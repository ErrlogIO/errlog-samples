using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ErrLogSampleWebMVCCS {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ErrLog.settings.apikey = "[your api key]";
        }
        protected void Application_Error() {
            Exception ex = Server.GetLastError().GetBaseException();
            ErrLog.logger.log(ex);
        }
    }
}
