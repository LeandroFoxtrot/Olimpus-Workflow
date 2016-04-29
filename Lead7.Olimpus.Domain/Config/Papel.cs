using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Papel : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual IList<Regra> Regras { get; set; }
        public virtual IList<Perfil> Perfis { get; set; } 

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Papel)) return false;

            var u = (Papel)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}