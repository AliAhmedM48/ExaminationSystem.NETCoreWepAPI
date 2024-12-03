using AutoMapper;
using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.ViewModels;

namespace Examination.System.Core.MappingProfiles;

public class ChoiceProfile : Profile
{
    public ChoiceProfile()
    {
        CreateMap<Choice, ChoiceViewModel>();
        CreateMap<ChoiceCreateViewModel, Choice>();
        CreateMap<ChoiceEditViewModel, Choice>().ReverseMap();
    }
}

