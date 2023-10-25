using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.TestAnswer;

namespace API.Data
{
    /// <summary>
    /// TestAnswer maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for TestAnswer model
        /// </summary>
        protected void MapTestAnswer()
        {
            CreateMap<TestAnswer, TestAnswerViewModel>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerAddModel>().ReverseMap();
            CreateMap<TestAnswer, TestAnswerEditModel>().ReverseMap();
        }
    }
}
