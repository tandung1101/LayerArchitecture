using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerArchitecture.Core.DTOs;
using LayerArchitecture.Core.Model;

namespace LayerArchitecture.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(Guid categoryId);
    }
}
