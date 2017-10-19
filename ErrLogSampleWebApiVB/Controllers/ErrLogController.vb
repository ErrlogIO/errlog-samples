Imports System.Net
Imports System.Net.Http
Imports System.Web.Http


Namespace Controllers
    Public Class ErrLogController
        Inherits ApiController

        <HttpGet>
        <Route("api/ErrLog/CheckRoutes")>
        Public Sub CheckRoutes()

            '  Check Routes
            Dim routes As String() = {"api/ErrLog/HelloWorld", 
                "api/ErrLog/ErrLogVersion", 
                "api/ErrLog/InvalidCastException", 
                "api/ErrLog/NullReferenceException", 
                "api/ErrLog/SqlException",
                "api/ErrLog/IndexOutOfRangeException", 
                "api/ErrLog/ArgumentException"}

            For Each route As String In routes
                Using client As New WebClient()
                    Try
                        Dim url = HttpContext.Current.Request.Url
                        Dim fullRoute As String = $"{url.Scheme}://{url.Host}:{url.Port}/{route}"

                        client.DownloadString(fullRoute)
                    Catch ex As Exception
                        ErrLog.logger.log(ex)
                    End Try
                End Using
            Next
        End Sub

        <HttpGet>
        <Route("api/ErrLog/HelloWorld")>
        Public Function HelloWorld() As HttpResponseMessage
            Dim response As HttpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, "Hello, World!")

            Return response
        End Function
        ''' <summary>
        ''' A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/ErrLogVersion")>
        Public Function ErrLogVersion() As HttpResponseMessage
            Dim response As HttpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, ErrLog.logger.version())

            Return response

        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/InvalidCastException")>
        Public Function InvalidCastException() As IHttpActionResult
            Dim str As Object = "This is not an int"

            Dim c As Integer = CInt(str)
            Return Ok()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/NullReferenceException")>
        Public Function NullReferenceException() As IHttpActionResult
            Dim result As String = Nothing

            Dim upper As String = result.ToUpper()
            Return Ok()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/SqlException")>
        Public Function SqlException() As IHttpActionResult
            Using conn = New System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")
                conn.Open()
            End Using
            Return Ok()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/IndexOutOfRangeException")>
        Public Function IndexOutOfRangeException() As IHttpActionResult
            Dim array As Integer() = {1, 2, 3, 4, 5}

            Dim num As Integer = array(6)
            Return Ok()
        End Function
        ''' <summary>
        ''' This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        ''' </summary>
        <HttpGet>
        <Route("api/ErrLog/ArgumentException")>
        Public Function ArgumentException() As IHttpActionResult
            Using conn = New System.Data.SqlClient.SqlConnection("This is not a real connection string")
                conn.Open()
            End Using
            Return Ok()
        End Function
    End Class
End Namespace