using API.Commons.Paginations;
using API.Data.DTOs.Notification;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Services.Implements
{
    /// <summary>
    /// Notification service
    /// </summary>
    public class NotificationService : BaseService<Notification, NotificationViewModel, NotificationAddModel, NotificationEditModel, NotificationFilterModel>, INotificationService
    {
        private new readonly INotificationRepository _repository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public NotificationService(INotificationRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IEnumerable<NotificationViewModel>?> GetAsync(NotificationFilterModel filter)
        {
            // Default filter condition
            Expression<Func<Notification, bool>> filterExpression = p => true; 

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.NotificationTitle))
                    filterExpression = p => p.NotificationTitle.Contains(filter.NotificationTitle);

                if (!string.IsNullOrEmpty(filter.NotificationContent))
                    filterExpression = p => p.NotificationContent.Contains(filter.NotificationContent);
            }

            // Default orderBy
            Func<IQueryable<Notification>, IOrderedQueryable<Notification>> orderBy = q => q.OrderBy(p => p.NotificationTitle); 

            // Define pagination parameters (skip and take)
            PaginationParameters pagination = new ()
            {
                PageNumber = filter?.PageNumber ?? PaginationDefaultValues.PageNumber,
                PageSize = filter?.PageSize ?? PaginationDefaultValues.PageSize
            };

            // Retrieve the data from the repository using the filter, orderBy, and pagination
            var entities = await _repository.GetAsync(filterExpression, orderBy, pagination);

            // Map the retrieved entities to ViewModel
            var models = _mapper.Map<IEnumerable<NotificationViewModel>>(entities);

            return models;
        }

        /// <summary>
        /// Get Notification by Class id
        /// </summary>
        /// <param name="ClassId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NotificationViewModel>> GetByClassId(Guid ClassId)
        {
            var entities = await _repository.GetByClassId(ClassId);
            var models = _mapper.Map<IEnumerable<NotificationViewModel>>(entities);
            return models;
        }

        /// <summary>
        /// Get Notification by Teacher id
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<NotificationViewModel>> GetByTeacherId(Guid TeacherId)
        {
            var entities = await _repository.GetByTeacherId(TeacherId);
            var models = _mapper.Map<IEnumerable<NotificationViewModel>>(entities);
            return models;
        }
    }
}
