using System.Collections.Generic;
using System.Linq;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using Lead7.Olimpus.Service.Interfaces.Config;

namespace Lead7.Olimpus.Service.Implementations.Config
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _empresaRepository = repository;
        }

        public IList<Empresa> GetEmpresas()
        {
            return _empresaRepository.GetAll().ToList();
        }

        public Empresa GetEmpresa(int id)
        {
            return _empresaRepository.Get(id);
        }

        public void Create(Empresa obj)
        {
            _empresaRepository.Create(obj);
        }

        public void Update(Empresa obj)
        {
            _empresaRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _empresaRepository.Delete(id);
        }
    }
}