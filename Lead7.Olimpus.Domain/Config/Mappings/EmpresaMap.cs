using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Config.Mappings
{
    public class EmpresaMap : ClassMap<Empresa>
    {
        public EmpresaMap()
        {
            Table("tbEmpresas");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Increment();
            Map(x => x.Nome).Not.Nullable().Length(100).Index("IX_Empresas_Nome");
            Map(x => x.Logotipo).Nullable().CustomType<NHibernate.Type.BinaryBlobType>();
            HasManyToMany(x => x.Modulos).Cascade.All().Table("tbEmpresasModulos");
            HasManyToMany(x => x.Perfis).Cascade.All().Table("tbEmpresasPerfis");
        }
    }
}