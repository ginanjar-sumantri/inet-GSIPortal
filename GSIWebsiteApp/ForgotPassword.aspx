<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="GSIWebsiteApp.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 500px;">
            <tr>
                <td align="center">
                    <asp:PasswordRecovery ID="PasswordRecovery" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                        BorderPadding="5" BorderWidth="1px" Font-Names="Verdana" Font-Overline="False"
                        Font-Size="10pt" UserNameInstructionText="Enter your User Name to receive your password send to your Email."
                        Width="300px" UserNameLabelText="User Name :">
                        <SubmitButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <SuccessTemplate>
                            <table cellpadding="5" cellspacing="0" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" style="width: 300px;">
                                            <tr>
                                                <td style="color: #507CD1; font-weight: bold;">
                                                    Your password has been sent to you.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:HyperLink ID="BackHyperLink" runat="server" NavigateUrl="~/Login.aspx">Back To Login</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </SuccessTemplate>
                        <SuccessTextStyle Font-Bold="True" ForeColor="#507CD1" />
                        <TextBoxStyle Font-Size="0.8em" Width="150px" />
                        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                    </asp:PasswordRecovery>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
