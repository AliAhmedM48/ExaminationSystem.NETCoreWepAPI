using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.Models;
using Examination.System.Core.ViewModels;

namespace Examination.System.Service;

public class CourseService : ICourseService
{
    private readonly IRepository<Course> _repository;
    private readonly IStudentCourseService _studentCourseService;

    public CourseService(IRepository<Course> repository, IStudentCourseService studentCourseService)
    {
        _repository = repository;
        _studentCourseService = studentCourseService;
    }
    public async Task AddAsync(CourseCreateViewModel courseCreateViewModel)
    {
        var course = courseCreateViewModel.Map<Course>();
        await _repository.AddAsync(course);
        await _repository.SaveChangesAsync();
    }

    public async Task Assign(int studentId, int courseId)
    {
        var course = _repository.GetById(courseId);
        if (course is null) return;
        await _studentCourseService.Assign(studentId, courseId);
    }

    public async Task Delete(int id)
    {
        var course = _repository.GetById(id);

        if (course is null) return;

        _repository.Delete(course);
        await _repository.SaveChangesAsync();
    }

    public IEnumerable<CourseViewModel> GetAll()
    {
        var courses = _repository.GetAll().ProjectTo<CourseViewModel>();
        return courses.ToList();
    }


    public CourseViewModel GetById(int id)
    {
        var course = _repository.GetAll().ProjectTo<CourseViewModel>().FirstOrDefault(c => c.Id == id);
        return course;
    }

    public async Task Update(CourseEditViewModel courseEditViewModel)
    {
        var course = courseEditViewModel.Map<Course>();

        if (course is null) return;

        _repository.SaveInclude(course, c => c.Name, c => c.Hours);
        await _repository.SaveChangesAsync();
    }
}
