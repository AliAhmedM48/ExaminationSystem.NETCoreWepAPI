using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class StudentExamQuestionChoice : BaseModel
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int ExamQuestionId { get; set; }
    public ExamQuestion ExamQuestion { get; set; }

    public int StudentChoiceId { get; set; }
    public Choice StudentChoice { get; set; }
}
