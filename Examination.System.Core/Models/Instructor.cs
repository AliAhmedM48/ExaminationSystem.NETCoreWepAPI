namespace Examination.System.Core.Models;

public class Instructor : User
{
    public decimal? Salary { get; set; }
    public ICollection<InstructorCourse> InstructorCourses { get; set; } = new List<InstructorCourse>();
}