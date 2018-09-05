Imports System.Data
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports ModUtility

Partial Class Appointment
    Inherits Page

    Private _UserCommand As String
    Public Property UserCommand As String
        Get
            Return _UserCommand
        End Get
        Set(value As String)
            _UserCommand = value
        End Set
    End Property

    Dim DBConn As New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            DivShowHideAppointment.Visible = False
            DivAppointmentSummary.Visible = False
            'DivSearchResult.Visible = False

        End If

    End Sub

    Protected Sub AddPet()

        'Dim ClsPet As New ClsPet
        'Dim DtPet As New DataTable
        'Dim SelectedRowIndex As Integer

        'Try
        '    'Optional ByVal RowIndex As Integer = Nothing, Optional ByVal IsRowCommand As Boolean = False

        '    'Initialize datatable
        '    With DtPet
        '        .Columns.Add("PetID", GetType(String))
        '        .Columns.Add("PetName", GetType(String))
        '        .Columns.Add("SexCode", GetType(String))
        '        .Columns.Add("SexName", GetType(String))
        '        .Columns.Add("PetDOB", GetType(String))
        '        .Columns.Add("AnimalTypeCode", GetType(String))
        '        .Columns.Add("AnimalTypeName", GetType(String))
        '        .Columns.Add("BreedCode", GetType(String))
        '        .Columns.Add("BreedName", GetType(String))
        '        .Columns.Add("StatusCode", GetType(String))
        '        .Columns.Add("StatusName", GetType(String))
        '        .Columns.Add("PetIssue", GetType(String))
        '    End With

        '    If Trim(LblSelectedRowIndex.Text) <> "" Then
        '        SelectedRowIndex = CInt(LblSelectedRowIndex.Text)
        '    Else
        '        SelectedRowIndex = -1
        '    End If

        '    If GvSelectedPet.Rows.Count > 0 Then

        '        For Each Row As GridViewRow In GvSelectedPet.Rows

        '            Dim DataRow As DataRow = DtPet.NewRow

        '            DataRow("PetID") = GvSelectedPet.DataKeys(Row.RowIndex).Values(0).ToString()
        '            DataRow("PetName") = Row.Cells(0).Text
        '            DataRow("SexCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(4).ToString()
        '            DataRow("SexName") = Row.Cells(1).Text
        '            DataRow("PetDOB") = Row.Cells(2).Text
        '            DataRow("AnimalTypeCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(1).ToString()
        '            DataRow("AnimalTypeName") = Row.Cells(3).Text
        '            DataRow("BreedCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(2).ToString()
        '            DataRow("BreedName") = Row.Cells(4).Text
        '            DataRow("StatusCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(3).ToString()
        '            DataRow("StatusName") = Row.Cells(5).Text
        '            DataRow("PetIssue") = Row.Cells(6).Text

        '            DtPet.Rows.Add(DataRow)

        '        Next

        '    End If

        '    Dim DataRowPetID As String
        '    Dim NewDataRow As DataRow = DtPet.NewRow

        '    If SelectedRowIndex <> -1 Then
        '        DataRowPetID = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(0).ToString()
        '    Else
        '        DataRowPetID = ""
        '    End If

        '    If IsRowCommand = True Then

        '        ' DataKeyNames="PetID,AnimalTypeCode,BreedCode,SexCode,StatusCode"
        '        Dim PetID As String = GvRegisteredPet.DataKeys(RowIndex).Values(0).ToString
        '        Dim PetName As String = GvRegisteredPet.Rows(RowIndex).Cells(1).Text
        '        Dim SexCode As String = GvRegisteredPet.DataKeys(RowIndex).Values(3).ToString
        '        Dim SexName As String = GvRegisteredPet.Rows(RowIndex).Cells(5).Text
        '        Dim PetDOB As Date = CDate(GvRegisteredPet.Rows(RowIndex).Cells(2).Text).Date
        '        Dim AnimalTypeCode As String = GvRegisteredPet.DataKeys(RowIndex).Values(1).ToString
        '        Dim AnimalTypeName As String = GvRegisteredPet.Rows(RowIndex).Cells(3).Text
        '        Dim BreedCode As String = GvRegisteredPet.DataKeys(RowIndex).Values(2).ToString
        '        Dim BreedName As String = GvRegisteredPet.Rows(RowIndex).Cells(4).Text
        '        Dim StatusCode As String = GvRegisteredPet.DataKeys(RowIndex).Values(4).ToString
        '        Dim StatusName As String = GvRegisteredPet.Rows(RowIndex).Cells(6).Text
        '        Dim PetIssue As String = Trim(TxtAppointmentDescription.Text)

        '        NewDataRow("PetID") = DataRowPetID
        '        NewDataRow("PetName") = UCase(Trim(PetName))
        '        NewDataRow("SexCode") = SexCode
        '        NewDataRow("SexName") = UCase(Trim(SexName))
        '        NewDataRow("PetDOB") = UCase(Trim(PetDOB))
        '        NewDataRow("AnimalTypeCode") = AnimalTypeCode
        '        NewDataRow("AnimalTypeName") = AnimalTypeName
        '        NewDataRow("BreedCode") = BreedCode
        '        NewDataRow("BreedName") = UCase(Trim(BreedName))
        '        NewDataRow("StatusCode") = StatusCode
        '        NewDataRow("StatusName") = UCase(Trim(StatusName))
        '        NewDataRow("PetIssue") = Trim(TxtAppointmentDescription.Text)

        '    Else

        '        NewDataRow("PetID") = DataRowPetID
        '        NewDataRow("PetName") = UCase(Trim(TxtPetName.Text))
        '        NewDataRow("SexCode") = DdlSex.SelectedValue
        '        NewDataRow("SexName") = DdlSex.SelectedItem
        '        NewDataRow("PetDOB") = UCase(Trim(TxtDOB.Text))
        '        NewDataRow("AnimalTypeCode") = DdlAnimalType.SelectedValue
        '        NewDataRow("AnimalTypeName") = DdlAnimalType.SelectedItem
        '        NewDataRow("BreedCode") = DdlBreed.SelectedValue
        '        NewDataRow("BreedName") = DdlBreed.SelectedItem
        '        NewDataRow("StatusCode") = DdlStatus.SelectedValue
        '        NewDataRow("StatusName") = DdlStatus.SelectedItem
        '        NewDataRow("PetIssue") = Trim(TxtAppointmentDescription.Text)

        '    End If

        '    DtPet.Rows.Add(NewDataRow)

        '    With GvSelectedPet
        '        .DataSource = DtPet
        '        .DataBind()
        '    End With

        '    If TrSelectedPet.Visible = False Then
        '        TrSelectedPet.Visible = True
        '    End If

        '    'Clear fields after adding pets, reset everything back to none
        '    ClearSetFields("FINISH_ADD_PETS")

        'Catch ex As Exception
        '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddPet()", JSMsgDisplay(ex.Message))
        'End Try

    End Sub

    Protected Sub ClearSetFields(ByVal FieldCommand As String)

        Try
            'COMMANDS
            '1. FINISH_ADD_PETS
            '2. CLEAR_SEARCH_CUSTOMER
            '3. REGISTER_NEW_CUSTOMER

            Select Case FieldCommand

                Case "CLOSE_APPOINTMENT_SUMMARY"

                    TxtSearchCustomer.Text = ""

                Case "UPDATE_PET_CHANGES"

                    TxtPetName.Text = ""
                    TxtDOB.Text = ""
                    TxtAppointmentDescription.Text = ""

                    If HfNewUser.Value <> "1" Then

                        TxtSex.Text = ""
                        TxtAnimalType.Text = ""
                        TxtBreed.Text = ""
                        TxtStatus.Text = ""

                    Else

                        DdlAnimalType.SelectedValue = ""
                        DdlBreed.SelectedValue = ""
                        DdlSex.SelectedValue = ""
                        DdlStatus.SelectedValue = ""

                    End If

                    BtnAddPet.Visible = True
                    BtnUpdatePet.Visible = False
                    BtnDiscardChanges.Visible = False

                Case "DISCARD_PET_CHANGES"

                    TxtPetName.Text = ""
                    TxtDOB.Text = ""
                    TxtAppointmentDescription.Text = ""

                    If HfNewUser.Value <> "1" Then

                        TxtSex.Text = ""
                        TxtAnimalType.Text = ""
                        TxtBreed.Text = ""
                        TxtStatus.Text = ""

                    Else

                        DdlAnimalType.SelectedValue = ""
                        DdlBreed.SelectedValue = ""
                        DdlSex.SelectedValue = ""
                        DdlStatus.SelectedValue = ""

                    End If

                    BtnAddPet.Visible = True
                    BtnUpdatePet.Visible = False
                    BtnDiscardChanges.Visible = False

                Case "SELECT_EDIT"

                    BtnAddPet.Visible = False
                    BtnClearSelectedPet.Visible = False
                    BtnUpdatePet.Visible = True
                    BtnDiscardChanges.Visible = True

                Case "SELECT_DELETE"

                    TxtPetName.Text = ""
                    TxtDOB.Text = ""
                    TxtAppointmentDescription.Text = ""

                    If HfNewUser.Value <> "1" Then

                        DdlAnimalType.SelectedValue = ""
                        DdlBreed.SelectedValue = ""
                        DdlSex.SelectedValue = ""
                        DdlStatus.SelectedValue = ""

                    Else

                        TxtAnimalType.Text = ""
                        TxtBreed.Text = ""
                        TxtSex.Text = ""
                        TxtStatus.Text = ""

                    End If

                    BtnAddPet.Visible = True
                    BtnClearSelectedPet.Visible = True
                    BtnUpdatePet.Visible = False
                    BtnDiscardChanges.Visible = False

                    If GvSelectedPet.Rows.Count > 0 Then
                        TrSelectedPet.Visible = True
                    Else
                        TrSelectedPet.Visible = False
                    End If


                Case "FINISH_ADD_PETS"

                    TxtPetName.Text = ""
                    TxtAnimalType.Text = ""
                    TxtBreed.Text = ""
                    TxtDOB.Text = ""
                    TxtSex.Text = ""
                    TxtStatus.Text = ""
                    TxtAppointmentDescription.Text = ""

                    DdlAnimalType.SelectedValue = ""
                    DdlBreed.SelectedValue = ""
                    DdlSex.SelectedValue = ""
                    DdlStatus.SelectedValue = ""

                Case "CLEAR_SEARCH_CUSTOMER"

                    HfNewUser.Value = "0"

                    DivSearchResult.Visible = False

                    TxtSearchCustomer.Text = ""

                    LblCustomerID.Text = ""
                    LblCustomerName.Text = ""
                    LblNRICPassportNo.Text = ""

                    'GvPetsInformation.DataSource = Nothing
                    GvAppointmentSummary.DataSource = Nothing

                    If DivShowHideAppointment.Visible = True Then
                        DivShowHideAppointment.Visible = False
                    End If

                    If DivAppointmentSummary.Visible = True Then
                        DivAppointmentSummary.Visible = False
                    End If

                Case "REGISTER_NEW_CUSTOMER"

                    HfNewUser.Value = "1"

                    If DivSearchResult.Visible = True Then
                        DivSearchResult.Visible = False
                    End If

                    If DivShowHideAppointment.Visible = False Then
                        DivShowHideAppointment.Visible = True
                    End If

                    TrRegisteredPet.Visible = False
                    TrSelectedPet.Visible = False

                    DdlSalutation.SelectedValue = ""
                    TxtCustomerName.Text = ""
                    TxtNRICPassportNo.Text = ""
                    TxtTelNo.Text = ""
                    TxtMobileNo.Text = ""
                    TxtEmail.Text = ""
                    TxtAddressLine1.Text = ""
                    TxtAddressLine2.Text = ""
                    TxtAddressLine3.Text = ""
                    TxtAddressLine4.Text = ""
                    TxtPetName.Text = ""

                    DdlSalutation.Visible = True
                    TxtSalutation.Visible = False
                    TxtCustomerName.Attributes.Remove("readonly")
                    TxtNRICPassportNo.Attributes.Remove("readonly")
                    TxtTelNo.Attributes.Remove("readonly")
                    TxtMobileNo.Attributes.Remove("readonly")
                    TxtEmail.Attributes.Remove("readonly")
                    TxtAddressLine1.Attributes.Remove("readonly")
                    TxtAddressLine2.Attributes.Remove("readonly")
                    TxtAddressLine3.Attributes.Remove("readonly")
                    TxtAddressLine4.Attributes.Remove("readonly")

                    TxtPetName.Attributes.Remove("readonly")
                    TxtAnimalType.Attributes.Remove("readonly")
                    TxtBreed.Attributes.Remove("readonly")
                    TxtSex.Attributes.Remove("readonly")
                    TxtStatus.Attributes.Remove("readonly")
                    TxtDOB.Attributes.Remove("disabled")
                    TxtDOB.Enabled = True

                    DdlAnimalType.Visible = True
                    DdlBreed.Visible = True
                    DdlSex.Visible = True
                    DdlStatus.Visible = True

                    TxtAnimalType.Visible = False
                    TxtBreed.Visible = False
                    TxtSex.Visible = False
                    TxtStatus.Visible = False

                    DivShowHideAppointment.Visible = True
                    DivCustomerInformation.Visible = True
                    DivPetInformation.Visible = True
                    DivAppointmentDetails.Visible = True

                Case "SHOW_APPOINTMENT_SUMMARY"

                    GvSelectedPet.DataSource = Nothing
                    GvSelectedPet.DataBind()

                    If DivAppointmentSummary.Visible = False Then
                        DivAppointmentSummary.Visible = True
                    End If

                Case "CREATE_APPOINTMENT"

                    'Customer Information
                    TxtSalutation.Text = DdlSalutation.SelectedItem.ToString
                    HfSaluteCode.Value = DdlSalutation.SelectedValue

                    TxtSalutation.Visible = True
                    DdlSalutation.Visible = False

                    TxtSalutation.Attributes.Add("readonly", "readonly")
                    TxtCustomerName.Attributes.Add("readonly", "readonly")
                    TxtNRICPassportNo.Attributes.Add("readonly", "readonly")
                    TxtTelNo.Attributes.Add("readonly", "readonly")
                    TxtMobileNo.Attributes.Add("readonly", "readonly")
                    TxtEmail.Attributes.Add("readonly", "readonly")
                    TxtAddressLine1.Attributes.Add("readonly", "readonly")
                    TxtAddressLine2.Attributes.Add("readonly", "readonly")
                    TxtAddressLine3.Attributes.Add("readonly", "readonly")
                    TxtAddressLine4.Attributes.Add("readonly", "readonly")

                    'Hide fields for pet information that is used for new user
                    'HfAnimalType.Value = DdlAnimalType.SelectedValue
                    'HfBreed.Value = DdlBreed.SelectedValue
                    'HfSex.Value = DdlSex.SelectedValue
                    'HfStatus.Value = DdlStatus.SelectedValue

                    TxtAnimalType.Visible = True
                    TxtBreed.Visible = True
                    TxtSex.Visible = True
                    TxtStatus.Visible = True

                    TxtPetName.Attributes.Add("readonly", "readonly")
                    TxtDOB.Attributes.Add("readonly", "readonly")
                    TxtDOB.Attributes.Add("disabled", "disabled")
                    TxtAnimalType.Attributes.Add("readonly", "readonly")
                    TxtBreed.Attributes.Add("readonly", "readonly")
                    TxtSex.Attributes.Add("readonly", "readonly")
                    TxtStatus.Attributes.Add("readonly", "readonly")

                    DdlAnimalType.Visible = False
                    DdlBreed.Visible = False
                    DdlSex.Visible = False
                    DdlStatus.Visible = False

                    TrRegisteredPet.Visible = True

                    DivShowHideAppointment.Visible = True
                    DivCustomerInformation.Visible = True
                    DivPetInformation.Visible = True
                    DivAppointmentDetails.Visible = True

                Case "CANCEL_APPOINTMENT"

                    HfNewUser.Value = "0"

                    'DivSearchCustomer
                    TxtSearchCustomer.Text = ""

                    'DivSearchResult
                    LblRecordCount.Text = ""
                    LblCustomerID.Text = ""
                    LblCustomerName.Text = ""
                    LblNRICPassportNo.Text = ""
                    'GvPetsInformation.DataSource = Nothing
                    'GvPetsInformation.DataBind()

                    'DivCustomerInformation
                    DdlSalutation.SelectedValue = ""
                    TxtSalutation.Text = ""
                    TxtCustomerName.Text = ""
                    TxtNRICPassportNo.Text = ""
                    TxtTelNo.Text = ""
                    TxtMobileNo.Text = ""
                    TxtEmail.Text = ""
                    TxtAddressLine1.Text = ""
                    TxtAddressLine2.Text = ""
                    TxtAddressLine3.Text = ""
                    TxtAddressLine4.Text = ""

                    'DivPetInformation
                    GvRegisteredPet.DataSource = Nothing
                    GvRegisteredPet.DataBind()
                    DdlAnimalType.SelectedValue = ""
                    DdlBreed.SelectedValue = ""
                    DdlSex.SelectedValue = ""
                    DdlStatus.SelectedValue = ""
                    TxtPetName.Text = ""
                    TxtAnimalType.Text = ""
                    TxtBreed.Text = ""
                    TxtDOB.Text = ""
                    TxtSex.Text = ""
                    TxtStatus.Text = ""
                    TxtAppointmentDescription.Text = ""
                    GvSelectedPet.DataSource = Nothing
                    GvSelectedPet.DataBind()

                    'DivAppointmentDetails
                    DdlVet.SelectedValue = ""
                    TxtAppointmentTime.Text = ""

                    DivSearchResult.Visible = False
                    DivCustomerInformation.Visible = False
                    DivPetInformation.Visible = False
                    DivAppointmentDetails.Visible = False

                Case "CLEAR_SELECTED_PET"

                    If HfIsRowCommand.Value = "1" Then

                        TxtPetName.Text = ""
                        TxtAnimalType.Text = ""
                        TxtBreed.Text = ""
                        TxtDOB.Text = ""
                        TxtSex.Text = ""
                        TxtStatus.Text = ""
                        TxtAppointmentDescription.Text = ""

                        'If GvSelectedPet.Rows.Count > 0 Then
                        '    GvSelectedPet.DataSource = Nothing
                        '    GvSelectedPet.DataBind()
                        'End If

                    Else

                        TxtPetName.Text = ""
                        DdlAnimalType.SelectedValue = ""
                        DdlBreed.SelectedValue = ""
                        TxtDOB.Text = ""
                        DdlSex.SelectedValue = ""
                        DdlStatus.SelectedValue = ""
                        TxtAppointmentDescription.Text = ""

                    End If


            End Select

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub SearchCustomer()

        Dim ClsCustomer As New ClsCustomer
        Dim ClsAppointment As New ClsAppointment
        Dim DtCustPetDataDB As New DataTable
        Dim DtAppointmentHistory As New DataTable
        'Dim Message As String

        Try
            If DivShowHideAppointment.Visible = True Then
                DivShowHideAppointment.Visible = False
            End If

            With ClsCustomer
                .CustomerID = UCase(Trim(TxtSearchCustomer.Text))
                .NRICPassportNo = UCase(Trim(TxtSearchCustomer.Text))
            End With

            DtCustPetDataDB = ClsCustomer.GetCustomerPetInfo(ClsCustomer, DBConn)

            If DtCustPetDataDB.Rows.Count > 0 Then

                With ClsAppointment
                    .CustomerID = CStr(DtCustPetDataDB.Rows(0).Item("CustomerID"))
                End With

                DtAppointmentHistory = ClsAppointment.GetAppointmentHistory(ClsAppointment, DBConn)

                If DtAppointmentHistory.Rows.Count > 0 Then

                    GvAppointmentHistory.DataSource = DtAppointmentHistory
                    GvAppointmentHistory.DataBind()

                End If

                LblCustomerID.Text = DtCustPetDataDB.Rows(0).Item("CustomerID")
                LblCustomerName.Text = DtCustPetDataDB.Rows(0).Item("CustomerName")
                LblNRICPassportNo.Text = DtCustPetDataDB.Rows(0).Item("NRICPassportNo")

                'GvPetsInformation.DataSource = DtCustPetDataDB
                'GvPetsInformation.DataBind()

                LblRecordCount.Text = DtCustPetDataDB.Rows.Count & " record(s) found."
                DivSearchResult.Visible = True
                LblRecordCount.Visible = True
                'TblSearchResult.Visible = True
                BtnAddAppointment.Visible = True
                BtnRegisterNewCustomer.Visible = False

            Else

                'If GvPetsInformation.Rows.Count > 0 Then
                '    GvPetsInformation.DataSource = Nothing
                '    GvPetsInformation.DataBind()
                'End If

                LblRecordCount.Text = DtCustPetDataDB.Rows.Count & " record(s) found."
                LblRecordCount.Visible = True
                'TblSearchResult.Visible = False
                DivSearchResult.Visible = True
                BtnAddAppointment.Visible = False
                BtnRegisterNewCustomer.Visible = True

                'Message = DtCustPetDataDB.Rows.Count & " record(s) found."
                'ClientScript.RegisterStartupScript(Me.GetType(), "SearchCustomer()", JSMsgDisplay(Message))

            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "SearchCustomer()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub ClearSearchCustomer()
        ClearSetFields("CLEAR_SEARCH_CUSTOMER")
    End Sub

    Protected Sub PopulateFields()
        PopulateSalutation()
        PopulateAnimalType()
        PopulateBreed()
        PopulateSex()
        PopulatePetStatus()
        PopulateVet()
    End Sub

    Protected Sub CreateAppointment()

        Dim ClsCustomer As New ClsCustomer
        Dim DtCustPetDataDB As New DataTable
        Dim DtIsUserExist As New DataTable
        'Dim Message As String

        Try
            PopulateFields()

            With ClsCustomer
                .CustomerID = UCase(Trim(LblCustomerID.Text))
                .NRICPassportNo = UCase(Trim(LblNRICPassportNo.Text))
            End With

            If DivShowHideAppointment.Visible = False Then
                DivShowHideAppointment.Visible = True
            End If

            If DtCustPetDataDB.Rows.Count = 0 Then
                DtCustPetDataDB = ClsCustomer.GetCustomerPetInfo(ClsCustomer, DBConn)
            End If

            If DtCustPetDataDB.Rows.Count > 0 Then

                'Fill blanks customer with customer information
                DdlSalutation.SelectedValue = CStr(DtCustPetDataDB.Rows(0).Item("SaluteCode"))
                TxtCustomerName.Text = CStr(DtCustPetDataDB.Rows(0).Item("CustomerName"))
                TxtNRICPassportNo.Text = CStr(DtCustPetDataDB.Rows(0).Item("NRICPassportNo"))
                TxtTelNo.Text = CStr(DtCustPetDataDB.Rows(0).Item("TelNo"))
                TxtMobileNo.Text = CStr(DtCustPetDataDB.Rows(0).Item("MobileNo"))
                TxtEmail.Text = CStr(DtCustPetDataDB.Rows(0).Item("Email"))

                TxtAddressLine1.Text = CStr(DtCustPetDataDB.Rows(0).Item("AddressLine1"))
                TxtAddressLine2.Text = CStr(DtCustPetDataDB.Rows(0).Item("AddressLine2"))
                TxtAddressLine3.Text = CStr(DtCustPetDataDB.Rows(0).Item("AddressLine3"))
                TxtAddressLine4.Text = CStr(DtCustPetDataDB.Rows(0).Item("AddressLine4"))

                GvRegisteredPet.DataSource = DtCustPetDataDB
                GvRegisteredPet.DataBind()

                ClearSetFields("CREATE_APPOINTMENT")

            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "CreateAppointment()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub SubmitAppointment()

        Try
            UserCommand = "SUBMIT_APPOINTMENT"
            If Not CheckValidEntry(UserCommand) Then Exit Sub

            If HfNewUser.Value = "1" Then
                If Not AddNewUser() Then Exit Sub
            Else
                If Not AddNewAppointment() Then Exit Sub
            End If

            ClearSetFields("SHOW_APPOINTMENT_SUMMARY")
            ShowAppointmentSummary()

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "SubmitAppointment()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Function CheckValidEntry(Optional UserCommand As String = Nothing) As Boolean

        Dim Message As String = ""

        Try
            'If GvSelectedPet.Rows.Count > 0 Then
            '    GoTo CHECK_SUBMIT_VALIDITY
            'End If

            Select Case UserCommand
                'Case "ADD_PET"
                '    If GvSelectedPet.Rows.Count = 0 Then
                '        Message = "No pet(s) selected for the appointment. Pleas select your pet or add new pet for the appointment."
                '        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                '        Return False
                '    End If

                Case "SUBMIT_APPOINTMENT"

                    If DdlVet.SelectedValue = "" Then
                        Message = "Please select vet."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    If Trim(TxtAppointmentTime.Text) = "" Then
                        Message = "Please select date and time for your appointment."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False

                    ElseIf Trim(TxtAppointmentTime.Text) <> "" Then

                        Dim AppointmentTime As DateTime
                        Dim EmpID As String
                        Dim DtAppointment As New DataTable
                        Dim ClsAppointment As New ClsAppointment

                        If LblCustomerID.Text <> "" Then

                            AppointmentTime = DateTime.ParseExact(Trim(TxtAppointmentTime.Text), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                            EmpID = UCase(Trim(DdlVet.SelectedValue))

                            With ClsAppointment
                                '.CustomerID = Trim(LblCustomerID.Text)
                                .AppointmentTime = AppointmentTime
                            End With

                            DtAppointment = ClsAppointment.CheckExistingAppointment(ClsAppointment, DBConn)
                            If DtAppointment.Rows.Count > 0 Then

                                If LblCustomerID.Text = DtAppointment.Rows(0).Item("CustomerID") And AppointmentTime.Date = CDate(DtAppointment.Rows(0).Item("AppointmentTime")).Date Then

                                    'MsgBox("You already have an appointment for the selected date.", MsgBoxStyle.Exclamation, "Appointment Already Created")
                                    Message = "You already have an appointment for the selected date."
                                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                                    Return False

                                ElseIf EmpID = DtAppointment.Rows(0).Item("EmpID") And AppointmentTime = DtAppointment.Rows(0).Item("AppointmentTime") Then

                                    'MsgBox("The selected vet is not available for appointment. Please select other date and time.", MsgBoxStyle.Exclamation, "Vet Not Available")
                                    Message = "You already have an appointment for the selected date."
                                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                                    Return False

                                End If

                            End If

                        End If

                    End If

                    Return True

            End Select

            'Check if user trying to add pet with insufficient pet information
            If HfNewUser.Value = "1" Then
                If TxtPetName.Text = "" Then
                    Message = "Please enter your pet's name."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If DdlAnimalType.SelectedValue = "" Then
                    Message = "Please select your pet animal type."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If DdlBreed.SelectedValue = "" Then
                    Message = "Please select your pet breed."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If TxtDOB.Text = "" Then
                    Message = "Please select your pet date of birth."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If DdlSex.SelectedValue = "" Then
                    Message = "Please select your pet sex."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If DdlStatus.SelectedValue = "" Then
                    Message = "Please select your pet status."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                If TxtAppointmentDescription.Text = "" Then
                    Message = "Please describe your pet issue."
                    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    Return False
                End If

                Return True

            ElseIf HfNewUser.Value = "" Then

                If HfNewUser.Value = "" Then
                    If TxtPetName.Text = "" Then
                        Message = "Please enter your pet's name."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    If TxtAnimalType.Text = "" Then
                        Message = "Please select your pet animal type."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    If TxtBreed.Text = "" Then
                        Message = "Please select your pet breed."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    'If TxtDOB.Text = "" Then
                    '    Message = "Please select your pet date of birth."
                    '    ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                    '    Return False
                    'End If

                    If TxtSex.Text = "" Then
                        Message = "Please select your pet sex."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    If TxtStatus.Text = "" Then
                        Message = "Please select your pet status."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    If TxtAppointmentDescription.Text = "" Then
                        Message = "Please describe your pet issue."
                        ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
                        Return False
                    End If

                    Return True

                End If

            End If

            'CHECK_SUBMIT_VALIDITY:

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "CheckValidEntry()", JSMsgDisplay(Message))
            Return False
        End Try

        Return True

    End Function

    Protected Sub CancelAppointment()
        ClearSetFields("CANCEL_APPOINTMENT")
    End Sub

    Protected Function AddNewUser() As Boolean

        Dim ClsCustomer As New ClsCustomer
        Dim ClsPet As New ClsPet
        Dim DtPet As New DataTable
        Dim DBTrans As MySqlTransaction = Nothing

        Try
            If DBConn.State = ConnectionState.Closed Then DBConn.Open()
            If DBTrans IsNot Nothing Then DBTrans = Nothing

            DBTrans = DBConn.BeginTransaction

            'Create CustomerID
            Dim GenCustomerID As String
            GenCustomerID = GenerateRunningNo("CT", DBConn, DBTrans)

            If GenCustomerID = "" Then Throw New Exception("Failed to generate customer ID.")

            'Store generated Customer ID somewhere to be fetch later on during loading appointment summary
            HfCustomerID.Value = GenCustomerID

            With ClsCustomer
                .CustomerID = GenCustomerID
                .SaluteCode = DdlSalutation.SelectedValue
                .SaluteName = DdlSalutation.SelectedItem.ToString
                .CustomerName = UCase(Trim(TxtCustomerName.Text))
                .NRICPassportNo = UCase(Trim(TxtNRICPassportNo.Text))
                .AddressLine1 = UCase(Trim(TxtAddressLine1.Text))
                .AddressLine2 = UCase(Trim(TxtAddressLine2.Text))
                .AddressLine3 = UCase(Trim(TxtAddressLine3.Text))
                .AddressLine4 = UCase(Trim(TxtAddressLine4.Text))
                .TelNo = UCase(Trim(TxtTelNo.Text))
                .MobileNo = UCase(Trim(TxtMobileNo.Text))
                .Email = Trim(TxtEmail.Text)
                .Ref.CreatedBy = "WEB_APP"
                .Ref.DateCreated = Now
                .Ref.ModifiedBy = "WEB_APP"
                .Ref.DateModified = Now
            End With

            If Not ClsCustomer.AddNewCustomer(ClsCustomer, DBConn, DBTrans) Then Throw New Exception("Failed to add new customer.")

            'Create PetID
            Dim GenPetID As String

            DtPet = SetSelectedPet()

            If DtPet.Rows.Count > 0 Then

                For i As Integer = 0 To DtPet.Rows.Count - 1

                    GenPetID = GenerateRunningNo("PT", DBConn, DBTrans)
                    If GenPetID = "" Then Throw New Exception("Failed to generate pet ID.")

                    'Update Pet ID in DtPet datatable
                    DtPet.Rows(i).Item("PetID") = GenPetID

                    With ClsPet
                        .CustomerID = GenCustomerID
                        .PetID = GenPetID
                        .PetName = CStr(DtPet.Rows(i).Item("PetName"))
                        .PetDOB = CStr(DtPet.Rows(i).Item("PetDOB"))
                        .AnimalTypeCode = CStr(DtPet.Rows(i).Item("AnimalTypeCode"))
                        .AnimalTypeName = CStr(DtPet.Rows(i).Item("AnimalTypeName"))
                        .BreedCode = CStr(DtPet.Rows(i).Item("BreedCode"))
                        .BreedName = CStr(DtPet.Rows(i).Item("BreedName"))
                        .SexCode = CStr(DtPet.Rows(i).Item("SexCode"))
                        .SexName = CStr(DtPet.Rows(i).Item("SexName"))
                        .StatusCode = CStr(DtPet.Rows(i).Item("StatusCode"))
                        .StatusName = CStr(DtPet.Rows(i).Item("StatusName"))
                        .Ref.CreatedBy = "WEB_APP"
                        .Ref.DateCreated = Now
                        .Ref.ModifiedBy = "WEB_APP"
                        .Ref.DateModified = Now
                    End With

                    'Add to database here
                    If Not ClsPet.AddNewPet(ClsPet, DBConn, DBTrans) Then Throw New Exception("Failed to add new pet(s).")

                Next

            End If

            If Not ResetPetIDRunningNo("PT", DBConn, DBTrans) Then Throw New Exception("Failed to update Pet ID number.")
            If Not AddNewAppointment(DtPet, "NEW_USER", GenCustomerID, UCase(Trim(TxtCustomerName.Text)), DBConn, DBTrans) Then Throw New Exception("Failed to create new appointment.")

            DBTrans.Commit()

        Catch ex As Exception
            If DBTrans IsNot Nothing Then
                DBTrans.Rollback()
                DBTrans.Dispose()
            End If
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewUser()", JSMsgDisplay(ex.Message))
            WriteErrLog("Appointment.AddNewUser()", ex.Message)
            Return False
        End Try

        DBTrans = Nothing
        Return True

    End Function

    Protected Function AddNewAppointment(Optional DtPet As DataTable = Nothing, Optional Command As String = "", Optional ByVal GenCustomerID As String = "", Optional ByVal GenCustomerName As String = "",
                                         Optional ByRef DBConn As MySqlConnection = Nothing, Optional DBTrans As MySqlTransaction = Nothing) As Boolean

        Dim ClsAppointment As New ClsAppointment
        Dim ClsAppointmentDetail As New ClsAppointmentDetail
        Dim DtAppointment As New DataTable
        Dim AppointmentTime As DateTime
        Dim AppointmentID As String
        Dim CustomerID As String
        Dim CustomerName As String
        Dim Message As String

        Try
            If DBConn Is Nothing Then DBConn = New MySqlConnection(ConfigurationManager.ConnectionStrings("samc_db").ConnectionString)

            If Trim(LblCustomerID.Text) <> "" Then
                CustomerID = UCase(Trim(LblCustomerID.Text))
            Else
                CustomerID = GenCustomerID
            End If

            If Trim(LblCustomerName.Text) <> "" Then
                CustomerName = UCase(Trim(LblCustomerName.Text))
            Else
                CustomerName = GenCustomerName
            End If

            'Set hidden field to hold value for CustomerID and AppointmentTime, to be used to load appointment summary based on CustomerID and latest AppointmentTime
            HfCustomerID.Value = CustomerID
            HfLatestAppointmentTime.Value = Trim(TxtAppointmentTime.Text)

            'Check if user already create appointment on that day
            ClsAppointment = New ClsAppointment
            With ClsAppointment
                .CustomerID = CustomerID
                .AppointmentTime = CDate(TxtAppointmentTime.Text)
            End With

            DtAppointment = ClsAppointment.CheckExistingAppointment(ClsAppointment, DBConn)
            If DtAppointment.Rows.Count > 0 Then

                Message = "Appointment for " & DtAppointment.Rows(0).Item("CustomerName") & " on " & DtAppointment.Rows(0).Item("AppointmentTime") &
                    " has been created. Please select another day and time."
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay(Message))
                Return False

            End If

            If DBConn.State = ConnectionState.Closed Then DBConn.Open()
            If DBTrans Is Nothing Then
                DBTrans = DBConn.BeginTransaction
            End If

            AppointmentID = GenerateRunningNo("AP", DBConn, DBTrans)
            If AppointmentID = "" Then
                Message = "Failed to create appointment number."
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay(Message))
            End If

            If DtPet Is Nothing Then
                DtPet = SetSelectedPet()
            End If

            AppointmentTime = DateTime.ParseExact(Trim(TxtAppointmentTime.Text), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)

            ClsAppointment = New ClsAppointment
            With ClsAppointment
                .AppointmentID = AppointmentID
                .EmpID = UCase(Trim(DdlVet.SelectedValue))
                .EmpName = UCase(Trim(DdlVet.SelectedItem.ToString))
                .CustomerID = CustomerID
                .CustomerName = CustomerName
                .AppointmentTime = AppointmentTime
                .Ref.CreatedBy = "WEB_APP"
                .Ref.DateCreated = Now
                .Ref.ModifiedBy = "WEB_APP"
                .Ref.DateModified = Now
            End With

            'Appointment header
            If Not ClsAppointment.AddNewAppointment(ClsAppointment, DBConn, DBTrans) Then
                'MsgBox("Failed to create appointment header.", MsgBoxStyle.Critical, "Create Appointment Failed")
                DBTrans.Rollback()
                DBTrans.Dispose()
                DBTrans = Nothing
                Return False
            End If

            If DtPet.Rows.Count > 0 Then

                For i As Integer = 0 To DtPet.Rows.Count - 1

                    ClsAppointmentDetail = New ClsAppointmentDetail
                    With ClsAppointmentDetail
                        .AppointmentID = AppointmentID
                        .PetID = DtPet.Rows(i).Item("PetID") 'DgvSelectedPet.Rows(i).Cells("PetID").Value
                        .PetName = DtPet.Rows(i).Item("PetName") 'DgvSelectedPet.Rows(i).Cells("PetName").Value
                        .PetDOB = DtPet.Rows(i).Item("PetDOB") 'DgvSelectedPet.Rows(i).Cells("PetDOB").Value
                        .AnimalTypeCode = DtPet.Rows(i).Item("AnimalTypeCode") 'DgvSelectedPet.Rows(i).Cells("AnimalTypeCode").Value
                        .AnimalTypeName = DtPet.Rows(i).Item("AnimalTypeName") 'DgvSelectedPet.Rows(i).Cells("AnimalTypeName").Value
                        .BreedCode = DtPet.Rows(i).Item("BreedCode") 'DgvSelectedPet.Rows(i).Cells("BreedCode").Value
                        .BreedName = DtPet.Rows(i).Item("BreedName") 'DgvSelectedPet.Rows(i).Cells("BreedName").Value
                        .SexCode = DtPet.Rows(i).Item("SexCode") 'DgvSelectedPet.Rows(i).Cells("SexCode").Value
                        .SexName = DtPet.Rows(i).Item("SexName") 'DgvSelectedPet.Rows(i).Cells("SexName").Value
                        .StatusCode = DtPet.Rows(i).Item("StatusCode") 'DgvSelectedPet.Rows(i).Cells("StatusCode").Value
                        .StatusName = DtPet.Rows(i).Item("StatusName") 'DgvSelectedPet.Rows(i).Cells("StatusName").Value
                        .AppointmentDesc = DtPet.Rows(i).Item("PetIssue") 'DgvSelectedPet.Rows(i).Cells("AppointmentDesc").Value
                        .Ref.CreatedBy = "WEB_APP"
                        .Ref.DateCreated = Now
                        .Ref.ModifiedBy = "WEB_APP"
                        .Ref.DateModified = Now
                    End With

                    If Not ClsAppointmentDetail.AddNewAppointmentDetail(ClsAppointmentDetail, DBConn, DBTrans) Then
                        'MsgBox("Failed to create appointment details.", MsgBoxStyle.Critical, "Create Appointment Failed")
                        DBTrans.Rollback()
                        DBTrans.Dispose()
                        DBTrans = Nothing
                        Return False
                    End If

                Next

            End If

            If Command = "NEW_USER" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay("Appointment has been successfully saved!"))
                Return True
            End If

            DBTrans.Commit()
            DBTrans.Dispose()

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay("Appointment has been successfully saved!"))

        Catch ex As Exception
            WriteErrLog("Appointment.AddNewAppointment()", ex.Message)

            If Command = "NEW_USER" Then
                Return False
            End If

            DBTrans.Rollback()
            DBTrans.Dispose()

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AddNewAppointment()", JSMsgDisplay(ex.Message))

            Return False
        End Try

        DBTrans = Nothing
        Return True

    End Function

    Protected Function SetSelectedPet() As DataTable

        Dim DtPet As New DataTable

        Try
            With DtPet
                .Columns.Add("PetID", GetType(String))
                .Columns.Add("PetName", GetType(String))
                .Columns.Add("SexCode", GetType(String))
                .Columns.Add("SexName", GetType(String))
                .Columns.Add("PetDOB", GetType(String))
                .Columns.Add("AnimalTypeCode", GetType(String))
                .Columns.Add("AnimalTypeName", GetType(String))
                .Columns.Add("BreedCode", GetType(String))
                .Columns.Add("BreedName", GetType(String))
                .Columns.Add("StatusCode", GetType(String))
                .Columns.Add("StatusName", GetType(String))
                .Columns.Add("PetIssue", GetType(String))
            End With

            If GvSelectedPet.Rows.Count > 0 Then

                For Each Row As GridViewRow In GvSelectedPet.Rows

                    Dim DataRow As DataRow = DtPet.NewRow

                    DataRow("PetID") = GvSelectedPet.DataKeys(Row.RowIndex).Values(0).ToString()
                    DataRow("PetName") = Row.Cells(1).Text
                    DataRow("SexCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(4).ToString()
                    DataRow("SexName") = Row.Cells(2).Text
                    DataRow("PetDOB") = Row.Cells(3).Text
                    DataRow("AnimalTypeCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(1).ToString()
                    DataRow("AnimalTypeName") = Row.Cells(4).Text
                    DataRow("BreedCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(2).ToString()
                    DataRow("BreedName") = Row.Cells(5).Text
                    DataRow("StatusCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(3).ToString()
                    DataRow("StatusName") = Row.Cells(6).Text
                    DataRow("PetIssue") = Row.Cells(7).Text

                    DtPet.Rows.Add(DataRow)

                Next

            End If

        Catch ex As Exception
            WriteErrLog("Appointment.SetSelectedPet()", ex.Message)
        End Try

        Return DtPet

    End Function

    Protected Sub ShowAppointmentSummary()

        Dim DtAppointment As New DataTable
        Dim ClsAppointment As New ClsAppointment
        Dim Message As String

        Try
            With ClsAppointment
                .CustomerID = HfCustomerID.Value
                .AppointmentTime = CDate(HfLatestAppointmentTime.Value)
            End With

            DtAppointment = ClsAppointment.GetAppointmentSummary(ClsAppointment, DBConn)

            If DtAppointment.Rows.Count > 0 Then

                LblCustomerIDSummary.Text = HfCustomerID.Value
                LblCustomerNameSummary.Text = CStr(DtAppointment.Rows(0).Item("CustomerName"))
                LblAppointmentIDSummary.Text = CStr(DtAppointment.Rows(0).Item("AppointmentID"))
                LblAppointmentTimeSummary.Text = CStr(DtAppointment.Rows(0).Item("AppointmentTime"))
                LblAppointmentVetSummary.Text = CStr(DtAppointment.Rows(0).Item("EmpName"))

                GvAppointmentSummary.DataSource = DtAppointment
                GvAppointmentSummary.DataBind()

            Else
                Message = "Unexpected error. Unable to show appointment summary. Please check customer appointment."
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "ShowAppointmentSummary()", JSMsgDisplay(Message))

                GvAppointmentSummary.Visible = False

            End If

            If DivShowHideAppointment.Visible = True Then
                DivShowHideAppointment.Visible = False
            End If

            If DivSearchResult.Visible = True Then
                DivSearchResult.Visible = False
            End If

        Catch ex As Exception
            WriteErrLog("Appointment.AddNewUser()", ex.Message)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "ShowAppointmentSummary()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub PopulateSalutation()

        Dim ClsCustomer As New ClsCustomer
        Dim DtSalutation As New DataTable

        Try
            DtSalutation = ClsCustomer.GetSalutation(ClsCustomer, DBConn)
            If DtSalutation.Rows.Count > 0 Then
                DdlSalutation.DataSource = DtSalutation
                DdlSalutation.DataTextField = "SaluteName"
                DdlSalutation.DataValueField = "SaluteCode"
                DdlSalutation.DataBind()
            End If

            DdlSalutation.Items.Insert(0, New ListItem("--Select Salutation--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub PopulateAnimalType()

        Dim ClsAnimal As New ClsAnimal
        Dim DtAnimalType As New DataTable

        Try
            DtAnimalType = ClsAnimal.GetAnimalType(ClsAnimal, DBConn)

            If DtAnimalType.Rows.Count > 0 Then

                DdlAnimalType.DataSource = DtAnimalType
                DdlAnimalType.DataTextField = "AnimalTypeName"
                DdlAnimalType.DataValueField = "AnimalTypeCode"
                DdlAnimalType.DataBind()

            End If

            DdlAnimalType.Items.Insert(0, New ListItem("--Select Animal Type--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub PopulateBreed()

        Dim ClsAnimal As New ClsAnimal
        Dim DtBreed As New DataTable

        Try
            DtBreed = ClsAnimal.GetAnimalBreed(ClsAnimal, DBConn)

            If DtBreed.Rows.Count > 0 Then

                DdlBreed.DataSource = DtBreed
                DdlBreed.DataTextField = "BreedName"
                DdlBreed.DataValueField = "BreedCode"
                DdlBreed.DataBind()

            End If

            DdlBreed.Items.Insert(0, New ListItem("--Select Breed--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub PopulateSex()

        Dim ClsAnimal As New ClsAnimal
        Dim DtSex As New DataTable

        Try
            DtSex = ClsAnimal.GetAnimalSex(ClsAnimal, DBConn)

            If DtSex.Rows.Count > 0 Then

                DdlSex.DataSource = DtSex
                DdlSex.DataValueField = "SexCode"
                DdlSex.DataTextField = "SexName"
                DdlSex.DataBind()

            End If

            DdlSex.Items.Insert(0, New ListItem("--Select Sex--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub PopulatePetStatus()

        Dim ClsAnimal As New ClsAnimal
        Dim DtPetStatus As New DataTable

        Try
            DtPetStatus = ClsAnimal.GetAnimalStatus(ClsAnimal, DBConn)

            If DtPetStatus.Rows.Count > 0 Then

                DdlStatus.DataSource = DtPetStatus
                DdlStatus.DataTextField = "StatusName"
                DdlStatus.DataValueField = "StatusCode"
                DdlStatus.DataBind()

            End If

            DdlStatus.Items.Insert(0, New ListItem("--Select Pet Status--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub PopulateVet()

        Dim ClsEmployee As New ClsEmployee
        Dim DtVet As New DataTable

        Try
            DtVet = ClsEmployee.GetVet(ClsEmployee, DBConn)

            If DtVet.Rows.Count > 0 Then

                DdlVet.DataSource = DtVet
                DdlVet.DataTextField = "EmpName"
                DdlVet.DataValueField = "EmpID"
                DdlVet.DataBind()

            End If

            DdlVet.Items.Insert(0, New ListItem("--Select Vet--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub RegisterNewCustomer()
        ClearSetFields("REGISTER_NEW_CUSTOMER")
        PopulateFields()
    End Sub

    Protected Sub SelectPet()

        Dim SelectedRowIndex As Integer

        Try
            SelectedRowIndex = CInt(HfSelectedRowIndex.Value)

            TxtPetName.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(1).Text
            TxtDOB.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(2).Text
            TxtAnimalType.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(3).Text
            TxtBreed.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(4).Text
            TxtSex.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(5).Text
            TxtStatus.Text = GvRegisteredPet.Rows(SelectedRowIndex).Cells(6).Text

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub DdlAnimalType_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim DtBreed As New DataTable
        Dim ClsAnimal As New ClsAnimal

        Try
            With ClsAnimal
                .AnimalTypeCode = DdlAnimalType.SelectedValue
            End With

            DtBreed = ClsAnimal.GetAnimalBreed(ClsAnimal, DBConn)

            If DtBreed.Rows.Count > 0 Then

                DdlBreed.DataSource = DtBreed
                DdlBreed.DataValueField = "BreedCode"
                DdlBreed.DataTextField = "BreedName"
                DdlBreed.DataBind()

            End If

            DdlBreed.Items.Insert(0, New ListItem("--Select Breed--", ""))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnAddPet_Click(sender As Object, e As EventArgs) Handles BtnAddPet.Click

        Dim ClsPet As New ClsPet
        Dim DtPet As New DataTable
        Dim SelectedRowIndex As Integer
        Dim IsRowCommand As Boolean
        'Dim Message As String

        Try
            UserCommand = "ADD_PET"
            If Not CheckValidEntry(UserCommand) Then Throw New Exception("Failed to add pet. Please check your input.")

            If HfIsRowCommand.Value = "1" Then
                IsRowCommand = True
            End If

            'Initialize datatable
            With DtPet
                .Columns.Add("PetID", GetType(String))
                .Columns.Add("PetName", GetType(String))
                .Columns.Add("SexCode", GetType(String))
                .Columns.Add("SexName", GetType(String))
                .Columns.Add("PetDOB", GetType(String))
                .Columns.Add("AnimalTypeCode", GetType(String))
                .Columns.Add("AnimalTypeName", GetType(String))
                .Columns.Add("BreedCode", GetType(String))
                .Columns.Add("BreedName", GetType(String))
                .Columns.Add("StatusCode", GetType(String))
                .Columns.Add("StatusName", GetType(String))
                .Columns.Add("PetIssue", GetType(String))
            End With

            If Trim(HfSelectedRowIndex.Value) <> "" Then
                SelectedRowIndex = CInt(HfSelectedRowIndex.Value)
            Else
                SelectedRowIndex = -1
            End If

            If GvSelectedPet.Rows.Count > 0 Then

                For Each Row As GridViewRow In GvSelectedPet.Rows

                    Dim DataRow As DataRow = DtPet.NewRow

                    DataRow("PetID") = GvSelectedPet.DataKeys(Row.RowIndex).Values(0).ToString()
                    DataRow("PetName") = Row.Cells(1).Text
                    DataRow("SexCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(4).ToString()
                    DataRow("SexName") = Row.Cells(2).Text
                    DataRow("PetDOB") = Row.Cells(3).Text
                    DataRow("AnimalTypeCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(1).ToString()
                    DataRow("AnimalTypeName") = Row.Cells(4).Text
                    DataRow("BreedCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(2).ToString()
                    DataRow("BreedName") = Row.Cells(5).Text
                    DataRow("StatusCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(3).ToString()
                    DataRow("StatusName") = Row.Cells(6).Text
                    DataRow("PetIssue") = Row.Cells(7).Text

                    DtPet.Rows.Add(DataRow)

                Next

            End If

            Dim DataRowPetID As String
            Dim NewDataRow As DataRow = DtPet.NewRow

            If SelectedRowIndex <> -1 Then
                DataRowPetID = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(0).ToString()
            Else
                DataRowPetID = ""
            End If

            If IsRowCommand = True Then

                ' DataKeyNames="PetID,AnimalTypeCode,BreedCode,SexCode,StatusCode"
                Dim PetID As String = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(0).ToString
                Dim PetName As String = GvRegisteredPet.Rows(SelectedRowIndex).Cells(1).Text
                Dim SexCode As String = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(3).ToString
                Dim SexName As String = GvRegisteredPet.Rows(SelectedRowIndex).Cells(5).Text
                Dim PetDOB As Date = CDate(GvRegisteredPet.Rows(SelectedRowIndex).Cells(2).Text).Date
                Dim AnimalTypeCode As String = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(1).ToString
                Dim AnimalTypeName As String = GvRegisteredPet.Rows(SelectedRowIndex).Cells(3).Text
                Dim BreedCode As String = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(2).ToString
                Dim BreedName As String = GvRegisteredPet.Rows(SelectedRowIndex).Cells(4).Text
                Dim StatusCode As String = GvRegisteredPet.DataKeys(SelectedRowIndex).Values(4).ToString
                Dim StatusName As String = GvRegisteredPet.Rows(SelectedRowIndex).Cells(6).Text
                Dim PetIssue As String = Trim(TxtAppointmentDescription.Text)

                NewDataRow("PetID") = DataRowPetID
                NewDataRow("PetName") = UCase(Trim(PetName))
                NewDataRow("SexCode") = SexCode
                NewDataRow("SexName") = UCase(Trim(SexName))
                NewDataRow("PetDOB") = UCase(Trim(PetDOB))
                NewDataRow("AnimalTypeCode") = AnimalTypeCode
                NewDataRow("AnimalTypeName") = AnimalTypeName
                NewDataRow("BreedCode") = BreedCode
                NewDataRow("BreedName") = UCase(Trim(BreedName))
                NewDataRow("StatusCode") = StatusCode
                NewDataRow("StatusName") = UCase(Trim(StatusName))
                NewDataRow("PetIssue") = Trim(TxtAppointmentDescription.Text)

            Else

                NewDataRow("PetID") = DataRowPetID
                NewDataRow("PetName") = UCase(Trim(TxtPetName.Text))
                NewDataRow("SexCode") = DdlSex.SelectedValue
                NewDataRow("SexName") = DdlSex.SelectedItem
                NewDataRow("PetDOB") = UCase(Trim(TxtDOB.Text))
                NewDataRow("AnimalTypeCode") = DdlAnimalType.SelectedValue
                NewDataRow("AnimalTypeName") = DdlAnimalType.SelectedItem
                NewDataRow("BreedCode") = DdlBreed.SelectedValue
                NewDataRow("BreedName") = DdlBreed.SelectedItem
                NewDataRow("StatusCode") = DdlStatus.SelectedValue
                NewDataRow("StatusName") = DdlStatus.SelectedItem
                NewDataRow("PetIssue") = Trim(TxtAppointmentDescription.Text)

            End If

            DtPet.Rows.Add(NewDataRow)

            With GvSelectedPet
                .DataSource = DtPet
                .DataBind()
            End With

            If TrSelectedPet.Visible = False Then
                TrSelectedPet.Visible = True
            End If

            'Clear fields after adding pets, reset everything back to none
            ClearSetFields("FINISH_ADD_PETS")

            'Message = "Your pet has been added."
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "BtnAddPet_Click()", JSMsgDisplay(Message))

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "BtnAddPet_Click()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Private Sub BtnClearSelectedPet_Click(sender As Object, e As EventArgs) Handles BtnClearSelectedPet.Click

        Try
            ClearSetFields("CLEAR_SELECTED_PET")

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "BtnClearSelectedPet_Click()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub BtnUpdatePet_Click(sender As Object, e As EventArgs) Handles BtnUpdatePet.Click

        Try
            GvSelectedPet.Rows(CInt(HfEditIndex.Value)).Cells(7).Text = UCase(Trim(TxtAppointmentDescription.Text))
            ClearSetFields("UPDATE_PET_CHANGES")

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "BtnUpdatePet_Click()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub BtnDiscardChanges_Click(sender As Object, e As EventArgs) Handles BtnDiscardChanges.Click
        ClearSetFields("DISCARD_PET_CHANGES")
    End Sub

    Protected Sub GvRegisteredPet_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GvRegisteredPet.RowCommand

        Try
            If e.CommandName = "Select" Then

                HfIsRowCommand.Value = "1"
                HfSelectedRowIndex.Value = e.CommandArgument.ToString()

                TxtPetName.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(1).Text
                TxtDOB.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(2).Text
                TxtAnimalType.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(3).Text
                TxtBreed.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(4).Text
                TxtSex.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(5).Text
                TxtStatus.Text = GvRegisteredPet.Rows(CInt(HfSelectedRowIndex.Value)).Cells(6).Text

            End If

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "GvRegisteredPet_RowCommand()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Protected Sub GvSelectedPet_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Dim SelectedRowIndex As Integer
        Dim CommandName As String = e.CommandName

        Try
            SelectedRowIndex = Integer.Parse(e.CommandArgument.ToString())
            HfEditIndex.Value = SelectedRowIndex

            Select Case CommandName

                Case "SelectEdit"

                    If HfNewUser.Value <> "1" Then
                        TxtPetName.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(1).Text
                        TxtSex.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(2).Text
                        TxtDOB.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(3).Text
                        TxtAnimalType.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(4).Text
                        TxtBreed.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(5).Text
                        TxtStatus.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(6).Text
                        TxtAppointmentDescription.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(7).Text
                    Else
                        TxtPetName.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(1).Text
                        TxtDOB.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(3).Text
                        DdlAnimalType.SelectedValue = GvSelectedPet.DataKeys(SelectedRowIndex).Values(1).ToString()
                        DdlSex.SelectedValue = GvSelectedPet.DataKeys(SelectedRowIndex).Values(4).ToString()
                        DdlBreed.SelectedValue = GvSelectedPet.DataKeys(SelectedRowIndex).Values(2).ToString()
                        DdlStatus.SelectedValue = GvSelectedPet.DataKeys(SelectedRowIndex).Values(3).ToString()
                        TxtAppointmentDescription.Text = GvSelectedPet.Rows(SelectedRowIndex).Cells(7).Text
                    End If

                    ClearSetFields("SELECT_EDIT")

                Case "SelectDelete"

                    Dim DtPet As New DataTable

                    If GvSelectedPet.Rows.Count > 0 Then

                        With DtPet
                            .Columns.Add("PetID", GetType(String))
                            .Columns.Add("PetName", GetType(String))
                            .Columns.Add("SexCode", GetType(String))
                            .Columns.Add("SexName", GetType(String))
                            .Columns.Add("PetDOB", GetType(String))
                            .Columns.Add("AnimalTypeCode", GetType(String))
                            .Columns.Add("AnimalTypeName", GetType(String))
                            .Columns.Add("BreedCode", GetType(String))
                            .Columns.Add("BreedName", GetType(String))
                            .Columns.Add("StatusCode", GetType(String))
                            .Columns.Add("StatusName", GetType(String))
                            .Columns.Add("PetIssue", GetType(String))
                        End With

                        Dim Row As GridViewRow
                        For Each Row In GvSelectedPet.Rows

                            Dim DataRow As DataRow = DtPet.NewRow

                            DataRow("PetID") = GvSelectedPet.DataKeys(Row.RowIndex).Values(0).ToString()
                            DataRow("PetName") = Row.Cells(1).Text
                            DataRow("SexCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(4).ToString()
                            DataRow("SexName") = Row.Cells(2).Text
                            DataRow("PetDOB") = Row.Cells(3).Text
                            DataRow("AnimalTypeCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(1).ToString()
                            DataRow("AnimalTypeName") = Row.Cells(4).Text
                            DataRow("BreedCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(2).ToString()
                            DataRow("BreedName") = Row.Cells(5).Text
                            DataRow("StatusCode") = GvSelectedPet.DataKeys(Row.RowIndex).Values(3).ToString()
                            DataRow("StatusName") = Row.Cells(6).Text
                            DataRow("PetIssue") = Row.Cells(7).Text

                            DtPet.Rows.Add(DataRow)

                        Next

                        DtPet.Rows.RemoveAt(SelectedRowIndex)

                    End If

                    If DtPet.Rows.Count > 0 Then
                        GvSelectedPet.DataSource = DtPet
                    Else
                        GvSelectedPet.DataSource = Nothing
                    End If

                    GvSelectedPet.DataBind()

                    ClearSetFields("SELECT_DELETE")

            End Select

        Catch ex As Exception
            WriteErrLog("Appointment.GvSelectedPet_RowCommand()", ex.Message)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "GvSelectedPet_RowCommand()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

    Private Sub BtnCloseAppointmentSummary_Click(sender As Object, e As EventArgs) Handles BtnCloseAppointmentSummary.Click

        Try
            GvAppointmentSummary.DataSource = Nothing
            GvAppointmentSummary.DataBind()

            DivAppointmentSummary.Visible = False

            ClearSetFields("CLOSE_APPOINTMENT_SUMMARY")

        Catch ex As Exception
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "BtnCloseAppointmentSummary_Click()", JSMsgDisplay(ex.Message))
        End Try

    End Sub

End Class
