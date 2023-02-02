using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;

namespace GSIWebsiteCore
{
    public partial class Login : LoginBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal _failMsg = (Literal)this.LoginGSI.FindControl("FailureText2");
            _failMsg.Text = Request.QueryString["FailureText"];

            if (!Page.IsPostBack)
            {
            }
            else
            {
            }
        }

        protected void LoginGSI_LoggedIn(object sender, EventArgs e)
        {
            TextBox _userName = (TextBox)this.LoginGSI.FindControl("UserName");
            HttpContext.Current.Session[this._sesUserLoginName] = _userName.Text;
            MsCustomer _msCustomer = new CustomerBL().GetCustomerInfoFromUser(_userName.Text);
            HttpContext.Current.Session[this._sesCustID] = _msCustomer.CustomerID;
            HttpContext.Current.Session[this._sesCustName] = _msCustomer.CustomerName.ToUpper();
            HttpContext.Current.Session[this._sesDisplayUserName] = _msCustomer.DisplayName;
            
        }

        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearLabel();

            //if (Session["Captcha"] != null)
            //{
            //    TextBox _captchaTB = (TextBox)this.LoginGSI.FindControl("CaptchaTextBox");
            //    if (_captchaTB.Text.Trim() != "")
            //    {
            //        if (_captchaTB.Text.ToLower() != this.Session["Captcha"].ToString().ToLower())
            //        {
            //            Response.Redirect(this._loginURL + "?FailureText=Captcha Incorrect, please try again");
            //        }
            //        else
            //        {
            //        }
            //    }
            //}
            //else
            //{
            //    Response.Redirect(this._loginURL);
            //}
        }

        private void ClearLabel()
        {
            Literal _failMsg = (Literal)this.LoginGSI.FindControl("FailureText");
            _failMsg.Text = "";
            Literal _failMsg2 = (Literal)this.LoginGSI.FindControl("FailureText2");
            _failMsg2.Text = "";
            //TextBox _captchaTextBox = (TextBox)this.LoginGSI.FindControl("CaptchaTextBox");
            //_captchaTextBox.Text = "";
        }
    }
}