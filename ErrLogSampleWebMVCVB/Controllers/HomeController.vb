Imports System.Web.Mvc

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function


        ''' <summary>
        ''' A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
        ''' </summary>
        Public Function ErrLogVersion() As String
            Return $"ErrLog version: {ErrLog.logger.version()}"
        End Function
        ''' <summary>
        ''' A test method to verify basic page functionality. It displays "Hello, World!" in a box on the page.
        ''' </summary>
        Public Function HelloWorld() As String
            Return "Hello, World!"
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start"/> for configuration
        ''' </summary>
        Public Function InvalidCastException() As ActionResult
            Dim str As Object = "This is not an int"

            Dim c As Integer = CInt(str)
            Return New EmptyResult()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start"/> for configuration
        ''' </summary>
        Public Function NullReferenceException() As ActionResult
            Dim result As String = Nothing

            Dim upper As String = result.ToUpper()
            Return New EmptyResult()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start"/> for configuration
        ''' </summary>
        Public Function SqlException() As ActionResult
            Using conn = New System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")
                conn.Open()
            End Using
            Return New EmptyResult()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start"/> for configuration
        ''' </summary>
        Public Function IndexOutOfRangeException() As ActionResult
            Dim array As Integer() = {1, 2, 3, 4, 5}

            Dim num As Integer = array(6)
            Return New EmptyResult()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start"/> for configuration
        ''' </summary>
        Public Function ArgumentException() As ActionResult
            Using conn = New System.Data.SqlClient.SqlConnection("This is not a real connection string")
                conn.Open()
            End Using
            Return New EmptyResult()
        End Function
    End Class
End Namespace