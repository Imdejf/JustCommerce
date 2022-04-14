using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.DTOs
{
    public class ProductTypePropertyLangDTO
    {
        public Guid ProductTypePropertyId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string DefualtValue { get; set; }
        public string IsoCode { get; set; }
    }
}
