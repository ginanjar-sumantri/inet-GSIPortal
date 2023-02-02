<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewOrder.aspx.cs" Inherits="GSIWebsiteApp.Order.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <link rel="stylesheet" type="text/css" media="screen" href="../contents/jQuery/resources/css/jquery.ui.potato.menu.css" />
    <script type="text/javascript" src="../contents/jQuery/jquery-1.4.4.js"></script>
    <script type="text/javascript" src="../contents/jQuery/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../contents/jQuery/jquery.ui.potato.menu.js"></script>
    <script type="text/javascript">
        (function ($) {
            $(document).ready(function () {
                $('#menu1').ptMenu({ vertical: true });
                $('#menu2').ptMenu({ vertical: true });
            });
        })(jQuery);
    </script>
    <style type="text/css">
        .btnSurveyButton
        {
            background: url(../contents/images/btnSPbackground.png) no-repeat left bottom;
            text-align: left;
            height: 28px;
            width: 104px;
            font-weight: bold;
            color: #FFFFFF;
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
                                        <asp:HiddenField ID="OrderStatusHiddenField" runat="server" />
                                        <asp:HiddenField ID="OrderVersionHiddenField" runat="server" />
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
                    <td style="font-family: arial; font-size: 12pt; font-weight: bold;">
                        <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:HiddenField ID="SPiDHiddenField" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="2" width="100%" border="0">
                            <tr>
                                <td class="formTextColor">
                                    Order Type
                                </td>
                                <td>
                                    <div class="formLabelColor">
                                        <asp:Label ID="OrderTypeIDLabel" runat="server" Width="250"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Date
                                </td>
                                <td>
                                    <div class="formLabelColor">
                                        <asp:Label ID="DateLabel" runat="server" Width="250"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                             <%--<tr>
                                <td class="formTextColor">
                                    Proceed Date
                                </td>
                                <td>
                                    <div class="formLabelColor">
                                        <asp:Label ID="ProceedDateLabel" runat="server" Width="250"></asp:Label>
                                    </div>
                                </td>
                            </tr>--%>                    
                            <asp:Panel ID="DocStatusPanel" runat="server">
                                <tr>
                                    <td class="formTextColor">
                                        Doc Status
                                    </td>
                                    <td>
                                        <div class="formLabelColor">
                                            <asp:Label ID="DocStatusLabel" runat="server" Width="250"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Note
                                </td>
                                <td class="formMultilineTextColor">
                                    <asp:TextBox ID="NoteTextBox" runat="server" TextMode="MultiLine" Height="180px" Width="259"
                                        CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul id="menu1">
                                        <li><a href="#">
                                            <asp:ImageButton ID="AddSurveyPointImageButton" runat="server" /></a>
                                            <ul>
                                                <asp:Repeater runat="server" ID="ListRepeaterSurveyPoint" OnItemDataBound="ListRepeaterSurveyPoint_ItemDataBound"
                                                    OnItemCommand="ListRepeaterSurveyPoint_ItemCommand">
                                                    <ItemTemplate>
                                                        <li><a>
                                                            <asp:Button ID="SurveyPointButton" CssClass="btnSurveyButton" runat="server" Text="Button" />
                                                        </a></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12pt; font-weight: bold;
                                    color: #030A5D">
                                    SURVEY POINT
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="3" cellspacing="0" width="0" border="0">
                                        <tr>
                                            <td>
                                                <table cellpadding="3" cellspacing="2" width="0" border="0">
                                                    <tr class="datatable_header">
                                                        <td style="width: 80px" align="center">
                                                            <b>Action</b>
                                                        </td>
                                                        <td style="width: 180px" align="center">
                                                            <b>Survey Point</b>
                                                        </td>
                                                        <td style="width: 200px" align="center">
                                                            <b>Name</b>
                                                        </td>
                                                        <td style="width: 180px" align="center">
                                                            <b>Status</b>
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
                                                                                <asp:ImageButton runat="server" Text="Result" ID="ResultButton" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left" style="margin-left:3px;">
                                                                    <asp:Literal runat="server" ID="SPLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="left" style="margin-left:3px;">
                                                                    <asp:Literal runat="server" ID="NameLiteral"></asp:Literal>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:Literal runat="server" ID="StatusLiteral"></asp:Literal>
                                                                </td>
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="0">
                                        <tr>
                                            <td>
                                                <ul id="menu2">
                                                    <li><a href="#">
                                                        <asp:ImageButton ID="AddSurveyPointImageButton2" runat="server" /></a>
                                                        <ul>
                                                            <asp:Repeater runat="server" ID="ListRepeaterSurveyPoint2" OnItemDataBound="ListRepeaterSurveyPoint2_ItemDataBound"
                                                                OnItemCommand="ListRepeaterSurveyPoint2_ItemCommand">
                                                                <ItemTemplate>
                                                                    <li><a>
                                                                        <asp:Button ID="SurveyPointButton" CssClass="btnSurveyButton" runat="server" Text="Button" />
                                                                    </a></li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </li>
                                                </ul>
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
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="SaveImageButton" runat="server" OnClick="SaveImageButton_Click" />
                        <asp:ImageButton ID="SubmitImageButton" runat="server" OnClick="SubmitImageButton_Click" />
                        <asp:ImageButton ID="CancelImageButton" runat="server" OnClick="CancelImageButton_Click"
                            CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
