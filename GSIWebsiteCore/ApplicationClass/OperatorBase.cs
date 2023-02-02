using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class OperatorBase : Base
    {
        protected string _pageTitleListLiteral = "List Operator";
        protected string _pageTitleViewLiteral = "Edit Operator";
        protected string _pageTitleAddLiteral = "Add Operator";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listOperatorPage = "~/Operator/ListOperator.aspx";
        protected string _viewOperatorPage = "~/Operator/ViewOperator.aspx";
        protected string _addOperatorPage = "~/Operator/AddOperator.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _operatorID = "OperatorID";
        public OperatorBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}