using System.Collections.Generic;
using System.Linq;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using Lead7.Olimpus.Service.Interfaces.Config;

namespace Lead7.Olimpus.Service.Implementations.Config
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository repository)
        {
            _menuRepository = repository;
        }

        public IList<Menu> GetMenus()
        {
            return _menuRepository.GetAll(x => x.Pai == null).OrderBy(x => x.Ordem).ToList();
        }
    }
}