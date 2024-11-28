using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LayerArchitecture.Core.DTOs;
using LayerArchitecture.Core.Model;
using LayerArchitecture.Core.Repositories;
using LayerArchitecture.Core.Services;
using LayerArchitecture.Core.UnitOfWorks;

namespace LayerArchitecture.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository,
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IMapper mapper) :
            base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // FOR WEB
        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return productsDto;
        }
    }
}
