<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EditUser.aspx.cs" Inherits="GSIWebsiteApp.User.EditUser" %>

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
                                        <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp;
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
                                <td class="formTextColorUser" width="750px">
                                    User Name
                                </td>
                                <td>
                                    <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>Change Password</legend>
                                    <asp:Panel ID="PasswordPanel" DefaultButton="SavePasswordImageButton" runat="server">
                                        <table cellpadding="3" cellspacing="0" width="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td class="formTextColorUser">
                                                    &nbsp; Old Password
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="OldPasswordTextBox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="OldPasswordRequiredFieldValidator1" runat="server"
                                                        ValidationGroup="1" ErrorMessage="Incorect Old Password" Text="*" ControlToValidate="OldPasswordTextBox"
                                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td class="formTextColorUser">
                                                    &nbsp; New Password
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="NewPasswordTextBox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="NewPasswordRequiredFieldValidator" runat="server"
                                                        ValidationGroup="1" ErrorMessage="Incorrect New Password" Text="*" ControlToValidate="NewPasswordTextBox"
                                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td class="formTextColorUser">
                                                    &nbsp; Confirm New Password
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="ConfirmNewPasswordTextBox" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator" runat="server"
                                                        ValidationGroup="1" ErrorMessage="Confirmation password is different" Text="*"
                                                        ControlToCompare="NewPasswordTextBox" ControlToValidate="ConfirmNewPasswordTextBox"
                                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3">
                                                    <table cellpadding="3" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                                <asp:ImageButton ID="SavePasswordImageButton" runat="server" OnClick="SavePasswordButton_Click"
                                                                    ValidationGroup="1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
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
                                    <legend>Change Data</legend>
                                    <asp:Panel ID="SaveEmailPanel" DefaultButton="SaveEmailImageButton" runat="server">
                                        <table cellpadding="3" cellspacing="0" width="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td class="formTextColorUser">
                                                    Email
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="EmailTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ValidationGroup="2"
                                                        ErrorMessage="Email Must Be Filled" Text="*" ControlToValidate="EmailTextBox"
                                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3">
                                                    <table cellpadding="3" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                                <asp:ImageButton ID="SaveEmailImageButton" runat="server" ValidationGroup="2" OnClick="SaveEmailButton_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
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
                        <table>
                            <tr>
                                <td>
                                    &nbsp;
                                    <%--<asp:ImageButton runat="server" ID="IsApprovedImageButton" OnClick="IsApprovedImageButton_Click"
                                        CausesValidation="false" />--%>
                                    <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
                                        CausesValidation="false" />
                                    <%--<asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
                                        CausesValidation="false" />--%>
                                    <%-- <asp:ImageButton runat="server" ID="DropImageButton" OnClick="DropImageButton_Click"
                                        CausesValidation="false" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
