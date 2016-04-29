using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class RegraRepository : RepositoryBase<Papel, int>, IRegraRepository
    {
        public RegraRepository(ISession session) : base(session){ }
    }
}