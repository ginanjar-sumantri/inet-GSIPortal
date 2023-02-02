using System;
using System.Web.UI;
using GSI.Common;
using GSI.BusinessRuleCore;
using System.Collections.Generic;
using GSI.Authentication;
using System.Web.Security;

namespace GSIWebsiteCore.User
{
    public partial class EditUser : UserBase
    {
        private String _queryString;
        private MembershipService _membershipService = new MembershipService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleEditLiteral;

                this.SavePasswordImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SavePasswordImageButton.ToolTip = this._toolTipSave;
                this.SaveEmailImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveEmailImageButton.ToolTip = this._toolTipSave;
                this.IsApprovedImageButton.ImageUrl = this._imageURL + "btnDisable.png";
                this.SaveEmailImageButton.ToolTip = this._toolTipDisable;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.BackImageButton.ImageUrl = this._imageURL + "btnBack.png";
                this.BackImageButton.ToolTip = this._toolTipBack;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;

                this.SetAttribute();
                this.InitializeData();
                if ((this._nvcExtractor.GetValue(this._userName)) != "")
                {
                    this.ShowData(0);
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._userName);
        }

        private void SetAttribute()
        {
            this.UserNameTextBox.Attributes.Add("ReadOnly", "True");
            this.UserNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            MembershipUser _membershipUser = this._membershipService.GetUser(this._nvcExtractor.GetValue(this._userName), true);

            this.UserNameTextBox.Text = _membershipUser.UserName;
            //this.OldPasswordTextBox.Text = "";
            this.NewPasswordTextBox.Text = "";
            this.ConfirmNewPasswordTextBox.Text = "";
            this.EmailTextBox.Text = _membershipUser.Email;
            if (_membershipUser.IsApproved == true)
            {
                this.IsApprovedImageButton.ImageUrl = this._imageURL + "btnDisable.png";
                this.IsApprovedImageButton.ToolTip = this._toolTipDisable;
            }
            else
            {
                this.IsApprovedImageButton.ImageUrl = this._imageURL + "btnActivate.png";
                this.IsApprovedImageButton.ToolTip = this._toolTipActivate;
            }
        }

        protected void BackImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listUserPage);
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData(0);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;

            _result = this._membershipService.DeleteUser(this._nvcExtractor.GetValue(this._userName), true);

            if (_result == true)
            {
                Response.Redirect(this._listUserPage);
            }
            else
            {
                this.WarningLabel.Text = "You Fail Drop Data";
            }
        }

        protected void SaveEmailButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;
            MembershipUser _membershipUser = this._membershipService.GetUser(this._nvcExtractor.GetValue(this._userName), true);

            this.WarningLabel.Text = "";
            _membershipUser.Email = this.EmailTextBox.Text;

            _result = this._membershipService.ChangeEmail(this.UserNameTextBox.Text, this.EmailTextBox.Text);
            if (_result)
            {
                this.ShowData(0);
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
            UserBL _userBL = new UserBL();
            //MembershipUser _membershipUser = this._membershipService.GetUser(this._nvcExtractor.GetValue(this._userName), true);
            
            this.WarningLabel.Text = "";
            if (this.NewPasswordTextBox.Text == this.ConfirmNewPasswordTextBox.Text)
            {
                _result = _userBL.ChangePasswordWithoutOld(this._nvcExtractor.GetValue(this._userName), this.NewPasswordTextBox.Text);
                if (_result)
                {
                    this.WarningLabel.Text = "Your Password Has Been Updated";
                    this.ShowData(0);
                }
                //else
                //{
                //    this.WarningLabel.Text = "Incorrect Old Password";
                //}
            }
            else
            {
                this.WarningLabel.Text = "Confirm New Password is different";
            }
        }

        protected void IsApprovedImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.WarningLabel.Text = "";
            MembershipUser _membershipUser = this._membershipService.GetUser(this._nvcExtractor.GetValue(this._userName), true);
            if (_membershipUser.IsApproved == true)
            {
                _membershipUser.IsApproved = false;
            }
            else
            {
                _membershipUser.IsApproved = true;
            }
            this._membershipService.UpdateUser(_membershipUser);

            this.ShowData(0);
        }
    }
}
