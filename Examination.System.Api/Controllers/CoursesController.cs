using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.ViewModels;
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
    public async Task<IActionResult> GetAllCourse()
    {
        var courseViewModels = _courseService.GetAll();
        return Ok(courseViewModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var courseViewModel = _courseService.GetById(id);
        return Ok(courseViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseCreateViewModel model)
    {
        await _courseService.AddAsync(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCourse(CourseEditViewModel model)
    {
        await _courseService.Update(model);
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> AssignCourse(int studentId, int courseId)
    {
        await _courseService.Assign(studentId, courseId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        await _courseService.Delete(id);
        return NoContent();
    }


}
