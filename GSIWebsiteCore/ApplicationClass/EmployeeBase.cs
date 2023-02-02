using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class EmployeeBase : Base
    {
        protected string _pageTitleListLiteral = "List Employee";
        protected string _pageTitleEditLiteral = "Edit Employee";
        protected string _pageTitleAddLiteral = "Add Employee";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listEmployeePage = "~/Employee/ListEmployee.aspx";
        protected string _viewEmployeePage = "~/Employee/ViewEmployee.aspx";
        protected string _addEmployeePage = "~/Employee/AddEmployee.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _employeeID = "EmployeeID";

        public EmployeeBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}