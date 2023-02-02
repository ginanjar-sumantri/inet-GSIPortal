using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class ZipCodeBase : Base
    {
        protected NameValueCollectionExtractor _nvcExtractor;

        protected string _pageTitleListLiteral = "List Region";
        protected string _pageTitleAddLiteral = "Add Zipcode";        

        // --Link Page--
        protected string _listRegionPage = "~/ZipCode/ListRegion.aspx";
        protected string _addZipCodePage = "~/ZipCode/AddZipCode.aspx";

        // --ToolTip button--
        protected string _toolTipEdit = "Edit";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";

        // --Query String--
        protected string _regionID = "ZipCodeID";

        public ZipCodeBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}