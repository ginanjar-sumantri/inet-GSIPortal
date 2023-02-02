using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;

namespace GSIWebsiteApp
{
    public partial class Login : LoginBase
    {
        private CustomerBL _customerBL = new CustomerBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("##" + Request.ServerVariables["LOGON_USER"] + "**");

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
            //Session[this._sesUserLoginName] = HttpContext.Current.User.Identity.Name;
            HttpContext.Current.Session[this._sesUserLoginName] = _userName.Text;
            //MsCustomer _msCustomer = new CustomerBL().GetCustomerInfoFromUser(HttpContext.Current.User.Identity.Name);
            MsCustomer _msCustomer = new CustomerBL().GetCustomerInfoFromUser(_userName.Text);
            HttpContext.Current.Session[this._sesCustID] = _msCustomer.CustomerID;
            HttpContext.Current.Session[this._sesCustName] = _msCustomer.CustomerName.ToUpper();
            HttpContext.Current.Session[this._sesDisplayUserName] = _msCustomer.DisplayName;
            //HttpSessionState.Session.Add(name, value);

            //add history login
            Gen_LoginHistory _genLoginHistory = new Gen_LoginHistory();

            _genLoginHistory.UserName = Convert.ToString(HttpContext.Current.Session[this._sesUserLoginName]);

            if (Context.Request.ServerVariables["HTTP_VIA"] != null) // Return real client IP.
            {
                _genLoginHistory.IPAddress = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else//While it can't get the Client IP, it will return proxy IP.
            {
                _genLoginHistory.IPAddress = Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
                //_genLoginHistory.IPAddress = Request.ServerVariables["LOCAL_ADDR"];
                //_genLoginHistory.IPAddress = Request.UserHostAddress;
            }
            _genLoginHistory.Date = DateTime.Now;
            _genLoginHistory.CreatedBy = Request.ServerVariables["LOGON_USER"];
            _genLoginHistory.RowStatus = 0;
            //_genLoginHistory.Timestamp = Request.ServerVariables["LOGON_USER"];

            int _success = this._customerBL.InsertGen_LoginHistory(_genLoginHistory);
            if (_success == -1)
            {
            }
        }

        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
            //this.ClearLabel();

            if (Session["Captcha"] != null)
            {
                TextBox _captchaTB = (TextBox)this.LoginGSI.FindControl("CaptchaTextBox");
                if (_captchaTB.Text.Trim() != "")
                {
                    if (_captchaTB.Text.ToLower() != this.Session["Captcha"].ToString().ToLower())
                    {
                        Response.Redirect(this._loginURL + "?FailureText=Captcha Incorrect, please try again");
                    }
                    else
                    {
                    }
                }
                else
                {
                    this.ClearLabel();
                    Response.Redirect(this._loginURL + "?FailureText=Captcha Incorrect, please try again");
                }
            }
            else
            {
                this.ClearLabel();
                Response.Redirect(this._loginURL);
            }
        }

        private void ClearLabel()
        {
            Literal _failMsg = (Literal)this.LoginGSI.FindControl("FailureText");
            _failMsg.Text = "";
            Literal _failMsg2 = (Literal)this.LoginGSI.FindControl("FailureText2");
            _failMsg2.Text = "";
            TextBox _captchaTextBox = (TextBox)this.LoginGSI.FindControl("CaptchaTextBox");
            _captchaTextBox.Text = "";
        }
    }
}