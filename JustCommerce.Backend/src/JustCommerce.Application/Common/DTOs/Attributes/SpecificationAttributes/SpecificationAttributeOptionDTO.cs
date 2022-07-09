using JustCommerce.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes
{
    public sealed class SpecificationAttributeOptionDTO : Entity
    {
        public Guid Id { get; set; }
        public Guid SpecificationAttributeId { get; set; }
        public SpecificationAttributeEntity SpecificationAttribute { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color RGB value (used when you want to display "Color squares" instead of text)
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        public ICollection<SpecificationAttributeOptionLangEntity> SpecificationAttributeOptionLang { get; set; }
        public ICollection<ProductSpecificationAttributeEntity> ProductSpecificationAttribute { get; set; }
    }
}
