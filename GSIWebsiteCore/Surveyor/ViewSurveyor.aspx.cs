using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;

namespace GSIWebsiteCore.Surveyor
{
    public partial class ViewSurveyor : SurveyorBase
    {
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private RegionBL _regionBL = new RegionBL();
        private EmployeeBL _msEmployeeBL = new EmployeeBL();
        private RegionZipCodeBL _msZipCodeBL = new RegionZipCodeBL();
        private String _queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropImageButton.Attributes.Add("OnClick", "return Drop();");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;
                this.SurveyorCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.SurveyorCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ShowRegionDDL();
                this.ShowZipCodeDDL();
                this.EmployeeID();
                if ((this._nvcExtractor.GetValue(this._surveyorID) != ""))
                {
                    this.ShowData();
                    this.ShowZipCodeDDL();
                    this.SetZipCodeCheckBox(Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID)));
                }
            }
        }


        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._surveyorID);
        }

        private void ShowData()
        {
            MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID)));

            this.EmployeeIDDropDownList.SelectedValue = _msSurveyor.EmployeeID.ToString();
            this.RegionIDDropDownList.SelectedValue = _msSurveyor.RegionID.ToString();
            this.RemarkTextBox.Text = _msSurveyor.Remark;
            this.SurveyorCodeTextBox.Text = _msSurveyor.SurveyorCode;

            this.SetZipCodeCheckBox(_msSurveyor.SurveyorID);

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msSurveyor.SurveyorID.ToString();
        }

        private void SetZipCodeCheckBox(Int64 _prmSurveyorID)
        {
            List<MsSurveyorZipCode> _listZipCode = this._surveyorBL.GetListSurveyorZipCodeForDDLBySurveyorID(_prmSurveyorID);
            foreach (var _item in _listZipCode)
            {
                ListItem _chk = this.ZipCodeCheckBoxList.Items.FindByValue(_item.ZipCode);
                if (_chk != null)
                {
                    _chk.Selected = true;
                }
            }
        }

        protected void ShowRegionDDL()
        {
            this.RegionIDDropDownList.Items.Clear();
            this.RegionIDDropDownList.DataSource = this._regionBL.GetListRegionForDDL(10000, 0, "RegionName", "");
            this.RegionIDDropDownList.DataValueField = "RegionID";
            this.RegionIDDropDownList.DataTextField = "RegionName";
            this.RegionIDDropDownList.DataBind();
            //this.RegionDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void ShowZipCodeDDL()
        {
            this.ZipCodeCheckBoxList.Items.Clear();
            this.ZipCodeCheckBoxList.DataSource = this._msZipCodeBL.GetListZipCodeDDLByRegionID(Convert.ToInt64(this.RegionIDDropDownList.SelectedValue));
            this.ZipCodeCheckBoxList.DataValueField = "ZipCode";
            this.ZipCodeCheckBoxList.DataTextField = "ZipCode";
            this.ZipCodeCheckBoxList.DataBind();
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

        protected void EmployeeID()
        {
            MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID)));

            this.EmployeeIDDropDownList.Items.Clear();
            this.EmployeeIDDropDownList.DataSource = this._msEmployeeBL.GetSingleEmployeeForDDL(_msSurveyor.EmployeeID);
            this.EmployeeIDDropDownList.DataValueField = "EmployeeID";
            this.EmployeeIDDropDownList.DataTextField = "EmployeeName";
            this.EmployeeIDDropDownList.DataBind();
            //this.EmployeeDropDownList.Items.Insert(0, new ListItem("[Choose One]", "null"));
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._listSurveyorPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsSurveyor _msSurveyor = new MsSurveyor();
            _msSurveyor.SurveyorID = Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID));
            _msSurveyor.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msSurveyor.RowStatus = 1;

            //_result = this._surveyorBL.DeletedSurveyor(_msSurveyor);
            _result = this._surveyorBL.DeleteSurveyorAndZipCode(_msSurveyor);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listSurveyorPage);
            }
            else
            {
                //this.WarningLabel.Text = "You Failed Delete Data";
                this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                ErrorHandler.ErrorMessage = "";
            }

        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (this.SurveyorCodeTextBox.Text == "" || this.EmployeeIDDropDownList.SelectedValue == "" || this.RegionIDDropDownList.SelectedValue == "")
            {
                this.WarningLabel.Text = "Form value not valid, Please review your input again";
            }
            else
            {
                this.EditSurveyor();
            }
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData();
        }

        protected void EditSurveyor()
        {
            Boolean _result = false;

            MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID)));

            _msSurveyor.SurveyorCode = this.SurveyorCodeTextBox.Text;
            _msSurveyor.RegionID = Convert.ToInt64(this.RegionIDDropDownList.SelectedValue);
            _msSurveyor.EmployeeID = Convert.ToInt64(this.EmployeeIDDropDownList.SelectedValue);
            _msSurveyor.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msSurveyor.Remark = this.RemarkTextBox.Text;

            //_result = this._surveyorBL.UpdateMsSurveyor(_msSurveyor);
            _result = this._surveyorBL.UpdateMsSurveyorAndZipCode(_msSurveyor, this.GetSelectedZipCode());

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listSurveyorPage);
            }
            else
            {
                this.WarningLabel.Text = ErrorHandler.ErrorMessage;
            }
        }

        protected void RegionIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WarningLabel.Text = "";
            this.ShowZipCodeDDL();
            this.SetZipCodeCheckBox(Convert.ToInt64(this._nvcExtractor.GetValue(this._surveyorID)));
        }
    }
}

