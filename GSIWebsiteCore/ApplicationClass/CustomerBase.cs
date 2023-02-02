using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class CustomerBase :Base
    {
          protected string _pageTitleListLiteral = "List Customer";
        protected string _pageTitleEditLiteral = "Edit Customer";
        protected string _pageTitleAddLiteral = "Add Customer";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listCustomerPage = "~/Customer/Customer.aspx";
        protected string _addCustomerPage = "~/Customer/AddCustomer.aspx";
      

        // --ToolTip button--
       
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";
       
        protected string _pageTitleLiteral = "Customer";

       

        // --Link Page--
        protected string _viewCustomerPage = "~/Customer/ViewCustomer.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";

        // --Query String--
        protected string _type = "Type";
        protected string _customerID = "CustomerID";


        public CustomerBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
    }
