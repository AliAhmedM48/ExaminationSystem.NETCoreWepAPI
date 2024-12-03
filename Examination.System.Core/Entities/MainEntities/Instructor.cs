using Examination.System.Core.Entities.JoinEntities;

namespace Examination.System.Core.Entities.MainEntities;

public class Instructor : User
{
    public decimal? Salary { get; set; }
    public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    public ICollection<InstructorStudentCourse> InstructorCourseStudents { get; set; } = new List<InstructorStudentCourse>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();

}