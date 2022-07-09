using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.ManagementRepositories.Store;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Entities.Products.Attributes;
using JustCommerce.Persistence.DataAccess.Repositories;
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

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserPermissionEntity> UserPermission { get; set; }



        //Repository
        private DbSet<ProductAttributeEntity> _ProductAttribute { get; set; }
        public IBaseRepository<ProductAttributeEntity> ProductAttribute => new BaseRepository<ProductAttributeEntity>(_ProductAttribute);

        private DbSet<StoreEntity> _Store { get; set; }
        public IBaseRepository<StoreEntity> Store => new BaseRepository<StoreEntity>(_Store);

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
