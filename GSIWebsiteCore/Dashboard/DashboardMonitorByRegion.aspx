<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardMonitorByRegion.aspx.cs"
    Inherits="GSIWebsiteCore.Dashboard.DashboardMonitorByRegion" %>

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
        <h3>
            View By Region
            <asp:Literal ID="TimeFrameLiteral" runat="server"></asp:Literal>
        </h3>
        <hr />
        <asp:ImageButton ID="BackImageButton" runat="server" OnClick="BackImageButton_Click" />
        <br />
        <br />
        <asp:Timer ID="Timer" runat="server" Enabled="true" Interval="5000" OnTick="Timer_Tick">
        </asp:Timer>
        <table cellpadding="0" cellspacing="5" class="HintFont">
            <tr>
                <td>
                    <div class="Dashboard PreSurvey">
                    </div>
                    &nbsp;Pre Survey
                </td>
                <td>
                    <div class="Dashboard Survey">
                    </div>
                    &nbsp;Survey
                </td>
                <td>
                    <div class="Dashboard AfterSurvey">
                    </div>
                    &nbsp;After Survey
                </td>
            </tr>
        </table>
        <asp:UpdatePanel runat="server" ID="UPTimeTable">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <table cellpadding="3" cellspacing="2" width="0" border="0">
                    <tr class="datatable_header">
                        <td style="width: 150px" align="left">
                            <b>Region</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>Rcv By System</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>WF Assign</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>WF Download</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>WF Survey</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>On The Way</b>
                        </td>
                        <td style="width: 80px" align="center">
                            <b>On The Spot</b>
                        </td>
                        <td style="width: 85px" align="center">
                            <b>Result Received</b>
                        </td>
                        <td style="width: 70px" align="center">
                            <b>Published</b>
                        </td>
                    </tr>
                    <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound">
                        <ItemTemplate>
                            <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                <td align="left">
                                    <asp:Literal ID="RegionLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right" class="PreSurvey">
                                    <asp:Literal ID="RBSLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right" class="PreSurvey">
                                    <asp:Literal ID="WFALiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="WFDLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="WFSLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="OTWLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="OTSLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right">
                                    <asp:Literal ID="SRRLiteral" runat="server"></asp:Literal>
                                </td>
                                <td align="right" class="AfterSurvey">
                                    <asp:Literal ID="PublishedLiteral" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:ImageButton ID="BackImageButton2" runat="server" OnClick="BackImageButton_Click" />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
