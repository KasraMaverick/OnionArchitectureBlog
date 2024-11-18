using Blog.Management.Domain.Shared;
using Blog.Management.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Blog.Management.Infrastructure.EfCore.Repositories.Shared
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BlogContext _dbContext;

        public Repository(BlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> Edit(T command, long key)
        {
            try
            {
                T val = await _dbContext.FindAsync<T>(new object[1] { key });
                if (val != null)
                {
                    _dbContext.Entry(val).State = EntityState.Detached;
                }

                _dbContext.Entry(command).State = EntityState.Modified;
                await SaveChanges();
                return command;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                T val = await _dbContext.FindAsync<T>(new object[1] { id });
                if (val != null)
                {
                    _dbContext.Remove(val);
                    await SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeActive(long id)
        {
            try
            {
                T val = await _dbContext.FindAsync<T>(new object[1] { id });
                if (val != null)
                {
                    _dbContext.Remove(val);
                    await SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }

        public async Task<T> GetById(long id)
        {
            return await _dbContext.FindAsync<T>(new object[1] { id });
        }

        public async Task<List<T>> Get()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return _dbContext.Set<T>();
        }

        public IDbContextTransaction GetTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }
    }
}