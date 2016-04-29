using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Lead7.Olimpus.Persistence.Util
{
    public static class DatabaseUtil
    {
        public static ISessionFactory CreateFactory<T>(string connectionString, bool createdb = false)
        {
            var cfg = new Configuration().Configure().SetProperty(Environment.ConnectionString, connectionString);

            return Fluently.Configure(cfg).Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>()).ExposeConfiguration(config =>
            {
                var se = new SchemaExport(config);
                se.Drop(true, true);
                //se.Create(true, true);
                se.Execute(true, true, !createdb);
            }).BuildSessionFactory();
        }
    }
}