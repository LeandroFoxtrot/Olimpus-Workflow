using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class PapelRepository : RepositoryBase<Regra, int>, IPapelRepository
    {
        public PapelRepository(ISession session) : base(session){ }
    }
}