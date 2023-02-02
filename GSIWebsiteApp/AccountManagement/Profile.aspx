<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="GSIWebsiteApp.AccountManagement.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div style="float: left">
        <table cellpadding="3" cellspacing="0" width="100%" border="0">
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
                                    <br />
                                    <hr style="width: 556px; color: #B3B3B3;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="CompanyProfileLabel" runat="server"></asp:Label>
                                    <asp:HiddenField ID="ProfileIDHiddenField" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="font-family: arial; font-size: 14pt;">
                    <asp:Label ID="OrderCodeLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Business Type
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="BusinessTypeLiteral"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Customer Name
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="CustomerNameLiteral"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Customer Code
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="CustomerCodeLiteral"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            City
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="CityLiteral"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Customer Address 1
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="CusAddress1Literal"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Customer Address 2
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="CustomerAddress2Literal"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            ZIP Code
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal runat="server" ID="ZIPCodeLiteral"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Phone
                                        </td>
                                        <td>
                                            <div class="formLabelColor">
                                                <asp:Literal ID="PhoneLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Fax
                                        </td>
                                        <td>
                                            <div class="formLabelColor">
                                                <asp:Literal ID="FaxLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            NPPKP
                                        </td>
                                        <td class="formLabelColor">
                                            <asp:Literal ID="NPPKPLiteral" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            NPWP
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal ID="NPWPLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            NPWP Address
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal ID="NPWPAddressLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formTextColorProfile" valign="top">
                                            Remark
                                        </td>
                                        <td class="formLabelColor">
                                            <div>
                                                <asp:Literal ID="RemarkLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset>
                                    <legend>PrimaryContact</legend>
                                    <table>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Name
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="PrimaryContactNameLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Hp
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="PrimaryContactHpLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Fax
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="PrimaryContactFaxLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Email Address
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="PrimaryContactEmailAddressLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset>
                                    <legend>Secondary Contact</legend>
                                    <table>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Department
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactDepartLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Name
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactNameLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Hp
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactHpLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Phone
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactPhoneLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Phone Extension
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactPhoneExtensionLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Fax
                                            </td>
                                            <td class="formLabelColor">
                                                <div>
                                                    <asp:Literal ID="SecondaryContactFaxLiteral" runat="server"></asp:Literal>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Email
                                            </td>
                                            <td class="formLabelColor">
                                                <asp:Literal ID="SecondaryContactEmailLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="formTextColorProfile" valign="top">
                                                Title
                                            </td>
                                            <td class="formLabelColor">
                                                <asp:Literal ID="SecondaryContactTitleLiteral" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
