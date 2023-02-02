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
    public partial class AddGuarantorRespondent : OrderBase
    {
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();
        private OrderBL _orderBL = new OrderBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private DocumentTypeBL _msDocumentTypeBL = new DocumentTypeBL();
        private RegionBL _msRegionBL = new RegionBL();
        private RegionZipCodeBL _zipCodeBL = new RegionZipCodeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteralAddSurveyPoint + " " + (new SurveyPointBL().GetSingleSurveyPoint(Convert.ToInt32(this._nvcExtractor.GetValue(this._SPid))).SurveyPointName);
                //PointSurveyMapper.GetPointSurveyName(Convert.ToInt32(this._nvcExtractor.GetValue(this._SPid)));

                this.SaveGuarantorRespondent.ImageUrl = this._imageURL + "btnSave2.png";
                this.CancelGuarantorRespondent.ImageUrl = this._imageURL + "btnCancel2.png";
                this.ResetGuarantorRespondent.ImageUrl = this._imageURL + "btnReset.png";

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
                this.OrderIdHiddenField.Value = this._nvcExtractor.GetValue(this._codeKey);
                this.SPidHiddenField.Value = this._nvcExtractor.GetValue(this._SPid);
                this.OrderSPIDHiddenField.Value = this._nvcExtractor.GetValue(this._orderSPID);
                this.OrderVersionHiddenField.Value = this._nvcExtractor.GetValue(this._orderVersion);

                if (this.OrderVersionHiddenField.Value == (OrderVersionMapper.GetOrderVersion(OrderVersion.Final)).ToString())
                {
                    this.SaveGuarantorRespondent.Visible = false;
                    this.ResetGuarantorRespondent.Visible = false;
                }

                this.ClearData();
                this.ClearLabel();
                this.InitializeData();
                this.SetAttribute();
                this.ShowIDTypeDDL();
                this.ShowDocument();
                this.ShowRegionDDL();
                this.ShowZipCodeDDL();

                if (this.OrderIdHiddenField.Value != "" && this.OrderSPIDHiddenField.Value != "")
                {
                    this.ShowData();
                }

                long _cekFormIsOriginator = this.GetOriginatorID();
            }
        }

        protected void StatusRBL_OnTextChanged(object sender, EventArgs e)
        {
            if (this.StatusRBL.SelectedValue != "Married")
            {
                this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.SpouseTextBox.Text = "";
                this.SpouseTextBoxRequiredFieldValidator.Enabled = false;
            }
            else
            {
                this.SpouseTextBox.Attributes.Remove("ReadOnly");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #FFFFFF");
                this.SpouseTextBoxRequiredFieldValidator.Enabled = true;
            }

        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._type);
            this._orderType = _queryString.Split(',');
        }

        protected void SetAttribute()
        {
            this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
            this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.DateOfBirthTextBox.Attributes.Add("ReadOnly", "True");
            this.DateOfBirthTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
            this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.SpouseTextBox.Text = "";
            this.SpouseTextBoxRequiredFieldValidator.Enabled = false;

            //this.ZipCodeTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ZipCodeTextBox.ClientID + "," + this.ZipCodeTextBox.ClientID + ",500" + ")");
            this.IDNoTextBox.Attributes.Add("OnKeyUp", "return formatangka2(" + this.IDNoTextBox.ClientID + "," + this.IDNoTextBox.ClientID + ",500" + ")");
            this.HomePhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.HomePhoneTextBox.ClientID + "," + this.HomePhoneTextBox.ClientID + ",500" + ")");
            this.MobilePhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.MobilePhoneTextBox.ClientID + "," + this.MobilePhoneTextBox.ClientID + ",500" + ")");
            this.ExtentionTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ExtentionTextBox.ClientID + "," + this.ExtentionTextBox.ClientID + ",500" + ")");
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void ClearData()
        {
            DateTime _now = DateTime.Now;

            this.FullNameTextBox.Text = "";
            this.SpouseTextBox.Text = "";
            this.PlaceOfBirthTextBox.Text = "";
            this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_now);
            this.IDNoTextBox.Text = "";
            this.IDAddressTextBox.Text = "";
            this.CurrentAddressTextBox.Text = "";
            this.ClueTextBox.Text = "";
            //this.ZipCodeTextBox.Text = "";
            this.NoteDocumentTextBox.Text = "";
            this.HomePhoneTextBox.Text = "";
            this.MobilePhoneTextBox.Text = "";
            this.ExtentionTextBox.Text = "";
            this.NoteTextBox.Text = "";
            this.StatusRBL.SelectedValue = "Single";
            this.SpouseTextBox.Attributes.Remove("ReadOnly");
            this.SpouseTextBox.Attributes.Add("Style", "background-color: #FFFFFF");
            this.JobTitleTextBox.Text = "";
            this.JobTypeTextBox.Text = "";
            this.BusinessLineTextBox.Text = "";
            foreach (ListItem _cBox in this.DocumentTypeCheckBoxList.Items)
            {
                _cBox.Selected = false;
            }
        }

        private void ReadOnlyTextBox(byte _prmSPStatus)
        {
            //if (_prmSPStatus == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed))
            if (this.OrderVersionHiddenField.Value == (OrderVersionMapper.GetOrderVersion(OrderVersion.Final)).ToString())
            {
                this.FullNameTextBox.Attributes.Add("ReadOnly", "True");
                this.FullNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.PlaceOfBirthTextBox.Attributes.Add("ReadOnly", "True");
                this.PlaceOfBirthTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.IDNoTextBox.Attributes.Add("ReadOnly", "True");
                this.IDNoTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.IDAddressTextBox.Attributes.Add("ReadOnly", "True");
                this.IDAddressTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.CurrentAddressTextBox.Attributes.Add("ReadOnly", "True");
                this.CurrentAddressTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.MobilePhoneTextBox.Attributes.Add("ReadOnly", "True");
                this.MobilePhoneTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.DateOfBirthTextBox.Attributes.Add("ReadOnly", "True");
                this.DateOfBirthTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.HomePhoneTextBox.Attributes.Add("ReadOnly", "True");
                this.HomePhoneTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ExtentionTextBox.Attributes.Add("ReadOnly", "True");
                this.ExtentionTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                //this.ZipCodeTextBox.Attributes.Add("ReadOnly", "True");
                //this.ZipCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.NoteDocumentTextBox.Attributes.Add("ReadOnly", "True");
                this.NoteDocumentTextBox.Attributes.Add("Style", "background-color: #DDDDDD");
                this.NoteTextBox.Attributes.Add("ReadOnly", "True");
                this.NoteTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ClueTextBox.Attributes.Add("ReadOnly", "True");
                this.ClueTextBox.Attributes.Add("Style", "background-color: #DDDDDD");
                this.JobTitleTextBox.Attributes.Add("ReadOnly", "True");
                this.JobTitleTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.JobTypeTextBox.Attributes.Add("ReadOnly", "True");
                this.JobTypeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.BusinessLineTextBox.Attributes.Add("ReadOnly", "True");
                this.BusinessLineTextBox.Attributes.Add("Style", "background-color: #CCCCCC");

                this.StatusRBL.Enabled = false;
                this.NationalityRBL.Enabled = false;
                this.IDDropDownList.Enabled = false;
                this.RegionDDL.Enabled = false;
                this.ZipCodeDDL.Enabled = false;
                this.DocumentTypeCheckBoxList.Enabled = false;
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
        protected void ShowReportIDDDL()
        {
            List<String> _reportList = ReportMapper.ReportList;
            this.IDDropDownList.Items.Clear();
            foreach (var _IDType in _reportList)
            {
                String[] _row = _IDType.Split('|');
                this.IDDropDownList.Items.Add(new ListItem(_row[0], _row[1]));
            }


        }

        protected void showfilter()
        {
            String _filterAttr = ReportMapper.GetFilterAttr(this.IDDropDownList.SelectedValue);
            String[] _attrArr = _filterAttr.Split(',');

            for (int i = 0; i < _attrArr.Length; i++)
            {
                if(_attrArr[i] == "")
                {

                }
            }

        }

        protected void ShowDocument()
        {
            this.DocumentTypeCheckBoxList.Items.Clear();
            this.DocumentTypeCheckBoxList.DataSource = this._msDocumentTypeBL.GetDocumentType(Convert.ToInt64(this.SPidHiddenField.Value));
            this.DocumentTypeCheckBoxList.DataValueField = "DocumentTypeID";
            this.DocumentTypeCheckBoxList.DataTextField = "DocumentTypeName";
            this.DocumentTypeCheckBoxList.DataBind();
        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._msRegionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
        }

        protected void ShowZipCodeDDL()
        {
            this.ZipCodeDDL.Items.Clear();
            this.ZipCodeDDL.DataSource = this._zipCodeBL.GetListZipCodeDDLByRegionID(Convert.ToInt64(this.RegionDDL.SelectedValue));
            this.ZipCodeDDL.DataValueField = "ZipCode";
            this.ZipCodeDDL.DataTextField = "ZipCode";
            this.ZipCodeDDL.DataBind();
        }

        protected void ShowData()
        {
            TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            this.FullNameTextBox.Text = _trOrderSPMovable.SurveyPointName;
            this.StatusRBL.SelectedValue = _trOrderSPMovable.MaritalStatus.ToString();
            this.SpouseTextBox.Text = _trOrderSPMovable.SpouseName;
            this.NationalityRBL.SelectedValue = _trOrderSPMovable.Nationality;
            this.PlaceOfBirthTextBox.Text = _trOrderSPMovable.PlaceOfBirth;
            this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_trOrderSPMovable.DateOfBirth);
            this.IDDropDownList.SelectedValue = _trOrderSPMovable.IDType.ToString();
            this.IDNoTextBox.Text = _trOrderSPMovable.IDNo;
            this.RegionDDL.SelectedValue = _trOrderSPMovable.RegionID.ToString();
            this.IDAddressTextBox.Text = _trOrderSPMovable.IDAddress;
            this.CurrentAddressTextBox.Text = _trOrderSPMovable.HomeAddress;
            this.MobilePhoneTextBox.Text = _trOrderSPMovable.MobilePhoneNumber;
            this.HomePhoneTextBox.Text = _trOrderSPMovable.HomePhoneNumber;
            this.NoteTextBox.Text = _trOrderSPMovable.Remark;
            this.ClueTextBox.Text = _trOrderSPMovable.Clue;
            //this.ZipCodeTextBox.Text = _trOrderSPMovable.ZipCode;
            this.ShowZipCodeDDL();
            this.ZipCodeDDL.SelectedValue = _trOrderSPMovable.ZipCode;
            this.ExtentionTextBox.Text = _trOrderSPMovable.Extension;
            this.JobTitleTextBox.Text = _trOrderSPMovable.JobTitle;
            this.JobTypeTextBox.Text = _trOrderSPMovable.JobType;
            this.BusinessLineTextBox.Text = _trOrderSPMovable.BusinessLine;

            if (this.StatusRBL.SelectedValue != "Married")
            {
                this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.SpouseTextBox.Text = "";
                this.SpouseTextBoxRequiredFieldValidator.Enabled = false;
            }
            else
            {
                this.SpouseTextBox.Attributes.Remove("ReadOnly");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #FFFFFF");
                this.SpouseTextBoxRequiredFieldValidator.Enabled = true;
            }

            this.ReadOnlyTextBox(_trOrderSPMovable.SPStatus);

            List<TrReqDocMovable> _reqDocList = this._orderSurveyPointBL.GetListReqDocbySPIDMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            foreach (ListItem _item in this.DocumentTypeCheckBoxList.Items)
            {
                foreach (TrReqDocMovable _data in _reqDocList)
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
            //get sngle
            Boolean _result = false;
            this.SetCheckBoxValue();

            TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            _trOrderSPMovable.SurveyPointName = this.FullNameTextBox.Text;
            _trOrderSPMovable.MaritalStatus = this.StatusRBL.SelectedValue;
            _trOrderSPMovable.SpouseName = this.SpouseTextBox.Text;
            _trOrderSPMovable.Nationality = this.NationalityRBL.SelectedValue;
            _trOrderSPMovable.PlaceOfBirth = this.PlaceOfBirthTextBox.Text;
            _trOrderSPMovable.DateOfBirth = DateFormMapper.GetValue(this.DateOfBirthTextBox.Text);
            _trOrderSPMovable.IDType = Convert.ToByte(this.IDDropDownList.SelectedValue);
            _trOrderSPMovable.IDNo = this.IDNoTextBox.Text;
            _trOrderSPMovable.IDAddress = this.IDAddressTextBox.Text;
            _trOrderSPMovable.HomeAddress = this.CurrentAddressTextBox.Text;
            _trOrderSPMovable.MobilePhoneNumber = this.MobilePhoneTextBox.Text;
            _trOrderSPMovable.HomePhoneNumber = this.HomePhoneTextBox.Text;
            _trOrderSPMovable.Extension = this.ExtentionTextBox.Text;
            _trOrderSPMovable.RegionID = Convert.ToInt64(this.RegionDDL.SelectedValue);
            _trOrderSPMovable.Clue = this.ClueTextBox.Text;
            //_trOrderSPMovable.ZipCode = this.ZipCodeTextBox.Text;
            _trOrderSPMovable.ZipCode = this.ZipCodeDDL.SelectedValue;
            _trOrderSPMovable.Remark = this.NoteTextBox.Text;
            _trOrderSPMovable.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _trOrderSPMovable.ModifiedDate = DateTime.Now;
            _trOrderSPMovable.RowStatus = 0;
            _trOrderSPMovable.SurveyPointID = Convert.ToInt64(this.SPidHiddenField.Value);
            _trOrderSPMovable.SPStatus = GlobalStatusMapper.GetStatus(GlobalStatus.OnHold);
            _trOrderSPMovable.Extension = this.ExtentionTextBox.Text;
            _trOrderSPMovable.JobTitle = this.JobTitleTextBox.Text;
            _trOrderSPMovable.JobType = this.JobTypeTextBox.Text;
            _trOrderSPMovable.BusinessLine = this.BusinessLineTextBox.Text;
            _trOrderSPMovable.OriginatorID = this.GetOriginatorID();
            _trOrderSPMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

            //update

            TrReqDocMovable _trReqDocMovable = new TrReqDocMovable();
            _trReqDocMovable.ModifiedDate = DateTime.Now;
            _trReqDocMovable.ModifiedBy = HttpContext.Current.User.Identity.Name;
            _trReqDocMovable.Remark = this.NoteDocumentTextBox.Text;

            _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable, _trReqDocMovable, this.DokumentTypeHiddenField.Value);

            if (_result)
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value + "");
            }
        }

        protected void SaveGuarantorRespondent_Click(object sender, ImageClickEventArgs e)
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
                if (this.validatecbl() == false && this.NoteDocumentTextBox.Text != "")
                {
                    this.WarningLabel.Text = "Required Document Must Be Filled";
                    this.DokumentTypeHiddenField.Value = "";
                }
                if (this.validatecbl() == false && this.NoteDocumentTextBox.Text == "" ||
                    this.validatecbl() == true && this.NoteDocumentTextBox.Text != ""
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
                    }
                    else
                    {
                        _trOrder = new OrderBL().GetSingleOrderByOrderID(Convert.ToInt64(this.OrderIdHiddenField.Value));
                        _trOrder.Remark = HttpContext.Current.Session["RemarkOrder"].ToString();
                        _trOrder.ModifiedBy = HttpContext.Current.User.Identity.Name;
                        _trOrder.ModifiedDate = DateTime.Now;
                    }

                    TrOrderSPMovable _trOrderSPMovable = new TrOrderSPMovable();

                    DateTime _now = DateTime.Now;

                    _trOrderSPMovable.SurveyPointName = this.FullNameTextBox.Text;
                    _trOrderSPMovable.MaritalStatus = this.StatusRBL.SelectedValue;
                    _trOrderSPMovable.SpouseName = this.SpouseTextBox.Text;
                    _trOrderSPMovable.Nationality = this.NationalityRBL.SelectedValue;
                    _trOrderSPMovable.PlaceOfBirth = this.PlaceOfBirthTextBox.Text;
                    _trOrderSPMovable.DateOfBirth = DateFormMapper.GetValue(this.DateOfBirthTextBox.Text);
                    _trOrderSPMovable.IDType = Convert.ToByte(this.IDDropDownList.SelectedValue);
                    _trOrderSPMovable.IDNo = this.IDNoTextBox.Text;
                    _trOrderSPMovable.IDAddress = this.IDAddressTextBox.Text;
                    _trOrderSPMovable.HomeAddress = this.CurrentAddressTextBox.Text;
                    _trOrderSPMovable.MobilePhoneNumber = this.MobilePhoneTextBox.Text;
                    _trOrderSPMovable.HomePhoneNumber = this.HomePhoneTextBox.Text;
                    _trOrderSPMovable.RegionID = Convert.ToInt64(this.RegionDDL.SelectedValue);
                    _trOrderSPMovable.Clue = this.ClueTextBox.Text;
                    //_trOrderSPMovable.ZipCode = this.ZipCodeTextBox.Text;
                    _trOrderSPMovable.ZipCode = this.ZipCodeDDL.SelectedValue;
                    _trOrderSPMovable.Remark = this.NoteTextBox.Text;
                    _trOrderSPMovable.RowStatus = 0;
                    _trOrderSPMovable.CreatedBy = HttpContext.Current.User.Identity.Name;
                    _trOrderSPMovable.CreatedDate = _now;
                    _trOrderSPMovable.SurveyPointID = Convert.ToInt64(this.SPidHiddenField.Value);
                    _trOrderSPMovable.SPStatus = GlobalStatusMapper.GetStatus(GlobalStatus.OnHold);
                    _trOrderSPMovable.Extension = this.ExtentionTextBox.Text;
                    _trOrderSPMovable.JobTitle = this.JobTitleTextBox.Text;
                    _trOrderSPMovable.JobType = this.JobTypeTextBox.Text;
                    _trOrderSPMovable.BusinessLine = this.BusinessLineTextBox.Text;
                    _trOrderSPMovable.OriginatorID = this.GetOriginatorID();
                    _trOrderSPMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);
                    _trOrderSPMovable.FgComplaint = false;

                    TrReqDocMovable _trReqDocMovable = new TrReqDocMovable();
                    _trReqDocMovable.CreatedDate = _now;
                    _trReqDocMovable.CreatedBy = HttpContext.Current.User.Identity.Name;
                    _trReqDocMovable.Remark = this.NoteDocumentTextBox.Text;
                    _trReqDocMovable.RowStatus = 0;
                    long _orderIDNew = 0;
                    int _success = this._orderSurveyPointBL.InsertOrderWithPersonal(this.DokumentTypeHiddenField.Value, this.OrderIdHiddenField.Value, _trOrder, _trOrderSPMovable, _trReqDocMovable, ref _orderIDNew);

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
                            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value);
                        }
                        else
                        {
                            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + _orderIDNew);
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
                        //Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this.OrderIdHiddenField.Value);
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

        protected void ResetGuarantorRespondent_Click(object sender, ImageClickEventArgs e)
        {
            if ((this._nvcExtractor.GetValue(this._orderSPID)).ToString() != "")
            {
                this.ShowData();
            }
            else
            {
                this.ClearLabel();
                this.ClearData();
                this.SetAttribute();
                this.DokumentTypeHiddenField.Value = "";
            }
        }

        protected void CancelGuarantorRespondent_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey) + "&" + this._orderVersion + "=" + this.OrderVersionHiddenField.Value);
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

        private Boolean validatecbl()
        {
            Boolean _result = false;
            foreach (ListItem _cbox in this.DocumentTypeCheckBoxList.Items)
            {
                if (_cbox.Selected)
                {
                    return true;
                }
            }
            return _result;
        }

        protected void IDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> _IDTypes = IDTypeMapper.IDTypes;
            foreach (var _IDType in _IDTypes)
            {
                String[] _row = _IDType.Split(',');
                if (_row[0] == this.IDDropDownList.SelectedValue)
                {
                    if (_row[2] == IDTypeMapper.GetIDFormat(FormatTextBox.AllowDot))
                    {
                        this.IDNoTextBox.Attributes.Add("OnKeyUp", "return formatangka2(" + this.IDNoTextBox.ClientID + "," + this.IDNoTextBox.ClientID + ",500" + ")");
                    }
                    else if (_row[2] == IDTypeMapper.GetIDFormat(FormatTextBox.AllowAlphabet))
                    {
                        this.IDNoTextBox.Attributes.Remove("OnKeyUp");
                    }
                }
            }
        }

        protected void RegionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowZipCodeDDL();
        }
    }
}
