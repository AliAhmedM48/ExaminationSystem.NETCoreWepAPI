using Examination.System.Core.Entities.JoinEntities;
using Examination.System.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examination.System.Core.Entities.MainEntities;

public class Question : BaseModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }

    public int? CorrectChoiceId { get; set; }
    public Choice CorrectChoice { get; set; }

    public ICollection<Choice> Choices { get; set; } = new List<Choice>();

    [NotMapped]
    public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
}
