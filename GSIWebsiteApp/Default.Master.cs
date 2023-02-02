using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using Microsoft.Security.Application;
using Microsoft.Security.Application.SecurityRuntimeEngine;

namespace GSIWebsiteApp
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String _sesCustName = "CustName";
            String _sesDisplayUserName = "DisplayName";

            if (HttpContext.Current.Session[_sesCustName] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else
            {
                this.HomeButton.ImageUrl = "contents/images/icon_home_master.png";
                this.ProfileButton.ImageUrl = "contents/images/icon_profile_master.png";
                this.DocumentButton.ImageUrl = "contents/images/icon_folder_master.png";
                this.SettingButton.ImageUrl = "contents/images/icon_setting_master.png";


                if (HttpContext.Current.Session[_sesCustName] != null) this.CustomerLiteral.Text = HttpContext.Current.Session[_sesCustName].ToString();
                else this.CustomerLiteral.Text = "";
                if (HttpContext.Current.Session[_sesDisplayUserName] != null) this.userLiteral.Text = HttpContext.Current.Session[_sesDisplayUserName].ToString();
                else this.userLiteral.Text = "";

                List<MsOrderType> _msOrderType = new OrderTypeBL().GetListOrderType();
                this.AddPersonalLink.NavigateUrl = "~/Order/ViewOrder.aspx?Type=" + _msOrderType[0].OrderTypeID + "," + _msOrderType[0].OrderTypeName + "&OrderId=";
                this.AddCorporateLink.NavigateUrl = "~/Order/ViewOrder.aspx?Type=" + _msOrderType[1].OrderTypeID + "," + _msOrderType[1].OrderTypeName + "&OrderId=";

                DateTime dt = DateTime.Now;
                this.TanggalLabel.Text = dt.ToString("dddd, dd MMMM yyyy"); //String.Format("{0:D}", dt);

                Response.AppendHeader("Refresh", Convert.ToString((HttpContext.Current.Session.Timeout * 60) + 10) + ";URL='../Login.aspx'");
            }
        }
    }
}
