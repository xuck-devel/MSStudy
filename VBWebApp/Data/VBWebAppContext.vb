Imports System.Data.Entity

Namespace Data
    
    Public Class VBWebAppContext
        Inherits DbContext
    
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, please use data migrations.
        ' For more information refer to the documentation:
        ' http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        Public Sub New()
            MyBase.New("name=VBWebAppContext")
        End Sub

        Public Property dbo_Table_3 As System.Data.Entity.DbSet(Of dbo_Table_3)
    End Class
    
End Namespace
