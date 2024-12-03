using Examination.System.Core.Enums;

namespace Examination.System.Core.ViewModels;

public class QuestionViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public ChoiceViewModel? CorrectChoice { get; set; }
}


