using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Perfil : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual IList<Papel> Papeis { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; } 

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Perfil)) return false;

            var u = (Perfil)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}