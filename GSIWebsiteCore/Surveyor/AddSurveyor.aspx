<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddSurveyor.aspx.cs" Inherits="GSIWebsiteCore.Surveyor.AddSurveyor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <asp:Panel runat="server" ID="AddSurveyorPanel">
            <table cellpadding="3" cellspacing="0" border="0">
                <tr>
                    <td rowspan="20">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td class="PageLiteral">
                                    <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
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
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="2" border="0">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td class="formTextColor">
                                                Surveyor Code
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="SurveyorCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="SurveyorCodeRequiredFieldValidator" runat="server"
                                                    ErrorMessage="Surveyor Code Must Be Filled" Text="*" ControlToValidate="SurveyorCodeTextBox"
                                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
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
                                                    ControlToValidate="EmployeeIDDropDownList" Display="Dynamic" ClientValidationFunction="DropDownValidation2"></asp:CustomValidator>
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
                                                    ControlToValidate="RegionIDDropDownList" Display="Dynamic" ClientValidationFunction="DropDownValidation2"></asp:CustomValidator>
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
                                                <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click" />
                                                <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
                                                    CausesValidation="false" />
                                                <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
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
        </asp:Panel>
    </div>
</asp:Content>
