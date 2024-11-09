using _0_Framework.Application.Model;
using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
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
        public async Task<OperationResultWithData<List<ArticleCategory>>> GetAllArticleCategories()
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
