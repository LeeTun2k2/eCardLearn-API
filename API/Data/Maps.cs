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
            MapUser();
            MapTopic();
        }
    }
}
