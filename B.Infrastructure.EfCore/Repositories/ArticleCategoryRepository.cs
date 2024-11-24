using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : Repository<ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _dbContext;
        public ArticleCategoryRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ArticleCategory>> GetTitles()
        {
            List<ArticleCategory> categoryList = await _dbContext.ArticleCategories.Select(x => x.CategoryId, x => x.Title).ToListAsync();
            return categoryList;
        }
    }
}
