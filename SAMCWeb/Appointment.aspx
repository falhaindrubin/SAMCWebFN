<%@ Page Title="Appointment" ClientIDMode="Static" MasterPageFile="~/Site.master" Language="VB" AutoEventWireup="true" CodeFile="Appointment.aspx.vb" Inherits="Appointment" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3><%: Title %>.</h3>
    <%--<h3>Your application description page.</h3>    --%>
    <p><span class="label label-warning">Please search your information in the system before proceed to create appointment.</span></p>

    <div id="DivSearchCustomer">
        <div class="entryblock">
            <fieldset>
                <legend>Search Customer</legend>
                <table border="0">
                    <tr>
                        <td colspan="3"><span class="label label-info"><i>*** Enter your NRIC/Passport/Customer ID</i></span></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSearchCustomer" Width="200"></asp:TextBox></td>
                        <td>
                            <asp:Button runat="server" ID="BtnSearchCustomer" Width="150" Text="Search Customer" CssClass="btn btn-sm btn-primary" />
                            <%--OnClick="SearchCustomer" --%>
                            <asp:Button runat="server" ID="BtnClearSearch" Width="150" Text="Clear" CssClass="btn btn-sm btn-default" />
                            <%--OnClick="ClearSearchCustomer"--%>
                        </td>
                    </tr> <!---->
                </table>
            </fieldset>
        </div>
    </div>

    <div id="DivSearchResult" runat="server">
        <div class="entryblock">
            <fieldset>
                <legend>Search Result(s)</legend>
                <i>
                    <asp:Label runat="server" ID="LblRecordCount"></asp:Label></i>
                    <asp:Label ID="LblCustomerID" runat="server"></asp:Label></td>
                <table border="0" id="TblSearchResult">
                    <tr>
                        <td style="width: 150px">ID</td>
                        <td>:</td>
                        <td></td>                            
                    </tr>
                    <tr>
                        <td>Name</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="LblCustomerName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>NRIC/Passport No</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="LblNRICPassportNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">Registered Pet(s)</td>
                        <td style="vertical-align: top">:</td>
                        <td>
                            <table class="table table-bordered table-striped">
                                <!-- <table id="TblPetsInformation" class="table table-bordered table-striped"> -->
                                <tr>
                                    <td>Pet ID</td>
                                    <td>Pet Name</td>
                                    <td>Animal Type</td>
                                    <td>Breed</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="LblPetIDData"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="LblPetNameData"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="LblAnimalTypeNameData"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="LblBreedNameData"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                            <%-- <asp:GridView runat="server" ID="GvPetsInformation" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="PetID"></asp:BoundField>
                                    <asp:BoundField HeaderText="Name" DataField="PetName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Animal Type" DataField="AnimalTypeName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Breed" DataField="BreedName"></asp:BoundField>
                                </Columns>
                            </asp:GridView>--%>

                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">Appointment History</td>
                        <td style="vertical-align: top">:</td>
                        <td>
                            <asp:GridView runat="server" ID="GvAppointmentHistory" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:BoundField HeaderText="Appointment Time" DataField="AppointmentTime" />
                                    <asp:BoundField HeaderText="Appointment ID" DataField="AppointmentID" />
                                    <asp:BoundField HeaderText="Vet" DataField="EmpName" />
                                    <asp:BoundField HeaderText="Pet Name" DataField="PetName" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>

                    <%--<tr>
                        <td></td>
                        <td></td>
                        <td>
                            <asp:Button ID="BtnAddAppointment" runat="server" Text="Create Appointment" Width="160" OnClick="CreateAppointment" />
                            <asp:Button ID="BtnRegisterNewCustomer" runat="server" Text="Register New Customer" OnClick="RegisterNewCustomer" Width="160" />
                        </td>
                    </tr>--%>
                </table>

                <div class="entryblock">
                    <asp:Button ID="BtnAddAppointment" runat="server" Text="Create Appointment" Width="160" OnClick="CreateAppointment" CssClass="btn btn-sm btn-primary" />
                    <asp:Button ID="BtnRegisterNewCustomer" runat="server" Text="Register New Customer" OnClick="RegisterNewCustomer" Width="160" CssClass="btn btn-sm btn-primary" />
                </div>
            </fieldset>
        </div>
    </div>

    <div id="DivShowHideAppointment" runat="server">
        <div id="DivCustomerInformation" runat="server">
            <div class="entryblock">
                <fieldset>
                    <legend>Customer Information</legend>
                    <table border="0">
                        <tr>
                            <td style="width: 150px">Salutation</td>
                            <td>:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlSalutation"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtSalutation" Width="70" Visible="false"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="HfSaluteCode" />
                            </td>
                        </tr>
                        <tr>
                            <td>Customer Name</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtCustomerName" Width="200" AutoCompleteType="Disabled"></asp:TextBox>
                                <asp:Label runat="server" ID="LblCustomerIDInfo" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>NRIC / Passport No.</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtNRICPassportNo" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Phone (Home)</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtTelNo" Width="200"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Phone (Mobile)</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtMobileNo" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Email</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtEmail" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Address</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtAddressLine1" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtAddressLine2" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtAddressLine3" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtAddressLine4" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>

        <div id="DivPetInformation" runat="server">
            <div class="entryblock">
                <fieldset>
                    <legend>Pet Information</legend>
                    <table border="0">
                        <tr id="TrRegisteredPet" runat="server">
                            <td style="vertical-align: top">Registered Pet(s)</td>
                            <td style="vertical-align: top">:</td>
                            <td>
                                <asp:GridView ID="GvRegisteredPet" runat="server" AutoGenerateColumns="false" OnRowCommand="GvRegisteredPet_RowCommand"
                                    DataKeyNames="PetID,AnimalTypeCode,BreedCode,SexCode,StatusCode" CssClass="table table-bordered table-striped">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button Text="SELECT" CssClass="btn btn-xs btn-primary" runat="server" ToolTip="Select Pet" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Name" DataField="PetName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Date Of Birth" DataField="PetDOB" DataFormatString="{0:d}"></asp:BoundField>
                                        <asp:BoundField HeaderText="Animal Type" DataField="AnimalTypeName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Breed" DataField="BreedName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Sex" DataField="SexName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Status" DataField="StatusName"></asp:BoundField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="TrPetName" runat="server">
                            <td style="width: 150px">Pet Name</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtPetName" Width="200"></asp:TextBox>
                                <asp:Label runat="server" ID="LblPetID" Visible="false"></asp:Label>
                                <asp:HiddenField runat="server" ID="HfSelectedRowIndex" />
                                <asp:HiddenField runat="server" ID="HfIsRowCommand" />
                            </td>
                        </tr>
                        <tr id="TrAnimalType" runat="server">
                            <td>Animal Type</td>
                            <td>:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlAnimalType" Width="200" OnSelectedIndexChanged="DdlAnimalType_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown theme-dropdown clearfix"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtAnimalType" Width="200" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="TrBreed" runat="server">
                            <td>Breed</td>
                            <td>:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlBreed" Width="200"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtBreed" Width="200" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="TrDOB" runat="server">
                            <td>Date of Birth</td>
                            <td>:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtDOB" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                        </tr>
                        <tr id="TrSex" runat="server">
                            <td>Sex</td>
                            <td>:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlSex" Width="200"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtSex" Width="200" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="TrStatus" runat="server">
                            <td>Status</td>
                            <td>:</td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlStatus" Width="200"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="TxtStatus" Width="200" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">Pet's Issues</td>
                            <td style="vertical-align: top">:</td>
                            <td>
                                <asp:TextBox runat="server" ID="TxtAppointmentDescription" TextMode="MultiLine" Width="500" Height="150"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 28px"></td>
                            <td style="height: 28px"></td>
                            <td style="height: 28px">
                                <asp:Button ID="BtnAddPet" runat="server" Text="Add Pet" Width="150" CommandName="0" CommandArgument="-1" CssClass="btn btn-sm btn-primary" />
                                <asp:Button ID="BtnClearSelectedPet" runat="server" Text="Clear Selected Pet" Width="150" CssClass="btn btn-sm btn-default" />
                                <asp:Button ID="BtnUpdatePet" runat="server" Text="Update Pet Issue" Visible="false" Width="150" CssClass="btn btn-sm btn-primary" />
                                <asp:Button ID="BtnDiscardChanges" runat="server" Text="Discard Changes" Visible="false" Width="150" CssClass="btn btn-sm btn-default" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr id="TrSelectedPet" runat="server">
                            <td style="vertical-align: top">Selected Pet(s)</td>
                            <td style="vertical-align: top">:</td>
                            <td>
                                <asp:GridView runat="server" ID="GvSelectedPet"
                                    AutoGenerateColumns="false" DataKeyNames="PetID,AnimalTypeCode,BreedCode,StatusCode,SexCode" OnRowCommand="GvSelectedPet_RowCommand" CssClass="table table-bordered table-striped">
                                    <%--OnRowEditing="GvSelectedPet_RowEditing" OnRowCancelingEdit="GvSelectedPet_RowCancelingEdit" OnRowUpdating="GvSelectedPet_RowUpdating" OnRowDeleting="GvSelectedPet_RowDeleting" --%>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button Text="EDIT" runat="server" CssClass="btn btn-xs btn-primary" CommandName="SelectEdit" CommandArgument="<%# Container.DataItemIndex %>" />
                                                <asp:Button Text="DELETE" runat="server" CssClass="btn btn-xs btn-danger" CommandName="SelectDelete" CommandArgument="<%# Container.DataItemIndex %>" />
                                                <%--   <asp:LinkButton Text="Update" runat="server" CssClass="Update" Style="display: none" />
                                                <asp:LinkButton Text="Cancel" runat="server" CssClass="Cancel" Style="display: none" />--%>
                                            </ItemTemplate>
                                            <%--<EditItemTemplate>
                                                <asp:LinkButton Text="UPDATE" runat="server" CssClass="Update" CommandName="Update" CommandArgument="<%# Container.DataItemIndex %>" />
                                                <asp:LinkButton Text="CANCEL" runat="server" CssClass="Cancel" CommandName="Cancel" CommandArgument="<%# Container.DataItemIndex %>" />
                                            </EditItemTemplate>--%>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Pet Name" DataField="PetName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Sex" DataField="SexName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Date of Birth" DataField="PetDOB" DataFormatString="{0:d}"></asp:BoundField>
                                        <asp:BoundField HeaderText="Animal Type" DataField="AnimalTypeName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Breed" DataField="BreedName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Status" DataField="StatusName"></asp:BoundField>
                                        <asp:BoundField HeaderText="Problem/Issue/Complaint" DataField="PetIssue"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField runat="server" ID="HfEditIndex" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>

        <div class="entryblock">
        </div>

        <div id="DivAppointmentDetails" runat="server">
            <div class="entryblock">
                <fieldset>
                    <legend>Appointment Details</legend>
                </fieldset>
                <table border="0">
                    <tr>
                        <td style="width: 150px">Vet</td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList runat="server" ID="DdlVet" Width="200"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Date & Time</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtAppointmentTime" Width="200" AutoCompleteType="Disabled"></asp:TextBox></td>
                    </tr>
                </table>
            </div>

            <div class="entryblock">
                <table>
                    <tr>
                        <td style="width: 150px"></td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td>
                            <asp:Button runat="server" ID="BtnSubmit" Text="Submit Appointment" Width="150" OnClick="SubmitAppointment" CssClass="btn btn-sm btn-success" />
                            <asp:Button runat="server" ID="BtnClear" Text="Cancel Appointment" Width="150" OnClick="CancelAppointment" CssClass="btn btn-sm btn-default" />
                            <asp:HiddenField runat="server" ID="HfNewUser" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="entryblock"></div>
    <div runat="server" id="DivAppointmentSummary">
        <div id="entryblock">
            <fieldset>
                <legend>Appointment Summary</legend>
                <table border="0">
                    <tr>
                        <td style="width: 150px">Customer ID</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server" ID="LblCustomerIDSummary"></asp:Label>
                            <asp:HiddenField runat="server" ID="HfCustomerID" />
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Name</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server" ID="LblCustomerNameSummary"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Appointment ID</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server" ID="LblAppointmentIDSummary"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Appointment Time</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server" ID="LblAppointmentTimeSummary"></asp:Label>
                            <asp:HiddenField runat="server" ID="HfLatestAppointmentTime" />
                        </td>
                    </tr>
                    <tr>
                        <td>Appointment Vet</td>
                        <td>:</td>
                        <td>
                            <asp:Label runat="server" ID="LblAppointmentVetSummary"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">Pet(s) Details</td>
                        <td style="vertical-align: top">:</td>
                        <td>
                            <asp:GridView runat="server" ID="GvAppointmentSummary" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
                                <Columns>
                                    <asp:BoundField HeaderText="Pet Name" DataField="PetName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Sex" DataField="SexName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Date of Birth" DataField="PetDOB" DataFormatString="{0:d}"></asp:BoundField>
                                    <asp:BoundField HeaderText="Animal Type" DataField="AnimalTypeName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Breed" DataField="BreedName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="StatusName"></asp:BoundField>
                                    <asp:BoundField HeaderText="Problem/Issue/Complaint" DataField="PetIssue"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td colspan="2">
                            <%--<img src="img/pdf-icon.png" width="32" height="32" alt="Appointment Summary" /><asp:Button runat="server" ID="BtnGetAppointmentSummaryPdf" Text="Download Appointment Summary (.pdf)" Width="250" CssClass="btn btn-sm btn-primary" />--%>
                            <asp:Button runat="server" ID="BtnCloseAppointmentSummary" Text="Close Appointment Summary" Width="250" CssClass="btn btn-sm btn-primary" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>

    <%--Script--%>
    <script src="Scripts/jquery-3.3.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-timepicker-addon/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
    <link href="Scripts/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/jquery-ui-timepicker-addon/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {

            //================================INSTANTIATION STARTS================================

            //Populate animal type (e.g Dog, Cat, Rabbit etc.)
            //        var obj = {};
            //        $.ajax({
            //   type: "POST",
            //contentType: "application/json; charset-utf8",
            //url: "/webservice/WsGetAnimalType.asmx/GetAnimalType",
            //data: JSON.stringify(obj),
            //dataType: "json",
            //success: function (data) {
            //    var ddl = [];
            //	for (var i = 0; i < data.d.length; i++) {
            //	    ddl.push(data.d[i].Value);
            //                }

            //	var DdlTypeOfAnimal = $("[id*=DdlTypeOfAnimal]");
            //	DdlTypeOfAnimal.empty().append('<option selected="selected" value="00">--Select Animal Type--</option>');
            //	$.each(data.d, function () {
            //		DdlTypeOfAnimal.append($("<option></option>").val(this['Value']).html(this['Text']));
            //	});yyyy
            //		$("#DdlTypeOfAnimal").val('');
            //	},
            //	error: function (data) {
            //		alert("Error on populating animal type.");
            //	}
            //        });

            $("#DivSearchResult").hide();

            //Set maximum date for pet date of birth
            var DaysToAdd = 0;
            var dtMax = new Date();
            dtMax.setDate(dtMax.getDate() - DaysToAdd);
            var dd = dtMax.getDate();
            var mm = dtMax.getMonth() + 1;
            var y = dtMax.getFullYear();
            var CurrentMaxDate = dd + '/' + mm + '/' + y;

            $("#TxtDOB").datepicker({
                showButtonPanel: true,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                //buttonImage: "../img/calendar.png",
                buttonImageOnly: true,
                buttonText: "Select Date",
                firstDay: 1, // Start with Monday
                maxDate: CurrentMaxDate
            });

            //Set minimum date for appointment date
            var DaysToAdd = 0;
            var dtMin = new Date();
            dtMin.setDate(dtMin.getDate() - DaysToAdd);
            var dd = dtMin.getDate();
            var mm = dtMin.getMonth() + 1;
            var y = dtMin.getFullYear();
            var CurrentMinDate = dd + '/' + mm + '/' + y;
            //alert(CurrentDate);

            $("#TxtAppointmentTime").datetimepicker({
                //showOn: "button",
                showButtonPanel: true,
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                //buttonImage: "../img/calendar.png",
                buttonImageOnly: true,
                buttonText: "Select Date",
                firstDay: 1,
                timeFormat: 'HH:mm:ss', //'HH:mm:ss'
                stepHour: 1,
                //stepMinute: 10,
                //stepSecond: 10,
                minDate: CurrentMinDate,
                hourMin: 9,
                hourMax: 20,
                minuteMax: 0,
                secondMax: 0
            });

            //$("#TxtAppointmentTime").click(function () {
            //    //Set minDate for appointment date
            //    var DaysToAdd = 0;
            //    var dtMax = new Date();
            //    dtMax.setDate(dtMax.getDate() - DaysToAdd);
            //    var dd = dtMax.getDate();
            //    var mm = dtMax.getMonth() + 1;
            //    var y = dtMax.getFullYear();
            //    var CurrentDate = dd + '/' + mm + '/' + y;
            //    alert(CurrentDate);
            //});

            //Populate pet sex
            //        var obj = {};
            //        $.ajax({
            //   type: "POST",
            //contentType: "application/json; charset-utf8",
            //url: "/webservice/WsGetAnimalSex.asmx/GetAnimalSex",
            //data: JSON.stringify(obj),
            //dataType: "json",
            //success: function (data) {
            //    var ddl = [];
            //	for (var i = 0; i < data.d.length; i++) {
            //	    ddl.push(data.d[i].Value);
            //                }

            //	var DdlSex = $("[id*=DdlSex]");
            //	DdlSex.empty().append('<option selected="selected" value="00">--Select Sex--</option>');
            //	$.each(data.d, function () {
            //		DdlSex.append($("<option></option>").val(this['Value']).html(this['Text']));
            //	});
            //		$("#DdlSex").val('');
            //	},
            //	error: function (data) {
            //		alert("Error on populating pet sex.");
            //	}
            //        });

            //Populate pet status
            //        var obj = {};
            //        $.ajax({
            //   type: "POST",
            //contentType: "application/json; charset-utf8",
            //url: "/webservice/WsGetAnimalStatus.asmx/GetAnimalStatus",
            //data: JSON.stringify(obj),
            //dataType: "json",
            //success: function (data) {
            //    var ddl = [];
            //	for (var i = 0; i < data.d.length; i++) {
            //	    ddl.push(data.d[i].Value);
            //                }

            //	var DdlStatus = $("[id*=DdlStatus]");
            //	DdlStatus.empty().append('<option selected="selected" value="00">--Select Pet Status--</option>');
            //	$.each(data.d, function () {
            //		DdlStatus.append($("<option></option>").val(this['Value']).html(this['Text']));
            //	});
            //		$("#DdlStatus").val('');
            //	},
            //	error: function (data) {
            //		alert("Error on populating pet status.");
            //	}
            //        });

            //Populate vet
            //        var obj = {};
            //        $.ajax({
            //   type: "POST",
            //contentType: "application/json; charset-utf8",
            //url: "/webservice/WsGetVet.asmx/GetVet",
            //data: JSON.stringify(obj),
            //dataType: "json",
            //success: function (data) {
            //    var ddl = [];
            //	for (var i = 0; i < data.d.length; i++) {
            //	    ddl.push(data.d[i].Value);
            //                }

            //	var DdlVet = $("[id*=DdlVet]");
            //	DdlVet.empty().append('<option selected="selected" value="00">--Select Vet--</option>');
            //	$.each(data.d, function () {
            //		DdlVet.append($("<option></option>").val(this['Value']).html(this['Text']));
            //	});
            //		$("#DdlVet").val('');
            //	},
            //	error: function (data) {
            //		alert("Error on populating vet list.");
            //	}
            //        });

            //================================INSTANTIATION ENDS================================

            $("#BtnSearchCustomer").click(function () {
                //alert($("#TxtSearchCustomer").val());
                //var CustomerQuery;
                //var Obj = {};
                //var CustomerQuery = $("#TxtSearchCustomer").val();
                //Obj.CustomerID = CustomerQuery;
                //alert(Obj.CustomerID);
                //{ "id" : $(this).find(':selected').val() };

                var CustomerQuery = $("#TxtSearchCustomer").val();
                if (CustomerQuery == "") {
                    alert("Please enter your NRIC/Passport number or Customer ID.");
                    return false;
                }

                if (!$("#TblSearchResult").empty()) {
                    $("#TblSearchResult").empty();
                }

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset-utf8",
                    url: "../webservice/WsGetCustomerInformation.asmx/GetCustomerInformation",
                    data: "{'CustomerQuery':'" + $("#TxtSearchCustomer").val() + "'}", //JSON.stringify(CustomerQuery),
                    dataType: "json",
                    success: function (data) {

                        alert(data.d[0].CustomerID);
                        $("[id$='LblCustomerID']").val(data.d[0].CustomerID);
                        alert($("[id$='LblCustomerID']").val());                        

                        var PetListData = "";
                        for (var i = 0; i < data.d.length; i++) {
                            PetListData += "" +
                                "<tr>" +
                                "<td>" + data.d[i].PetID + "</td>" +
                                "<td>" + data.d[i].PetName + "</td>" +
                                "<td>" + data.d[i].AnimalTypeName + "</td>" +
                                "<td>" + data.d[i].BreedName + "</td>" +
                                "</tr>";
                        };
                                               
                        $("#TblSearchResult").append(
                            "<tr>" +
                            "<td>ID</td>" +
                            "<td>:</td>" +
                            "<td>" + data.d[0].CustomerID + "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td>Name</td>" +
                            "<td>:</td>" +
                            "<td>" + data.d[0].CustomerName + "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td>NRIC/Passport No.</td>" +
                            "<td>:</td>" +
                            "<td>" + data.d[0].NRICPassportNo + "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td style='vertical-align: top'>Registered Pet(s)</td>" +
                            "<td style='vertical-align: top'>:</td>" +
                            "<td>" +
                            "<table class='table table-bordered table-striped'>" +
                            "<tr>" +
                            "<td>Pet ID</td>" +
                            "<td>Pet Name</td>" +
                            "<td>Animal Type</td>" +
                            "<td>Breed</td>" +
                            "</tr>" +
                            PetListData +
                            "</table>" +

                            "</td>" +
                            "</tr>" +

                            "<tr>" +
                            "<td>Appointment History</td>" +
                            "<td>:</td>" +
                            "</tr>"
                        );

                        $("#TblPetsInformation").append(

                            "<tr>" +
                            "<td>Pet ID</td>" +
                            "<td>Pet Name</td>" +
                            "<td>Animal Type</td>" +
                            "<td>Breed</td>" +
                            "</tr>"

                        );

                        for (var i = 0; i < data.d.length; i++) {

                            $("#TblPetsInformation").append(
                                "<tr>" +
                                "<td>" + data.d[i].PetID + "</td>" +
                                "<td>" + data.d[i].PetName + "</td>" +
                                "<td>" + data.d[i].AnimalTypeName + "</td>" +
                                "<td>" + data.d[i].BreedName + "</td>" +
                                "</tr>"
                            );
                        }

                        $("#DivSearchResult").show();

                    },
                    error: function (data) {
                        alert(data.responseText);
                    }
                });

                //alert("Record found.");
                return false;

            });

            $("#BtnClearSearch").click(function () {
                //$("#TblSearchResult").empty();
                //DivSearchResult
                if (!$("#TblSearchResult").empty()) {
                    $("#TblSearchResult").empty();
                }

                $("#DivSearchResult").hide();
                $("#TxtSearchCustomer").val("");

                return false;
            });

            $("#DdlTypeOfAnimal").change(function () {

                var obj = {};
                obj.AnimalCode = $("#DdlTypeOfAnimal").val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset-utf8",
                    url: "/webservice/WsGetAnimalBreed.asmx/GetBreed",
                    data: JSON.stringify(obj),
                    dataType: "json",
                    success: function (data) {
                        var currBDC = [];
                        for (var i = 0; i < data.d.length; i++) {
                            currBDC.push(data.d[i].Value);
                        }
                        //$("#hfCurrBDC").val(currBDC);
                        var DdlBreed = $("[id*=DdlBreed]");
                        DdlBreed.empty().append('<option selected="selected" value="00">--Select Breed--</option>');
                        $.each(data.d, function () {
                            DdlBreed.append($("<option></option>").val(this['Value']).html(this['Text']));
                        });
                        $("#DdlBreed").val('');
                    },
                    error: function (data) {
                        alert("Error on populating animal breed.");
                    }
                });

            });

            $("#BtnSearchCustomer").click(function () {
                if ($("#TxtSearchCustomer").val() == "") {
                    $("#TxtSearchCustomer").css('border-color', 'red');
                    alert("Please enter your NRIC or Passport No.");
                    return false;
                }
            });

            $("#BtnClearSearch").click(function () {
                $("#TxtSearchCustomer").css('border-color', '');
                //return false;
            });

            $("#BtnClear").click(function () {
                //return false;
            });

            $("#BtnAddAppointment").click(function () {
                //$("#DdlSalutation").prop("disabled", true);
                $("#DdlSalutation").attr("disabled", "disabled");
                //return false;
            });

            $("#BtnAddPet").click(function () {
                if ($("#TxtPetName").val() == "") {
                    $("#TxtPetName").css('border-color', 'red');
                    alert("Please select your registered pet.");
                    return false;
                }

                if ($("#TxtAppointmentDescription").val() == "") {
                    $("#TxtAppointmentDescription").css('border-color', 'red');
                    alert("Please describe your pet issue.");
                    return false;
                }
            });

            $("#BtnSubmit").click(function () {
                if ($("#DdlVet").val() == "") {
                    alert("Please select vet.");
                    $("#DdlVet").css('border-color', 'red');
                    return false;
                }

                if ($("#TxtAppointmentTime").val() == "") {
                    alert("Please select appointment date and time.")
                    $("#TxtAppointmentTime").css('border-color', 'red');
                    return false;
                }
            });

        });

    </script>

</asp:Content>
