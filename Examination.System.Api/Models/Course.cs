namespace Examination.System.Api.Models;

public class Course
{
    public Course()
    {
        InstructorCourses = new List<InstructorCourse>();

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Hours { get; set; }
    public ICollection<InstructorCourse> InstructorCourses { get; set; }
}

