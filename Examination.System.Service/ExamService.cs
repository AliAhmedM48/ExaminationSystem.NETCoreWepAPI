using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Core.Interfaces.Services;
using Examination.System.Core.Models;
using Examination.System.Core.ViewModels.ExamQuestions;
using Examination.System.Core.ViewModels.Exams;

namespace Examination.System.Service;

public class ExamService : IExamService
{
    private readonly IRepository<Exam> _examRepository;
    private readonly IExamQuestionsService _examQuestionsService;

    public ExamService(IRepository<Exam> examRepository, IExamQuestionsService examQuestionsService)
    {
        _examRepository = examRepository;
        _examQuestionsService = examQuestionsService;
    }
    public async Task<int> AddAsync(ExamCreateViewModel examCreateViewModel)
    {
        var exam = new Exam
        {
            Date = examCreateViewModel.Date,
            MaxGrade = examCreateViewModel.MaxGrade,
            MaxTime = examCreateViewModel.MaxTime,
            CreatedAt = DateTime.Now
            #region Bad => Duplication
            //ExamQuestions = examCreateViewModel.QuestionIds
            //.Select(x => new ExamQuestions() { QuestionId = x }).ToList()
            #endregion
        };

        await _examRepository.AddAsync(exam);

        await _examRepository.SaveChangesAsync();

        await _examQuestionsService.AddRangeAsync(
              examCreateViewModel.QuestionIds
              .Select(x => new ExamQuestionsCreateViewModel
              {
                  QuestionId = x,
                  ExamId = exam.Id
              }));
        return exam.Id;
    }

    public async Task<int> AddRandomAsync(ExamCreateViewModel examCreateViewModel)
    {
        examCreateViewModel.QuestionIds = new List<int>();
        return await AddAsync(examCreateViewModel);
    }
}
