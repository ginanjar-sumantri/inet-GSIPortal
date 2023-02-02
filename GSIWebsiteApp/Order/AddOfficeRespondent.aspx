<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddOfficeRespondent.aspx.cs" Inherits="GSIWebsiteApp.Order.AddOfficeRespondent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="font-size: 8pt;">
        <table cellpadding="3" cellspacing="0" width="75%" border="0">
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
                <td>
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td>
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
                        <tr>
                            <td>
                                <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="3" width="0" border="0">
                        <tr>
                            <td class="formTextColor">
                                Business Forms
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="BusinessFormsDropDownList" runat="server" Width="302"
                                    Style="font-size: 9pt;" CssClass="TextBox">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="BusinessFormCustomValidator" runat="server" Text="*" ErrorMessage="Business Forms Be Choose"
                                    ControlToValidate="BusinessFormsDropDownList" Display="Dynamic"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Company Name
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="CompanyNameTextBox" Width="300" MaxLength="60" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CompanyNameRequiredFieldValidator" runat="server"
                                    ErrorMessage="Company Name Must Be Filled" Text="*" ControlToValidate="CompanyNameTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="formTextColor">
                                Line of Business
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="LineofBussinesTextBox" Width="300" MaxLength="200"
                                    CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LineofBussinesRequiredFieldValidator" runat="server"
                                    ErrorMessage="Line of Bussines Must Be Filled" Text="*" ControlToValidate="LineofBussinesTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        <tr>
                            <td valign="top" class="formTextColor">
                                Company Address
                            </td>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="background: #CCCCCC;">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox runat="server" ID="AddressTextBox" Width="298" MaxLength="210" CssClass="TextBox"
                                                            TextMode="MultiLine" Height="80"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ErrorMessage="Company Address Must Be Filled"
                                                            Text="*" ControlToValidate="AddressTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                                            <tr>
                                                                <td valign="top" class="fontColor2" style="padding-right: 2px;">
                                                                    Clue
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="ClueTextBox" Width="260px" TextMode="MultiLine" MaxLength="200"
                                                                        CssClass="TextBox" Height="60"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Phone Number
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="PhoneNumberTextBox" runat="server" Width="137px" MaxLength="50"
                                    CssClass="TextBox"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="PhoneNumberRequiredFieldValidator" runat="server"
                                    ErrorMessage="Phone Number Must Be Filled" Text="*" ControlToValidate="PhoneNumberTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>--%>
                                Ext.
                                <asp:TextBox runat="server" ID="ExtentionTextBox" MaxLength="50" CssClass="TextBox"
                                    Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Contact Number
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="ContactNumberTextBox" runat="server" Width="300" CssClass="TextBox"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="ContactNumberRequiredFieldValidator" runat="server"
                                    ErrorMessage="Contact Number Must Be Filled" Text="*" ControlToValidate="ContactNumberTextBox"
                                    Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Region
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="RegionDDL" runat="server" CssClass="TextBox" Style="font-size: 8pt;"
                                    AutoPostBack="True" OnSelectedIndexChanged="RegionDDL_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="RegionCustomValidator1" runat="server" Text="*" ErrorMessage="Region Must Be Filled"
                                    ControlToValidate="RegionDDL" Display="Dynamic"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <%--<td class="formTextColor">
                                Zip Code
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="ZipCodeTextBox" Width="300" MaxLength="10" CssClass="TextBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ZipCodeRequiredFieldValidator" runat="server" ErrorMessage="Zip Code Must Be Filled"
                                    Text="*" ControlToValidate="ZipCodeTextBox" Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                            </td>--%>
                            <td class="formTextColor">
                                Zip Code
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:DropDownList ID="ZipCodeDDL" runat="server" CssClass="TextBox" Style="font-size: 8pt;">
                                </asp:DropDownList>
                                <asp:CustomValidator ID="ZipCodeCustomValidator" runat="server" Text="*" ErrorMessage="Zip Code Must Be Filled"
                                    ClientValidationFunction="DropDownValidation" ControlToValidate="ZipCodeDDL"
                                    Display="Dynamic" CssClass="warning"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="formTextColor">
                                Required Document
                            </td>
                            <td valign="top" class="fontColor">
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="DokumentTypeHiddenField" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <fieldset id="Fieldset1" runat="server">
                                                <table cellpadding="1" cellspacing="1" style="padding: 2px;">
                                                    <tr>
                                                        <td valign="top" colspan="3">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBoxList ID="DocumentTypeCheckBoxList" RepeatColumns="5" runat="server"
                                                                            RepeatDirection="Horizontal">
                                                                        </asp:CheckBoxList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="padding-right: 2px;">
                                                            Note :
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="NoteDocumentTextBox" Width="251px" TextMode="MultiLine"
                                                                MaxLength="290" CssClass="TextBox" Height="60px"></asp:TextBox>
                                                            <%-- <asp:RequiredFieldValidator ID="NoteDocumentRequiredFieldValidator" runat="server"
                                                                ErrorMessage="Note Document Must Be Filled" Text="*" ControlToValidate="NoteDocumentTextBox"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
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
                            <td valign="top" class="formTextColor">
                                Note
                            </td>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="RemarkTextBox" Width="300" MaxLength="200" TextMode="MultiLine"
                                    CssClass="TextBox" Height="80"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton runat="server" ID="SaveButton" OnClick="SaveButton_Click1" />
                                <asp:ImageButton runat="server" ID="ResetButton" OnClick="ResetButton_Click" CausesValidation="false" />
                                <asp:ImageButton runat="server" ID="CancelButton" OnClick="CancelButton_Click" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
