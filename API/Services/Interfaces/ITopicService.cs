using API.Data.DTOs.Topic;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Topic Service Interface
    /// </summary>
    public interface ITopicService : IBaseService<Topic, TopicViewModel, TopicAddModel, TopicEditModel, TopicFilterModel>
    {

    }
}
