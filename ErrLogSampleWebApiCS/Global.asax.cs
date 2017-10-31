using System;
using System.Web.Http;

namespace ErrLogSampleWebApiCS {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ErrLog.settings.apikey = "[your api key]";
        }

        protected void Application_Error() {
            Exception ex = Server.GetLastError().GetBaseException();
            ErrLog.logger.log(ex);
        }
    }
}
