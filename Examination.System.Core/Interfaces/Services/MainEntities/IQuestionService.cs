using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;

namespace Examination.System.Core.Interfaces.Services.MainEntities;

public interface IQuestionService
{
    Task<ResponseViewModel<QuestionChoiceViewModel>> CreateQuestionWithRelatedChoicesAsync(QuestionChoiceCreateViewModel questionChoiceCreateViewModel);
    Task<ResponseViewModel<bool>> DeleteQuestionWithRelatedChoicesAsync(int id);
    Task<ResponseViewModel<QuestionChoiceViewModel>> EditQuestionWithRelatedChoicesAsync(QuestionChoiceEditViewModel questionChoiceEditViewModel);
    Task<ResponseViewModel<QuestionChoiceViewModel>> GetByIdQuestionWithRelatedChoicesAsync(int id);
    ResponseViewModel<IEnumerable<QuestionChoiceViewModel>> GetAllQuestionWithRelatedChoices();
    ResponseViewModel<IEnumerable<QuestionViewModel>> GetAllQuestion();
    Task<ResponseViewModel<QuestionChoiceViewModel>> SetCorrectChoiceAsync(int questionId, int choiceId);
}
