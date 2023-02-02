using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class SurveyPointBase : Base
    {
        protected string _pageTitleLiteral = "Survey Point List";
        protected string _pageTitleViewLiteral = "View Survey Point";

        // --Link Page--
        protected string _listSurveyPoint = "ListSurveyPoint.aspx";
        protected string  _viewSurveyPoint= "ViewSurveyPoint.aspx";

        protected NameValueCollectionExtractor _nvcExtractor;

        protected String _queryString;
        protected String[] _orderType;

        protected string _codeKey = "OrderId";
        protected string _type = "Type";
        protected string _SPid = "SPid";
        protected string _orderSPID = "OrderSpID";
        protected string _template = "Template";
        protected string _workOrderType = "WOType";

        protected string _toolTipView = "View";
        protected string _toolTipAssign = "Assign";
        protected string _toolTipTakeOver = "Take Over";
        protected string _toolTipPublish = "Publish";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipApproveCancel = "Approve Cancel";

        public SurveyPointBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}