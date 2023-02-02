<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="TestCarousel.aspx.cs" Inherits="GSIWebsiteApp.Testing.TestCarousel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="../contents/jQuery/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../contents/jQuery/jquery.jcarousel.min.js"></script>
    <link type="text/css" rel="stylesheet" href="../contents/skins/tango/skin.css" />
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#mycarousel').jcarousel();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/contents/images/view.jpg" />
    <div id="wrap" runat="server">
        <asp:HiddenField ID="WrapVisibleHiddenField" runat="server" />
        <ul id="mycarousel" class="jcarousel-skin-tango">
            <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                <ItemTemplate>
                    <li id="Li1" runat="server">
                        <asp:Literal ID="PicLiteral" runat="server"></asp:Literal>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <script type="text/javascript">
        //        $('#ctl00_BodyContentPlaceHolder_ImageButton1').click(function () {
        //            $('#ctl00_BodyContentPlaceHolder_wrap').toggle("slow");
        //        });
    </script>
</asp:Content>
