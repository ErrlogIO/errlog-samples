using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ErrLogSampleWebMVCCS {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ErrLog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF";
        }
        protected void Application_Error() {
            Exception ex = Server.GetLastError().GetBaseException();
            ErrLog.logger.log(ex);
        }
    }
}
