<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Mobile.aspx.cs" Inherits="GSIWebsiteCore.Mobile.Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <asp:Literal ID="ExampleLiteral" runat="server" Text="Example Mobile System"></asp:Literal>
    &nbsp
    <fieldset runat="server">
        <legend>Movable</legend>
        <table>
            <tr>
                <td>
                    <asp:Button ID="SendButtonResult" Text="Send Survey Point Result to CoreSystem" runat="server"
                        OnClick="SendButtonResult_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="SendAddPhoto" Text="Send Additional Photo" runat="server" OnClick="SendAddPhoto_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="SendReqDocPhoto" Text="Send Req Document" runat="server" OnClick="SendReqDocPhoto_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="Fieldset1" runat="server">
        <legend>Not Movable</legend>
        <table>
            <tr>
                <td>
                    <asp:Button ID="SendSurveyPointNot" Text="Send Survey Point Result to CoreSystem"
                        runat="server" onclick="SendSurveyPointNot_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="SendAddPhotoNot" Text="Send Additional Photo" runat="server" 
                        onclick="SendAddPhotoNot_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="SendReqDocPhotoNot" Text="Send Req Document" runat="server" 
                        onclick="SendReqDocPhotoNot_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
