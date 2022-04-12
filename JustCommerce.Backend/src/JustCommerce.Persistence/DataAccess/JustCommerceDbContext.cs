using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories;
using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.ProductType;
using JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

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
                        entry.Entity.CreatedBy = _currentUserService.CurrentUser.UserId.ToString();
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.CurrentUser.UserId.ToString();
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
