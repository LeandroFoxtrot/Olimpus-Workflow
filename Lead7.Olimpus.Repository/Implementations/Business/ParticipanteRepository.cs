using Lead7.Olimpus.Domain.Business;
using Lead7.Olimpus.Repository.Interfaces.Business;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Business
{
    public class ParticipanteRepository : RepositoryBase<Participante, int>, IParticipanteRepository
    {
        public ParticipanteRepository(ISession session) : base(session){ }
    }
}