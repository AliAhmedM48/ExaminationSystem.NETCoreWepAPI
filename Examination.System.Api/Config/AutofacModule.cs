using Autofac;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Repository;
using Examination.System.Service.Services;
using FluentValidation;

namespace Examination.System.Api.Config;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Repositories
        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>)).InstancePerLifetimeScope();

        // Services
        builder.RegisterAssemblyTypes(typeof(CourseService).Assembly)
            .Where(c => c.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        // Validators
        //builder.RegisterAssemblyTypes(typeof(CourseValidator).Assembly)
        //    .AsClosedTypesOf(typeof(IValidator<>)).InstancePerDependency();
        //builder.RegisterType<FakeDataService>().SingleInstance();
        //builder.RegisterType<AppDbContext>().InstancePerDependency(); // Transient
        //builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces;
    }
}