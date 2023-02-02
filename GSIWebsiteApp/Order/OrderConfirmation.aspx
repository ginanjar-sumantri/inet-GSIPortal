<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="OrderConfirmation.aspx.cs" Inherits="GSIWebsiteApp.Order.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        .accordion
        {
            width: 567px;
            border-bottom: solid 1px #c4c4c4;
            border-top: solid 1px #c4c4c4;
        }
        .accordion .headerAccordion
        {
            border-radius: 5px;
            background-image: url(/contents/images/bg_accordion.png);
            background-repeat: repeat-x;
            width: 557px;
            float: left;
            padding: 3px;
            font-size: 9pt;
            cursor: pointer;
            cursor: hand;
            height: 14px;
        }
        
        .accordion .headerAccordion .active
        {
            background-position: right 5px;
        }
        .accordion .ContentAccordion
        {
            background: #CCCCCC;
            margin: 0;
            padding: 7px 7px 7px 7px;
            border-left: solid 1px #c4c4c4;
            border-right: solid 1px #c4c4c4;
            width: 542px;
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
            width: 140px;
            font-weight: bold;
        }
        .textSuperPoint
        {
            background-color: #F2F2F2;
            padding: 2px 2px 2px 8px;
            font-family: Arial;
            font-size: 9pt;
            width: 417px;
        }
    </style>
    <script src="../contents/jQuery/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".accordion .headerAccordion:first").addClass("active");
            $(".accordion .ContentAccordion:not(:first)").hide();

            $(".accordion .headerAccordion").click(function () {
                $(this).next(".ContentAccordion").slideToggle("slow")
		.siblings(".ContentAccordion:visible").slideUp("slow");
                $(this).toggleClass("active");
                $(this).siblings(".headerAccordion").removeClass("active");
            });

        });

        function ChangePic(_prmSubmitButton, _prmCancelButton, _prmLoadingImage, _path) {
            var submitButton = document.getElementById(_prmSubmitButton);
            var cancelButton = document.getElementById(_prmCancelButton);
            var loadingImage = document.getElementById(_prmLoadingImage);

            submitButton.style.visibility = "hidden";
            cancelButton.style.visibility = "hidden";
            loadingImage.style.visibility = "visible";
        }

        function ChangePic1(_prmChangeButton, _prmLoadingImage, _path) {
            var changeButton = document.getElementById(_prmChangeButton);
            var loadingImage = document.getElementById(_prmLoadingImage);

            changeButton.style.visibility = "hidden";
            loadingImage.style.visibility = "visible";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <table cellpadding="3" cellspacing="0" width="75%" border="0">
        <tr>
            <td class="PageLiteral">
                <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                <b>
                    <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                </b>
                <br />
                <hr style="color: #B3B3B3;" />
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="WarningLabel" CssClass="warning" runat="server"></asp:Label>
                                <asp:Label ID="OrderIDLabel" runat="server"></asp:Label>
                                <asp:HiddenField ID="OrderIDHiddenField" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td style="font-family: arial; font-size: 12pt; font-weight: bold;">
                <asp:Label ID="OrderCodeLabel" runat="server"></asp:Label>
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
                                <asp:Label ID="OrderTypeLabel" runat="server" Width="250px"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="formTextColor">
                            Date
                        </td>
                        <td>
                            <div class="formLabelColor">
                                <asp:Label ID="DateLabel" runat="server" Width="250px"></asp:Label>
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
                                <asp:Label ID="NoteLabel" runat="server" Width="250px" Height="200px"></asp:Label>
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
            <td style="font-style: italic; font-family: Arial; font-size: 8pt; color: #C1272D;">
                Click on item to view detail
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PersonalPanel" runat="server">
                    <div class="accordion">
                        <table>
                            <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="headerAccordion">
                                                <div style="float: left;">
                                                    <div style="float: left; color: #ffffff; margin-top: 2px;">
                                                        <asp:Image runat="server" ID="Image2" ImageUrl="~/contents/images/icon_blue.png" />
                                                        <asp:Literal ID="OrderTypeLiteral" runat="server"></asp:Literal>
                                                    </div>
                                                    <div style="float: left; color: Yellow; margin-left: 5px;">
                                                        <asp:Literal ID="SurveyPointTypeLiteral" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                                <div style="float: left; text-align: left; margin-left: 360px; font-style: italic;
                                                    color: #ffffff; font-size: 8pt;">
                                                </div>
                                            </div>
                                            <div class="ContentAccordion" style="display: none;">
                                                <table cellpadding="3px" cellspacing="3px">
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Full Name
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="FullNameLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Status
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="StatusLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Spouse
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="SposeLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Nationality
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="NationalityLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Place Birth
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="PlaceBirthLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Date Of Birth
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="DateOfBirthLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            ID
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="IDLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            ID No
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="IDNoLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Region
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="RegionLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            ID Address
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="IDAddressLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <div class="textViewSuperPoint">
                                                                Current Address</div>
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <div>
                                                                <asp:Literal ID="CurrentAddressLiteral" runat="server"></asp:Literal>
                                                            </div>
                                                            <div style="margin-top: 5px;">
                                                                <div style="float: left; color: #999999; font-weight: bold; font-family: Arial;">
                                                                    CLUE
                                                                </div>
                                                                <div style="background-color: #999999; color: #FFFFFF; float: left; padding: 5px;
                                                                    width: 326px; min-height: 50px; margin-left: 5px; font-size: 8pt;">
                                                                    <asp:Literal ID="ClueLiteral" runat="server"></asp:Literal>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Mobile Phone
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="MobilePhoneLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Home Phone
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="HomePhoneLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Extension
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="ExtentionLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Zip Code
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="ZipCodeLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <div class="textViewSuperPoint">
                                                                Required Document</div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left;">
                                                                <asp:Repeater ID="RequiredDokumentListRepeater" runat="server" OnItemDataBound="RequiredDokumentListRepeater_OnItemDataBound">
                                                                    <ItemTemplate>
                                                                        <div class="textSuperPoint" style="width: 100px; float: left;">
                                                                            <asp:Literal ID="IDTypeLiteral" runat="server"></asp:Literal>
                                                                        </div>
                                                                        <div style="color: #ffffff; padding: 3px; width: 266px; font-size: 9pt; float: left;
                                                                            background-color: #999999;">
                                                                            <div style="float: left;">
                                                                                <div style="float: left;">
                                                                                    Note :
                                                                                </div>
                                                                                <div style="float: left;">
                                                                                    <asp:Literal ID="NoteLiteral" runat="server"></asp:Literal>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Note
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="NoteLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="OfficePanel" runat="server">
                    <div class="accordion">
                        <table>
                            <asp:Repeater ID="OfficeListRepeater" runat="server" OnItemDataBound="OfficeListRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <div class="headerAccordion">
                                                <div style="float: left;">
                                                    <div style="float: left; color: #ffffff; margin-top: 2px;">
                                                        <asp:Image runat="server" ID="Image2" ImageUrl="~/contents/images/icon_blue.png" />
                                                    </div>
                                                    <div style="float: left; color: Yellow; margin-left: 5px;">
                                                        <asp:Literal ID="SurveyPointTypeLiteral2" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                                <div style="float: left; text-align: left; margin-left: 360px; font-style: italic;
                                                    color: #ffffff; font-size: 8pt;">
                                                </div>
                                            </div>
                                            <div class="ContentAccordion">
                                                <table cellpadding="3px" cellspacing="3px">
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Full Name
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="FullNameLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Business Type
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="BusinessTypeLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="textViewSuperPoint">
                                                            Business Line
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="BusinessLineLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Region
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="RegionLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <div class="textViewSuperPoint">
                                                                Address</div>
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <div>
                                                                <asp:Literal ID="AddressLiteral2" runat="server"></asp:Literal>
                                                            </div>
                                                            <div style="margin-top: 5px;">
                                                                <div style="float: left; color: #999999; font-weight: bold; font-family: Arial;">
                                                                    CLUE
                                                                </div>
                                                                <div style="background-color: #999999; color: #FFFFFF; float: left; padding: 5px;
                                                                    width: 326px; min-height: 50px; margin-left: 5px; font-size: 8pt;">
                                                                    <asp:Literal ID="ClueLiteral2" runat="server"></asp:Literal>
                                                                </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Mobile Phone
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="MobilePhoneLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Home Phone
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="HomePhoneLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Extension
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="ExtentsionLiteral" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Zip Code
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="ZipCodeLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <div class="textViewSuperPoint">
                                                                Required Document</div>
                                                        </td>
                                                        <td>
                                                            <div style="float: left;">
                                                                <asp:Repeater ID="RequiredDokumentOfficeListRepeater" runat="server" OnItemDataBound="RequiredDokumentOfficeListRepeater_OnItemDataBound">
                                                                    <ItemTemplate>
                                                                        <div class="textSuperPoint" style="width: 100px; float: left;">
                                                                            <asp:Literal ID="IDTypeLiteral2" runat="server"></asp:Literal>
                                                                        </div>
                                                                        <div style="color: #ffffff; padding: 3px; width: 266px; font-size: 9pt; float: left;
                                                                            background-color: #999999;">
                                                                            <div style="float: left;">
                                                                                <div style="float: left;">
                                                                                    Note :
                                                                                </div>
                                                                                <div style="float: left;">
                                                                                    <asp:Literal ID="NoteLiteral2" runat="server"></asp:Literal>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textViewSuperPoint">
                                                            Note
                                                        </td>
                                                        <td class="textSuperPoint">
                                                            <asp:Literal ID="NoteLiteral2" runat="server"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ProceedButton" runat="server" OnClick="ProceedButton_Click" />
                            <asp:Image ID="LoadingImage" runat="server" ImageUrl="~/contents/images/ajax-loader.gif" />
                        </td>
                        <td>
                            <asp:ImageButton ID="CancelButton" runat="server" OnClick="CancelButton_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
