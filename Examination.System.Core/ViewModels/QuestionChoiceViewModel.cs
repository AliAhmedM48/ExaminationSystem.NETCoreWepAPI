using Examination.System.Core.Enums;

namespace Examination.System.Core.ViewModels;

public class QuestionChoiceViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public ChoiceViewModel? CorrectChoice { get; set; }
    public List<ChoiceViewModel> Choices { get; set; }
}


public class QuestionChoiceCreateViewModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public List<ChoiceCreateViewModel> Choices { get; set; }
}

public class QuestionChoiceEditViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public int CorrectChoiceId { get; set; }
    public List<ChoiceEditViewModel> Choices { get; set; }
}
