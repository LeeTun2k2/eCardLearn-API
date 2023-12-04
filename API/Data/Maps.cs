using AutoMapper;

namespace API.Data
{
    /// <summary>
    /// Config mapping type
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Maps()
        {
            MapAchievement();
            MapAnswer();
            MapAuthentication();
            MapClass();
            MapCourseInClass();
            MapCourse();
            MapFeedback();
            MapNotification();
            MapOpenTriviaDBCategory();
            MapQuestion();
            MapStudentJoinClass();
            MapStudentJoinTest();
            MapTest();
            MapTestAnswer();
            MapTopic();
            MapUser();
            MapUserEarnedAchievement();
            MapUserLoginHistory();
        }
    }
}
