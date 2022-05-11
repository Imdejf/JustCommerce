using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.Article
{
    public interface IArticleRepository : IBaseRepository<ArticleEntity>
    {
        Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<ArticleEntity> GetFullArticleAsync(Guid articleId, CancellationToken cancellationToken = default);
        Task<List<ArticleEntity>> GetAllByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default);
    }
}
