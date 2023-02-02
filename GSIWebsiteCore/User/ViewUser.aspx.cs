using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;
using System.Web.Security;
using GSI.Authentication;

namespace GSIWebsiteCore.User
{
    public partial class ViewUser : UserBase
    {
        private String _queryString;
        private MembershipService _membershipService = new MembershipService();
        //private string _currPageKey = "CurrentPage";
        //private int _page;
        //private int _maxrow = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleViewLiteral;
                this.BackImageButton.ImageUrl = this._imageURL + "btnBack.png";
                this.BackImageButton.ToolTip = this._toolTipBack;
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
            this.EmailTextBox.Attributes.Add("ReadOnly", "True");
            this.EmailTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.CreationDateTextBox.Attributes.Add("ReadOnly", "True");
            this.CreationDateTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.IsApprovedTextBox.Attributes.Add("ReadOnly", "True");
            this.IsApprovedTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.IsLockedOutTextBox.Attributes.Add("ReadOnly", "True");
            this.IsLockedOutTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.IsOnlineTextBox.Attributes.Add("ReadOnly", "True");
            this.IsOnlineTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.LastLoginDateTextBox.Attributes.Add("ReadOnly", "True");
            this.LastLoginDateTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.LastActivityDateTextBox.Attributes.Add("ReadOnly", "True");
            this.LastActivityDateTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.LastLockoutDateTextBox.Attributes.Add("ReadOnly", "True");
            this.LastLockoutDateTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.LastPasswordChangedDateTextBox.Attributes.Add("ReadOnly", "True");
            this.LastPasswordChangedDateTextBox.Attributes.Add("Style", "background-color: #CCCCCC");

        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            MembershipUser _membershipUser = this._membershipService.GetUser(this._nvcExtractor.GetValue(this._userName), true);

            this.UserNameTextBox.Text = _membershipUser.UserName;
            this.EmailTextBox.Text = _membershipUser.Email;
            this.CreationDateTextBox.Text = Convert.ToString(_membershipUser.CreationDate);
            if (_membershipUser.IsApproved == true)
            {
                this.IsApprovedTextBox.Text = "Active";
            }
            else
            {
                this.IsApprovedTextBox.Text = "Not Active";
            }
            this.IsLockedOutTextBox.Text = Convert.ToString(_membershipUser.IsLockedOut);
            this.IsOnlineTextBox.Text = Convert.ToString(_membershipUser.IsOnline);
            this.LastLoginDateTextBox.Text = Convert.ToString(_membershipUser.LastLoginDate);
            this.LastActivityDateTextBox.Text = Convert.ToString(_membershipUser.LastActivityDate);
            this.LastLockoutDateTextBox.Text = Convert.ToString(_membershipUser.LastLockoutDate);
            this.LastPasswordChangedDateTextBox.Text = Convert.ToString(_membershipUser.LastPasswordChangedDate);
        }

        protected void BackImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listUserPage);
        }

    }
}
