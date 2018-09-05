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
Public Class WsGetAnimalSex
    Inherits System.Web.Services.WebService

    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    <WebMethod()>
    Public Function GetAnimalSex() As List(Of ListItem)

        Dim _ListOfPetSex As New List(Of ListItem)()
        Dim DtPetSex As New DataTable
        Dim ClsAnimal As New ClsAnimal

        Try
            DtPetSex = ClsAnimal.GetAnimalSex(ClsAnimal, DBConn)

            If DtPetSex.Rows.Count > 0 Then

                For i As Integer = 0 To DtPetSex.Rows.Count - 1

                    _ListOfPetSex.Add(New ListItem() With {
                        .Value = DtPetSex.Rows(i).Item("SexCode").ToString,
                        .Text = DtPetSex.Rows(i).Item("SexName").ToString
                    })

                Next

            End If

        Catch ex As Exception

        End Try

        Return _ListOfPetSex

    End Function

    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class