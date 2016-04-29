using System.Threading;
using System.Web.Mvc;
using System.Web.Security;

namespace Lead7.Olimpus.Web.Controllers
{
    public class ControllerBase : Controller
    {
        internal string DinamicText(string resource, string key)
        {
            return (string)ControllerContext.HttpContext.GetGlobalResourceObject(resource, key, Thread.CurrentThread.CurrentUICulture);
        }

        internal RedirectToRouteResult Logout()
        {
            Session["Login"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("DoLogin", "Usuario");
        }
    }
}
