Imports System.Text
Imports System.Data
Imports MySql.Data.MySqlClient
Imports ModUtility

Public Class ClsDBPet

    Dim sb As StringBuilder
    Dim cmd As MySqlCommand
    Dim da As MySqlDataAdapter

    Public Function AddNewPet(ByVal PET As ClsPet, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Dim ret As Integer

        Try
            sb = New StringBuilder
            With sb
                .Append("INSERT INTO samc_pet ")
                .Append("(CustomerID, PetID, PetName, PetDOB, AnimalTypeCode, AnimalTypeName, BreedCode, BreedName, SexCode, SexName, StatusCode, StatusName, ")
                .Append("CreatedBy, DateCreated, ModifiedBy, DateModified) ")
                .Append("VALUES ")
                .Append("(@CustomerID, @PetID, @PetName, @PetDOB, @AnimalTypeCode, @AnimalTypeName, @BreedCode, @BreedName, @SexCode, @SexName, @StatusCode, @StatusName, ")
                .Append("@CreatedBy, @DateCreated, @ModifiedBy, @DateModified) ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            With cmd.Parameters
                .AddWithValue("@CustomerID", PET.CustomerID)
                .AddWithValue("@PetID", PET.PetID)
                .AddWithValue("@PetName", PET.PetName)
                .AddWithValue("@PetDOB", PET.PetDOB)
                .AddWithValue("@AnimalTypeCode", PET.AnimalTypeCode)
                .AddWithValue("@AnimalTypeName", PET.AnimalTypeName)
                .AddWithValue("@BreedCode", PET.BreedCode)
                .AddWithValue("@BreedName", PET.BreedName)
                .AddWithValue("@SexCode", PET.SexCode)
                .AddWithValue("@SexName", PET.SexName)
                .AddWithValue("@StatusCode", PET.StatusCode)
                .AddWithValue("@StatusName", PET.StatusName)
                .AddWithValue("@CreatedBy", PET.Ref.CreatedBy)
                .AddWithValue("@DateCreated", PET.Ref.DateCreated)
                .AddWithValue("@ModifiedBy", PET.Ref.ModifiedBy)
                .AddWithValue("@DateModified", PET.Ref.DateModified)
            End With

            ret = cmd.ExecuteNonQuery()

        Catch ex As Exception
            WriteErrLog("ClsDBCustomer.AddNewCustomer()", ex.Message)
            Return False
        End Try

        Return IIf(ret = 0, False, True)

    End Function

    Public Function UpdatePet(ByVal PET As ClsPet, ByRef DBConn As MySqlConnection, ByRef DBTrans As MySqlTransaction) As Boolean

        Try
            sb = New StringBuilder
            With sb
                .Append("INSERT INTO samc_pet ")
                .Append("(CustomerID, PetID, PetName, PetDOB, AnimalType, Breed, Sex, PetStatus, DateCreated, CreatedBy, DateModified, ModifiedBy) ")
                .Append("VALUES ")
                .Append("('" & PET.CustomerID & "', '" & PET.PetID & "', '" & PET.PetName & "', '" & CSQLDate(PET.PetDOB) & "', '" & PET.AnimalTypeCode & "', '" & PET.BreedCode & "', '" & PET.SexCode & "', ")
                .Append("'" & PET.StatusCode & "', '" & CSQLDateTime(PET.Ref.DateCreated) & "', '" & PET.Ref.CreatedBy & "', '" & CSQLDateTime(PET.Ref.DateModified) & "', '" & PET.Ref.ModifiedBy & "') ")
                .Append("ON DUPLICATE KEY UPDATE CustomerID = '" & PET.CustomerID & "', PetID = '" & PET.PetID & "' ")

                '.Append("UPDATE samc_pet ")
                '.Append("SET CustomerID = '" & PET.CustomerID & "', PetID = '" & PET.PetID & "', PetName = '" & PET.PetName & "', PetDOB = '" & PET.PetDOB & "', AnimalType = '" & PET.AnimalType & "', ")
                '.Append("Breed = '" & PET.Breed & "', Sex = '" & PET.Sex & "', PetStatus = '" & PET.PetStatus & "', DateModified = '" & PET.DateModified & "', ModifiedBy = '" & PET.ModifiedBy & "' ")
                '.Append("WHERE CustomerID = '" & PET.CustomerID & "' AND PetID = '" & PET.PetID & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn, DBTrans)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ClsDBPet.UpdatePet()")
        End Try

        Return True

    End Function

    Public Function GetPetListing(ByVal PET As ClsPet) As DataTable

        Dim DtPetListing As New DataTable

        Try
            sb = New StringBuilder
            With sb
                .Append("SELECT CustomerID, PetID, PetName, PetDOB, AnimalType, Breed, Sex, PetStatus, DateCreated, CreatedBy, DateModified, ModifiedBy ")
                .Append("FROM samc_pet ")
                .Append("WHERE CustomerID = '" & PET.CustomerID & "' ")
            End With

            cmd = New MySqlCommand(sb.ToString, DBConn)
            da = New MySqlDataAdapter(cmd)
            da.Fill(DtPetListing)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ClsDBPet.GetPetListing()")
        End Try

        Return DtPetListing

    End Function

End Class
