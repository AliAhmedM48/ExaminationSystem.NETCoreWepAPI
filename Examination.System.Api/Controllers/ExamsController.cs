using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
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

    [HttpGet]
    public async Task<ActionResult<ResponseViewModel<List<ExamViewModel>>>> GetAllExams()
    {
        var responseViewModel = _examService.GetAll();
        return Ok(responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseViewModel<ExamViewModel>>> GetById(int id)
    {
        var responseViewModel = await _examService.GetByIdAsync(id);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseViewModel<ExamViewModel>>> CreateExam(ExamCreateViewModel model)
    {
        var responseViewModel = await _examService.CreateAsync(model);

        if (!responseViewModel.IsSuccess)
        {
            return BadRequest(responseViewModel);
        };


        return CreatedAtAction(nameof(GetById), new { id = responseViewModel.Data.Id }, responseViewModel);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseViewModel<ExamViewModel>>> UpdateExam(ExamEditViewModel model)
    {
        var responseViewModel = await _examService.EditAsync(model);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseViewModel<bool>>> DeleteExam(int id)
    {
        var responseViewModel = await _examService.DeleteAsync(id);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }
}
