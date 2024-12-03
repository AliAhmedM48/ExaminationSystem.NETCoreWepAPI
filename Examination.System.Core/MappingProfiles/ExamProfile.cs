using AutoMapper;
using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.ViewModels;

namespace Examination.System.Core.MappingProfiles;
public class ExamProfile : Profile
{
    public ExamProfile()
    {
        CreateMap<Exam, ExamViewModel>()
            .ForMember(e => e.CourseTitle, e => e.MapFrom(o => o.Course.Name));
        CreateMap<ExamCreateViewModel, Exam>();
        CreateMap<ExamEditViewModel, Exam>();
    }
}

