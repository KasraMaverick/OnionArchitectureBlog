using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly BlogContext _dbContext;
        public AuthorRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }
    }
}
