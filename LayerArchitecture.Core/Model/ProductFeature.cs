using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace LayerArchitecture.Core.Model
{
    public class ProductFeature
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
#nullable disable