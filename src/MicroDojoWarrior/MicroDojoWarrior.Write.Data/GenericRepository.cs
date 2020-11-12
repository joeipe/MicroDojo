using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MicroDojoWarrior.Write.Data
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbContext _dataContext;
        protected DbSet<TEntity> _dataTable;

        public GenericRepository(DbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException("writedataContext");
            _dataTable = _dataContext.Set<TEntity>();
        }

        public virtual void Create(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                _dataContext.Add(item);
            }
        }

        public virtual void Update(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                _dataContext.Update(item);
            }
        }

        public virtual void Delete(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                _dataContext.Remove(item);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dataTable.ToList();
        }

        public virtual TEntity Find(int id)
        {
            return _dataTable.SingleOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataTable.Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetAllInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public virtual IEnumerable<TEntity> SearchForInclude(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> GetAllIncluding(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
        {
            IQueryable<TEntity> queryable = _dataTable;
            queryable = includeProperties(queryable);
            return queryable;
        }
    }
}