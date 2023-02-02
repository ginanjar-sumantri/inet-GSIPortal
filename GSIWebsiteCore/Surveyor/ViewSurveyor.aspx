<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewSurveyor.aspx.cs" Inherits="GSIWebsiteCore.Surveyor.ViewSurveyor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <%-- <style type="text/css">
        .style1
        {
            width: 120px;
            font-family: Arial;
            font-size: 9pt;
            font-weight: bold;
            color: #FFFFFF;
            line-height: 25px;
            height: 25px;
            padding-left: 10px;
            background: #2F3DA5;
        }
        .style2
        {
            height: 25px;
        }
    </style>--%>
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <asp:Panel ID="TrOrderSPNotMovablePanel" runat="server">
        <div style="font-size: 8pt;">
            <table>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="0" width="100%" border="0">
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
                                    <hr style="width: 556px; color: #B3B3B3;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="SurveyorIDLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="2" border="0">
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Surveyor Code
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="SurveyorCodeTextBox" MaxLength="70" CssClass="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Employee
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="EmployeeIDDropDownList" runat="server" CssClass="TextBox">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="EmployeeIDCustomValidator" runat="server" Text="*" ErrorMessage="Employee ID Must Be Filled"
                                                    ControlToValidate="EmployeeIDDropDownList" Display="Dynamic"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <div class="formTextColor">
                                                    Remark
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="RemarkTextBox" TextMode="MultiLine" Width="300px"
                                                    Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Region
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="RegionIDDropDownList" runat="server" CssClass="TextBox" AutoPostBack="True"
                                                    OnSelectedIndexChanged="RegionIDDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="RegionIDCustomValidator" runat="server" Text="*" ErrorMessage="Region ID Must Be Filled"
                                                    ControlToValidate="RegionIDDropDownList" Display="Dynamic"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColor">
                                                Zip Code
                                            </td>
                                            <td>
                                                <asp:CheckBoxList ID="ZipCodeCheckBoxList" runat="server" RepeatColumns="4" RepeatLayout="Table"
                                                    CellPadding="5" CellSpacing="5" RepeatDirection="Vertical" Width="305">
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp
                                    <table>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click"
                                                    CausesValidation="false" />
                                                <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
                                                    CausesValidation="false" />
                                                <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
                                                    CausesValidation="false" />
                                                <asp:ImageButton runat="server" ID="DropImageButton" OnClick="DropImageButton_Click"
                                                    CausesValidation="false" />
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
</asp:Content>
