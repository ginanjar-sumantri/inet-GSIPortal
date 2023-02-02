using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class BrandBase : Base
    {
        protected string _pageTitleListLiteral = "List Brand";
        protected string _pageTitleViewLiteral = "Edit Brand";
        protected string _pageTitleAddLiteral = "Add Brand";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listBrandPage = "~/Brand/ListBrand.aspx";
        protected string _viewBrandPage = "~/Brand/ViewBrand.aspx";
        protected string _addBrandPage = "~/Brand/AddBrand.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _brandID = "BrandID";
        public BrandBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}