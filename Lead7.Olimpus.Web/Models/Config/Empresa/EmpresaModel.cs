using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Lead7.Olimpus.Web.Models.Config.Modulo;
using Lead7.Olimpus.Web.Models.Config.Perfil;

namespace Lead7.Olimpus.Web.Models.Config.Empresa
{
    public class EmpresaModel : ModelBase
    {
        public int Id { get; set; }

        [Required]
        public string NomeEmpresa { get; set; }

        public byte[] Logotipo { get; set; }

        public IList<PerfilModel> Perfis { get; set; }

        public IList<ModuloModel> Modulos { get; set; } 

        public IList<SelectListItem> ListaPerfis { get; set; } 

        public IList<SelectListItem> ListaModulos { get; set; } 

        public EmpresaModel()
        {
            Perfis = new List<PerfilModel>();
            Modulos = new List<ModuloModel>();
            ListaPerfis = new List<SelectListItem>();
            ListaModulos = new List<SelectListItem>();
        }
    }
}