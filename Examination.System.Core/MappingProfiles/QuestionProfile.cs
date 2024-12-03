using AutoMapper;
using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.ViewModels;

namespace Examination.System.Core.MappingProfiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, QuestionViewModel>()
          .ForMember(e => e.CorrectChoice, e => e.MapFrom(o => new ChoiceViewModel() { Id = o.CorrectChoice.Id, Text = o.CorrectChoice.Text }));

    }
}

