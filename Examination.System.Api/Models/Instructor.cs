namespace Examination.System.Api.Models;

public class Instructor
{
    public Instructor()
    {
        InstructorCourses = new List<InstructorCourse>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<InstructorCourse> InstructorCourses { get; set; }
}

