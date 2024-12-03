//using Examination.System.Core.Entities.MainEntities;
//using Examination.System.Core.Interfaces.Repositories;
//using Examination.System.Core.Interfaces.Services;

//namespace Examination.System.Service;

//public class InstructorService : IInstructorService
//{
//    private readonly IRepository<Instructor> _repository;

//    public InstructorService(IRepository<Instructor> repository)
//    {
//        _repository = repository;
//    }

//    public async Task CreateInstructor(Instructor instructor)
//    {
//        await _repository.AddAsync(instructor);
//        await _repository.SaveChangesAsync();
//    }

//    public IEnumerable<Instructor> GetAll()
//    {
//        var instructors = _repository.GetAll().ToList();
//        return instructors;
//    }

//    public Instructor? GetById(int id)
//    {
//        var instructor = _repository.GetById(id);
//        return instructor;
//    }

//    public Instructor? GetByEmail(string email)
//    {
//        var instructor = _repository.Get(i => i.Email == email).FirstOrDefault();
//        return instructor;
//    }

//    public async Task UpdateName(int id, string name)
//    {
//        var instructor = new Instructor() { Id = id, FullName = name };
//        _repository.SaveInclude(instructor, i => i.FullName);
//        await _repository.SaveChangesAsync();
//    }
//}
