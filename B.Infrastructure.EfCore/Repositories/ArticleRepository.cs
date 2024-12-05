using _0_Framework.Log;
using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        #region INJECTION

        private readonly BlogContext _dbContext;
        private readonly ILogService _logService;
        const string className = nameof(ArticleRepository);
        public ArticleRepository(BlogContext dbContext, ILogService logService) : base(dbContext)
        {
            _dbContext = dbContext;
            _logService = logService;
        }

        #endregion


        #region CRUD

        public async Task<List<Article>> GetAll(long authorId)
        {
            return await _dbContext.Articles.Where(x => x.AuthorId == authorId).ToListAsync();
        }


        #endregion


        #region PUBLISH & ARCHIVE & ACTIVATE

        public async Task<bool> Activate(long articleId)
        {
            try
            {
                if (articleId == 0)
                {
                    _logService.LogError($@"{className}/Activate", "articleid was zero");
                    return false;
                }
                
                Article? val = await _dbContext.FindAsync<Article>(new object[1] { articleId });

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

        public async Task<bool> Deactivate(long articleId)
        {
            try
            {
                Article? val = await _dbContext.FindAsync<Article>(new object[1] { articleId });

                if (articleId == 0 || val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.DeActivate();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> Publish(long articleId)
        {
            try
            {
                Article val = await _dbContext.FindAsync<Article>(new object[1] { articleId });

                if (articleId == 0 || val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Publish();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Archive(long articleId)
        {
            try
            {
                Article val = await _dbContext.FindAsync<Article>(new object[1] { articleId });

                if (articleId == 0 || val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Archive();
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
