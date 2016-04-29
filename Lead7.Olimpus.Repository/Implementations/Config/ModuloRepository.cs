using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class ModuloRepository : RepositoryBase<Modulo, int>, IModuloRepository
    {
        public ModuloRepository(ISession session) : base(session){ }
    }
}