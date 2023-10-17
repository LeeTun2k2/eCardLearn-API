using API.Data.Repositories.Interfaces;
using API.Data.Repositories.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data.Repositories
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAchievementRepository, AchievementRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentJoinClassRepository, StudentJoinClassRepository>();
            services.AddTransient<IStudentJoinTestRepository, StudentJoinTestRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestAnswerRepository, TestAnswerRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
