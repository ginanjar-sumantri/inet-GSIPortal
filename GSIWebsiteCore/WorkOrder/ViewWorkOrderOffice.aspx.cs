using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using GSI.Common;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common.Enum;
using GSI.BusinessRuleCore;
using Microsoft.Reporting.WebForms;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class ViewWorkOrderOffice : WorkOrderBase
    {
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private BusinessTypeBL _msBusinessTypeBL = new BusinessTypeBL();

        private ResultBL _resultBL = new ResultBL();
        private RequiredDocumentBL _reqDocBL = new RequiredDocumentBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();

        int i = 0;
        int j = 0;
        int z = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleViewWorkOrderLiteral;

                this.WORefImageButton.ImageUrl = this._imageURL + "WoRef.png";

                TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
                if (_trWorkOrderNotMovable.WORef == 0)
                {
                    this.WORefImageButton.Visible = false;
                }
                else
                {
                    this.WORefImageButton.Visible = true;
                }

                this.BackImageButton.ImageUrl = this._imageURL + "btnBack.png";

                this.CorrectionImageButton.ImageUrl = this._imageURL + "Correction.png";

                this.PreviewImageButton.ImageUrl = this._imageURL + "btnPreview2.png";

                this.PreviewWithImageButton.ImageUrl = this._imageURL + "btnPreview.png";

                this.InitializeData();

                this.ShowData();
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._workOrderCode);
            this._orderType = _queryString.Split('/');
        }

        private void ShowData()
        {
            TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));

            this.WorkOrderCodeLabel.Text = _trWorkOrderNotMovable.WorkOrderCode;
            this.SurveyorNameLabel.Text = (new EmployeeBL().GetSingleEmployee((this._surveyorBL.GetSingleSurveyor(_trWorkOrderNotMovable.SurveyorID).EmployeeID)).EmployeeName);
            this.DateLabel.Text = DateFormMapper.GetValue(_trWorkOrderNotMovable.CreatedDate);
            //this.WorkOrderStatusLabel.Text = GlobalStatusMapper.GetStatusText(_trWorkOrderNotMovable.WorkOrderStatusID);
            this.WorkOrderStatusLabel.Text = StatusMapper.GetStatusInternalText(_trWorkOrderNotMovable.WorkOrderStatusID);
            //this.RemarkLabel.Text = _trWorkOrderNotMovable.Remark;
            this.OrderSPIDHiddenField.Value = _trWorkOrderNotMovable.OrderSPNotMovableID.ToString();

            TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(_trWorkOrderNotMovable.OrderSPNotMovableID);
            this.CompanyLiteral.Text = _trOrderSPNotMovable.SurveyPointName;
            this.BusinessLiteral.Text = this._msBusinessTypeBL.GetSingleBusinessType(_trOrderSPNotMovable.BusinessTypeID).BusinessTypeName;
            this.CompanyAddressLiteral.Text = _trOrderSPNotMovable.Address;
            this.ClueLiteral.Text = _trOrderSPNotMovable.Clue;
            this.ZipCodeLiteral.Text = _trOrderSPNotMovable.ZipCode;
            this.RemarkTextBox.Text = _trOrderSPNotMovable.Remark;

            TrResultNotMovable _trResultNotMovable = this._resultBL.GetResultNotMovableForWorkOrder(_trWorkOrderNotMovable.WorkOrderNotMovableID);
            this.CompanyAgeLiteral.Text = _trResultNotMovable.CompanyPeriod;
            //this.LineOfBusinessLiteral.Text = _trResultNotMovable.BusinessLine;
            this.CompanyConditionLiteral.Text = _trResultNotMovable.CompanyCondition;
            this.PositionLiteral.Text = _trResultNotMovable.Position;
            this.WorkingPeriodLiteral.Text = _trResultNotMovable.WorkingPeriod;
            this.RemarkOrderTextBox.Text = _trResultNotMovable.Remark;
            //this.OtherInformationLiteral.Text = _trResultNotMovable.Others;

            //additional photo
            List<TrResultPhotoAdditionalNotMovable> _trResultPhoto = this._resultBL.GetResultAdditionalPhotobyResultNotMovableID(_trResultNotMovable.ResultNotMovableID);
            this.ListRepeater.DataSource = _trResultPhoto;
            this.ListRepeater.DataBind();
            if (_trResultPhoto.Count == 0)
            {
                this.DivAdditionalPhoto.Visible = false;
            }

            //group
            this.DocumentTypeListRepeater.DataSource = this._reqDocBL.GetListDocTypeByOrderSPIDNotMovable(_trWorkOrderNotMovable.OrderSPNotMovableID);
            this.DocumentTypeListRepeater.DataBind();

            //content
            this.ContentListRepeater.DataSource = this._reqDocBL.GetListDocTypeByOrderSPIDNotMovable(_trWorkOrderNotMovable.OrderSPNotMovableID);
            this.ContentListRepeater.DataBind();

            if (_trWorkOrderNotMovable.WorkOrderStatusID != StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
            {
                this.CorrectionImageButton.Visible = false;
            }
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrResultPhotoAdditionalNotMovable _temp = (TrResultPhotoAdditionalNotMovable)e.Item.DataItem;

            Literal _lightBox = (Literal)e.Item.FindControl("LightBoxLiteral");
            _lightBox.Text = "<a class='example1' title='" + "ID : " + _temp.ResultPhotoAdditionalNotMovableID + ", Remark : " + _temp.Remark + "' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=AdditionalPhoto" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='max-width:" + this._imgMaxWidth + "; max-height:" + this._imgMaxHeight + ";'>";
            _lightBox.Text += "<img src=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=AdditionalPhoto" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='width:" + this._imgThumbWidth + "; height:" + this._imgThumbHeight + ";' />";
            Literal _closelightBox = (Literal)e.Item.FindControl("CloseLightBoxLiteral");
            _closelightBox.Text = "</a>";
            z++;

            Literal _maps = (Literal)e.Item.FindControl("GoogleMapsLiteral");
            _maps.Text = "<a class='example2' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "GoogleTagging.ashx" + "?" + "Latitude" + "=" + _temp.Latitude + "&" + "Longitude" + "=" + _temp.Longitude + "&" + "ImageHeight=512&ImageWidth=512" + "&" + "format=jpg'" + " alt='Google Tag'>";
            _maps.Text += "<img src='../contents/images/googleMapsIcon.jpg' style='width:15px; height:15px;' />";
            Literal _closemaps = (Literal)e.Item.FindControl("CloseGoogleMapsLiteral");
            _closemaps.Text = "</a>";

            Image _remark = (Image)e.Item.FindControl("RemarkImage");
            _remark.ImageUrl = this._imageURL + "remarkicon.jpg";
            _remark.Attributes.Add("Style", "Width: 15px");
            _remark.Attributes.Add("Style", "Height: 15px");
            _remark.ToolTip = _temp.Remark;
        }

        protected void DocumentTypeListRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ReqDocument _temp = (ReqDocument)e.Item.DataItem;

            Literal _docTypeLiteral = (Literal)e.Item.FindControl("TabLiteral");
            _docTypeLiteral.Text = "<li><a href=\"#tabs-" + i + "\">" + (_temp.DocumentName) + "</a></li>";
            i++;
        }

        protected void ContentListRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ReqDocument _temp = (ReqDocument)e.Item.DataItem;

            Literal _opendivContent = (Literal)e.Item.FindControl("OpendivContent");
            _opendivContent.Text = "<div id=\"tabs-" + j + "\">";
            Literal _closeDivContent = (Literal)e.Item.FindControl("CloseDivContent");
            _closeDivContent.Text = "</div>";
            j++;

            Repeater _docListRepeater = (Repeater)e.Item.FindControl("DetailDocumentListRepeater");
            _docListRepeater.DataSource = this._resultBL.GetResultReqDocNotMoveable(Convert.ToInt64(this.OrderSPIDHiddenField.Value), _temp.DocumentTypeID);
            _docListRepeater.DataBind();

            Literal _caroStart = (Literal)e.Item.FindControl("CaroStartLiteral");
            _caroStart.Text = "<ul id='mycarousel" + j + "' class='jcarousel-skin-tango'>";
            Literal _caroEnd = (Literal)e.Item.FindControl("CaroEndLiteral");
            _caroEnd.Text = "</ul>";
        }

        protected void DetailDocumentListRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrResultReqDocNotMovable _temp = (TrResultReqDocNotMovable)e.Item.DataItem;

            Literal _lightBox2 = (Literal)e.Item.FindControl("ImageDocLiteral");
            _lightBox2.Text = "<a class='example1' title='" + "ID : " + _temp.ResultReqDocNotMovableID + ", Remark : " + _temp.Remark + "' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=RequiredDocument" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='max-width:" + this._imgMaxWidth + "; max-height:" + this._imgMaxHeight + ";'>";
            _lightBox2.Text += "<img src=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=RequiredDocument" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='width:" + this._imgThumbWidth + "; height:" + this._imgThumbHeight + ";' />";

            Literal _closelightBox2 = (Literal)e.Item.FindControl("CloseImageDocLiteral");
            _closelightBox2.Text = "</a>";

            Literal _maps = (Literal)e.Item.FindControl("GoogleMapsLiteral2");
            _maps.Text = "<a class='example2' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "GoogleTagging.ashx" + "?" + "Latitude" + "=" + _temp.Latitude + "&" + "Longitude" + "=" + _temp.Longitude + "&" + "ImageHeight=512&ImageWidth=512" + "&" + "format=jpg'" + " alt='Google Tag'>";
            _maps.Text += "<img src='../contents/images/googleMapsIcon.jpg' style='width:15px; height:15px;' />";
            Literal _closemaps = (Literal)e.Item.FindControl("CloseGoogleMapsLiteral2");
            _closemaps.Text = "</a>";

            Image _remark = (Image)e.Item.FindControl("RemarkImage2");
            _remark.ImageUrl = this._imageURL + "remarkicon.jpg";
            _remark.Attributes.Add("Style", "Width: 15px");
            _remark.Attributes.Add("Style", "Height: 15px");
            _remark.ToolTip = _temp.Remark;
        }

        protected void BackImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listWorkOrderPage);
        }

        protected void CorrectionImageButton_Click(object sender, ImageClickEventArgs e)
        {
            List<TrWorkOrder> _listTrWorkOrder = this._workOrderBL.GetListWorkOrder(this.WorkOrderCodeLabel.Text, Convert.ToString(StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived)), "", DateFormMapper.GetValue("01-01-1999"), DateFormMapper.GetValue("01-01-9999"), "", "", 999999, 1, 0, "", "",99);
            TrWorkOrder _trWorkOrder = null;

            foreach (var _data in _listTrWorkOrder)
            {
                _trWorkOrder = new TrWorkOrder();
                _trWorkOrder.OrderTypeID = _data.OrderTypeID;
                _trWorkOrder.SurveyPointID = _data.SurveyPointID;
                _trWorkOrder.OrderID = _data.OrderID;
                _trWorkOrder.OrderSPID = _data.OrderSPID;
            }
            if (_trWorkOrder != null)
            {
                MsSurveyPoint _template = this._surveyPointBL.GetTemplateSurveyPoint(_trWorkOrder.OrderTypeID, _trWorkOrder.SurveyPointID);
                Response.Redirect("~/WorkOrder/AddWorkOrderAssign.aspx" + "?" + this._orderSPID + "=" + _trWorkOrder.OrderSPID + "&" + _spType + "=" + _template.TemplateForm + "&" + this._SPid + "=" + _trWorkOrder.SurveyPointID + "&" + this._workOrderType + "=" + WOTypeMapper.GetWOTypeText(WOTypeEnum.Correction));
            }
        }

        protected void PreviewImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;            

            string _path = "/SurveyorSystem/ReportResultWONotMov";            

            ReportParameter[] _reportParam = new ReportParameter[1];
            _reportParam[0] = new ReportParameter("WorkOrderNotMovableID", Convert.ToString(this._nvcExtractor.GetValue(this._codeKey).Trim()), false);
            this.ReportViewer1.Reset();
            this.ReportViewer1.ShowCredentialPrompts = false;
            ServerReport _serverReport = ReportViewer1.ServerReport;
            this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
            this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
            this.ReportViewer1.ServerReport.ReportPath = _path;

            this.ReportViewer1.ServerReport.SetParameters(_reportParam);
            ReportViewer1.ServerReport.Refresh();
        }

        protected void WORefImageButton_Click(object sender, ImageClickEventArgs e)
        {
            TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));
            Int64 _woRef =  _trWorkOrderNotMovable.WORef;
            Response.Redirect(this._viewWorkOrderOfficePage + "?" + this._codeKey + " = " + Convert.ToString(_woRef));
        }

        protected void PreviewWithImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
                        
            string _path = "/SurveyorSystem/ReportResultWONotMovWithImage";
            string _url = ConfigurationManager.AppSettings["ImageRendererURLForReport"];
            

            ReportParameter[] _reportParam = new ReportParameter[2];
            _reportParam[0] = new ReportParameter("WorkOrderNotMovableID", Convert.ToString(this._nvcExtractor.GetValue(this._codeKey).Trim()), false);
            _reportParam[1] = new ReportParameter("ImageRendererURL", _url, false);
            this.ReportViewer1.Reset();
            this.ReportViewer1.ShowCredentialPrompts = false;
            ServerReport _serverReport = ReportViewer1.ServerReport;
            this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
            this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
            this.ReportViewer1.ServerReport.ReportPath = _path;

            this.ReportViewer1.ServerReport.SetParameters(_reportParam);
            ReportViewer1.ServerReport.Refresh();
        }

        [Serializable]
        public class ReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
        {
            string _userName, _password, _domain;

            public ReportCredentials(string userName, string password, string domain)
            {
                _userName = userName;
                _password = password;
                _domain = domain;
            }

            public System.Security.Principal.WindowsIdentity ImpersonationUser
            {
                get
                {
                    return null;
                }
            }

            public System.Net.ICredentials NetworkCredentials
            {
                get
                {
                    return new System.Net.NetworkCredential(_userName, _password, _domain);
                }
            }

            public bool GetFormsCredentials(out System.Net.Cookie authCoki, out string userName, out string password, out string authority)
            {
                userName = _userName;
                password = _password;
                authority = _domain;
                authCoki = new System.Net.Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "Domain");
                return true;
            }

        }
    }
}
