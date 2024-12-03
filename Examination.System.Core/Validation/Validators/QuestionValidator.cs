using Examination.System.Core.ViewModels;
using FluentValidation;

namespace Examination.System.Core.Validation.Validators;
public class QuestionCreateViewModelValidator : AbstractValidator<QuestionChoiceCreateViewModel>
{
    public QuestionCreateViewModelValidator()
    {
        RuleFor(q => q.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(q => q.DifficultyLevel)
            .IsInEnum().WithMessage("Invalid difficulty level.");
    }
}


public class QuestionEditViewModelValidator : AbstractValidator<QuestionChoiceEditViewModel>
{
    public QuestionEditViewModelValidator()
    {
        RuleFor(q => q.Id)
            .GreaterThan(0).WithMessage("Id must be a positive integer.");

        RuleFor(q => q.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(q => q.DifficultyLevel)
            .IsInEnum().WithMessage("Invalid difficulty level.");

        RuleFor(q => q.CorrectChoiceId)
            .GreaterThan(0).WithMessage("CorrectChoiceId must be a positive integer.");
    }
}
