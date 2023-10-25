using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Question;

namespace API.Data
{
    /// <summary>
    /// Question maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Question model
        /// </summary>
        protected void MapQuestion()
        {
            CreateMap<Question, QuestionViewModel>().ReverseMap();
            CreateMap<Question, QuestionAddModel>().ReverseMap();
            CreateMap<Question, QuestionEditModel>().ReverseMap();
        }
    }
}
