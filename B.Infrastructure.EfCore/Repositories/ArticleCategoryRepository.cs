using Blog.Management.Domain.ArticleCategoryAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleCategoryRepository : Repository<ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _dbContext;
        public ArticleCategoryRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
