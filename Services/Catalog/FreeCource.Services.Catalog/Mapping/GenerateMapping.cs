using AutoMapper;
using FreeCource.Services.Catalog.Dtos;
using FreeCource.Services.Catalog.Models;

namespace FreeCource.Services.Catalog.Mapping
{
    public class GenerateMapping:Profile
    {
        public GenerateMapping()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
        }
    }
}
