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

namespace GSIWebsiteCore.Report
{
    public partial class Report : ReportBase
    {
        SurveyorBL _surveyorBL = new SurveyorBL();
        EmployeeBL _employeeBL = new EmployeeBL();
        ReportBL _reportBL = new ReportBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleListLiteral;
                //PointSurveyMapper.GetPointSurveyName(Convert.ToInt32(this._nvcExtractor.GetValue(this._SPid)));

                this.SaveGuarantorRespondent.ImageUrl = this._imageURL + "btnSave2.png";                

                this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

                this.ClearData();
                this.ClearLabel();
                this.SetAttribute();
                this.ShowReportDDL();
                this.Showfilter();    
                
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
            this.DateToTextBox.Attributes.Add("ReadOnly","true");
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

        protected void ShowSurveyor()
        {
            this.SurveyorDDL.Items.Clear();
            this.SurveyorDDL.DataSource = this._surveyorBL.GetListSurveyorForDDL();
            this.SurveyorDDL.DataValueField = "SurveyorID";
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
                }
                
            }
        }

        protected void SaveGuarantorRespondent_Click(object sender, ImageClickEventArgs e)
        {
            //this.Panel1.Visible = false;
            //this.Panel2.Visible = true;

            //if (ReportDDL.SelectedValue == "1")
            //{
            //    //ReportDataSource _reportDataSource1 = this._reportBL.ReportDetailCustomerTransaction(this.DateFromTextBox.Text, this.DateToTextBox.Text, this.CustomerTextBox.Text);

            //    this.ReportViewer1.LocalReport.DataSources.Clear();
            //    this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource1);

            //    string _path = ReportMapper.GetReportPath(ReportDDL.SelectedValue);

            //    this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _path;

            //    this.ReportViewer1.DataBind();

            //    ReportParameter[] _reportParam = new ReportParameter[3];
            //    _reportParam[0] = new ReportParameter("StartPeriod", "12/12/2011", true);
            //    _reportParam[1] = new ReportParameter("EndPeriod", "12/15/2011", true);
            //    _reportParam[2] = new ReportParameter("CustomerName", this.CustomerTextBox.Text, true);
                
                
            //    this.ReportViewer1.LocalReport.SetParameters(_reportParam);
            //    this.ReportViewer1.LocalReport.Refresh();
            //}

            //ReportDataSource _reportDataSource1 = this._workOrderBL.PrintPreview("OrderMovable", Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));

            //this.ReportViewer1.LocalReport.DataSources.Clear();
            //this.ReportViewer1.LocalReport.DataSources.Add(_reportDataSource1);

            //string _path = "WorkOrder/ReportResultWOMov.rdlc";

            //this.ReportViewer1.LocalReport.ReportPath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + _path;

            //this.ReportViewer1.DataBind();

            //ReportParameter[] _reportParam = new ReportParameter[1];
            //_reportParam[0] = new ReportParameter("workOrderMovableID", Convert.ToString(this._nvcExtractor.GetValue(this._codeKey).Trim()), false);
            //this.ReportViewer1.LocalReport.SetParameters(_reportParam);
            //this.ReportViewer1.LocalReport.Refresh();
        }

        protected void ReportDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetAttribute();
            this.Showfilter();
        }

        
    }
}
