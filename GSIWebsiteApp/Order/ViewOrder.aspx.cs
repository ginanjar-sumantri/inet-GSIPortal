using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;
using GSIWebsiteAppBase;
using GSI.Common;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common.Enum;
using GSI.BusinessRuleCore;

namespace GSIWebsiteApp.Order
{
    public partial class ViewOrder : OrderBase
    {
        private OrderBL _orderBL = new OrderBL();
        private OrderSurveyPointBL _ordersurveyPointBL = new OrderSurveyPointBL();
        private String[] _cd;

        //private string _currPageKey = "CurrentPage";
        private int?[] _navMark = { null, null, null, null };
        //private bool _flag = true;
        //private bool _nextFlag = false;
        //private bool _lastFlag = false;

        //private int _page;
        //private int _maxrow = 20;
        //private int _maxlength = 5;
        //private int _no = 0;
        //private int _nomor = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteralViewOrder;

                this.AddSurveyPointImageButton.ImageUrl = this._imageURL + "btnAddSurveyPoint2.png";
                this.AddSurveyPointImageButton2.ImageUrl = this._imageURL + "btnAddSurveyPoint2.png";
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SubmitImageButton.ImageUrl = this._imageURL + "btnSubmit2.png";
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";

                this.InitializeData();
                if ((this._nvcExtractor.GetValue(this._codeKey) != ""))
                {
                    this.ShowLabel();
                    this.ShowData();                    
                    this.ShowSurveyPoint();
                }
                else
                {
                    this.ShowLabel();
                    this.ShowSurveyPoint();
                }
            }
        }

        public String Remark
        {
            get
            {
                return this.NoteTextBox.Text;
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._type);
            this._orderType = _queryString.Split(',');
        }

        private void ShowLabel()
        {
            this.OrderTypeIDLabel.Text = this._orderType[1];
            this.DateLabel.Text = "-";
            //this.ProceedDateLabel.Text = "-";
            if (this.DocStatusLabel.Text != "")
            {
                this.DocStatusPanel.Visible = true;
            }
            else
            {
                this.DocStatusPanel.Visible = false;
            }
        }

        private void ValidationImage(byte _prmOrderVersion)
        {
            if (_prmOrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            {
                this.SubmitImageButton.Visible = false;
                this.SaveImageButton.Visible = false;
                this.AddSurveyPointImageButton.Visible = false;
                this.AddSurveyPointImageButton2.Visible = false;
            }
            else
            {
                this.SubmitImageButton.Visible = true;
                this.SaveImageButton.Visible = true;
                this.AddSurveyPointImageButton.Visible = true;
                this.AddSurveyPointImageButton2.Visible = true;
            }

        }

        private void ShowData()
        {
            TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
            this.OrderIDLabel.Text = _trOrder.OrderCode;
            this.OrderTypeIDLabel.Text = OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID);
            this.DateLabel.Text = (DateFormMapper.GetValue(_trOrder.OrderDate) + " " + _trOrder.OrderDate.Hour.ToString().PadLeft(2, '0') + ":" + _trOrder.OrderDate.Minute.ToString().PadLeft(2, '0') + ":" + _trOrder.OrderDate.Second.ToString().PadLeft(2, '0'));
            this.DocStatusLabel.Text = OrderVersionMapper.GetOrderVersionText(_trOrder.OrderVersion);
            this.OrderVersionHiddenField.Value = _trOrder.OrderVersion.ToString();
            //if (_trOrder.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            //{
            //    this.ProceedDateLabel.Text = (DateFormMapper.GetValue(_trOrder.ProceedDate) + " " + _trOrder.ProceedDate.Hour.ToString().PadLeft(2, '0') + ":" + _trOrder.ProceedDate.Minute.ToString().PadLeft(2, '0') + ":" + _trOrder.ProceedDate.Second.ToString().PadLeft(2, '0'));
            //}
            //else
            //{
            //    this.ProceedDateLabel.Text = "-";
            //}

            if (_trOrder.OrderVersion == OrderVersionMapper.GetOrderVersion(OrderVersion.Final))
            {
                this.NoteTextBox.Text = _trOrder.Remark;
                this.NoteTextBox.Attributes.Add("ReadOnly", "True");
                this.NoteTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            }
            else
            {
                this.NoteTextBox.Text = _trOrder.Remark;
            }

           
            this.ListRepeater.DataSource = this._orderBL.GetListSPByOrderID(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
            this.ListRepeater.DataBind();

            this.ValidationImage(_trOrder.OrderVersion);
        }

        private void ShowSurveyPoint()
        {
            String _OrderTypeID = this._nvcExtractor.GetValue(this._type);
            this.ListRepeaterSurveyPoint.DataSource = this._orderBL.GetListSurveyPoinPersonal(Convert.ToInt64(this._orderType[0]));
            this.ListRepeaterSurveyPoint.DataBind();

            this.ListRepeaterSurveyPoint2.DataSource = this._orderBL.GetListSurveyPoinPersonal(Convert.ToInt64(this._orderType[0]));
            this.ListRepeaterSurveyPoint2.DataBind();
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            this.InitializeData();
            OrderDetail _temp = (OrderDetail)e.Item.DataItem;

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "icon_view.png";
            _viewButton.ToolTip = this._toolTipView;
            _viewButton.CommandName = "ViewOrder";
            _viewButton.CommandArgument = Convert.ToInt64(this._orderType[0]) + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;

            ImageButton _resultButton = (ImageButton)e.Item.FindControl("ResultButton");
            _resultButton.ImageUrl = this._imageURL + "icon_result.png";
            _resultButton.ToolTip = this._toolTipResult;

            if (_temp.SurveyPointStatus == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed))
            {
                _resultButton.Visible = true;
                _resultButton.CommandName = "ResultOrder";
                _resultButton.CommandArgument = Convert.ToInt64(this._orderType[0]) + "-" + _temp.SurveyPointID + "-" + _temp.OrderID + "-" + _temp.OrderSPID;
            }
            else
            {
                _resultButton.Visible = false;
            }

            Literal _spLiteral = (Literal)e.Item.FindControl("SPLiteral");
            _spLiteral.Text = HttpUtility.HtmlEncode(new SurveyPointBL().GetSingleSurveyPoint(_temp.SurveyPointID).SurveyPointName);
            this.SPiDHiddenField.Value = Convert.ToString(_temp.SurveyPointID);

            Literal _nameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            _nameLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);
            Literal _statusLiteral = (Literal)e.Item.FindControl("StatusLiteral");
            _statusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusEksternalText(_temp.SurveyPointStatus));
        }

        protected void ListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            this.InitializeData();
            if (e.CommandName == "ViewOrder")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._ordersurveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._orderType[0])), Convert.ToInt64(this._cd[1]));
                Response.Redirect(PointSurveyMapper.GetTemplateFormPath((int)_template.TemplateForm) + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._SPid + "=" + _cd[1] + "&" + this._codeKey + "=" + _cd[2] + "&" + this._orderSPID + "=" + _cd[3] + "&" + this._orderVersion + "=" + this.OrderVersionHiddenField.Value);
            }
            else if (e.CommandName == "ResultOrder")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                MsSurveyPoint _template = this._ordersurveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(this._orderType[0])), Convert.ToInt64(this._cd[1]));
                Response.Redirect(this._viewResultURL + PointSurveyMapper.GetTemplateFormPathForViewResult((int)_template.TemplateForm) + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._SPid + "=" + _cd[1] + "&" + this._codeKey + "=" + _cd[2] + "&" + this._orderSPID + "=" + _cd[3] + "&" + this._orderVersion + "=" + this.OrderVersionHiddenField.Value);
            }
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            long _custID = Convert.ToInt64(Session[this._sesCustID]);

            Boolean _result = false;
            if ((this._nvcExtractor.GetValue(this._codeKey) == ""))
            {
                DateTime _now = DateTime.Now;
                TrOrder _trOrder = new TrOrder();
                _trOrder.CustomerID = _custID;
                _trOrder.OrderCode = new AutoNumber().GetAutoNumberOrder(_custID);
                _trOrder.OrderTypeID = Convert.ToInt32(this._orderType[0]);
                _trOrder.OrderDate = _now;
                _trOrder.OrderVersion = OrderVersionMapper.GetOrderVersion(OrderVersion.Draft);
                _trOrder.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Initialized);
                _trOrder.ProceedDate = this._defaultDate;
                _trOrder.Remark = this.NoteTextBox.Text;
                _trOrder.RowStatus = 0;
                _trOrder.CreatedBy = HttpContext.Current.User.Identity.Name;

                _result = this._orderBL.InsertOrder(_trOrder);
            }
            else
            {
                TrOrder _trOrder = this._orderBL.GetSingleOrderByOrderID(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
                _trOrder.Remark = this.NoteTextBox.Text;
                _trOrder.ModifiedBy = HttpContext.Current.User.Identity.Name;
                _trOrder.ModifiedDate = DateTime.Now;

                _result = this._orderBL.UpdateOrder(_trOrder);
            }

            if (_result)
            {
                Response.Redirect(this._listOrderPage);
            }
        }

        protected void SubmitImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (this.SPiDHiddenField.Value != "")
            {
                Response.Redirect(this._confirmationOrderPage + "?" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey) + "");
            }
            else
            {
                this.WarningLabel.Text = "You Must Insert Survey Point";
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listOrderPage);
        }

        protected void ListRepeaterSurveyPoint_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            this.InitializeData();
            Mapper_OrderType_PointSurveybySurveyPoint _temp = (Mapper_OrderType_PointSurveybySurveyPoint)e.Item.DataItem;

            Button _surveyPointButton = (Button)e.Item.FindControl("SurveyPointButton");
            _surveyPointButton.Text = " " + _temp.PointSurveyNameMapper;
            _surveyPointButton.CommandName = "SurveyPoint";
            _surveyPointButton.CommandArgument = _temp.TemplateFormMapper.ToString() + "-" + _temp.PointSurveyIDMapper.ToString();

            Int64 _spOriID = Convert.ToInt64(ConfigurationManager.AppSettings["OriginatorID"].ToString());
            if (this._nvcExtractor.GetValue(this._codeKey) != "")
            {
                List<OrderDetail> _listOrderDt = this._orderBL.GetListSPByOrderID(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
                if (_listOrderDt.Count <= 0)
                {
                    if (_temp.PointSurveyIDMapper != _spOriID) _surveyPointButton.Enabled = false;
                }
                else
                {
                    if (_temp.PointSurveyIDMapper == _spOriID) _surveyPointButton.Enabled = false;
                }
            }
            else
            {
                if (_temp.PointSurveyIDMapper != _spOriID) _surveyPointButton.Enabled = false;
            }
        }

        protected void ListRepeaterSurveyPoint_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            this.InitializeData();
            if (e.CommandName == "SurveyPoint")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                HttpContext.Current.Session["RemarkOrder"] = this.NoteTextBox.Text;
                Response.Redirect(PointSurveyMapper.GetTemplateFormPath(Convert.ToInt32(this._cd[0])) + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._SPid + "=" + this._cd[1] + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey));
            }
        }

        protected void ListRepeaterSurveyPoint2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            this.InitializeData();
            Mapper_OrderType_PointSurveybySurveyPoint _temp = (Mapper_OrderType_PointSurveybySurveyPoint)e.Item.DataItem;

            Button _surveyPointButton = (Button)e.Item.FindControl("SurveyPointButton");
            _surveyPointButton.Text = " " + _temp.PointSurveyNameMapper;
            _surveyPointButton.CommandName = "SurveyPoint";
            _surveyPointButton.CommandArgument = _temp.TemplateFormMapper.ToString() + "-" + _temp.PointSurveyIDMapper.ToString();

            Int64 _spOriID = Convert.ToInt64(ConfigurationManager.AppSettings["OriginatorID"].ToString());
            if (this._nvcExtractor.GetValue(this._codeKey) != "")
            {
                List<OrderDetail> _listOrderDt = this._orderBL.GetListSPByOrderID(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
                if (_listOrderDt.Count <= 0)
                {
                    if (_temp.PointSurveyIDMapper != _spOriID) _surveyPointButton.Enabled = false;
                }
                else
                {
                    if (_temp.PointSurveyIDMapper == _spOriID) _surveyPointButton.Enabled = false;
                }
            }
            else
            {
                if (_temp.PointSurveyIDMapper != _spOriID) _surveyPointButton.Enabled = false;
            }
        }

        protected void ListRepeaterSurveyPoint2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            this.InitializeData();
            if (e.CommandName == "SurveyPoint")
            {
                String _ex = (e.CommandArgument.ToString());
                this._cd = _ex.Split('-');
                HttpContext.Current.Session["RemarkOrder"] = this.NoteTextBox.Text;
                Response.Redirect(PointSurveyMapper.GetTemplateFormPath(Convert.ToInt32(this._cd[0])) + "?" + this._type + "=" + this._nvcExtractor.GetValue(this._type) + "&" + this._SPid + "=" + this._cd[1] + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey));
            }
        }
    }
}
