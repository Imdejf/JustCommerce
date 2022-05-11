using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Domain.Entities.Article;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ArticleCategory
{
    public interface IArticleCategoryRepository : IBaseRepository<ArticleCategoryEntity>
    {
        Task<bool> ExistSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<ArticleCategoryEntity?> GetFullArticleCategoryAsync(Guid articleCategoryId, CancellationToken cancellationToken = default);

    }
}
