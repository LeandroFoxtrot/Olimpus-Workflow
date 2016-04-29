using System.Globalization;
using System.Web;
using System.Web.SessionState;

namespace Lead7.Olimpus.Web.Providers
{
    public class SessionHelper
    {
        private static HttpSessionState Session => HttpContext.Current.Session;

        public static CultureInfo Culture
        {
            get
            {
                return (CultureInfo)Session["Culture"];
            }
            set
            {
                Session["Culture"] = value;
            }
        }
    }
}