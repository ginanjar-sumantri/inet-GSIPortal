<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddPersonalRespondent.aspx.cs" Inherits="GSIWebsiteApp.Order.AddGuarantorRespondent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/javascripts/calendar.js"></script>
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
    <style type="text/css">
        .radioButton
        {
            font-size: 8pt;
        }
        .radioButton td input
        {
            margin: 3px 3px 3px 6px;
        }
        .checkBox
        {
            font-size: 8pt;
        }
        .checkBox td input
        {
            margin: 3px 3px 3px 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <table cellpadding="3" cellspacing="0" border="0" width="75%">
            <tr>
                <td class="PageLiteral">
                    <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                    <b>
                        <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                    </b>
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="color: #B3B3B3;" />
                </td>
            </tr>
            <tr>
                <td colspan="5 ">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                                <asp:HiddenField ID="OrderIdHiddenField" runat="server" />
                                <asp:HiddenField ID="SPidHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderTypeIdHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderSPIDHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderVersionHiddenField" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-left: 14px;">
                                    <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="warning" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="3" width="0" border="0">
                        <tr>
                            <td class="formTextColor">
                                Full Name
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="FullNameTextBox" MaxLength="60" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="FullNameRequiredFieldValidator" runat="server" ErrorMessage="Full Name Must Be Filled"
                                    Text="*" ControlToValidate="FullNameTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                    <asp:ListItem Text="Single" Value="Single" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                    <asp:ListItem Text="Widow" Value="Widow"></asp:ListItem>
                                    <asp:ListItem Text="Widower" Value="Widower"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator runat="server" ID="StatusRBLRequiredFieldValidator" ErrorMessage="Status Name Must Be Filled"
                                    Text="*" ControlToValidate="StatusRBL" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator runat="server" ID="SpouseTextBoxRequiredFieldValidator"
                                    ErrorMessage="Spouse Name Must Be Filled" Text="*" ControlToValidate="SpouseTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator runat="server" ID="PlaceOfBirthRequiredFieldValidator"
                                    ErrorMessage="Place Of Birth Must Be Filled" Text="*" ControlToValidate="PlaceOfBirthTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Date Of Birth
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="DateOfBirthTextBox" runat="server" Width="265" MaxLength="8" CssClass="TextBox"></asp:TextBox>
                                &nbsp;
                                <input id="button1" type="button" onclick="displayCalendar(BodyContentPlaceHolder_DateOfBirthTextBox,'dd-mm-yyyy',this)"
                                    value="..." />
                                <asp:RequiredFieldValidator runat="server" ID="DateOfBirthRequiredFieldValidator"
                                    ErrorMessage="Date Of Birth Must Be Filled" Text="*" ControlToValidate="DateOfBirthTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                ID
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="IDDropDownList" runat="server" CssClass="TextBox" Style="font-size: 8pt;
                                    width: 91px;" OnSelectedIndexChanged="IDDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:TextBox runat="server" ID="IDNoTextBox" Width="205" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="IDRequiredFieldValidator" ErrorMessage="ID No Must Be Filled"
                                    Text="*" ControlToValidate="IDNoTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="IDDropDownListCustomValidator" runat="server" Text="*" ErrorMessage="ID Must Be Filled"
                                    ControlToValidate="IDDropDownList" Display="Dynamic"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Region
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="RegionDDL" runat="server" CssClass="TextBox" Style="font-size: 8pt;"
                                    AutoPostBack="True" OnSelectedIndexChanged="RegionDDL_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="RegionCustomValidator" runat="server" Text="*" ErrorMessage="Region Must Be Filled"
                                    ClientValidationFunction="DropDownValidation" ControlToValidate="RegionDDL" Display="Dynamic"
                                    CssClass="warning"></asp:CustomValidator>
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
                                <asp:RequiredFieldValidator runat="server" ID="IDAddressRequiredFieldValidator" ErrorMessage="ID Address Must Be Filled"
                                    Text="*" ControlToValidate="IDAddressTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                                            CssClass="TextBox" TextMode="MultiLine" Height="150"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ID="CurrentAddressRequiredFieldValidator"
                                                            ErrorMessage="Current Address Must Be Filled" Text="*" ControlToValidate="CurrentAddressTextBox"
                                                            Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                                                    <asp:TextBox runat="server" ID="ClueTextBox" Width="260px" TextMode="MultiLine" MaxLength="2000"
                                                                        CssClass="TextBox" Height="100"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator runat="server" ID="ClueRequiredFieldValidator" ErrorMessage="Clue Must Be Filled"
                                                                        Text="*" ControlToValidate="ClueTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                <%--<asp:RequiredFieldValidator runat="server" ID="MobilePhoneRequiredFieldValidator"
                                    ErrorMessage="Mobile Phone Must Be Filled" Text="*" ControlToValidate="MobilePhoneTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>--%>
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
                                <%--<asp:RequiredFieldValidator runat="server" ID="HomePhoneRequiredFieldValidator" ErrorMessage="Home Phone     Must Be Filled"
                                    Text="*" ControlToValidate="HomePhoneTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>--%>
                                Ext.
                                <asp:TextBox runat="server" ID="ExtentionTextBox" MaxLength="50" CssClass="TextBox"
                                    Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%--<td class="formTextColor">
                                Zip Code
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="ZipCodeTextBox" MaxLength="10" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="ZipCodeRequiredFieldValidator" ErrorMessage="Zip Code Must Be Filled"
                                    Text="*" ControlToValidate="ZipCodeTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>--%>
                            <td class="formTextColor">
                                Zip Code
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="ZipCodeDDL" runat="server" CssClass="TextBox" Style="font-size: 8pt;">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="ZipCodeCustomValidator" runat="server" Text="*" ErrorMessage="Zip Code Must Be Filled"
                                    ClientValidationFunction="DropDownValidation" ControlToValidate="ZipCodeDDL"
                                    Display="Dynamic" CssClass="warning"></asp:CustomValidator>
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
                                            <asp:HiddenField ID="DokumentTypeHiddenField" runat="server" />
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
                                                                        <asp:CheckBoxList ID="DocumentTypeCheckBoxList" RepeatColumns="5" runat="server"
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
                                                            <asp:TextBox runat="server" ID="NoteDocumentTextBox" Width="251px" TextMode="MultiLine"
                                                                MaxLength="290" CssClass="TextBox" Height="100px"></asp:TextBox>
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
                                Job Title
                            </td>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="JobTitleTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="JobTitleRequiredFieldValidator" ErrorMessage="Job Title Must Be Filled"
                                    Text="*" ControlToValidate="JobTitleTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="formTextColor">
                                Job Type
                            </td>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="JobTypeTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="JobTypeRequiredFieldValidator" ErrorMessage="Job Type Must Be Filled"
                                    Text="*" ControlToValidate="JobTypeTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="formTextColor">
                                Business Line
                            </td>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="BusinessLineTextBox" MaxLength="200" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="BusinessLineRequiredFieldValidator"
                                    ErrorMessage="Business Line Must Be Filled" Text="*" ControlToValidate="BusinessLineTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="formTextColor">
                                Note
                            </td>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="NoteTextBox" Width="300" MaxLength="500" TextMode="MultiLine"
                                    Height="150" CssClass="TextBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" ID="SaveGuarantorRespondent" OnClick="SaveGuarantorRespondent_Click" />
                                <asp:ImageButton runat="server" ID="ResetGuarantorRespondent" OnClick="ResetGuarantorRespondent_Click"
                                    CausesValidation="false" />
                                <asp:ImageButton runat="server" ID="CancelGuarantorRespondent" OnClick="CancelGuarantorRespondent_Click"
                                    CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
