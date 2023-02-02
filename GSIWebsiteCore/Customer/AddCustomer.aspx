<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddCustomer.aspx.cs" Inherits="GSIWebsiteCore.Customer.AddCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/jquery/calendar.js"></script>
    <script type="text/javascript" src="../contents/jquery/JScript.js"></script>
    <%--<style type="text/css">
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
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <asp:Panel ID="TrOrderSPNotMovablePanel" runat="server">
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
                    <td class="line_separator">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
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
                            <tr>
                                <td>
                                    <asp:Label ID="CustomerIDLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="3" cellspacing="2" border="0">
                                        <tr>
                                            <td class="formTextColor">
                                                Code
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="CustomerCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CustomerCodeRequiredFieldValidator" runat="server"
                                                    ErrorMessage="Customer Code Must Be Filled" Text="*" ControlToValidate="CustomerCodeTextBox"
                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Name
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="CustomerNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CustomerNameRequiredFieldValidator" runat="server"
                                                    ErrorMessage="Customer Name Must Be Filled" Text="*" ControlToValidate="CustomerNameTextBox"
                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Business Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="BusinessTypeDropDownList" runat="server" Style="font-size: 8pt;"
                                                    CssClass="TextBox">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="BusinessTypeCustomValidator" runat="server" Text="*" ErrorMessage="Business Type  Must Be Filled"
                                                    ControlToValidate="BusinessTypeDropDownList" Display="Dynamic" CssClass="warning"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                City
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="CityTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" ErrorMessage="City Must Be Filled"
                                                    Text="*" ControlToValidate="CityTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="formTextColor">
                                                Address
                                            </td>
                                            <td class="formMultilineTextColor">
                                                <asp:TextBox ID="CustomerAddress1TextBox" runat="server" TextMode="MultiLine" Height="80px"
                                                    Width="300" MaxLength="2000"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="formTextColor">
                                                Address 2
                                            </td>
                                            <td class="formMultilineTextColor">
                                                <asp:TextBox ID="CustomerAddress2TextBox" runat="server" TextMode="MultiLine" Height="80px"
                                                    Width="300" MaxLength="2000"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                <td class="formTextColor">
                                    FgActive
                                </td>
                                <td>
                                    <asp:CheckBox ID="FgActiveCheckBox" runat="server" CssClass="checkBox"></asp:CheckBox>
                                </td>
                            </tr>--%>
                                        <tr>
                                            <td class="formTextColor">
                                                Phone
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="PhoneTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Fax
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="FaxTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                NPPKP
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="NPPKPTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NPPKPRequiredFieldValidator" runat="server" ErrorMessage="NPPKP Must Be Filled"
                                                    Text="*" ControlToValidate="NPPKPTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                NPWP
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="NPWPTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NPWPRequiredFieldValidator" runat="server" ErrorMessage="NPWP Must Be Filled"
                                                    Text="*" ControlToValidate="NPWPTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="formTextColor">
                                                NPWP Address
                                            </td>
                                            <td class="formMultilineTextColor">
                                                <asp:TextBox ID="NPWPAddressTextBox" runat="server" TextMode="MultiLine" Height="80px"
                                                    Width="300" MaxLength="2000"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Zip Code
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="ZipCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ZipCodeRequiredFieldValidator" runat="server" ErrorMessage="Zip Code Must Be Filled"
                                                    Text="*" ControlToValidate="ZipCodeTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="formTextColor">
                                                Remark
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="RemarkTextBox" Width="300" MaxLength="2000" TextMode="MultiLine"
                                                    Height="80" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <fieldset>
                                                    <legend>PrimaryContact</legend>
                                                    <table>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Department
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactDepartmentTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="PrimaryContactDepartmentRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Primary Contact Department Must Be Filled" Text="*" ControlToValidate="PrimaryContactDepartmentTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Name
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="PrimaryContactNameRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Primary Contact Name Must Be Filled" Text="*" ControlToValidate="PrimaryContactNameTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Gender
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="PrimaryGenderRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                                                    CssClass="radioButton" Width="113px">
                                                                    <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Place Of Birth
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryPlaceOfBirthTextBox" MaxLength="40" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Date Of Birth
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="PrimaryDateOfBirthTextBox" runat="server" Width="265" MaxLength="8"
                                                                    CssClass="TextBox" BackColor="#CCCCCCC"></asp:TextBox>
                                                                &nbsp;
                                                                <input id="button1" type="button" onclick="displayCalendar(BodyContentPlaceHolder_PrimaryDateOfBirthTextBox,'dd-mm-yyyy',this)"
                                                                    value="..." />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                HP
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactHPTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Phone
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactPhoneTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Phone Extension
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactPhoneExtensionTextBox" MaxLength="50"
                                                                    CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Fax
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactFaxTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Email
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactEmailTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="PrimaryContactEmailRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Primary Contact Email Must Be Filled" Text="*" ControlToValidate="PrimaryContactEmailTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="PrimaryContactEmailTextBoxRegularExpressionValidator"
                                                                    runat="server" ErrorMessage="Email Not Valid" Text="*" ControlToValidate="PrimaryContactEmailTextBox"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="warning"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Title
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="PrimaryContactTitleTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="PrimaryContactTitleRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Primary Contact Title Must Be Filled" Text="*" ControlToValidate="PrimaryContactTitleTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </fieldset>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <fieldset>
                                                    <legend>Secondary Contact</legend>
                                                    <table>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Department
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactDepartmentTextBox" MaxLength="50"
                                                                    CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="SecondaryContactDepartmentRequiredFieldValidator"
                                                                    runat="server" ErrorMessage="Secondary Contact Department Must Be Filled" Text="*"
                                                                    ControlToValidate="SecondaryContactDepartmentTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Name
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="SecondaryContactNameRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Secondary Contact Name Must Be Filled" Text="*" ControlToValidate="SecondaryContactNameTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Gender
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="SecondaryGenderRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                                                    CssClass="radioButton">
                                                                    <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Place Of Birth
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryPlaceOfBirthTextBox" MaxLength="40" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Date Of Birth
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="SecondaryDateOfBirthTextBox" runat="server" Width="265" MaxLength="8"
                                                                    CssClass="TextBox" BackColor="#CCCCCCC"></asp:TextBox>
                                                                &nbsp;
                                                                <input id="button2" type="button" onclick="displayCalendar(BodyContentPlaceHolder_SecondaryDateOfBirthTextBox,'dd-mm-yyyy',this)"
                                                                    value="..." />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                HP
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactHPTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Phone
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactPhoneTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Phone Extension
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactPhoneExtensionTextBox" MaxLength="50"
                                                                    CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Fax
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactFaxTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Email
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactEmailTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="SecondaryContactEmailRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Secondary Contact Email Must Be Filled" Text="*" ControlToValidate="SecondaryContactEmailTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="SecondaryContactEmailTextBoxRegularExpressionValidator"
                                                                    runat="server" ErrorMessage="Email Not Valid" Text="*" ControlToValidate="SecondaryContactEmailTextBox"
                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="warning"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="formTextColor">
                                                                Title
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="SecondaryContactTitleTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="SecondaryContactTitleRequiredFieldValidator" runat="server"
                                                                    ErrorMessage="Secondary Contact Title Must Be Filled" Text="*" ControlToValidate="SecondaryContactTitleTextBox"
                                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
                                        CausesValidation="false" />
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
