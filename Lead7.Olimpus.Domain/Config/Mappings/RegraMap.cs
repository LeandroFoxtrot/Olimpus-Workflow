using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class RegraMap : ClassMap<Regra>
    {
        public RegraMap()
        {
            Table("tbRegras");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Objeto).CustomType<int>().Not.Nullable();
            Map(x => x.IdObjeto).Not.Nullable();
            Map(x => x.Acesso);
            Map(x => x.SomenteLeitura);
            Map(x => x.Obrigatorio);
        }
    }
}