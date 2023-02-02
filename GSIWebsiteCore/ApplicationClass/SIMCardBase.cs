using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class SIMCardBase : Base
    {
        protected string _pageTitleListLiteral = "List SIM Card";
        protected string _pageTitleViewLiteral = "Edit SIM Card";
        protected string _pageTitleAddLiteral = "Add SIM Card";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listSIMCardPage = "~/SIMCard/ListSIMCard.aspx";
        protected string _viewSIMCardPage = "~/SIMCard/ViewSIMCard.aspx";
        protected string _addSIMCardPage = "~/SIMCard/AddSIMCard.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _sIMCardID = "SIMCardID";
        public SIMCardBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}