using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.CheckoutAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.ProductAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Attributes.SpecificationAttributes;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Category;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Manufacturer;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Product;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product.Tags;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Permission;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.Language;
using JustCommerce.Domain.Entities.Products.Attributes.CheckoutAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.ProductAttribute;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using JustCommerce.Domain.Entities.Products.Category;
using JustCommerce.Domain.Entities.Products.Manufacturer;
using JustCommerce.Domain.Entities.Products.Product;
using JustCommerce.Domain.Entities.Products.Tags;
using JustCommerce.Persistence.DataAccess.Repositories;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Attributes.Product.CheckoutAttributes;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.Manufacturer;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.ProductAttributes;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.SpecificationAttributes;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Attributes.Tags;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Category;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product.Product;
using JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Permission;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JustCommerce.Persistence.DataAccess
{
    public sealed class JustCommerceDbContext : DbContext, IUnitOfWorkAdministration, IUnitOfWorkManagmenet, IUnitOfWorkCommon
    {
        private readonly ICurrentUserService _currentUserService;

        public JustCommerceDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<CMSUserEntity> Users { get; set; }
        public DbSet<UserPermissionEntity> UserPermission { get; set; }



        //Repository

        private DbSet<StoreEntity> _Store { get; set; }
        public IBaseRepository<StoreEntity> Store => new BaseRepository<StoreEntity>(_Store);

        private DbSet<UserPermissionEntity> _UserPermission { get; set; }
        public IPermissionReposiotry Permission => new PermissionRepository(_UserPermission);

        private DbSet<LanguageEntity> _Language { get; set; }
        public IBaseRepository<LanguageEntity> Language => new BaseRepository<LanguageEntity>(_Language);

        private DbSet<ProductAttributeEntity> _ProductAttribute{ get; set; }
        public IProductAttributeRepository ProductAttribute => new ProductAttributeRepository(_ProductAttribute);

        private DbSet<SpecificationAttributeGroupEntity> _SpecificationAttributeGroup { get; set; }

        public ISpecificationAttributeGroupRepository SpecificationAttributeGroup => new SpecificationAttributeGroupRepository(_SpecificationAttributeGroup);

        private DbSet<SpecificationAttributeEntity> _SpecificationAttribute { get; set; }
        public ISpecificationAttributeRepository SpecificationAttribute => new SpecificationAttributeRepository(_SpecificationAttribute);

        private DbSet<SpecificationAttributeOptionEntity> _SpecificationAttributeOption { get; set; }
        public ISpecificationAttributeOptionRepository SpecificationAttributeOption => new SpecificationAttributeOptionRepository(_SpecificationAttributeOption);

        private DbSet<CheckoutAttributeEntity> _CheckoutAttribute { get; set; }
        private DbSet<CheckoutAttributeValueEntity> _CheckoutAttributeValue { get; set; }
        public ICheckoutAttrbiuteRepository CheckoutAttrbiute => new CheckoutAttrbiuteRepository(_CheckoutAttribute, _CheckoutAttributeValue);

        private DbSet<ProductTagEntity> _ProductTag { get; set; }
        public IProductTagRepository ProductTag => new ProductTagRepository(_ProductTag);

        private DbSet<ManufacturerEntity> _Manufacturer { get; set; }
        public IManufacturerRepository Manufacturer => new ManufacturerRepository(_Manufacturer);

        private DbSet<CategoryEntity> _Category { get; set; }
        public ICategoryRepository Category => new CategoryRepository(_Category);

        private DbSet<ProductEntity> _Product { get; set; }
        public IProductRepository Product => new ProductRepository(_Product);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
