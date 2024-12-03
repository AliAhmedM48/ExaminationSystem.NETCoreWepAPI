using Examination.System.Core.Entities.JoinEntities;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;

namespace Examination.System.Service;
public class StudentCourseService : IStudentCourseService
{
    private readonly IRepository<StudentCourse> _repository;

    public StudentCourseService(IRepository<StudentCourse> repository)
    {
        _repository = repository;
    }
    public async Task Assign(int studentId, int courseId)
    {
        var studentCourse = new StudentCourse { StudentId = studentId, CourseId = courseId };
        await _repository.AddAsync(studentCourse);
        await _repository.SaveChangesAsync();
    }
}
