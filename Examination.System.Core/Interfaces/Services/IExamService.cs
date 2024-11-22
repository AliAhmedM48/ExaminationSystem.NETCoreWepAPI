using Examination.System.Core.ViewModels.Exams;

namespace Examination.System.Core.Interfaces.Services;

public interface IExamService
{
    Task<int> AddAsync(ExamCreateViewModel examCreateViewModel);
    Task<int> AddRandomAsync(ExamCreateViewModel examCreateViewModel);
    // ExamViewModel GetById(int Id);
}
