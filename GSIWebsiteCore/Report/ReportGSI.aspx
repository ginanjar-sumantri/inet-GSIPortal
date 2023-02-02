<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ReportGSI.aspx.cs" Inherits="GSIWebsiteCore.Report.ReportGSI" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/javascripts/calendar.js"></script>
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
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
    <asp:Panel runat="server" ID="Panel1">
        <div style="font-size: 8pt;">
            <table cellpadding="3" cellspacing="0" border="0" width="75%">
                <tr>
                    <td class="PageLiteral">
                        <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                        <b>
                            <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                        </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="color: #B3B3B3;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5 ">
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                                    <asp:HiddenField ID="OrderIdHiddenField" runat="server" />
                                    <asp:HiddenField ID="SPidHiddenField" runat="server" />
                                    <asp:HiddenField ID="OrderTypeIdHiddenField" runat="server" />
                                    <asp:HiddenField ID="OrderSPIDHiddenField" runat="server" />
                                    <asp:HiddenField ID="OrderVersionHiddenField" runat="server" />
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
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="3" width="0" border="0">
                            <tr>
                                <td>
                                    Selected Report
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ReportDDL" OnSelectedIndexChanged="ReportDDL_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
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
                        <table>
                            <tr>
                                <td>
                                    <fieldset>
                                        <table>
                                            <tr runat="server" id="Date">
                                                <td>
                                                    Date From
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="DateFromTextBox" Width="200"></asp:TextBox>
                                                    <input id="button1" type="button" onclick="displayCalendar(BodyContentPlaceHolder_DateFromTextBox,'dd-mm-yyyy',this)"
                                                        value="..." />
                                                </td>
                                                <td>
                                                    To
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="DateToTextBox" Width="200"></asp:TextBox>
                                                    <input id="button2" type="button" onclick="displayCalendar(BodyContentPlaceHolder_DateToTextBox,'dd-mm-yyyy',this)"
                                                        value="..." />
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Cust">
                                                <td>
                                                    Customer
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="CustomerTextBox" Width="200"></asp:TextBox>
                                                </td>
                                                <%--<td>
                                                    To
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="CustomerToTextBox" Width="200"></asp:TextBox>
                                                </td>--%>
                                            </tr>
                                            <tr runat="server" id="CustDDL">
                                                <td>
                                                    Customer
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="CustomerDDL" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="OrNo">
                                                <td>
                                                    Order No From
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="OrderNoFromTextBox" Width="200"></asp:TextBox>
                                                </td>
                                                <td>
                                                    To
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="OrderNoToTextBox" Width="200"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="SPName">
                                                <td>
                                                    Survey Point Name
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="SurveyPointNameTextBox" Width="200"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Status">
                                                <td>
                                                    Status
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="StatusDDL" Width="200">
                                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Received By System" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Waiting For Assigment" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Waiting For Download" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Waiting For Survey" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="On The Way" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="On The Spot" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Survey Result Received" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Published" Value="8"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Dispatcher">
                                                <td>
                                                    Dispatcher
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td colspan="4">
                                                    <asp:DropDownList runat="server" ID="DispatcherDDL" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Surveyor">
                                                <td>
                                                    Surveyor
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td colspan="4">
                                                    <asp:DropDownList runat="server" ID="SurveyorDDL" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Year">
                                                <td>
                                                    Years
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="YearDDL" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Month">
                                                <td>
                                                    Month
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="MonthDropDownList" Width="200">
                                                        <asp:ListItem Text="Januari" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Pebruari" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maret" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Mei" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Juni" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Juli" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Agustus" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="Oktober" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Desember" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Period">
                                                <td>
                                                    Month From
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="PeriodFromDDL" Width="200">
                                                        <asp:ListItem Text="Januari" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Pebruari" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maret" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Mei" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Juni" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Juli" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Agustus" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="Oktober" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Desember" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    To
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList runat="server" ID="PeriodToDDL" Width="200">
                                                        <asp:ListItem Text="Januari" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Pebruari" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maret" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Mei" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Juni" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Juli" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Agustus" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="Oktober" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Desember" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
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
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton runat="server" ID="SaveGuarantorRespondent" OnClick="SaveGuarantorRespondent_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel2">
        <table cellpadding="3" cellspacing="0" width="100%" border="0">
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" Height="800px" Width="800px" padding-top="6px"
                        runat="server" ProcessingMode="Remote" AsyncRendering="true">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
