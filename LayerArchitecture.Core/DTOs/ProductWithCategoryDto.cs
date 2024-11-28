using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerArchitecture.Core.Model;

namespace LayerArchitecture.Core.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto CategoryDto { get; set; } = new CategoryDto();
    }
}
