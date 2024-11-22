using Autofac;
using Examination.System.Core.Interfaces.Repositories;
using Examination.System.Repository;
using Examination.System.Service;

namespace Examination.System.Api.Config;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Repositories
        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>)).InstancePerLifetimeScope();

        // Services
        builder.RegisterAssemblyTypes(typeof(InstructorService).Assembly)
            .Where(c => c.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        //builder.RegisterType<FakeDataService>().SingleInstance();
        //builder.RegisterType<AppDbContext>().InstancePerDependency(); // Transient
        //builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces;
    }
}
