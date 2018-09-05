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
Public Class WsGetAnimalType
    Inherits System.Web.Services.WebService

    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    <WebMethod()>
    Public Function GetAnimalType() As List(Of ListItem)

        Dim _ListOfAnimalType As New List(Of ListItem)()
        Dim DtAnimalType As New DataTable
        Dim ClsAnimal As New ClsAnimal

        Try
            DtAnimalType = ClsAnimal.GetAnimalType(ClsAnimal, DBConn)
            If DtAnimalType.Rows.Count > 0 Then

                For i As Integer = 0 To DtAnimalType.Rows.Count - 1

                    _ListOfAnimalType.Add(New ListItem() With {
                        .Value = DtAnimalType.Rows(i).Item("AnimalCode").ToString,
                        .Text = DtAnimalType.Rows(i).Item("AnimalName").ToString
                    })

                Next

            End If

        Catch ex As Exception

        End Try

        Return _ListOfAnimalType

    End Function

    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class