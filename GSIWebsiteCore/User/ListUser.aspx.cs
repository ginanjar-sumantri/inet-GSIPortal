using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Authentication;
using System.Web.Security;

namespace GSIWebsiteCore.User
{
    public partial class ListUser : UserBase
    {
        private UserBL _userBL = new UserBL();
        private MembershipService _membershipService = new MembershipService();

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
            this.DataPagerButton.Attributes.Add("Style", "visibility: hidden;");
            this.DataPagerBottomButton.Attributes.Add("Style", "visibility: hidden;");

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleListLiteral;
                this.ViewState[this._currPageKey] = 0;
                this.ShowData(0);
            }
        }

        private void ShowData(Int32 _prmCurrentPage)
        {
            NameValueCollectionExtractor _nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            this._page = _prmCurrentPage;
            Int32 _row = 0;

            this.ListRepeater.DataSource = this._membershipService.GetAllUsers(_prmCurrentPage, _maxrow, out _row);
            this.ListRepeater.DataBind();

            RequestVariable.RowCount = _row;

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
            MembershipUser _temp = (MembershipUser)e.Item.DataItem;
            Literal _userName = (Literal)e.Item.FindControl("UserNameLiteral");
            _userName.Text = HttpUtility.HtmlEncode(_temp.UserName);

            Literal _email = (Literal)e.Item.FindControl("EmailLiteral");
            _email.Text = HttpUtility.HtmlEncode(_temp.Email);

            Literal _lastLogin = (Literal)e.Item.FindControl("LastLoginLiteral");
            _lastLogin.Text = HttpUtility.HtmlEncode(Convert.ToString(_temp.LastLoginDate));

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.PostBackUrl = this._viewUserPage + "?" + this._userName + "=" + HttpUtility.HtmlEncode(_temp.UserName);

            ImageButton _activateButton = (ImageButton)e.Item.FindControl("ActivateImageButton");
            _activateButton.ImageUrl = this._imageURL + "btnActivateUser.png";
            _activateButton.ToolTip = this._toolTipActivate;
            _activateButton.CommandName = "Activate";
            _activateButton.CommandArgument = HttpUtility.HtmlEncode(_temp.UserName);

            ImageButton _disableButton = (ImageButton)e.Item.FindControl("DisableImageButton");
            _disableButton.ImageUrl = this._imageURL + "btnDisableUser.png";
            _disableButton.ToolTip = this._toolTipDisable;
            _disableButton.CommandName = "Disable";
            _disableButton.CommandArgument = HttpUtility.HtmlEncode(_temp.UserName);

            String _prmIsApproved = HttpUtility.HtmlEncode(Convert.ToString(_temp.IsApproved));
            if (_prmIsApproved == "True")
            {
                _activateButton.Visible = false;
            }
            else
            {
                _disableButton.Visible = false;
            }

            ImageButton _editButton = (ImageButton)e.Item.FindControl("EditImageButton");
            _editButton.ImageUrl = this._imageURL + "btnEdit.png";
            _editButton.ToolTip = this._toolTipEdit;
            _editButton.PostBackUrl = this._editUserPage + "?" + this._userName + "=" + HttpUtility.HtmlEncode(_temp.UserName);

        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Activate")
            {
                MembershipUser _membershipUser = this._membershipService.GetUser(Convert.ToString(e.CommandArgument), true);
                _membershipUser.IsApproved = true;
                this._membershipService.UpdateUser(_membershipUser);
                ShowData(0);
            }
            if (e.CommandName == "Disable")
            {
                MembershipUser _membershipUser = this._membershipService.GetUser(Convert.ToString(e.CommandArgument), true);
                _membershipUser.IsApproved = false;
                this._membershipService.UpdateUser(_membershipUser);
                ShowData(0);
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

        protected void AddImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._addUserPage);
        }
    }
}

