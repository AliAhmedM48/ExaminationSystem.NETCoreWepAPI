using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class StudentExam : BaseModel
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int ExamId { get; set; }
    public Exam Exam { get; set; }
}
