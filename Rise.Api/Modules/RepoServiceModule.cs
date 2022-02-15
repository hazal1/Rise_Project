using Autofac;
using Rise.Core.Repositories;
using Rise.Core.Services;
using Rise.Core.UnitOfWorks;
using Rise.Repository;
using Rise.Repository.Repositories;
using Rise.Repository.UnitOfWorks;
using Rise.Service.Mapping;
using Rise.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace Rise.Api.Modules
{
    public class RepoServiceModule:Module
    {
       protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();           
            var apiAssembly=Assembly.GetExecutingAssembly();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();            
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces()
.InstancePerLifetimeScope().AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces()
.InstancePerLifetimeScope().AsImplementedInterfaces();
        }
    }
}
