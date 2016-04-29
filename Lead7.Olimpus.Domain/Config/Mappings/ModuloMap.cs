using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class ModuloMap : ClassMap<Modulo>
    {
        public ModuloMap()
        {
            Table("tbModulos");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Column("Modulo_Nome").Length(50).Not.Nullable().Index("IX_MODULO_NOME");
            Map(x => x.Descricao).Column("Modulo_Descricao").Length(200).Not.Nullable();
            Map(x => x.PodeExcluir).Column("Modulo_PodeExcluir").Not.Nullable();
        }
    }
}