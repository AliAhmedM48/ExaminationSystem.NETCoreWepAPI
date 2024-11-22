namespace Examination.System.Core.Models;

public class Student : User
{
    public int? Level { get; set; }
    public int? Age { get; set; }
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    public ICollection<StudentExam> StudentExams { get; set; } = new List<StudentExam>();
}
