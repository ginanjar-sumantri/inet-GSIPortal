<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddWorkOrderAssign.aspx.cs" Inherits="GSIWebsiteCore.WorkOrder.AddWorkOrderAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/jquery/calendar.js"></script>
    <script type="text/javascript" src="../contents/jquery/JScript.js"></script>
    <script language="javascript" type="text/javascript">
        function showStickySuccessToast(_text) {
            $().toastmessage('showToast', {
                text: _text,
                sticky: true,
                position: 'top-right',
                type: 'success',
                closeText: '',
                close: function () {
                    console.log("toast is closed ...");
                }
            });

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="WorkOrderPanel">
            <table cellpadding="3" cellspacing="0" border="0" width="75%">
                <tr>
                    <td class="PageLiteral">
                        <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                        <b>
                            <asp:Literal ID="PageTitleLiteral" runat="server" />
                        </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="color: #B3B3B3;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend><b>Survey Point Info</b></legend>
                                        <asp:Panel ID="PanelMovable" runat="server">
                                            <table cellpadding="3" cellspacing="3" border="0" width="75%">
                                                <tr>
                                                    <td>
                                                        <table cellpadding="3" cellspacing="3" border="0" width="75%">
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Full Name
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="FullNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    Status
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="StatusRBL" runat="server" CssClass="radioButton" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True" OnTextChanged="StatusRBL_OnTextChanged">
                                                                        <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                                                        <asp:ListItem Text="Widow" Value="Widow"></asp:ListItem>
                                                                        <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                                        <asp:ListItem Text="Widower" Value="Widower"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Spouse
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="SpouseTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Nationality
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="NationalityRBL" runat="server" RepeatDirection="Horizontal"
                                                                        CssClass="radioButton">
                                                                        <asp:ListItem Text="WNI" Value="WNI" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="WNA" Value="WNA"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    Place Of Birth
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="PlaceOfBirthTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Date Of Birth
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="DateOfBirthTextBox" runat="server" MaxLength="8" CssClass="TextBox"
                                                                        ReadOnly="true" BackColor="#CCCCCCC"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    ID
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="IDTextBox" Width="89" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                    <asp:TextBox runat="server" ID="IDNoTextBox" Width="205" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Region
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="RegionMovTextBox" Width="300" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    ID Address
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="IDAddressTextBox" Width="300" MaxLength="2000" TextMode="MultiLine"
                                                                        Height="150" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    Current Address
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0" width="0" style="background: #CCCCCC;">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:TextBox runat="server" ID="CurrentAddressTextBox" Width="300" MaxLength="2000"
                                                                                                CssClass="TextBox" TextMode="MultiLine" Height="100"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                                                                                <tr>
                                                                                                    <td valign="top" class="fontColor2" style="padding-right: 2px;">
                                                                                                        Clue
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox runat="server" ID="ClueMovTextBox" Width="260px" TextMode="MultiLine"
                                                                                                            MaxLength="2000" CssClass="TextBox" Height="80"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Mobile Phone
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="MobilePhoneTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Home Phone
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="HomePhoneTextBox" Width="137px" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                    Ext.
                                                                    <asp:TextBox runat="server" ID="ExtensionMovTextBox" MaxLength="50" CssClass="TextBox"
                                                                        Width="130px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Zip Code
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="ZipCodeMovTextBox" MaxLength="10" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    Required Document
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="DokumentTypeMovHiddenField" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <fieldset id="Fieldset1" runat="server">
                                                                                    <table cellpadding="1" cellspacing="1" style="padding: 2px;">
                                                                                        <tr>
                                                                                            <td valign="top" colspan="3">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CheckBoxList ID="DocumentTypeMovCheckBoxList" RepeatColumns="5" runat="server"
                                                                                                                RepeatDirection="Horizontal" CssClass="checkBox">
                                                                                                            </asp:CheckBoxList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top" style="padding-right: 2px;">
                                                                                                Note :
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox runat="server" ID="NoteDocumentMovTextBox" Width="251px" TextMode="MultiLine"
                                                                                                    MaxLength="290" CssClass="TextBox" Height="80px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </fieldset>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="formTextColor">
                                                                    Note
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="RemarkMovTextBox" Width="300" MaxLength="500" TextMode="MultiLine"
                                                                        Height="150" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <div class="formTextColor">
                                                                        Note Complaint
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="RemarkComplaintTextBox" TextMode="MultiLine" runat="server" BackColor="#CCCCCC"
                                                                        ReadOnly="true" Width="180" Height="150" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="PanelNotMovable" runat="server">
                                            <table cellpadding="3" cellspacing="3" width="75%" border="0">
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Business Forms
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="BusinessFormsTextBox" Width="300" MaxLength="200"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Company Name
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="CompanyNameTextBox" Width="300" MaxLength="200" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Line of Bussiness
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="LineofBussinesTextBox" Width="300" MaxLength="200"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <div class="formTextColor">
                                                                        Company Address
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <table cellpadding="0" cellspacing="0" width="0" style="background: #CCCCCC;">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:TextBox runat="server" ID="AddressTextBox" Width="298" MaxLength="210" CssClass="TextBox"
                                                                                                TextMode="MultiLine" Height="80"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                                                                                <tr>
                                                                                                    <td valign="top" class="fontColor2" style="padding-right: 2px;">
                                                                                                        Clue
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox runat="server" ID="ClueNotMovTextBox" Width="260px" TextMode="MultiLine"
                                                                                                            MaxLength="200" CssClass="TextBox" Height="60"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Phone Number
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="PhoneNumberTextBox" runat="server" Width="137px" MaxLength="50"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                    Ext.
                                                                    <asp:TextBox runat="server" ID="ExtensionNotMovTextBox" MaxLength="50" CssClass="TextBox"
                                                                        Width="130px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Contact Number
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="ContactNumberTextBox" runat="server" Width="300" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Region
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="RegionNotMovTextBox" runat="server" Width="300" CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="formTextColor">
                                                                    Zip Code
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="ZipCodeNotMovTextBox" Width="300" MaxLength="10"
                                                                        CssClass="TextBox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <div class="formTextColor">
                                                                        Required Document
                                                                    </div>
                                                                </td>
                                                                <td valign="top" class="fontColor">
                                                                </td>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="DokumentTypeNotMovHiddenField" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <fieldset id="Fieldset2" runat="server">
                                                                                    <table cellpadding="1" cellspacing="1" style="padding: 2px;">
                                                                                        <tr>
                                                                                            <td valign="top" colspan="3">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:CheckBoxList ID="DocumentTypeNotMovCheckBoxList" RepeatColumns="5" runat="server"
                                                                                                                RepeatDirection="Horizontal">
                                                                                                            </asp:CheckBoxList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top" style="padding-right: 2px;">
                                                                                                Note :
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox runat="server" ID="NoteDocumentNotMovTextBox" Width="251px" TextMode="MultiLine"
                                                                                                    MaxLength="290" CssClass="TextBox" Height="60px"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </fieldset>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <div class="formTextColor">
                                                                        Note
                                                                    </div>
                                                                </td>
                                                                <td valign="top">
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="RemarkNotMovTextBox" Width="300" MaxLength="200"
                                                                        TextMode="MultiLine" CssClass="TextBox" Height="80"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table>
                                                            <tr>
                                                                <td valign="top">
                                                                    <div class="formTextColor">
                                                                        Note Complaint
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="RemarkComplaintTextBox2" runat="server" BackColor="#CCCCCC" ReadOnly="true"
                                                                        Width="180" Height="150" CssClass="TextBox" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend><b>Assign Work Order</b></legend>
                                        <table cellpadding="3" cellspacing="3" width="0" border="0">
                                            <tr>
                                                <td valign="top" class="formTextColor">
                                                    Date
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="DateCreateLiteral" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" class="formTextColor">
                                                    Surveyor
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:ScriptManager ID="ScriptManager" runat="server">
                                                    </asp:ScriptManager>
                                                    <asp:UpdatePanel ID="SurveyorUpdatePanel" runat="server">
                                                        <ContentTemplate>
                                                            Region
                                                            <asp:DropDownList ID="RegionDDL" runat="server" OnSelectedIndexChanged="RegionDDL_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            ZipCode
                                                            <asp:DropDownList ID="ZipCodeDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ZipCodeDropDownList_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <br />
                                                            Surveyor
                                                            <asp:DropDownList ID="SurveyorDDL" runat="server" OnSelectedIndexChanged="SurveyorDDL_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                            NIK :
                                                            <asp:Label runat="server" ID="NIKLabel"></asp:Label>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" class="formTextColor">
                                                    Remark
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="WORemarkTextBox" Width="300" MaxLength="200" TextMode="MultiLine"
                                                        CssClass="TextBox" Height="80" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:ImageButton ID="AssignImageButton" runat="server" OnClick="AssignImageButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
