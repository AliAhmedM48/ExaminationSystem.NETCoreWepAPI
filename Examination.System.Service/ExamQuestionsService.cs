using Examination.System.Core.Entities.JoinEntities;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.ViewModels.ExamQuestions;

namespace Examination.System.Service;

public class ExamQuestionsService : IExamQuestionsService
{
    private readonly IRepository<StudentExamQuestionChoice> _repository;

    public ExamQuestionsService(IRepository<StudentExamQuestionChoice> repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(ExamQuestionsCreateViewModel examQuestionsViewModel)
    {
        //await _repository.AddAsync(new StudentExamQuestionChoice
        //{
        //    QuestionId = examQuestionsViewModel.QuestionId,
        //    ExamId = examQuestionsViewModel.ExamId,
        //    CreatedAt = DateTime.Now
        //});

        //await _repository.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<ExamQuestionsCreateViewModel> examQuestionsCreateViewModels)
    {
        //foreach (var viewModel in examQuestionsCreateViewModels)
        //{
        //    await _repository.AddAsync(new StudentExamQuestionChoice()
        //    {
        //        ExamId = viewModel.ExamId,
        //        QuestionId = viewModel.QuestionId,
        //        CreatedAt = DateTime.Now
        //    });
        //}

        //await _repository.SaveChangesAsync();
    }
}

