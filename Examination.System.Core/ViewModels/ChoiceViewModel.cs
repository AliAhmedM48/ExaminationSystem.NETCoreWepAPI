namespace Examination.System.Core.ViewModels;

public class ChoiceViewModel
{
    public int Id { get; set; }
    public string Text { get; set; }
}

public class ChoiceCreateViewModel
{
    public string Text { get; set; }
    public int? QuestionId { get; set; }

}

public class ChoiceEditViewModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int QuestionId { get; set; }
}