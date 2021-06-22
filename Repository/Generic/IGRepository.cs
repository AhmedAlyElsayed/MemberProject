using MemberProject.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MemberProject.Repository.Generic
{
    public interface IGRepository<T> where T : class
    {
        #region Find Methods
        T Find(params object[] keys);
        ValueTask<T> FindAsync(params object[] keys);
        T Find(Func<T, bool> where);
        ValueTask<T> FindAsync(Expression<Func<T, bool>> match);
        #endregion

        #region Add Methods
        object Add(T entity);
        ValueTask AddAsync(T t);
        void AddRange(IEnumerable<T> entities);
        ValueTask AddRangeAsync(IEnumerable<T> entities);
        #endregion

        #region Count Methods
        int Count();
        ValueTask<int> CountAsync();
        #endregion

        #region Remove Methods
        EntityEntry<T> Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Truncate();

        #endregion

        #region Get Methods
        IQueryable<T> GetAll();
        ValueTask<IQueryable<T>> GetAllAsync();
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        ValueTask<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where);
        IQueryable<object> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> select);
        ValueTask<IQueryable<object>> GetAllAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> select);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        ValueTask<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        T GetFirst();
        ValueTask<T> GetFirstAsync();
        T GetLast();
        ValueTask<T> GetLastAsync();
        T GetFirst(Expression<Func<T, bool>> where);
        ValueTask<T> GetFirstAsync(Expression<Func<T, bool>> where);
        T GetLast(Expression<Func<T, bool>> where);
        ValueTask<T> GetLastAsync(Expression<Func<T, bool>> where);

        #endregion

        #region Update Method
        EntityEntry<T> Update(T entity);
        #endregion

        #region Pagination Methods


        PaginatedList<T> Paginate<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        PaginatedList<T> PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);

        PaginatedList<T> PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        #endregion

        #region Release Unmanaged Resources
        void Dispose(bool disposing);
        #endregion

        #region GetMinimum Methods
        T GetMinimum();
        ValueTask<T> GetMinimumAsync();
        object GetMinimum(Expression<Func<T, object>> selector);
        ValueTask<object> GetMinimumAsync(Expression<Func<T, object>> selector);

        #endregion

        #region GetMaximum Methods
        T GetMaximum();
        ValueTask<T> GetMaximumAsync();
        object GetMaximum(Expression<Func<T, object>> selector);
        ValueTask<object> GetMaximumAsync(Expression<Func<T, object>> selector);
        #endregion

    }
}
