<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewUser.aspx.cs" Inherits="GSIWebsiteCore.User.ViewUser" %>

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
                        <table cellpadding="3" cellspacing="2" width="100%" border="0">
                            <tr >
                                <td class="formTextColorUser">
                                    User Name
                                </td>
                                <td>
                                    <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Email
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="EmailTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Created Date
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="CreationDateTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Status
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="IsApprovedTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    LockedOut
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="IsLockedOutTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Online
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="IsOnlineTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Last Login
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="LastLoginDateTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Last Activity
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="LastActivityDateTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Last Lockout
                                </td>
                                <td>
                                    <asp:TextBox ID="LastLockoutDateTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColorUser">
                                    Last Password Changed
                                </td>
                                <td>
                                    <asp:TextBox ID="LastPasswordChangedDateTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        &nbsp
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="BackImageButton" OnClick="BackImageButton_Click"
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
