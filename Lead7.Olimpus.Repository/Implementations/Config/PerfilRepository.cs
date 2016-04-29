using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class PerfilRepository : RepositoryBase<Perfil, int>, IPerfilRepository
    {
        public PerfilRepository(ISession session) : base(session){ }
    }
}