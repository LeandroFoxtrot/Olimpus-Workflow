using System.Collections.Generic;
using System.Linq;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using Lead7.Olimpus.Service.Interfaces.Config;

namespace Lead7.Olimpus.Service.Implementations.Config
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _moduloRepository;

        public ModuloService(IModuloRepository repository)
        {
            _moduloRepository = repository;
        }

        public IList<Modulo> GetModulos()
        {
            return _moduloRepository.GetAll().ToList();
        }

        public Modulo GetModulo(int id)
        {
            return _moduloRepository.Get(id);
        }

        public void Create(Modulo obj)
        {
            _moduloRepository.Create(obj);
        }

        public void Update(Modulo obj)
        {
            _moduloRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _moduloRepository.Delete(id);
        }
    }
}