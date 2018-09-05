Imports System.Data
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports MySql.Data.MySqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WsGetVet
    Inherits System.Web.Services.WebService

    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    <WebMethod()>
    Public Function GetVet() As List(Of ListItem)

        Dim _ListOfGetVet As New List(Of ListItem)()
        Dim DtVet As New DataTable
        Dim ClsEmployee As New ClsEmployee

        Try
            DtVet = ClsEmployee.GetVet(ClsEmployee, DBConn)
            If DtVet.Rows.Count > 0 Then

                For i As Integer = 0 To DtVet.Rows.Count - 1

                    _ListOfGetVet.Add(New ListItem() With {
                        .Value = DtVet.Rows(i).Item("EmpID").ToString,
                        .Text = DtVet.Rows(i).Item("EmpName").ToString
                    })

                Next

            End If

        Catch ex As Exception

        End Try

        Return _ListOfGetVet

    End Function

    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class