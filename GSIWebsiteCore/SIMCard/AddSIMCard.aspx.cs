using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using System.Collections.Generic;

namespace GSIWebsiteCore.SIMCard
{
    public partial class AddSIMCard : SIMCardBase
    {
        private SIMCardBL _sIMCardBL = new SIMCardBL();
        private OperatorBL _operatorBL = new OperatorBL();

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
                this.SetAttribute();
                this.ShowOperatorNameDDL();
                this.Notice();
                this.ClearData();
            }
        }

        protected void SetAttribute()
        {
            this.SIMCardNumberTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SIMCardNumberTextBox.ClientID + "," + this.SIMCardNumberTextBox.ClientID + ",500" + ")");
            this.PhonePulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhonePulsaTextBox.ClientID + "," + this.PhonePulsaTextBox.ClientID + ",500" + ")");
            this.InternetPulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.InternetPulsaTextBox.ClientID + "," + this.InternetPulsaTextBox.ClientID + ",500" + ")");
            this.NoCheckPulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.NoCheckPulsaTextBox.ClientID + "," + this.NoCheckPulsaTextBox.ClientID + ",500" + ")");
        }

        protected void ShowOperatorNameDDL()
        {
            this.OperatorNameDropDownList.Items.Clear();
            this.OperatorNameDropDownList.DataValueField = "OperatorID";
            this.OperatorNameDropDownList.DataTextField = "OperatorName";
            List<MsOperator> _msOperator = this._operatorBL.GetListOperator();
            this.OperatorNameDropDownList.DataSource = _msOperator;
            this.OperatorNameDropDownList.DataBind();
            this.OperatorNameDropDownList.Items.Insert(0, new ListItem("[Choose One]", "null"));

            //if (_msOperator.Count <= 0)
            //{
            //    this.WarningLabel.Text = "Master Operator, please use the first master Operator";
            //};
        }

        private void Notice()
        {
            this.WarningLabel.Text = "";
            String _messageNotice = "";
            if (this.OperatorNameDropDownList.Items.Count == 1)
            {
                _messageNotice = "the Operator data";
            }
            if (_messageNotice != "")
            {
                this.WarningLabel.Text = "Please fill in " + _messageNotice + ", before performing SIM Card data storage ";
            }
        }

        private void ClearData()
        {
            this.SIMCardCodeTextBox.Text = "";
            this.SIMCardNumberTextBox.Text = "";
            this.OperatorNameDropDownList.SelectedValue = "1";
            this.PhonePulsaTextBox.Text = "0";
            this.InternetPulsaTextBox.Text = "0";
            this.NoCheckPulsaTextBox.Text = "0";
            this.NoteTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.Notice();
            if (this.WarningLabel.Text == "")
            {
                MsSIMCard _msSIMCard = new MsSIMCard();

                _msSIMCard.SIMCardCode = this.SIMCardCodeTextBox.Text;
                _msSIMCard.SIMCardNumber = this.SIMCardNumberTextBox.Text;
                _msSIMCard.OperatorID = Convert.ToByte(this.OperatorNameDropDownList.SelectedValue);
                _msSIMCard.PhonePulsa = Convert.ToInt32(this.PhonePulsaTextBox.Text);
                _msSIMCard.InternetPulsa = Convert.ToInt32(this.InternetPulsaTextBox.Text);
                _msSIMCard.NoCheckPulsa = Convert.ToInt32(this.NoCheckPulsaTextBox.Text);
                _msSIMCard.Remark = this.NoteTextBox.Text;
                _msSIMCard.RowStatus = 0;
                _msSIMCard.CreatedBy = Request.ServerVariables["LOGON_USER"];

                int _success = this._sIMCardBL.InsertMsSIMCard(_msSIMCard);

                if (_success == -1)
                {
                    //this.WarningLabel.Text = "You Success update";
                    Response.Redirect(this._listSIMCardPage);
                }
                else
                {
                    this.WarningLabel.Text = "You Failed Add Data";
                }
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listSIMCardPage);
        }
    }
}
