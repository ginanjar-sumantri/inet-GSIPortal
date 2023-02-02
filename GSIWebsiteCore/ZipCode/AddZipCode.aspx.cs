using System;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;

namespace GSIWebsiteCore.ZipCode
{
    public partial class AddZipCode : ZipCodeBase
    {
        private RegionBL _regionBL = new RegionBL();
        private RegionZipCodeBL _regionZipCodeBL = new RegionZipCodeBL();
        private String _queryString;

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
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.Save2ImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.Reset2ImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.RegionCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.RegionCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.RegionNameTextBox.Attributes.Add("ReadOnly", "True");
                this.RegionNameTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ZipCodeEditTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.ZipCodeEditTextBox.ClientID + "," + this.ZipCodeEditTextBox.ClientID + ",500" + ")");

                this.ViewState[this._currPageKey] = 0;

                this.ClearLabel();
                this.ClearData();
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._regionID) != ""))
                {                    
                    this.ClearLabel();
                    this.ClearData();
                    this.ShowData(0);
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._regionID);
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            this.InitializeData();

            this._page = _prmCurrentPage;

            MsRegion _msRegion = this._regionBL.GetMsRegionByRegionId(Convert.ToInt64(this._queryString));

            this.RegionCodeTextBox.Text = _msRegion.RegionCode;
            this.RegionNameTextBox.Text = _msRegion.RegionName;

            this.ListRepeater.DataSource = this._regionZipCodeBL.GetListZipCodeByRegion(_maxrow, _prmCurrentPage, "", "", Convert.ToInt64(this._queryString));
            this.ListRepeater.DataBind();

            this.ShowPage(_prmCurrentPage);
        }

        private void ClearData()
        {
            this.ZipCodeEditTextBox.Text = "";
            this.RegionZipCodeIDHiddenField.Value = "";
        }

        private void ClearLabel()
        {
            this.WarningLabel.Text = "";
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

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listRegionPage);
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            MsRegionZipCode _temp = (MsRegionZipCode)e.Item.DataItem;

            ImageButton _editButton = (ImageButton)e.Item.FindControl("EditImageButton");
            _editButton.ImageUrl = this._imageURL + "icon_view.png";
            _editButton.CommandName = "Edit";
            _editButton.CommandArgument = _temp.ZipCode + "-" + _temp.RegionZipCodeID;

            ImageButton _deleteButton = (ImageButton)e.Item.FindControl("DeleteImageButton");
            _deleteButton.ImageUrl = this._imageURL + "icon_drop.png";
            _deleteButton.Attributes.Add("OnClick", "return Drop();");
            _deleteButton.CommandName = "Delete";
            _deleteButton.CommandArgument = _temp.RegionZipCodeID.ToString();

            Literal _zipCodeLiteral = (Literal)e.Item.FindControl("ZipCodeLiteral");
            _zipCodeLiteral.Text = HttpUtility.HtmlEncode(_temp.ZipCode);
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                string[] _ex = (e.CommandArgument.ToString()).Split('-');
                this.ZipCodeEditTextBox.Text = _ex[0];
                this.RegionZipCodeIDHiddenField.Value = (_ex[1]);
            }
            else if (e.CommandName == "Delete")
            {
                int _result = 0;
                this.InitializeData();

                MsRegionZipCode _msRegionZipCode = new MsRegionZipCode();
                _msRegionZipCode.RegionZipCodeID = Convert.ToInt64(e.CommandArgument);
                _msRegionZipCode.ModifiedBy = Request.ServerVariables["LOGON_USER"];
                _msRegionZipCode.RowStatus = 1;

                _result = this._regionZipCodeBL.DeletedRegionZipCode(_msRegionZipCode);

                if (_result == -1 && ErrorHandler.ErrorMessage == "")
                {
                    this.WarningLabel.Text = "You Success Update";
                    Response.Redirect(this._addZipCodePage + "?" + this._regionID + "=" + this._queryString);
                }
                else
                {
                    //this.WarningLabel.Text = "You Failed Delete Data";
                    this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                    ErrorHandler.ErrorMessage = "";
                }
            }
        }

        protected void Save2ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (this.RegionZipCodeIDHiddenField.Value != "")
            {
                Boolean _result = false;

                MsRegionZipCode _msRegionZipCode = this._regionZipCodeBL.GetRegionZipCodeByRegionZipCodeId(Convert.ToInt64(this.RegionZipCodeIDHiddenField.Value));

                _msRegionZipCode.ZipCode = this.ZipCodeEditTextBox.Text;
                _msRegionZipCode.ModifiedBy = Request.ServerVariables["LOGON_USER"];
                _msRegionZipCode.ModifiedDate = DateTime.Now;

                _result = this._regionZipCodeBL.UpdateMsRegionZipCode(_msRegionZipCode);

                if (_result)
                {
                    this.ClearLabel();
                    this.WarningLabel.Text = "You Success update";
                    this.ClearData();
                    this.ShowData(0);
                }
            }
            else
            {
                this.InitializeData();

                MsRegionZipCode _msRegionZipCode = new MsRegionZipCode();

                _msRegionZipCode.RegionID = Convert.ToInt64(this._queryString);
                _msRegionZipCode.ZipCode = this.ZipCodeEditTextBox.Text;
                _msRegionZipCode.CreatedBy = Request.ServerVariables["LOGON_USER"];

                int _success = this._regionZipCodeBL.InsertMsRegionZipCode(_msRegionZipCode);

                if (_success == -1)
                {
                    this.ClearLabel();
                    this.WarningLabel.Text = "you success update";
                    this.ClearData();
                    this.ShowData(0);
                }
                else
                {
                    this.ClearLabel();
                    this.WarningLabel.Text = "you failed add data";
                }
            }
        }

        protected void Reset2ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }
    }
}
