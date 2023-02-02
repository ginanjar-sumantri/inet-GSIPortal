using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Common.Enum;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class AddWorkOrder : WorkOrderBase
    {
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private RegionBL _regionBL = new RegionBL();
        private UserManagementBL _userManagementBL = new UserManagementBL();
        private OrderBL _orderBL = new OrderBL();


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
                this.PageTitleLiteral.Text = this._pageAddWorkOrderTitleLiteral;
                this.ViewState[this._currPageKey] = 0;
                this.GoImageButton.ImageUrl = this._imageURL + "btnGO2.jpg";

                this.StartDateLiteral.Text = "<input id='StartDateButton' type='button' onclick='displayCalendar(" + this.StartDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";
                this.EndDateLiteral.Text = "<input id='EndDateButton' type='button' onclick='displayCalendar(" + this.EndDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";

                this.SetAttribute();
                this.SetInitializeData();
                this.ShowRegionDDL();
                this.ShowUserDDL();
                this.ShowData(0);
            }
        }

        private void SetInitializeData()
        {
            DateTime _now = DateTime.Now;
            this.StartDateTextBox.Text = DateFormMapper.GetValue(_now.AddMonths(-1));
            this.EndDateTextBox.Text = DateFormMapper.GetValue(_now);
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

            this.UserDDL.Items.Clear();
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
            //this.RegionDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
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

            this.AddWorkOrderRepeater.DataSource = this._surveyPointBL.GetListSurveyPointForAssign(this.CustNameTextBox.Text,this.UserDDL.SelectedValue, Convert.ToInt64(this.RegionDDL.SelectedValue), this.OrderCodeTextBox.Text, this.OrderSPNameTextBox.Text, _startTime, _endTime, Convert.ToByte(this.SPStatusDDL.SelectedValue),_maxrow, _prmCurrentPage, "", "");
            this.AddWorkOrderRepeater.DataBind();

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
            OrderSurveyPoint _temp = (OrderSurveyPoint)e.Item.DataItem;
            Int64 _code = _temp.OrderSPID;

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            //_viewButton.PostBackUrl = this._viewWorkOrderPage + "?" + this._codeKey + "=" + _code;
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.CommandName = "View";
            _viewButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;



            ImageButton _takeOverImageButton = (ImageButton)e.Item.FindControl("TakeOverImageButton");
            _takeOverImageButton.ImageUrl = this._imageURL + "Icon_TakeOver.png";
            _takeOverImageButton.ToolTip = this._toolTipTakeOver;
            _takeOverImageButton.CommandName = "TakeOver";
            _takeOverImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem))
            {
                _takeOverImageButton.Visible = true;
            }
            else
            {
                _takeOverImageButton.Visible = false;
            }

            ImageButton _assignButton = (ImageButton)e.Item.FindControl("AssignImageButton");
            _assignButton.ImageUrl = this._imageURL + "icon_assign.png";
            _assignButton.ToolTip = this._toolTipAssign;
            _assignButton.PostBackUrl = this._assignWorkOrderPage + "?" + this._orderSPID + "=" + _code.ToString() + "&" + this._spType + "=" + _temp.TemplateForm.ToString();
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForAssigment))
            {
                _assignButton.Visible = true;
            }
            else
            {
                _assignButton.Visible = false;
            }

            ImageButton _publishImageButton = (ImageButton)e.Item.FindControl("PublishImageButton");
            _publishImageButton.ImageUrl = this._imageURL + "Icon_Publish.png";
            _publishImageButton.ToolTip = this._toolTipPublish;
            _publishImageButton.CommandName = "Publish";
            _publishImageButton.CommandArgument = _temp.OrderTypeID + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            if (_temp.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
            {
                _publishImageButton.Visible = true;
            }
            else
            {
                _publishImageButton.Visible = false;
            }

            Literal _orderLiteral = (Literal)e.Item.FindControl("OrderCodeLiteral");
            _orderLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderCode);
            Literal _dateLiteral = (Literal)e.Item.FindControl("OrderDateLiteral");
            _dateLiteral.Text = DateFormMapper.GetValue(_temp.OrderDate);
            Literal _custNameLiteral = (Literal)e.Item.FindControl("CustNameLiteral");
            _custNameLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerName);
            Literal _orderSPNameLiteral = (Literal)e.Item.FindControl("OrderSPNameLiteral");
            _orderSPNameLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderSurveyPointName);
            Literal _regionLiteral = (Literal)e.Item.FindControl("RegionLiteral");
            _regionLiteral.Text = HttpUtility.HtmlEncode(_temp.RegionName);
            Literal _statusLiteral = (Literal)e.Item.FindControl("StatusLiteral");
            _statusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusInternalText(_temp.SPStatus));
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));
                Response.Redirect(this._viewWorkOrderPageSurveyPoint + "?" + this._template + "=" + _template.TemplateForm + "&" + this._SPid + "=" + _cd[1] + "&" + this._orderSPID + "=" + _cd[3]);
            }

            if (e.CommandName == "TakeOver")
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

                if (_template.TemplateForm == 1)
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

            if (e.CommandName == "Publish")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._cd[0])), Convert.ToInt64(this._cd[1]));
                if (_template.TemplateForm == 1)
                {
                    TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));

                    if (_trOrderSPNotMovable.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
                    {

                        _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
                        Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                        if (_result == true)
                        {
                            Boolean _cekTrOrder = this._orderBL.IsOrderSurveyPointAllComplete(Convert.ToInt64(_cd[2]));
                            if (_cekTrOrder == true)
                            {
                                TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this._cd[2]));
                                _trOrder.OrderStatus = OrderVersionMapper.GetOrderVersion(OrderVersion.Final);

                                Boolean _updateTrOrderFinal = this._orderBL.UpdateOrder(_trOrder);
                            }
                            this.WarningLabel.Text = "You Success Publish";
                            this.ShowData(0);
                        }
                    }
                }

                if (_template.TemplateForm == 0)
                {
                    TrOrderSPMovable _trOrderSPMovable = this._orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));

                    if (_trOrderSPMovable.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
                    {
                        _trOrderSPMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
                        Boolean _result = this._orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);

                        if (_result == true)
                        {
                            Boolean _cekTrOrder = this._orderBL.IsOrderSurveyPointAllComplete(Convert.ToInt64(_cd[2]));
                            if (_cekTrOrder == true)
                            {
                                TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this._cd[2]));
                                _trOrder.OrderStatus = OrderVersionMapper.GetOrderVersion(OrderVersion.Final);

                                Boolean _updateTrOrderFinal = this._orderBL.UpdateOrder(_trOrder);
                            }
                            this.WarningLabel.Text = "You Success Publish";
                            this.ShowData(0);
                        }
                    }
                }
            }
        }

        protected void GoImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData(0);
            this.WarningLabel.Text = "";
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
    }
}
