using System.Collections.Generic;
using Lead7.Olimpus.Domain.Config;

namespace Lead7.Olimpus.Service.Interfaces.Config
{
    public interface IModuloService
    {
        IList<Modulo> GetModulos();
        Modulo GetModulo(int id);
        void Create(Modulo obj);
        void Update(Modulo obj);
        void Delete(int id);
    }
}