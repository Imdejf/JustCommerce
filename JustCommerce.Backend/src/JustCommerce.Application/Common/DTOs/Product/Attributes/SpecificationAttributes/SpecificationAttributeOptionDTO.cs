using JustCommerce.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes
{
    public sealed class SpecificationAttributeOptionDTO : Entity
    {
        public Guid Id { get; set; }
        public Guid SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<SpecificationAttributeOptionLangDTO> SpecificationAttributeOptionLang { get; set; }
    }
}
