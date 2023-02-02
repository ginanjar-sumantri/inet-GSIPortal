using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.Common.Enum;
using System.Transactions;
using System.Configuration;

namespace GSIWebsiteCore.SurveyPoint
{
    public partial class ListSurveyPoint : SurveyPointBase
    {
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private OrderBL _orderBL = new OrderBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private RegionBL _regionBL = new RegionBL();
        private UserManagementBL _userManagementBL = new UserManagementBL();
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

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;
                this.ViewState[this._currPageKey] = 0;
                this.GoImageButton.ImageUrl = this._imageURL + "btnGO2.jpg";

                this.StartDateLiteral.Text = "<input id='StartDateButton' type='button' onclick='displayCalendar(" + this.StartDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";
                this.EndDateLiteral.Text = "<input id='EndDateButton' type='button' onclick='displayCalendar(" + this.EndDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";

                this.SetAttribute();
                this.SetInitializeData();
                this.ShowRegionDDL();
                this.ShowUserDDL();
                this.CheckSession();

                //this.ShowData(0);

                this.ClearLabel();
            }
        }

        private void SetInitializeData()
        {
            DateTime _now = DateTime.Now;
            this.StartDateTextBox.Text = DateFormMapper.GetValue(_now.AddDays(-2));
            this.EndDateTextBox.Text = DateFormMapper.GetValue(_now);
        }

        private void CheckSession()
        {
            if (HttpContext.Current.Session[this._sesOrderCode] != null) this.OrderCodeTextBox.Text = HttpContext.Current.Session[this._sesOrderCode].ToString();
            if (HttpContext.Current.Session[this._sesOrderSPName] != null) this.OrderSpNameTextBox.Text = HttpContext.Current.Session[this._sesOrderSPName].ToString();
            if (HttpContext.Current.Session[this._sesSPStatus] != null) this.SPStatusDDL.SelectedValue = HttpContext.Current.Session[this._sesSPStatus].ToString();
            if (HttpContext.Current.Session[this._sesDateStart] != null) this.StartDateTextBox.Text = HttpContext.Current.Session[this._sesDateStart].ToString();
            if (HttpContext.Current.Session[this._sesDateEnd] != null) this.EndDateTextBox.Text = HttpContext.Current.Session[this._sesDateEnd].ToString();
            if (HttpContext.Current.Session[this._sesReligion] != null) this.RegionDDL.SelectedValue = HttpContext.Current.Session[this._sesReligion].ToString();
            if (HttpContext.Current.Session[this._sesCustName] != null) this.CustNameTextBox.Text = HttpContext.Current.Session[this._sesCustName].ToString();
        }

        private void SetSession()
        {
            HttpContext.Current.Session[this._sesOrderCode] = this.OrderCodeTextBox.Text;
            HttpContext.Current.Session[this._sesOrderSPName] = this.OrderSpNameTextBox.Text;
            HttpContext.Current.Session[this._sesSPStatus] = this.SPStatusDDL.SelectedValue;
            HttpContext.Current.Session[this._sesDateStart] = this.StartDateTextBox.Text;
            HttpContext.Current.Session[this._sesDateEnd] = this.EndDateTextBox.Text;
            HttpContext.Current.Session[this._sesReligion] = this.RegionDDL.SelectedValue;
            HttpContext.Current.Session[this._sesUserLoginName] = this.UserDDL.SelectedValue;
            HttpContext.Current.Session[this._sesCustName] = this.CustNameTextBox.Text;
        }

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
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

            this.ListRepeater.DataSource = this._surveyPointBL.GetListSurveyPointForAssign(this.CustNameTextBox.Text, this.UserDDL.SelectedValue, Convert.ToInt64(this.RegionDDL.SelectedValue), this.OrderCodeTextBox.Text, this.OrderSpNameTextBox.Text, _startTime, _endTime, Convert.ToByte(this.SPStatusDDL.SelectedValue), _maxrow, _prmCurrentPage, "", "");
            this.ListRepeater.DataBind();

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

        private void SetAttribute()
        {
            this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
            this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
        }

        protected void ShowRegionDDL()
        {
            this.RegionDDL.Items.Clear();
            this.RegionDDL.DataSource = this._regionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionDDL.DataValueField = "RegionID";
            this.RegionDDL.DataTextField = "RegionName";
            this.RegionDDL.DataBind();
            this.RegionDDL.Items.Insert(0, new ListItem("All", "99"));
        }

        protected void ShowUserDDL()
        {
            long _custID = Convert.ToInt64(Session[this._sesCustID]);

            //this.UserDDL.Items.Clear();
            //if ("bukanadmin" == "admin")
            //{
            //    this.UserDDL.DataSource = this._userManagementBL.GetMsCustomerUserByCustomerID(_custID);
            //}
            //else
            //{
            this.UserDDL.DataSource = null;
            this.UserDDL.Items.Insert(0, new ListItem(Request.ServerVariables["LOGON_USER"], Request.ServerVariables["LOGON_USER"]));
            //}

            this.UserDDL.DataValueField = "MembershipUserName";
            this.UserDDL.DataTextField = "MembershipUserName";
            this.UserDDL.DataBind();
            //this.UserDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
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
            OrderSurveyPoint _temp = (OrderSurveyPoint)e.Item.DataItem;

            String _OrderSPID = _temp.OrderSPID.ToString();

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
            if (_total < _timeSLA1)
            {
                _tableRow.Attributes.Remove("Style");
            }
            else if (_total > _timeSLA1 && _total < _timeSLA2)
            {
                _tableRow.Attributes.Add("Style", "background-color:#d3d128; color: black");
            }
            else if (_total > _timeSLA2)
            {
                _tableRow.Attributes.Add("Style", "background-color:#d23e3e; color: white");
            }

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.CommandName = "ViewOrder";
            _viewButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;

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
            //_cancelImageButton.Attributes.Add("OnClick", "return DropSurveyPoint(\"" + this.RemarkCancelHiddenField.ClientID + "\", \"" + this.RemarkCancelTextBox.ClientID + "\");");
            _cancelImageButton.CommandName = "Cancel";
            _cancelImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal))
                _cancelImageButton.Visible = true;
            else
                _cancelImageButton.Visible = false;

            ImageButton _apprCancelImageButton = (ImageButton)e.Item.FindControl("ApproveCancelImageButton");
            _apprCancelImageButton.ImageUrl = this._imageURL + "icon_appr_drop.png";
            _apprCancelImageButton.ToolTip = this._toolTipApproveCancel;
            //_apprCancelImageButton.Attributes.Add("OnClick", "return DropSurveyPoint();");
            _apprCancelImageButton.CommandName = "ApproveCancel";
            _apprCancelImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.CancelStatus == CancelStatusMapper.GetCancelStatus(CancelStatusEnum.WaitingForCancel))
                _apprCancelImageButton.Visible = true;
            else
                _apprCancelImageButton.Visible = false;

            Literal _orderCodeLiteral = (Literal)e.Item.FindControl("OrderCodeLiteral");
            _orderCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderCode);

            Literal _spNameLiteral = (Literal)e.Item.FindControl("SPNameLiteral");
            _spNameLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderSurveyPointName);

            Literal _sPTypeLiteral = (Literal)e.Item.FindControl("SPTypeLiteral");
            _sPTypeLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);

            Literal _custNameLiteral = (Literal)e.Item.FindControl("CustNameLiteral");
            _custNameLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerName);

            Literal _receiptOrderDateLiteral = (Literal)e.Item.FindControl("ReceiptOrderDateLiteral");
            _receiptOrderDateLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderDate);

            Literal _regionLiteral = (Literal)e.Item.FindControl("RegionLiteral");
            _regionLiteral.Text = HttpUtility.HtmlEncode(this._regionBL.GetMsRegionByRegionId((long)_temp.RegionID).RegionName);

            Literal _sPStatusLiteral = (Literal)e.Item.FindControl("SPStatusLiteral");
            _sPStatusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusInternalText(_temp.SPStatus));
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrder")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));
                Response.Redirect(this._viewSurveyPoint + "?" + this._template + "=" + _template.TemplateForm + "&" + this._SPid + "=" + _cd[1] + "&" + this._orderSPID + "=" + _cd[3]);
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

                            TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMovable.OrderID);
                            MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMovable.SurveyPointID);

                            //For Duration
                            TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();

                            DateTime _now = DateTime.Now;
                            _trOrderSPLog.CreatedBy = _trOrderSPMovable.UserTakeOver;
                            _trOrderSPLog.CreatedDate = _now;
                            _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                            _trOrderSPLog.OrderSPID = _trOrderSPMovable.OrderSPMovableID;
                            _trOrderSPLog.DateTime = _now;
                            _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                            _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment);
                            _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                            _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPMovable.UserTakeOver).EmployeeID);
                            _trOrderSPLog.RowStatus = 0;

                            this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

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

                            TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMovable.OrderID);
                            MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMovable.SurveyPointID);

                            //For Duration
                            TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();

                            DateTime _now = DateTime.Now;
                            _trOrderSPLog.CreatedBy = _trOrderSPNotMovable.UserTakeOver;
                            _trOrderSPLog.CreatedDate = _now;
                            _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                            _trOrderSPLog.OrderSPID = _trOrderSPNotMovable.OrderSPNotMovableID;
                            _trOrderSPLog.DateTime = _now;
                            _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                            _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment);
                            _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                            _trOrderSPLog.EmployeeID = (this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPNotMovable.UserTakeOver).EmployeeID);
                            _trOrderSPLog.RowStatus = 0;

                            this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

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
            }
            else if (e.CommandName == "ApproveCancel")
            {
                this.ReasonApproveCancel.Visible = true;
                this.ApproveCancelHiddenField.Value = e.CommandArgument.ToString();
            }
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

        protected void GoImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.SetSession();
            this.ShowData(0);
            this.ClearLabel();
        }

        protected void YesButton_OnClick(object sender, EventArgs e)
        {
            String _ex = this.CancelRowHiddenField.Value;
            this._cd = _ex.Split('-');
            MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));

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

        protected void NoButton_OnClick(object sender, EventArgs e)
        {
            this.ReasonPanel.Visible = false;
        }

        protected void YesButton2_OnClick(object sender, EventArgs e)
        {
            //String _ex = (e.CommandArgument.ToString());
            String _ex = this.ApproveCancelHiddenField.Value;
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
                            this.ReasonApproveCancel.Visible = false;
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
                            this.ReasonApproveCancel.Visible = false;
                        }

                        this.ShowData(0);
                    }

                    _scope.Complete();
                }
                catch (Exception Ex)
                {
                    this.WarningLabel.Text = "Cancel Survey Point Failed, " + Ex.Message;
                }
            }
        }

        protected void NoButton2_OnClick(object sender, EventArgs e)
        {
            this.ReasonApproveCancel.Visible = false;
        }
    }
}

