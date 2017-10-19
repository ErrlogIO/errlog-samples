Imports System.Web.Http

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        ErrLog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF"
    End Sub
    Protected Sub Application_Error(sender As Object, e As EventArgs)
        Dim ex As Exception = Server.GetLastError().GetBaseException()
        ErrLog.logger.log(ex)
    End Sub
End Class
