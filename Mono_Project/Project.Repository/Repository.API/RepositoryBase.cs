using System;
using Project.Repository.Common.Interfaces.API;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Repository.API
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext applicationContext { get; set; }

        public RepositoryBase(ApplicationContext repositoryContext)
        {
            this.applicationContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.applicationContext.Set<T>().AsQueryable();
        }

        public async Task<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await this.applicationContext.Set<T>().Where(expression).SingleOrDefaultAsync();
        }

        public async Task<bool> Create(T entity)
        {
            this.applicationContext.Set<T>().Add(entity);
            return (await applicationContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Update(T entity)
        {
            this.applicationContext.Set<T>().Update(entity);
            return (await applicationContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            applicationContext.Set<T>().Remove(entity);
            return (await applicationContext.SaveChangesAsync()) > 0;
        }
    }
}
