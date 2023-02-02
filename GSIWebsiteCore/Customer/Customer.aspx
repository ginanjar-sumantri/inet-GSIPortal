<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Customer.aspx.cs" Inherits="GSIWebsiteCore.Customer.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="SurveyorPanel">
            <table cellpadding="3" cellspacing="0" border="0" width="75%">
                <tr>
                    <td rowspan="20">
                    </td>
                    <td>
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td class="PageLiteral">
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
                    <td class="line_separator">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
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
                                            <td class="pageHeight">
                                                <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerButton" runat="server" OnClick="DataPagerButton_Click" />
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemCommand="DataPagerTopRepeater_ItemCommand"
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
                            <tr>
                                <td>
                                    <table cellpadding="3" cellspacing="0" width="0" border="0">
                                        <tr>
                                            <td>
                                                <table cellpadding="3" cellspacing="2" width="0" border="0">
                                                    <tr class="datatable_header">
                                                        <td style="width: 100px" align="center">
                                                            <b>Action</b>
                                                        </td>
                                                        <%--<td style="width: 280px" align="center">
                                                            <b>Customer ID</b>
                                                        </td>--%>
                                                        <td style="width: 1000px" align="center">
                                                            <b>Code</b>
                                                        </td>
                                                        <td style="width: 1100px" align="center">
                                                            <b>Name</b>
                                                        </td>
                                                        <td style="width: 1000px" align="center">
                                                            <b>Business</b>
                                                        </td>
                                                        <td style="width: 2000px" align="center">
                                                            <b>Address</b>
                                                        </td>
                                                        <%--<td style="width: 280px" align="center">
                                                            <b>Customer Address2</b>
                                                        </td>--%>
                                                        <td style="width: 300px" align="center">
                                                            <b>Zip Code</b>
                                                        </td>
                                                        <td style="width: 350px" align="center">
                                                            <b>City</b>
                                                        </td>
                                                        <td style="width: 400px" align="center">
                                                            <b>Phone</b>
                                                        </td>
                                                        <td style="width: 500px" align="center">
                                                            <b>Fax</b>
                                                        </td>
                                                        <td style="width: 280px" align="center">
                                                            <b>NPWP</b>
                                                        </td>
                                                        <%-- <td style="width: 280px" align="center">
                                                            <b>Remark</b>
                                                        </td>--%>
                                                    </tr>
                                                    <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound">
                                                        <ItemTemplate>
                                                            <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                                <td align="center">
                                                                    <table cellpadding="0" cellspacing="0" width="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ImageButton runat="server" Text="View" ID="ViewImageButton" />
                                                                            </td>
                                                                            <%--<td style="padding-left: 7px">
                                                                                <asp:ImageButton runat="server" Text="Result" ID="ResultButton" />
                                                                            </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <%--<td align="center">
                                                                    <asp:Literal runat="server" ID="CustomerIDLiteral"></asp:Literal>
                                                                </td>--%>
                                                                <td align="left">
                                                                    <asp:Literal runat="server" ID="CustomerCodeLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Literal runat="server" ID="CustomerNameLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Literal runat="server" ID="BusinessTypeLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Literal runat="server" ID="CustomerAddress1Literal"></asp:Literal>
                                                                </td>
                                                                <%-- <td align="center">
                                                                    <asp:Literal runat="server" ID="CustomerAddress2Literal"></asp:Literal>
                                                                </td>--%>
                                                                <td align="right">
                                                                    <asp:Literal runat="server" ID="ZipCodeLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Literal runat="server" ID="CityLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Literal runat="server" ID="PhoneLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Literal runat="server" ID="FaxLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Literal runat="server" ID="NPWPLiteral"></asp:Literal>
                                                                </td>
                                                                <%--<td align="center">
                                                                    <asp:Literal runat="server" ID="RemarkLiteral"></asp:Literal>
                                                                </td>--%>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td class="pageHeight">
                                                <asp:Panel DefaultButton="DataPagerBottomButton" ID="DataPagerPanel2" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerBottomButton" runat="server" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerBottomRepeater" runat="server"
                                                                OnItemCommand="DataPagerTopRepeater_ItemCommand" OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
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
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="AddImageButton" runat="server" OnClick="AddImageButton_Click" />
                                            &nbsp;
                                            <asp:ImageButton ID="SyncImageButton" runat="server" OnClick="SyncImageButton_Click" />
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
