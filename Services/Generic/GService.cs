using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MemberProject.Repository.Generic;
using MemberProject.Common.Interfaces;

namespace MemberProject.Services.Generic
{
    public class GService<D, T, R> : IGService<D, T, R>
        where R : IGRepository<T>
        where T : class
    {
        #region Private Fields
        protected readonly R _genericRepository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="genericRepository">Inject IGenericRepository interface</param>
        public GService(R genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        #endregion

        #region Add Method
        /// <summary>
        /// Insert a single entity
        /// </summary>
        /// <param name="dtoObject"></param>
        /// <returns></returns>
        public virtual IResponseDTO Add(D dtoObject)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                T entityObj = _mapper.Map<T>(dtoObject);

                object addedModel = _genericRepository.Add(entityObj);

                IResponseDTO.Data = _mapper.Map<D>(addedModel);
                IResponseDTO.IsPassed = true;
                IResponseDTO.Message = "Ok";
            }
            catch (Exception ex)
            {
                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
                return IResponseDTO;
            }
            return IResponseDTO;
        }
        /// <summary>
        /// Insert a single entity asynchronously
        /// </summary>
        /// <param name="dtoObject"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> AddAsync(D dtoObject)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                T entityObj = _mapper.Map<T>(dtoObject);
                await _genericRepository.AddAsync(entityObj);
                IResponseDTO.IsPassed = true;
                IResponseDTO.Message = "Ok";
            }
            catch (Exception ex)
            {
                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
                return IResponseDTO;
            }
            return IResponseDTO;
        }
        /// <summary>
        /// Insert a list of entities
        /// </summary>
        /// <param name="dtoObjects"></param>
        /// <returns></returns>
        public virtual IResponseDTO AddRange(IEnumerable<D> dtoObjects)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                ICollection<T> models = _mapper.Map<ICollection<T>>(dtoObjects);
                _genericRepository.AddRange(models);
                IResponseDTO.IsPassed = true;
                IResponseDTO.Message = "Ok";
            }
            catch (Exception ex)
            {
                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
            }
            return IResponseDTO;
        }
        /// <summary>
        /// Insert a list of entities asynchronously
        /// </summary>
        /// <param name="dtoObjects"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> AddRangeAsync(IEnumerable<D> dtoObjects)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                ICollection<T> models = _mapper.Map<ICollection<T>>(dtoObjects);
                await _genericRepository.AddRangeAsync(models);
                IResponseDTO.IsPassed = true;
                IResponseDTO.Message = "Ok";
            }
            catch (Exception ex)
            {
                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
                return IResponseDTO;
            }
            return IResponseDTO;
        }
        #endregion

        #region Count Methods
        /// <summary>
        /// Retrieve the count of currently exisiting records 
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO Count()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.Count());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the count of currently exisiting records asynchronously
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> CountAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<Task<D>>(await _genericRepository.CountAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        #endregion

        #region Remove Method
        /// <summary>
        /// Soft delete of records by updating is deleted property to be true
        /// </summary>
        /// <param name="dtoObject"></param>
        /// <returns></returns>
        public virtual IResponseDTO Remove(D dtoObject)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                T entityObject = _mapper.Map<T>(dtoObject);
                IResponseDTO.Data = _genericRepository.Remove(entityObject);


                IResponseDTO.IsPassed = true;
                IResponseDTO.Message = "Ok";
            }
            catch (Exception ex)
            {


                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
                return IResponseDTO;
            }
            return IResponseDTO;
        }
        /// <summary>
        /// Logically or physically deleting list of records based on the entity type
        /// </summary>
        /// <param name="dtoObjects"></param>
        /// <returns></returns>
        public virtual IResponseDTO RemoveRange(IEnumerable<D> dtoObjects)
        {
            IResponseDTO IResponseDTO = new ResponseDTO();
            try
            {
                IEnumerable<T> entityObjects = _mapper.Map<IEnumerable<T>>(dtoObjects);

                if (entityObjects != null && entityObjects.Count() > 0)
                {
                    _genericRepository.RemoveRange(entityObjects);
                    IResponseDTO.IsPassed = true;
                    IResponseDTO.Message = "Ok";
                }
            }
            catch (Exception ex)
            {
                IResponseDTO.IsPassed = false;
                IResponseDTO.Message = "Internal Error" + ex.Message;
                return IResponseDTO;
            }
            IResponseDTO.IsPassed = true;
            IResponseDTO.Message = "Ok";
            return IResponseDTO;
        }
        #endregion

        #region Find Methods
        /// <summary>
        /// Searches for a record with a specified primary key values
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public virtual IResponseDTO Find(params object[] keys)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.Find(keys));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Searches for a record with a specified primary key values asynchronously
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> FindAsync(params object[] keys)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<Task<D>>(await _genericRepository.FindAsync(keys));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Searches for a record with a specified condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IResponseDTO Find(Func<T, bool> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.Find(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Searches for a record or list of records that match(es) a specified condition asynchronously
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> FindAsync(Expression<Func<T, bool>> match)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<Task<D>>(await _genericRepository.FindAsync(match));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        #endregion

        #region Get Methods
        /// <summary>
        ///  Retrieve a list of records based on a specified condition
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetAll(Expression<Func<T, bool>> whereCondition)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(_genericRepository.GetAll(whereCondition));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        ///  Retrieve a list of records 
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO GetAll()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(_genericRepository.GetAll());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        ///  Retrieve a list of records based on a specified condition with a specifed set of properties
        /// </summary>
        /// <param name="where"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> select)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(_genericRepository.GetAll(where, select));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        ///  Retrieve a list of records asynchronously
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetAllAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(await _genericRepository.GetAllAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        ///  Retrieve a list of records based on a specified condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetAllAsync(Expression<Func<T, bool>> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(await _genericRepository.GetAllAsync(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve a list of records based on a specified condition with a specifed set of properties
        /// </summary>
        /// <param name="where"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetAllAsync(Expression<Func<T, bool>> where, Expression<Func<T, object>> select)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(await _genericRepository.GetAllAsync(where, select));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve a list of records with a specifed set of properties
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(_genericRepository.GetAllIncluding(includeProperties));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve a list of records with a specifed set of properties asynchronously
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IQueryable<D>>(await _genericRepository.GetAllIncludingAsync(includeProperties));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the first record
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO GetFirstOrDefault()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetFirst());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the first record based on specified condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetFirstOrDefault(Expression<Func<T, bool>> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetFirst(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the first record with asynchronous execution
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetFirstOrDefaultAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetFirstAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the first record based on specified condition with asynchronous execution
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetFirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetFirstAsync(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the last record
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO GetLastOrDefault()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetLast());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the last record based on specified condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetLastOrDefault(Expression<Func<T, bool>> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetLast(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the last record with asynchronous execution
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetLastOrDefaultAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetLastAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Retrieve the last record based on specified condition with asynchronous execution
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetLastOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetLastAsync(where));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        #endregion

        #region Pagination Methods

        /// <summary>
        /// Paginate the retrieved records besed on specific conditions with specified set of properties and specified key used in order
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keySelector"></param>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IResponseDTO Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IEnumerable<D>>(_genericRepository.Paginate(pageIndex, pageSize, keySelector, predicate));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Paginate the retrieved records with specified set of properties and specified key used in Descending order
        /// </summary>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public virtual IResponseDTO PaginateDescending<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IEnumerable<D>>(_genericRepository.PaginateDescending(pageIndex, pageSize, keySelector));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        /// <summary>
        /// Paginate the retrieved records based on specified condition and specified set of properties and specified key used in Descending order
        /// </summary>
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="keySelector"></param>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IResponseDTO PaginateDescending<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<IEnumerable<D>>(_genericRepository.PaginateDescending(pageIndex, pageSize, keySelector, predicate, includeProperties));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        #endregion

        #region Update Method
        /// <summary>
        /// Update record data
        /// </summary>
        /// <param name="dtoObject"></param>
        /// <returns></returns>
        public virtual IResponseDTO Update(D dtoObject)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                T entityToBeUpdated = _mapper.Map<T>(dtoObject);
                response.Data = _mapper.Map<D>(_genericRepository.Update(entityToBeUpdated));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        #endregion

        #region GetMinimum Methods
        /// <summary>
        ///  Retrieve the minimum of generic list
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO GetMinimum()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetMinimum());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the minimum of generic list asynchronusly
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetMinimumAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetMinimumAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the minimum of generic list using a given key
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetMinimum(Expression<Func<T, object>> selector)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetMinimum(selector));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the minimum of generic list using a given key asynchronously
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetMinimumAsync(Expression<Func<T, object>> selector)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetMinimumAsync(selector));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }
        #endregion

        #region GetMaximum Methods
        /// <summary>
        /// Retrieve the maximum of generic list
        /// </summary>
        /// <returns></returns>
        public virtual IResponseDTO GetMaximum()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetMaximum());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the maximum of generic list asynchronously
        /// </summary>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetMaximumAsync()
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetMaximumAsync());
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the maximum of generic list using a given key
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual IResponseDTO GetMaximum(Expression<Func<T, object>> selector)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(_genericRepository.GetMaximum(selector));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Retrieve the maximum of generic list using a given key asynchronously
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async ValueTask<IResponseDTO> GetMaximumAsync(Expression<Func<T, object>> selector)
        {
            IResponseDTO response = new ResponseDTO();
            try
            {
                response.Data = _mapper.Map<D>(await _genericRepository.GetMaximumAsync(selector));
                response.IsPassed = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                response.IsPassed = false;
                response.Message = "Internal Error" + ex.Message;
            }
            return response;
        }

        #endregion

    }
}