using Examination.System.Core.ViewModels.ExamQuestions;

namespace Examination.System.Core.Interfaces.Services;

public interface IExamQuestionsService
{
    Task AddAsync(ExamQuestionsCreateViewModel examQuestionsViewModel);
    Task AddRangeAsync(IEnumerable<ExamQuestionsCreateViewModel> examQuestionsCreateViewModels);
}

