using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteAppBase;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using GSI.Common.Enum;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Net;


namespace GSIWebsiteCore.Report
{
    public partial class ReportGSI : ReportBase
    {
        SurveyorBL _surveyorBL = new SurveyorBL();
        EmployeeBL _employeeBL = new EmployeeBL();
        ReportBL _reportBL = new ReportBL();
        CustomerBL _custBL = new CustomerBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                DateTime _now = DateTime.Now;
                int _year = _now.Year;

                for (int i = 0; i <= 15; i++)
                {
                    this.YearDDL.Items.Add(new ListItem(_year.ToString()));
                    _year = --_year;
                }

                this.PageTitleLiteral.Text = this._pageTitleListLiteral;
                //PointSurveyMapper.GetPointSurveyName(Convert.ToInt32(this._nvcExtractor.GetValue(this._SPid)));

                this.SaveGuarantorRespondent.ImageUrl = this._imageURL + "PreviewReport.png";

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

                this.ClearData();
                this.ClearLabel();
                this.SetAttribute();
                this.ShowReportDDL();
                this.Showfilter();
                this.Panel2.Visible = false;
            }
        }

        protected void SetAttribute()
        {
            this.Date.Attributes.Add("Style", "display: none;");
            this.Cust.Attributes.Add("Style", "display: none;");
            this.OrNo.Attributes.Add("Style", "display: none;");
            this.SPName.Attributes.Add("Style", "display: none;");
            this.Status.Attributes.Add("Style", "display: none;");
            this.Dispatcher.Attributes.Add("Style", "display: none;");
            this.Surveyor.Attributes.Add("Style", "display: none;");
            this.Period.Attributes.Add("Style", "display: none;");
            this.CustDDL.Attributes.Add("Style", "display: none;");
            this.Year.Attributes.Add("Style", "display: none;");
            this.Month.Attributes.Add("Style", "display: none;");
        }

        protected void ClearLabel()
        {
            this.WarningLabel.Text = "";
        }

        private void ClearData()
        {
            DateTime _now = DateTime.Now;

            this.DateFromTextBox.Text = DateFormMapper.GetValue(_now);
            this.DateToTextBox.Text = DateFormMapper.GetValue(_now);
            this.DateFromTextBox.Attributes.Add("ReadOnly", "true");
            this.DateToTextBox.Attributes.Add("ReadOnly", "true");
            this.CustomerTextBox.Text = "";
            //this.CustomerToTextBox.Text = "";
            this.OrderNoFromTextBox.Text = "";
            this.OrderNoToTextBox.Text = "";
            this.SurveyPointNameTextBox.Text = "";
            //foreach (ListItem _cBox in this.DocumentTypeCheckBoxList.Items)
            //{
            //    _cBox.Selected = false;
            //}
        }

        protected void ShowReportDDL()
        {
            List<String> _IDTypes = ReportMapper.ReportList;
            this.ReportDDL.Items.Clear();
            foreach (var _IDType in _IDTypes)
            {
                String[] _row = _IDType.Split('|');
                this.ReportDDL.Items.Add(new ListItem(_row[1], _row[0]));
            }
        }

        protected void ShowDispatcher()
        {
            this.DispatcherDDL.Items.Clear();
            this.DispatcherDDL.DataSource = this._employeeBL.GetListMsEmployeeForDispatcherDDL();
            this.DispatcherDDL.DataValueField = "EmployeeID";
            this.DispatcherDDL.DataTextField = "EmployeeLogOn";
            this.DispatcherDDL.DataBind();
        }

        protected void ShowCustomer()
        {
            this.CustomerDDL.Items.Clear();
            this.CustomerDDL.DataSource = this._custBL.GetListFromMsCustomerForDDL();
            this.CustomerDDL.DataValueField = "CustomerID";
            this.CustomerDDL.DataTextField = "CustomerName";
            this.CustomerDDL.DataBind();
        }

        protected void ShowSurveyor()
        {
            this.SurveyorDDL.Items.Clear();
            this.SurveyorDDL.DataSource = this._surveyorBL.GetListSurveyorForDDL();
            this.SurveyorDDL.DataValueField = "EmployeeID";
            this.SurveyorDDL.DataTextField = "EmployeeName";
            this.SurveyorDDL.DataBind();
        }

        protected void Showfilter()
        {
            String _filterAttr = ReportMapper.GetFilterAttr(this.ReportDDL.SelectedValue);
            String[] _attrArr = _filterAttr.Split(',');

            for (int i = 0; i < _attrArr.Length; i++)
            {
                if (_attrArr[i].Trim().Trim() == "Date")
                {
                    this.Date.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "Cust")
                {
                    this.Cust.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "OrNo")
                {
                    this.OrNo.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "SPName")
                {
                    this.SPName.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "Status")
                {
                    this.Status.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "Dispatcher")
                {
                    this.Dispatcher.Attributes.Remove("Style");
                    this.ShowDispatcher();
                }
                else if (_attrArr[i].Trim() == "Surveyor")
                {
                    this.Surveyor.Attributes.Remove("Style");
                    this.ShowSurveyor();
                }
                else if (_attrArr[i].Trim() == "Period")
                {
                    this.Period.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "CustDDL")
                {
                    this.CustDDL.Attributes.Remove("Style");
                    this.ShowCustomer();
                }
                else if (_attrArr[i].Trim() == "Year")
                {
                    this.Year.Attributes.Remove("Style");
                }
                else if (_attrArr[i].Trim() == "Month")
                {
                    this.Month.Attributes.Remove("Style");
                }

            }
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

        protected void SaveGuarantorRespondent_Click(object sender, ImageClickEventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;

            while (this.ReportViewer1.ServerReport.IsDrillthroughReport)
            {
                this.ReportViewer1.PerformBack();
            }

            if (ReportDDL.SelectedValue == "1")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[3];
                _reportParam[0] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[1] = new ReportParameter("EndPeriod", _end2, false);
                _reportParam[2] = new ReportParameter("CustomerName", this.CustomerTextBox.Text, false);
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

            else if (ReportDDL.SelectedValue == "2")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[3];
                _reportParam[0] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[1] = new ReportParameter("EndPeriod", _end2, false);
                _reportParam[2] = new ReportParameter("CustomerName", this.CustomerTextBox.Text, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "3")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                this.ReportViewer1.Reset();

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[7];
                _reportParam[0] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[1] = new ReportParameter("EndPeriod", _end2, false);
                _reportParam[2] = new ReportParameter("CustomerName", this.CustomerTextBox.Text, false);
                _reportParam[3] = new ReportParameter("OrderCodeFrom", this.OrderNoFromTextBox.Text, false);
                _reportParam[4] = new ReportParameter("OrderCodeTo", this.OrderNoToTextBox.Text, false);
                _reportParam[5] = new ReportParameter("SurveyPointName", this.SurveyPointNameTextBox.Text, false);
                _reportParam[6] = new ReportParameter("Status", this.StatusDDL.SelectedValue, false);

                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ShowParameterPrompts = false;
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "4")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[3];
                _reportParam[0] = new ReportParameter("EmployeeID", this.DispatcherDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[2] = new ReportParameter("EndPeriod", _end2, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "5")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[3];
                _reportParam[0] = new ReportParameter("EmployeeID", this.SurveyorDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[2] = new ReportParameter("EndPeriod", _end2, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "6")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                DateTime _start = DateFormMapper.GetValue(this.DateFromTextBox.Text);
                //String _start2 = _start.Month + "/" + _start.Day + "/" + _start.Year;
                String _start2 = _start.Date.ToString();
                DateTime _end = DateFormMapper.GetValue(this.DateToTextBox.Text);
                //String _end2 = _end.Month + "/" + _end.Day + "/" + _end.Year;
                String _end2 = _end.Date.ToString();

                ReportParameter[] _reportParam = new ReportParameter[4];
                _reportParam[0] = new ReportParameter("StartPeriod", _start2, false);
                _reportParam[1] = new ReportParameter("EndPeriod", _end2, false);
                _reportParam[2] = new ReportParameter("OrderCodeFrom", this.OrderNoFromTextBox.Text, false);
                _reportParam[3] = new ReportParameter("OrderCodeTo", this.OrderNoToTextBox.Text, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "7")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);               

                ReportParameter[] _reportParam = new ReportParameter[2];
                _reportParam[0] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("MonthPeriod", this.MonthDropDownList.SelectedValue, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "8")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);                

                ReportParameter[] _reportParam = new ReportParameter[4];
                _reportParam[0] = new ReportParameter("EmployeeID", this.SurveyorDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[2] = new ReportParameter("StartPeriod", this.PeriodFromDDL.SelectedValue, false);
                _reportParam[3] = new ReportParameter("EndPeriod", this.PeriodToDDL.SelectedValue, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "9")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);
                               

                ReportParameter[] _reportParam = new ReportParameter[4];
                _reportParam[0] = new ReportParameter("CustomerID", this.CustomerDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[2] = new ReportParameter("StartPeriod", this.PeriodFromDDL.SelectedValue, false);
                _reportParam[3] = new ReportParameter("EndPeriod", this.PeriodToDDL.SelectedValue, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "10")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                ReportParameter[] _reportParam = new ReportParameter[2];
                _reportParam[0] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("MonthPeriod", this.MonthDropDownList.SelectedValue, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "11")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);
                
                ReportParameter[] _reportParam = new ReportParameter[4];
                _reportParam[0] = new ReportParameter("CustomerID", this.CustomerDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[2] = new ReportParameter("StartPeriod", this.PeriodFromDDL.SelectedValue, false);
                _reportParam[3] = new ReportParameter("EndPeriod", this.PeriodToDDL.SelectedValue, false);
                this.ReportViewer1.Reset();
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ServerReport.Refresh();
            }

            else if (ReportDDL.SelectedValue == "12")
            {
                string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

                this.ReportViewer1.Reset();

                ReportParameter[] _reportParam = new ReportParameter[2];
                _reportParam[0] = new ReportParameter("YearPeriod", this.YearDDL.SelectedValue, false);
                _reportParam[1] = new ReportParameter("MonthPeriod", this.MonthDropDownList.SelectedValue, false);
                
                this.ReportViewer1.ShowCredentialPrompts = false;
                ServerReport _serverReport = ReportViewer1.ServerReport;
                this.ReportViewer1.ServerReport.ReportServerCredentials = new ReportCredentials(ConfigurationManager.AppSettings["UserNameReport"], ConfigurationManager.AppSettings["PasswordReport"], ConfigurationManager.AppSettings["DomainReport"]);
                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                _serverReport.ReportServerUrl = new System.Uri(ConfigurationManager.AppSettings["UrlReport"]);
                this.ReportViewer1.ServerReport.ReportPath = _path;

                this.ReportViewer1.ServerReport.SetParameters(_reportParam);
                this.ReportViewer1.ShowParameterPrompts = false;
                this.ReportViewer1.ServerReport.Refresh();
            }
        }

        protected void ReportDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetAttribute();
            this.Showfilter();
        }


    }
}