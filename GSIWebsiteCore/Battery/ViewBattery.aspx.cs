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
    public partial class ViewBattery : BatteryBase
    {
        private BatteryBL _batteryBL = new BatteryBL();
        private String _queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropImageButton.Attributes.Add("OnClick", "return Drop();");

            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleViewLiteral;
                this.SaveImageButton.ImageUrl = this._imageURL + "btnSave2.png";
                this.SaveImageButton.ToolTip = this._toolTipSave;
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;
                this.CodeBatteryTextBox.Attributes.Add("ReadOnly", "True");
                this.CodeBatteryTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.AmpereTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.AmpereTextBox.ClientID + "," + this.AmpereTextBox.ClientID + ",500" + ")");
                this.ShowBatteryTypeDDL();
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._batteryID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._batteryID);
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

        private void ShowData()
        {
            MsBattery _msBattery = this._batteryBL.GetSingleMsBatteryByBatteryID(Convert.ToInt64(this._nvcExtractor.GetValue(this._batteryID)));

            this.CodeBatteryTextBox.Text = _msBattery.BatteryCode;
            this.BatteryNameTextBox.Text = _msBattery.BatteryName;
            this.BatteryTypeDropDownList.SelectedValue = Convert.ToString(_msBattery.BatteryType);
            this.AmpereTextBox.Text = Convert.ToString(_msBattery.Ampere);
            this.SerialNumberTextBox.Text = _msBattery.SerialNumber;
            this.NoteTextBox.Text = _msBattery.Remark;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msBattery.BatteryID.ToString();

        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listBatteryPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsBattery _msBattery = new MsBattery();
            _msBattery.BatteryID = Convert.ToInt64(this._nvcExtractor.GetValue(this._batteryID));
            _msBattery.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msBattery.RowStatus = 1;

            _result = this._batteryBL.DeletedBattery(_msBattery);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listBatteryPage);
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

            MsBattery _msBattery = this._batteryBL.GetSingleMsBatteryByBatteryID(Convert.ToInt64(this._nvcExtractor.GetValue(this._batteryID)));

            _msBattery.BatteryCode = this.CodeBatteryTextBox.Text;
            _msBattery.BatteryName = this.BatteryNameTextBox.Text;
            _msBattery.BatteryType = Convert.ToByte(this.BatteryTypeDropDownList.SelectedValue);
            _msBattery.Ampere = Convert.ToInt32(this.AmpereTextBox.Text);
            _msBattery.SerialNumber = this.SerialNumberTextBox.Text;
            _msBattery.Remark = this.NoteTextBox.Text;
            _msBattery.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msBattery.ModifiedDate = DateTime.Now;

            _result = this._batteryBL.UpdateMsBattery(_msBattery);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listBatteryPage);
            }
        }
    }
}
