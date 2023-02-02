<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewResultCompany.aspx.cs" Inherits="GSIWebsiteApp.OrderResult.ViewResultCompany" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/javascripts/JScript.js"></script>
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
    <%--JCarousel1--%>
    <link rel="stylesheet" href="../contents/jQuery/resources/css/skin.css" type="text/css"
        media="screen" />
    <script type="text/javascript" src="../contents/jQuery/jquery-1.3.2.js"> </script>
    <script type="text/javascript" src="../contents/jQuery/jquery.jcarousel.min.js"> </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#mycarousel').jcarousel();
            jQuery('#mycarousel1').jcarousel();
            jQuery('#mycarousel2').jcarousel();
            jQuery('#mycarousel3').jcarousel();
            jQuery('#mycarousel4').jcarousel();
            jQuery('#mycarousel5').jcarousel();
            jQuery('#mycarousel6').jcarousel();
            jQuery('#mycarousel7').jcarousel();
            jQuery('#mycarousel8').jcarousel();
        });
    </script>
    <%--Tabs--%>
    <script src="../contents/jQuery/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../contents/jQuery/jquery.ui.tabs.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="../contents/jQuery/resources/css/demos.css" />
    <link type="text/css" rel="stylesheet" href="../contents/jQuery/resources/css/jquery.ui.tabs.css" />
    <link type="text/css" rel="stylesheet" href="../contents/jQuery/resources/css/jquery.ui.theme.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#tabs").tabs();
        });
    </script>
    <%--LightBox--%>
    <script type="text/javascript">
        !window.jQuery && document.write('<script src="../contents/jQuery/jquery-1.4.3.min.js"><\/script>');
    </script>
    <script type="text/javascript" src="../contents/jQuery/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../contents/jQuery/resources/css/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("a.example1").fancybox({ 'type': 'image' });
            $("a.example2").fancybox({ 'type': 'image' });
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
    <asp:Panel runat="server" ID="Panel1">
        <table cellpadding="3" cellspacing="0" width="75%" border="0">
            <tr>
                <td>
                    <asp:Image runat="server" ID="iconImage" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                    <b>
                        <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                    </b>
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="color: #B3B3B3;" />
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:Label ID="WarningLabel" CssClass="warning" runat="server"></asp:Label>
                                <asp:HiddenField ID="OrderIdHiddenField" runat="server" />
                                <asp:HiddenField ID="SPidHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderTypeIdHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderSPIDHiddenField" runat="server" />
                                <asp:HiddenField ID="OrderStatusHiddenField" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="formTextColor">
                                Company Name
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="CompanyLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Business Form
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="BusinessFormLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <div class="formTextColor">
                                    Company Address
                                </div>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td class="formLabelColor">
                                            <asp:Literal ID="CompanyAddressLiteral" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="formLabelColor">
                                            <table>
                                                <tr>
                                                    <td valign="top" style="padding-right: 3px;">
                                                        Clue
                                                    </td>
                                                    <td class="clueLabel" style="padding-left: 8px;">
                                                        <asp:Literal ID="ClueLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="formLabelColor">
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Zip Code
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="ZipCodeLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Company Age
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="CompanyAgeLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <%--<tr>
                        <td class="formTextColor">
                            Line Of Business
                        </td>
                        <td class="formLabelColor">
                            <asp:Literal ID="LineOfBusinessLiteral" runat="server"></asp:Literal>
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="formTextColor">
                                Company Condition
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="CompanyConditionLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Position
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="PositionLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor">
                                Working Period
                            </td>
                            <td class="formLabelColor">
                                <asp:Literal ID="WorkingPeriodLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="formTextColor" valign="top">
                                Remark
                            </td>
                            <td>
                                <asp:TextBox ID="RemarkTextBox" runat="server" Height="180px" TextMode="MultiLine"
                                    Width="255px" BackColor="#CCCCCC" CssClass="Multiline"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="accordion">
                        <table>
                            <tr>
                                <td>
                                    <div class="headerAccordion">
                                        <div>
                                            <div style="float: left; color: #ffffff; margin-left: 3px;">
                                                <asp:Image runat="server" ID="Image2" ImageUrl="~/contents/images/icon_blue.png" />
                                                Photo
                                            </div>
                                        </div>
                                    </div>
                                    <div class="ContentAccordion">
                                        <div class="demo" id="DivAdditionalPhoto" runat="server">
                                            <ul id="mycarousel" class="jcarousel-skin-tango">
                                                <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                                                    <ItemTemplate>
                                                        <li>
                                                            <asp:Literal ID="LightBoxLiteral" runat="server"></asp:Literal>
                                                            <asp:Literal ID="CloseLightBoxLiteral" runat="server"></asp:Literal>
                                                            <asp:Literal ID="GoogleMapsLiteral" runat="server"></asp:Literal>
                                                            <asp:Literal ID="CloseGoogleMapsLiteral" runat="server"></asp:Literal>
                                                            <asp:Image ID="RemarkImage" runat="server" />
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: right; background-image: url(../contents/images/icon_down.png);">
                                    </div>
                                    <div class="accordion">
                                        <div class="headerAccordion">
                                            <div style="float: left;">
                                                <div style="float: left; color: #ffffff;">
                                                    <asp:Image runat="server" ID="Image3" ImageUrl="~/contents/images/icon_blue.png" />
                                                    Required Document Photo
                                                </div>
                                                <div style="float: right; background-image: url(../contents/images/icon_down.png);">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="ContentAccordion">
                                            <div class="demo" style="width: 519px; font-size: 8pt; font-weight: bold;">
                                                <div id="tabs">
                                                    <ul style="height: 27PX;">
                                                        <asp:Repeater ID="DocumentTypeListRepeater" runat="server" OnItemDataBound="DocumentTypeListRepeater_OnItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="TabLiteral" runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                    <asp:Repeater ID="ContentListRepeater" runat="server" OnItemDataBound="ContentListRepeater_OnItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="OpendivContent" runat="server"></asp:Literal>
                                                            <asp:Literal ID="CaroStartLiteral" runat="server"></asp:Literal>
                                                            <asp:Repeater ID="DetailDocumentListRepeater" runat="server" OnItemDataBound="DetailDocumentListRepeater_OnItemDataBound">
                                                                <ItemTemplate>
                                                                    <li>
                                                                        <asp:Literal ID="ImageDocLiteral" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="CloseImageDocLiteral" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="GoogleMapsLiteral2" runat="server"></asp:Literal>
                                                                        <asp:Literal ID="CloseGoogleMapsLiteral2" runat="server"></asp:Literal>
                                                                        <asp:Image ID="RemarkImage2" runat="server" />
                                                                    </li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:Literal ID="CaroEndLiteral" runat="server"></asp:Literal>
                                                            <asp:Literal ID="CloseDivContent" runat="server"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="ButtonPanel">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="BackButton" runat="server" OnClick="BackButton_Click1" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ComplaintButton" runat="server" OnClick="ComplaintButton_Click" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="PreviewImageButton" runat="server" OnClick="PreviewImageButton_Click" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="PreviewWithImageButton" runat="server" OnClick="PreviewWithImageButton_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel runat="server" ID="NotePanel">
                                        <fieldset>
                                            <legend>Note Complaint</legend>
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox runat="server" ID="NoteComplaintTextBox" TextMode="MultiLine" Height="150px"
                                                            Width="300px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="ProceedImageButton" runat="server" OnClick="ProceedImageButton_Click" />
                                                                    <asp:Image ID="LoadingImage" runat="server" ImageUrl="~/contents/images/ajax-loader.gif" />
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="CancelImageButton" runat="server" OnClick="CancelImageButton_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Literal ID="SliderScriptLiteral" runat="server"></asp:Literal>
        <%--<script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('.slider-stage').carousel('.previous', '.next');
            //            jQuery('#viewport').carousel('#simplePrevious', '#simpleNext');
        });
    </script>--%>
        <%--batas--%>
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
        </script>
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel2">
        <table cellpadding="3" cellspacing="0" width="100%" border="0">
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" Height="800px" Width="800px" padding-top="6px"
                        runat="server">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
