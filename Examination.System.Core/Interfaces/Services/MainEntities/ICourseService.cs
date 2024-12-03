using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;

namespace Examination.System.Core.Interfaces.Services.MainEntities;

public interface ICourseService
{
    Task<ResponseViewModel<CourseViewModel>> CreateAsync(CourseCreateViewModel courseCreateViewModel);
    Task<ResponseViewModel<CourseViewModel>> EditAsync(CourseEditViewModel courseEditViewModel);
    Task<ResponseViewModel<bool>> DeleteAsync(int id);
    Task<ResponseViewModel<CourseViewModel>> GetByIdAsync(int id);
    ResponseViewModel<IEnumerable<CourseViewModel>> GetAll();
}
