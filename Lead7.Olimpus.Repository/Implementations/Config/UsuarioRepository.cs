using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class UsuarioRepository : RepositoryBase<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(ISession session) : base(session){ }
    }
}