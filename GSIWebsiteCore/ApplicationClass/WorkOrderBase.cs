using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class WorkOrderBase : Base
    {
        // --Page Title--
        protected string _pageTitleLiteral = "Work Order List";
        protected string _pageAddWorkOrderTitleLiteral = "Add Work Order";
        protected string _pageAddWorkOrderAssignTitleLiteral = "Add Work Order - Assign Surveyor";
        protected string _pageTitleViewSPLiteral = "View Survey Point";
        protected string _pageTitleViewWorkOrderLiteral = "View Work Order";
        
        // --Link Page--
        protected string _addWorkOrderPage = "AddWorkOrder.aspx";
        protected string _listWorkOrderPage = "ListWorkOrder.aspx";
        protected string _viewWorkOrderOfficePage = "ViewWorkOrderOffice.aspx";
        protected string _viewWorkOrderPersonalPage = "ViewWorkOrderPersonal.aspx";
        protected string _assignWorkOrderPage = "AddWorkOrderAssign.aspx";
        protected string _viewWorkOrderPageSurveyPoint = "ViewWorkOrderSurveyPoint.aspx";
        
        protected NameValueCollectionExtractor _nvcExtractor;
        
        protected String _queryString;
        protected String[] _orderType;

        // --Query String--
        protected string _codeKey = "Id";
        protected string _type = "Type";
        protected string _SPid = "SPid";
        protected string _orderSPID = "OrderSpID";
        protected string _spType = "SPType";
        protected string _workOrderCode = "OrderCode";
        protected string _workOrderType = "WOType";
        protected string _warning = "warning";


        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipTakeOver = "Take Over";
        protected string _toolTipResult = "Result";
        protected string _toolTipSubmit = "Submit";
        protected string _toolTipAssign = "Assign";
        protected string _toolTipPublish = "Publish";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipApproveCancel = "Approve Cancel";

        protected string _template = "Template";
        protected String _resultPhotoURL = HttpContext.Current.Request.ApplicationPath + "contents/ResultPhoto/";

        // --view result image preview
        protected String _imgMaxWidth = "360px";
        protected String _imgMaxHeight = "300px";
        protected String _imgThumbWidth = "120px";
        protected String _imgThumbHeight = "100px";

        public WorkOrderBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}