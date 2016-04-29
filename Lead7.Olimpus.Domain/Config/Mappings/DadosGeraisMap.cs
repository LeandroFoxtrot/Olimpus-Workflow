using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class DadosGeraisMap : ClassMap<DadosGerais>
    {
        public DadosGeraisMap()
        {
            Table("tbDadosGerais");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Fotografia).Nullable().CustomType<NHibernate.Type.BinaryBlobType>();
            Map(x => x.TelefoneFixo).Nullable().Length(11);
            Map(x => x.Ramal).Nullable().Length(10);
            Map(x => x.TelefoneCelular).Nullable().Length(11);
            Map(x => x.DataAdmissao).Nullable();
            Map(x => x.Status).CustomType<int>().Not.Nullable();
            Map(x => x.Email).Length(100).Nullable();
            References(x => x.Usuario).Not.LazyLoad().Cascade.SaveUpdate();
        }
    }
}