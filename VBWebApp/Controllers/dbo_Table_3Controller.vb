Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports VBWebApp
Imports VBWebApp.Data

Public Class dbo_Table_3Controller
    Inherits System.Web.Mvc.Controller

    Private db As New VBWebAppContext

    ' GET: dbo_Table_3
    Function Index() As ActionResult

        Dim reqparam = Request.Params
        Dim requestbody = Request.InputStream

        'Dim buf(1024) As Byte
        'requestbody.Read(buf, 0, 1024)

        Dim lst As List(Of dbo_Table_3) = db.Database.SqlQuery(Of dbo_Table_3)("SELECT Aaaa FROM dbo_Table_3").ToList()

        Return View(db.dbo_Table_3.ToList())
    End Function

    ' GET: dbo_Table_3/Details/5
    Function Details(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim dbo_Table_3 As dbo_Table_3 = db.dbo_Table_3.Find(id)
        If IsNothing(dbo_Table_3) Then
            Return HttpNotFound()
        End If
        Return View(dbo_Table_3)
    End Function

    ' GET: dbo_Table_3/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: dbo_Table_3/Create
    '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
    '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function Create(<Bind(Include:="Aaaa")> ByVal dbo_Table_3 As dbo_Table_3) As ActionResult
        If ModelState.IsValid Then
            db.dbo_Table_3.Add(dbo_Table_3)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View(dbo_Table_3)
    End Function

    ' GET: dbo_Table_3/Edit/5
    Function Edit(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If

        Dim Sql As String = "SELECT Aaaa FROM dbo_Table_3 where Aaaa=@Aaaa"
        Dim param As SqlParameter = New SqlParameter("@Aaaa", id)
        Dim rs = db.Database.SqlQuery(Of dbo_Table_3)(Sql, param)
        Dim rec As dbo_Table_3 = rs.First()


        Dim dbo_Table_3 As dbo_Table_3 = db.dbo_Table_3.Find(id)
        If IsNothing(dbo_Table_3) Then
            Return HttpNotFound()
        End If
        Return View(dbo_Table_3)
    End Function

    ' POST: dbo_Table_3/Edit/5
    '過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
    '詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
    <HttpPost()>
    <ValidateAntiForgeryToken()>
    Function Edit(<Bind(Include:="Aaaa")> ByVal dbo_Table_3 As dbo_Table_3) As ActionResult
        If ModelState.IsValid Then
            db.Entry(dbo_Table_3).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View(dbo_Table_3)
    End Function

    ' GET: dbo_Table_3/Delete/5
    Function Delete(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim dbo_Table_3 As dbo_Table_3 = db.dbo_Table_3.Find(id)
        If IsNothing(dbo_Table_3) Then
            Return HttpNotFound()
        End If
        Return View(dbo_Table_3)
    End Function

    ' POST: dbo_Table_3/Delete/5
    <HttpPost()>
    <ActionName("Delete")>
    <ValidateAntiForgeryToken()>
    Function DeleteConfirmed(ByVal id As String) As ActionResult
        Dim dbo_Table_3 As dbo_Table_3 = db.dbo_Table_3.Find(id)
        db.dbo_Table_3.Remove(dbo_Table_3)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            db.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
