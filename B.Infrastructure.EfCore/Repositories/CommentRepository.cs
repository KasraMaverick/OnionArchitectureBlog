using Blog.Management.Domain.CommentAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly BlogContext _dbContext;
        public CommentRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
