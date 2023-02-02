using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;

namespace GSIWebsiteCore.SIMCard
{
    public partial class ViewSIMCard : SIMCardBase
    {
        private SIMCardBL _sIMCardBL = new SIMCardBL();
        private OperatorBL _operatorBL = new OperatorBL();
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
                this.SIMCardNumberCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.SIMCardNumberCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                SetAttribute();
                ShowSIMCardTypeDDL();
                this.InitializeData();
                if ((this._nvcExtractor.GetValue(this._sIMCardID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void SetAttribute()
        {
            this.SIMCardNumberTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.SIMCardNumberTextBox.ClientID + "," + this.SIMCardNumberTextBox.ClientID + ",500" + ")");
            this.PhonePulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.PhonePulsaTextBox.ClientID + "," + this.PhonePulsaTextBox.ClientID + ",500" + ")");
            this.InternetPulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.InternetPulsaTextBox.ClientID + "," + this.InternetPulsaTextBox.ClientID + ",500" + ")");
            this.NoCheckPulsaTextBox.Attributes.Add("OnKeyUp", "return formatangka(" + this.NoCheckPulsaTextBox.ClientID + "," + this.NoCheckPulsaTextBox.ClientID + ",500" + ")");
        }

        protected void ShowSIMCardTypeDDL()
        {
            this.OperatorNameDropDownList.Items.Clear();
            this.OperatorNameDropDownList.DataValueField = "OperatorID";
            this.OperatorNameDropDownList.DataTextField = "OperatorName";
            this.OperatorNameDropDownList.DataSource = this._operatorBL.GetListOperator();
            this.OperatorNameDropDownList.DataBind();
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._sIMCardID);
        }

        private void ShowData()
        {
            MsSIMCard _msSIMCard = this._sIMCardBL.GetSingleSIMCard(Convert.ToInt64(this._nvcExtractor.GetValue(this._sIMCardID)));

            this.SIMCardNumberCodeTextBox.Text = _msSIMCard.SIMCardCode;
            this.SIMCardNumberTextBox.Text = _msSIMCard.SIMCardNumber;
            this.OperatorNameDropDownList.SelectedValue = _msSIMCard.OperatorName;
            this.PhonePulsaTextBox.Text = Convert.ToString(_msSIMCard.PhonePulsa);
            this.InternetPulsaTextBox.Text = Convert.ToString(_msSIMCard.InternetPulsa);
            this.NoCheckPulsaTextBox.Text = Convert.ToString(_msSIMCard.NoCheckPulsa);
            this.NoteTextBox.Text = _msSIMCard.Remark;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msSIMCard.SIMCardID.ToString();

        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.InitializeData();
            Response.Redirect(this._listSIMCardPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsSIMCard _msSIMCard = new MsSIMCard();
            _msSIMCard.SIMCardID = Convert.ToInt64(this._nvcExtractor.GetValue(this._sIMCardID));
            _msSIMCard.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msSIMCard.RowStatus = 1;

            _result = this._sIMCardBL.DeletedSIMCard(_msSIMCard);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listSIMCardPage);
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

            MsSIMCard _msSIMCard = this._sIMCardBL.GetSingleSIMCard(Convert.ToInt64(this._nvcExtractor.GetValue(this._sIMCardID)));

            _msSIMCard.SIMCardCode = this.SIMCardNumberCodeTextBox.Text;
            _msSIMCard.SIMCardNumber = this.SIMCardNumberTextBox.Text;
            _msSIMCard.OperatorID = Convert.ToByte(this.OperatorNameDropDownList.SelectedValue);
            _msSIMCard.PhonePulsa = Convert.ToInt32(this.PhonePulsaTextBox.Text);
            _msSIMCard.InternetPulsa = Convert.ToInt32(this.InternetPulsaTextBox.Text);
            _msSIMCard.NoCheckPulsa = Convert.ToInt32(this.NoCheckPulsaTextBox.Text);
            _msSIMCard.Remark = this.NoteTextBox.Text;
            _msSIMCard.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msSIMCard.ModifiedDate = DateTime.Now;

            _result = this._sIMCardBL.UpdateMsSIMCard(_msSIMCard);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listSIMCardPage);
            }
        }

    }
}
