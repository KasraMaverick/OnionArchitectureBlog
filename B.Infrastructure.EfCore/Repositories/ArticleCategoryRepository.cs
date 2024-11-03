using B.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace B.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly BlogContext _dbContext;
        public ArticleCategoryRepository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        //-------------------- ADD ARTICLE CATEGORY --------------------\\
        public async Task AddArticleCategory(ArticleCategory articleCategory)
        {
            await _dbContext.ArticleCategories.AddAsync(articleCategory);
            await SaveChanges();
        }

        //-------------------- GET ALL ARTICLE CATEGORIES --------------------\\
        public async Task<List<ArticleCategory>> GetAllArticleCategories()
        {
            return await _dbContext.ArticleCategories.ToListAsync();
        }

        //------------------- SAVE CHANGES --------------------\\
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
