<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewDocumentType.aspx.cs" Inherits="GSIWebsiteCore.DocumentType.ViewDocumentType" %>

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
                        <asp:Literal ID="DocumentTypeCodeLiteral" runat="server"></asp:Literal>
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
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="DocumentTypeNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="DocumentTypeNameRequiredFieldValidator" runat="server"
                                        ErrorMessage="Name Must Be Filled" Text="*" ControlToValidate="DocumentTypeNameTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Note
                                </td>
                                <td>
                                    <asp:TextBox ID="NoteTextBox" runat="server" TextMode="MultiLine" Height="80px" Width="300"
                                        MaxLength="2000"></asp:TextBox>
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
