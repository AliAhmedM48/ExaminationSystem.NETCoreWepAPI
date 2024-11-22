using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.ViewModels.Exams;
using Microsoft.AspNetCore.Mvc;

namespace Examination.System.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExamsController : ControllerBase
{
    private readonly IExamService _examService;

    public ExamsController(IExamService examService)
    {
        _examService = examService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExamCreateViewModel examCreateViewModel)
    {
        await _examService.AddAsync(examCreateViewModel);
        return Ok();
    }
}
