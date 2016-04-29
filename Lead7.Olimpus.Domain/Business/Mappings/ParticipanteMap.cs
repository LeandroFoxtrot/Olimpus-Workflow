using FluentNHibernate.Mapping;

namespace Lead7.Olimpus.Domain.Business.Mappings
{
    public class ParticipanteMap : ClassMap<Participante>
    {
        public ParticipanteMap()
        {
            Table("tbParticipantes");
            Id(x => x.Id).Not.Nullable().GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable().Length(150).Index("IX_Participantes_Nome");
        }
    }
}