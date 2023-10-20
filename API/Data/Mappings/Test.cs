using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.Test;

namespace API.Data
{
    /// <summary>
    /// Test maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for Test model
        /// </summary>
        protected void MapTest()
        {
            CreateMap<Test, TestViewModel>().ReverseMap();
            CreateMap<Test, TestAddModel>().ReverseMap();
            CreateMap<Test, TestEditModel>().ReverseMap();
        }
    }
}
