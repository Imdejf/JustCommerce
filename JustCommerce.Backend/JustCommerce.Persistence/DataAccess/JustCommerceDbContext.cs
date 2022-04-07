using JustCommerce.Domain.Entities.Abstract;
using JustCommerce.Domain.Entities.Company;
using JustCommerce.Domain.Entities.Email;
using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace JustCommerce.Persistence.DataAccess
{
    public sealed class JustCommerceDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        private readonly ICurrentUserService _currentUserService;

        public JustCommerceDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<UserEntity> Users { get; set; }
        //public DbSet<EmailAccountEntity> EmailAccount { get; set; }
        //public DbSet<EmailTemplateEntity> EmailTemplate { get; set; }
        //public DbSet<ShopEntity> ShopEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser<Guid>>().ToTable("User", "identity");
            builder.Entity<IdentityRole<Guid>>().ToTable("Role", "identity");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole", "identity");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim", "identity");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin", "identity");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim", "identity");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken", "identity");

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
