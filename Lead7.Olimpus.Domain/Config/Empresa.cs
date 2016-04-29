using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Empresa : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual byte[] Logotipo { get; set; }
        public virtual IList<Modulo> Modulos { get; set; } 
        public virtual IList<Perfil> Perfis { get; set; } 

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Empresa)) return false;

            var u = (Empresa)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}