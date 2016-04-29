using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lead7.Olimpus.Domain;
using Lead7.Olimpus.Service;
using Lead7.Olimpus.Web.Models;
using Lead7.Olimpus.Web.Models.Config.Usuario;

namespace Lead7.Olimpus.Web.Controllers.Config.Usuario
{
    public partial class UsuarioController
    {
        [AllowAnonymous]
        public ActionResult DoLogin()
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoLogin(LoginModel model)
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut();

            try
            {
                var result = _usuarioService.Login(model.Usuario, GeneralService.Encrypt(model.Senha, true));

                if (result != null && result.DadosGerais.Status == Status.Ativo)
                {
                    var ticket = new FormsAuthenticationTicket(1, model.Usuario, DateTime.Now,
                        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes), true, model.Usuario);
                    var hashedTicket = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashedTicket)
                    {
                        Expires = ticket.Expiration
                    };

                    HttpContext.Response.Cookies.Add(cookie);
                    Session["Login"] = result;

                    var menus = _menuService.GetMenus();

                    Session["Menus"] = menus;
                    FormsAuthentication.SetAuthCookie(result.Nome, true);
                    return RedirectToAction("Index", "Home");
                }
                if (result != null && result.DadosGerais.Status == Status.Desabilitado)
                {
                    model.Erro = new ErroModel {Id = 1, Mensagem = DinamicText("Erros", "ErroLogin1")};
                }
                else
                {
                    model.Erro = new ErroModel {Id = 2, Mensagem = DinamicText("Erros", "ErroLogin2")};
                }
            }
            catch (Exception ex)
            {
                model.Erro = new ErroModel {Id = ex.HResult, Mensagem = ex.Message};
            }

            return View(model);
        }

        public ActionResult DoLogoff()
        {
            FormsAuthentication.SignOut();
            Session["Login"] = null;
            Session["Menus"] = null;
            return RedirectToAction("DoLogin", "Usuario");
        }
    }
}