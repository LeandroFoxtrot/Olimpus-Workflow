using System;
using System.Linq;
using System.Web.Mvc;
using Lead7.Olimpus.Service.Interfaces.Config;
using Lead7.Olimpus.Web.Models.Config.Empresa;
using Lead7.Olimpus.Web.Models.Config.Perfil;
using Newtonsoft.Json;

namespace Lead7.Olimpus.Web.Controllers.Config.Perfil
{
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        public ActionResult Index(EmpresaModel m)
        {
            return PartialView(m);
        }

        //[HttpGet]
        //public string GetPerfis()
        //{
        //    var result = _perfilService.GetPerfis().Select(x => new PerfilModel() { Id = x.Id, Nome = x.Nome }).ToList();
        //    var json = JsonConvert.SerializeObject(result);
        //    return json;
        //}
    }
}