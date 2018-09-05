Imports System
Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class ClsDBEmployee

    Dim sb As StringBuilder
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter

    Public Function GetVet(ByVal EMPLOYEE As ClsEmployee, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtVet As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT * ")
                .Append("FROM samc_employee ")
                .Append("WHERE PositionCode = '01' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtVet)

        Catch ex As Exception

        End Try

        Return DtVet

    End Function

End Class
