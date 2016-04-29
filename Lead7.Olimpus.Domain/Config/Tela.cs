using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Tela : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual IList<Campo> Campos { get; set; }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Tela)) return false;

            var u = (Tela)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}