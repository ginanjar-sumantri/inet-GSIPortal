using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GSIWebsiteBase
/// </summary>

namespace GSIWebsiteAppBase
{
    [Microsoft.Security.Application.SecurityRuntimeEngine.SupressAntiXssEncoding()]
    public class Base : System.Web.UI.Page
    {
        protected String _baseURL = HttpContext.Current.Request.ApplicationPath;
        protected String _imageURL = HttpContext.Current.Request.ApplicationPath + "contents/images/";
        protected String _loginURL = HttpContext.Current.Request.ApplicationPath + "Login.aspx";

        protected String _sesCustID = "CustID";
        protected String _sesCustName = "CustName";
        protected String _sesDisplayUserName = "DisplayName";
        protected String _sesUserLoginName = "username";

        // For Search List Order
        protected String _sesOrderNumber = "OrderCode";
        protected String _sesOrderStartDate = "StartDate";
        protected String _sesOrderEndDate = "EndDate";
        protected String _sesOrderType = "OrderType";
        protected String _sesOrderDocStatus = "DocumentStatus";

        protected DateTime _defaultDate = new DateTime(1900, 1, 1);

        public Base()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}