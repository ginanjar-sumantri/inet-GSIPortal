<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesAccordion.aspx.cs" Inherits="GSIWebsiteApp.Testing.TesAccordion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 10px auto;
            width: 570px;
            font: 75%/120% Arial, Helvetica, sans-serif;
        }
        .accordion
        {
            width: 480px;
            border-bottom: solid 1px #c4c4c4;
        }
        .accordion h3
        {
            background: #e9e7e7 url(images/arrow-square.gif) no-repeat right -51px;
            padding: 7px 15px;
            margin: 0;
            font: bold 120%/100% Arial, Helvetica, sans-serif;
            border: solid 1px #c4c4c4;
            border-bottom: none;
            cursor: pointer;
        }
        .accordion h3:hover
        {
            background-color: #e3e2e2;
        }
        .accordion h3.active
        {
            background-position: right 5px;
        }
        .accordion p
        {
            background: #f7f7f7;
            margin: 0;
            padding: 10px 15px 20px;
            border-left: solid 1px #c4c4c4;
            border-right: solid 1px #c4c4c4;
        }
    </style>
    <script src="../contents/jQuery/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".accordion h3:first").addClass("active");
            $(".accordion p:not(:first)").hide();

            $(".accordion h3").click(function () {
                $(this).next("p").slideToggle("slow")
		.siblings("p:visible").slideUp("slow");
                $(this).toggleClass("active");
                $(this).siblings("h3").removeClass("active");
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="accordion">
        <h3>
            Question One Sample Text</h3>
        <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante
            at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros.
            Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
        <h3>
            This is Question Two</h3>
        <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante
            at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros.
            Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
        <h3>
            Another Questio here</h3>
        <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante
            at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros.
            Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
        <h3>
            Sample heading</h3>
        <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante
            at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros.
            Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
        <h3>
            Sample Question Heading</h3>
        <p>
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Morbi malesuada, ante
            at feugiat tincidunt, enim massa gravida metus, commodo lacinia massa diam vel eros.
            Proin eget urna. Nunc fringilla neque vitae odio. Vivamus vitae ligula.</p>
    </div>
    </form>
</body>
</html>
