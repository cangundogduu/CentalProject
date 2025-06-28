using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BrandDtos
{
    public class ResultBrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public virtual List<Car>? Cars { get; set; }
    }
}
