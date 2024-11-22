using Examination.System.Core.ViewModels;

namespace Examination.System.Core.Interfaces.Services;
public interface ICourseService
{

    CourseViewModel GetById(int id);
    IEnumerable<CourseViewModel> GetAll();
    Task AddAsync(CourseCreateViewModel courseCreateViewModel);
    Task Update(CourseEditViewModel courseEditViewModel);
    Task Delete(int id);
    Task Assign(int studentId, int courseId);
}