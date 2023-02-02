using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.Common.Enum;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;

namespace GSIWebsiteCore.Employee
{
    public partial class AddEmployee : EmployeeBase
    {
        private EmployeeBL _employeeBL = new EmployeeBL();
        private GadgetBL _gadGetBL = new GadgetBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.SetAttribute();
                this.ShowIDTypeDDL();
                this.ShowGadgetDDL();
                this.ClearData();
            }
        }

        private void SetAttribute()
        {
            this.DateOfBirthTextBox.Attributes.Add("ReadOnly", "True");
            this.HandPhoneTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.HandPhoneTextBox.ClientID + "," + this.HandPhoneTextBox.ClientID + ",500" + ")");
            this.IDNoTextBox.Attributes.Add("OnKeyUp", "return formatangka2(" + this.IDNoTextBox.ClientID + "," + this.IDNoTextBox.ClientID + ",500" + ")");
        }

        private void ClearData()
        {
            this.EmployeeCodeTextBox.Text = "";
            this.FullNameTextBox.Text = "";
            this.GenderRadioButtonList.SelectedValue = "Male";
            this.PlaceOfBirthTextBox.Text = "";
            this.DateOfBirthTextBox.Text = DateFormMapper.GetValue(DateTime.Now);
            this.NationalityRadioButtonList.SelectedValue = "";
            this.IDDropDownList.SelectedValue = "1";
            this.IDNoTextBox.Text = "";
            this.EmployeeIDAddressTextBox.Text = "";
            this.EmployeeCurrentAddressTextBox.Text = "";
            this.HandPhoneTextBox.Text = "";
            this.EmailTextBox.Text = "";
            this.NoteTextBox.Text = "";
            this.EmployeeCodeTextBox.Text = "";
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

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsEmployee _msEmployee = new MsEmployee();

            _msEmployee.EmployeeCode = this.EmployeeCodeTextBox.Text;
            _msEmployee.EmployeeName = this.FullNameTextBox.Text;
            _msEmployee.Gender = this.GenderRadioButtonList.SelectedValue;
            _msEmployee.BirthPlace = this.PlaceOfBirthTextBox.Text;
            _msEmployee.BirthDate = DateFormMapper.GetValue(this.DateOfBirthTextBox.Text);
            _msEmployee.Nationality = this.NationalityRadioButtonList.SelectedValue;
            _msEmployee.TypeID = Convert.ToString(this.IDDropDownList.SelectedValue);
            _msEmployee.NoID = this.IDNoTextBox.Text;
            _msEmployee.EmployeeAddress1 = this.EmployeeIDAddressTextBox.Text;
            _msEmployee.EmployeeAddress2 = this.EmployeeCurrentAddressTextBox.Text;
            _msEmployee.HandPhone1 = this.HandPhoneTextBox.Text;
            if (this.GadgetDropDownList.SelectedValue != "null")
            {
                _msEmployee.GadgetID = Convert.ToInt64(this.GadgetDropDownList.SelectedValue);
            }
            _msEmployee.Email = this.EmailTextBox.Text;
            _msEmployee.FgActive = "Y";
            _msEmployee.Remark = this.NoteTextBox.Text;
            _msEmployee.CreatedBy = Request.ServerVariables["LOGON_USER"];
            _msEmployee.EmployeeLogOn = this.EmployeeLogOnTextBox.Text;

            int _success = this._employeeBL.InsertMsEmployee(_msEmployee);

            if (_success == -1)
            {
                Response.Redirect(this._listEmployeePage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listEmployeePage);
        }

        protected void IDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> _IDTypes = IDTypeMapper.IDTypes;
            foreach (var _IDType in _IDTypes)
            {
                String[] _row = _IDType.Split(',');
                if (_row[0] == this.IDDropDownList.SelectedValue)
                {
                    if (_row[2] == IDTypeMapper.GetIDFormat(FormatTextBox.AllowDot))
                    {
                        this.IDNoTextBox.Attributes.Add("OnKeyUp", "return formatangka2(" + this.IDNoTextBox.ClientID + "," + this.IDNoTextBox.ClientID + ",500" + ")");
                    }
                    else if (_row[2] == IDTypeMapper.GetIDFormat(FormatTextBox.AllowAlphabet))
                    {
                        this.IDNoTextBox.Attributes.Remove("OnKeyUp");
                    }
                }
            }
        }
    }
}
