using API.Data.Repositories.Interfaces;
using API.Data.Repositories.Implements;
using API.Data.Entities;

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
            // Unit of work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // User
            services.AddTransient<IBaseRepository<User>, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Admin
            services.AddTransient<IBaseRepository<Admin>, AdminRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();

            // Achievement
            services.AddTransient<IBaseRepository<Achievement>, AchievementRepository>();
            services.AddTransient<IAchievementRepository, AchievementRepository>();

            // Answer
            services.AddTransient<IBaseRepository<Answer>, AnswerRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();

            // Class
            services.AddTransient<IBaseRepository<Class>, ClassRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();

            // CourseInClass
            services.AddTransient<IBaseRepository<CourseInClass>, CourseInClassRepository>();
            services.AddTransient<ICourseInClassRepository, CourseInClassRepository>();

            // Course
            services.AddTransient<IBaseRepository<Course>, CourseRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();

            // Feedback
            services.AddTransient<IBaseRepository<Feedback>, FeedbackRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();

            // Notification
            services.AddTransient<IBaseRepository<Notification>, NotificationRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();

            // Question
            services.AddTransient<IBaseRepository<Question>, QuestionRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();

            // Student
            services.AddTransient<IBaseRepository<Student>, StudentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            // Student join class
            services.AddTransient<IBaseRepository<StudentJoinClass>, StudentJoinClassRepository>();
            services.AddTransient<IStudentJoinClassRepository, StudentJoinClassRepository>();

            // Student join test
            services.AddTransient<IBaseRepository<StudentJoinTest>, StudentJoinTestRepository>();
            services.AddTransient<IStudentJoinTestRepository, StudentJoinTestRepository>();

            // Teacher
            services.AddTransient<IBaseRepository<Teacher>, TeacherRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();

            // Test
            services.AddTransient<IBaseRepository<Test>, TestRepository>();
            services.AddTransient<ITestRepository, TestRepository>();

            // Test answer
            services.AddTransient<IBaseRepository<TestAnswer>, TestAnswerRepository>();
            services.AddTransient<ITestAnswerRepository, TestAnswerRepository>();

            // Topic
            services.AddTransient<IBaseRepository<Topic>, TopicRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();

            // User
            services.AddTransient<IBaseRepository<User>, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // UserEarnedAchievement
            services.AddTransient<IBaseRepository<UserEarnedAchievement>, UserEarnedAchievementRepository>();
            services.AddTransient<IUserEarnedAchievementRepository, UserEarnedAchievementRepository>();

            return services;
        }
    }
}
