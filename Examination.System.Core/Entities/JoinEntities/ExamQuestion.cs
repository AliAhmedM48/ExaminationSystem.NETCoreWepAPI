using Examination.System.Core.Entities.MainEntities;

namespace Examination.System.Core.Entities.JoinEntities;

public class ExamQuestion : BaseModel
{
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public ICollection<StudentExamQuestionChoice> StudentExamQuestionChoices { get; set; } = new List<StudentExamQuestionChoice>();

}
