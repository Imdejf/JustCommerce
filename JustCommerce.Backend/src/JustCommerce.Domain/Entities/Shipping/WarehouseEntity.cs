using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Common;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Products.Product;

namespace JustCommerce.Domain.Entities.Shipping
{
    public sealed class WarehouseEntity : Entity
    {
        /// <summary>
        /// Gets or sets the warehouse name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the address identifier of the warehouse
        /// </summary>
        public Guid AddressId { get; set; }
        public AddressEntity Adress { get; set; }
        public Guid StoreId { get; set; }
        public StoreEntity Store { get; set; }
        public ICollection<ProductWarehouseInventoryEntity> ProductWarehouseInventory { get; set; }
    }
}
