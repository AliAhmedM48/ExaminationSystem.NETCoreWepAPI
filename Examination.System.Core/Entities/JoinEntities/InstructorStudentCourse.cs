using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class InstructorStudentCourse : BaseModel
{
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public DateTime AssignDate { get; set; }
}