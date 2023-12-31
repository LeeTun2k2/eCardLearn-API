﻿using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories.Implements
{
    /// <summary>
    /// Achievement Repository
    /// </summary>
    public class AchievementRepository : BaseRepository<Achievement>, IAchievementRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="unitOfWork"></param>
        public AchievementRepository(DataContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }

        /// <summary>
        /// Get by date requirement
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public async Task<Achievement?> GetByDay(int day)
        {
            return await Entities
                .Where(x => x.DayRequirement == day)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
