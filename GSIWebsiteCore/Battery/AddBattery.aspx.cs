using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using System.Collections.Generic;
using GSI.DataMapping;

namespace GSIWebsiteCore.Battery
{
    public partial class AddBattery : BatteryBase
    {
        private BatteryBL _batteryBL = new BatteryBL();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleAddLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.ResetImageButton.ImageUrl = this._imageURL + "btnReset.png";
                this.ResetImageButton.ToolTip = this._toolTipCancel;
                this.AmpereTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.AmpereTextBox.ClientID + "," + this.AmpereTextBox.ClientID + ",500" + ")");
                this.ShowBatteryTypeDDL();
                this.ClearData();
            }
        }

        protected void ShowBatteryTypeDDL()
        {
            List<String> _batteryTypes = BatteryTypeMapper.BatteryTypes;
            this.BatteryTypeDropDownList.Items.Clear();
            foreach (var _batteryType in _batteryTypes)
            {
                String[] _row = _batteryType.Split(',');
                this.BatteryTypeDropDownList.Items.Add(new ListItem(_row[1], _row[0]));
            }
        }

        private void ClearData()
        {
            this.BatteryCodeTextBox.Text = "";
            this.BatteryNameTextBox.Text = "";
            this.BatteryTypeDropDownList.SelectedValue = "1";
            this.AmpereTextBox.Text = "0";
            this.SerialNumberTextBox.Text = "";
            this.NoteTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listBatteryPage);
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsBattery _msBattery = new MsBattery();

            _msBattery.BatteryCode = this.BatteryCodeTextBox.Text;
            _msBattery.BatteryName = this.BatteryNameTextBox.Text;
            _msBattery.BatteryType = Convert.ToByte(this.BatteryTypeDropDownList.SelectedValue);
            _msBattery.Ampere = Convert.ToInt32(this.AmpereTextBox.Text);
            _msBattery.SerialNumber = this.SerialNumberTextBox.Text;
            _msBattery.Remark = this.NoteTextBox.Text;
            _msBattery.RowStatus = 0;
            _msBattery.CreatedBy = Request.ServerVariables["LOGON_USER"];

            int _success = this._batteryBL.InsertMsBattery(_msBattery);

            if (_success == -1)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listBatteryPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }

        }
    }
}
