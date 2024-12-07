using _0_Framework.Log;
using Blog.Management.Domain.CommentAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly BlogContext _dbContext;
        private readonly ILogService _logService;
        const string className = nameof(CommentRepository);
        public CommentRepository(BlogContext dbContext, ILogService logService) : base(dbContext)
        {
            _dbContext = dbContext;
            _logService = logService;
        }

        public async Task<bool> Activate(long commentId)
        {
            try
            {
                if (commentId == 0)
                {
                    _logService.LogError($@"{className}/Activate", "commentId was zero");
                    return false;
                }

                Comment? val = await _dbContext.FindAsync<Comment>(new object[1] { commentId });

                if (val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Activate();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                _logService.LogError($@"{className}/Activate", "activate result was successfully saved");
                return true;
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in activation");
                return false;
            }
        }

        public async Task<bool> Deactivate(long commentId)
        {
            try
            {
                if (commentId == 0)
                {
                    _logService.LogError($@"{className}/Deactivate", "commentId was zero");
                    return false;
                }

                Comment? val = await _dbContext.FindAsync<Comment>(new object[1] { commentId });

                if (val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Deactivate();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                _logService.LogError($@"{className}/Dectivate", "deactivate result was successfully saved");
                return true;
            }
            catch (Exception ex)
            {
                _logService.LogException(ex, className, "exception error in deactivation");
                return false;
            }
        }

        public Task<List<Comment>> GetAll(long articleId)
        {
            throw new NotImplementedException();
        }
    }
}
