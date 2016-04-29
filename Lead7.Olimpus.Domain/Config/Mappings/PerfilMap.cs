using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class PerfilMap : ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Table("tbPerfis");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Not.Nullable().Length(100).Index("IX_Perfis_Nome");
            HasManyToMany(x => x.Papeis).Not.LazyLoad().Cascade.All().Table("tbPapeisPerfis");
            HasManyToMany(x => x.Usuarios).Not.LazyLoad().Cascade.All().Table("tbPerfisUsuarios");
        }
    }
}