using System.Collections.Generic;
using Lead7.Olimpus.Domain.Config;

namespace Lead7.Olimpus.Service.Interfaces.Config
{
    public interface IEmpresaService
    {
        IList<Empresa> GetEmpresas();
        Empresa GetEmpresa(int id);
        void Create(Empresa obj);
        void Update(Empresa obj);
        void Delete(int id);
    }
}