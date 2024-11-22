namespace Examination.System.Core.Models;

public class Course : BaseModel
{
    public string Name { get; set; }
    public int Hours { get; set; }


    public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
