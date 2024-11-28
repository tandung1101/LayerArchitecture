using System.Reflection;
using Autofac;
using LayerArchitecture.API.Filters;
using LayerArchitecture.Core.Repositories;
using LayerArchitecture.Core.Services;
using LayerArchitecture.Core.UnitOfWorks;
using LayerArchitecture.Repository;
using LayerArchitecture.Repository.Repositories;
using LayerArchitecture.Repository.UnitOfWorks;
using LayerArchitecture.Service.Mapping;
using LayerArchitecture.Service.Services;
using Module = Autofac.Module;

namespace LayerArchitecture.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(NotFoundFilter<>)).AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var _repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var _serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            if (apiAssembly != null && _repoAssembly != null && _serviceAssembly != null)
            {
                builder.RegisterAssemblyTypes(apiAssembly, _repoAssembly, _serviceAssembly)
                       .Where(x => x.Name.EndsWith("Repository"))
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(apiAssembly, _repoAssembly, _serviceAssembly)
                       .Where(x => x.Name.EndsWith("Service"))
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
            }
        }
    }
}
