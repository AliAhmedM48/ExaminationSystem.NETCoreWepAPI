using Examination.System.Core.Entities.MainEntities;
using Examination.System.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examination.System.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InstructorsController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorsController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateInstructor(Instructor instructor)
    {
        await _instructorService.CreateInstructor(instructor);
        return Ok();
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var instructor = _instructorService.GetByEmail(email);
        return Ok(instructor);
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByEmail(int id)
    {
        var instructor = _instructorService.GetById(id);
        return Ok(instructor);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllInstructors()
    {
        var instructors = _instructorService.GetAll();
        return Ok(instructors);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateName(int id, string name)
    {
        await _instructorService.UpdateName(id, name);
        return Ok();
    }
}
