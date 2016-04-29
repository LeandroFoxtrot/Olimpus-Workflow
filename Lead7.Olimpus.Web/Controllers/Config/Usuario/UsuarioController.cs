using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Lead7.Olimpus.Service.Interfaces.Config;
using Lead7.Olimpus.Web.Providers;

namespace Lead7.Olimpus.Web.Controllers.Config.Usuario
{
    public partial class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMenuService _menuService;

        public UsuarioController(IUsuarioService userService, IMenuService menuService)
        {
            _usuarioService = userService;
            _menuService = menuService;
        }

        [Authorize]
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated) FormsAuthentication.SignOut();

            return View();
        }

        [AllowAnonymous]
        public ActionResult Language(string language)
        {
            SessionHelper.Culture = new CultureInfo(language);
            return RedirectToAction("DoLogin", "Usuario");
        }
    }
}