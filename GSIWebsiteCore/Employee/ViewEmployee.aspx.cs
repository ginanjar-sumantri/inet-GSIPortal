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

namespace GSIWebsiteCore.Employee
{
    public partial class ViewEmployee : EmployeeBase
    {
        private EmployeeBL _employeeBL = new EmployeeBL();
        private GadgetBL _gadGetBL = new GadgetBL();
        private String _queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropImageButton.Attributes.Add("OnClick", "return Drop();");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleEditLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;
                this.SetAttribute();
                this.ShowIDTypeDDL();
                this.ShowGadgetDDL();
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._employeeID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void SetAttribute()
        {
            this.CodeEmployeeTextBox.Attributes.Add("ReadOnly", "True");
            this.CodeEmployeeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
            this.DateOfBirthTextBox.Attributes.Add("ReadOnly", "True");
            this.HandPhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.HandPhoneTextBox.ClientID + "," + this.HandPhoneTextBox.ClientID + ",500" + ")");
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._employeeID);
        }

        private void ShowData()
        {
            MsEmployee _msEmployee = this._employeeBL.GetSingleEmployee(Convert.ToInt64(this._nvcExtractor.GetValue(this._employeeID)));

            this.CodeEmployeeTextBox.Text = _msEmployee.EmployeeCode;
            this.FullNameTextBox.Text = _msEmployee.EmployeeName;
            this.GenderRadioButtonList.SelectedValue = _msEmployee.Gender;
            this.PlaceOfBirthTextBox.Text = _msEmployee.BirthPlace;
            this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(_msEmployee.BirthDate);
            this.NationalityRadioButtonList.SelectedValue = _msEmployee.Nationality;
            this.IDDropDownList.SelectedValue = _msEmployee.TypeID.ToString();
            this.IDNoTextBox.Text = _msEmployee.NoID;
            this.EmployeeAddressTextBox.Text = _msEmployee.EmployeeAddress1;
            this.EmployeeAddress2TextBox.Text = _msEmployee.EmployeeAddress2;
            this.HandPhoneTextBox.Text = _msEmployee.HandPhone1;
            this.GadgetDropDownList.SelectedValue = _msEmployee.GadgetID.ToString();
            this.EmailTextBox.Text = _msEmployee.Email;
            this.NoteTextBox.Text = _msEmployee.Remark;
            if (_msEmployee.FgActive == "Y")
            {
                this.FgActiveCheckBox.Checked = true;
            }
            this.EmployeeLogOnTextBox.Text = _msEmployee.EmployeeLogOn;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msEmployee.EmployeeID.ToString();
        }

        protected void ShowIDTypeDDL()
        {
            List<String> _IDTypes = IDTypeMapper.IDTypes;
            this.IDDropDownList.Items.Clear();
            foreach (var _IDType in _IDTypes)
            {
                String[] _row = _IDType.Split(',');
                this.IDDropDownList.Items.Add(new ListItem(_row[1], _row[0]));
            }
        }

        protected void ShowGadgetDDL()
        {
            this.GadgetDropDownList.Items.Clear();
            this.GadgetDropDownList.DataValueField = "GadgetID";
            this.GadgetDropDownList.DataTextField = "GadgetName";
            this.GadgetDropDownList.DataSource = this._gadGetBL.GetListGadget(10000, 0, "", "");
            this.GadgetDropDownList.DataBind();
            this.GadgetDropDownList.Items.Insert(0, new ListItem("[None]", "null"));
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listEmployeePage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {            
            int _result = 0;

            MsEmployee _msEmployee = new MsEmployee();
            _msEmployee.EmployeeID = Convert.ToInt64(this._nvcExtractor.GetValue(this._employeeID));
            _msEmployee.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msEmployee.RowStatus = 1;

            _result = this._employeeBL.DeletedEmployee(_msEmployee);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listEmployeePage);
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
            Boolean _result = false;

            MsEmployee _msEmployee = this._employeeBL.GetSingleEmployee(Convert.ToInt64(this._nvcExtractor.GetValue(this._employeeID)));

            _msEmployee.EmployeeName = this.FullNameTextBox.Text;
            _msEmployee.Gender = this.GenderRadioButtonList.SelectedValue;
            _msEmployee.BirthPlace = this.PlaceOfBirthTextBox.Text;
            _msEmployee.BirthDate = DateFormMapper.GetValue(this.DateOfBirthTextBox.Text);
            _msEmployee.Nationality = this.NationalityRadioButtonList.SelectedValue;
            _msEmployee.TypeID = Convert.ToString(this.IDDropDownList.SelectedValue);
            _msEmployee.NoID = this.IDNoTextBox.Text;
            _msEmployee.EmployeeAddress1 = this.EmployeeAddressTextBox.Text;
            _msEmployee.EmployeeAddress2 = this.EmployeeAddress2TextBox.Text;
            _msEmployee.HandPhone1 = this.HandPhoneTextBox.Text;
            if (this.GadgetDropDownList.SelectedValue != "null")
            {
                _msEmployee.GadgetID = Convert.ToInt64(this.GadgetDropDownList.SelectedValue);
            }
            else
            {
                _msEmployee.GadgetID = (Int64?)null;
            }
            _msEmployee.Email = this.EmailTextBox.Text;

            if (this.FgActiveCheckBox.Checked == true)
            {
                _msEmployee.FgActive = "Y";
            }
            else
            {
                _msEmployee.FgActive = "N";
            }

            _msEmployee.Remark = this.NoteTextBox.Text;
            _msEmployee.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msEmployee.ModifiedDate = DateTime.Now;
            _msEmployee.EmployeeLogOn = this.EmployeeLogOnTextBox.Text;

            _result = this._employeeBL.UpdateMsEmployee(_msEmployee);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listEmployeePage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Edit Data";
            }

        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ShowData();
        }
    }
}
