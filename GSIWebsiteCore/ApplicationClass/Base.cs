using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
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
        protected String _sesUserLoginName = "Username";

        //For Search Survey Point List
        protected String _sesOrderCode = "OrderCode";
        protected String _sesOrderSPName = "SPName";
        protected String _sesSPStatus = "SPStatus";
        protected String _sesDateStart = "StartDate";
        protected String _sesDateEnd = "EndDate";
        protected String _sesReligion = "Religion";

        //For Search Work Order List
        protected String _sesWOCode = "WOCode";
        protected String _sesWOStatus = "WOStatus";
        protected String _sesWODateStart = "WOStartDate";
        protected String _sesWODateEnd = "WOEndDate";
        protected String _sesWOSurveryorName = "WOSurveyorName";

        protected DateTime _defaultDate = new DateTime(1900, 1, 1);

        public Base()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}