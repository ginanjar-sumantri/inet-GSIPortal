using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class ReportBase : Base
    {
        protected NameValueCollectionExtractor _nvcExtractor;

        protected string _pageTitleListLiteral = "Report";

        // --Link Page--        

        // --ToolTip button--
        protected string _toolTipView = "View";

        // --Query String--
        protected string _regionID = "RegionID";

        public ReportBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}