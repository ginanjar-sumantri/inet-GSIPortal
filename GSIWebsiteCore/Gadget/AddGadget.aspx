<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddGadget.aspx.cs" Inherits="GSIWebsiteCore.Gadget.AddGadget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
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
                                    Code
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="GadgetCodeTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="GadgetCodeRequiredFieldValidator" runat="server"
                                        ErrorMessage="Code Must Be Filled" Text="*" ControlToValidate="GadgetCodeTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="GadgetNameTextBox" MaxLength="100" CssClass="TextBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="GadgetNameRequiredFieldValidator" runat="server"
                                        ErrorMessage="Gadget Name Must Be Filled" Text="*" ControlToValidate="GadgetNameTextBox"
                                        Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Brand
                                </td>
                                <td>
                                    <asp:DropDownList ID="BrandDDL" runat="server" CssClass="TextBox">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="BrandCustomValidator" runat="server" Text="*" ErrorMessage="Brand Must Be Filled"
                                        ClientValidationFunction="DropDownValidation2" ControlToValidate="BrandDDL" Display="Dynamic"
                                        CssClass="warning"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    No IMEI
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="NoIMEITextBox" MaxLength="40" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    SIM Card
                                </td>
                                <td>
                                    <asp:DropDownList ID="SIMCardDDL" runat="server" CssClass="TextBox">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="SIMCardCustomValidator" runat="server" Text="*" ErrorMessage="SIMCard Must Be Filled"
                                        ControlToValidate="SIMCardDDL" Display="Dynamic" ClientValidationFunction="DropDownValidation2"
                                        CssClass="warning"></asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Note
                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="NoteTextBox" Width="300" MaxLength="2000" TextMode="MultiLine"
                                        Height="100" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="SaveImageButton" OnClick="SaveImageButton_Click" />
                                    <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
                                        CausesValidation="false" />
                                    <asp:ImageButton runat="server" ID="ResetImageButton" OnClick="ResetImageButton_Click"
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
