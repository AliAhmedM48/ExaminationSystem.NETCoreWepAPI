namespace Examination.System.Core.Interfaces.Services;
public interface IStudentCourseService
{
    Task Assign(int studentId, int courseId);
}
