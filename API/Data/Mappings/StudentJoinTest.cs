using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.StudentJoinTest;

namespace API.Data
{
    /// <summary>
    /// StudentJoinTest maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for StudentJoinTest model
        /// </summary>
        protected void MapStudentJoinTest()
        {
            CreateMap<StudentJoinTest, StudentJoinTestViewModel>().ReverseMap();
            CreateMap<StudentJoinTest, StudentJoinTestAddModel>().ReverseMap();
            CreateMap<StudentJoinTest, StudentJoinTestEditModel>().ReverseMap();
        }
    }
}
