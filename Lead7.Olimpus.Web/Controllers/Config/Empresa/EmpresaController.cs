using System.IO;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using Lead7.Olimpus.Service.Interfaces.Config;
using Lead7.Olimpus.Web.Models.Config.Empresa;
using Lead7.Olimpus.Web.Models.Config.Modulo;
using Lead7.Olimpus.Web.Models.Config.Perfil;

namespace Lead7.Olimpus.Web.Controllers.Config.Empresa
{
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _companyService;
        private readonly IPerfilService _perfilService;
        private readonly IModuloService _moduloService;

        public EmpresaController(IEmpresaService companyService, IPerfilService perfilService, IModuloService moduloService)
        {
            _companyService = companyService;
            _perfilService = perfilService;
            _moduloService = moduloService;
        }

        public ActionResult Index()
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var model =
                _companyService.GetEmpresas()
                    .Select(
                        x =>
                            new EmpresaModel()
                            {
                                Id = x.Id,
                                NomeEmpresa = x.Nome,
                                Logotipo = x.Logotipo,
                                Perfis = x.Perfis.Select(y => new PerfilModel() { Id = y.Id, Nome = y.Nome }).ToList(),
                                Modulos = x.Modulos.Select(y => new ModuloModel() { Id = y.Id, Nome = y.Nome, Descricao = y.Descricao }).ToList()
                            })
                    .ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var model = new EmpresaModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmpresaModel model)
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var data = new byte[] { };

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["imgBtn"];

                using (var inputStream = pic.InputStream)
                {
                    var memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    model.Logotipo = data;
                }
            }

            _companyService.Create(new Domain.Config.Empresa() { Logotipo = model.Logotipo, Nome = model.NomeEmpresa });

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var qry = _companyService.GetEmpresa(id);
            var model = new EmpresaModel()
            {
                Id = qry.Id,
                Logotipo = qry.Logotipo,
                NomeEmpresa = qry.Nome,
                Perfis = qry.Perfis.Select(x => new PerfilModel() { Id = x.Id, Nome = x.Nome}).ToList(),
                Modulos = qry.Modulos.Select(x => new ModuloModel() { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao, PodeExcluir = x.PodeExcluir }).ToList(),
                ListaPerfis = _perfilService.GetPerfis().Select(x => new SelectListItem() { Text = x.Nome, Value = x.Id.ToString() }).ToList(),
            };

            model.ListaModulos = _moduloService.GetModulos().Where(w => model.Modulos.All(p => p.Id != w.Id)).Select(x => new SelectListItem() { Text = x.Nome, Value = x.Id.ToString() }).ToList();

            model.ListaPerfis.Insert(0, new SelectListItem() { Value = "0", Text = "" });
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EmpresaModel model)
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var data = new byte[] { };
            var obj = _companyService.GetEmpresa(model.Id);

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["imgBtn"];

                using (var inputStream = pic.InputStream)
                {
                    var memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    model.Logotipo = data;
                }
            }

            obj.Logotipo = model.Logotipo;
            obj.Nome = model.NomeEmpresa;

            _companyService.Update(obj);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            _companyService.Delete(id);

            var model = _companyService.GetEmpresas().Select(x => new EmpresaModel() { Id = x.Id, NomeEmpresa = x.Nome, Logotipo = x.Logotipo }).ToList();

            return PartialView("Index", model);
        }

        [HttpPost]
        public ActionResult AddPerfil(int id)
        {
            var session = (Domain.Config.Usuario)Session["Login"];

            if (!this.User.Identity.IsAuthenticated || session == null) return Logout();

            var result = _perfilService.GetPerfil(id);
            var qry = _companyService.GetEmpresa(id);

            if (!qry.Perfis.Contains(result))
            {
                qry.Perfis.Add(result);
                _companyService.Update(qry);
            }

            var model = new EmpresaModel()
            {
                Id = qry.Id,
                Logotipo = qry.Logotipo,
                NomeEmpresa = qry.Nome,
                Perfis = qry.Perfis.Select(x => new PerfilModel() { Id = x.Id, Nome = x.Nome }).ToList(),
                ListaPerfis = _perfilService.GetPerfis().Select(x => new SelectListItem() { Text = x.Nome, Value = x.Id.ToString() }).ToList()
            };

            model.ListaPerfis.Insert(0, new SelectListItem() { Value = "0", Text = "" });            
            return PartialView("Perfil/Index", model);
        }

        [HttpPost]
        public ActionResult DeleteModulo(int idModulo, int idEmpresa)
        {
            var model = _companyService.GetEmpresas().Select(x => new EmpresaModel() { Id = x.Id, NomeEmpresa = x.Nome, Logotipo = x.Logotipo }).ToList();

            return PartialView("Index", model);
        }
    }
}