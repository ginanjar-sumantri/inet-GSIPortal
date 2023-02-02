<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddEmployee.aspx.cs" Inherits="GSIWebsiteCore.Employee.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/jquery/calendar.js"></script>
    <script type="text/javascript" src="../contents/jquery/JScript.js"></script>
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
    <div>
        <div style="font-size: 8pt;">
            <table cellpadding="3" cellspacing="0" width="75%" border="0">
                <tr>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td class="PageLiteral">
                                        <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                                        <b>
                                            <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                                        </b>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="width: 750px; color: #B3B3B3;" />
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
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="2" width="100%" border="0">
                            <tr>
                                <td class="formTextColor">
                                    Code
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="EmployeeCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmployeeCodeRequiredFieldValidator" runat="server"
                                        ErrorMessage="Code Must Be Filled" Text="*" ControlToValidate="EmployeeCodeTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="FullNameTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="FullNameRequiredFieldValidator" runat="server" ErrorMessage="Full Name Must Be Filled"
                                        Text="*" ControlToValidate="FullNameTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Gender
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="GenderRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                        CssClass="radioButton">
                                        <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Birth Place
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="PlaceOfBirthTextBox" MaxLength="40" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Birth Date
                                </td>
                                <td>
                                    <asp:TextBox ID="DateOfBirthTextBox" runat="server" Width="265" MaxLength="8" CssClass="TextBox"
                                        BackColor="#CCCCCCC"></asp:TextBox>
                                    &nbsp;
                                    <input id="button1" type="button" onclick="displayCalendar(BodyContentPlaceHolder_DateOfBirthTextBox,'dd-mm-yyyy',this)"
                                        value="..." />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Nationality
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="NationalityRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                        CssClass="radioButton">
                                        <asp:ListItem Text="WNI" Value="WNI" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="WNA" Value="WNA"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    ID
                                </td>
                                <td>
                                    <asp:DropDownList ID="IDDropDownList" runat="server" OnSelectedIndexChanged="IDDropDownList_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="IDNoTextBox" Width="185px" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="IDRequiredFieldValidator" ErrorMessage="ID No Must Be Filled"
                                        Text="*" ControlToValidate="IDNoTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        ID Address
                                    </div>
                                </td>
                                <td class="formMultilineTextColor">
                                    <asp:TextBox ID="EmployeeIDAddressTextBox" runat="server" TextMode="MultiLine" Height="80px"
                                        Width="300" MaxLength="2000"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Current Address
                                    </div>
                                </td>
                                <td class="formMultilineTextColor">
                                    <asp:TextBox ID="EmployeeCurrentAddressTextBox" runat="server" TextMode="MultiLine" Height="80px"
                                        Width="300" MaxLength="2000"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    HandPhone
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="HandPhoneTextBox" Width="300" MaxLength="30" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Gadget Name
                                </td>
                                <td>
                                    <asp:DropDownList ID="GadgetDropDownList" runat="server" CssClass="TextBox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Email
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="EmailTextBox" MaxLength="40" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email Must Be Filled"
                                        Text="*" ControlToValidate="EmailTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Note
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="NoteTextBox" Width="300" MaxLength="2000" TextMode="MultiLine"
                                        Height="80" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    LogOn
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="EmployeeLogOnTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmployeeLogOnRequiredFieldValidator" runat="server"
                                        ErrorMessage="LogOn Must Be Filled" Text="*" ControlToValidate="EmployeeLogOnTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        &nbsp
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click" />
                                    <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
                                        CausesValidation="false" />
                                    <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
