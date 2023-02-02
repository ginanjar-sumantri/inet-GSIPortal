<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GSIWebsiteCore.Customer.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>
        CONFIRMATION ORDER</h2>
    <div class="line">
    </div>
    <p>
        Your order is almost finished. Please review the details below and click 'CHECKOUT'
        if all the information is correct. Can use the 'BACK' to make changes to your order
        if necessary.</p>
    <div class="confirm-shopingcart">
        <h3>
            SHOPPING CART</h3>
        <table>
            <tr>
                <td>
                    Product
                </td>
                <td class="style2">
                    Quantity
                </td>
                <td class="style3">
                    Unit Price
                </td>
                <td>
                    Price
                </td>
                <%-- <td>
                        Sale Price
                    </td>--%>
            </tr>
            <tr>
                <td>
                    [NamaProduct]
                </td>
                <td class="style2">
                    <span style="font-size: 12px;">[Qty] pcs </span>
                    <br />
                </td>
                <td class="style3">
                    [UnitPrice]
                </td>
                <td class="style3">
                    [Total Price]
                </td>
                <%--<td class="style3">
                    [SalePrice]                        
                    </td>--%>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <b>SUBTOTAL :</b>
                </td>
                <td>
                    <asp:Label ID="SubTotalLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <b>SHIPPING COST :</b>
                </td>
                <td>
                    <asp:Label ID="OngkirLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    <b>TOTAL :</b>
                </td>
                <td>
                    <asp:Label ID="TotalLabel" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="confirm-email">
        <h3>
            CUSTOMER INFORMATION</h3>
        <div class="line">
        </div>
        <table>
            <tr>
                <td class="left-td">
                    Email
                </td>
                <td class="left-td">
                    <asp:Label ID="EmailLabel" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div class="confirm-shiping">
        <h3>
            BILLING ADDRESS</h3>
        <div class="line">
        </div>
        <table>
            <tr>
                <td class="left-td">
                    First Name
                </td>
                <td class="left-td">
                    [FirstName]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Last Name
                </td>
                <td class="left-td">
                    [LastName]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Address
                </td>
                <td class="left-td">
                    [Address]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Zip Code
                </td>
                <td class="left-td">
                    [ZipCode]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Phone
                </td>
                <td class="left-td">
                    [Phone]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Mobile Phone
                </td>
                <td class="left-td">
                    [MobilePhone]
                </td>
            </tr>
        </table>
    </div>
    <div class="confirm-shiping">
        <h3>
            SHIPPING ADDRESS</h3>
        <div class="line">
        </div>
        <table>
            <tr>
                <td class="left-td">
                    Email
                </td>
                <td class="left-td">
                    [Email]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    First Name
                </td>
                <td class="left-td">
                    [FirstName]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Last Name
                </td>
                <td class="left-td">
                    [LastName]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Address
                </td>
                <td class="left-td">
                    Address
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Province
                </td>
                <td class="left-td">
                    [Province]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Zip Code
                </td>
                <td class="left-td">
                    [ZipCode]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Company
                </td>
                <td class="left-td">
                    [Company]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Phone
                </td>
                <td class="left-td">
                    [Phone]
                </td>
            </tr>
            <tr>
                <td class="left-td">
                    Mobile Phone
                </td>
                <td class="left-td">
                    [MobilePhone]
                </td>
            </tr>
        </table>
    </div>
    <h2>
        PAYMENT</h2>
    <br />
    Payment method
    <select name="SelectName">
    </select>
    <span class="error-message"></span>
    <br />
    <div class="msg_list">
        <input type="checkbox" />
        <a class="inline" href="#termsconditions">Terms & Conditions</a> <span class="error-message">
            
        </span>
        <div style="display: none;">
            <div id="Div1">
                <cms:genericcontent id="cmsTermCondition" runat="server" contentid="48" />
            </div>
        </div>
    </div>
    <div class="billing-address">
        <div class="checkout-button-section">
            <input type="button" value="Back"/>
            <input type="button" value="CheckOut"/>
        </div>
    </div>
    </form>
</body>
</html>
