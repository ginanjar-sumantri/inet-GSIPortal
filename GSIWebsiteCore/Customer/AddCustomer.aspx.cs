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
    public partial class AddCustomer : CustomerBase
    {
        private CustomerBL _CustomerBL = new CustomerBL();
        private OrderSurveyPointBL _surveyPointBL = new OrderSurveyPointBL();
        
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
                this.SetAttribute();
                this.ShowBusinessTypeDDL();
                this.ClearData();
                this.SetAttribute();
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

        }
        private void ClearData()
        {
            this.BusinessTypeDropDownList.SelectedValue = "";
            this.CityTextBox.Text = "";
            this.CustomerAddress1TextBox.Text = "";
            this.CustomerAddress2TextBox.Text = "";
            this.CustomerCodeTextBox.Text = "";
            //this.CustomerIDTextBox.Text = "";
            this.CustomerNameTextBox.Text = "";
            this.FaxTextBox.Text = "";
            //this.FgActiveCheckBox.Checked = true;
            this.NPPKPTextBox.Text = "";
            this.NPWPTextBox.Text = "";
            this.NPWPAddressTextBox.Text = "";
            this.PhoneTextBox.Text = "";
            this.PrimaryContactDepartmentTextBox.Text = "";
            this.PrimaryContactEmailTextBox.Text = "";
            this.PrimaryContactHPTextBox.Text = "";
            this.PrimaryContactNameTextBox.Text = "";
            this.PrimaryGenderRadioButtonList.SelectedValue = "Male";
            this.PrimaryPlaceOfBirthTextBox.Text = "";
            this.PrimaryDateOfBirthTextBox.Text = DateFormMapper.GetValue(DateTime.Now);
            this.PrimaryContactTitleTextBox.Text = "";
            this.PrimaryContactFaxTextBox.Text = "";
            this.PrimaryContactPhoneTextBox.Text = "";
            this.PrimaryContactPhoneExtensionTextBox.Text = "";
            this.RemarkTextBox.Text = "";
            //this.RowStatusTextBox.Text = "";
            this.SecondaryContactDepartmentTextBox.Text = "";
            this.SecondaryContactEmailTextBox.Text = "";
            this.SecondaryContactFaxTextBox.Text = "";
            this.SecondaryContactHPTextBox.Text = "";
            this.SecondaryContactNameTextBox.Text = "";
            this.SecondaryGenderRadioButtonList.SelectedValue = "Male";
            this.SecondaryPlaceOfBirthTextBox.Text = "";
            this.SecondaryDateOfBirthTextBox.Text = DateFormMapper.GetValue(DateTime.Now);
            this.SecondaryContactPhoneTextBox.Text = "";
            this.SecondaryContactPhoneExtensionTextBox.Text = "";
            this.SecondaryContactTitleTextBox.Text = "";
            this.ZipCodeTextBox.Text = "";
           
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



        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            //if (this.EmployeeCodeTextBox.Text == "" || this.FullNameTextBox.Text == "" || this.IDNoTextBox.Text == "")
            //{
            //    this.WarningLabel.Text = "Required Document Note Must Be Filled";
            //}
            //else
            //{
            this.AddCustomerData();
            //}

        }

        protected void AddCustomerData()
        {
           MsCustomer _mscustomer = new MsCustomer();

           _mscustomer.BusinessTypeID= Convert.ToInt64(this.BusinessTypeDropDownList.SelectedValue);
            _mscustomer.City = this.CityTextBox.Text;
            _mscustomer.CreatedBy = Request.ServerVariables["LOGON_USER"];
            _mscustomer.CreatedDate = DateTime.Now;
            _mscustomer.CustomerAddress1 = this.CustomerAddress1TextBox.Text;
            _mscustomer.CustomerAddress2 = this.CustomerAddress2TextBox.Text;
            _mscustomer.CustomerCode = this.CustomerCodeTextBox.Text;
            //_mscustomer.CustomerID = Convert.ToInt64(this.CustomerIDTextBox.Text);
            _mscustomer.CustomerName = this.CustomerNameTextBox.Text;
            _mscustomer.Fax = this.FaxTextBox.Text;
            _mscustomer.ModifiedBy = String.Empty;
            _mscustomer.ModifiedDate = this._defaultDate;
            _mscustomer.NPPKP = this.NPPKPTextBox.Text;            
            _mscustomer.NPWP = this.NPWPTextBox.Text;
            _mscustomer.NPWPAddress = this.NPWPAddressTextBox.Text;
            _mscustomer.Phone = this.PhoneTextBox.Text;
            _mscustomer.PrimaryContactDepartment = this.PrimaryContactDepartmentTextBox.Text;
            _mscustomer.PrimaryContactEmail = this.PrimaryContactEmailTextBox.Text;
            _mscustomer.PrimaryContactHP = this.PrimaryContactHPTextBox.Text;
            _mscustomer.PrimaryContactName = this.PrimaryContactNameTextBox.Text;
            _mscustomer.PrimaryGender = this.PrimaryGenderRadioButtonList.SelectedValue;
            _mscustomer.PrimaryPlaceOfBirth = this.PrimaryPlaceOfBirthTextBox.Text;
            _mscustomer.PrimaryDateOfBirth = DateFormMapper.GetValue(this.PrimaryDateOfBirthTextBox.Text);
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
            _mscustomer.SecondaryGender = this.SecondaryGenderRadioButtonList.SelectedValue;
            _mscustomer.SecondaryPlaceOfBirth = this.SecondaryPlaceOfBirthTextBox.Text;
            _mscustomer.SecondaryDateOfBirth = DateFormMapper.GetValue(this.SecondaryDateOfBirthTextBox.Text);
            _mscustomer.SecondaryContactPhone = this.SecondaryContactPhoneTextBox.Text;
            _mscustomer.SecondaryContactPhoneExtension = this.SecondaryContactPhoneExtensionTextBox.Text;
            _mscustomer.SecondaryContactTitle = this.SecondaryContactTitleTextBox.Text;
            _mscustomer.ZipCode = this.ZipCodeTextBox.Text;
            _mscustomer.fgActive = true;


            int _success = this._CustomerBL.InsertMsCustomer(_mscustomer);

            if (_success == -1)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listCustomerPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";

            }
        }
        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listCustomerPage);
        }
    }
}