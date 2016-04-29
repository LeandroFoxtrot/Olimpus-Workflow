using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("tbUsuarios");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Not.Nullable().Length(120).Index("IX_Usuarios_Nome");
            Map(x => x.Logon).Not.Nullable().Length(120).Index("IX_Usuarios_Login");
            Map(x => x.Senha).Not.Nullable().Length(100);
            HasManyToMany(x => x.Perfis).Not.LazyLoad().Cascade.All().Table("tbPerfisUsuarios");
            HasOne(x => x.DadosGerais).Not.LazyLoad().Cascade.All();
        }
    }
}