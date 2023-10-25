using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Feedback;

namespace API.Data
{
    /// <summary>
    /// Feedback maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Feedback model
        /// </summary>
        protected void MapFeedback()
        {
            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
            CreateMap<Feedback, FeedbackAddModel>().ReverseMap();
            CreateMap<Feedback, FeedbackEditModel>().ReverseMap();
        }
    }
}
