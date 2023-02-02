using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class BatteryBase : Base
    {
        protected string _pageTitleListLiteral = "List Battery";
        protected string _pageTitleViewLiteral = "Edit Battery";
        protected string _pageTitleAddLiteral = "Add Battery";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listBatteryPage = "~/Battery/ListBattery.aspx";
        protected string _viewBatteryPage = "~/Battery/ViewBattery.aspx";
        protected string _addBatteryPage = "~/Battery/AddBattery.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _batteryID = "BatteryID";
        public BatteryBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}