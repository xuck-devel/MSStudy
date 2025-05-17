Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult

        Dim connectString As String = "Server=(localdb)\mssqllocaldb;Database=CSWebAppContext-91e67821-630c-4958-a9cc-29f9825a8850;Trusted_Connection=True;MultipleActiveResultSets=true"
        Dim connection As SqlConnection = Nothing
        Dim tran As SqlTransaction = Nothing

        Try

            connection = New SqlConnection(connectString)
            connection.Open()
            tran = connection.BeginTransaction()

            SelectAll(connection, tran)
            Insert(connection, tran)
            Delete(connection, tran)

        Catch ex As Exception
            Throw
        Finally
            Try
                If connection IsNot Nothing Then
                    connection.Close()
                End If
            Catch ex As Exception

            End Try
        End Try


        ViewData("Message") = "Your application description page."
        Return View()

    End Function



    Private Function SelectAll(connection As SqlConnection, tran As SqlTransaction)

        Dim command As SqlCommand = New SqlCommand("select * from dbo_Table_3", connection)
        command.Transaction = tran
        Dim Reader As SqlDataReader = command.ExecuteReader()
        While Reader.Read()
            Dim aaaa As String = Reader.GetString(0)
            Trace.WriteLine("Aaaa:" + aaaa)
        End While

    End Function

    Private Function Insert(connection As SqlConnection, tran As SqlTransaction)

        Trace.WriteLine("before insert:")
        SelectAll(connection, tran)

        Dim command As SqlCommand = New SqlCommand("insert into dbo_Table_3 values(@Aaaa)", connection)
        command.Transaction = tran
        command.Parameters.AddWithValue("@Aaaa", "99999")
        Dim rows As Integer = command.ExecuteNonQuery()

        Trace.WriteLine("after insert:")
        SelectAll(connection, tran)

    End Function
    Private Function Delete(connection As SqlConnection, tran As SqlTransaction)

        Trace.WriteLine("before delete:")
        SelectAll(connection, tran)

        Dim command As SqlCommand = New SqlCommand("delete from dbo_Table_3 where Aaaa=@Aaaa", connection)
        command.Transaction = tran
        command.Parameters.AddWithValue("@Aaaa", "99999")
        Dim rows As Integer = command.ExecuteNonQuery()

        Trace.WriteLine("after delete:")
        SelectAll(connection, tran)

    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
