using Examination.System.Core.ViewModels;
using FluentValidation;

namespace Examination.System.Core.Validation.Validators;

public class ExamCreateViewModelValidator : AbstractValidator<ExamCreateViewModel>
{
    public ExamCreateViewModelValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(x => x.CourseId)
           .NotEmpty().WithMessage("CourseId is required.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.");

        RuleFor(x => x.ExamType)
            .NotEmpty().WithMessage("Exam Type is required.");

        RuleFor(x => x.DurationInMinutes)
            .NotEmpty().WithMessage("Duration in hours is required.")
            .GreaterThan(0).WithMessage("Duration must be greater than 0.")
            .LessThanOrEqualTo(3).WithMessage("Duration must be less than or equal to 3 hours.");

    }
}
public class ExamEditViewModelValidator : AbstractValidator<ExamEditViewModel>
{
    public ExamEditViewModelValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .When(c => !string.IsNullOrEmpty(c.Title));

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.")
            .When(c => c.Date != null);

        RuleFor(x => x.ExamType)
            .NotEmpty().WithMessage("Exam Type is required.")
            .When(c => !string.IsNullOrEmpty(c.ExamType.ToString()));

        RuleFor(x => x.DurationInMinutes)
            .NotEmpty().WithMessage("Duration in hours is required.")
            .GreaterThan(0).WithMessage("Duration must be greater than 0.")
            .LessThanOrEqualTo(3).WithMessage("Duration must be less than or equal to 3 hours.")
            .When(c => c.DurationInMinutes > 0);

    }
}