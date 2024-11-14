using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : Repository<Article>
    {
        private readonly BlogContext _dbContext;
        public ArticleRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
