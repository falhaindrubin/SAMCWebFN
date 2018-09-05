Imports System.Globalization
Imports System.Text
Imports System.Data
Imports MySql.Data.MySqlClient
Imports ModUtility

Public Module ModMain

    Public DBConn As New MySqlConnection
    Public DBTrans As MySqlTransaction

    'Database credentials
    Public SERVER As String
    Public DATABASE As String
    Public PORT As String
    Public UID As String
    Public PWD As String
    Public CURR_USER As String

    Dim sb As StringBuilder
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter

    'Database connection
    Public Function ConnectToDB() As Boolean

        Try
            SERVER = "localhost"
            DATABASE = "samc_db"
            PORT = "3306"
            UID = "root"
            PWD = "root"

            DBConn.ConnectionString =
                "DRIVER={MySQL ODBC 8.0 UNICODE Driver};" &
                "SERVER=" & SERVER & ";" &
                "PORT=" & PORT & ";" &
                "DATABASE=" & DATABASE & ";" &
                "USER=" & UID & ";" &
                "PASSWORD=" & PWD & ";"

            DBConn.Open()

        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
            Return False
        End Try

        Return True

    End Function

    Public Function GenerateRunningNo(ByVal Prefix As String, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As String

        Dim NewRunningNo As String = ""
        Dim RunningNo As Integer
        Dim DtRunningNo As New DataTable

        Try
            'Get last customer no
            sb = New StringBuilder
            With sb
                .Append("SELECT LastNo FROM samc_runningno WHERE Prefix = '" & Prefix & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtRunningNo)

            If DtRunningNo.Rows.Count > 0 Then

                Dim LastNo As Integer
                Dim ZeroPadLength As Integer

                LastNo = CInt(DtRunningNo.Rows(0).Item("LastNo"))
                RunningNo = LastNo + 1
                ZeroPadLength = 6 - RunningNo.ToString.Length

                If RunningNo.ToString.Length < 8 Then
                    NewRunningNo = Prefix & RunningNo.ToString.PadLeft(8, "0"c)
                Else
                    NewRunningNo = Prefix & RunningNo.ToString
                End If

                'Update ClientNo
                sb = New StringBuilder
                With sb
                    .Append("UPDATE samc_runningno ")
                    .Append("SET LastNo = '" & RunningNo & "' ")
                    .Append("WHERE Prefix = '" & Prefix & "' ")
                End With

                cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
                cmd.ExecuteNonQuery()

            Else
                MsgBox("Failed to generate running number [" & Prefix & "].", MsgBoxStyle.Critical, "ModMain.GenerateRunningNo()")
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "ModMain.GenerateRunningNo()")
        End Try

        Return NewRunningNo

    End Function

    Public Function ResetPetIDRunningNo(ByVal Prefix As String, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Try
            'Reset Pet ID
            If Prefix <> "PT" Then
                Return False
            End If

            sb = New StringBuilder
            With sb
                .Append("UPDATE samc_runningno ")
                .Append("SET LastNo = '0' ")
                .Append("WHERE Prefix = '" & Prefix & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Return False
            WriteErrLog("ModMain.ResetPetIDRunningNo()", ex.Message)
        End Try

        Return True

    End Function

End Module
