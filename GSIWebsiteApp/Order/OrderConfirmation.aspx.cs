using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using System.Web;

namespace GSIWebsiteApp.Order
{
    public partial class OrderConfirmation : OrderBase
    {
        private OrderBL _orderBL = new OrderBL();
        private OrderSurveyPointBL _surveyPointBL = new OrderSurveyPointBL();
        private DocumentTypeBL _msDocumentTypeBL = new DocumentTypeBL();
        private RegionBL _msRegionBL = new RegionBL();
        private BusinessTypeBL _msBusinessTypeBL = new BusinessTypeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack == true)
            {
                this.ProceedButton.ImageUrl = this._imageURL + "btn_proceed_OrderConfirmation2.png";
                this.CancelButton.ImageUrl = this._imageURL + "btn_cancel_OrderConfirmation2.png";

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

                this.PageTitleLiteral.Text = this._pageTitleLiteralOrderConfirmation;
                this.OrderIDHiddenField.Value = this._nvcExtractor.GetValue(this._codeKey);

                this.ProceedButton.Attributes.Add("OnClick", "ChangePic(\"" + this.ProceedButton.ClientID + "\", \"" + this.CancelButton.ClientID + "\", \"" + this.LoadingImage.ClientID + "\" ,'" + this._imageURL + "ajax-loader.gif');");
                this.LoadingImage.Attributes.Add("style", "visibility : hidden");

                this.ShowData();
                this.ShowDataDetail();
            }
        }

        private void ShowData()
        {
            TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this.OrderIDHiddenField.Value));
            this.OrderCodeLabel.Text = _trOrder.OrderCode;
            this.OrderTypeLabel.Text = OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID);
            this.DateLabel.Text = DateFormMapper.GetValue(_trOrder.OrderDate);
            this.NoteLabel.Text = Convert.ToString(_trOrder.Remark);
        }

        private void ShowDataDetail()
        {
            this.ListRepeater.DataSource = this._orderBL.GetListTrOrderSPMovableByOrderId(Convert.ToInt64(this.OrderIDHiddenField.Value));
            this.ListRepeater.DataBind();
            this.OfficeListRepeater.DataSource = this._orderBL.GetListTrOrderSPNotMovableByOrderId(Convert.ToInt64(this.OrderIDHiddenField.Value));
            this.OfficeListRepeater.DataBind();
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrOrderSPMovable _temp = (TrOrderSPMovable)e.Item.DataItem;


            Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointTypeLiteral");
            _nameLiteral.Text = HttpUtility.HtmlEncode(PointSurveyMapper.GetPointSurveyName((int)_temp.SurveyPointID));

            Literal _fullNameLiteral = (Literal)e.Item.FindControl("FullNameLiteral");
            _fullNameLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);

            Literal _StatusLiteral = (Literal)e.Item.FindControl("StatusLiteral");
            _StatusLiteral.Text = HttpUtility.HtmlEncode(_temp.MaritalStatus);

            Literal _sposeLiteral = (Literal)e.Item.FindControl("SposeLiteral");
            _sposeLiteral.Text = HttpUtility.HtmlEncode(_temp.SpouseName);

            Literal _nationalityLiteral = (Literal)e.Item.FindControl("NationalityLiteral");
            _nationalityLiteral.Text = HttpUtility.HtmlEncode(_temp.Nationality);

            Literal _placeBirthLiteral = (Literal)e.Item.FindControl("PlaceBirthLiteral");
            _placeBirthLiteral.Text = HttpUtility.HtmlEncode(_temp.PlaceOfBirth);

            Literal _dateOfBirthLiteral = (Literal)e.Item.FindControl("DateOfBirthLiteral");
            _dateOfBirthLiteral.Text = HttpUtility.HtmlEncode(DateFormMapper.GetValue(_temp.DateOfBirth));

            Literal _IDLiteral = (Literal)e.Item.FindControl("IDLiteral");
            _IDLiteral.Text = HttpUtility.HtmlEncode(IDTypeMapper.GetIDTypeText(_temp.IDType));

            Literal _iDNoLiteral = (Literal)e.Item.FindControl("IDNoLiteral");
            _iDNoLiteral.Text = HttpUtility.HtmlEncode(_temp.IDNo.ToString());

            Literal _iDAddressLiteral = (Literal)e.Item.FindControl("IDAddressLiteral");
            _iDAddressLiteral.Text = HttpUtility.HtmlEncode(_temp.IDAddress.ToString());

            Literal _currentAddressLiteral = (Literal)e.Item.FindControl("CurrentAddressLiteral");
            _currentAddressLiteral.Text = HttpUtility.HtmlEncode(_temp.HomeAddress);

            Literal _ZipCodeLiteral = (Literal)e.Item.FindControl("ZipCodeLiteral");
            _ZipCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.ZipCode);

            Literal _NoteLiteral = (Literal)e.Item.FindControl("NoteLiteral");
            _NoteLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);

            Literal _ClueLiteral = (Literal)e.Item.FindControl("ClueLiteral");
            _ClueLiteral.Text = HttpUtility.HtmlEncode(_temp.Clue);

            Literal _regionLiteral = (Literal)e.Item.FindControl("RegionLiteral");
            _regionLiteral.Text = HttpUtility.HtmlEncode(this._msRegionBL.GetMsRegionByRegionId((long)_temp.RegionID).RegionName);

            Literal _mobilePhoneLiteral = (Literal)e.Item.FindControl("MobilePhoneLiteral");
            _mobilePhoneLiteral.Text = HttpUtility.HtmlEncode(_temp.MobilePhoneNumber);

            Literal _homePhoneLiteral = (Literal)e.Item.FindControl("HomePhoneLiteral");
            _homePhoneLiteral.Text = HttpUtility.HtmlEncode(_temp.HomePhoneNumber);

            Literal _extentionLiteral = (Literal)e.Item.FindControl("ExtentionLiteral");
            _extentionLiteral.Text = HttpUtility.HtmlEncode(_temp.Extension);

            Repeater _doclistliteral = (Repeater)e.Item.FindControl("RequiredDokumentListRepeater");
            _doclistliteral.DataSource = this._orderBL.GetListReqDocMovableByOrderSPMovableID(_temp.OrderSPMovableID);
            _doclistliteral.DataBind();
        }

        protected void RequiredDokumentListRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrReqDocMovable _temp = (TrReqDocMovable)e.Item.DataItem;

            Literal _nameLiteral = (Literal)e.Item.FindControl("IDTypeLiteral");
            _nameLiteral.Text = HttpUtility.HtmlEncode(this._msDocumentTypeBL.GetListMsDocumentTypeByCode(_temp.DocumentTypeID).DocumentTypeName);
            Literal _fullNameLiteral = (Literal)e.Item.FindControl("NoteLiteral");
            _fullNameLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);
        }

        protected void OfficeListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrOrderSPNotMovable _temp = (TrOrderSPNotMovable)e.Item.DataItem;

            Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointTypeLiteral2");
            _nameLiteral.Text = HttpUtility.HtmlEncode(PointSurveyMapper.GetPointSurveyName((int)_temp.SurveyPointID));

            Literal _fullNameLiteral = (Literal)e.Item.FindControl("FullNameLiteral2");
            _fullNameLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);

            Literal _businessTypeLiteral = (Literal)e.Item.FindControl("BusinessTypeLiteral");
            _businessTypeLiteral.Text = HttpUtility.HtmlEncode(this._msBusinessTypeBL.GetSingleBusinessType(_temp.BusinessTypeID).BusinessTypeName);

            //Literal _businessLineLiteral = (Literal)e.Item.FindControl("BusinessLineLiteral");
            //_businessLineLiteral.Text = HttpUtility.HtmlEncode(_temp.BusinessLine);

            Literal _addressLiteral = (Literal)e.Item.FindControl("AddressLiteral2");
            _addressLiteral.Text = HttpUtility.HtmlEncode(_temp.Address);

            Literal _ClueLiteral = (Literal)e.Item.FindControl("ClueLiteral2");
            _ClueLiteral.Text = HttpUtility.HtmlEncode(_temp.Clue);

            Literal _ZipCodeLiteral = (Literal)e.Item.FindControl("ZipCodeLiteral2");
            _ZipCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.ZipCode);

            Literal _mobilePhoneLiteral = (Literal)e.Item.FindControl("MobilePhoneLiteral2");
            _mobilePhoneLiteral.Text = HttpUtility.HtmlEncode(_temp.PhoneNumber);

            Literal _homePhoneLiteral = (Literal)e.Item.FindControl("HomePhoneLiteral2");
            _homePhoneLiteral.Text = HttpUtility.HtmlEncode(_temp.ContactNumber);

            Literal _extentsionLiteral = (Literal)e.Item.FindControl("ExtentsionLiteral");
            _extentsionLiteral.Text = HttpUtility.HtmlEncode(_temp.Extension);

            Literal _regionLiteral = (Literal)e.Item.FindControl("RegionLiteral2");
            _regionLiteral.Text = HttpUtility.HtmlEncode(this._msRegionBL.GetMsRegionByRegionId((long)_temp.RegionID).RegionName);

            Literal _NoteLiteral = (Literal)e.Item.FindControl("NoteLiteral2");
            _NoteLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);


            Repeater _doclistliteral = (Repeater)e.Item.FindControl("RequiredDokumentOfficeListRepeater");
            _doclistliteral.DataSource = this._orderBL.GetListReqDocNotMovableByOrderSPnotMovableID(_temp.OrderSPNotMovableID);
            _doclistliteral.DataBind();

        }

        protected void RequiredDokumentOfficeListRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrReqDocNotMovable _temp = (TrReqDocNotMovable)e.Item.DataItem;

            Literal _nameLiteral = (Literal)e.Item.FindControl("IDTypeLiteral2");
            _nameLiteral.Text = HttpUtility.HtmlEncode(this._msDocumentTypeBL.GetListMsDocumentTypeByCode(_temp.DocumentTypeID).DocumentTypeName);
            Literal _fullNameLiteral = (Literal)e.Item.FindControl("NoteLiteral2");
            _fullNameLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);

        }

        protected void CancelButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect(this._listOrderPage);
        }

        protected void ProceedButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this.OrderIDHiddenField.Value));
            if (_trOrder.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Draft) && _trOrder.OrderStatus == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Initialized))
            {
                String _result = this._orderBL.SendToCoreSystem(Convert.ToInt64(this.OrderIDHiddenField.Value), HttpContext.Current.User.Identity.Name);
                if (_result == "")
                {
                    this.LoadingImage.Attributes.Add("style", "visibility : hidden");
                    this.WarningLabel.Text = "Proceed Succesfully";
                    Response.Redirect(this._listOrderPage +"?"+ this._warning + "=" + this.WarningLabel.Text);
                }
                else
                {
                    this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                }
            }
            else
            {
                this.WarningLabel.Text = "The Order Has been Submited";
            }
        }
    }
}