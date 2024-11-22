using Examination.System.Core.Models;

namespace Examination.System.Core.Interfaces.Services;

public interface IInstructorService
{
    Task CreateInstructor(Instructor instructor);
    Instructor? GetByEmail(string email);
    Instructor? GetById(int id);
    IEnumerable<Instructor> GetAll();
    Task UpdateName(int id, string name);

}
