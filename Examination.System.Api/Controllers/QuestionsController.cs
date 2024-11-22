using Examination.System.Core.Interfaces.Services;
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
    public async Task<IActionResult> GetQuestionsPool()
    {
        var questions = _questionService.GetQuestionsPool();
        return Ok(questions);
    }
}
