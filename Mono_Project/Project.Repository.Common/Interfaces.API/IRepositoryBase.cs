using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Project.Repository.Common.Interfaces.API
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        Task<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
