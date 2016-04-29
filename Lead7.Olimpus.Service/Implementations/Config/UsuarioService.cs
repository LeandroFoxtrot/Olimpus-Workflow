using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Repository.Interfaces.Config;
using Lead7.Olimpus.Service.Interfaces.Config;

namespace Lead7.Olimpus.Service.Implementations.Config
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public Usuario Login(string user, string pwd)
        {
            return _usuarioRepository.Get(x => x.Logon == user && x.Senha == pwd);
        }
    }
}