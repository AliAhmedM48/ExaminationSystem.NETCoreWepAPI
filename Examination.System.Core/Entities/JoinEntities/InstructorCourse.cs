using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class InstructorCourse : BaseModel
{
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
