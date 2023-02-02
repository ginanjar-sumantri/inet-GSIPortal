using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using GSIWebsiteAppBase;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using System.Web;
using Microsoft.Reporting.WebForms;

namespace GSIWebsiteApp.OrderResult
{
    public partial class ViewResultCompany : OrderResultBase
    {
        private ResultBL _resultBL = new ResultBL();
        private RequiredDocumentBL _reqDocBL = new RequiredDocumentBL();
        private BusinessTypeBL _businessTypeBL = new BusinessTypeBL();
        private OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
        private OrderBL _orderBL = new OrderBL();
        private WorkOrderBL _woBL = new WorkOrderBL();
        private SurveyPointLogBL _surveyPointLogBL = new SurveyPointLogBL();

        int i = 0;
        int j = 0;

        private String _queryString;
        private String[] _orderType;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
            this.BackButton.ImageUrl = "/contents/images/btn_back.png";
            this.ComplaintButton.ImageUrl = "/contents/images/Complaint.png";
            this.ProceedImageButton.ImageUrl = this._imageURL + "btn_proceed_OrderConfirmation2.png";
            this.CancelImageButton.ImageUrl = this._imageURL + "btn_cancel_OrderConfirmation2.png";
            this.PreviewImageButton.ImageUrl = this._imageURL + "btnPreview2.png";
            this.PreviewWithImageButton.ImageUrl = this._imageURL + "btnPreview.png";

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteralViewResultCompany;

                this.NotePanel.Visible = false;

                this.ProceedImageButton.Attributes.Add("OnClick", "ChangePic(\"" + this.ProceedImageButton.ClientID + "\", \"" + this.CancelImageButton.ClientID + "\", \"" + this.LoadingImage.ClientID + "\" ,'" + this._imageURL + "ajax-loader.gif');");
                this.LoadingImage.Attributes.Add("style", "visibility : hidden");

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);
                this.OrderIdHiddenField.Value = this._nvcExtractor.GetValue(this._codeKey);
                this.SPidHiddenField.Value = this._nvcExtractor.GetValue(this._SPid);
                this.OrderSPIDHiddenField.Value = this._nvcExtractor.GetValue(this._orderSPID);
                this.OrderStatusHiddenField.Value = this._nvcExtractor.GetValue(this._orderVersion);
                this.SliderScriptLiteral.Text = "";
                this.InitializeData();

                this.ShowData();
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._type);
            this._orderType = _queryString.Split(',');
        }

        private void ShowData()
        {
            ResultNotMovable _resultNotMovable = new ResultNotMovable();
            //_resultNotMovable = this._resultBL.GetResultNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value), GlobalStatusMapper.GetStatus(GlobalStatus.Done));
            _resultNotMovable = this._resultBL.GetResultNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value), StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed));

            this.CompanyLiteral.Text = _resultNotMovable.SurveyPointName;
            this.BusinessFormLiteral.Text = this._businessTypeBL.GetBusinessTypeNameByBusinessTypeID(_resultNotMovable.BusinessTypeID).BusinessTypeName;
            this.CompanyAddressLiteral.Text = _resultNotMovable.Address;
            this.ClueLiteral.Text = _resultNotMovable.Clue;
            this.CompanyAgeLiteral.Text = _resultNotMovable.CompanyPeriod;
            this.PositionLiteral.Text = _resultNotMovable.Position;
            this.WorkingPeriodLiteral.Text = _resultNotMovable.WorkingPeriod;
            this.CompanyConditionLiteral.Text = _resultNotMovable.CompanyCondition;
            this.ZipCodeLiteral.Text = _resultNotMovable.ZipCode;
            this.RemarkTextBox.Text = _resultNotMovable.Remark;
            //this.LineOfBusinessLiteral.Text = _resultNotMovable.BusinessLine;
            //this.OtherInformationLiteral.Text = _resultNotMovable.Others;

            //additional photo
            List<TrResultPhotoAdditionalNotMovable> _trResultPhoto = this._resultBL.GetResultAdditionalPhotobyResultNotMovableID(_resultNotMovable.ResultNotMovableID);
            this.ListRepeater.DataSource = _trResultPhoto;
            this.ListRepeater.DataBind();
            if (_trResultPhoto.Count == 0)
            {
                this.DivAdditionalPhoto.Visible = false;
            }

            //group
            this.DocumentTypeListRepeater.DataSource = this._reqDocBL.GetListDocTypeByOrderSPIDNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));
            this.DocumentTypeListRepeater.DataBind();

            //content
            this.ContentListRepeater.DataSource = this._reqDocBL.GetListDocTypeByOrderSPIDNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));
            this.ContentListRepeater.DataBind();

            this._orderBL.GetListTrOrderSPLogByOrderIDSurveyPointType(Convert.ToInt64(this.OrderSPIDHiddenField.Value), 1);
            if (RequestVariable.RowCount > Convert.ToInt64(ConfigurationManager.AppSettings["Complaint"]))
            {
                this.ComplaintButton.Visible = false;
            }

            this._orderBL.GetListTrOrderSPLogByOrderIDSurveyPointTypeForComplaintTime(Convert.ToInt64(this.OrderSPIDHiddenField.Value), 1);

            DateTime _time = RequestVariable.Time;
            DateTime _now = DateTime.Now;

            Double _totalTime = _now.Subtract(_time).TotalMinutes;
            if (_totalTime < Convert.ToInt64(ConfigurationManager.AppSettings["TimeComplaint"]))
            {
                this.ComplaintButton.Visible = true;
            }
            else
            {
                this.ComplaintButton.Visible = false;
            }

        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TrResultPhotoAdditionalNotMovable _temp = (TrResultPhotoAdditionalNotMovable)e.Item.DataItem;

            Literal _lightBox = (Literal)e.Item.FindControl("LightBoxLiteral");
            _lightBox.Text = "<a class='example1' title='" + "ID : " + _temp.ResultPhotoAdditionalNotMovableID + ", Remark : " + _temp.Remark + "' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=AdditionalPhoto" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='max-width:" + this._imgMaxWidth + "; max-height:" + this._imgMaxHeight + ";'>";
            _lightBox.Text += "<img src=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=AdditionalPhoto" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='width:" + this._imgThumbWidth + "; height:" + this._imgThumbHeight + "; border: none;' />";
            Literal _closelightBox = (Literal)e.Item.FindControl("CloseLightBoxLiteral");
            _closelightBox.Text = "</a>";

            Literal _maps = (Literal)e.Item.FindControl("GoogleMapsLiteral");
            _maps.Text = "<a class='example2' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "GoogleTagging.ashx" + "?" + "Latitude" + "=" + _temp.Latitude + "&" + "Longitude" + "=" + _temp.Longitude + "&" + "ImageHeight=512&ImageWidth=512" + "&" + "format=jpg'" + " alt='Google Tag'>";
            _maps.Text += "<img src='../contents/images/googleMapsIcon.jpg' style='width:15px; height:15px; border: none;' />";
            Literal _closemaps = (Literal)e.Item.FindControl("CloseLightBoxLiteral");
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
            _lightBox2.Text += "<img src=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "ImageRenderer.ashx?documenttype=RequiredDocument" + "&" + "filename" + "=" + _temp.PhotoName + "&" + "foldername" + "=" + _temp.ImageGuid.ToString() + "' style='width:" + this._imgThumbWidth + "; height:" + this._imgThumbHeight + "; border: none;' />";

            Literal _closelightBox2 = (Literal)e.Item.FindControl("CloseImageDocLiteral");
            _closelightBox2.Text = "</a>";

            Literal _maps = (Literal)e.Item.FindControl("GoogleMapsLiteral2");
            _maps.Text = "<a class='example2' href=' " + ConfigurationManager.AppSettings["ImageRendererURL"].ToString() + "GoogleTagging.ashx" + "?" + "Latitude" + "=" + _temp.Latitude + "&" + "Longitude" + "=" + _temp.Longitude + "&" + "ImageHeight=512&ImageWidth=512" + "&" + "format=jpg'" + " alt='Google Tag'>";
            _maps.Text += "<img src='../contents/images/googleMapsIcon.jpg' style='width:15px; height:15px; border: none;' />";
            Literal _closemaps = (Literal)e.Item.FindControl("CloseGoogleMapsLiteral2");
            _closemaps.Text = "</a>";

            Image _remark = (Image)e.Item.FindControl("RemarkImage2");
            _remark.ImageUrl = this._imageURL + "remarkicon.jpg";
            _remark.Attributes.Add("Style", "Width: 15px");
            _remark.Attributes.Add("Style", "Height: 15px");
            _remark.ToolTip = _temp.Remark;
        }

        protected void BackButton_Click1(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._orderType[0] + "," + this._orderType[1] + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey) + "&" + this._orderVersion + "=" + this.OrderStatusHiddenField.Value);

        }

        protected void ComplaintButton_Click(object sender, ImageClickEventArgs e)
        {
            this._orderBL.GetListTrOrderSPLogByOrderIDSurveyPointTypeForComplaintTime(Convert.ToInt64(this.OrderSPIDHiddenField.Value), 1);

            DateTime _time = RequestVariable.Time;
            DateTime _now = DateTime.Now;

            Double _totalTime = _now.Subtract(_time).TotalMinutes;
            if (_totalTime < Convert.ToInt64(ConfigurationManager.AppSettings["TimeComplaint"]))
            {
                TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));
                if (_trOrderSPNotMovable.SPStatus == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed))
                {
                    this.ButtonPanel.Visible = false;
                    this.NotePanel.Visible = true;
                }
                else
                {
                    this.WarningLabel.Text = "Result not yet available";
                }
            }
            else
            {
                this.ComplaintButton.Visible = false;
                this.WarningLabel.Text = "You already don't have the right to complaint";
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ButtonPanel.Visible = true;
            this.NotePanel.Visible = false;
        }

        protected void ProceedImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this._orderBL.GetListTrOrderSPLogByOrderIDSurveyPointTypeForComplaintTime(Convert.ToInt64(this.OrderSPIDHiddenField.Value), 1);

            DateTime _time = RequestVariable.Time;
            DateTime _now = DateTime.Now;

            Double _totalTime = _now.Subtract(_time).TotalMinutes;
            if (_totalTime < Convert.ToInt64(ConfigurationManager.AppSettings["TimeComplaint"]))
            {
                TrOrderSPNotMovable _trOrderSPNotMovable = this._orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value));
                if (_trOrderSPNotMovable.SPStatus == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed))
                {
                    String _result = this._orderBL.CompalintOrderSPNotMovable(Convert.ToInt64(this.OrderSPIDHiddenField.Value), HttpContext.Current.User.Identity.Name, this.NoteComplaintTextBox.Text);

                    if (_result == "")
                    {
                        TrWorkOrderNotMovable _woSpNotMovable = this._woBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_trOrderSPNotMovable.OrderSPNotMovableID);
                        _woSpNotMovable.WorkOrderStatusID = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Complaint);
                        this._woBL.UpdateWorkOrderNotMovable(_woSpNotMovable);
                        this.InitializeData();
                        Response.Redirect(this._viewOrderPage + "?" + this._type + "=" + this._orderType[0] + "," + this._orderType[1] + "&" + this._codeKey + "=" + this._nvcExtractor.GetValue(this._codeKey) + "&" + this._orderVersion + "=" + this.OrderStatusHiddenField.Value);
                    }
                    else
                    {
                        this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                    }
                }
            }
            else
            {
                this.WarningLabel.Text = "You already don't have the right to complaint";
            }
        }

        protected void PreviewImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;

            string _path = "/SurveyorSystem/ReportResultWONotMovCP";   

            TrWorkOrderNotMovable _trWorkOrderNotMovable = this._woBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            ReportParameter[] _reportParam = new ReportParameter[1];
            _reportParam[0] = new ReportParameter("WorkOrderNotMovableID", _trWorkOrderNotMovable.WorkOrderNotMovableID.ToString(), false);
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

        protected void PreviewWithImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;

            string _path = "/SurveyorSystem/ReportResultWONotMovWithImageCP";
            string _url = ConfigurationManager.AppSettings["ImageRendererURLForReport"];

            TrWorkOrderNotMovable _trWorkOrderNotMovable = this._woBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(Convert.ToInt64(this.OrderSPIDHiddenField.Value));

            ReportParameter[] _reportParam = new ReportParameter[2];
            _reportParam[0] = new ReportParameter("WorkOrderNotMovableID", _trWorkOrderNotMovable.WorkOrderNotMovableID.ToString(), false);
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



