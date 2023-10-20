using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Class;

namespace API.Data
{
    /// <summary>
    /// Class maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Class model
        /// </summary>
        protected void MapClass()
        {
            CreateMap<Class, ClassViewModel>().ReverseMap();
            CreateMap<Class, ClassAddModel>().ReverseMap();
            CreateMap<Class, ClassEditModel>().ReverseMap();
        }
    }
}
