using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerArchitecture.Core.DTOs
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
