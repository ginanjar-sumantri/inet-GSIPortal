using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GSI.Common;
using GSI.Common.Enum;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class AddWorkOrderAssign : WorkOrderBase
    {
        private BusinessTypeBL _businessTypeBL = new BusinessTypeBL();
        private DocumentTypeBL _docTypeBL = new DocumentTypeBL();
        private RegionBL _regionBL = new RegionBL();
        private RegionZipCodeBL _zipCodeBL = new RegionZipCodeBL();
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private EmployeeBL _employeeBL = new EmployeeBL();
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageAddWorkOrderAssignTitleLiteral;

                this.AssignImageButton.ImageUrl = this._imageURL + "btnAssign.png";

                this.SetAttribute();
                this.SetInitializeData();

                this.ClearLabel();
                this.ClearData();

                this.ShowDocument();
                this.ShowRegionDDL();
                this.ShowData(this._nvcExtractor.GetValue(this._spType));
            }
        }

        private void SetInitializeData()
        {
            //this._queryString = this._nvcExtractor.GetValue(this._type);
            //this._orderType = _queryString.Split(',');
        }

        private void SetAttribute()
        {
            this.ZipCodeMovTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ZipCodeMovTextBox.ClientID + "," + this.ZipCodeMovTextBox.ClientID + ",500" + ")");
            this.ZipCodeNotMovTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ZipCodeNotMovTextBox.ClientID + "," + this.ZipCodeNotMovTextBox.ClientID + ",500" + ")");
            this.IDNoTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.IDNoTextBox.ClientID + "," + this.IDNoTextBox.ClientID + ",500" + ")");
            this.HomePhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.HomePhoneTextBox.ClientID + "," + this.HomePhoneTextBox.ClientID + ",500" + ")");
            this.MobilePhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.MobilePhoneTextBox.ClientID + "," + this.MobilePhoneTextBox.ClientID + ",500" + ")");
            this.ExtensionMovTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ExtensionMovTextBox.ClientID + "," + this.ExtensionMovTextBox.ClientID + ",500" + ")");

            //set info to readonly
            this.FullNameTextBox.Attributes.Add("ReadOnly", "True"); this.FullNameTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.SpouseTextBox.Attributes.Add("ReadOnly", "True"); this.SpouseTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.PlaceOfBirthTextBox.Attributes.Add("ReadOnly", "True"); this.PlaceOfBirthTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.DateOfBirthTextBox.Attributes.Add("ReadOnly", "True"); this.DateOfBirthTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.IDNoTextBox.Attributes.Add("ReadOnly", "True"); this.IDNoTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.IDAddressTextBox.Attributes.Add("ReadOnly", "True"); this.IDAddressTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.CurrentAddressTextBox.Attributes.Add("ReadOnly", "True"); this.CurrentAddressTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ClueMovTextBox.Attributes.Add("ReadOnly", "True"); this.ClueMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.MobilePhoneTextBox.Attributes.Add("ReadOnly", "True"); this.MobilePhoneTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.HomePhoneTextBox.Attributes.Add("ReadOnly", "True"); this.HomePhoneTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ZipCodeMovTextBox.Attributes.Add("ReadOnly", "True"); this.ZipCodeMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.NoteDocumentMovTextBox.Attributes.Add("ReadOnly", "True"); this.NoteDocumentMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.RemarkMovTextBox.Attributes.Add("ReadOnly", "True"); this.RemarkMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.RegionMovTextBox.Attributes.Add("ReadOnly", "True"); this.RegionMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.IDTextBox.Attributes.Add("ReadOnly", "True"); this.IDTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ExtensionMovTextBox.Attributes.Add("ReadOnly", "True"); this.ExtensionMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.StatusRBL.Enabled = false;
            this.NationalityRBL.Enabled = false;
            this.DocumentTypeMovCheckBoxList.Enabled = false;

            this.BusinessFormsTextBox.Attributes.Add("ReadOnly", "True"); this.BusinessFormsTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.CompanyNameTextBox.Attributes.Add("ReadOnly", "True"); this.CompanyNameTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.LineofBussinesTextBox.Attributes.Add("ReadOnly", "True"); this.LineofBussinesTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.AddressTextBox.Attributes.Add("ReadOnly", "True"); this.AddressTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ClueNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.ClueNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.PhoneNumberTextBox.Attributes.Add("ReadOnly", "True"); this.PhoneNumberTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ExtensionNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.ExtensionNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ContactNumberTextBox.Attributes.Add("ReadOnly", "True"); this.ContactNumberTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.RegionNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.RegionNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.ZipCodeNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.ZipCodeNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.NoteDocumentNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.NoteDocumentNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");
            this.RemarkNotMovTextBox.Attributes.Add("ReadOnly", "True"); this.RemarkNotMovTextBox.Attributes.Add("style", "background-color: #d4d0c8");

            this.DocumentTypeNotMovCheckBoxList.Enabled = false;
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void ClearData()
        {
            DateTime _now = DateTime.Now;

            //movable
            this.FullNameTextBox.Text = "";
            this.SpouseTextBox.Text = "";
            this.PlaceOfBirthTextBox.Text = "";
            this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_now);
            this.IDNoTextBox.Text = "";
            this.IDAddressTextBox.Text = "";
            this.CurrentAddressTextBox.Text = "";
            this.ClueMovTextBox.Text = "";
            this.ZipCodeMovTextBox.Text = "";
            this.NoteDocumentMovTextBox.Text = "";
            this.HomePhoneTextBox.Text = "";
            this.MobilePhoneTextBox.Text = "";
            this.ExtensionMovTextBox.Text = "";
            this.RemarkMovTextBox.Text = "";
            this.RemarkComplaintTextBox.Text = "";

            foreach (ListItem _cBox in this.DocumentTypeMovCheckBoxList.Items)
            {
                _cBox.Selected = false;
            }

            //not movable
            this.CompanyNameTextBox.Text = "";
            this.LineofBussinesTextBox.Text = "";
            this.AddressTextBox.Text = "";
            this.ClueNotMovTextBox.Text = "";
            this.ZipCodeNotMovTextBox.Text = "";
            this.NoteDocumentNotMovTextBox.Text = "";
            this.RemarkNotMovTextBox.Text = "";
            this.PhoneNumberTextBox.Text = "";
            this.ContactNumberTextBox.Text = "";
            this.ExtensionNotMovTextBox.Text = "";
            this.RemarkComplaintTextBox2.Text = "";

            foreach (ListItem _cBox in this.DocumentTypeNotMovCheckBoxList.Items)
            {
                _cBox.Selected = false;
            }

            //bottom data
            this.DateCreateLiteral.Text = _now.ToString("dd-MM-yyyy "); //+ _now.Hour.ToString().PadLeft(2, '0') + ":" + _now.Minute.ToString().PadLeft(2, '0') + ":" + _now.Second.ToString().PadLeft(2, '0');

        }

        protected void ShowDocument()
        {
            List<MsDocumentType> _docTypeList = this._docTypeBL.GetDocumentType(Convert.ToInt64(this._nvcExtractor.GetValue(this._SPid)));
            this.DocumentTypeMovCheckBoxList.Items.Clear();
            this.DocumentTypeMovCheckBoxList.DataSource = _docTypeList;
            this.DocumentTypeMovCheckBoxList.DataValueField = "DocumentTypeID";
            this.DocumentTypeMovCheckBoxList.DataTextField = "DocumentTypeName";
            this.DocumentTypeMovCheckBoxList.DataBind();

            this.DocumentTypeNotMovCheckBoxList.Items.Clear();
            this.DocumentTypeNotMovCheckBoxList.DataSource = _docTypeList;
            this.DocumentTypeNotMovCheckBoxList.DataValueField = "DocumentTypeID";
            this.DocumentTypeNotMovCheckBoxList.DataTextField = "DocumentTypeName";
            this.DocumentTypeNotMovCheckBoxList.DataBind();
        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._regionBL.GetListRegionDDLForWorkAssign();
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
            //this.RegionDDL.Items.Insert(0, new ListItem("[Choose One]", "0"));
        }

        protected void ShowZipCodeDDL()
        {
            this.ZipCodeDDL.Items.Clear();
            this.ZipCodeDDL.DataSource = this._zipCodeBL.GetListZipCodeDDLByRegionID(Convert.ToInt64(this.RegionDDL.SelectedValue));
            this.ZipCodeDDL.DataValueField = "ZipCode";
            this.ZipCodeDDL.DataTextField = "ZipCode";
            this.ZipCodeDDL.DataBind();
            this.ZipCodeDDL.Items.Insert(0, new ListItem("ALL", "%"));
        }

        protected void ShowSurveyor(Int64 _prmRegion, String _prmZipCode)
        {
            this.SurveyorDDL.DataTextField = "EmployeeName";
            this.SurveyorDDL.DataValueField = "SurveyorID";
            this.SurveyorDDL.DataSource = this._surveyorBL.GetSurveyorByRegionIDAndZipCode(_prmRegion, _prmZipCode);
            this.SurveyorDDL.DataBind();
        }

        protected void StatusRBL_OnTextChanged(object sender, EventArgs e)
        {
            if (this.StatusRBL.SelectedValue != "Married")
            {
                this.SpouseTextBox.Attributes.Add("ReadOnly", "True");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.SpouseTextBox.Text = "";
            }
            else
            {
                this.SpouseTextBox.Attributes.Remove("ReadOnly");
                this.SpouseTextBox.Attributes.Add("Style", "background-color: #FFFFFF");
            }
        }

        private void ShowPanel(String _prmTemplateForm)
        {
            if (_prmTemplateForm == "0")
            {
                this.PanelMovable.Visible = true;
                this.PanelNotMovable.Visible = false;
            }
            else
            {
                this.PanelMovable.Visible = false;
                this.PanelNotMovable.Visible = true;
            }
        }

        private void ShowData(String _prmTemplateForm)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
            String _spID = this._nvcExtractor.GetValue(this._orderSPID);

            this.ShowPanel(_prmTemplateForm);
            switch (_prmTemplateForm)
            {
                case "0":
                    TrOrderSPMovable _trOrderSPMovable = this._orderSPBL.GetSingleTrOrderMovable(Convert.ToInt64(_spID));

                    this.FullNameTextBox.Text = _trOrderSPMovable.SurveyPointName;
                    this.StatusRBL.SelectedValue = _trOrderSPMovable.MaritalStatus.ToString();
                    this.SpouseTextBox.Text = _trOrderSPMovable.SpouseName;
                    this.NationalityRBL.SelectedValue = _trOrderSPMovable.Nationality;
                    this.PlaceOfBirthTextBox.Text = _trOrderSPMovable.PlaceOfBirth;
                    this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_trOrderSPMovable.DateOfBirth);
                    this.IDTextBox.Text = (IDTypeMapper.GetIDTypeText(_trOrderSPMovable.IDType));
                    this.IDNoTextBox.Text = _trOrderSPMovable.IDNo;
                    this.RegionMovTextBox.Text = (this._regionBL.GetMsRegionByRegionId(_trOrderSPMovable.RegionID).RegionName);
                    this.IDAddressTextBox.Text = _trOrderSPMovable.IDAddress;
                    this.CurrentAddressTextBox.Text = _trOrderSPMovable.HomeAddress;
                    this.MobilePhoneTextBox.Text = _trOrderSPMovable.MobilePhoneNumber;
                    this.HomePhoneTextBox.Text = _trOrderSPMovable.HomePhoneNumber;
                    this.ExtensionMovTextBox.Text = _trOrderSPMovable.Extension;
                    this.ClueMovTextBox.Text = _trOrderSPMovable.Clue;
                    this.ZipCodeMovTextBox.Text = _trOrderSPMovable.ZipCode;
                    this.RemarkMovTextBox.Text = _trOrderSPMovable.Remark;
                    this.RemarkComplaintTextBox.Text = _trOrderSPMovable.RemarkComplaint;

                    List<TrReqDocMovable> _reqDocMovList = this._orderSPBL.GetListReqDocbySPIDMovable(Convert.ToInt64(_spID));

                    foreach (ListItem _item in this.DocumentTypeMovCheckBoxList.Items)
                    {
                        foreach (TrReqDocMovable _data in _reqDocMovList)
                        {
                            if (_data.DocumentTypeID.ToString().Trim() == _item.Value.Trim())
                            {
                                _item.Selected = true;
                                this.NoteDocumentMovTextBox.Text = _data.Remark;
                            }
                        }
                    }

                    this.RegionDDL.SelectedValue = _trOrderSPMovable.RegionID.ToString();
                    this.ShowZipCodeDDL();
                    this.ZipCodeDDL.SelectedValue = _trOrderSPMovable.ZipCode;
                    this.ShowSurveyor(_trOrderSPMovable.RegionID, _trOrderSPMovable.ZipCode);
                    break;
                case "1":
                    TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSPBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_spID));

                    this.CompanyNameTextBox.Text = _trOrderSPNotMovable.SurveyPointName;
                    this.BusinessFormsTextBox.Text = (this._businessTypeBL.GetSingleBusinessType(_trOrderSPNotMovable.BusinessTypeID)).BusinessTypeName;
                    //this.LineofBussinesTextBox.Text = _trOrderSPNotMovable.BusinessLine;
                    this.AddressTextBox.Text = _trOrderSPNotMovable.Address;
                    this.ClueNotMovTextBox.Text = _trOrderSPNotMovable.Clue;
                    this.ZipCodeNotMovTextBox.Text = _trOrderSPNotMovable.ZipCode;
                    this.PhoneNumberTextBox.Text = _trOrderSPNotMovable.PhoneNumber;
                    this.ExtensionNotMovTextBox.Text = _trOrderSPNotMovable.Extension;
                    this.ContactNumberTextBox.Text = _trOrderSPNotMovable.ContactNumber;
                    this.RegionNotMovTextBox.Text = (this._regionBL.GetMsRegionByRegionId(_trOrderSPNotMovable.RegionID).RegionName);
                    this.RemarkNotMovTextBox.Text = _trOrderSPNotMovable.Remark;
                    this.RemarkComplaintTextBox2.Text = _trOrderSPNotMovable.RemarkComplaint;

                    List<TrReqDocNotMovable> _reqDocNotMovList = this._orderSPBL.GetListReqDocbySPIDNotMovable(Convert.ToInt64(_spID));

                    foreach (ListItem _item in this.DocumentTypeNotMovCheckBoxList.Items)
                    {
                        foreach (TrReqDocNotMovable _data in _reqDocNotMovList)
                        {
                            if (_data.DocumentTypeID.ToString().Trim() == _item.Value.Trim())
                            {
                                _item.Selected = true;
                                this.NoteDocumentNotMovTextBox.Text = _data.Remark;
                            }
                        }
                    }

                    this.RegionDDL.SelectedValue = _trOrderSPNotMovable.RegionID.ToString();
                    this.ShowZipCodeDDL();
                    this.ZipCodeDDL.SelectedValue = _trOrderSPNotMovable.ZipCode;
                    this.ShowSurveyor(_trOrderSPNotMovable.RegionID, _trOrderSPNotMovable.ZipCode);
                    break;
                default:
                    break;
            }
            if (this.SurveyorDDL.SelectedValue != "")
            {
                MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this.SurveyorDDL.SelectedValue));
                this.NIKLabel.Text = (this._employeeBL.GetSingleEmployee(_msSurveyor.EmployeeID)).EmployeeCode;
            }
            else
            {
                this.NIKLabel.Text = "";
            }
        }

        protected void GoImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData(this._nvcExtractor.GetValue(this._spType));
        }

        protected void RegionDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowZipCodeDDL();
            this.ShowSurveyor(Convert.ToInt64(this.RegionDDL.SelectedValue), "%");
            if (this.SurveyorDDL.SelectedValue != "")
            {
                MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this.SurveyorDDL.SelectedValue));
                this.NIKLabel.Text = (this._employeeBL.GetSingleEmployee(_msSurveyor.EmployeeID)).EmployeeCode;
            }
            else
            {
                this.NIKLabel.Text = "";
            }
        }

        protected void ZipCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowSurveyor(Convert.ToInt64(this.RegionDDL.SelectedValue), this.ZipCodeDDL.SelectedValue);
            if (this.SurveyorDDL.SelectedValue != "")
            {
                MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this.SurveyorDDL.SelectedValue));
                this.NIKLabel.Text = (this._employeeBL.GetSingleEmployee(_msSurveyor.EmployeeID)).EmployeeCode;
            }
            else
            {
                this.NIKLabel.Text = "";
            }
        }

        protected void SurveyorDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SurveyorDDL.SelectedValue != "")
            {
                MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this.SurveyorDDL.SelectedValue));
                this.NIKLabel.Text = (this._employeeBL.GetSingleEmployee(_msSurveyor.EmployeeID)).EmployeeCode;
            }
            else
            {
                this.NIKLabel.Text = "";
            }
        }

        protected void AssignImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;

            this.AssignImageButton.Visible = false;

            if (this._nvcExtractor.GetValue(this._spType) == "0")
            {
                DateTime _now = DateTime.Now;
                TrWorkOrderMovable _workOrderMov = new TrWorkOrderMovable();
                _workOrderMov.WorkOrderCode = new AutoNumber().GetAutoNumberWorkOrder(SurveyPointType.Movable);
                _workOrderMov.OrderSPMovableID = Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID));
                _workOrderMov.SurveyorID = Convert.ToInt64(this.SurveyorDDL.SelectedValue);
                _workOrderMov.DateCreate = _now;
                _workOrderMov.DateExecute = _now;
                _workOrderMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                _workOrderMov.SyncStatus = false;
                _workOrderMov.Remark = this.WORemarkTextBox.Text;
                _workOrderMov.DownloadDate = this._defaultDate;
                _workOrderMov.OnTheWayDate = this._defaultDate;
                _workOrderMov.OnTheSpotDate = this._defaultDate;
                _workOrderMov.RowStatus = 0;
                _workOrderMov.CreatedBy = Request.ServerVariables["LOGON_USER"];
                _workOrderMov.CreatedDate = _now;                

                TrOrderSPMovable _trOrderSPMovable = this._orderSPBL.GetSingleTrOrderMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));
                //TrWorkOrderMovable _trWorkOrderMovable = this._workOrderBL.GetSingleWorkOrderMovableByOrderSPMovableID(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                //if (_trWorkOrderMovable != null)
                //{
                //    if (_trOrderSPMovable.FgComplaint == true)
                //    {
                //        _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Complaint);
                //    }
                //    else if (_trOrderSPMovable.FgComplaint == false)
                //    {
                //        _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Correction);
                //    }
                //}
                //else
                //{
                //    _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Normal);
                //}

                if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Correction))
                {
                    _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Correction);
                }
                else if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Normal))
                {
                    if (_trOrderSPMovable.FgComplaint == true)
                    {
                        _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Complaint);
                    }
                    else
                    {
                        _workOrderMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Normal);
                    }
                }

                TrWorkOrderMovable _trWorkOrderMovable = this._workOrderBL.GetSingleWorkOrderMovableByOrderSPMovableID(_trOrderSPMovable.OrderSPMovableID);
                if (_trWorkOrderMovable != null)
                {
                    _workOrderMov.WORef = _trWorkOrderMovable.WorkOrderMovableID;
                }

                _result = this._workOrderBL.InsertWorkOrderMovable(_workOrderMov);

                if (_result)
                {
                    TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMovable.OrderID);
                    MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMovable.SurveyPointID);
                    TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                    DateTime _nowDate = DateTime.Now;

                    //ini jika WO Correction
                    if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Correction))
                    {                        
                        _trOrderSPLog.CreatedBy = _trOrderSPMovable.UserTakeOver;
                        _trOrderSPLog.CreatedDate = _nowDate;
                        _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                        _trOrderSPLog.OrderSPID = _trOrderSPMovable.OrderSPMovableID;
                        _trOrderSPLog.DateTime = _nowDate;
                        _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                        _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Correction);
                        _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                        _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPMovable.UserTakeOver).EmployeeID);
                        _trOrderSPLog.RowStatus = 0;

                        this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    }
                    
                    _trOrderSPLog.CreatedBy = _trOrderSPMovable.UserTakeOver;
                    _trOrderSPLog.CreatedDate = _nowDate;
                    _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                    _trOrderSPLog.OrderSPID = _trOrderSPMovable.OrderSPMovableID;
                    _trOrderSPLog.DateTime = _nowDate;
                    _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                    _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                    _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                    _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPMovable.UserTakeOver).EmployeeID);
                    _trOrderSPLog.RowStatus = 0;

                    this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    this.WarningLabel.Text = "You Succesfully Assign";
                    Response.Redirect(this._listWorkOrderPage + "?" + this._warning + "=" + this.WarningLabel.Text);

                }
                else
                {
                    this.ClearLabel();
                    this.AssignImageButton.Visible = true;
                    this.WarningLabel.Text = "You Failed Add Data";
                }
            }
            else
            {
                DateTime _now = DateTime.Now;
                TrWorkOrderNotMovable _workOrderNotMov = new TrWorkOrderNotMovable();
                _workOrderNotMov.WorkOrderCode = new AutoNumber().GetAutoNumberWorkOrder(SurveyPointType.NotMovable);
                _workOrderNotMov.OrderSPNotMovableID = Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID));
                _workOrderNotMov.SurveyorID = Convert.ToInt64(this.SurveyorDDL.SelectedValue);
                _workOrderNotMov.DateCreate = _now;
                _workOrderNotMov.DateExecute = _now;
                _workOrderNotMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                _workOrderNotMov.SyncStatus = false;
                _workOrderNotMov.Remark = this.WORemarkTextBox.Text;
                _workOrderNotMov.RowStatus = 0;
                _workOrderNotMov.CreatedBy = Request.ServerVariables["LOGON_USER"];
                _workOrderNotMov.CreatedDate = _now;

                TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSPBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));
                //TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(Convert.ToInt64(this._nvcExtractor.GetValue(this._orderSPID)));

                //if (_trWorkOrderNotMovable != null)
                //{
                //    if (_trOrderSPNotMovable.FgComplaint == true)
                //    {
                //        _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Complaint);
                //    }
                //    else if (_trOrderSPNotMovable.FgComplaint == false)
                //    {
                //        _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Correction);
                //    }
                //}
                //else
                //{
                //    _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Normal);
                //}

                if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Correction))
                {
                    _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Correction);
                }
                else if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Normal))
                {
                    if (_trOrderSPNotMovable.FgComplaint == true)
                    {
                        _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Complaint);
                    }
                    else
                    {
                        _workOrderNotMov.WOType = WOTypeMapper.GetWOType(WOTypeEnum.Normal);
                    }
                }                

                TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_trOrderSPNotMovable.OrderSPNotMovableID);
                if (_trWorkOrderNotMovable != null)
                {
                    _workOrderNotMov.WORef = _trWorkOrderNotMovable.WorkOrderNotMovableID;
                }

                _result = this._workOrderBL.InsertWorkOrderNotMovable(_workOrderNotMov);

                if (_result)
                {
                    TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMovable.OrderID);
                    MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMovable.SurveyPointID);

                    TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                    DateTime _nowDate = DateTime.Now;

                    //ini jika WO Correction
                    if (this._nvcExtractor.GetValue(this._workOrderType) == WOTypeMapper.GetWOTypeText(WOTypeEnum.Correction))
                    {
                        _trOrderSPLog.CreatedBy = _trOrderSPNotMovable.UserTakeOver;
                        _trOrderSPLog.CreatedDate = _nowDate;
                        _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                        _trOrderSPLog.OrderSPID = _trOrderSPNotMovable.OrderSPNotMovableID;
                        _trOrderSPLog.DateTime = _nowDate;
                        _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                        _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Correction);
                        _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                        _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPNotMovable.UserTakeOver).EmployeeID);
                        _trOrderSPLog.RowStatus = 0;

                        this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    }

                    _trOrderSPLog.CreatedBy = _trOrderSPNotMovable.UserTakeOver;
                    _trOrderSPLog.CreatedDate = _nowDate;
                    _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                    _trOrderSPLog.OrderSPID = _trOrderSPNotMovable.OrderSPNotMovableID;
                    _trOrderSPLog.DateTime = _nowDate;
                    _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                    _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                    _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                    _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPNotMovable.UserTakeOver).EmployeeID);
                    _trOrderSPLog.RowStatus = 0;

                    this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    this.WarningLabel.Text = "You Succesfully Assign";
                    Response.Redirect(this._listWorkOrderPage + "?" + this._warning + "=" + this.WarningLabel.Text);
                }
                else
                {
                    this.ClearLabel();
                    this.AssignImageButton.Visible = true;
                    this.WarningLabel.Text = "You Failed Add Data";
                }
            }
        }
    }
}
