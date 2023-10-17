using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Topic;

namespace API.Data
{
    /// <summary>
    /// Topic maps
    /// </summary>
    public partial class Maps : Profile
    {
        protected void MapTopic()
        {
            CreateMap<Topic, TopicViewModel>().ReverseMap();
            CreateMap<Topic, TopicAddModel>().ReverseMap();
            CreateMap<Topic, TopicEditModel>().ReverseMap();
        }
    }
}
