<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewSIMCard.aspx.cs" Inherits="GSIWebsiteCore.SIMCard.ViewSIMCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/jQuery/JScript.js"></script>
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
                <%--<tr>
                    <td style="font-family: arial; font-size: 12pt; font-weight: bold;">
                        <asp:Literal ID="SIMCardCodeLiteral" runat="server"></asp:Literal>
                    </td>
                </tr>--%>
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
                        <table cellpadding="3" cellspacing="2" width="100%" border="0">
                            <tr>
                                <td class="formTextColor">
                                    SIM Card ID
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="SIMCardNumberCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Phone Number
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="SIMCardNumberTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="SIMCardNumberRequiredFieldValidator" runat="server"
                                        ErrorMessage="SIMCardNumber Must Be Filled" Text="*" ControlToValidate="SIMCardNumberTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Operator Name
                                </td>
                                <td>
                                    <asp:DropDownList ID="OperatorNameDropDownList" runat="server" CssClass="TextBox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Phone Pulsa
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="PhonePulsaTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Internet Pulsa
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="InternetPulsaTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    No Check Pulsa
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="NoCheckPulsaTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Note
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox ID="NoteTextBox" runat="server" TextMode="MultiLine" Height="80px" Width="300"></asp:TextBox>
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
                                        CausesValidation="true" />
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
        </div>
    </div>
</asp:Content>
