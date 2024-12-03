using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class StudentCourse : BaseModel
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
