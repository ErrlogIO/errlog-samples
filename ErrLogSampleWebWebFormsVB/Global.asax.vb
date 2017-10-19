
Public Class Global_asax
    Inherits HttpApplication

    Protected Sub Application_Start(sender As Object, e As EventArgs)
        ErrLog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF"
    End Sub

    Protected Sub Application_Error(sender As Object, e As EventArgs)
        Dim ex As Exception = Server.GetLastError().GetBaseException()
        ErrLog.logger.log(ex)
    End Sub
End Class