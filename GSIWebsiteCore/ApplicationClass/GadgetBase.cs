using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class GadgetBase : Base
    {
        protected string _pageTitleListLiteral = "List Gadget";
        protected string _pageTitleEditLiteral = "Edit Gadget";
        protected string _pageTitleAddLiteral = "Add Gadget";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listGadgetPage = "~/Gadget/ListGadget.aspx";
        protected string _viewGadgetPage = "~/Gadget/ViewGadget.aspx";
        protected string _addGadgetPage = "~/Gadget/AddGadget.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _gadgetID = "GadgetID";

        public GadgetBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}