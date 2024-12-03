using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace Examination.System.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionViewModel>>> GetAllQuestion()
    {
        var responseViewModel = _questionService.GetAllQuestion();

        return Ok(responseViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionChoiceViewModel>> CreateQuestionWithRelatedChoices(QuestionChoiceCreateViewModel questionChoiceCreateViewModel)
    {
        var responseViewModel = await _questionService.CreateQuestionWithRelatedChoicesAsync(questionChoiceCreateViewModel);

        if (!responseViewModel.IsSuccess) BadRequest(responseViewModel);

        return CreatedAtAction(nameof(GetByIdQuestionWithRelatedChoices), new { id = responseViewModel.Data.Id }, responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseViewModel<QuestionChoiceViewModel>>> GetByIdQuestionWithRelatedChoices(int id)
    {
        var responseViewModel = await _questionService.GetByIdQuestionWithRelatedChoicesAsync(id);

        if (!responseViewModel.IsSuccess)
        {
            return responseViewModel.BusinessErrorCode == BusinessErrorCode.QuestionNotFound
            ? NotFound(responseViewModel)
            : BadRequest(responseViewModel);
        }

        return Ok(responseViewModel);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseViewModel<QuestionChoiceViewModel>>> UpdateQuestionWithRelatedChoices(QuestionChoiceEditViewModel questionChoiceEditViewModel)
    {
        var responseViewModel = await _questionService.EditQuestionWithRelatedChoicesAsync(questionChoiceEditViewModel);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseViewModel<bool>>> DeleteQuestionWithRelatedChoices(int id)
    {
        var responseViewModel = await _questionService.DeleteQuestionWithRelatedChoicesAsync(id);

        if (!responseViewModel.IsSuccess)
        {
            return responseViewModel.BusinessErrorCode == BusinessErrorCode.QuestionNotFound
           ? NotFound(responseViewModel)
           : BadRequest(responseViewModel);
        }

        return Ok(responseViewModel);
    }

    [HttpPatch("{questionId}/correct-choice/{choiceId}")]
    public async Task<ActionResult<ResponseViewModel<bool>>> UpdateQuestionCorrectChoice(int questionId, int choiceId)
    {

        var responseViewModel = await _questionService.SetCorrectChoiceAsync(questionId, choiceId);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }
}
