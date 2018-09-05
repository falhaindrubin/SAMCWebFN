Imports System.Data
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports MySql.Data.MySqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class WsGetCustomerInformation
    Inherits System.Web.Services.WebService

    Dim Obj As New ClsWsCustomerPetInfo
    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    <WebMethod()>
    Public Function GetCustomerInformation(ByVal CustomerQuery As String) As ClsWsCustomerPetInfo()

        Dim CustInfo As New List(Of ClsWsCustomerPetInfo)
        Dim DtCustomer As New DataTable
        Dim ClsCustomer As New ClsCustomer

        Try
            With ClsCustomer
                .CustomerID = UCase(Trim(CustomerQuery))
                .NRICPassportNo = UCase(Trim(CustomerQuery))
            End With

            DtCustomer = ClsCustomer.GetCustomerPetInfo(ClsCustomer, DBConn)

            If DtCustomer.Rows.Count > 0 Then
                For Each Row As DataRow In DtCustomer.Rows
                    Obj = New ClsWsCustomerPetInfo
                    With Obj
                        .CustomerID = Row("CustomerID").ToString
                        .SaluteCode = Row("SaluteCode").ToString
                        .SaluteName = Row("SaluteName").ToString
                        .CustomerName = Row("CustomerName").ToString
                        .NRICPassportNo = Row("NRICPassportNo").ToString
                        .AddressLine1 = Row("AddressLine1").ToString
                        .AddressLine2 = Row("AddressLine2").ToString
                        .AddressLine3 = Row("AddressLine3").ToString
                        .AddressLine4 = Row("AddressLine4").ToString
                        .TelNo = Row("TelNo").ToString
                        .MobileNo = Row("MobileNo").ToString
                        .Email = Row("Email").ToString
                        .PetID = Row("PetID").ToString
                        .PetName = Row("PetName").ToString
                        .PetDOB = Row("PetDOB").ToString
                        .AnimalTypeCode = Row("AnimalTypeCode").ToString
                        .AnimalTypeName = Row("AnimalTypeName").ToString
                        .BreedCode = Row("BreedCode").ToString
                        .BreedName = Row("BreedName").ToString
                        .SexCode = Row("SexCode").ToString
                        .SexName = Row("SexName").ToString
                        .StatusCode = Row("StatusCode").ToString
                        .StatusName = Row("StatusName").ToString
                    End With
                    CustInfo.Add(Obj)
                Next
            End If

        Catch ex As Exception

        End Try

        Return CustInfo.ToArray()

    End Function

    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

End Class