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
Public Class WsGetAnimalBreed
    Inherits System.Web.Services.WebService

    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    <WebMethod()>
    Public Function GetBreed(ByVal AnimalTypeCode As String) As List(Of ListItem)

        Dim _ListOfAnimalBreed As New List(Of ListItem)()
        Dim DtAnimalBreed As New DataTable
        Dim ClsAnimal As New ClsAnimal

        Try
            ClsAnimal = New ClsAnimal
            With ClsAnimal
                .AnimalTypeCode = AnimalTypeCode
            End With

            DtAnimalBreed = ClsAnimal.GetAnimalBreed(ClsAnimal, DBConn)

            If DtAnimalBreed.Rows.Count > 0 Then

                For i As Integer = 0 To DtAnimalBreed.Rows.Count - 1

                    _ListOfAnimalBreed.Add(New ListItem() With {
                        .Value = DtAnimalBreed.Rows(i).Item("BreedCode").ToString,
                        .Text = DtAnimalBreed.Rows(i).Item("BreedName").ToString
                    })

                Next

            End If

        Catch ex As Exception

        End Try

        Return _ListOfAnimalBreed

    End Function

    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class