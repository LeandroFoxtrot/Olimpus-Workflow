namespace Lead7.Olimpus.Domain.Config
{
    public class Modulo : Entity<int>
    {
        #region Properties

        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool PodeExcluir { get; set; }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Modulo)) return false;

            var u = (Modulo)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}