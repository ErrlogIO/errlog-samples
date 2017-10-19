Public Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs)
    End Sub
    ''' <summary>
    ''' A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
    ''' </summary>
    Protected Sub btnErrLogVersion_Click(sender As Object, e As EventArgs)
        lblMessage.Text = $"ErrLog version: {ErrLog.logger.version()}"
    End Sub
    ''' <summary>
    ''' A test method to verify basic page functionality. It displays "Hello, World!" in a box on the page.
    ''' </summary>
    Protected Sub btnHelloWorld_Click(sender As Object, e As EventArgs)
        lblMessage.Text = "Hello, World!"
    End Sub
    ''' <summary>
    ''' This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log" /> method. See also <see cref="ErrLogSampleWebWebFormsVB.Global_asax.Application_Start"/> for configuration
    ''' </summary>
    Protected Sub btnInvalidCastException_Click(sender As Object, e As EventArgs)
        Dim str As Object = "This is not an int"

        Dim c As Integer = CInt(str)
    End Sub
    ''' <summary>
    ''' This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log" /> method. See also <see cref="ErrLogSampleWebWebFormsVB.Global_asax.Application_Start"/> for configuration
    ''' </summary>
    Protected Sub btnNullReferenceException_Click(sender As Object, e As EventArgs)
        Dim result As String = Nothing

        Dim upper As String = result.ToUpper()
    End Sub
    ''' <summary>
    ''' This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log" /> method. See also <see cref="ErrLogSampleWebWebFormsVB.Global_asax.Application_Start"/> for configuration
    ''' </summary>
    Protected Sub btnSqlException_Click(sender As Object, e As EventArgs)
        Using conn As New System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")
            conn.Open()
        End Using
    End Sub
    ''' <summary>
    ''' This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log" /> method. See also <see cref="ErrLogSampleWebWebFormsVB.Global_asax.Application_Start"/> for configuration
    ''' </summary>
    Protected Sub btnIndexOutOfRangeException_Click(sender As Object, e As EventArgs)
        Dim array As Integer() = {1, 2, 3, 4, 5}

        Dim num As Integer = array(6)
    End Sub
    ''' <summary>
    ''' This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log" /> method. See also <see cref="ErrLogSampleWebWebFormsVB.Global_asax.Application_Start"/> for configuration
    ''' </summary>
    Protected Sub btnArgumentException_Click(sender As Object, e As EventArgs)
        Using conn As New System.Data.SqlClient.SqlConnection("This is not a real connection string")
            conn.Open()
        End Using
    End Sub


End Class