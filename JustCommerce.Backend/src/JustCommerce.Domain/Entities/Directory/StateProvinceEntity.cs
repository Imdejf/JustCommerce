using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Common;

namespace JustCommerce.Domain.Entities.Directory
{
    public sealed class StateProvinceEntity : Entity
    {
        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public Guid CountryId { get; set; }
        public CountryEntity Country { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        public ICollection<AddressEntity> Address{ get; set; }
    }
}
