using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using LayerArchitecture.Core.DTOs;
using LayerArchitecture.Core.Model;
using LayerArchitecture.Core.Repositories;
using LayerArchitecture.Core.Services;
using LayerArchitecture.Core.UnitOfWorks;
using LayerArchitecture.Service.Exceptions;

namespace LayerArchitecture.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IUnitOfWork unitOfWork, IProductRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetProductsWithCategory().Result);
            }


        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey) ?? [];
            return Task.FromResult(products);
        }

        public Task<Product> GetByIdAsync(Guid id)
        {
            var products = _memoryCache.Get<List<Product>>(CacheProductKey) ?? throw new NotFoundException($"{typeof(Product).Name}({id}) not found");
            var product = products.FirstOrDefault(x => x.Id == id);
            return product == null ? throw new NotFoundException($"{typeof(Product).Name}({id}) not found") : Task.FromResult(product);
        }

        //// FOR API
        //public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        //{
        //    var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);

        //    var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

        //    return Task.FromResult(CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsWithCategoryDto));
        //}


        // FOR WEB
        public Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);

            var productsWithCategoryDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return Task.FromResult(productsWithCategoryDto);
        }

        public async Task RemoveAsync(Product entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            var products = _memoryCache.Get<List<Product>>(CacheProductKey);
            if (products == null)
            {
                return Enumerable.Empty<Product>().AsQueryable();
            }
            return products.Where(expression.Compile()).AsQueryable();
        }


        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());

        }
    }
}
