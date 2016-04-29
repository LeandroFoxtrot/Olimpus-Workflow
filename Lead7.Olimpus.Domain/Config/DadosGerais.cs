using System;

namespace Lead7.Olimpus.Domain.Config
{
    public class DadosGerais : Entity<int>
    {
        #region Properties

        public virtual byte?[] Fotografia { get; set; }
        public virtual string TelefoneFixo { get; set; }
        public virtual string Ramal { get; set; }
        public virtual string TelefoneCelular { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime? DataAdmissao { get; set; }
        public virtual Status Status { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion

        #region Hash

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(DadosGerais)) return false;

            var u = (DadosGerais)obj;
            return (Id == u.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        #endregion
    }
}