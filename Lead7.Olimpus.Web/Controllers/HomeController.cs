using System.Globalization;
using System.Web.Mvc;
using Lead7.Olimpus.Domain.Config;
using Lead7.Olimpus.Web.Providers;

namespace Lead7.Olimpus.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        [Authorize]
        public ActionResult Index()
        {
            var session = (Usuario)Session["Login"];

            if (User.Identity.IsAuthenticated && session != null) return View();

            return Logout();
        }

        [Authorize]
        public ActionResult Language(string language)
        {
            SessionHelper.Culture = new CultureInfo(language);
            return RedirectToAction("Index", "Home");
        }
    }
}