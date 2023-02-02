using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRuleCore;
using GSI.BusinessRule;
using GSI.DataMapping;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class ViewWorkOrderSurveyPoint : WorkOrderBase
    {
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private RegionBL _regionBL = new RegionBL();
        private BusinessTypeBL _msBusinessTypeBL = new BusinessTypeBL();
        private DocumentTypeBL _msDocumentTypeBL = new DocumentTypeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.BackButton.ImageUrl = this._imageURL + "btnBack.png";
                this.BackButton2.ImageUrl = this._imageURL + "btnBack.png";

                this.PageTitleLiteral.Text = this._pageTitleViewSPLiteral;
                this.PageLiteral2.Text = this._pageTitleViewSPLiteral;

                this.InitializeData();
                if ((this._nvcExtractor.GetValue(this._orderSPID) != ""))
                {
                    this.ShowDocument();
                    this.ShowDocument2();
                    this.ShowIDTypeDDL();
                    this.ShowRegionDDL();
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._orderSPID);
        }

        private void ShowData()
        {
            if (this._nvcExtractor.GetValue(this._template) == "1")
            {
                this.TrOrderSPNotMovablePanel.Visible = true;
                this.TrOrderSPMovablePanel.Visible = false;

                TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                this.CompanyNameTextBox.Text = _trOrderSPNotMovable.SurveyPointName;
                this.BusinessFormsTextBox.Text = (this._msBusinessTypeBL.GetSingleBusinessType(_trOrderSPNotMovable.BusinessTypeID).BusinessTypeName);
                //this.LineofBussinesTextBox.Text = _trOrderSPNotMovable.BusinessLine;
                this.AddressTextBox.Text = _trOrderSPNotMovable.Address;
                this.ClueTextBox.Text = _trOrderSPNotMovable.Clue;
                this.ZipCodeTextBox.Text = _trOrderSPNotMovable.ZipCode;
                this.PhoneNumberTextBox.Text = _trOrderSPNotMovable.PhoneNumber;
                this.ExtentionTextBox.Text = _trOrderSPNotMovable.Extension;
                this.ContactNumberTextBox.Text = _trOrderSPNotMovable.ContactNumber;
                this.RegionTextBoxt.Text = this._regionBL.GetMsRegionByRegionId((long)_trOrderSPNotMovable.RegionID).RegionName;
                this.RemarkTextBox.Text = _trOrderSPNotMovable.Remark;

                List<TrReqDocNotMovable> _reqDocList = this._orderSurveyPointBL.GetListReqDocbySPIDNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                foreach (ListItem _item in this.DocumentTypeCheckBoxList.Items)
                {
                    foreach (TrReqDocNotMovable _data in _reqDocList)
                    {
                        if (_data.DocumentTypeID.ToString().Trim() == _item.Value.Trim())
                        {
                            _item.Selected = true;
                            this.NoteDocumentTextBox.Text = _data.Remark;
                        }
                    }
                }
            }
            else
            {
                this.TrOrderSPNotMovablePanel.Visible = false;
                this.TrOrderSPMovablePanel.Visible = true;

                TrOrderSPMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                this.FullNameTextBox.Text = _trOrderSPNotMovable.SurveyPointName;
                this.StatusRBL.SelectedValue = _trOrderSPNotMovable.MaritalStatus.ToString();
                this.SpouseTextBox.Text = _trOrderSPNotMovable.SpouseName;
                this.NationalityRBL.SelectedValue = _trOrderSPNotMovable.Nationality;
                this.PlaceOfBirthTextBox.Text = _trOrderSPNotMovable.PlaceOfBirth;
                this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_trOrderSPNotMovable.DateOfBirth);
                this.IDDropDownList.SelectedValue = _trOrderSPNotMovable.IDType.ToString();
                this.IDNoTextBox.Text = _trOrderSPNotMovable.IDNo;
                this.RegionDDL.SelectedValue = _trOrderSPNotMovable.RegionID.ToString();
                this.IDAddressTextBox.Text = _trOrderSPNotMovable.IDAddress;
                this.CurrentAddressTextBox.Text = _trOrderSPNotMovable.HomeAddress;
                this.MobilePhoneTextBox.Text = _trOrderSPNotMovable.MobilePhoneNumber;
                this.HomePhoneTextBox.Text = _trOrderSPNotMovable.HomePhoneNumber;
                this.NoteTextBox.Text = _trOrderSPNotMovable.Remark;
                this.ClueTextBox2.Text = _trOrderSPNotMovable.Clue;
                this.ZipCodeTextBox2.Text = _trOrderSPNotMovable.ZipCode;
                this.ExtentionTextBox2.Text = _trOrderSPNotMovable.Extension;


                List<TrReqDocMovable> _reqDocList = this._orderSurveyPointBL.GetListReqDocbySPIDMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                foreach (ListItem _item in this.DocumentTypeCheckBoxList2.Items)
                {
                    foreach (TrReqDocMovable _data in _reqDocList)
                    {
                        if (_data.DocumentTypeID.ToString().Trim() == _item.Value.Trim())
                        {
                            _item.Selected = true;
                            this.NoteDocumentTextBox2.Text = _data.Remark;
                        }
                    }
                }
            }

        }

        protected void ShowIDTypeDDL()
        {
            List<String> _IDTypes = IDTypeMapper.IDTypes;
            this.IDDropDownList.Items.Clear();
            foreach (var _IDType in _IDTypes)
            {
                String[] _row = _IDType.Split(',');
                this.IDDropDownList.Items.Add(new ListItem(_row[1], _row[0]));
            }
        }

        protected void ShowDocument()
        {
            this.DocumentTypeCheckBoxList.Items.Clear();
            this.DocumentTypeCheckBoxList.DataSource = this._msDocumentTypeBL.GetDocumentType(Convert.ToInt64(this._nvcExtractor.GetValue(this._SPid)));
            this.DocumentTypeCheckBoxList.DataValueField = "DocumentTypeID";
            this.DocumentTypeCheckBoxList.DataTextField = "DocumentTypeName";
            this.DocumentTypeCheckBoxList.DataBind();
            this.DocumentTypeCheckBoxList.Enabled = false;
        }
        protected void ShowDocument2()
        {
            this.DocumentTypeCheckBoxList2.Items.Clear();
            this.DocumentTypeCheckBoxList2.DataSource = this._msDocumentTypeBL.GetDocumentType(Convert.ToInt64(this._nvcExtractor.GetValue(this._SPid)));
            this.DocumentTypeCheckBoxList2.DataValueField = "DocumentTypeID";
            this.DocumentTypeCheckBoxList2.DataTextField = "DocumentTypeName";
            this.DocumentTypeCheckBoxList2.DataBind();
            this.DocumentTypeCheckBoxList2.Enabled = false;
        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._regionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
            //this.RegionDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void BackButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._addWorkOrderPage);
        }

        protected void BackButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._addWorkOrderPage);
        }
    }
}
