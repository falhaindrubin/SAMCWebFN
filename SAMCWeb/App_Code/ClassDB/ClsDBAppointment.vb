Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Text
Imports ModUtility

Public Class ClsDBAppointment

    Dim Sb As StringBuilder
    Dim Cmd As MySqlCommand
    Dim Da As MySqlDataAdapter

    Public Function AddNewAppointment(ByVal APP As ClsAppointment, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Dim ret As Integer

        Try
            Sb = New StringBuilder
            With Sb
                .Append("INSERT INTO samc_appointment ")
                .Append("(AppointmentID, EmpID, EmpName, CustomerID, CustomerName, AppointmentTime, ")
                .Append("CreatedBy, DateCreated, ModifiedBy, DateModified) ")
                .Append("VALUES ")
                .Append("(@AppointmentID, @EmpID, @EmpName, @CustomerID, @CustomerName, @AppointmentTime, ")
                .Append("@CreatedBy, @DateCreated, @ModifiedBy, @DateModified) ")
            End With

            Cmd = New MySqlCommand(Sb.ToString, DBConn, DBTrans)
            With Cmd.Parameters
                .AddWithValue("@AppointmentID", APP.AppointmentID)
                .AddWithValue("@EmpID", APP.EmpID)
                .AddWithValue("@EmpName", APP.EmpName)
                .AddWithValue("@CustomerID", APP.CustomerID)
                .AddWithValue("@CustomerName", APP.CustomerName)
                .AddWithValue("@AppointmentTime", APP.AppointmentTime)
                .AddWithValue("@CreatedBy", APP.Ref.CreatedBy)
                .AddWithValue("@DateCreated", APP.Ref.DateCreated)
                .AddWithValue("@ModifiedBy", APP.Ref.ModifiedBy)
                .AddWithValue("@DateModified", APP.Ref.DateModified)
            End With

            ret = Cmd.ExecuteNonQuery()

        Catch ex As Exception
            WriteErrLog("ClsDBAppointment.AddNewAppointment()", ex.Message)
            Return False
        End Try

        Return IIf(ret = 0, False, True)

    End Function

    Public Function AddNewAppointmentDetail(APPD As ClsAppointmentDetail, DBConn As MySqlConnection, DBTrans As MySqlTransaction) As Boolean

        Dim Ret As Integer

        Try
            sb = New StringBuilder
            With sb
                .Append("INSERT INTO samc_appointmentdetail ")
                .Append("(AppointmentID, PetID, PetName, PetDOB, SexCode, SexName, AnimalTypeCode, AnimalTypeName, BreedCode, BreedName, StatusCode, StatusName, AppointmentDesc, ")
                .Append("CreatedBy, DateCreated, ModifiedBy, DateModified) ")
                .Append("VALUES ")
                .Append("(@AppointmentID, @PetID, @PetName, @PetDOB, @SexCode, @SexName, @AnimalTypeCode, @AnimalTypeName, @BreedCode, ")
                .Append("@BreedName, @StatusCode, @StatusName, @AppointmentDesc, ")
                .Append("@CreatedBy, @DateCreated, @ModifiedBy, @DateModified) ")
            End With

            Cmd = New MySqlCommand(Sb.ToString, DBConn, DBTrans)
            With Cmd.Parameters
                .AddWithValue("@AppointmentID", APPD.AppointmentID)
                .AddWithValue("@PetID", APPD.PetID)
                .AddWithValue("@PetName", APPD.PetName)
                .AddWithValue("@PetDOB", APPD.PetDOB)
                .AddWithValue("@SexCode", APPD.SexCode)
                .AddWithValue("@SexName", APPD.SexName)
                .AddWithValue("@AnimalTypeCode", APPD.AnimalTypeCode)
                .AddWithValue("@AnimalTypeName", APPD.AnimalTypeName)
                .AddWithValue("@BreedCode", APPD.BreedCode)
                .AddWithValue("@BreedName", APPD.BreedName)
                .AddWithValue("@StatusCode", APPD.StatusCode)
                .AddWithValue("@StatusName", APPD.StatusName)
                .AddWithValue("@AppointmentDesc", APPD.AppointmentDesc)
                .AddWithValue("@CreatedBy", APPD.Ref.CreatedBy)
                .AddWithValue("@DateCreated", APPD.Ref.DateCreated)
                .AddWithValue("@ModifiedBy", APPD.Ref.ModifiedBy)
                .AddWithValue("@DateModified", APPD.Ref.DateModified)
            End With

            Ret = cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ClsDBAppointment.AddNewAppointmentDetail()")
        End Try

        Return IIf(Ret = 0, False, True)

    End Function

    Public Function CheckExistingAppointment(APP As ClsAppointment, DBConn As MySqlConnection) As DataTable

        Dim DtAppointment As New DataTable

        Try
            Sb = New StringBuilder
            With Sb
                .Append("SELECT AppointmentID, EmpID, EmpName, CustomerID, CustomerName,AppointmentTime, CreatedBy, DateCreated, ModifiedBy, DateModified ")
                .Append("FROM samc_appointment ")
                .Append("WHERE DATE(AppointmentTime) = DATE(@AppointmentTime) ")
                '.Append("WHERE CustomerID = @CustomerID AND DATE(AppointmentTime) = DATE(@AppointmentTime) ")
            End With

            Cmd = New MySqlCommand(Sb.ToString, DBConn)
            With Cmd.Parameters
                '.AddWithValue("@CustomerID", APP.CustomerID)
                .AddWithValue("@AppointmentTime", APP.AppointmentTime)
            End With

            Da = New MySqlDataAdapter(Cmd)
            Da.Fill(DtAppointment)

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "ClsDBAppointment.GetAppointmentListing()")
        End Try

        Return DtAppointment

    End Function

    Public Function GetAppointmentSummary(ByVal APP As ClsAppointment, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAppointment As New DataTable

        Try
            sb = New StringBuilder
            With Sb
                .Append("Select a.AppointmentID, a.AppointmentTime, EmpID, EmpName, CustomerID, CustomerName, ")
                .Append("PetID, PetName, PetDOB, SexCode, SexName, AnimalTypeCode, AnimalTypeName, BreedCode, BreedName, StatusCode, StatusName, AppointmentDesc AS 'PetIssue' ")
                .Append("FROM samc_appointment a ")
                .Append("INNER JOIN samc_appointmentdetail b ON a.AppointmentID = b.AppointmentID ")
                .Append("WHERE a.CustomerID = @CustomerID AND DATE(a.AppointmentTime) = DATE(@AppointmentTime) ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            With cmd.Parameters
                .AddWithValue("@CustomerID", APP.CustomerID)
                .AddWithValue("@AppointmentTime", APP.AppointmentTime)
            End With

            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAppointment)

        Catch ex As Exception
            WriteErrLog("ClsDBAppointment.GetAppointmentSummary()", ex.Message)
        End Try

        Return DtAppointment

    End Function

    'Public Function CheckExistingAppointment(ByVal APP As ClsAppointment, ByRef DBConn As MySqlConnection) As DataTable

    '    Dim DtAppointment As New DataTable

    '    Try
    '        sb = New StringBuilder
    '        With sb
    '            .Append("SELECT AppointmentID, EmpID, EmpName, CustomerID, CustomerName, PetID, PetName, AppointmentTime, AppointmentDesc, ")
    '            .Append("CreatedBy, DateCreated, ModifiedBy, DateModified ")
    '            .Append("FROM samc_appointment ")
    '            .Append("WHERE CustomerID = @CustomerID AND DATE(AppointmentTime) = DATE(@AppointmentTime) ")
    '        End With

    '        cmd = New MySqlCommand(sb.ToString, DBConn)
    '        With cmd.Parameters
    '            .AddWithValue("@CustomerID", APP.CustomerID)
    '            .AddWithValue("@AppointmentTime", APP.AppointmentTime)
    '        End With

    '        da = New MySqlDataAdapter(cmd)
    '        da.Fill(DtAppointment)

    '    Catch ex As Exception
    '        WriteErrLog("ClsDBAppointment.GetAppointmentSummary()", ex.Message)
    '    End Try

    '    Return DtAppointment

    'End Function

    Public Function GetAppointmentHistory(APP As ClsAppointment, DBConn As MySqlConnection) As DataTable

        Dim DtAppointment As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT AppointmentID, EmpID, EmpName, CustomerID, CustomerName, PetID, PetName, AppointmentTime, AppointmentDesc ")
                .Append("FROM samc_appointment ")
                .Append("WHERE CustomerID = @CustomerID ")
                .Append("ORDER BY AppointmentTime DESC ")
                .Append("LIMIT 5 ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            With cmd.Parameters
                .AddWithValue("@CustomerID", APP.CustomerID)
            End With

            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAppointment)

        Catch ex As Exception

        End Try

        Return DtAppointment

    End Function

End Class
