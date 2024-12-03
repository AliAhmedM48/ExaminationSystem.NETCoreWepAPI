using Examination.System.Core.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.System.Core.Entities.MainEntities;

public class Choice : BaseModel
{
    public string Text { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }

    [NotMapped]
    public ICollection<StudentExamQuestionChoice> StudentExamQuestionChoices { get; set; } = new List<StudentExamQuestionChoice>();
}