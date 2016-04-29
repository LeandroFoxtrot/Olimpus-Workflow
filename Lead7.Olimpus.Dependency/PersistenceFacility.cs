using System.Configuration;
using System.Reflection;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using Lead7.Olimpus.Domain.Config;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace Lead7.Olimpus.Dependency
{
    public class PersistenceFacility : AbstractFacility
    {
        private const string DBCONFIGFACTORY = "dbconfigfactory";
        private const string DBBUSINESSFACTORY = "dbbusinessfactory";
        private const string DBWORKFLOWFACTORY = "dbworkflowfactory";
        private const string DBCONFIGCONNECT = "dbconfigconnect";
        private const string DBBUSINESSCONNECT = "dbbusinessconnect";
        private const string DBWORKFLOWCONNECT = "dbworkflowconnect";

        protected override void Init()
        {
            Kernel.Register(Component.For<ISessionFactory>().UsingFactoryMethod(CreateDBConfigConnectSessionFactory).LifeStyle.Singleton.Named(DBCONFIGFACTORY),
                            Component.For<ISessionFactory>().UsingFactoryMethod(CreateDBBusinessConnectSessionFactory).LifeStyle.Singleton.Named(DBBUSINESSFACTORY),
                            Component.For<ISessionFactory>().UsingFactoryMethod(CreateDBWorkflowConnectSessionFactory).LifeStyle.Singleton.Named(DBWORKFLOWFACTORY)
            );

            Kernel.Register(Component.For<ISession>().UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>(DBCONFIGFACTORY).OpenSession()).LifeStyle.Singleton.Named(DBCONFIGCONNECT),
                            Component.For<ISession>().UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>(DBBUSINESSFACTORY).OpenSession()).LifeStyle.Singleton.Named(DBBUSINESSCONNECT),
                            Component.For<ISession>().UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>(DBWORKFLOWFACTORY).OpenSession()).LifeStyle.Singleton.Named(DBWORKFLOWCONNECT)
            );
        }

        private static ISessionFactory CreateDBConfigConnectSessionFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Olimpus_Config"].ConnectionString;
            var cfg = new NHibernate.Cfg.Configuration().Configure().SetProperty(Environment.ConnectionString, connectionString);

            return Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>()).ExposeConfiguration(config =>
            {
                var se = new SchemaExport(config);
                se.Create(false, false);
            }).BuildSessionFactory();
        }

        private static ISessionFactory CreateDBBusinessConnectSessionFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Olimpus_Business"].ConnectionString;
            var cfg = new NHibernate.Cfg.Configuration().Configure().SetProperty(Environment.ConnectionString, connectionString);

            return Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>()).ExposeConfiguration(config =>
            {
                var se = new SchemaExport(config);
                se.Create(false, false);
            }).BuildSessionFactory();
        }

        private static ISessionFactory CreateDBWorkflowConnectSessionFactory()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Olimpus_Workflow"].ConnectionString;
            var cfg = new NHibernate.Cfg.Configuration().Configure().SetProperty(Environment.ConnectionString, connectionString);

            return Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Usuario>()).ExposeConfiguration(config =>
            {
                var se = new SchemaExport(config);
                se.Create(false, false);
            }).BuildSessionFactory();
        }
    }
}