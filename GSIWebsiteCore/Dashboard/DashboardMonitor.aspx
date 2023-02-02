<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardMonitor.aspx.cs"
    Inherits="GSIWebsiteCore.Dashboard.DashboardMonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../contents/jQuery/jquery.toastmessage.js">
    </script>
    <script type="text/javascript" src="../contents/jQuery/jquery-1.4.4.js">
    </script>
    <script type="text/javascript" src="../contents/jQuery/jquery-1.4.4.min.js">
    </script>
    <link href="../contents/css/MainStyleSheet.css" type="text/css" rel="stylesheet" />
    <link href="../contents/jQuery/resources/css/jquery.toastmessage.css" type="text/css"
        rel="stylesheet" />
    <link href="../contents/css/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <div style="margin: 0px 5px 5px 5px;">
        <h3 style="font-weight: bold; font-size: 30px; margin: auto;" align="center">
            SLA Monitoring Surveyor
        </h3>
        <hr />
        <br />
        <asp:Panel runat="server" ID="PanelTotalOrder">
            <table cellpadding="3" cellspacing="2" width="0" border="0" style="font-weight: bold;
                font-size: 17px; margin: auto;" align="center">
                <tr>
                    <td>
                        Out Standing
                    </td>
                    <td>
                        &nbsp :
                    </td>
                    <td>
                        <asp:Literal ID="OutStandingLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        On Progress
                    </td>
                    <td>
                        &nbsp :
                    </td>
                    <td>
                        <asp:Literal ID="OnProgressLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        Today New Order
                    </td>
                    <td>
                        &nbsp :
                    </td>
                    <td>
                        <asp:Literal ID="NewOrderLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        Today Survey Point
                    </td>
                    <td>
                        &nbsp :
                    </td>
                    <td>
                        <asp:Literal ID="TotalSurveyPointLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%--<asp:UpdatePanel runat="server" ID="UPTotalSurveyPoint">
            <ContentTemplate>
                <b>Total Survey Point :
                    <asp:Literal ID="TotalSurveyPointLiteral" runat="server"></asp:Literal></b>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <asp:Panel runat="server" ID="UPOrderWFD">
            <table cellpadding="3" cellspacing="2" width="0" border="0" align="center" style="margin: auto;">
                <tr class="datatable_header">
                    <td style="width: 200px; font-size: 17px;" align="center">
                        <b>Order Date</b>
                    </td>
                    <td style="width: 250px; font-size: 17px;" align="center">
                        <b>Customer</b>
                    </td>
                    <td style="width: 200px; font-size: 17px;" align="center">
                        <b>Survey Point Status</b>
                    </td>
                    <td style="width: 200px; font-size: 17px;" align="center">
                        <b>Region</b>
                    </td>
                </tr>
            </table>
            <asp:Repeater runat="server" ID="OrderWFDListRepeater" OnItemDataBound="OrderWFDListRepeater_ItemDataBound">
                <ItemTemplate>
                    <table cellpadding="3" cellspacing="2" width="0" border="0" align="center" style="font-size: 17px;
                        margin: auto;">
                        <tr class="datatable_body" style="line-height: 30px;">
                            <td style="width: 200px; font-size: 16px;" align="center">
                                <asp:Literal ID="OrderDateLiteral" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 250px; font-size: 16px;" align="center">
                                <asp:Literal ID="CustomerNameLiteral" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 200px; font-size: 16px;" align="center">
                                <asp:Literal ID="SPStatusLiteral" runat="server"></asp:Literal>
                            </td>
                            <td style="width: 200px; font-size: 16px;" align="center">
                                <asp:Literal ID="RegionNameLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Timer ID="Timer" runat="server" Enabled="true" Interval="500000" OnTick="Timer_Tick">
        </asp:Timer>
        <br />
        <asp:UpdatePanel runat="server" ID="UPTimeTable">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <table cellpadding="3" cellspacing="3" width="0" border="0" align="center" style="font-size: 17px;
                    margin: auto;">
                    <tr class="datatable_header">
                        <td style="width: 100px; font-size: 17px;" align="center">
                            <b>Time</b>
                        </td>
                        <td style="width: 350px; font-size: 17px;" align="center">
                            <b>Grid</b>
                        </td>
                        <td style="width: 145px; font-size: 17px;" align="center">
                            <b>Action</b>
                        </td>
                    </tr>
                    <tr class="datatable_body" style="line-height: 30px; font-size: 16px;">
                        <td align="center">
                            < 1 Jam
                        </td>
                        <td align="center">
                            <asp:Literal ID="Progress1Literal" runat="server"></asp:Literal>
                        </td>
                        <td align="center" style="line-height: 15px; font-size: 12px; padding-top: 3px;">
                            <asp:ImageButton ID="Region1ImageButton" runat="server" OnClick="Region1ImageButton_Click" />
                            &nbsp;
                            <asp:ImageButton ID="Surveyor1ImageButton" runat="server" OnClick="Surveyor1ImageButton_Click" />
                        </td>
                    </tr>
                    <tr class="datatable_body" style="line-height: 30px; font-size: 16px;">
                        <td align="center">
                            1 - 2 Jam
                        </td>
                        <td align="center">
                            <asp:Literal ID="Progress2Literal" runat="server"></asp:Literal>
                        </td>
                        <td align="center" style="line-height: 15px; font-size: 12px; padding-top: 3px;">
                            <asp:ImageButton ID="Region2ImageButton" runat="server" OnClick="Region2ImageButton_Click" />
                            &nbsp;
                            <asp:ImageButton ID="Surveyor2ImageButton" runat="server" OnClick="Surveyor2ImageButton_Click" />
                        </td>
                    </tr>
                    <tr class="datatable_body" style="line-height: 30px; font-size: 16px;">
                        <td align="center">
                            > 2 Jam
                        </td>
                        <td align="center">
                            <asp:Literal ID="Progress3Literal" runat="server"></asp:Literal>
                        </td>
                        <td align="center" style="line-height: 15px; font-size: 12px; padding-top: 3px;">
                            <asp:ImageButton ID="Region3ImageButton" runat="server" OnClick="Region3ImageButton_Click" />
                            &nbsp;
                            <asp:ImageButton ID="Surveyor3ImageButton" runat="server" OnClick="Surveyor3ImageButton_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
