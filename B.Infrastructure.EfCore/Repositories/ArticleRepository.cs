﻿using Blog.Management.Domain.ArticleAgg;
using Blog.Management.Infrastructure.EfCore.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Blog.Management.Infrastructure.EfCore.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly BlogContext _dbContext;
        public ArticleRepository(BlogContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<List<Article>> GetAll(long authorId)
        {
            return await _dbContext.Articles.Where(x => x.AuthorId == authorId).ToListAsync();
        }
    }
}
