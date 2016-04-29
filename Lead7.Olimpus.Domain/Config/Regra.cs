namespace Lead7.Olimpus.Domain.Config
{
    public class Regra : Entity<int>
    {
        #region Properties

        public virtual TipoObjeto Objeto { get; set; }
        public virtual int IdObjeto { get; set; }
        public virtual bool Acesso { get; set; }
        public virtual bool SomenteLeitura { get; set; }
        public virtual bool Obrigatorio { get; set; }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Regra)) return false;

            var u = (Regra)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}