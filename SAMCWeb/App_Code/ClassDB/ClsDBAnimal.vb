Imports System
Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient

Public Class ClsDBAnimal

    Dim sb As StringBuilder
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter

    Public Function GetAnimalType(ByVal ANIMAL As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAnimalTypeList As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT * FROM samc_animaltype ")
                .Append("ORDER BY AnimalTypeName ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAnimalTypeList)

        Catch ex As Exception

        End Try

        Return DtAnimalTypeList

    End Function

    Public Function GetAnimalBreedList(ByVal ANIMAL As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAnimalBreedList As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT * ")
                .Append("FROM samc_breed ")

                If ANIMAL.AnimalTypeCode <> "" Then
                    .Append("WHERE AnimalTypeCode = '" & ANIMAL.AnimalTypeCode & "' ")
                End If

                .Append("ORDER BY BreedName ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAnimalBreedList)

        Catch ex As Exception

        End Try

        Return DtAnimalBreedList

    End Function

    Public Function GetAnimalStatus(ByVal ANIMAL As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAnimalStatusListing As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT * ")
                .Append("FROM samc_petstatus ")

                If ANIMAL.StatusCode <> "" Then
                    .Append("WHERE StatusCode = '" & ANIMAL.StatusCode & "' ")
                End If
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAnimalStatusListing)

        Catch ex As Exception

        End Try

        Return DtAnimalStatusListing

    End Function

    Public Function GetAnimalSexListing(ByVal ANIMAL As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAnimalSexListing As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT SexCode, SexName ")
                .Append("FROM samc_sex ")

                If ANIMAL.SexCode <> "" Then

                    .Append("WHERE SexCode = '" & ANIMAL.SexCode & "' ")

                End If
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAnimalSexListing)

        Catch ex As Exception

        End Try

        Return DtAnimalSexListing

    End Function

    Public Function ConcatAnimalTypeBreed(ByVal ANIMAL As ClsAnimal, ByRef DBConn As MySqlConnection) As DataTable

        Dim DtAnimalTypeBreed As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT a.AnimalCode, a.AnimalName, b.BreedCode, b.BreedName ")
                .Append("FROM samc_animal a ")
                .Append("INNER JOIN samc_breed b ON a.AnimalCode = b.AnimalCode ")
                .Append("WHERE a.AnimalCode = '" & ANIMAL.AnimalTypeCode & "' AND b.BreedCode = '" & ANIMAL.BreedCode & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtAnimalTypeBreed)

        Catch ex As Exception

        End Try

        Return DtAnimalTypeBreed

    End Function



End Class
