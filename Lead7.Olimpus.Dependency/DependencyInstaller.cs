using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Lead7.Olimpus.Dependency.UnitOfWork;
using Lead7.Olimpus.Repository.Implementations.Business;
using Lead7.Olimpus.Repository.Implementations.Config;
using Lead7.Olimpus.Service.Implementations.Business;
using Lead7.Olimpus.Service.Implementations.Config;
using NHibernate;

namespace Lead7.Olimpus.Dependency
{
    public class DependencyInstaller : IWindsorInstaller
    {
        private const string DBCONFIGCONNECT = "dbconfigconnect";
        private const string DBBUSINESSCONNECT = "dbbusinessconnect";
        private const string DBWORKFLOWCONNECT = "dbworkflowconnect";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
            container.AddFacility(new PersistenceFacility());
            container.Register(
                // Unit of Work
                Component.For<NHUnitOfWorkInterceptor>().LifeStyle.Transient,

                // Repositórios
                Classes.FromAssembly(Assembly.GetAssembly(typeof (UsuarioRepository)))
                    .InSameNamespaceAs<UsuarioRepository>()
                    .WithService.DefaultInterfaces()
                    .Configure(c => { c.DependsOn(ServiceOverride.ForKey<ISession>().Eq(DBCONFIGCONNECT)); })
                    .LifestyleTransient(),

                Classes.FromAssembly(Assembly.GetAssembly(typeof (ParticipanteRepository)))
                    .InSameNamespaceAs<ParticipanteRepository>()
                    .WithService.DefaultInterfaces()
                    .Configure(c => { c.DependsOn(ServiceOverride.ForKey<ISession>().Eq(DBBUSINESSCONNECT)); })
                    .LifestyleTransient(),

                // Serviços
                Classes.FromAssembly(Assembly.GetAssembly(typeof (UsuarioService))).InSameNamespaceAs<UsuarioService>().WithService.DefaultInterfaces().LifestyleTransient(),

                Classes.FromAssembly(Assembly.GetAssembly(typeof (ParticipanteService))).InSameNamespaceAs<ParticipanteService>().WithService.DefaultInterfaces().LifestyleTransient(),

                //All MVC controllers
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
                );
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof (NHUnitOfWorkInterceptor)));
            }

            if (
                !handler.ComponentModel.Implementation.GetMethods()
                    .Any(method => UnitOfWorkHelper.HasUnitOfWorkAttribute(method))) return;

            handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof (NHUnitOfWorkInterceptor)));
        }
    }
}