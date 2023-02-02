using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSIWebsiteCore
{
    public partial class _default : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(this._baseURL + "\\SurveyPoint\\ListSurveyPoint.aspx");
        }
    }
}