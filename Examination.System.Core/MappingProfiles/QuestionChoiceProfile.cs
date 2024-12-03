using AutoMapper;
using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.ViewModels;

namespace Examination.System.Core.MappingProfiles;

public class QuestionChoiceProfile : Profile
{
    public QuestionChoiceProfile()
    {
        CreateMap<Question, QuestionChoiceViewModel>()
        .ForMember(e => e.CorrectChoice, e => e.MapFrom(o => new ChoiceViewModel() { Id = o.CorrectChoice.Id, Text = o.CorrectChoice.Text }))
        .ForMember(e => e.Choices, e => e.MapFrom(o => o.Choices.Select(c => new ChoiceViewModel() { Id = c.Id, Text = c.Text })))
        .ReverseMap()
        .ForMember(q => q.CorrectChoiceId, opt => opt.MapFrom(q => q.CorrectChoice.Id))
        .ForMember(q => q.CorrectChoice, opt => opt.Ignore())
        .ForMember(q => q.Choices, opt => opt.MapFrom(c => c.Choices.Select(c => new Choice() { Id = c.Id, Text = c.Text })));

        CreateMap<QuestionChoiceCreateViewModel, Question>()
        .ForMember(dest => dest.Choices, opt => opt.Ignore());
        //.ForMember(q => q.Choices, e => e.MapFrom(q => q.Choices));

        CreateMap<QuestionChoiceEditViewModel, Question>()
        .ForMember(dest => dest.Choices, opt => opt.Ignore());
    }
}

