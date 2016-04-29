using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Usuario : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual string Logon { get; set; }
        public virtual string Senha { get; set; }
        public virtual IList<Perfil> Perfis { get; set; }
        public virtual DadosGerais DadosGerais { get; set; }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof (Usuario)) return false;

            var u = (Usuario) obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}