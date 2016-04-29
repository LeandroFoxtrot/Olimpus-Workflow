using System.Collections.Generic;
using Lead7.Olimpus.Domain.Config;

namespace Lead7.Olimpus.Service.Interfaces.Config
{
    public interface IMenuService
    {
        IList<Menu> GetMenus();
    }
}