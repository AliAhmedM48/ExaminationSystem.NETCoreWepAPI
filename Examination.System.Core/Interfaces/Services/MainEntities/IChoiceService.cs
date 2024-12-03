using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;

namespace Examination.System.Core.Interfaces.Services.MainEntities;

public interface IChoiceService
{
    Task<ResponseViewModel<ChoiceViewModel>> CreateAsync(ChoiceCreateViewModel choiceCreateViewModel);
    Task<ResponseViewModel<IEnumerable<ChoiceViewModel>>> CreateRangeForQuestionIdAsync(IEnumerable<ChoiceCreateViewModel> choiceCreateViewModels, int questionId);
    Task<ResponseViewModel<IEnumerable<ChoiceViewModel>>> EditRangeAsync(IEnumerable<ChoiceEditViewModel> choiceEditViewModels);
    Task<ResponseViewModel<bool>> DeleteAsync(int id);
    Task<ResponseViewModel<bool>> DeleteChoicesByQuestionIdAsync(int questionId);
    Task<ResponseViewModel<ChoiceViewModel>> GetByIdAsync(int id);
    ResponseViewModel<IEnumerable<ChoiceViewModel>> GetAll();
    ResponseViewModel<IEnumerable<ChoiceViewModel>> GetAllByQuestionId(int questionId);
}