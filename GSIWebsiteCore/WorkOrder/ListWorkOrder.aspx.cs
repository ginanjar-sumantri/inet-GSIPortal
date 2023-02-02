using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Transactions;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Common.Enum;
using System.Configuration;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class WorkOrderList : WorkOrderBase
    {
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private RegionBL _msRegionBL = new RegionBL();
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();
        private EmployeeBL _employeeBL = new EmployeeBL();

        private string _currPageKey = "CurrentPage";
        private int?[] _navMark = { null, null, null, null };
        private bool _flag = true;
        private bool _nextFlag = false;
        private bool _lastFlag = false;
        private int _page;
        private int _maxrow = 20;
        private int _maxlength = 5;
        private String[] _cd;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;
                this.ViewState[this._currPageKey] = 0;
                this.GoImageButton.ImageUrl = this._imageURL + "btnGO2.jpg";
                //this.AddImageButton.ImageUrl = this._imageURL + "btnAdd2.png";

                this.StartDateLiteral.Text = "<input id='StartDateButton' type='button' onclick='displayCalendar(" + this.StartDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";
                this.EndDateLiteral.Text = "<input id='EndDateButton' type='button' onclick='displayCalendar(" + this.EndDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";

                this.SetAttribute();
                this.SetInitializeData();
                this.CheckSession();
                this.ShowRegionDDL();
                this.ClearLabel();
                this.WarningLabel.Text = this._nvcExtractor.GetValue(this._warning);
                //this.ShowData(0);
            }
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void SetInitializeData()
        {
            DateTime _now = DateTime.Now;
            this.StartDateTextBox.Text = DateFormMapper.GetValue(_now.AddDays(-2));
            this.EndDateTextBox.Text = DateFormMapper.GetValue(_now);
        }

        private void SetAttribute()
        {
            this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
            this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
        }

        private void CheckSession()
        {
            if (HttpContext.Current.Session[this._sesWOCode] != null) this.WOCodeTextBox.Text = HttpContext.Current.Session[this._sesWOCode].ToString();
            if (HttpContext.Current.Session[this._sesWOStatus] != null) this.WOStatusDDL.SelectedValue = HttpContext.Current.Session[this._sesWOStatus].ToString();
            if (HttpContext.Current.Session[this._sesWODateStart] != null) this.StartDateTextBox.Text = HttpContext.Current.Session[this._sesWODateStart].ToString();
            if (HttpContext.Current.Session[this._sesWODateEnd] != null) this.EndDateTextBox.Text = HttpContext.Current.Session[this._sesWODateEnd].ToString();
            if (HttpContext.Current.Session[this._sesWOSurveryorName] != null) this.EmployeeNameTextBox.Text = HttpContext.Current.Session[this._sesWOSurveryorName].ToString();
            if (HttpContext.Current.Session[this._sesCustName] != null) this.CustNameTextBox.Text = HttpContext.Current.Session[this._sesCustName].ToString();
        }

        private void SetSession()
        {
            HttpContext.Current.Session[this._sesWOCode] = this.WOCodeTextBox.Text;
            HttpContext.Current.Session[this._sesWOStatus] = this.WOStatusDDL.SelectedValue;
            HttpContext.Current.Session[this._sesWODateStart] = this.StartDateTextBox.Text;
            HttpContext.Current.Session[this._sesWODateEnd] = this.EndDateTextBox.Text;
            HttpContext.Current.Session[this._sesWOSurveryorName] = this.EmployeeNameTextBox.Text;
            HttpContext.Current.Session[this._sesCustName] = this.CustNameTextBox.Text;

        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._msRegionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
            this.RegionDDL.Items.Insert(0, new ListItem("All", "999999"));
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            this._page = _prmCurrentPage;

            DateTime _startTime = DateFormMapper.GetValue(this.StartDateTextBox.Text);
            DateTime _endTime = DateFormMapper.GetValue(this.EndDateTextBox.Text);
            _endTime = _endTime.AddHours(23);
            _endTime = _endTime.AddMinutes(59);
            _endTime = _endTime.AddSeconds(59);

            this.WorkOrderListRepeater.DataSource = this._workOrderBL.GetListWorkOrder(this.WOCodeTextBox.Text, this.WOStatusDDL.SelectedValue, this.CustNameTextBox.Text, _startTime, _endTime, this.EmployeeNameTextBox.Text, this.SPNameTextBox.Text, Convert.ToInt64(this.RegionDDL.SelectedValue), _maxrow, _prmCurrentPage, "", "", Convert.ToInt16(this.WOTypeDropDownList.SelectedValue));
            this.WorkOrderListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);
        }

        private void ShowPage(Int32 _prmCurrentPage)
        {
            Int32[] _pageNumber;
            byte _addElement = 0;
            Int32 _pageNumberElement = 0;

            int i = 0;
            decimal min = 0, max = 0;
            double q = this.RowCount();

            if (_prmCurrentPage - _maxlength > 0)
            {
                min = _prmCurrentPage - _maxlength;
            }
            else
            {
                min = 0;
            }

            if (_prmCurrentPage + _maxlength < q)
            {
                max = _prmCurrentPage + _maxlength + 1;
            }
            else
            {
                max = Convert.ToDecimal(q);
            }

            if (_prmCurrentPage > 0)
                _addElement += 2;

            if (_prmCurrentPage < q - 1)
                _addElement += 2;

            i = Convert.ToInt32(min);
            _pageNumber = new Int32[Convert.ToInt32(max - min) + _addElement];
            if (_pageNumber.Length != 0)
            {
                //NB: Prev Or First
                if (_prmCurrentPage > 0)
                {
                    this._navMark[0] = 0;

                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[0]);
                    _pageNumberElement++;

                    this._navMark[1] = Convert.ToInt32(Math.Abs(_prmCurrentPage - 1));

                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[1]);
                    _pageNumberElement++;
                }

                for (; i < max; i++)
                {
                    _pageNumber[_pageNumberElement] = i;
                    _pageNumberElement++;
                }

                if (_prmCurrentPage < q - 1)
                {
                    this._navMark[2] = Convert.ToInt32(_prmCurrentPage + 1);

                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[2]);
                    _pageNumberElement++;

                    if (_pageNumber[_pageNumberElement - 2] > _pageNumber[_pageNumberElement - 1])
                    {
                        this._flag = true;
                    }

                    this._navMark[3] = Convert.ToInt32(q - 1);

                    _pageNumber[_pageNumberElement] = Convert.ToInt32(this._navMark[3]);
                    _pageNumberElement++;
                }

                int?[] _navMarkBackup = new int?[4];
                this._navMark.CopyTo(_navMarkBackup, 0);
                this.DataPagerTopRepeater.DataSource = from _query in _pageNumber
                                                       select _query;
                this.DataPagerTopRepeater.DataBind();

                _flag = true;
                _nextFlag = false;
                _lastFlag = false;
                _navMark = _navMarkBackup;

                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber
                                                          select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
            else
            {
                this.DataPagerTopRepeater.DataSource = from _query in _pageNumber
                                                       select _query;
                this.DataPagerTopRepeater.DataBind();

                this.DataPagerBottomRepeater.DataSource = from _query in _pageNumber
                                                          select _query;
                this.DataPagerBottomRepeater.DataBind();
            }
        }

        private double RowCount()
        {
            double _result = 0;

            _result = RequestVariable.RowCount;
            _result = System.Math.Ceiling(_result / (double)_maxrow);

            return _result;
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrWorkOrder _temp = (TrWorkOrder)e.Item.DataItem;
            Int64 _code = _temp.WorkOrderID;

            TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_temp.OrderID);
            MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _temp.SurveyPointID);
            int _totalDuration = this._spLogBL.GetDurationForSLA(_temp.OrderSPID, Convert.ToInt64(_msSurveyPoint.TemplateForm));

            TrOrderSPLog _trOrderSPLogQuery = this._spLogBL.GetSingleTrOrderSPLogByOrderSPIDAndSPType(_temp.OrderSPID, Convert.ToInt64(_msSurveyPoint.TemplateForm));

            DateTime _time1 = _trOrderSPLogQuery.DateTime;
            DateTime _time2 = DateTime.Now;

            Int32 _duration = Convert.ToInt32(_time2.Subtract(_time1).TotalMinutes);
            Int32 _total = _duration + _totalDuration;
            Int32 _timeSLA1 = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSLA1"].ToString());
            Int32 _timeSLA2 = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSLA2"].ToString());


            HtmlTableRow _tableRow = (HtmlTableRow)e.Item.FindControl("RepeaterItemTemplate");
            if (_total < _timeSLA1 || _temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.Published))
            {
                _tableRow.Attributes.Remove("Style");
            }
            else if (_total > _timeSLA1 && _total < _timeSLA2)
            {
                if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.Published))
                {
                    _tableRow.Attributes.Remove("Style");
                }
                else
                {
                    _tableRow.Attributes.Add("Style", "background-color:#d3d128; color: white");
                }
            }
            else if (_total > _timeSLA2)
            {
                if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.Published))
                {
                    _tableRow.Attributes.Remove("Style");
                }
                else
                {
                    _tableRow.Attributes.Add("Style", "background-color:#d23e3e; color: white");
                }
            }

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            //_viewButton.PostBackUrl = this._viewWorkOrderPage + "?" + this._codeKey + "=" + _code + "&" + this._workOrderCode + "=" + _temp.WorkOrderCode;
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.CommandName = "ViewWorkOrder";
            _viewButton.CommandArgument = _temp.WorkOrderCode + "-" + _temp.WorkOrderID;

            ImageButton _cancelButton = (ImageButton)e.Item.FindControl("CancelImageButton");
            _cancelButton.ImageUrl = this._imageURL + "icon_drop.png";

            ImageButton _takeOverImageButton = (ImageButton)e.Item.FindControl("TakeOverImageButton");
            _takeOverImageButton.ImageUrl = this._imageURL + "Icon_TakeOver.png";
            _takeOverImageButton.ToolTip = this._toolTipTakeOver;
            _takeOverImageButton.CommandName = "TakeOver";
            _takeOverImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem))
                _takeOverImageButton.Visible = true;
            else
                _takeOverImageButton.Visible = false;

            ImageButton _assignImageButton = (ImageButton)e.Item.FindControl("AssignImageButton");
            _assignImageButton.ImageUrl = this._imageURL + "icon_assign.png";
            _assignImageButton.ToolTip = this._toolTipAssign;
            _assignImageButton.CommandName = "Assign";
            _assignImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment))
                _assignImageButton.Visible = true;
            else
                _assignImageButton.Visible = false;

            ImageButton _publishImageButton = (ImageButton)e.Item.FindControl("PublishImageButton");
            _publishImageButton.ImageUrl = this._imageURL + "Icon_Publish.png";
            _publishImageButton.ToolTip = this._toolTipPublish;
            _publishImageButton.CommandName = "Publish";
            _publishImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
                _publishImageButton.Visible = true;
            else
                _publishImageButton.Visible = false;

            ImageButton _cancelImageButton = (ImageButton)e.Item.FindControl("CancelImageButton");
            _cancelImageButton.ImageUrl = this._imageURL + "icon_drop.png";
            _cancelImageButton.ToolTip = this._toolTipCancel;
            _cancelImageButton.Attributes.Add("OnClick", "return DropWorkOrder();");
            _cancelImageButton.CommandName = "Cancel";
            _cancelImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID + "-" + _temp.WorkOrderID + "-" + _temp.SurveyorID;

            //if (_temp.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal) && _temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload))
            //    _cancelImageButton.Visible = true;
            //else
                _cancelImageButton.Visible = false;

            ImageButton _apprCancelImageButton = (ImageButton)e.Item.FindControl("ApproveCancelImageButton");
            _apprCancelImageButton.ImageUrl = this._imageURL + "icon_appr_drop.png";
            _apprCancelImageButton.ToolTip = this._toolTipApproveCancel;
            _apprCancelImageButton.Attributes.Add("OnClick", "return DropWorkOrder();");
            _apprCancelImageButton.CommandName = "ApproveCancel";
            _apprCancelImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID + "-" + _temp.WorkOrderCode + "-" + _temp.WorkOrderID;

            //MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint(_temp.OrderTypeID, _temp.SurveyPointID);
            //if (_template.TemplateForm == 0)
            //{
            //    TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(_temp.SurveyPointID);
            //    if (_trOrderSPMovable.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel))
            //    {
            //        _apprCancelImageButton.Visible = true;
            //    }
            //    else
            //    {
            //        _apprCancelImageButton.Visible = false;
            //    }
            //}
            //else if (_template.TemplateForm == 1)
            //{
            //    TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(_temp.SurveyPointID);
            //    if (_trOrderSPNotMovable.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel))
            //    {
            //        _apprCancelImageButton.Visible = true;
            //    }
            //    else
            //    {
            //        _apprCancelImageButton.Visible = false;
            //    }
            //}

            //if (_temp.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel))
            //    _apprCancelImageButton.Visible = true;
            //else
                _apprCancelImageButton.Visible = false;

            Literal _woLiteral = (Literal)e.Item.FindControl("WOCodeLiteral");
            _woLiteral.Text = HttpUtility.HtmlEncode(_temp.WorkOrderCode);
            //Literal _dateCreateLiteral = (Literal)e.Item.FindControl("DateCreateLiteral");
            //_dateCreateLiteral.Text = HttpUtility.HtmlEncode(_temp.DateCreate);
            Literal _dateExecLiteral = (Literal)e.Item.FindControl("DateExecuteLiteral");
            //_dateExecLiteral.Text = "<Span title='Tes'>" + HttpUtility.HtmlEncode(_temp.OnTheSpotDate) + "</span>";
            _dateExecLiteral.Text = "<Span title='On The Way Date : " + ((Convert.ToDateTime(_temp.OnTheWayDate) == this._defaultDate) ? "-" : _temp.OnTheWayDate.ToString()) + "&#10" +
                " | On The Spot Date : " + ((Convert.ToDateTime(_temp.OnTheSpotDate) == this._defaultDate) ? "-" : _temp.OnTheSpotDate.ToString()) + "&#10" +
                " | Survey result Receive Date : " + ((Convert.ToDateTime(_temp.SurveyResultReceivedDate) == this._defaultDate) ? "-" : _temp.SurveyResultReceivedDate.ToString()) +
                "'>" + HttpUtility.HtmlEncode(_temp.DateExecute) + "</Span>";
            Literal _custNameLiteral = (Literal)e.Item.FindControl("CustomerNameLiteral");
            _custNameLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerName);
            Literal _spNameLiteral = (Literal)e.Item.FindControl("SurveyPointNameLiteral");
            _spNameLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);
            Literal _statusLiteral = (Literal)e.Item.FindControl("StatusLiteral");
            _statusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusInternalText(_temp.WorkOrderStatusID));
            Literal _custEmployeeNameLiteral = (Literal)e.Item.FindControl("EmployeeNameLiteral");
            _custEmployeeNameLiteral.Text = HttpUtility.HtmlEncode(_temp.EmployeeName);
            Literal _wOTypeLiteral = (Literal)e.Item.FindControl("WOTypeLiteral");
            _wOTypeLiteral.Text = HttpUtility.HtmlEncode(WOTypeMapper.GetWOTypeText(Convert.ToByte(_temp.WOType)));
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewWorkOrder")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                this._orderType = this._cd[0].Split('/');
                if (this._orderType[1] == SPTypeMapper.GetSPType(SurveyPointType.Movable))
                {
                    Response.Redirect(this._viewWorkOrderPersonalPage + "?" + this._codeKey + " = " + this._cd[1]);
                }
                if (this._orderType[1] == SPTypeMapper.GetSPType(SurveyPointType.NotMovable))
                {
                    Response.Redirect(this._viewWorkOrderOfficePage + "?" + this._codeKey + " = " + this._cd[1]);
                }
            }
            else if (e.CommandName == "TakeOver")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));

                if (_template.TemplateForm == 0)
                {
                    TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));

                    _trOrderSPMovable.UserTakeOver = Request.ServerVariables["LOGON_USER"].ToString();
                    _trOrderSPMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment);

                    if (_trOrderSPMovable.UserTakeOver != null || _trOrderSPMovable.UserTakeOver != "")
                    {

                        Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);

                        if (_result == true)
                        {
                            this._workOrderBL.UpdateStatusCustomerPortal(SurveyPointType.Movable, _trOrderSPMovable.OrderSPMovableID, GSIInternalStatus.WaitingForAssigment, _trOrderSPMovable.UserTakeOver);

                            this.WarningLabel.Text = "You Success Take Over";
                        }

                        this.ShowData(0);
                    }
                }
                else if (_template.TemplateForm == 1)
                {
                    TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));

                    _trOrderSPNotMovable.UserTakeOver = Request.ServerVariables["LOGON_USER"].ToString();
                    _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment);

                    if (_trOrderSPNotMovable.UserTakeOver != null || _trOrderSPNotMovable.UserTakeOver != "")
                    {
                        Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                        if (_result == true)
                        {
                            this._workOrderBL.UpdateStatusCustomerPortal(SurveyPointType.NotMovable, _trOrderSPNotMovable.OrderSPNotMovableID, GSIInternalStatus.WaitingForAssigment, _trOrderSPNotMovable.UserTakeOver);

                            this.WarningLabel.Text = "You Success Take Over";
                        }

                        this.ShowData(0);
                    }
                }
            }
            else if (e.CommandName == "Assign")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));
                Response.Redirect("~/WorkOrder/AddWorkOrderAssign.aspx" + "?" + this._orderSPID + "=" + _cd[3] + "&" + "SPType" + "=" + _template.TemplateForm + "&" + this._SPid + "=" + this._cd[1] + "&" + this._workOrderType + "=" + WOTypeMapper.GetWOTypeText(WOTypeEnum.Normal));
            }
            else if (e.CommandName == "Publish")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');

                string _msg = "";
                bool _result = this._workOrderBL.PublishedToCustomerPortal(this._cd, ref _msg);

                if (_result)
                {
                    this.WarningLabel.Text = _msg;
                    this.ShowData(0);
                }
                else
                {
                    this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                }
            }
            else if (e.CommandName == "Cancel")
            {
                this.ReasonPanel.Visible = true;
                this.CancelRowHiddenField.Value = e.CommandArgument.ToString();
                //string _ex = (e.CommandArgument.ToString());
                //this._cd = _ex.Split('-');
                //MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));

                //using (TransactionScope _scope = new TransactionScope())
                //{
                //    try
                //    {
                //        if (_template.TemplateForm == 0)
                //        {
                //            TrOrderSPMovable _trorderspmovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));
                //            _trorderspmovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel);

                //            Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trorderspmovable);

                //            if (_result == true)
                //            {
                //                this.WarningLabel.Text = "request cancel success";
                //            }

                //            this.ShowData(0);
                //        }
                //        else if (_template.TemplateForm == 1)
                //        {
                //            TrOrderSPNotMovable _trorderspnotmovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));
                //            _trorderspnotmovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel);

                //            Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trorderspnotmovable);

                //            if (_result == true)
                //            {
                //                this.WarningLabel.Text = "request cancel success";
                //            }

                //            this.ShowData(0);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        this.WarningLabel.Text = "request cancel failed, " + ex.Message;
                //    }
                //}
            }
            else if (e.CommandName == "ApproveCancel")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));

                using (TransactionScope _scope = new TransactionScope())
                {
                    try
                    {
                        if (_template.TemplateForm == 0)
                        {
                            TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));
                            _trOrderSPMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Cancelled);
                            _trOrderSPMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                            _trOrderSPMovable.ModifiedBy = Request.ServerVariables["LOGON_USER"].ToString();
                            _trOrderSPMovable.ModifiedDate = DateTime.Now;

                            Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);
                            if (_result)
                            {
                                int _result2 = this._orderSurveyPointBL.DeleteTrOrderSPMovable(_trOrderSPMovable);

                                if (_result2 == -1)
                                {
                                    MobileSystemWorkOrderServices.WorkOrderClient _client = new MobileSystemWorkOrderServices.WorkOrderClient();
                                    _client.CancelOrder(this._cd[4], Convert.ToInt64(this._cd[5]));

                                    _result = true;
                                }
                                else
                                {
                                    _result = false;
                                }
                            }

                            if (_result == true)
                            {
                                this._workOrderBL.UpdateStatusCustomerPortal(SurveyPointType.Movable, _trOrderSPMovable.OrderSPMovableID, GSIInternalStatus.Cancelled, _trOrderSPMovable.UserTakeOver);

                                TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMovable.OrderID);
                                MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMovable.SurveyPointID);

                                //For Duration
                                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();

                                DateTime _now = DateTime.Now;
                                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                                _trOrderSPLog.OrderSPID = _trOrderSPMovable.OrderSPMovableID;
                                _trOrderSPLog.DateTime = _now;
                                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                                _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Cancelled);
                                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                                _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(Request.ServerVariables["LOGON_USER"].ToString()).EmployeeID);
                                _trOrderSPLog.RowStatus = 0;
                                _trOrderSPLog.CreatedBy = Request.ServerVariables["LOGON_USER"].ToString();
                                _trOrderSPLog.CreatedDate = _now;

                                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

                                this.WarningLabel.Text = "Cancel Survey Point Success";
                            }

                            this.ShowData(0);
                        }
                        else if (_template.TemplateForm == 1)
                        {
                            TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));
                            _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Cancelled);
                            _trOrderSPNotMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                            _trOrderSPNotMovable.ModifiedBy = Request.ServerVariables["LOGON_USER"].ToString();
                            _trOrderSPNotMovable.ModifiedDate = DateTime.Now;

                            Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                            if (_result)
                            {
                                int _result2 = this._orderSurveyPointBL.DeleteTrOrderSPNotMovable(_trOrderSPNotMovable);

                                if (_result2 == -1)
                                {
                                    MobileSystemWorkOrderServices.WorkOrderClient _client = new MobileSystemWorkOrderServices.WorkOrderClient();
                                    _client.CancelOrder(this._cd[4], Convert.ToInt64(this._cd[5]));

                                    _result = true;
                                }
                                else
                                {
                                    _result = false;
                                }
                            }

                            if (_result == true)
                            {
                                this._workOrderBL.UpdateStatusCustomerPortal(SurveyPointType.NotMovable, _trOrderSPNotMovable.OrderSPNotMovableID, GSIInternalStatus.Cancelled, _trOrderSPNotMovable.UserTakeOver);

                                TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMovable.OrderID);
                                MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMovable.SurveyPointID);

                                //For Duration
                                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();

                                DateTime _now = DateTime.Now;
                                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                                _trOrderSPLog.OrderSPID = _trOrderSPNotMovable.OrderSPNotMovableID;
                                _trOrderSPLog.DateTime = _now;
                                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                                _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Cancelled);
                                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                                _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(Request.ServerVariables["LOGON_USER"].ToString()).EmployeeID);
                                _trOrderSPLog.RowStatus = 0;
                                _trOrderSPLog.CreatedBy = Request.ServerVariables["LOGON_USER"].ToString();
                                _trOrderSPLog.CreatedDate = _now;

                                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

                                this.WarningLabel.Text = "Cancel Survey Point Success";
                            }

                            this.ShowData(0);
                        }

                        _scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        String _err = ex.Message;
                    }
                }
            }
        }

        protected void GoImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.SetSession();
            this.ReasonPanel.Visible = false;
            this.ShowData(0);
            this.ClearLabel();
        }

        protected void DataPagerTopRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                int _pageNumber = (int)e.Item.DataItem;

                NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

                if (Convert.ToInt32(this.ViewState[this._currPageKey]) == _pageNumber)
                {
                    TextBox _pageNumberTextbox = (TextBox)e.Item.FindControl("PageNumberTextBox");

                    _pageNumberTextbox.Text = (_pageNumber + 1).ToString();
                    _pageNumberTextbox.MaxLength = 9;
                    _pageNumberTextbox.Visible = true;

                    _pageNumberTextbox.Attributes.Add("style", "text-align: center;");
                    _pageNumberTextbox.Attributes.Add("OnKeyDown", "return NumericWithEnter();");
                }
                else
                {
                    LinkButton _pageNumberLinkButton = (LinkButton)e.Item.FindControl("PageNumberLinkButton");
                    _pageNumberLinkButton.CommandName = "DataPager";
                    _pageNumberLinkButton.CommandArgument = _pageNumber.ToString();

                    if (_pageNumber == this._navMark[0])
                    {
                        _pageNumberLinkButton.Text = "First";
                        this._navMark[0] = null;
                    }
                    else if (_pageNumber == this._navMark[1])
                    {
                        _pageNumberLinkButton.Text = "Prev";
                        this._navMark[1] = null;
                    }
                    else if (_pageNumber == this._navMark[2] && this._flag == false)
                    {
                        _pageNumberLinkButton.Text = "Next";
                        this._navMark[2] = null;
                        this._nextFlag = true;
                        this._flag = true;
                    }
                    else if (_pageNumber == this._navMark[3] && this._flag == true && this._nextFlag == true)
                    {
                        _pageNumberLinkButton.Text = "Last";
                        this._navMark[3] = null;
                        this._lastFlag = true;
                    }
                    else
                    {
                        if (this._lastFlag == false)
                        {
                            _pageNumberLinkButton.Text = (_pageNumber + 1).ToString();
                        }

                        if (_pageNumber == this._navMark[2] && this._flag == true)
                            this._flag = false;
                    }
                }
            }
        }

        protected void DataPagerTopRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DataPager")
            {
                this.ViewState[this._currPageKey] = Convert.ToInt32(e.CommandArgument);

                this.ShowData(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void DataPagerButton_Click(object sender, EventArgs e)
        {
            Int32 _reqPage = 0;

            foreach (Control _item in this.DataPagerTopRepeater.Controls)
            {
                if (((TextBox)_item.Controls[3]).Text != "")
                {
                    _reqPage = Convert.ToInt32(((TextBox)_item.Controls[3]).Text) - 1;

                    if (_reqPage >= this.RowCount())
                    {
                        ((TextBox)_item.Controls[3]).Text = this.RowCount().ToString();
                        _reqPage = Convert.ToInt32(this.RowCount()) - 1;
                        break;
                    }
                    else if (_reqPage < 0)
                    {
                        ((TextBox)_item.Controls[3]).Text = "1";
                        _reqPage = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            this.ViewState[this._currPageKey] = _reqPage;
            this.ShowData(_reqPage);
        }

        protected void AddImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._addWorkOrderPage);
        }

        protected void YesButton_OnClick(object sender, EventArgs e)
        {
            String _ex = this.CancelRowHiddenField.Value;
            this._cd = _ex.Split('-');
            MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));


            try
            {
                if (_template.TemplateForm == 0)
                {
                    TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));
                    _trOrderSPMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel);
                    _trOrderSPMovable.RemarkCancel = this.ReasonTextBox.Text;

                    Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);

                    if (_result == true)
                    {
                        this.WarningLabel.Text = "Request Cancel Success";
                        this.ReasonPanel.Visible = false;
                    }

                    this.ShowData(0);
                }
                else if (_template.TemplateForm == 1)
                {
                    TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));
                    _trOrderSPNotMovable.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel);
                    _trOrderSPNotMovable.RemarkCancel = this.ReasonTextBox.Text;

                    Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                    if (_result == true)
                    {
                        this.WarningLabel.Text = "Request Cancel Success";
                        this.ReasonPanel.Visible = false;
                    }

                    this.ShowData(0);
                }
            }
            catch (Exception Ex)
            {
                this.WarningLabel.Text = "Request Cancel Failed, " + Ex.Message;
            }
        }

        protected void NoButton_OnClick(object sender, EventArgs e)
        {
            this.ReasonPanel.Visible = false;
        }
    }
}
