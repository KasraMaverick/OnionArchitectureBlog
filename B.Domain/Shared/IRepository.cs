using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Management.Domain.Shared
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Edit(T command, long key);
        Task<bool> Delete(long id);
        Task<bool> Exists(Expression<Func<T, bool>> expression);
        Task<T> GetById(long id);
        Task<List<T>> Get();
        Task SaveChanges();
        IQueryable<T> FindAll();
    }
}
