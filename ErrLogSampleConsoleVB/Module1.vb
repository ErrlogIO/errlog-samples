Module Module1

    Sub PrintHelp()
        Console.WriteLine(
"1) Print ""Hello, World!""
2) Print Current ErrLog version
3) Throw an InvalidCastException
4) Throw an IndexOutOfBoundsException
5) Throw an ArgumentException
6) Throw a NullReferenceException
7) Throw a SQLException
or
q) Quit
")
    End Sub
    Private  Sub UnhandledExceptionCatcher(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex = TryCast(e.ExceptionObject, Exception)
        ErrLog.logger.log(ex)
    End Sub
    Sub Main(args As String())
        ErrLog.settings.apikey = "[your api key]"
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionCatcher

        PrintHelp()

        While True
            Try
                Console.Write("Please select an option: ")
                Dim key As Char = Console.ReadKey().KeyChar
                Console.WriteLine()

                Select Case key
                    Case "h"c, "H"c
                        PrintHelp()
                        Exit Select
                    Case "q"c, "Q"c
                        Environment.Exit(0)
                        Exit Select
                    Case "1"c
                        ' Hello, World!
                        Console.WriteLine("Hello, World!")
                        Exit Select
                    Case "2"c
                        ' ErrLog version
                        Console.WriteLine($"ErrLog.IO version: {ErrLog.logger.version()}")
                        Exit Select
                    Case "3"c
                        ' InvalidCastException
                        Dim str As Object = "This is not an int"

                        Dim c As Integer = CInt(str)

                        Exit Select
                    Case "4"c
                        ' IndexOutOfBoundsException
                        Dim array As Integer() = {1, 2, 3, 4, 5}

                        Dim num As Integer = array(6)
                        Exit Select
                    Case "5"c
                        ' ArgumentException
                        Using conn = New System.Data.SqlClient.SqlConnection("This is not a real connection string")
                            conn.Open()
                        End Using
                        Exit Select
                    Case "6"c
                        ' NullReferenceException
                        Dim result As String = Nothing

                        Dim upper As String = result.ToUpper()
                        Exit Select
                    Case "7"c
                        ' SQLException
                        Using conn = New System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")
                            conn.Open()
                        End Using
                        Exit Select
                    Case Else
                        PrintHelp()
                        Exit Select
                End Select
            Catch ex As Exception
                Console.WriteLine($"Sending exception to errlog.io: {ex.Message}")

                Dim startTime As DateTime = DateTime.Now
                Console.WriteLine($"ErrLog.IO Response: {ErrLog.logger.log(ex)}")
                Dim endTime As DateTime = DateTime.Now

                Dim timespan As TimeSpan = endTime - startTime

                Console.WriteLine($"Submission took {timespan.TotalSeconds} seconds")

            End Try
        End While
    End Sub

End Module
