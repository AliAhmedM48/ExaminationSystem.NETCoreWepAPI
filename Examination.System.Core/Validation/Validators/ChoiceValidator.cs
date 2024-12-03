using Examination.System.Core.ViewModels;
using FluentValidation;

namespace Examination.System.Core.Validation.Validators;
public class ChoiceCreateViewModelValidator : AbstractValidator<ChoiceCreateViewModel>
{
    public ChoiceCreateViewModelValidator()
    {
        RuleFor(c => c.Text)
            .NotEmpty().WithMessage("Text is required.")
            .MaximumLength(250).WithMessage("Text must not exceed 250 characters.");

    }
}

public class ChoiceEditViewModelValidator : AbstractValidator<ChoiceEditViewModel>
{
    public ChoiceEditViewModelValidator()
    {
        RuleFor(c => c.Text)
            .NotEmpty().WithMessage("Text is required.")
            .MaximumLength(250).WithMessage("Text must not exceed 250 characters.");

    }
}