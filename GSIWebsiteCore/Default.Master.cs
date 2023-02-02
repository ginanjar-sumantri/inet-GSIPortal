using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Security.Application;
using Microsoft.Security.Application.SecurityRuntimeEngine;


namespace GSIWebsiteCore
{
    [Microsoft.Security.Application.SecurityRuntimeEngine.SupressAntiXssEncoding()]
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.HomeButton.ImageUrl = "contents/images/icon_home_master.png";

            this.userLiteral.Text = Request.ServerVariables["LOGON_USER"];
            
            DateTime dt = DateTime.Now;
            this.TanggalLabel.Text = dt.ToString("dddd, dd MMMM yyyy"); //String.Format("{0:D}", dt);

            this.DashboardLink.Attributes.Add("OnClick", "window.open('../Dashboard/DashboardMonitor.aspx','_monitor','fullscreen=yes,toolbar=0,location=0,status=0,scrollbars=1')");
        }
    }
}