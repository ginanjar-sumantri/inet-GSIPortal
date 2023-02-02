<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ListWorkOrder.aspx.cs" Inherits="GSIWebsiteCore.WorkOrder.WorkOrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="../contents/css/calendar.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript" src="../contents/jquery/calendar.js"></script>
    <script type="text/javascript" src="../contents/jquery/JScript.js"></script>
    <script language="javascript" type="text/javascript">
        function DropWorkOrder() {
            var _result = false;

            if (confirm("Are you sure want to Cancel this Work Order ?") == true) {
                _result = true;
            }
            else {
                _result = false;
            }

            return _result
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="WorkOrderPanel">
            <table cellpadding="3" cellspacing="0" border="0" width="78%">
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
                                                    Number &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="WOCodeTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td rowspan="3" style="width: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    Create Date &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="StartDateTextBox" runat="server" Width="130px" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="StartDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="DateRequiredFieldValidator" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="StartDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    To &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EndDateTextBox" runat="server" Width="130px" MaxLength="8" CssClass="TextBox"
                                                        BackColor="#CCCCCCC"></asp:TextBox>
                                                    <asp:Literal ID="EndDateLiteral" runat="server"></asp:Literal>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Date Must Be Filled"
                                                        Text="*" ControlToValidate="EndDateTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Customer &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="CustNameTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Surveyor &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EmployeeNameTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Region &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="RegionDDL" runat="server" Width="155px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Status &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="WOStatusDDL" runat="server" Width="159px" Style="font-size: 10pt;">
                                                        <asp:ListItem Value="99" Text="All"></asp:ListItem>
                                                        <%--<asp:ListItem Value="0" Text="N/A"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Received By System"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Waiting for Assigment"></asp:ListItem>--%>
                                                        <asp:ListItem Value="3" Text="Waiting for Download"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Waiting for Survey"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="On the Way"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text="On the Spot"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text="Survey Result Received"></asp:ListItem>
                                                        <asp:ListItem Value="8" Text="Published"></asp:ListItem>
                                                        <asp:ListItem Value="9" Text="Cancelled"></asp:ListItem>
                                                        <asp:ListItem Value="10" Text="Correction"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="Complaint"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    Survey Point &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="SPNameTextBox" runat="server" Width="155px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Type &nbsp;
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="WOTypeDropDownList" runat="server" Width="159px" Style="font-size: 10pt;">
                                                        <asp:ListItem Value="99" Text="All"></asp:ListItem>
                                                        <asp:ListItem Value="0" Text="Normal"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Correction"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Complaint"></asp:ListItem>
                                                    </asp:DropDownList>
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
                        &nbsp;<asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
                    </td>
                </tr>
                <asp:Panel ID="ReasonPanel" runat="server" Visible="false">
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Reason</legend>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Cancel Reason ?
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="ReasonTextBox" runat="server" MaxLength="500" Width="400px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReasonRequiredFieldValidator" runat="server" Text="*"
                                                ErrorMessage="Reason Text Box Must Be Filled" ControlToValidate="ReasonTextBox"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="YesButton" runat="server" Text="Yes" OnClick="YesButton_OnClick" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="NoButton" runat="server" Text="No" OnClick="NoButton_OnClick" CausesValidation="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="0" width="0" border="0">
                            <%--<tr>
                                <td>
                                    <asp:ImageButton ID="AddImageButton" runat="server" OnClick="AddImageButton_Click" />
                                </td>
                            </tr>--%>
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
                                    <asp:HiddenField ID="CancelRowHiddenField" runat="server" />
                                    <table cellpadding="3" cellspacing="2" width="0" border="0">
                                        <tr class="datatable_header">
                                            <td style="width: 80px" align="center">
                                                <b>Action</b>
                                            </td>
                                            <td style="width: 150px" align="center">
                                                <b>WO No</b>
                                            </td>
                                            <td style="width: 150px" align="center">
                                                <b>Customer</b>
                                            </td>
                                            <td style="width: 150px" align="center">
                                                <b>Survey Point</b>
                                            </td>
                                            <td style="width: 130px" align="center">
                                                <b>Surveyor</b>
                                            </td>
                                            <%-- <td style="width: 120px" align="center">
                                                <b>Create Date</b>
                                            </td>--%>
                                            <td style="width: 120px" align="center">
                                                <b>Execute Date</b>
                                            </td>
                                            <td style="width: 120px" align="center">
                                                <b>Status</b>
                                            </td>
                                            <td style="width: 120px" align="center">
                                                <b>WO Type</b>
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="WorkOrderListRepeater" OnItemDataBound="ListRepeater_ItemDataBound"
                                            OnItemCommand="ListRepeater_ItemCommand">
                                            <ItemTemplate>
                                                <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                    <td align="center">
                                                        <table cellpadding="0" cellspacing="0" width="0" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton runat="server" Text="View" ID="ViewImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Assign" ID="AssignImageButton" />
                                                                    <asp:ImageButton runat="server" Text="TakeOver" ID="TakeOverImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Publish" ID="PublishImageButton" />
                                                                    <asp:ImageButton runat="server" Text="Cancel" ID="CancelImageButton" />
                                                                    <asp:ImageButton runat="server" Text="ApproveCancel" ID="ApproveCancelImageButton" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="WOCodeLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal runat="server" ID="CustomerNameLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal runat="server" ID="SurveyPointNameLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="left">
                                                        <asp:Literal runat="server" ID="EmployeeNameLiteral"></asp:Literal>
                                                    </td>
                                                    <%-- <td align="center">
                                                        <asp:Literal runat="server" ID="DateCreateLiteral"></asp:Literal>
                                                    </td>--%>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="DateExecuteLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="StatusLiteral"></asp:Literal>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Literal runat="server" ID="WOTypeLiteral"></asp:Literal>
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
