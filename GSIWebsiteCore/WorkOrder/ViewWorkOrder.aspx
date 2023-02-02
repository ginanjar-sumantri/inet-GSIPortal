<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewWorkOrder.aspx.cs" Inherits="GSIWebsiteCore.WorkOrder.ViewWorkOrder" %>

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
    </style>
    <script src="../contents/jQuery/jquery.js" type="text/javascript"> </script>
    <link rel="stylesheet" href="../contents/css/style.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../contents/jQuery/jquery-1.3.2.js"> </script>
    <script type="text/javascript" src="../contents/jQuery/jquery.infinite-carousel.js"> </script>
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
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#slider-stage').carousel('#previous', '#next');
            jQuery('#slider-stage2').carousel('#previous2', '#next2');
            jQuery('#viewport').carousel('#simplePrevious', '#simpleNext');
        });
    </script>
    <script src="../contents/jQuery/jquery.ui.core.js" type="text/javascript"></script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <div>
        <div style="font-size: 8pt;">
            <table cellpadding="3" cellspacing="0" border="0">
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
                    <td class="line_separator" style="width: 650px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="3" cellspacing="2" border="0">
                            <tr>
                                <td class="formTextColor">
                                    Surveyor Name
                                </td>
                                <td>
                                    <div class="formLabelColor">
                                        <asp:Label ID="SurveyorNameLabel" runat="server" Width="250"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Work Order Code
                                </td>
                                <td>
                                    <div class="formLabelColor">
                                        <asp:Label ID="WorkOrderCodeLabel" runat="server" Width="250"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Date
                                </td>
                                <td class="formLabelColor">
                                    <asp:Label ID="DateLabel" runat="server" Width="250"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Work Order Status</div>
                                </td>
                                <td class="formLabelColor">
                                    <asp:Label ID="WorkOrderStatusLabel" runat="server" Width="250" ReadOnly="true" BackColor="#CCCCCC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div class="formTextColor">
                                        Remark</div>
                                </td>
                                <td class="formLabelColor">
                                    <asp:Label ID="RemarkLabel" runat="server" Width="250" ReadOnly="true" Height="100px"
                                        BackColor="#CCCCCC"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div>
        <br />
    </div>
    <div style="float: left;">
        <fieldset>
            <legend class="PageLiteral" style="font-size: 10pt;"><b>
                <asp:Image runat="server" ID="Image1" ImageUrl="~/contents/images/icon_blue.png" />
                View Result Respondent Personal</b></legend>
            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                <tr>
                    <td>
                        <div>
                            <table>
                                <%--     <tr>
                                    <td class="PageLiteral" style="font-size: 10pt;">
                                        <asp:Image runat="server" ID="Image1" ImageUrl="~/contents/images/icon_blue.png" />&nbsp
                                        <b>View Result Respondent Personal </b>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="OrderIdHiddenField" runat="server" />
                                        <asp:HiddenField ID="SPidHiddenField" runat="server" />
                                        <asp:HiddenField ID="OrderTypeIdHiddenField" runat="server" />
                                        <asp:HiddenField ID="OrderSPIDHiddenField" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td class="formTextColor">
                                        Full Name
                                    </td>
                                    <td class="formLabelColor">
                                        <asp:Literal ID="SurveyPointNameLiteral" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <div class="formTextColor">
                                            Survey Address
                                        </div>
                                    </td>
                                    <td class="formLabelColor" style="padding-bottom: 3px;">
                                        <div>
                                            <asp:Literal ID="HomeAddressLiteral" runat="server" />
                                        </div>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td valign="top" style="padding-right: 3px;">
                                                        Clue
                                                    </td>
                                                    <td valign="top" class="clueLabel" style="padding-left: 8px; color: #ffffff; width: 205px;
                                                        height: 60px;">
                                                        <asp:Literal ID="ClueLiteral" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextColor">
                                        Zip Code
                                    </td>
                                    <td class="formLabelColor">
                                        <asp:Literal ID="ZipCodeLiteral" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="formTextResult">
                                    Result
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Resident Status
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="HouseStatusLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Lenght of Stay
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="LengthOfStayLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Resident Condition
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="ResidenceConditionsLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Environment Condition
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="EnvironmentalConditionsLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Building Area
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="BuildingAreaLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Personal Character
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="PersonalCharacterLiteral" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextColor">
                                    Others
                                </td>
                                <td class="formLabelColor">
                                    <asp:Literal ID="OthersLiteral" runat="server" />
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
                                    <div class="accordion">
                                        <div class="headerAccordion">
                                            <div style="float: left;">
                                                <div style="float: left; color: #ffffff;">
                                                    <asp:Image runat="server" ID="Image3" ImageUrl="~/contents/images/icon_blue.png" />
                                                    Additional Photo
                                                </div>
                                                <div style="float: right; background-image: url(../contents/images/icon_down.png);">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="ContentAccordion" style="display: none;">
                                            <div class="demo">
                                                <div id="sliderBloc">
                                                    <a id="previous">Previous</a>
                                                    <div style="" id="slider-stage">
                                                        <div style="width: 512px;" id="slider-list">
                                                            <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <div class="theme">
                                                                        <asp:Image ID="ImageLiteral" runat="server" /><span class="changeTheme"><asp:Label
                                                                            ID="SpanLabel" runat="server"></asp:Label></span>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                    <a id="next">Next</a>
                                                </div>
                                            </div>
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
                                                    <asp:Image runat="server" ID="Image4" ImageUrl="~/contents/images/icon_blue.png" />
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
                                                        <%-- <asp:Repeater ID="DocumentTypeListRepeater" runat="server" OnItemDataBound="DocumentTypeListRepeater_OnItemDataBound">--%>
                                                        <asp:Repeater ID="DocumentTypeListRepeater" runat="server">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="TabLiteral" runat="server"></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </ul>
                                                    <%--   <asp:Repeater ID="ContentListRepeater" runat="server" OnItemDataBound="ContentListRepeater_OnItemDataBound">--%>
                                                    <asp:Repeater ID="ContentListRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="OpendivContent" runat="server"></asp:Literal>
                                                            <div class="demo">
                                                                <div id="sliderBloc2">
                                                                    <a id="previous2">Previous</a>
                                                                    <div style="" id="slider-stage2">
                                                                        <div style="width: 512px;" id="slider-list2">
                                                                            <%--<asp:Repeater ID="DetailDocumentListRepeater" runat="server" OnItemDataBound="DetailDocumentListRepeater_OnItemDataBound">--%>
                                                                            <asp:Repeater ID="DetailDocumentListRepeater" runat="server">
                                                                                <ItemTemplate>
                                                                                    <div class="theme">
                                                                                        <asp:Image ID="DocDetailImage" runat="server" /><span class="changeTheme"><asp:Label
                                                                                            ID="SpanLabel" runat="server"></asp:Label></span>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </div>
                                                                    </div>
                                                                    <a id="next2">Next</a>
                                                                </div>
                                                            </div>
                                                            <asp:Literal ID="CloseDivContent" runat="server"></asp:Literal>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="BackImageButton" runat="server" OnClick="BackImageButton_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
