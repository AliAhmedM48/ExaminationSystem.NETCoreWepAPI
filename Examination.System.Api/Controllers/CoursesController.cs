using Examination.System.Core.Enums.Response;
using Examination.System.Core.Interfaces.Services.MainEntities;
using Examination.System.Core.ViewModels;
using Examination.System.Core.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace Examination.System.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }


    [HttpGet]
    public async Task<ActionResult<ResponseViewModel<List<CourseViewModel>>>> GetAllCourse()
    {
        var responseViewModel = _courseService.GetAll();
        return Ok(responseViewModel);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseViewModel<CourseViewModel>>> GetById(int id)
    {
        var responseViewModel = await _courseService.GetByIdAsync(id);

        if (!responseViewModel.IsSuccess)
        {
            return responseViewModel.BusinessErrorCode == BusinessErrorCode.CourseNotFound
            ? NotFound(responseViewModel)
            : BadRequest(responseViewModel);
        }

        return Ok(responseViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseViewModel<CourseViewModel>>> CreateCourse(CourseCreateViewModel model)
    {
        var responseViewModel = await _courseService.CreateAsync(model);

        if (!responseViewModel.IsSuccess) BadRequest(responseViewModel);

        return CreatedAtAction(nameof(GetById), new { id = responseViewModel.Data.Id }, responseViewModel);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseViewModel<CourseViewModel>>> UpdateCourse(CourseEditViewModel model)
    {
        var responseViewModel = await _courseService.EditAsync(model);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseViewModel<bool>>> DeleteCourse(int id)
    {
        var responseViewModel = await _courseService.DeleteAsync(id);

        if (!responseViewModel.IsSuccess) return BadRequest(responseViewModel);

        return Ok(responseViewModel);
    }
}
