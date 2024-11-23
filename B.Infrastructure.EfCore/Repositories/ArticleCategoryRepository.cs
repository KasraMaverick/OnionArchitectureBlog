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

        public async Task<string> GetTitleById(long categoryId)
        {
            List<ArticleCategory> categoryList = await _dbContext.ArticleCategories.Where(x => x.ArticleCategoryId == categoryId).ToListAsync();
            var category = categoryList.FirstOrDefault();
            if (category == null)
            {
                return null;
            }
            return category.Title;
        }
    }
}
