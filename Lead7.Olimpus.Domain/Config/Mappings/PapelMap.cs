using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class PapelMap : ClassMap<Papel>
    {
        public PapelMap()
        {
            Table("tbPapeis");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Length(150).Not.Nullable().Index("IX_Papeis_Nome");
            HasMany(x => x.Regras).Not.LazyLoad().Cascade.All();
            HasManyToMany(x => x.Perfis).Not.LazyLoad().Cascade.All().Table("tbPapeisPerfis");
        }
    }
}