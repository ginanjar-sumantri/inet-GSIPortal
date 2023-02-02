using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class CustomerUserBase : Base
    {
        protected string _pageTitleListLiteral = "List Customer User";
        protected string _pageTitleEditLiteral = "Edit Customer User";
        protected string _pageTitleAddLiteral = "Add Customer User";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listCustomerUserPage = "~/CustomerUser/CustomerUser.aspx";
        protected string _addCustomerUserPage = "~/CustomerUser/AddCustomerUser.aspx";


        // --ToolTip button--

        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";

        protected string _pageTitleLiteral = "CustomerUser";



        // --Link Page--
        protected string _viewCustomerUserPage = "~/CustomerUser/ViewCustomerUser.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";

        // --Query String--
        protected string _type = "Type";
        protected string _customerUserID = "CustomerUserID";


        public CustomerUserBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
