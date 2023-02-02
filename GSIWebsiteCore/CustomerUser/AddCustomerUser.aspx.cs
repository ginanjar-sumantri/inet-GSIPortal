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
using GSI.BusinessRule;
using GSI.Authentication;
using GSIWebsiteCore.User;

namespace GSIWebsiteCore.CustomerUser
{
    public partial class AddCustomerUser : CustomerUserBase
    {
        private CustomerUserBL _CustomerUserBL = new CustomerUserBL();
        private CustomerBL _msCustomerBL = new CustomerBL();
        private MembershipService _membershipService = new MembershipService();
        //private String _queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;

                this.CustomerIDDDL();
                this.MembershipUserDDL();
                this.ClearData();
            }
        }


        private void ClearData()
        {
            //this.CustomerIDDropDownList.Text = "";
            this.DisplayNameTextBox.Text = "";
            this.UserEmailAddressTextBox.Text = "";
            this.RemarkTextBox.Text = "";
        }

        protected void CustomerIDDDL()
        {
            this.CustomerIDDropDownList.Items.Clear();
            this.CustomerIDDropDownList.DataSource = this._msCustomerBL.GetListFromMsCustomerForDDL();
            this.CustomerIDDropDownList.DataValueField = "CustomerID";
            this.CustomerIDDropDownList.DataTextField = "CustomerName";
            this.CustomerIDDropDownList.DataBind();
            this.CustomerIDDropDownList.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void MembershipUserDDL()
        {
            int _pageIndex = 0;
            int _pageSize = 10000;
            int _row = 0;
            this.MembershipUserDropDownList.Items.Clear();
            this.MembershipUserDropDownList.DataSource = this._membershipService.GetAllUsers(_pageIndex, _pageSize, out _row);
            this.MembershipUserDropDownList.DataValueField = "UserName";
            this.MembershipUserDropDownList.DataTextField = "UserName";
            this.MembershipUserDropDownList.DataBind();
            this.MembershipUserDropDownList.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (this.WarningLabel.Text == "")
            {
                MsCustomerUser _msCustomerUser = new MsCustomerUser();
                if (this.CustomerIDDropDownList.SelectedValue != "null")
                {
                    _msCustomerUser.CustomerID = Convert.ToInt64(this.CustomerIDDropDownList.SelectedValue);
                }
                _msCustomerUser.DisplayName = this.DisplayNameTextBox.Text;
                _msCustomerUser.UserEmailAddress = this.UserEmailAddressTextBox.Text;
                if (this.MembershipUserDropDownList.SelectedValue != "null")
                {
                    _msCustomerUser.MembershipUserName = Convert.ToString(this.MembershipUserDropDownList.SelectedValue);
                }
                _msCustomerUser.Remark = this.RemarkTextBox.Text;
                _msCustomerUser.CreatedBy = HttpContext.Current.User.Identity.Name;
                _msCustomerUser.CreatedDate = DateTime.Now;
                _msCustomerUser.RowStatus = 0;
                _msCustomerUser.ModifiedBy = String.Empty;
                _msCustomerUser.ModifiedDate = this._defaultDate;

                int _success = this._CustomerUserBL.InsertMsCustomerUser(_msCustomerUser);

                if (_success == -1)
                {
                    //this.WarningLabel.Text = "You Success update";
                    Response.Redirect(this._listCustomerUserPage);
                }
                else
                {
                    this.WarningLabel.Text = "You Failed Add Data";
                }
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listCustomerUserPage);
        }
    }
}