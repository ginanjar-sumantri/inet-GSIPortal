<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddZipCode.aspx.cs" Inherits="GSIWebsiteCore.ZipCode.AddZipCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <asp:Literal ID="javascriptReceiver" runat="server"></asp:Literal>
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
    <script language="javascript" type="text/javascript">
        function Drop() {
            var _result = false;

            if (confirm("Are you sure want to drop this zipcode ?") == true) {
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        <asp:UpdatePanel ID="WarningUpdatePanel" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" ID="WarningLabel" CssClass="warning"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
                                    <asp:TextBox ID="RegionCodeTextBox" runat="server" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Name
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="RegionNameTextBox" MaxLength="50" CssClass="TextBox"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                        <table cellpadding="3" cellspacing="0" width="0" border="0">
                            <tr>
                                <td align="right">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td class="pageHeight">
                                                <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                    <table border="0" cellpadding="2" cellspacing="3">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="DataPagerButton" runat="server" CausesValidation="false" OnClick="DataPagerButton_Click" />
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemCommand="DataPagerTopRepeater_ItemCommand"
                                                                OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <td>
                                                                        <asp:LinkButton ID="PageNumberLinkButton" runat="server" CausesValidation="false"></asp:LinkButton>
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
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="ZipCodeUpdatePanel" runat="server">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="2" width="0" border="0">
                                                            <tr class="datatable_header">
                                                                <td style="width: 70px" align="center">
                                                                    <b>Action</b>
                                                                </td>
                                                                <td style="width: 100px" align="center">
                                                                    <b>ZipCode</b>
                                                                </td>
                                                            </tr>
                                                            <asp:Repeater runat="server" ID="ListRepeater" OnItemCommand="ListRepeater_ItemCommand"
                                                                OnItemDataBound="ListRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr runat="server" id="RepeaterItemTemplate" class="datatable_body">
                                                                        <td align="center">
                                                                            <asp:ImageButton runat="server" Text="Edit" ID="EditImageButton" CausesValidation="false" />
                                                                            <asp:ImageButton runat="server" ID="DeleteImageButton" CausesValidation="false" />
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Literal runat="server" ID="ZipCodeLiteral"></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
                                                                <asp:Button ID="DataPagerBottomButton" CausesValidation="false" runat="server" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <asp:Repeater EnableViewState="true" ID="DataPagerBottomRepeater" runat="server"
                                                                OnItemCommand="DataPagerTopRepeater_ItemCommand" OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <td>
                                                                        <asp:LinkButton ID="PageNumberLinkButton" runat="server" CausesValidation="false"></asp:LinkButton>
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
                        &nbsp;
                        <table>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="EditUpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Zip Code :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="ZipCodeEditTextBox" MaxLength="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ZipCodeEditRequiredFieldValidator" runat="server"
                                                            ErrorMessage="ZipCode Must Be Filled" Text="*" ControlToValidate="ZipCodeEditTextBox"
                                                            Display="Dynamic" CssClass="warning"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="RegionZipCodeIDHiddenField" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ImageButton runat="server" ID="Save2ImageButton" OnClick="Save2ImageButton_Click" />
                                                        <asp:ImageButton runat="server" ID="Reset2ImageButton" OnClick="Reset2ImageButton_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Save2ImageButton" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="CancelImageButton" OnClick="CancelImageButton_Click"
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
