using System;
using GSI.Common;
using System.Web;

/// <summary>
/// Summary description for OrderBase
/// </summary>
namespace GSIWebsiteAppBase
{
    public class OrderBase : Base
    {
        // --Page Title--
        protected string _pageTitleLiteral = "Order";
        protected string _pageTitleLiteralViewOrder = "View Order";
        protected string _pageTitleLiteralAddSurveyPoint = "Add Survey Point";        
        protected string _pageTitleLiteralOrderConfirmation = "Order Confirmation";

        // --Link Page--
        protected string _listOrderPage = "ListOrder.aspx";
        protected string _viewOrderPage = "ViewOrder.aspx";
        protected string _confirmationOrderPage = "OrderConfirmation.aspx";

        // --Query String--
        protected string _type = "Type";
        protected string _codeKey = "OrderId";
        protected string _SPid = "SPid";
        protected string _orderSPID = "OrderSpID";
        protected string _orderVersion = "orderVersion";
        protected string _warning = "warning";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipResult = "Result";
        protected string _toolTipSubmit = "Submit";
        protected string _toolTipAssign = "Assign";

        // --Url For View Result
        protected String _viewResultURL = HttpContext.Current.Request.ApplicationPath + "OrderResult/";

        protected NameValueCollectionExtractor _nvcExtractor;
        protected String _queryString;
        protected String[] _orderType;
                
        public OrderBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
