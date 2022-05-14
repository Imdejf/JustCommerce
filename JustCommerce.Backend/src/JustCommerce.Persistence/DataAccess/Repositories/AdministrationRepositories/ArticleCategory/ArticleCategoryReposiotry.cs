using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ArticleCategory;
using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.ArticleCategory
{
    internal sealed class ArticleCategoryReposiotry : BaseRepository<ArticleCategoryEntity>, IArticleCategoryRepository
    {
        public ArticleCategoryReposiotry(DbSet<ArticleCategoryEntity> entity) : base(entity)
        {
        }

        public Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Slug == slug).AnyAsync(cancellationToken);
        }

        public Task<List<ArticleCategoryEntity>> GetAllByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.ArticleCategoryLang)
                          .Where(c => c.ShopId == shopId)
                          .ToListAsync(cancellationToken);
        }

        public Task<ArticleCategoryEntity?> GetFullArticleCategoryAsync(Guid articleCategoryId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.ArticleCategoryLang)
                          .FirstOrDefaultAsync(c => c.Id == articleCategoryId, cancellationToken);
        }
    }
}
