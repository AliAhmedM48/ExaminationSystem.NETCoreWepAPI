using Examination.System.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Examination.System.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InstructorsController : ControllerBase
{
    //[HttpPost]
    //public Task Create(Instructor instructor)
    //{

    //}

    [HttpGet]
    public async Task<IActionResult> Get(string name)
    {
        AppDbContext appDbContext = new AppDbContext();

        var instructor =
            appDbContext.Instructors
            .Where(x => x.Name.Contains("Aliiii"))
            .FirstOrDefault();

        return Ok(instructor);
    }
}
