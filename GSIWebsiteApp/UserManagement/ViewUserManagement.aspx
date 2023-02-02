<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewUserManagement.aspx.cs" Inherits="GSIWebsiteApp.UserManagement.ViewUserManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="ViewUserManagementPanel">
            <table cellpadding="3" cellspacing="0" border="0">
                <tr>
                    <td rowspan="20">
                        &nbsp;
                    </td>
                    <td>
                        <table cellpadding="3" cellspacing="0" width="100%" border="0">
                            <tr>
                                <td class="tahoma_14_black PageLiteral">
                                    <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp;
                                    <b>
                                        <asp:Literal ID="PageTitleLiteral" runat="server" />
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="width: 750px; color: #B3B3B3;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="0" width="0" border="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td class="pageHeight" align="right">
                                                <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerButton" runat="server" OnClick="DataPagerButton_Click" />
                                                            </td>
                                                            <td valign="middle">
                                                                &nbsp;
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <td>
                                                                        <asp:LinkButton ID="PageNumberLinkButton" runat="server"></asp:LinkButton>
                                                                        <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="30px"></asp:TextBox>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="3" cellspacing="2" width="0" border="0">
                                        <tr class="datatable_header">
                                            <td style="width: 130px" align="center">
                                                <b>User Name</b>
                                            </td>
                                            <td style="width: 200px" align="center">
                                                <b>Display Name</b>
                                            </td>
                                            <td style="width: 200px" align="center">
                                                <b>Email Address</b>
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound">
                                            <ItemTemplate>
                                                <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="MembershipUserName"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="DisplayName"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="UserEmailAddress"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td class="pageHeight" align="right">
                                                <asp:Panel DefaultButton="DataPagerBottomButton" ID="DataPagerPanel2" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerBottomButton" runat="server" OnClick="DataPagerButton_Click" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerBottomRepeater" runat="server"
                                                                OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <td>
                                                                        <asp:LinkButton ID="PageNumberLinkButton" runat="server"></asp:LinkButton>
                                                                        <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="30px"></asp:TextBox>
                                                                    </td>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
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
