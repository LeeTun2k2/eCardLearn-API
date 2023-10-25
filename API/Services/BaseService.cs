using API.Data.Entities;
using API.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace API.Services
{
    /// <summary>
    /// Base Service
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="ViewModel"></typeparam>
    /// <typeparam name="AddModel"></typeparam>
    /// <typeparam name="EditModel"></typeparam>
    /// <typeparam name="FilterModel"></typeparam>
    public class BaseService<TEntity, ViewModel, AddModel, EditModel, FilterModel>
        : IBaseService<TEntity, ViewModel, AddModel, EditModel, FilterModel>
        where TEntity : class
        where ViewModel : class
        where AddModel : class
        where EditModel : class
        where FilterModel : class
    {
        /// <summary>
        /// Base Repository
        /// </summary>
        protected readonly IBaseRepository<TEntity> _repository;

        /// <summary>
        /// Auto mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ViewModel?> AddAsync(AddModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var addedEntity = await _repository.AddAsync(entity);
            return _mapper.Map<ViewModel>(addedEntity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            var result = await _repository.RemoveAsync(entity);
            return result;
        }

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<IEnumerable<ViewModel>?> GetAsync(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ViewModel?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var model = _mapper.Map<ViewModel>(entity);
            return model;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ViewModel?> UpdateAsync(Guid id, EditModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            var updatedEntity = await _repository.UpdateAsync(entity);
            return _mapper.Map<ViewModel>(updatedEntity);
        }
    }
}
