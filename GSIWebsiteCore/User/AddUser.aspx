<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddUser.aspx.cs" Inherits="GSIWebsiteCore.User.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
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
                                    User Name
                                </td>
                                <td>
                                    <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" ErrorMessage="User Name Must Be Filled"
                                        Text="*" ControlToValidate="UserNameTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Password
                                </td>
                                <td>
                                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Password Must Be Filled"
                                        Text="*" ControlToValidate="PasswordTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Re Type Password
                                </td>
                                <td>
                                    <asp:TextBox ID="ReTypePasswordTextBox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReTypePasswordRequiredFieldValidator" runat="server"
                                        ErrorMessage="Re Type Password is different" Text="*" ControlToValidate="ReTypePasswordTextBox"
                                        ControlToCompare="PasswordTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Email
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="EmailTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Email Must Be Filled"
                                        Text="*" ControlToValidate="EmailTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        &nbsp
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click"
                                        CausesValidation="true" />
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
