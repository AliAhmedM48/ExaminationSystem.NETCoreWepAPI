namespace Examination.System.Api.Models;

public class InstructorCourse
{
    public int Id { get; set; }

    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}

