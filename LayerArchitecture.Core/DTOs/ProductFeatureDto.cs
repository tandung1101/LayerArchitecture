using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerArchitecture.Core.DTOs
{
#nullable disable
    public class ProductFeatureDto
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        public ProductFeatureDto(Guid id, string color, int height, int width, int productId)
        {
            Id = id;
            Color = color;
            Height = height;
            Width = width;
            ProductId = productId;
        }

        public ProductFeatureDto()
        {

        }
    }
#nullable enable
}
