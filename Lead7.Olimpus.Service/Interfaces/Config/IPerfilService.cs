using System.Collections.Generic;
using Lead7.Olimpus.Domain.Config;

namespace Lead7.Olimpus.Service.Interfaces.Config
{
    public interface IPerfilService
    {
        IList<Perfil> GetPerfis();
        Perfil GetPerfil(int id);
        void Create(Perfil obj);
        void Update(Perfil obj);
        void Delete(int id);
    }
}