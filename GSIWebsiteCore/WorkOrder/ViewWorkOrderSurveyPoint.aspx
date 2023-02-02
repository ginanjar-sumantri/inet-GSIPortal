<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewWorkOrderSurveyPoint.aspx.cs" Inherits="GSIWebsiteCore.WorkOrder.ViewWorkOrderSurveyPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
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
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                                    <asp:TextBox runat="server" ID="BusinessFormsTextBox" Width="300" MaxLength="200"
                                        CssClass="TextBox" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Company Name
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" runat="server" ID="CompanyNameTextBox"
                                        Width="300" MaxLength="200" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Line of Business
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" runat="server" ID="LineofBussinesTextBox"
                                        Width="300" MaxLength="200" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Company Address
                                    </div>
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
                                                                TextMode="MultiLine" Height="80" ReadOnly="true"></asp:TextBox>
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
                                                                            CssClass="TextBox" Height="60" ReadOnly="true"></asp:TextBox>
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
                                        CssClass="TextBox" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                    Ext.
                                    <asp:TextBox runat="server" ID="ExtentionTextBox" MaxLength="50" CssClass="TextBox"
                                        Width="130px" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Contact Number
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" ID="ContactNumberTextBox" runat="server"
                                        Width="300" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Region
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" runat="server" ID="RegionTextBoxt"
                                        Width="300" MaxLength="10" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Zip Code
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" runat="server" ID="ZipCodeTextBox"
                                        Width="300" MaxLength="10" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Required Document
                                    </div>
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
                                                                    MaxLength="290" CssClass="TextBox" Height="60px" ReadOnly="true"></asp:TextBox>
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
                                <td valign="top">
                                    <div class="formTextColor">
                                        Note
                                    </div>
                                </td>
                                <td valign="top">
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="RemarkTextBox" Width="300" MaxLength="200" TextMode="MultiLine"
                                        CssClass="TextBox" Height="80" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="BackButton" OnClick="BackButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="TrOrderSPMovablePanel" runat="server">
        <div style="font-size: 8pt;">
            <table>
                <tr>
                    <td colspan="5 ">
                        <table cellpadding="3" cellspacing="0" width="100%" border="0">
                            <tr>
                                <td class="PageLiteral">
                                    <asp:Image runat="server" ID="Image1" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                                    <b>
                                        <asp:Literal ID="PageLiteral2" runat="server"></asp:Literal>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr style="width: 750px; color: #B3B3B3;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="3" width="0" border="0">
                            <tr>
                                <td class="formTextColor">
                                    Full Name
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="FullNameTextBox" MaxLength="50" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Status
                                </td>
                                <td valign="top">
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="StatusRBL" runat="server" CssClass="radioButton" RepeatDirection="Horizontal"
                                        AutoPostBack="True" Enabled="false">
                                        <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                        <asp:ListItem Text="Widow" Value="Widow"></asp:ListItem>
                                        <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                        <asp:ListItem Text="Widower" Value="Widower"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Spouse
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="SpouseTextBox" MaxLength="50" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Nationality
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="NationalityRBL" runat="server" RepeatDirection="Horizontal"
                                        CssClass="radioButton" Enabled="false">
                                        <asp:ListItem Text="WNI" Value="WNI" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="WNA" Value="WNA"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Place Of Birth
                                </td>
                                <td valign="top">
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="PlaceOfBirthTextBox" MaxLength="100" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Date Of Birth
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ID="DateOfBirthTextBox" runat="server" Width="265" MaxLength="8" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    ID
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:DropDownList ID="IDDropDownList" runat="server" CssClass="TextBox" Style="font-size: 8pt;
                                        width: 91px;" Enabled="false">
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="IDNoTextBox" Width="205" MaxLength="50" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Region
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:DropDownList ID="RegionDDL" runat="server" CssClass="TextBox" Enabled="false"
                                        Style="font-size: 8pt;">
                                    </asp:DropDownList>
                                    <%-- <asp:TextBox runat="server" ID="Region2TextBox" Width="205" MaxLength="50" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    ID Address
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="IDAddressTextBox" Width="300" MaxLength="2000" TextMode="MultiLine"
                                        Height="80" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Current Address
                                </td>
                                <td valign="top">
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="0" style="background: #CCCCCC;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox runat="server" ID="CurrentAddressTextBox" Width="300" MaxLength="2000"
                                                                CssClass="TextBox" TextMode="MultiLine" Height="80" ReadOnly="true"></asp:TextBox>
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
                                                                        <asp:TextBox runat="server" ID="ClueTextBox2" Width="260px" TextMode="MultiLine"
                                                                            MaxLength="2000" CssClass="TextBox" Height="60" ReadOnly="true"></asp:TextBox>
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
                                    Mobile Phone
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox ReadOnly="true" BackColor="#CCCCCC" runat="server" ID="MobilePhoneTextBox"
                                        MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Home Phone
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="HomePhoneTextBox" Width="137px" MaxLength="50" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                    Ext.
                                    <asp:TextBox runat="server" ID="ExtentionTextBox2" MaxLength="50" CssClass="TextBox"
                                        Width="130px" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Zip Code
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="ZipCodeTextBox2" MaxLength="10" CssClass="TextBox"
                                        ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="formTextColor">
                                    Required Document
                                </td>
                                <td valign="top">
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" style="padding: 2px;">
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <fieldset id="Fieldset2" runat="server">
                                                    <table cellpadding="1" cellspacing="1" style="padding: 2px;">
                                                        <tr>
                                                            <td valign="top" colspan="3">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="DocumentTypeCheckBoxList2" RepeatColumns="5" runat="server"
                                                                                RepeatDirection="Horizontal" CssClass="checkBox">
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
                                                                <asp:TextBox runat="server" ID="NoteDocumentTextBox2" Width="251px" TextMode="MultiLine"
                                                                    MaxLength="290" CssClass="TextBox" Height="60px" ReadOnly="true"></asp:TextBox>
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
                                    <asp:TextBox runat="server" ID="NoteTextBox" Width="300" MaxLength="500" TextMode="MultiLine"
                                        Height="80" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="BackButton2" OnClick="BackButton2_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
