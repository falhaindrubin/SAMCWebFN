Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Text
Imports ModUtility

Public Class ClsDBCustomer

    Dim sb As StringBuilder
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter

    Public Function AddNewCustomer(ByVal CUSTOMER As ClsCustomer, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Dim ret As Integer

        Try
            sb = New StringBuilder
            With sb
                .Append("INSERT INTO samc_customer ")
                .Append("(CustomerID, SaluteCode, SaluteName, CustomerName, NRICPassportNo, AddressLine1, AddressLine2, AddressLine3, AddressLine4, TelNo, MobileNo, Email, ")
                .Append("CreatedBy, DateCreated, ModifiedBy, DateModified) ")
                .Append("VALUES ")
                .Append("(@CustomerID, @SaluteCode, @SaluteName, @CustomerName, @NRICPassportNo, @AddressLine1, @AddressLine2, @AddressLine3, @AddressLine4, ")
                .Append("@TelNo, @MobileNo, @Email, @CreatedBy, @DateCreated, @ModifiedBy, @DateModified) ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            With cmd.Parameters
                .AddWithValue("@CustomerID", CUSTOMER.CustomerID)
                .AddWithValue("@SaluteCode", CUSTOMER.SaluteCode)
                .AddWithValue("@SaluteName", CUSTOMER.SaluteName)
                .AddWithValue("@CustomerName", CUSTOMER.CustomerName)
                .AddWithValue("@NRICPassportNo", CUSTOMER.NRICPassportNo)
                .AddWithValue("@AddressLine1", CUSTOMER.AddressLine1)
                .AddWithValue("@AddressLine2", CUSTOMER.AddressLine2)
                .AddWithValue("@AddressLine3", CUSTOMER.AddressLine3)
                .AddWithValue("@AddressLine4", CUSTOMER.AddressLine4)
                .AddWithValue("@TelNo", CUSTOMER.TelNo)
                .AddWithValue("@MobileNo", CUSTOMER.MobileNo)
                .AddWithValue("@Email", CUSTOMER.Email)
                .AddWithValue("@CreatedBy", CUSTOMER.Ref.CreatedBy)
                .AddWithValue("@DateCreated", CUSTOMER.Ref.DateCreated)
                .AddWithValue("@ModifiedBy", CUSTOMER.Ref.ModifiedBy)
                .AddWithValue("@DateModified", CUSTOMER.Ref.DateModified)
            End With

            ret = cmd.ExecuteNonQuery()

        Catch ex As Exception
            WriteErrLog("ClsDBCustomer.AddNewCustomer()", ex.Message)
            Return False
        End Try

        Return IIf(ret = 0, False, True)

    End Function

    Public Function UpdateCustomer(ByVal CUSTOMER As ClsCustomer, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Try
            sb = New StringBuilder
            With sb
                .Append("UPDATE samc_customer ")
                .Append("SET Salutation = '" & CUSTOMER.Salutation & "', CustomerName = '" & CUSTOMER.CustomerName & "', NRICPassportNo = '" & CUSTOMER.NRICPassportNo & "', ")
                .Append("AddressLine1 = '" & CUSTOMER.AddressLine1 & "', AddressLine2 = '" & CUSTOMER.AddressLine2 & "', AddressLine3 = '" & CUSTOMER.AddressLine3 & "', AddressLine4 = '" & CUSTOMER.AddressLine4 & "', ")
                .Append("TelNo = '" & CUSTOMER.TelNo & "', MobileNo = '" & CUSTOMER.MobileNo & "', DateModified = '" & CUSTOMER.Ref.DateModified & "', ModifiedBy = '" & CUSTOMER.Ref.ModifiedBy & "' ")
                .Append("WHERE CustomerID = '" & CUSTOMER.CustomerID & "' AND NRICPassportNo = '" & CUSTOMER.NRICPassportNo & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ClsDBCustomer.UpdateCustomer()")
        End Try

        Return True

    End Function

    Public Function CheckExistingCustomer(ByVal CUSTOMER As ClsCustomer, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtCustomer As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT CustomerName, NRICPassportNo ")
                .Append("FROM samc_customer ")
                .Append("WHERE NRICPassportNo = @NRICPassportNo ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            With cmd.Parameters
                .AddWithValue("@NRICPassportNo", CUSTOMER.NRICPassportNo)
            End With

            da = New MySqlDataAdapter(cmd)
            da.Fill(DtCustomer)

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "ClsDBCustomer.CheckExistingCustomer()")
        End Try

        Return DtCustomer

    End Function

    Public Function GetCustomerListing(ByVal CUSTOMER As ClsCustomer) As DataTable

        Dim DtCustomerListing As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT * ")
                .Append("FROM samc_customer ")

                If CUSTOMER.CustomerID <> "" Then
                    .Append("WHERE CustomerID = '" & CUSTOMER.CustomerID & "' ")
                End If

            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtCustomerListing)

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "ClsDBCustomer.GetCustomerListing()")
        End Try

        Return DtCustomerListing

    End Function

    Public Function GetCustomerPetInfo(ByVal CUSTOMER As ClsCustomer, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtCustPetData As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT a.CustomerID, a.SaluteCode, a.SaluteName, CustomerName, NRICPassportNo, AddressLine1, AddressLine2, AddressLine3, AddressLine4, TelNo, MobileNo, Email, ")
                .Append("PetID, PetName, PetDOB, AnimalTypeCode, AnimalTypeName, BreedCode, BreedName, SexCode, SexName, StatusCode, StatusName ")
                .Append("FROM samc_customer a ")
                .Append("INNER JOIN samc_pet b ON a.CustomerID = b.CustomerID ")
                .Append("WHERE a.CustomerID = @CustomerID OR a.NRICPassportNo = @NRICPassportNo ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            With cmd.Parameters
                .AddWithValue("@CustomerID", CUSTOMER.CustomerID)
                .AddWithValue("@NRICPassportNo", CUSTOMER.NRICPassportNo)
            End With

            da = New MySqlDataAdapter(cmd)
            da.Fill(DtCustPetData)

        Catch ex As Exception
            WriteErrLog("ClsDBCustomer.GetCustomerPetInfo()", ex.Message)
        End Try

        Return DtCustPetData

    End Function

    Public Function GetSalutation(ByVal ClsCustomer As ClsCustomer, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtSalutation As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT SaluteCode, SaluteName ")
                .append("FROM samc_salutation ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtSalutation)

        Catch ex As Exception

        End Try

        Return DtSalutation

    End Function

End Class
