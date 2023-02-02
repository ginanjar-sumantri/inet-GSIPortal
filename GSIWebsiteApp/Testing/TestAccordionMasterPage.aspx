<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="TestAccordionMasterPage.aspx.cs" Inherits="GSIWebsiteApp.Testing.TestAccordionMasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        .accordion
        {
            width: 560px;
            border-bottom: solid 1px #c4c4c4;
        }
        .accordion .h
        {
            border-radius: 5px;
            background-color: #030A5D;
            width: 557px;
            float: left;
            padding: 3px;
            font-size: 9pt;
            cursor: pointer;
            cursor: hand;
            height: 20px;
        }
        
        .accordion .h.active
        {
            background-position: right 5px;
        }
        .accordion .p
        {
            background: #CCCCCC;
            margin: 0;
            padding: 10px 15px 20px;
            border-left: solid 1px #c4c4c4;
            border-right: solid 1px #c4c4c4;
            width: 525px;
            margin-left: 2px;
            margin-top: 1px;
            clear: both;
        }
        .textViewSuperPoint
        {
            background-color: #F2F2F2;
            padding: 2px 2px 2px 8px;
            font-family: Arial;
            font-size: 9pt;
        }
        .textSuperPoint
        {
            background-color: #F2F2F2;
            padding: 2px 2px 2px 8px;
            font-family: Arial;
            font-size: 9pt;
            width: 417px;
        }
        .proceedButtonOrderConfirmation
        {
            background-image: url(/contents/images/btn_proceed_OrderConfirmation.png);
            background-repeat: no-repeat;
            background-position: center;
            border: medium none;
            cursor: pointer;
            display: block;
            font-size: 0;
            width: 71px;
            height: 24px;
            line-height: 0;
            outline: none;
            text-indent: -999px;
            margin: 1px;
        }
        .cancelButtonOrderConfirmation
        {
            background-image: url(/contents/images/btn_cancel_OrderConfirmation.png);
            background-repeat: no-repeat;
            background-position: center;
            border: medium none;
            cursor: pointer;
            display: block;
            font-size: 0;
            width: 71px;
            height: 24px;
            line-height: 0;
            outline: none;
            text-indent: -999px;
            margin: 1px;
        }
    </style>
    <script src="../contents/jQuery/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".accordion .h:first").addClass("active");
            $(".accordion .p:not(:first)").hide();

            $(".accordion .h").click(function () {
                $(this).next(".p").slideToggle("slow")
		.siblings("p:visible").slideUp("slow");
                $(this).toggleClass("active");
                $(this).siblings(".h").removeClass("active");
            });

        });
    </script>
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
                                    <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="2" width="100%" border="0">
                        <tr>
                            <td class="formTextColor">
                                Order Type
                            </td>
                            <td>
                                <div class="formLabelColor">
                                    <asp:Label ID="OrderTypeID" runat="server" Width="250">Personal</asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Date
                            </td>
                            <td>
                                <div class="formLabelColor">
                                    <asp:Label ID="DateLabel" runat="server" Width="250px">21/5/2001</asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <div class="formTextColor">
                                    Note
                                </div>
                            </td>
                            <td>
                                <div class="formLabelColor">
                                    <asp:Label ID="NoteLabel" runat="server" Width="250px" Height="100px">Some Text</asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="PageLiteral">
                    <asp:Image runat="server" ID="Image1" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                    <b>Survey Point </b>
                    <br />
                </td>
            </tr>
            <tr>
                <td style="font-style: italic; font-family: Arial; font-size: 9pt; color: #C1272D;">
                    Click on item to view detail
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        <div class="accordion">
            <div class="h">
                <div style="float: left;">
                    <div style="float: left; color: #ffffff;">
                        <asp:Image runat="server" ID="Image2" ImageUrl="~/contents/images/icon_blue.png" />
                        GUARANTOR :
                    </div>
                    <div style="float: left; color: Yellow;">
                        Saeful Alif
                    </div>
                </div>
                <div style="float: left; text-align: left; margin-left: 360px; font-style: italic;
                    color: #ffffff;">
                    Draft
                </div>
            </div>
            <div class="p" style="display: none;">
                <table cellpadding="3px" cellspacing="3px">
                    <tr>
                        <td class="textViewSuperPoint">
                            Full Name
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="FullNameLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Status
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Spouse
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Nationality
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Place Birth
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label4" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Date Of Bird
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            ID
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label6" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            ID Address
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label7" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Current Address
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label8" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Zip Code
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label9" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Required Document
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label10" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="textViewSuperPoint">
                            Note
                        </td>
                        <td class="textSuperPoint">
                            <asp:Label ID="Label11" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin: 9px; margin-left: 0px; margin-top: 5px;">
            <div style="float: left;">
                <asp:ImageButton ID="ProceedButton" CssClass="proceedButtonOrderConfirmation" runat="server" /></div>
            <div style="float: left;">
                <asp:ImageButton ID="CancelButton" runat="server" CssClass="cancelButtonOrderConfirmation" /></div>
        </div>
    </div>
</asp:Content>
