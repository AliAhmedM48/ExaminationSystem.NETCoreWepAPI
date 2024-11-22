using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Examination.System.Api.Config;
using Examination.System.Api.Middlewares;
using Examination.System.Core.MappingProfiles;
using Examination.System.Repository;
using Examination.System.Service;
using Microsoft.EntityFrameworkCore;

namespace Examination.System.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Default DI Container
        //builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //builder.Services.AddScoped<IRepository<Exam>, Repository<Exam>>();
        //builder.Services.AddScoped<IExamService, ExamService>();

        //builder.Services.AddScoped<IRepository<Question>, Repository<Question>>();
        //builder.Services.AddScoped<IQuestionService, QuestionService>();

        //builder.Services.AddScoped<IRepository<ExamQuestion>, Repository<ExamQuestion>>();
        //builder.Services.AddScoped<IExamQuestionsService, ExamQuestionsService>();

        //builder.Services.AddScoped<IRepository<ExamQuestion>, Repository<ExamQuestion>>();
        //builder.Services.AddScoped<IExamQuestionsService, ExamQuestionsService>();

        //builder.Services.AddScoped<IRepository<Instructor>, Repository<Instructor>>();
        //builder.Services.AddScoped<IInstructorService, InstructorService>();
        #endregion

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(container =>
        {
            container.RegisterModule(new AutofacModule());
        });

        builder.Services.AddAutoMapper(typeof(CourseProfile).Assembly);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            #region Update Database Based on Pending Migration
            var appDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            await appDbContext.Database.MigrateAsync();
            #endregion

            #region Seed Data
            await DataSeeder.SeedData(appDbContext);
            #endregion
        }

        MappingService.Mapper = app.Services.GetRequiredService<IMapper>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        #region Custom Middleware
        app.UseMiddleware<GlobalErrorHandlerMiddleware>();
        app.UseMiddleware<TransactionMiddleware>();
        #endregion

        app.Run();
    }
}
