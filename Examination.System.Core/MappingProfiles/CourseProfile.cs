using AutoMapper;
using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.ViewModels;

namespace Examination.System.Core.MappingProfiles;
public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseViewModel>();
        CreateMap<CourseCreateViewModel, Course>();
        CreateMap<CourseEditViewModel, Course>();
    }
}
