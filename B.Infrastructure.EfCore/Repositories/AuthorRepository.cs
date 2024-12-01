using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Domain.AuthorAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {

        #region INJECTION

        private readonly BlogContext _dbContext;
        public AuthorRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        #endregion


        #region ADD-ARTICLE-COUNT / ACTIVATE / DEACTIVATE

        public async Task<bool> AddArticleCount(long authorId)
        {
            try
            {
                if (authorId == 0)
                {
                    return false;
                }

                Author? val = await _dbContext.FindAsync<Author>(new object[1] { authorId });


                if (val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.AddArticleCount();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Activate(long authorId)
        {
            try
            {
                if (authorId == 0)
                {
                    return false;
                }

                Author? val = await _dbContext.FindAsync<Author>(new object[1] { authorId });
               

                if (val == null)
                {
                    return false;
                }

                _dbContext.Entry(val).State = EntityState.Detached;
                val.Activate();
                _dbContext.Entry(val).State = EntityState.Modified;

                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Deactivate(long authorId)
        {
            try
            {
                if (authorId == 0)
                {
                    return false;
                }

                Author? val = await _dbContext.FindAsync<Author>(new object[1] { authorId });


                if (val == null)
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

        #endregion

    }
}
