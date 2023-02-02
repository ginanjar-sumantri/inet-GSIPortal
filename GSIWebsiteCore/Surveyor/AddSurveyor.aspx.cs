using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;
using GSI.BusinessRule;

namespace GSIWebsiteCore.Surveyor
{
    public partial class AddSurveyor : SurveyorBase
    {
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private EmployeeBL _msEmployeeBL = new EmployeeBL();
        private RegionBL _msRegionBL = new RegionBL();
        private RegionZipCodeBL _msZipCodeBL = new RegionZipCodeBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;

                this.ShowRegionDDL();
                this.ShowZipCodeDDL();
                this.EmployeeID();
                this.Notice();
                this.ClearData();
            }
        }

        private void ClearData()
        {
            //this.EmployeeIDTextBox.Text = "";
            this.SurveyorCodeTextBox.Text = "";
            this.RemarkTextBox.Text = "";
        }

        protected void ShowRegionDDL()
        {
            this.RegionIDDropDownList.Items.Clear();
            this.RegionIDDropDownList.DataSource = this._msRegionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionIDDropDownList.DataValueField = "RegionID";
            this.RegionIDDropDownList.DataTextField = "RegionName";
            this.RegionIDDropDownList.DataBind();
        }

        protected void ShowZipCodeDDL()
        {
            this.ZipCodeCheckBoxList.Items.Clear();
            this.ZipCodeCheckBoxList.DataSource = this._msZipCodeBL.GetListZipCodeDDLByRegionID(Convert.ToInt64(this.RegionIDDropDownList.SelectedValue));
            this.ZipCodeCheckBoxList.DataValueField = "ZipCode";
            this.ZipCodeCheckBoxList.DataTextField = "ZipCode";
            this.ZipCodeCheckBoxList.DataBind();
        }

        protected void EmployeeID()
        {
            this.EmployeeIDDropDownList.Items.Clear();
            List<MsEmployee> _msEmployee = this._msEmployeeBL.GetListEmployeeNotInMsSurveyor();
            this.EmployeeIDDropDownList.DataSource = _msEmployee;
            this.EmployeeIDDropDownList.DataValueField = "EmployeeID";
            this.EmployeeIDDropDownList.DataTextField = "EmployeeName";
            this.EmployeeIDDropDownList.DataBind();
            this.EmployeeIDDropDownList.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        private void Notice()
        {
            this.WarningLabel.Text = "";
            String _messageNotice = "";
            if (this.EmployeeIDDropDownList.Items.Count == 1)
            {
                _messageNotice = "Employee data";
            }
            if (this.RegionIDDropDownList.Items.Count == 1)
            {
                if (_messageNotice != "")
                {
                    _messageNotice = _messageNotice + " and ";
                }
                _messageNotice = _messageNotice + "Region data";
            }
            if (this.ZipCodeCheckBoxList.Items.Count == 0)
            {
                if (_messageNotice != "")
                {
                    _messageNotice = _messageNotice + " and ";
                }
                _messageNotice = _messageNotice + "Zip Code data";
            }

            if (_messageNotice != "")
            {
                this.WarningLabel.Text = "Please fill in " + _messageNotice + ", before performing Surveyor data storage ";
            }
        }

        private Boolean ZipCodeAnyIsChecked()
        {
            foreach (var _item in this.ZipCodeCheckBoxList.Items)
            {
                if (((ListItem)_item).Selected)
                {
                    return true;
                }
            }
            return false;
        }

        private String GetSelectedZipCode()
        {
            String _result = "";

            foreach (var _item in this.ZipCodeCheckBoxList.Items)
            {
                ListItem _chk = (ListItem)_item;
                if (_chk.Selected)
                {
                    if (_result == "")
                        _result = _chk.Text;
                    else
                        _result += "," + _chk.Text;
                }
            }

            return _result;
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Notice();
            if (this.WarningLabel.Text == "")
            {
                if (this.ZipCodeAnyIsChecked())
                {
                    MsSurveyor _msSurveyor = new MsSurveyor();

                    _msSurveyor.EmployeeID = Convert.ToInt64(this.EmployeeIDDropDownList.Text);
                    _msSurveyor.SurveyorCode = this.SurveyorCodeTextBox.Text;
                    _msSurveyor.RegionID = Convert.ToInt64(this.RegionIDDropDownList.Text);
                    _msSurveyor.Remark = this.RemarkTextBox.Text;

                    _msSurveyor.RowStatus = 0;
                    _msSurveyor.CreatedBy = Request.ServerVariables["LOGON_USER"];
                    _msSurveyor.RegionID = Convert.ToInt64(this.RegionIDDropDownList.SelectedValue);
                    
                    //int _success = this._surveyorBL.InsertMsSurveyor(_msSurveyor);
                    int _success = this._surveyorBL.InsertMsSurveyorAndZipCodes(_msSurveyor, this.GetSelectedZipCode());

                    if (_success == -1)
                    {
                        //this.WarningLabel.Text = "You Success update";
                        Response.Redirect(this._listSurveyorPage);
                    }
                    else
                    {
                        this.WarningLabel.Text = "You Failed Add Data" + ((ErrorHandler.ErrorMessage == "") ? "" : ", " + ErrorHandler.ErrorMessage);
                    }
                }
                else
                {
                    this.WarningLabel.Text = "Please tick at least one Zip Code";
                }
            }
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listSurveyorPage);
        }

        protected void RegionIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WarningLabel.Text = "";
            this.ShowZipCodeDDL();
        }
    }
}




