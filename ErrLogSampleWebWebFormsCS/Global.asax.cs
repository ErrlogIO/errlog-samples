using System;

namespace ErrLogSampleWebWebFormsCS {
    public class Global : System.Web.HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            ErrLog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF";
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception ex = Server.GetLastError().GetBaseException();
            ErrLog.logger.log(ex);
        }
    }
}