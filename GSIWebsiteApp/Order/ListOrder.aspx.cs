using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;

namespace GSIWebsiteApp.Order
{
    public partial class ListOrder : OrderBase
    {
        private OrderBL _orderBL = new OrderBL();
        private OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

        private string _currPageKey = "CurrentPage";
        private int?[] _navMark = { null, null, null, null };
        private bool _flag = true;
        private bool _nextFlag = false;
        private bool _lastFlag = false;

        private int _page;
        private int _maxrow = 20;
        private int _maxlength = 5;
        //private int _no = 0;
        //private int _nomor = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;

                this.ViewState[this._currPageKey] = 0;

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

                this.GoImageButton.ImageUrl = this._imageURL + "btnGO2.jpg";
                //this.AddPersonalOrderButton.ImageUrl = this._imageURL + "btnAddPersonalOrder.jpg";
                //this.AddPersonalOrderButton2.ImageUrl = this._imageURL + "btnAddPersonalOrder.jpg";
                //this.AddCompanyOrderButton.ImageUrl = this._imageURL + "btnAddCompanyOrder.jpg";
                //this.AddCompanyOrderButton2.ImageUrl = this._imageURL + "btnAddCompanyOrder.jpg";
                
                this.StartDateLiteral.Text = "<input id='StartDateButton' type='button' onclick='displayCalendar(" + this.StartDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";
                this.EndDateLiteral.Text = "<input id='EndDateButton' type='button' onclick='displayCalendar(" + this.EndDateTextBox.ClientID + ",&#39" + DateFormMapper.GetFormat() + "&#39,this)' value='...' />";

                this.SetAttribute();
                this.SetInitializeData();
                this.ClearLabel();
                this.CheckSession();
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
            //this.StartDateTextBox.Text = DateFormMapper.GetValue(_now);
            //this.StartDateTextBox.Text = (_now.Day - 02).ToString().PadLeft(2, '0') + "-" + _now.Month + "-" + _now.Year;
            this.StartDateTextBox.Text = DateFormMapper.GetValue(_now.AddDays(-2));
            this.EndDateTextBox.Text = DateFormMapper.GetValue(_now);
        }

        private void CheckSession()
        {
            if (HttpContext.Current.Session[this._sesOrderNumber] != null) this.KeywordOrderNoTextBox.Text = HttpContext.Current.Session[this._sesOrderNumber].ToString();
            if (HttpContext.Current.Session[this._sesOrderStartDate] != null) this.StartDateTextBox.Text = HttpContext.Current.Session[this._sesOrderStartDate].ToString();
            if (HttpContext.Current.Session[this._sesOrderEndDate] != null) this.EndDateTextBox.Text = HttpContext.Current.Session[this._sesOrderEndDate].ToString();
            if (HttpContext.Current.Session[this._sesOrderType] != null) this.KeywordOrderTypeDropDownList.SelectedValue = HttpContext.Current.Session[this._sesOrderType].ToString();
            if (HttpContext.Current.Session[this._sesOrderDocStatus] != null) this.KeywordDocStatusDropDownList.SelectedValue = HttpContext.Current.Session[this._sesOrderDocStatus].ToString();
        }

        private void SetSession()
        {
            HttpContext.Current.Session[this._sesOrderNumber] = this.KeywordOrderNoTextBox.Text;
            HttpContext.Current.Session[this._sesOrderStartDate] = this.StartDateTextBox.Text;
            HttpContext.Current.Session[this._sesOrderEndDate] = this.EndDateTextBox.Text;
            HttpContext.Current.Session[this._sesOrderType] = this.KeywordOrderTypeDropDownList.SelectedValue;
            HttpContext.Current.Session[this._sesOrderDocStatus] = this.KeywordDocStatusDropDownList.SelectedValue;
        }

        private void SetAttribute()
        {
            this.StartDateTextBox.Attributes.Add("ReadOnly", "True");
            this.EndDateTextBox.Attributes.Add("ReadOnly", "True");
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            this._page = _prmCurrentPage;

            //Int64 _custID = 7;

            DateTime _startTime = DateFormMapper.GetValue(this.StartDateTextBox.Text);
            DateTime _endTime = DateFormMapper.GetValue(this.EndDateTextBox.Text);
            _endTime = _endTime.AddHours(23);
            _endTime = _endTime.AddMinutes(59);
            _endTime = _endTime.AddSeconds(59);
            this.WarningLabel.Text = "";

            //string a = HttpContext.Current.User.Identity.Name;
            this.ListRepeater.DataSource = this._orderBL.GetListOrderStatus(Convert.ToInt64(HttpContext.Current.Session[this._sesCustID]), this.KeywordOrderNoTextBox.Text, Convert.ToInt64(this.KeywordOrderTypeDropDownList.SelectedValue), 2, Convert.ToInt16(this.KeywordDocStatusDropDownList.SelectedValue), _startTime, _endTime, _maxrow, _prmCurrentPage, "", "");
            this.ListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);
        }

        private double RowCount()
        {
            double _result = 0;

            _result = RequestVariable.RowCount; //_cityBL.RowsCount(this.CategoryDropDownList.SelectedValue, this.KeywordTextBox.Text);
            _result = System.Math.Ceiling(_result / (double)_maxrow);

            return _result;
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrOrder _temp = (TrOrder)e.Item.DataItem;
            Int64 _code = _temp.OrderID;
            Int64 _orderTypeID = _temp.OrderTypeID;

            List<MsOrderType> _msOrderType = new OrderTypeBL().GetListOrderType();
            Literal _spLiteral = (Literal)e.Item.FindControl("OrderNoLiteral");
            _spLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderCode);

            if (_temp.OrderTypeID == OrderMapper.GetOrderType(OrderType.Personal))
            {
                TrOrderSPMovable _trOrderSPMovable = this._orderSPBL.GetOriginatorPersonalByOrderID(_temp.OrderID);
                if (_trOrderSPMovable.SurveyPointName == null)
                {
                    Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointNameLiteral");
                    _nameLiteral.Text = "-";
                }
                else
                {
                    Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointNameLiteral");
                    _nameLiteral.Text = HttpUtility.HtmlEncode(_trOrderSPMovable.SurveyPointName);
                }
            }
            else
            {
                TrOrderSPMovable _trOrderSPMovable = this._orderSPBL.GetOriginatorPersonalByOrderID(_temp.OrderID);
                if (_trOrderSPMovable.SurveyPointName == null)
                {
                    Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointNameLiteral");
                    _nameLiteral.Text = "-";
                }
                else
                {
                    Literal _nameLiteral = (Literal)e.Item.FindControl("SurveyPointNameLiteral");
                    _nameLiteral.Text = HttpUtility.HtmlEncode(_trOrderSPMovable.SurveyPointName);
                }
            }

            //Literal _nameLiteral = (Literal)e.Item.FindControl("OrderTypeLiteral");
            //_nameLiteral.Text = HttpUtility.HtmlEncode(OrderMapper.GetOrderTypeName(_temp.OrderTypeID));

            Literal _statusLiteral = (Literal)e.Item.FindControl("CreatedDateLiteral");
            _statusLiteral.Text = (DateFormMapper.GetValue(_temp.OrderDate) + " " + _temp.OrderDate.Hour.ToString().PadLeft(2, '0') + ":" + _temp.OrderDate.Minute.ToString().PadLeft(2, '0') + ":" + _temp.OrderDate.Second.ToString().PadLeft(2, '0'));

            if (_temp.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            {
                Literal _proceedLiteral = (Literal)e.Item.FindControl("ProceedLiteral");
                _proceedLiteral.Text = (DateFormMapper.GetValue(_temp.ProceedDate) + " " + _temp.ProceedDate.Hour.ToString().PadLeft(2, '0') + ":" + _temp.ProceedDate.Minute.ToString().PadLeft(2, '0') + ":" + _temp.ProceedDate.Second.ToString().PadLeft(2, '0'));
            }
            else
            {
                Literal _proceedLiteral = (Literal)e.Item.FindControl("ProceedLiteral");
                _proceedLiteral.Text = "-";
            }
            //Literal _timeLiteral = (Literal)e.Item.FindControl("TimeLiteral");
            //_timeLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderDate.Hour.ToString().PadLeft(2, '0') + ":" + _temp.OrderDate.Minute.ToString().PadLeft(2, '0') + ":" + _temp.OrderDate.Second.ToString().PadLeft(2, '0'));

            Literal _docLiteral = (Literal)e.Item.FindControl("DocStatusLiteral");
            _docLiteral.Text = HttpUtility.HtmlEncode(OrderVersionMapper.GetOrderVersionText(_temp.OrderVersion));

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.PostBackUrl = this._viewOrderPage + "?" + this._type + "=" + _orderTypeID + "," + _msOrderType[0].OrderTypeName + "&" + this._codeKey + "=" + _code + "&" + this._orderVersion + "=" + _temp.OrderVersion;

            ImageButton _dropButton = (ImageButton)e.Item.FindControl("DropImageButton");
            _dropButton.ImageUrl = this._imageURL + "icon_drop.png";
            _dropButton.ToolTip = this._toolTipDrop;
            _dropButton.Visible = false; //Sementara by Ginanjar :)
            if (_temp.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Draft))
            {
                _dropButton.Attributes.Add("OnClick", "return Drop();");
                _dropButton.CommandName = "DropOrder";
                _dropButton.CommandArgument = _temp.OrderID.ToString();
            }
            else
            {
                _dropButton.Attributes.Add("OnClick", "return Confirmation();");
            }

            ImageButton _submitButton = (ImageButton)e.Item.FindControl("SubmitImageButton");
            _submitButton.ImageUrl = this._imageURL + "icon_submit.png";
            _submitButton.ToolTip = this._toolTipSubmit;
            _submitButton.CommandName = "Submit";
            _submitButton.CommandArgument = _code.ToString();

            if (_temp.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            {
                _submitButton.Visible = false;
            }
            else
            {
                _submitButton.Visible = true;
            }

        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DropOrder")
            {

                TrOrder _trOrder = new TrOrder();
                _trOrder.OrderID = Convert.ToInt64(e.CommandArgument.ToString());
                _trOrder.ModifiedBy = HttpContext.Current.User.Identity.Name;
                _trOrder.RowStatus = 1;

                int _result = this._orderBL.DeletedOrder(_trOrder);

                if (_result == 1 && ErrorHandler.ErrorMessage == "")
                {
                    this.ShowData(0);
                }
                else
                {
                    this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                    ErrorHandler.ErrorMessage = "";
                }
            }

            if (e.CommandName == "Submit")
            {
                List<TrOrderSPMovable> _trOrderSPMovable = this._orderBL.GetListTrOrderSPMovableByOrderId(Convert.ToInt64(e.CommandArgument));
                List<TrOrderSPNotMovable> _trOrderSPNotMovable = this._orderBL.GetListTrOrderSPNotMovableByOrderId(Convert.ToInt64(e.CommandArgument));

                if (_trOrderSPMovable.Count != 0 || _trOrderSPNotMovable.Count != 0)
                {
                    Response.Redirect(this._confirmationOrderPage + "?" + this._codeKey + "=" + e.CommandArgument);
                }
                else
                {
                    this.WarningLabel.Text = "You Must Insert Survey Point";
                }
            }
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

        //protected void AddCompanyOrderButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect(this._viewOrderPage + "?Type=Company");
        //}

        //protected void AddPersonalOrderButton_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect(this._viewOrderPage + "?Type=Personal");
        //}

        protected void GoImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.SetSession();
            this.ShowData(0);
        }
    }
}
