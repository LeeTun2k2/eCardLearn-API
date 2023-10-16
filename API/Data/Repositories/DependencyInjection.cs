using API.Data.Repositories.Interfaces;
using API.Data.Repositories.Implements;

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
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IAchievementRepository, AchievementRepository>();
            service.AddTransient<IAdminRepository, AdminRepository>();
            service.AddTransient<IAnswerRepository, AnswerRepository>();
            service.AddTransient<IClassRepository, ClassRepository>();
            service.AddTransient<ICourseRepository, CourseRepository>();
            service.AddTransient<IFeedbackRepository, FeedbackRepository>();
            service.AddTransient<INotificationRepository, NotificationRepository>();
            service.AddTransient<IQuestionRepository, QuestionRepository>();
            service.AddTransient<IStudentRepository, StudentRepository>();
            service.AddTransient<IStudentJoinClassRepository, StudentJoinClassRepository>();
            service.AddTransient<IStudentJoinTestRepository, StudentJoinTestRepository>();
            service.AddTransient<ITeacherRepository, TeacherRepository>();
            service.AddTransient<ITestRepository, TestRepository>();
            service.AddTransient<ITestAnswerRepository, TestAnswerRepository>();
            service.AddTransient<ITopicRepository, TopicRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            return service;
        }
    }

}
