using API.Services.Implements;
using API.Services.Interfaces;

namespace API.Services
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add services
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IAchievementService, AchievementService>();
            service.AddTransient<IAnswerService, AnswerService>();
            service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddTransient<IClassService, ClassService>();
            service.AddTransient<ICourseService, CourseService>();
            service.AddTransient<IFeedbackService, FeedbackService>();
            service.AddTransient<INotificationService, NotificationService>();
            service.AddTransient<IQuestionService, QuestionService>();
            service.AddTransient<IStudentJoinClassService, StudentJoinClassService>();
            service.AddTransient<IStudentJoinTestService, StudentJoinTestService>();
            service.AddTransient<ITestAnswerService, TestAnswerService>();
            service.AddTransient<ITestService, TestService>();
            service.AddTransient<ITopicService, TopicService>();
            service.AddTransient<IUserEarnedAchievementService, UserEarnedAchievementService>();
            return service;
        }
    }

}
