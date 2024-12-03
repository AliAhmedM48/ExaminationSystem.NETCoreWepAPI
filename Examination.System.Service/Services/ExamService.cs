using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Examination.System.Service.Services;

public class ExamService : IExamService
{
    private readonly IRepository<Exam> _repository;
    private readonly IValidator<ExamCreateViewModel> _validatorForCreation;
    private readonly IValidator<ExamEditViewModel> _validatorForEditing;
    private readonly ILogger<ExamService> _logger;

    public ExamService(IRepository<Exam> examRepository,
        IValidator<ExamCreateViewModel> validatorForCreation,
        IValidator<ExamEditViewModel> validatorForEditing,
        ILogger<ExamService> logger)
    {
        _repository = examRepository;
        _validatorForCreation = validatorForCreation;
        _validatorForEditing = validatorForEditing;
        _logger = logger;
    }
    public async Task<ResponseViewModel<ExamViewModel>> CreateAsync(ExamCreateViewModel examCreateViewModel)
    {
        if (examCreateViewModel == null)
        {
            _logger.LogError("Attempted to create an exam with null data.");
            throw new ArgumentNullException(nameof(examCreateViewModel), "The exam creation data cannot be null. Provide valid input.");
        }

        var validationResult = await _validatorForCreation.ValidateAsync(examCreateViewModel);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList();
            return new FailureResponseViewModel<ExamViewModel>(BusinessErrorCode.ValidationError, BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError), validationErrors);
        }

        var exam = examCreateViewModel.Map<Exam>();
        await _repository.AddAsync(exam);
        await _repository.SaveChangesAsync();

        var examViewModel = exam.Map<ExamViewModel>();
        return new SuccessResponseViewModel<ExamViewModel>(examViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ExamCreated));
    }

    public async Task<ResponseViewModel<ExamViewModel>> EditAsync(ExamEditViewModel examEditViewModel)
    {
        if (examEditViewModel == null)
        {
            _logger.LogError("Attempted to edit an exam with null data.");
            throw new ArgumentNullException(nameof(examEditViewModel), "The exam editing data cannot be null. Provide valid input.");
        }

        var validationResult = await _validatorForEditing.ValidateAsync(examEditViewModel);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList();
            return new FailureResponseViewModel<ExamViewModel>(BusinessErrorCode.ValidationError, BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError), validationErrors);
        }

        var exam = examEditViewModel.Map<Exam>();

        var existingExam = await _repository.GetByIdAsync(exam.Id);

        if (existingExam == null) return new FailureResponseViewModel<ExamViewModel>(BusinessErrorCode.ExamNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.ExamNotFound));

        exam.MapToExistingEntity(existingExam);

        _repository.SaveInclude(existingExam,
            ec => ec.Title,
            ec => ec.DurationInMinutes,
            ec => ec.Date,
            ec => ec.ExamType,
            e => e.NoOfQuestions,
            e => e.ScorePerQuestion,
            e => e.Description,
            e => e.DifficultyLevel,
            e => e.CourseId);


        await _repository.SaveChangesAsync();

        var examViewModel = exam.Map<ExamViewModel>();
        return new SuccessResponseViewModel<ExamViewModel>(examViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ExamUpdated));
    }

    public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
    {
        var exam = await _repository.GetByIdAsync(id);
        if (exam == null) return new FailureResponseViewModel<bool>(BusinessErrorCode.ExamNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.ExamNotFound));

        _repository.Delete(exam);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<bool>(true, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.ExamDeleted));
    }


    public async Task<ResponseViewModel<ExamViewModel>> GetByIdAsync(int id)
    {
        var exam = await _repository.GetByIdAsync(id);

        if (exam == null) return new FailureResponseViewModel<ExamViewModel>(BusinessErrorCode.ExamNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.ExamNotFound));
        var examViewModel = exam.Map<ExamViewModel>();
        return new SuccessResponseViewModel<ExamViewModel>(examViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public ResponseViewModel<IEnumerable<ExamViewModel>> GetAll()
    {
        var exams = _repository.GetAll();
        var examViewModels = exams.ProjectTo<ExamViewModel>().AsEnumerable();
        return new SuccessResponseViewModel<IEnumerable<ExamViewModel>>(examViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }
}



