using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

/// <summary>
/// Summary description for OrderBase
/// </summary>
namespace GSIWebsiteAppBase
{
    public class OrderResultBase : Base
    {
        protected string _pageTitleLiteralViewResultCompany = "View Result Respondent Company";
        protected string _pageTitleLiteralViewResultPersonal = "View Result Respondent Personal";

        protected string _type = "Type";
        protected string _codeKey = "OrderId";
        protected string _SPid = "SPid";
        protected string _orderSPID = "OrderSpID";
        protected string _orderVersion = "orderVersion";

        // --Url For View Result Photo
        protected String _resultPhotoURL = HttpContext.Current.Request.ApplicationPath + "contents/ResultPhoto/";

        // --Link Page--
        protected string _viewOrderPage = "../Order/ViewOrder.aspx";

        // --view result image preview
        protected String _imgMaxWidth = "360px";
        protected String _imgMaxHeight = "300px";
        protected String _imgThumbWidth = "120px";
        protected String _imgThumbHeight = "100px";

        protected NameValueCollectionExtractor _nvcExtractor;
        public OrderResultBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
