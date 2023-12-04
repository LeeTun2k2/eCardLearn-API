using AutoMapper;
using API.Data.Entities;
using API.Data.DTOs.OpenTriviaDBCategory;

namespace API.Data
{
    /// <summary>
    /// OpenTriviaDBCategory maps
    /// </summary>
    public partial class Maps : Profile
    {
        /// <summary>
        /// Auto mapping for OpenTriviaDBCategory model
        /// </summary>
        protected void MapOpenTriviaDBCategory()
        {
            CreateMap<OpenTriviaDBCategory, OpenTriviaDBCategoryViewModel>().ReverseMap();
            CreateMap<OpenTriviaDBCategory, OpenTriviaDBCategoryAddModel>().ReverseMap();
            CreateMap<OpenTriviaDBCategory, OpenTriviaDBCategoryEditModel>().ReverseMap();
        }
    }
}
