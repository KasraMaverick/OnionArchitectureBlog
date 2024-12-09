using _0_Framework.Log;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Domain.CommentAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {

        #region INJECTION

        private readonly BlogContext _dbContext;
        private readonly ILogService _logService;
        const string className = nameof(CommentRepository);
        public CommentRepository(BlogContext dbContext, ILogService logService) : base(dbContext)
        {
            _dbContext = dbContext;
            _logService = logService;
        }

        #endregion


        #region CRUD

        public async Task<List<Comment>> GetAllForArticle(long articleId)
        {
            return await _dbContext.Comments.Where(x => x.ArticleId == articleId).ToListAsync();
        }
        public async Task<List<Comment>> GetAllForAuthor(long authorId)
        {
            return await _dbContext.Comments.Where(x => x.AuthorId == authorId).ToListAsync();
        }

        #endregion


        #region ACTIVATE/DEACTIVATE

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

        #endregion


        #region LIKE/DISLIKE

        public async Task<bool> Like(long commentId)
        {
            try
            {
                Comment? val = await _dbContext.FindAsync<Comment>(new object[1] { commentId });

                if (commentId == 0 || val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Like();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Dislike(long commentId)
        {
            try
            {
                Comment? val = await _dbContext.FindAsync<Comment>(new object[1] { commentId });

                if (commentId == 0 || val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Dislike();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
