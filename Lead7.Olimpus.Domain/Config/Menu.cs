using System.Collections.Generic;

namespace Lead7.Olimpus.Domain.Config
{
    public class Menu : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual int Ordem { get; set; }
        public virtual string Classe { get; set; }
        public virtual string EnderecoURL { get; set; }
        public virtual Menu Pai { get; set; }
        public virtual IList<Menu> Filhos { get; set; }

        #endregion

        #region Constructor

        public Menu()
        {
            Filhos = new List<Menu>();
        }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Menu)) return false;

            var u = (Menu)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}