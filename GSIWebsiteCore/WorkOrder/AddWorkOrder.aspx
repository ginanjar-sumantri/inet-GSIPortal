<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddWorkOrder.aspx.cs" Inherits="GSIWebsiteCore.WorkOrder.AddWorkOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/jquery/calendar.js"></script>
    <script type="text/javascript" src="../contents/jquery/JScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="WorkOrderPanel">
            <table cellpadding="3" cellspacing="0" border="0">
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
                        <asp:Panel ID="QSPanel" DefaultButton="GoImageButton" runat="server">
                            <table cellpadding="0" cellspacing="2" border="0">
                                <tr>
                                    <td valign="top">
                                        <b>Search :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    Order No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="OrderCodeTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td rowspan="3" style="width: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Order Date Start
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="StartDateTextBox" runat="server" Width="100" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="StartDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="DateRequiredFieldValidator" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="StartDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    User
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="UserDDL" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Survey Point
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="OrderSPNameTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Order Date End
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EndDateTextBox" runat="server" Width="100" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="EndDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="EndDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="SPStatusDDL" runat="server" Width="159px" Style="font-size: 10pt;">
                                                        <asp:ListItem Value="99" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Received By System"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Waiting For Assigment"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Waiting For Download"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Waiting For Survey"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="On The Way"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="On The Spot"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Survey Result Received"></asp:ListItem>
                                                        <asp:ListItem Value="8" Text="Published"></asp:ListItem>
                                                        <asp:ListItem Value="9" Text="Cancelled"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Region
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RegionDDL" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Customer Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="CustNameTextBox" runat="Server" Width="155px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:ImageButton ID="GoImageButton" runat="server" OnClick="GoImageButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
                                            <td class="pageHeight">
                                                <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerButton" runat="server" OnClick="DataPagerButton_Click" />
                                                            </td>
                                                            <td valign="middle">
                                                                &nbsp;
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
                                    <table cellpadding="2" cellspacing="2" width="0" border="0">
                                        <tr class="datatable_header">
                                            <td style="width: 100px" align="center">
                                                <b>Action</b>
                                            </td>
                                            <td style="width: 180px" align="center">
                                                <b>Order No</b>
                                            </td>
                                            <td style="width: 90px" align="center">
                                                <b>Order Date</b>
                                            </td>
                                            <td style="width: 220px" align="center">
                                                <b>Survey Point</b>
                                            </td>
                                            <td style="width: 130px" align="center">
                                                <b>Customer</b>
                                            </td>
                                            <td style="width: 100px" align="center">
                                                <b>Region</b>
                                            </td>
                                            <td style="width: 80px" align="center">
                                                <b>Status</b>
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="AddWorkOrderRepeater" OnItemDataBound="ListRepeater_ItemDataBound"
                                            OnItemCommand="ListRepeater_ItemCommand">
                                            <ItemTemplate>
                                                <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                    <td align="center">
                                                        <table cellpadding="0" cellspacing="0" width="0" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton runat="server" Text="View" ID="ViewImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Take Over" ID="TakeOverImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Assign" ID="AssignImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Publish" ID="PublishImageButton" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="OrderCodeLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="OrderDateLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal runat="server" ID="OrderSPNameLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="CustNameLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="RegionLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="StatusLiteral"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="6">
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
                                                                <%--<asp:Button ID="DataPagerBottomButton" runat="server" OnClick="DataPagerButton_Click" /> --%>
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
