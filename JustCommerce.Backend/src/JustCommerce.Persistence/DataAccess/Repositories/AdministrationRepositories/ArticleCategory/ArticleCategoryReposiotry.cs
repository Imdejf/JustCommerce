﻿using JustCommerce.Application.Common.Interfaces.DataAccess.Repository.AdministrationRepositories.ArticleCategory;
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

        public Task<ArticleCategoryEntity?> GetFullArticleCategoryAsync(Guid articleCategoryId, CancellationToken cancellationToken = default)
        {
            return _entity.Include(c => c.ArticleCategoryLang)
                          .ThenInclude(c => c.Language)
                          .Include(c => c.ArticleCategoryRelated)
                          .FirstOrDefaultAsync(c => c.Id == articleCategoryId);
        }
    }
}