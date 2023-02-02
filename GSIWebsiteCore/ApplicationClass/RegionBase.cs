using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class RegionBase : Base
    {
        protected NameValueCollectionExtractor _nvcExtractor;

        protected string _pageTitleListLiteral = "List Region";
        protected string _pageTitleViewLiteral = "Edit Region";
        protected string _pageTitleAddLiteral = "Add Region";

        // --Link Page--
        protected string _listRegionPage = "~/Region/ListRegion.aspx";
        protected string _viewRegionPage = "~/Region/ViewRegion.aspx";
        protected string _addRegionPage = "~/Region/AddRegion.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";

        // --Query String--
        protected string _regionID = "RegionID";

        public RegionBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}