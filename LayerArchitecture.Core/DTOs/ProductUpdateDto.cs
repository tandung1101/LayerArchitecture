using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerArchitecture.Core.DTOs
{
#nullable disable
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public ProductUpdateDto(string name, int Stock, int Price, Guid categoryId)
        {
            this.Name = name;
            this.Stock = Stock;
            this.Price = Price;
            this.CategoryId = categoryId;
        }
        public ProductUpdateDto()
        {

        }
    }
#nullable enable
}
