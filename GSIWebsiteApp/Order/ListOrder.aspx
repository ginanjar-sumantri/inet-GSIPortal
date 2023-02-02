<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ListOrder.aspx.cs" Inherits="GSIWebsiteApp.Order.ListOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/javascripts/calendar.js"></script>
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
    <script language="javascript" type="text/javascript">
        function Drop() {
            var _result = false;

            if (confirm("Are you sure want to drop this order ?") == true) {
                _result = true;
            }
            else {
                _result = false;
            }

            return _result
        }

        function Confirmation() {
            var _result = false;

            if (alert("Please confirm to Administrator ") == true) {
                _result = true;
            }

            return _result
        }        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="OrderPanel">
            <table cellpadding="3" cellspacing="0" border="0" width="75%">
                <tr>
                    <td rowspan="20">
                        &nbsp;
                    </td>
                    <td>
                        <table cellpadding="3" cellspacing="0" border="0">
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
                    <td class="line_separator">
                    </td>
                </tr>
                <tr>
                    <td>
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
                                                    Order Number
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="KeywordOrderNoTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td rowspan="3" style="width: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Order Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="StartDateTextBox" runat="server" Width="135" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="StartDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="DateRequiredFieldValidator" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="StartDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    To
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EndDateTextBox" runat="server" Width="135" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="EndDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="EndDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Order Type
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="KeywordOrderTypeDropDownList" runat="server" Width="159px"
                                                        Style="font-size: 10pt;">
                                                        <asp:ListItem Value="99" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="Personal"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Corporate"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Document Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="KeywordDocStatusDropDownList" runat="server" Width="159px"
                                                        Style="font-size: 10pt;">
                                                        <asp:ListItem Value="99" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="Draft"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Final"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
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
                        <table cellpadding="3" cellspacing="0" width="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
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
                                    <table cellpadding="3" cellspacing="2" width="0" border="0">
                                        <tr class="datatable_header">
                                            <td style="width: 80px" align="center">
                                                <b>Action</b>
                                            </td>
                                            <td style="width: 200px" align="center">
                                                <b>Order No</b>
                                            </td>
                                            <%--<td style="width: 130px" align="center">
                                                <b>Type</b>
                                            </td>--%>
                                            <td style="width: 130px" align="center">
                                                <b>SP Name</b>
                                            </td>
                                            <td style="width: 200px" align="center">
                                                <b>Created Date</b>
                                            </td>
                                            <td style="width: 200px" align="center">
                                                <b>Proceed Date</b>
                                            </td>
                                            <td style="width: 100px" align="center">
                                                <b>Doc Version</b>
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound"
                                            OnItemCommand="ListRepeater_ItemCommand">
                                            <ItemTemplate>
                                                <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                    <td align="center">
                                                        <table cellpadding="0" cellspacing="0" width="0" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton runat="server" Text="View" ID="ViewImageButton" />
                                                                </td>
                                                                <td style="padding-left: 7px">
                                                                    <asp:ImageButton runat="server" Text="Drop" ID="DropImageButton" />
                                                                </td>
                                                                <td style="padding-left: 7px; text-indent: 2px;">
                                                                    <asp:ImageButton runat="server" Text="Submit" ID="SubmitImageButton" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="OrderNoLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="SurveyPointNameLiteral"></asp:Literal>
                                                    </td>
                                                    <%--<td align="center">
                                                        <asp:Literal runat="server" ID="OrderTypeLiteral"></asp:Literal>
                                                    </td>--%>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="CreatedDateLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="ProceedLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="DocStatusLiteral"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td colspan="7">
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
