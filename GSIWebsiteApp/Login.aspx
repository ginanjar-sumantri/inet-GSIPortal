<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GSIWebsiteApp.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--[if IE]><!-->
    <link rel="stylesheet" type="text/css" href="contents/css/ie7.css" />
    <!--<![endif]-->
    <!--[if !IE]><!-->
    <link rel="stylesheet" type="text/css" href="contents/css/firefox.css" />
    <!--<![endif]-->
    <title></title>
</head>
<body>
    <div class="login_borderTop">
    </div>
    <div class="login_container">
        <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 500px;">
            <tr>
                <td align="center">
                    <div class="OuterLogin">
                        <div class="OuterLoginInside">
                            <div class="OuterLoginHeader">
                                <div class="OuterLoginHeaderLeft">
                                </div>
                                <div class="OuterLoginHeaderRight1">
                                </div>
                                <div class="OuterLoginHeaderRight2">                                    
                                </div>
                                <%--<div class="OuterLoginHeaderRight3">
                                    CUSTOMER PORTAL
                                </div>--%>
                            </div>
                            <div class="OuterLoginBody">
                                <div class="OuterLoginBodyWrapper">
                                    <div class="OuterLoginBodyLeft">
                                    </div>
                                    <div class="OuterLoginBodyMiddle">
                                        <asp:Login ID="LoginGSI" runat="server" BorderColor="#CCCC99" BorderStyle="Solid"
                                            BorderWidth="0px" Font-Names="Verdana" Font-Size="10pt" DestinationPageUrl="~/Order/ListOrder.aspx"
                                            FailureText="User Name or Password Invalid" OnLoggedIn="LoginGSI_LoggedIn">
                                            <LayoutTemplate>
                                                <asp:Panel DefaultButton="LoginButton" ID="LoginPanel" runat="server">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <table id="panelLogin" runat="server">
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="3">
                                                                                <tr>
                                                                                    <td colspan="3" style="height: 23px;">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="login_text">
                                                                                    <td align="left">
                                                                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                                                                    </td>
                                                                                    <td align="center" style="width: 15px;">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="UserName" runat="server" Width="250"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginGSI">*</asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="line-height: 10px;">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="login_text">
                                                                                    <td align="left">
                                                                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                                                                    </td>
                                                                                    <td align="center" style="width: 15px;">
                                                                                        :
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="250"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginGSI">*</asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                    <td align="left" colspan="2">
                                                                                        <asp:HyperLink ID="ForgotPasswordHyperLink" runat="server" NavigateUrl="~/ForgotPassword.aspx"
                                                                                            CssClass="login_textWhite">Forgot Your Password ?</asp:HyperLink>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="line-height: 10px;">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                    <td align="left" style="height: 20px;">
                                                                                        <div>
                                                                                            <div class="login_captcha">
                                                                                                <img src="contents/CaptchaImage.aspx" alt="">
                                                                                                <asp:ImageButton ID="RefreshCaptcha" CssClass="btnRefreshCaptcha" runat="server"
                                                                                                    ImageUrl="~/contents/images/login/btnRCaptcha.png" CausesValidation="false" />
                                                                                            </div>
                                                                                            <div class="login_captcha_right">
                                                                                                <div class="login_textWhite">
                                                                                                    <asp:Literal ID="CaptchaLiteral" runat="server">Enter Code :</asp:Literal>
                                                                                                </div>
                                                                                                <div>
                                                                                                    <asp:TextBox ID="CaptchaTextBox" runat="server" Width="120px"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                    </td>
                                                                                    <td align="left" style="height: 45px;">
                                                                                        <asp:ImageButton ID="LoginButton" runat="server" OnClick="LoginButton_Click" ValidationGroup="LoginGSI"
                                                                                            CommandName="Login" ImageUrl="~/contents/images/login/btnLogin.png" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" align="center" class="warningLiteral">
                                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                                <asp:Literal ID="FailureText2" runat="server" EnableViewState="False"></asp:Literal>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </LayoutTemplate>
                                            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                                        </asp:Login>
                                    </div>
                                    <div class="OuterLoginBodyRight">
                                    </div>
                                </div>
                            </div>
                            <div class="OuterLoginFooter">
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div class="recomendedPage">
        Best View Firefox 4 +
    </div>
    <div class="login_borderBottom">
    </div>
</body>
</html>
