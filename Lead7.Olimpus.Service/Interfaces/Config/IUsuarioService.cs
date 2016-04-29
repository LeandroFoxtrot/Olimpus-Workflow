using Lead7.Olimpus.Domain.Config;

namespace Lead7.Olimpus.Service.Interfaces.Config
{
    public interface IUsuarioService
    {
        Usuario Login(string user, string pwd);
    }
}