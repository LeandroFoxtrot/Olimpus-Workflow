using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using NHibernate;

namespace Lead7.Olimpus.Repository.Implementations.Config
{
    public class MenuRepository : RepositoryBase<Menu, int>, IMenuRepository
    {
        public MenuRepository(ISession session) : base(session) { }
    }
}