using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Table("tbMenu");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Not.Nullable().Length(30);
            Map(x => x.Ordem).Not.Nullable().Index("IX_Menu_Ordem");
            Map(x => x.Classe).Nullable().Length(150);
            Map(x => x.EnderecoURL).Nullable().Length(150);
            References(x => x.Pai).Column("ParentId").Not.LazyLoad();
            HasMany(x => x.Filhos).Cascade.All().KeyColumn("ParentId").Not.LazyLoad();
        }
    }
}