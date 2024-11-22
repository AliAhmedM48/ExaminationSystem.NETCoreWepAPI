using AutoMapper;
using Examination.System.Core.Models;
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
