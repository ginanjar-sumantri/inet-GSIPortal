<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddCustomerUser.aspx.cs" Inherits="GSIWebsiteCore.CustomerUser.AddCustomerUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="AddCustomerUserPanel">
            <table cellpadding="3" cellspacing="0" border="0">
                <tr>
                    <td rowspan="20">
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
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td class="PageLiteral">
                                    <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                                    <b>
                                        <asp:Literal ID="PageTitleLiteral" runat="server" />
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="line_separator">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="2" border="0">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td class="formTextColor">
                                                Customer
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="CustomerIDDropDownList" runat="server" CssClass="TextBox">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="CustomerIDCustomValidator" runat="server" Text="*" ErrorMessage="Customer ID Must Be Filled"
                                                    ControlToValidate="CustomerIDDropDownList" Display="Dynamic"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Display Name
                                            </td>
                                            <td>
                                                <asp:TextBox ID="DisplayNameTextBox" runat="server" CssClass="TextBox">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="DisplayNameCustomValidator" runat="server" Text="*"
                                                    ErrorMessage="Display Name Must Be Filled" ControlToValidate="DisplayNameTextBox"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                User Email Address
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserEmailAddressTextBox" runat="server" CssClass="TextBox">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserEmailAddressRequiredFieldValidator" runat="server"
                                                    Text="*" ErrorMessage="User Email Address Must Be Filled" ControlToValidate="UserEmailAddressTextBox"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="UserEmailAddressTextBoxRegularExpressionValidator" runat="server"
                                                    ErrorMessage="Email Not Valid" Text="*" ControlToValidate="UserEmailAddressTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                User Name
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="MembershipUserDropDownList" runat="server" CssClass="TextBox">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="MembershipUserCustomValidator" runat="server" Text="*" ErrorMessage="Membership User Must Be Filled"
                                                    ControlToValidate="MembershipUserDropDownList" Display="Dynamic"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" class="formTextColor">
                                                Remark
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="RemarkTextBox" TextMode="MultiLine" Width="300px"
                                                    Height="100px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RemarkRequiredFieldValidator" runat="server" ErrorMessage="Full Name Must Be Filled"
                                                    Text="*" ControlToValidate="RemarkTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
