using System;
using System.Web.UI;
using GSI.Common;
using GSI.BusinessRuleCore;
using System.Collections.Generic;
using GSI.Authentication;
using System.Web.Security;
using GSIWebsiteAppBase;
using System.Web;


namespace GSIWebsiteApp.User
{
    public partial class EditUser : UserBase
    {
        private MembershipService _membershipService = new MembershipService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleEditLiteral;
                this.SavePasswordImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SavePasswordImageButton.ToolTip = this._toolTipSave;
                this.SaveEmailImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveEmailImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.SetAttribute();
                this.ShowData(0);
            }
        }

        private void SetAttribute()
        {
            this.UserNameTextBox.Attributes.Add("ReadOnly", "True");
            this.UserNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            MembershipUser _membershipUser = this._membershipService.GetUser(Convert.ToString(HttpContext.Current.Session[_sesUserLoginName]), true);

            this.UserNameTextBox.Text = _membershipUser.UserName;
            this.OldPasswordTextBox.Text = "";
            this.NewPasswordTextBox.Text = "";
            this.ConfirmNewPasswordTextBox.Text = "";
            this.EmailTextBox.Text = _membershipUser.Email;
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData(0);
        }

        protected void SaveEmailButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;
            MembershipUser _membershipUser = this._membershipService.GetUser(Convert.ToString(HttpContext.Current.Session[_sesUserLoginName]), true);

            this.WarningLabel.Text = "";
            _membershipUser.Email = this.EmailTextBox.Text;

            _result = this._membershipService.ChangeEmail(this.UserNameTextBox.Text, this.EmailTextBox.Text);
            if (_result)
            {
                ShowData(0);
                this.WarningLabel.Text = "Your Email Has Been Updated";
            }
            else
            {
                this.WarningLabel.Text = "You Fail Save Email";
            }
        }

        protected void SavePasswordButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;
            MembershipUser _membershipUser = this._membershipService.GetUser(Convert.ToString(HttpContext.Current.Session[_sesUserLoginName]), true);

            this.WarningLabel.Text = "";
            if (this.NewPasswordTextBox.Text == this.ConfirmNewPasswordTextBox.Text)
            {
                _result = _membershipUser.ChangePassword(this.OldPasswordTextBox.Text, this.NewPasswordTextBox.Text);
                if (_result)
                {
                    this.WarningLabel.Text = "Your Password Has Been Updated";
                    ShowData(0);
                }
                else
                {
                    this.WarningLabel.Text = "Incorrect Old Password";
                }

            }
            else
            {
                this.WarningLabel.Text = "Confirm New Password is different";
            }
        }
    }
}
