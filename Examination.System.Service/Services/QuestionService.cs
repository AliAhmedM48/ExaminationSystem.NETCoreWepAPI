using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.Validation;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Examination.System.Service.Services;
public class QuestionService : IQuestionService
{
    private readonly IRepository<Question> _repository;
    private readonly IChoiceService _choiceService;
    private readonly IValidator<QuestionChoiceCreateViewModel> _validatorForCreation;
    private readonly IValidator<QuestionChoiceEditViewModel> _validatorForEditing;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(IRepository<Question> repository,
        IChoiceService choiceService,
        IValidator<QuestionChoiceCreateViewModel> validatorForCreation,
        IValidator<QuestionChoiceEditViewModel> validatorForEditing,
        ILogger<QuestionService> logger)
    {
        _repository = repository;
        _choiceService = choiceService;
        _validatorForCreation = validatorForCreation;
        _validatorForEditing = validatorForEditing;
        _logger = logger;
    }

    public async Task<ResponseViewModel<QuestionChoiceViewModel>> CreateQuestionWithRelatedChoicesAsync(QuestionChoiceCreateViewModel questionChoiceCreateViewModel)
    {
        ValidationHelper.ValidateArgumentsNullOrEmpty(questionChoiceCreateViewModel);

        var validationErrors = await ValidationHelper.ValidateViewModelAsync(_validatorForCreation, questionChoiceCreateViewModel);
        if (validationErrors != null)
            return new FailureResponseViewModel<QuestionChoiceViewModel>(
                BusinessErrorCode.ValidationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError), validationErrors);

        var question = questionChoiceCreateViewModel.Map<Question>();
        await _repository.AddAsync(question);
        await _repository.SaveChangesAsync();

        var responseViewModel = await _choiceService.CreateRangeForQuestionIdAsync(questionChoiceCreateViewModel.Choices, question.Id);

        if (!responseViewModel.IsSuccess)
        {
            _logger.LogError("Failed to create choices for the question.");
            return new FailureResponseViewModel<QuestionChoiceViewModel>(
                BusinessErrorCode.ChoiceCreationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceCreationError),
                responseViewModel.ValidationErrors.ToList());
        }

        var questionChoiceViewModel = question.Map<QuestionChoiceViewModel>();
        return new SuccessResponseViewModel<QuestionChoiceViewModel>(questionChoiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.QuestionChoiceCreated));

    }

    public async Task<ResponseViewModel<QuestionChoiceViewModel>> EditQuestionWithRelatedChoicesAsync(QuestionChoiceEditViewModel questionChoiceEditViewModel)
    {
        ValidationHelper.ValidateArgumentsNullOrEmpty(questionChoiceEditViewModel);

        var validationErrors = await ValidationHelper.ValidateViewModelAsync(_validatorForEditing, questionChoiceEditViewModel);
        if (validationErrors != null)
            return new FailureResponseViewModel<QuestionChoiceViewModel>(
                BusinessErrorCode.ValidationError,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.ValidationError), validationErrors);


        var question = questionChoiceEditViewModel.Map<Question>();

        _repository.SaveInclude(question, ec => ec.Title, ec => ec.Description, q => q.DifficultyLevel, q => q.CorrectChoiceId);
        await _repository.SaveChangesAsync();

        var responseViewModel = await _choiceService.EditRangeAsync(questionChoiceEditViewModel.Choices);

        if (!responseViewModel.IsSuccess)
        {
            _logger.LogError("Failed to edit choices for the question.");
            return new FailureResponseViewModel<QuestionChoiceViewModel>(BusinessErrorCode.ChoiceUpdatingError, BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceUpdatingError), responseViewModel.ValidationErrors.ToList());
        }

        var questionChoiceViewModel = question.Map<QuestionChoiceViewModel>();
        return new SuccessResponseViewModel<QuestionChoiceViewModel>(questionChoiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.QuestionChoiceUpdated));
    }


    public async Task<ResponseViewModel<bool>> DeleteQuestionWithRelatedChoicesAsync(int id)
    {
        var question = await _repository.GetByIdAsync(id);

        if (question == null) return new FailureResponseViewModel<bool>(BusinessErrorCode.QuestionNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.QuestionNotFound));

        _repository.Delete(question);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<bool>(true, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.QuestionChoiceDeleted));
    }


    public ResponseViewModel<IEnumerable<QuestionViewModel>> GetAllQuestion()
    {
        var questions = _repository.GetAll();
        var questionViewModels = questions.ProjectTo<QuestionViewModel>().AsEnumerable();
        return new SuccessResponseViewModel<IEnumerable<QuestionViewModel>>(questionViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public ResponseViewModel<IEnumerable<QuestionChoiceViewModel>> GetAllQuestionWithRelatedChoices()
    {
        var questions = _repository.GetAll();
        var questionChoiceViewModels = questions.ProjectTo<QuestionChoiceViewModel>().AsEnumerable();
        return new SuccessResponseViewModel<IEnumerable<QuestionChoiceViewModel>>(questionChoiceViewModels, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public async Task<ResponseViewModel<QuestionChoiceViewModel>> GetByIdQuestionWithRelatedChoicesAsync(int id)
    {
        var questionChoiceViewModel = await _repository.GetAll(c => c.Id == id).ProjectToForFirstOrDefaultAsync<QuestionChoiceViewModel>();

        if (questionChoiceViewModel == null) return new FailureResponseViewModel<QuestionChoiceViewModel>(BusinessErrorCode.QuestionNotFound, BusinessErrorMessage.GetMessage(BusinessErrorCode.QuestionNotFound));

        return new SuccessResponseViewModel<QuestionChoiceViewModel>(questionChoiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.OperationCompleted));
    }

    public async Task<ResponseViewModel<QuestionChoiceViewModel>> SetCorrectChoiceAsync(int questionId, int choiceId)
    {
        var questions = _repository.GetAll(q => q.Id == questionId);
        var questionChoiceViewModel = await questions.ProjectToForFirstOrDefaultAsync<QuestionChoiceViewModel>();
        if (questionChoiceViewModel is null)
        {
            return new FailureResponseViewModel<QuestionChoiceViewModel>(
                BusinessErrorCode.QuestionNotFound,
                BusinessErrorMessage.GetMessage(BusinessErrorCode.QuestionNotFound));
        }


        var responseChoiceViewModel = await _choiceService.GetByIdAsync(choiceId);
        if (!responseChoiceViewModel.IsSuccess)
        {
            return new FailureResponseViewModel<QuestionChoiceViewModel>(
               BusinessErrorCode.ChoiceNotFound,
               BusinessErrorMessage.GetMessage(BusinessErrorCode.ChoiceNotFound));
        }

        questionChoiceViewModel.CorrectChoice = responseChoiceViewModel.Data;

        var question = questionChoiceViewModel.Map<Question>();

        _repository.SaveInclude(question, q => q.CorrectChoiceId);
        await _repository.SaveChangesAsync();

        return new SuccessResponseViewModel<QuestionChoiceViewModel>(questionChoiceViewModel, BusinessSuccessMessage.GetMessage(BusinessSuccessCode.QuestionCorrectChoiceUpdated));
    }
}
