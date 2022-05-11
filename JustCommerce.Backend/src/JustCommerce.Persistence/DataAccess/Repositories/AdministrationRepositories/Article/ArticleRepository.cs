using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Article;
using JustCommerce.Domain.Entities.Article;
using Microsoft.EntityFrameworkCore;

namespace JustCommerce.Persistence.DataAccess.Repositories.AdministrationRepositories.Article
{
    internal sealed class ArticleRepository : BaseRepository<ArticleEntity>, IArticleRepository
    {
        public ArticleRepository(DbSet<ArticleEntity> entity) : base(entity)
        {
        }

        public Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return _entity.Where(c => c.Slug == slug).AnyAsync(cancellationToken);
        }

        public Task<ArticleEntity?> GetFullArticleAsync(Guid articleId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.ArticleLang)
                          .ThenInclude(c => c.Language)
                          .Include(c => c.ArticleRelatedProduct)
                          .Include(c => c.ArticleCategoryRelated)
                          .FirstOrDefaultAsync(c => c.Id == articleId, cancellationToken);
        }
    }
}
