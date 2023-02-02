<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="GSI.WCFTesting._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        Update Status CoreSystem -><br />
        Type
        <asp:DropDownList ID="SPTypeDropDownList" runat="server">
            <asp:ListItem Value="Movable">Movable</asp:ListItem>
            <asp:ListItem Value="NotMovable">NotMovable</asp:ListItem>
        </asp:DropDownList>
        &nbsp; WorkOrderID
        <asp:TextBox ID="WOIDTextBox1" runat="server" Width="40"></asp:TextBox>
        &nbsp; Status
        <asp:DropDownList ID="StatusDropDownList" runat="server">
            <asp:ListItem Value="WaitingForSurvey">WaitingForSurvey</asp:ListItem>
            <asp:ListItem Value="OnTheWay">OnTheWay</asp:ListItem>
            <asp:ListItem Value="OnTheSpot">OnTheSpot</asp:ListItem>
            <asp:ListItem Value="ReceivedBySystem">ReceivedBySystem</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Change Core Status" OnClick="Button1_Click" />
    </p>
    <p>
        Update CP Status -><br />
        Type
        <asp:DropDownList ID="SPTypeCPDropDownList" runat="server">
            <asp:ListItem Value="Movable">Movable</asp:ListItem>
            <asp:ListItem Value="NotMovable">NotMovable</asp:ListItem>
        </asp:DropDownList>
        &nbsp; OrderSP ID
        <asp:TextBox ID="OrderSPIDTextBox" runat="server" Width="40"></asp:TextBox>
        &nbsp; Status
        <asp:DropDownList ID="StatusCPDropDownList" runat="server">
            <asp:ListItem Value="WaitingForSurvey">WaitingForSurvey</asp:ListItem>
            <asp:ListItem Value="OnTheWay">OnTheWay</asp:ListItem>
            <asp:ListItem Value="OnTheSpot">OnTheSpot</asp:ListItem>
            <asp:ListItem Value="ReceivedBySystem">ReceivedBySystem</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" Text="Change CP Status" OnClick="Button2_Click" />
    </p>
    <p>
        Insert Result From Mobile Not Movable
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
    </p>
    <p>
        <fieldset>
            <legend>Send Email</legend>
            <table cellpadding="2" cellspacing="2">
                <tr>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:TextBox ID="EmailFromTextBox" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        To
                    </td>
                    <td>
                        <asp:TextBox ID="EmailToTextBox" runat="server" Text="supiandi@webaccess.co.id" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Subject
                    </td>
                    <td>
                        <asp:TextBox ID="EmailSubjectTextBox" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Message
                    </td>
                    <td>
                        <asp:TextBox ID="EmailMessageTextBox" TextMode="MultiLine" runat="server" Width="300"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="SendEmailButton" runat="server" Text="Send Email" OnClick="SendEmailButton_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </p>
</asp:Content>
