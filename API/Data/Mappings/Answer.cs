using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Answer;

namespace API.Data
{
    /// <summary>
    /// Answer maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Answer model
        /// </summary>
        protected void MapAnswer()
        {
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
            CreateMap<Answer, AnswerAddModel>().ReverseMap();
            CreateMap<Answer, AnswerEditModel>().ReverseMap();
        }
    }
}
