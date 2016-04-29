using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using Lead7.Olimpus.Service.Interfaces.Config;

namespace Lead7.Olimpus.Service.Implementations.Config
{
    public class PerfilService : IPerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository repository)
        {
            _perfilRepository = repository;
        }

        public IList<Perfil> GetPerfis()
        {
            return _perfilRepository.GetAll().ToList();
        }

        public Perfil GetPerfil(int id)
        {
            return _perfilRepository.Get(id);
        }

        public void Create(Perfil obj)
        {
            _perfilRepository.Create(obj);
        }

        public void Update(Perfil obj)
        {
            _perfilRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _perfilRepository.Delete(id);
        }
    }
}