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

namespace GSIWebsiteCore.Customer
{
    public partial class ViewCustomer : CustomerBase
    {
        private CustomerBL _CustomerBL = new CustomerBL();
        private OrderSurveyPointBL _surveyPointBL = new OrderSurveyPointBL();
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


                if ((this._nvcExtractor.GetValue(this._customerID) != ""))
                {
                    this.ShowData();
                    this.ShowBusinessTypeDDL();
                    this.SetAttribute();

                }
            }
        }

        private void SetAttribute()
        {
            this.PrimaryDateOfBirthTextBox.Attributes.Add("ReadOnly", "True");
            this.PrimaryContactHPTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PrimaryContactHPTextBox.ClientID + "," + this.PrimaryContactHPTextBox.ClientID + ",500" + ")");
            this.PhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhoneTextBox.ClientID + "," + this.PhoneTextBox.ClientID + ",500" + ")");
            this.FaxTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.FaxTextBox.ClientID + "," + this.FaxTextBox.ClientID + ",500" + ")");
            this.PrimaryContactFaxTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PrimaryContactFaxTextBox.ClientID + "," + this.PrimaryContactFaxTextBox.ClientID + ",500" + ")");
            this.PrimaryContactPhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PrimaryContactPhoneTextBox.ClientID + "," + this.PrimaryContactPhoneTextBox.ClientID + ",500" + ")");
            this.PrimaryContactPhoneExtensionTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PrimaryContactPhoneExtensionTextBox.ClientID + "," + this.PrimaryContactPhoneExtensionTextBox.ClientID + ",500" + ")");
            this.SecondaryContactFaxTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SecondaryContactFaxTextBox.ClientID + "," + this.SecondaryContactFaxTextBox.ClientID + ",500" + ")");
            this.SecondaryContactHPTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SecondaryContactHPTextBox.ClientID + "," + this.SecondaryContactHPTextBox.ClientID + ",500" + ")");
            this.SecondaryContactPhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SecondaryContactPhoneTextBox.ClientID + "," + this.SecondaryContactPhoneTextBox.ClientID + ",500" + ")");
            this.SecondaryContactPhoneExtensionTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SecondaryContactPhoneExtensionTextBox.ClientID + "," + this.SecondaryContactPhoneExtensionTextBox.ClientID + ",500" + ")");

            this.CustomerCodeTextBox.Attributes.Add("ReadOnly", "True");
            this.CustomerCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._customerID);
        }

        private void ShowData()
        {
            MsCustomer _mscustomer = this._CustomerBL.GetMsCustomerByCustomerID(this._nvcExtractor.GetValue(this._customerID));

            this.BusinessTypeDropDownList.SelectedValue = _mscustomer.BusinessTypeID.ToString();
            this.CityTextBox.Text = _mscustomer.City;
            //this.CreatedByTextBox.Text =_mscustomer.CreatedBy;
            //this.CreatedDateTextBox.Text = DateFormMapper.GetValue(_mscustomer.CreatedDate);
            this.CustomerAddress1TextBox.Text = _mscustomer.CustomerAddress1;
            this.CustomerAddress2TextBox.Text = _mscustomer.CustomerAddress2;
            this.CustomerCodeTextBox.Text = _mscustomer.CustomerCode;            
            this.CustomerNameTextBox.Text = _mscustomer.CustomerName;
            this.FaxTextBox.Text = _mscustomer.Fax;
            //this.ModifiedByTextBox.Text = _mscustomer. ModifiedBy;
            //this.ModifiedDateTextBox.Text =  DateFormMapper.GetValue(_mscustomer.ModifiedDate);
            this.NPPKPTextBox.Text = _mscustomer.NPPKP;
            this.NPWPTextBox.Text = _mscustomer.NPWP;
            this.NPWPAddressTextBox.Text = _mscustomer.NPWPAddress;
            this.PhoneTextBox.Text = _mscustomer.Phone;
            this.PrimaryContactDepartmentTextBox.Text = _mscustomer.PrimaryContactDepartment;
            this.PrimaryContactEmailTextBox.Text = _mscustomer.PrimaryContactEmail;
            this.PrimaryContactHPTextBox.Text = _mscustomer.PrimaryContactHP;
            this.PrimaryContactNameTextBox.Text = _mscustomer.PrimaryContactName;
            this.PrimaryContactTitleTextBox.Text = _mscustomer.PrimaryContactTitle;
            this.PrimaryContactFaxTextBox.Text = _mscustomer.PrimayContactFax;
            this.PrimaryContactPhoneTextBox.Text = _mscustomer.PrimayContactPhone;
            this.PrimaryContactPhoneExtensionTextBox.Text = _mscustomer.PrimayContactPhoneExtension;
            this.RemarkTextBox.Text = _mscustomer.Remark;
            this.SecondaryContactDepartmentTextBox.Text = _mscustomer.SecondaryContactDepartment;
            this.SecondaryContactEmailTextBox.Text = _mscustomer.SecondaryContactEmail;
            this.SecondaryContactFaxTextBox.Text = _mscustomer.SecondaryContactFax;
            this.SecondaryContactHPTextBox.Text = _mscustomer.SecondaryContactHP;
            this.SecondaryContactNameTextBox.Text = _mscustomer.SecondaryContactName;
            this.SecondaryContactPhoneTextBox.Text = _mscustomer.SecondaryContactPhone;
            this.SecondaryContactPhoneExtensionTextBox.Text = _mscustomer.SecondaryContactPhoneExtension;
            this.SecondaryContactTitleTextBox.Text = _mscustomer.SecondaryContactTitle;
            this.ZipCodeTextBox.Text = _mscustomer.ZipCode;
            this.RemarkTextBox.Text = _mscustomer.Remark;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _mscustomer.CustomerID.ToString();
        }

        protected void ShowBusinessTypeDDL()
        {
            {
                this.BusinessTypeDropDownList.DataTextField = "BusinessTypeName";
                this.BusinessTypeDropDownList.DataValueField = "BusinessTypeID";
                this.BusinessTypeDropDownList.DataSource = this._surveyPointBL.GetListBusinessFormsForDDL();
                this.BusinessTypeDropDownList.DataBind();
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._listCustomerPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsCustomer _mscustomer = new MsCustomer();
            _mscustomer.CustomerID = Convert.ToInt64(this._nvcExtractor.GetValue(this._customerID));
            _mscustomer.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _mscustomer.RowStatus = 1;

            _result = this._CustomerBL.DeletedCustomer(_mscustomer);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listCustomerPage);
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
                this.EditCustomer();
            }

        protected void EditCustomer()
        {
            Boolean _result = false;

            MsCustomer _mscustomer = this._CustomerBL.GetMsCustomerByCustomerID(this._nvcExtractor.GetValue(this._customerID));

            _mscustomer.BusinessTypeID = Convert.ToInt64(this.BusinessTypeDropDownList.SelectedValue);
            _mscustomer.City = this.CityTextBox.Text;
            //_mscustomer.CreatedBy = this.CreatedByTextBox.Text;
            //_mscustomer.CreatedDate = Convert.ToDateTime(this.CreatedDateTextBox.Text);
            _mscustomer.CustomerAddress1 = this.CustomerAddress1TextBox.Text;
            _mscustomer.CustomerAddress2 = this.CustomerAddress2TextBox.Text;
            _mscustomer.CustomerCode = this.CustomerCodeTextBox.Text;            
            _mscustomer.CustomerName = this.CustomerNameTextBox.Text;
            _mscustomer.Fax = this.FaxTextBox.Text;            
            _mscustomer.NPPKP = this.NPPKPTextBox.Text;
            _mscustomer.NPWP = this.NPWPTextBox.Text;
            _mscustomer.NPWPAddress = this.NPWPAddressTextBox.Text;
            _mscustomer.Phone = this.PhoneTextBox.Text;
            _mscustomer.PrimaryContactDepartment = this.PrimaryContactDepartmentTextBox.Text;
            _mscustomer.PrimaryContactEmail = this.PrimaryContactEmailTextBox.Text;
            _mscustomer.PrimaryContactHP = this.PrimaryContactHPTextBox.Text;
            _mscustomer.PrimaryContactName = this.PrimaryContactNameTextBox.Text;
            _mscustomer.PrimaryContactTitle = this.PrimaryContactTitleTextBox.Text;
            _mscustomer.PrimayContactFax = this.PrimaryContactFaxTextBox.Text;
            _mscustomer.PrimayContactPhone = this.PrimaryContactPhoneTextBox.Text;
            _mscustomer.PrimayContactPhoneExtension = this.PrimaryContactPhoneExtensionTextBox.Text;
            _mscustomer.Remark = this.RemarkTextBox.Text;
            _mscustomer.RowStatus = 0;
            _mscustomer.SecondaryContactDepartment = this.SecondaryContactDepartmentTextBox.Text;
            _mscustomer.SecondaryContactEmail = this.SecondaryContactEmailTextBox.Text;
            _mscustomer.SecondaryContactFax = this.SecondaryContactFaxTextBox.Text;
            _mscustomer.SecondaryContactHP = this.SecondaryContactHPTextBox.Text;
            _mscustomer.SecondaryContactName = this.SecondaryContactNameTextBox.Text;
            _mscustomer.SecondaryContactPhone = this.SecondaryContactPhoneTextBox.Text;
            _mscustomer.SecondaryContactPhoneExtension = this.SecondaryContactPhoneExtensionTextBox.Text;
            _mscustomer.SecondaryContactTitle = this.SecondaryContactTitleTextBox.Text;
            _mscustomer.ZipCode = this.ZipCodeTextBox.Text;


            _mscustomer.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _mscustomer.ModifiedDate = DateTime.Now;

            _result = this._CustomerBL.UpdateCustomer(_mscustomer);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listCustomerPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Edit Data";
            }
        }
    }
}
