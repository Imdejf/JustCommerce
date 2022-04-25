﻿using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Category;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Product;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.ProductType;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Category;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Product;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ProductType;
using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Category;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.Product;
using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Company;
using JustCommerce.Persistence.DataAccess.Repositories.ManagementRepositories.Company;

namespace JustCommerce.Persistence.DataAccess
{
    public sealed class JustCommerceDbContext : DbContext, IUnitOfWorkAdministration, IUnitOfWorkManagmenet
    {
        private readonly ICurrentUserService _currentUserService;

        public JustCommerceDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserPermissionEntity> UserPermission { get; set; }
        public DbSet<EmailAccountEntity> EmailAccount { get; set; }
        public DbSet<EmailTemplateEntity> EmailTemplate { get; set; }
        public DbSet<ShopEntity> ShopEntity { get; set; }

        //Repository
        public DbSet<ProductTypeEntity> _ProductType { get; set; }
        public IProductTypeRepository ProductType => new ProductTypeRepository(_ProductType);

        public DbSet<ProductTypePropertyEntity> _ProductTypeProperty { get; set; }
        public IProductTypePropertyRepository ProductTypeProperty => new ProductTypePropertyRepository(_ProductTypeProperty);

        public DbSet<CategoryEntity> _Category { get; set; }
        public ICategoryRepository Category => new CategoryRepository(_Category);

        public DbSet<ProductEntity> _Product { get; set; }
        public IProductRepository Product => new ProductRepository(_Product);

        public DbSet<ShopEntity> _Shop { get; set; }
        public IShopRepository Shop => new ShopRepository(_Shop);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.CurrentUser.Id.ToString();
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.CurrentUser.Id.ToString();
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
