using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using System.Collections.Generic;

namespace GSIWebsiteCore.Operator
{
    public partial class AddOperator : OperatorBase
    {
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
                this.ClearData();
            }
        }

        private void ClearData()
        {
            this.OperatorCodeTextBox.Text = "";
            this.OperatorNameTextBox.Text = "";
            this.NoteTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listOperatorPage);
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsOperator _msOperator = new MsOperator();

            _msOperator.OperatorCode = this.OperatorCodeTextBox.Text;
            _msOperator.OperatorName = this.OperatorNameTextBox.Text;
            _msOperator.Remark = this.NoteTextBox.Text;
            _msOperator.RowStatus = 0;
            _msOperator.CreatedBy = Request.ServerVariables["LOGON_USER"];

            int _success = this._operatorBL.InsertMsOperator(_msOperator);

            if (_success == -1)
            {
                Response.Redirect(this._listOperatorPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }
        }
    }
}
