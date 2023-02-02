using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Common.Enum;
using System.Collections.Generic;
using System.Configuration;

namespace GSIWebsiteApp.Order
{
    public partial class AddOfficeRespondent : OrderBase
    {
        private OrderBL _orderBL = new OrderBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();
        private DocumentTypeBL _msDocumentTypeBL = new DocumentTypeBL();
        private RegionBL _msRegionBL = new RegionBL();
        private RegionZipCodeBL _zipCodeBL = new RegionZipCodeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteralAddSurveyPoint + " " + (new SurveyPointBL().GetSingleSurveyPoint(Convert.ToInt32(this._nvcExtractor.GetValue(this._SPid))).SurveyPointName);

                this.SaveButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.CancelButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.ResetButton.ImageUrl = this._imageURL + "btnReset.png";

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
                this.OrderIdHiddenField.Value = this._nvcExtractor.GetValue(this._codeKey);
                this.SPidHiddenField.Value = this._nvcExtractor.GetValue(this._SPid);
                this.OrderSPIDHiddenField.Value = this._nvcExtractor.GetValue(this._orderSPID);
                this.OrderVersionHiddenField.Value = this._nvcExtractor.GetValue(this._orderVersion);

                if (this.OrderVersionHiddenField.Value == (OrderVersionMapper.GetOrderVersion(OrderVersion.Final)).ToString())
                {
                    this.SaveButton.Visible = false;
                    this.ResetButton.Visible = false;
                }

                this.SetAttribute();
                this.ClearLabel();
                this.ClearData();
                this.ShowRegionDDL();
                this.ShowZipCodeDDL();
                this.InitializeData();
                this.ShowBusinessForms();
                this.ShowDocument();

                if (this.OrderIdHiddenField.Value != "" && this.OrderSPIDHiddenField.Value != "")
                {
                    this.ShowData();
                }

                long _cekFormIsOriginator = this.GetOriginatorID();
            }
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        protected void ClearData()
        {
            DateTime _now = DateTime.Now;

            this.CompanyNameTextBox.Text = "";
            //this.LineofBussinesTextBox.Text = "";
            this.AddressTextBox.Text = "";
            this.ClueTextBox.Text = "";
            //this.ZipCodeTextBox.Text = "";
            this.NoteDocumentTextBox.Text = "";
            this.RemarkTextBox.Text = "";
            this.PhoneNumberTextBox.Text = "";
            this.ContactNumberTextBox.Text = "";
            this.ExtentionTextBox.Text = "";

            foreach (ListItem _cBox in this.DocumentTypeCheckBoxList.Items)
            {
                _cBox.Selected = false;
            }
        }

        private void ReadOnlyTextBox(byte _prmSPStatus)
        {
            if (_prmSPStatus == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            {
                this.CompanyNameTextBox.Attributes.Add("ReadOnly", "True");
                this.CompanyNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                //this.LineofBussinesTextBox.Attributes.Add("ReadOnly", "True");
                //this.LineofBussinesTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.AddressTextBox.Attributes.Add("ReadOnly", "True");
                this.AddressTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ClueTextBox.Attributes.Add("ReadOnly", "True");
                this.ClueTextBox.Attributes.Add("Style", "background-color: #DDDDDD");
                this.PhoneNumberTextBox.Attributes.Add("ReadOnly", "True");
                this.PhoneNumberTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.CompanyNameTextBox.Attributes.Add("ReadOnly", "True");
                this.CompanyNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.PhoneNumberTextBox.Attributes.Add("ReadOnly", "True");
                this.PhoneNumberTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ContactNumberTextBox.Attributes.Add("ReadOnly", "True");
                this.ContactNumberTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.CompanyNameTextBox.Attributes.Add("ReadOnly", "True");
                this.CompanyNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ExtentionTextBox.Attributes.Add("ReadOnly", "True");
                this.ExtentionTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                //this.ZipCodeTextBox.Attributes.Add("ReadOnly", "True");
                //this.ZipCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.NoteDocumentTextBox.Attributes.Add("ReadOnly", "True");
                this.NoteDocumentTextBox.Attributes.Add("Style", "background-color: #DDDDDD");
                this.RemarkTextBox.Attributes.Add("ReadOnly", "True");
                this.RemarkTextBox.Attributes.Add("Style", "background-color: #CCCCCC");

                this.BusinessFormsDropDownList.Enabled = false;
                this.RegionDDL.Enabled = false;
                this.ZipCodeDDL.Enabled = false;
                this.DocumentTypeCheckBoxList.Enabled = false;
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._type);
            this._orderType = _queryString.Split(',');
        }

        protected void SetAttribute()
        {
            this.PhoneNumberTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhoneNumberTextBox.ClientID + "," + this.PhoneNumberTextBox.ClientID + ",500" + ")");
            this.ContactNumberTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ContactNumberTextBox.ClientID + "," + this.ContactNumberTextBox.ClientID + ",500" + ")");
            //this.ZipCodeTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ZipCodeTextBox.ClientID + "," + this.ZipCodeTextBox.ClientID + ",500" + ")");
            this.ExtentionTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ExtentionTextBox.ClientID + "," + this.ExtentionTextBox.ClientID + ",500" + ")");
        }

        private void ShowBusinessForms()
        {
            this.BusinessFormsDropDownList.DataTextField = "BusinessTypeName";
            this.BusinessFormsDropDownList.DataValueField = "BusinessTypeID";
            this.BusinessFormsDropDownList.DataSource = this._orderSurveyPointBL.GetListBusinessFormsForDDL();
            this.BusinessFormsDropDownList.DataBind();
        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._msRegionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
            //this.RegionDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void ShowZipCodeDDL()
        {
            this.ZipCodeDDL.Items.Clear();
            this.ZipCodeDDL.DataSource = this._zipCodeBL.GetListZipCodeDDLByRegionID(Convert.ToInt64(this.RegionDDL.SelectedValue));
            this.ZipCodeDDL.DataValueField = "ZipCode";
            this.ZipCodeDDL.DataTextField = "ZipCode";
            this.ZipCodeDDL.DataBind();
        }

        protected void ShowDocument()
        {
            this.DocumentTypeCheckBoxList.Items.Clear();
            this.DocumentTypeCheckBoxList.DataSource = this._msDocumentTypeBL.GetDocumentType(Convert.ToInt64(this.SPidHiddenField.Value));
            this.DocumentTypeCheckBoxList.DataValueField = "DocumentTypeID";
            this.DocumentTypeCheckBoxList.DataTextField = "DocumentTypeName";
            this.DocumentTypeCheckBoxList.DataBind();
        }

        protected void ShowData()
        {
            TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            this.CompanyNameTextBox.Text = _trOrderSPNotMovable.SurveyPointName;
            this.BusinessFormsDropDownList.SelectedValue = _trOrderSPNotMovable.BusinessTypeID.ToString();
            //this.LineofBussinesTextBox.Text = _trOrderSPNotMovable.BusinessLine;
            this.AddressTextBox.Text = _trOrderSPNotMovable.Address;
            this.ClueTextBox.Text = _trOrderSPNotMovable.Clue;
            this.PhoneNumberTextBox.Text = _trOrderSPNotMovable.PhoneNumber;
            this.ExtentionTextBox.Text = _trOrderSPNotMovable.Extension;
            this.ContactNumberTextBox.Text = _trOrderSPNotMovable.ContactNumber;
            this.RegionDDL.SelectedValue = _trOrderSPNotMovable.RegionID.ToString();
            this.ShowZipCodeDDL();
            //this.ZipCodeTextBox.Text = _trOrderSPNotMovable.ZipCode;
            this.ZipCodeDDL.SelectedValue = _trOrderSPNotMovable.ZipCode;
            this.RemarkTextBox.Text = _trOrderSPNotMovable.Remark;

            //this.ReadOnlyTextBox(_trOrderSPNotMovable.SPStatus);
            this.ReadOnlyTextBox(Convert.ToByte(this.OrderVersionHiddenField.Value));

            List<TrReqDocNotMovable> _reqDocList = this._orderSurveyPointBL.GetListReqDocbySPIDNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

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

        protected void EditSurveyPoint()
        {
            Boolean _result = false;
            this.SetCheckBoxValue();

            TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            _trOrderSPNotMovable.SurveyPointName = this.CompanyNameTextBox.Text;
            _trOrderSPNotMovable.BusinessTypeID = Convert.ToInt64(this.BusinessFormsDropDownList.SelectedValue);
            //_trOrderSPNotMovable.BusinessLine = this.LineofBussinesTextBox.Text;
            _trOrderSPNotMovable.Address = this.AddressTextBox.Text;
            _trOrderSPNotMovable.Clue = this.ClueTextBox.Text;
            //_trOrderSPNotMovable.ZipCode = this.ZipCodeTextBox.Text;
            _trOrderSPNotMovable.ZipCode = this.ZipCodeDDL.SelectedValue;
            _trOrderSPNotMovable.PhoneNumber = this.PhoneNumberTextBox.Text;
            _trOrderSPNotMovable.Extension = this.ExtentionTextBox.Text;
            _trOrderSPNotMovable.ContactNumber = this.ContactNumberTextBox.Text;
            _trOrderSPNotMovable.RegionID = Convert.ToInt64(this.RegionDDL.SelectedValue);
            _trOrderSPNotMovable.Remark = this.RemarkTextBox.Text;
            _trOrderSPNotMovable.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _trOrderSPNotMovable.ModifiedDate = DateTime.Now;
            _trOrderSPNotMovable.OriginatorID = this.GetOriginatorID();
            _trOrderSPNotMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

            TrReqDocNotMovable _trReqDocNotMovable = new TrReqDocNotMovable();
            _trReqDocNotMovable.ModifiedDate = DateTime.Now;
            _trReqDocNotMovable.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _trReqDocNotMovable.Remark = this.NoteDocumentTextBox.Text;

            _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable, _trReqDocNotMovable, this.DokumentTypeHiddenField.Value);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value + "");
            }
        }

        protected void SetCheckBoxValue()
        {
            foreach (ListItem _item in this.DocumentTypeCheckBoxList.Items)
            {
                if (_item.Selected)
                {
                    if (this.DokumentTypeHiddenField.Value == "")
                    {
                        this.DokumentTypeHiddenField.Value = _item.Value;
                    }
                    else
                    {
                        this.DokumentTypeHiddenField.Value += "," + _item.Value;
                    }
                }
            }
        }

        private Boolean ValidateCBL()
        {
            Boolean _result = false;
            foreach (ListItem _cBox in this.DocumentTypeCheckBoxList.Items)
            {
                if (_cBox.Selected)
                {
                    return true;
                }
            }
            return _result;
        }

        protected void SaveButton_Click1(object sender, ImageClickEventArgs e)
        {
            if (this.OrderSPIDHiddenField.Value != "")
            {
                this.EditSurveyPoint();
            }
            else
            {
                this.SetCheckBoxValue();

                if (this.DokumentTypeHiddenField.Value != "" && this.NoteDocumentTextBox.Text == "")
                {
                    this.WarningLabel.Text = "Required Document Note Must Be Filled";
                    this.DokumentTypeHiddenField.Value = "";
                }

                if (this.ValidateCBL() == false && this.NoteDocumentTextBox.Text != "")
                {
                    this.WarningLabel.Text = "Required Document Must Be Filled";
                    this.DokumentTypeHiddenField.Value = "";
                }
                if (this.ValidateCBL() == false && this.NoteDocumentTextBox.Text == "" ||
                    this.ValidateCBL() == true && this.NoteDocumentTextBox.Text != ""
                    )
                {

                    this.InitializeData();
                    long _custID = Convert.ToInt64(Session[this._sesCustID]);

                    TrOrder _trOrder = new TrOrder();
                    if (this.OrderIdHiddenField.Value == "")
                    {
                        _trOrder.CustomerID = _custID;
                        _trOrder.OrderCode = new AutoNumber().GetAutoNumberOrder(_custID);
                        _trOrder.OrderTypeID = Convert.ToInt32(this._orderType[0]);
                        _trOrder.OrderDate = DateTime.Now;
                        _trOrder.OrderVersion = OrderVersionMapper.GetOrderVersion(OrderVersion.Draft);
                        _trOrder.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Initialized);
                        _trOrder.ProceedDate = this._defaultDate;
                        _trOrder.Remark = HttpContext.Current.Session["RemarkOrder"].ToString();
                        _trOrder.RowStatus = 0;
                        _trOrder.CreatedBy = HttpContext.Current.User.Identity.Name;
                        _trOrder.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        _trOrder = new OrderBL().GetSingleOrderByOrderID(Convert.ToInt64(this.OrderIdHiddenField.Value));
                        _trOrder.Remark = HttpContext.Current.Session["RemarkOrder"].ToString();
                        _trOrder.ModifiedBy = HttpContext.Current.User.Identity.Name;
                        _trOrder.ModifiedDate = DateTime.Now;
                    }

                    TrOrderSPNotMovable _trOrderSPNotMovable = new TrOrderSPNotMovable();

                    DateTime _now = DateTime.Now;

                    _trOrderSPNotMovable.SurveyPointName = this.CompanyNameTextBox.Text;
                    if (this.BusinessFormsDropDownList.SelectedValue != "null")
                    {
                        _trOrderSPNotMovable.BusinessTypeID = Convert.ToInt64(this.BusinessFormsDropDownList.SelectedValue);
                    }
                    //_trOrderSPNotMovable.BusinessLine = this.LineofBussinesTextBox.Text;
                    _trOrderSPNotMovable.Address = this.AddressTextBox.Text;
                    _trOrderSPNotMovable.Clue = this.ClueTextBox.Text;
                    //_trOrderSPNotMovable.ZipCode = this.ZipCodeTextBox.Text;
                    _trOrderSPNotMovable.ZipCode = this.ZipCodeDDL.SelectedValue;
                    _trOrderSPNotMovable.Remark = this.RemarkTextBox.Text;
                    _trOrderSPNotMovable.RowStatus = 0;
                    _trOrderSPNotMovable.CreatedBy = HttpContext.Current.User.Identity.Name;
                    _trOrderSPNotMovable.CreatedDate = _now;
                    _trOrderSPNotMovable.SurveyPointID = Convert.ToInt64(this.SPidHiddenField.Value);
                    _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Initialized);
                    _trOrderSPNotMovable.PhoneNumber = this.PhoneNumberTextBox.Text;
                    _trOrderSPNotMovable.Extension = this.ExtentionTextBox.Text;
                    _trOrderSPNotMovable.ContactNumber = this.ContactNumberTextBox.Text;
                    _trOrderSPNotMovable.UserTakeOver = "";
                    _trOrderSPNotMovable.FgComplaint = false;
                    
                    if (this.RegionDDL.SelectedValue != "null")
                    {
                        _trOrderSPNotMovable.RegionID = Convert.ToInt64(this.RegionDDL.SelectedValue);
                    }
                    _trOrderSPNotMovable.OriginatorID = this.GetOriginatorID();
                    _trOrderSPNotMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

                    TrReqDocNotMovable _trReqDocNotMovable = new TrReqDocNotMovable();
                    _trReqDocNotMovable.CreatedDate = _now;
                    _trReqDocNotMovable.CreatedBy = HttpContext.Current.User.Identity.Name;
                    _trReqDocNotMovable.Remark = this.NoteDocumentTextBox.Text;
                    _trReqDocNotMovable.RowStatus = 0;                    

                    long _orderIDNew = 0;
                    int _success = this._orderSurveyPointBL.InsertOrderWithCorporate(this.DokumentTypeHiddenField.Value, this.OrderIdHiddenField.Value, _trOrder, _trOrderSPNotMovable, _trReqDocNotMovable, ref _orderIDNew);

                    if (_success == -1)
                    {
                        this.WarningLabel.Text = "You Successful Add Personal Respondent";
                        this.ClearData();
                        foreach (ListItem _cBox in this.DocumentTypeCheckBoxList.Items)
                        {
                            _cBox.Selected = false;
                        }
                        if (this.OrderIdHiddenField.Value != "")
                        {
                            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value + "");
                        }
                        else
                        {
                            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + _orderIDNew + "");
                        }
                    }
                    else
                    {
                        this.ClearLabel();
                        this.WarningLabel.Text = "You Failed Add Data";
                    }
                }
            }
        }

        private long GetOriginatorID()
        {
            long _result = 0;

            //validasi apakah row adalah originator, bila ya originatorID = -1
            Int64 _spOriID = Convert.ToInt64(ConfigurationManager.AppSettings["OriginatorID"].ToString());
            if (this.OrderIdHiddenField.Value == "")
            {
                String _errMessage = "";
                if (this._surveyPointBL.IsSurveyPointOriginator(Convert.ToInt64(this.SPidHiddenField.Value), _spOriID, ref _errMessage))
                {
                    _result = -1; //merupakan originator
                }
                else
                {
                    Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value);
                }
            }
            else
            {
                //search within order (detailnya)
                //count detail, if 0, row pertama, cek input merupakan originator ato bukan; kalau ya -1
                //              else, row kedua/lebih, cek input merupakan originator ato bukan; kalau ya false, kalau tidak refer ke detail pertama yg originator = -1
                List<OrderDetail> _listOrderDt = this._orderBL.GetListSPByOrderID(Convert.ToInt64(this.OrderIdHiddenField.Value));
                if (_listOrderDt.Count <= 0)
                {
                    String _errMessage = "";
                    if (this._surveyPointBL.IsSurveyPointOriginator(Convert.ToInt64(this.SPidHiddenField.Value), _spOriID, ref _errMessage))
                    {
                        _result = -1; //merupakan originator
                    }
                }
                else
                {
                    String _errMessage = "";
                    if (this._surveyPointBL.IsSurveyPointOriginator(Convert.ToInt64(this.SPidHiddenField.Value), _spOriID, ref _errMessage))
                    {
                        Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value);
                    }
                    else
                    {
                        OrderDetail _odt = _listOrderDt.Find(a => a.SurveyPointID == _spOriID);
                        _result = _odt.OrderSPID;
                    }
                }
            }

            return _result;
        }

        protected void CancelButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._orderType[0] + "," + this._orderType[1] + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey) + "&" + this._orderVersion + "=" + this.OrderVersionHiddenField.Value);
        }

        protected void ResetButton_Click(object sender, ImageClickEventArgs e)
        {
            if ((this._nvcExtractor.GetValue(this._orderSPID)).ToString() != "")
            {
                this.ShowData();
            }
            else
            {
                this.ClearData();
                this.ClearLabel();
                this.SetAttribute();
                this.DokumentTypeHiddenField.Value = "";
            }
        }

        protected void RegionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowZipCodeDDL();
        }
    }
}
