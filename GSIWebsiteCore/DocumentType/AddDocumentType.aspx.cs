using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using System.Collections.Generic;

namespace GSIWebsiteCore.DocumentType
{
    public partial class AddDocumentType : DocumentTypeBase
    {
        private DocumentTypeBL _documentTypeBL = new DocumentTypeBL();

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
            this.DocumentTypeNameTextBox.Text = "";
            this.NoteTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listDocumentTypePage);
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsDocumentType _msDocumentType = new MsDocumentType();

            _msDocumentType.DocumentTypeName = this.DocumentTypeNameTextBox.Text;
            _msDocumentType.Remark = this.NoteTextBox.Text;
            _msDocumentType.RowStatus = 0;
            _msDocumentType.CreatedBy = Request.ServerVariables["LOGON_USER"];

            int _success = this._documentTypeBL.InsertMsDocumentType(_msDocumentType);

            if (_success == -1)
            {
                Response.Redirect(this._listDocumentTypePage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }
        }
    }
}
