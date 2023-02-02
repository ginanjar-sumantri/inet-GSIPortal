using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Authentication;
using GSIWebsiteCore.User;

namespace GSIWebsiteCore.CustomerUser
{
    public partial class ViewCustomerUser : CustomerUserBase
    {

        private CustomerUserBL _msCustomerUserBL = new CustomerUserBL();
        private CustomerBL _msCustomerBL = new CustomerBL();
        private MembershipService _membershipService = new MembershipService();
        private String _queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropImageButton.Attributes.Add("OnClick", "return Drop();");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleEditLiteral;
                this.InitializeData();
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;


                if ((this._nvcExtractor.GetValue(this._customerUserID) != ""))
                {
                    this.CustomerIDDDL();
                    this.MembershipUserDDL();
                    this.ShowData();
                }

            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._customerUserID);
        }

        private void ShowData()
        {
            MsCustomerUser _msCustomerUser = this._msCustomerUserBL.GetMsCustomerUserByCustomerUserID(this._nvcExtractor.GetValue(this._customerUserID));

            this.CustomerIDDropDownList.SelectedValue = _msCustomerUser.CustomerID.ToString();
            this.DisplayNameTextBox.Text = _msCustomerUser.DisplayName;
            this.UserEmailAddressTextBox.Text = _msCustomerUser.UserEmailAddress;
            this.RemarkTextBox.Text = _msCustomerUser.Remark;
            this.MembershipUserDropDownList.SelectedValue = _msCustomerUser.MembershipUserName;
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

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._listCustomerUserPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsCustomerUser _mscustomeruser = new MsCustomerUser();
            _mscustomeruser.CustomerUserID = Convert.ToInt64(this._nvcExtractor.GetValue(this._customerUserID));
            _mscustomeruser.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _mscustomeruser.RowStatus = 1;

            _result = this._msCustomerUserBL.DeleteMsCustomerUser(_mscustomeruser);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                //this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listCustomerUserPage);
            }
            else
            {
                //this.WarningLabel.Text = "You Failed Delete Data";
                this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                ErrorHandler.ErrorMessage = "";
            }

        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.EditCustomerUser();
        }

        protected void EditCustomerUser()
        {
            Boolean _result = false;

            MsCustomerUser _msCustomerUser = this._msCustomerUserBL.GetMsCustomerUserByCustomerUserID(this._nvcExtractor.GetValue(this._customerUserID));

            if (this.CustomerIDDropDownList.SelectedValue != "null")
            {
                _msCustomerUser.CustomerID = Convert.ToInt64(this.CustomerIDDropDownList.SelectedValue);
            }
            else
            {
                _msCustomerUser.CustomerID = (Int64?)null;
            }
            _msCustomerUser.DisplayName = this.DisplayNameTextBox.Text;
            _msCustomerUser.UserEmailAddress = this.UserEmailAddressTextBox.Text;
            if (this.MembershipUserDropDownList.SelectedValue != "null")
            {
                _msCustomerUser.MembershipUserName = Convert.ToString(this.MembershipUserDropDownList.SelectedValue);
            }
            else
            {
                _msCustomerUser.MembershipUserName = Convert.ToString(null);
            }
            _msCustomerUser.Remark = this.RemarkTextBox.Text;
            //_msCustomerUser.CreatedBy = HttpContext.Current.Session[this._sesCustID].ToString();
            //_msCustomerUser.CreatedDate = DateTime.Now;
            _msCustomerUser.RowStatus = 0;
            _msCustomerUser.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _msCustomerUser.ModifiedDate = this._defaultDate;



            _msCustomerUser.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _msCustomerUser.ModifiedDate = DateTime.Now;

            _result = this._msCustomerUserBL.UpdateCustomerUser(_msCustomerUser);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listCustomerUserPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Edit Data";
            }
        }
    }
}
