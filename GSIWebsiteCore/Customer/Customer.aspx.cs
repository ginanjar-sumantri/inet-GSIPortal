using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.BusinessRule;

namespace GSIWebsiteCore.Customer
{
    public partial class Customer : CustomerBase
    {
        private CustomerBL _customerBL = new CustomerBL();
        private BusinessTypeBL _businessTypeBL = new BusinessTypeBL();
        private WCFBL _wcfBL = new WCFBL();

        private string _currPageKey = "CurrentPage";
        private int?[] _navMark = { null, null, null, null };
        private bool _flag = true;
        private bool _nextFlag = false;
        private bool _lastFlag = false;
        private int _page;
        private int _maxrow = 20;
        private int _maxlength = 5;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddImageButton.ImageUrl = this._imageURL + "btnAdd2.png";
            this.SyncImageButton.ImageUrl = this._imageURL + "btnSyncToCustomerPortal.png";
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");
            this.WarningLabel.Text = "";
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;
                this.ViewState[this._currPageKey] = 0;
                this.ShowData(0);
            }
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            this._page = _prmCurrentPage;

            this.AddImageButton.ImageUrl = this._imageURL + "btnAdd2.png";
            this.ListRepeater.DataSource = this._customerBL.GetListFromMsCustomer(_maxrow, _prmCurrentPage, "CustomerName", "");
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

        private double RowCount()
        {
            double _result = 0;

            _result = RequestVariable.RowCount;
            _result = System.Math.Ceiling(_result / (double)_maxrow);

            return _result;
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            MsCustomer _temp = (MsCustomer)e.Item.DataItem;

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.PostBackUrl = this._viewCustomerPage + "?" + this._customerID + "=" + HttpUtility.HtmlEncode(_temp.CustomerID);

            //Literal _customerIDLiteral = (Literal)e.Item.FindControl("CustomerIDLiteral");
            //_customerIDLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerID);

            Literal _customerNameLiteral = (Literal)e.Item.FindControl("CustomerNameLiteral");
            _customerNameLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerName);

            Literal _customerCodeLiteral = (Literal)e.Item.FindControl("CustomerCodeLiteral");
            _customerCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerCode);

            Literal _businessTypeLiteral = (Literal)e.Item.FindControl("BusinessTypeLiteral");
            _businessTypeLiteral.Text = HttpUtility.HtmlEncode(new BusinessTypeBL().GetBusinessTypeNameByBusinessTypeID(Convert.ToInt64(_temp.BusinessTypeID)).BusinessTypeName);

            Literal _customerAddress1Literal = (Literal)e.Item.FindControl("CustomerAddress1Literal");
            _customerAddress1Literal.Text = HttpUtility.HtmlEncode(_temp.CustomerAddress1);

            //Literal _customerAddress2Literal = (Literal)e.Item.FindControl("CustomerAddress2Literal");
            //_customerAddress2Literal.Text = HttpUtility.HtmlEncode(_temp.CustomerAddress2);

            Literal _zipCodeLiteral = (Literal)e.Item.FindControl("ZipCodeLiteral");
            _zipCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.ZipCode);

            Literal _cityLiteral = (Literal)e.Item.FindControl("cityLiteral");
            _cityLiteral.Text = HttpUtility.HtmlEncode(_temp.City);

            Literal _phoneLiteral = (Literal)e.Item.FindControl("PhoneLiteral");
            _phoneLiteral.Text = HttpUtility.HtmlEncode(_temp.Phone);

            Literal _faxLiteral = (Literal)e.Item.FindControl("FaxLiteral");
            _faxLiteral.Text = HttpUtility.HtmlEncode(_temp.Fax);

            Literal _npwpLiteral = (Literal)e.Item.FindControl("NPWPLiteral");
            _npwpLiteral.Text = HttpUtility.HtmlEncode(_temp.NPWP);

          

            //Literal _remarkLiteral = (Literal)e.Item.FindControl("RemarkLiteral");
            //_remarkLiteral.Text = HttpUtility.HtmlEncode(_temp.Remark);

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

        protected void AddImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(this._addCustomerPage);
        }

        protected void SyncImageButton_Click(object sender, EventArgs e)
        {
            this._wcfBL.SyncMaster("MsCustomer");
            if (ErrorHandler.ErrorMessage != "" && ErrorHandler.ErrorMessage != null)
            {
                this.WarningLabel.Text = ErrorHandler.ErrorMessage;
            }
            else
            {
                this.WarningLabel.Text = "Synchronize Master Customer Have Been Finished";
            }
        }
    }
}