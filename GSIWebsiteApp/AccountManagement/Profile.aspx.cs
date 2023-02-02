using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;
using GSI.Common;
using GSI.DataMapping;
using System.Web;

namespace GSIWebsiteApp.AccountManagement
{
    public partial class Profile : ProfileBase
    {
        private CustomerBL _customerBL = new CustomerBL();
        private BusinessTypeBL _msBusinessTypeBL = new BusinessTypeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;

                this.ProfileIDHiddenField.Value = HttpContext.Current.Session[this._sesCustID].ToString();
                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
                this.ShowData();
            }
        }

        protected void ShowData()
        {
            MsCustomer _msCustomer = this._customerBL.GetMsCustomerByCustomerID(this.ProfileIDHiddenField.Value);
            this.BusinessTypeLiteral.Text = (_msCustomer.BusinessTypeID == null) ? "" : this._msBusinessTypeBL.GetSingleBusinessType(Convert.ToInt64(_msCustomer.BusinessTypeID)).BusinessTypeName;
            this.CityLiteral.Text = _msCustomer.City;
            this.CusAddress1Literal.Text = _msCustomer.CustomerAddress1;
            this.CustomerAddress2Literal.Text = _msCustomer.CustomerAddress2;
            this.ZIPCodeLiteral.Text = _msCustomer.ZipCode;
            this.CustomerCodeLiteral.Text = _msCustomer.CustomerCode;
            this.CustomerNameLiteral.Text = _msCustomer.CustomerName;
            this.FaxLiteral.Text = _msCustomer.Fax;
            this.NPPKPLiteral.Text = _msCustomer.NPPKP;
            this.NPWPLiteral.Text = _msCustomer.NPWP;
            this.NPWPAddressLiteral.Text = _msCustomer.NPWPAddress;
            this.PhoneLiteral.Text = _msCustomer.Phone;
            this.PrimaryContactEmailAddressLiteral.Text = _msCustomer.PrimaryContactEmail;
            this.PrimaryContactHpLiteral.Text = _msCustomer.PrimaryContactHP;
            this.PrimaryContactNameLiteral.Text = _msCustomer.PrimaryContactName;           
            this.PrimaryContactFaxLiteral.Text = _msCustomer.PrimayContactFax;
            this.SecondaryContactDepartLiteral.Text = _msCustomer.SecondaryContactDepartment;
            this.SecondaryContactEmailLiteral.Text = _msCustomer.SecondaryContactEmail;
            this.SecondaryContactFaxLiteral.Text = _msCustomer.SecondaryContactFax;
            this.SecondaryContactHpLiteral.Text = _msCustomer.SecondaryContactHP;
            this.SecondaryContactNameLiteral.Text = _msCustomer.SecondaryContactName;
            this.SecondaryContactPhoneLiteral.Text = _msCustomer.SecondaryContactPhone;
            this.SecondaryContactPhoneExtensionLiteral.Text = _msCustomer.SecondaryContactPhoneExtension;
            this.SecondaryContactTitleLiteral.Text = _msCustomer.SecondaryContactTitle;
            this.RemarkLiteral.Text = _msCustomer.Remark;
            this.RemarkLiteral.Text = Convert.ToString(_msCustomer.Remark);
        }
    }
}
