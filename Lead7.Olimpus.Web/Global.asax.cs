using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Lead7.Olimpus.Dependency;
using Lead7.Olimpus.Web.Controllers.Shared;
using Lead7.Olimpus.Web.Providers;

namespace Lead7.Olimpus.Web
{
    public class WebApiApplication : HttpApplication
    {
        private WindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            InitializeWindsor();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            _windsorContainer?.Dispose();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session == null) return;

            var ci = SessionHelper.Culture;

            if (ci == null)
            {
                var langName = "pt-BR";

                if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                {
                    langName = HttpContext.Current.Request.UserLanguages[0];
                }

                ci = new CultureInfo(langName);
                SessionHelper.Culture = ci;
            }
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

        private void InitializeWindsor()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.Containing<DependencyInstaller>());
            _windsorContainer.Install(FromAssembly.This());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        }
    }
}