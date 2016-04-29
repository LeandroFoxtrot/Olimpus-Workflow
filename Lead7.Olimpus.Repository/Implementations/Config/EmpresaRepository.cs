using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class EmpresaRepository : RepositoryBase<Empresa, int>, IEmpresaRepository
    {
        public EmpresaRepository(ISession session) : base(session){ }
    }
}