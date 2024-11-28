using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerArchitecture.Core.DTOs
{
#nullable disable
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public ProductDto(Guid id, DateTime createdDate, string name, int stock, decimal price, Guid categoryId)
        {
            Id = id;
            CreatedDate = createdDate;
            Name = name;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }
        public ProductDto()
        {

        }
    }
#nullable enable
}
