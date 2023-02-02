using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;
using System.Web.Security;
using GSI.Authentication;

namespace GSIWebsiteCore.User
{
    public partial class AddUser : UserBase
    {
        private UserBL _userBL = new UserBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.ClearData();
            }
        }

        private void ClearData()
        {
            this.UserNameTextBox.Text = "";
            this.PasswordTextBox.Text = "";
            this.ReTypePasswordTextBox.Text = "";
            this.EmailTextBox.Text = "";
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listUserPage);
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;
            if (this.PasswordTextBox.Text == this.ReTypePasswordTextBox.Text)
            {
                _result = this._userBL.CreateUser(this.UserNameTextBox.Text, this.PasswordTextBox.Text, this.EmailTextBox.Text);

                if (_result)
                {
                    Response.Redirect(this._listUserPage);
                }
                else
                {
                    this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                }
            }
            else
            {
                this.WarningLabel.Text = "Re Type Password is different";
            }
        }

    }
}
