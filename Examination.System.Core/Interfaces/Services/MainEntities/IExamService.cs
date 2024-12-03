using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;

namespace Examination.System.Core.Interfaces.Services.MainEntities;

public interface IExamService
{
    Task<ResponseViewModel<ExamViewModel>> CreateAsync(ExamCreateViewModel examCreateViewModel);
    Task<ResponseViewModel<ExamViewModel>> EditAsync(ExamEditViewModel examEditViewModel);
    Task<ResponseViewModel<bool>> DeleteAsync(int id);
    Task<ResponseViewModel<ExamViewModel>> GetByIdAsync(int id);
    ResponseViewModel<IEnumerable<ExamViewModel>> GetAll();
}
