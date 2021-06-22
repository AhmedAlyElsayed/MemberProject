using MemberProject.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MemberProject.Services.Generic
{
    public interface IGService<D, T, R>
    {
        #region Add Method
        IResponseDTO Add(D dtoModel);
        ValueTask<IResponseDTO> AddAsync(D dtoObject);
        IResponseDTO AddRange(IEnumerable<D> dtoObjects);
        ValueTask<IResponseDTO> AddRangeAsync(IEnumerable<D> dtoObjects);
        #endregion

        #region Delete Method
        /// <summary> 
        /// Mark entity to be deleted within the repository 
        /// </summary> 
        /// <param name="entity">The entity to delete</param> 
        IResponseDTO Remove(D entity);
        IResponseDTO RemoveRange(IEnumerable<D> dtoObjects);
        #endregion

        #region Update Method
        /// <summary> 
        /// Updates entity within the the repository 
        /// </summary> 
        /// <param name="entity">the entity to update</param> 
        /// <returns>The updates entity</returns> 
        IResponseDTO Update(D entity);

        #endregion

        #region Get Methods

        IResponseDTO GetAll();
        ValueTask<IResponseDTO> GetAllAsync();
        IResponseDTO GetAll(Expression<Func<T, bool>> where);
        ValueTask<IResponseDTO> GetAllAsync(Expression<Func<T, bool>> where);
        IResponseDTO GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> select);
        ValueTask<IResponseDTO> GetAllAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> select);
        IResponseDTO GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        ValueTask<IResponseDTO> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        IResponseDTO GetFirstOrDefault();
        ValueTask<IResponseDTO> GetFirstOrDefaultAsync();
        IResponseDTO GetLastOrDefault();
        ValueTask<IResponseDTO> GetLastOrDefaultAsync();
        IResponseDTO GetFirstOrDefault(Expression<Func<T, bool>> where);
        ValueTask<IResponseDTO> GetFirstOrDefaultAsync(Expression<Func<T, bool>> where);
        IResponseDTO GetLastOrDefault(Expression<Func<T, bool>> where);
        ValueTask<IResponseDTO> GetLastOrDefaultAsync(Expression<Func<T, bool>> where);
        #endregion

        #region Pagination Methods


        IResponseDTO Paginate<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IResponseDTO PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);

        IResponseDTO PaginateDescending<TKey>(
            int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        #endregion

        #region Count Methods
        IResponseDTO Count();
        ValueTask<IResponseDTO> CountAsync();
        #endregion

        #region Find Methods
        IResponseDTO Find(params object[] keys);
        ValueTask<IResponseDTO> FindAsync(params object[] keys);
        IResponseDTO Find(Func<T, bool> where);
        ValueTask<IResponseDTO> FindAsync(Expression<Func<T, bool>> match);
        #endregion

        #region Aggregation Methods
        IResponseDTO GetMinimum();
        ValueTask<IResponseDTO> GetMinimumAsync();
        IResponseDTO GetMinimum(Expression<Func<T, object>> selector);
        ValueTask<IResponseDTO> GetMinimumAsync(Expression<Func<T, object>> selector);


        IResponseDTO GetMaximum();
        ValueTask<IResponseDTO> GetMaximumAsync();
        IResponseDTO GetMaximum(Expression<Func<T, object>> selector);
        ValueTask<IResponseDTO> GetMaximumAsync(Expression<Func<T, object>> selector);
        #endregion
    }
}
