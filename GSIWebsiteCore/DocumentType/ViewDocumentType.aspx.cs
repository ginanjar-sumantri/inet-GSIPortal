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
    public partial class ViewDocumentType : DocumentTypeBase
    {
        private DocumentTypeBL _documentTypeBL = new DocumentTypeBL();
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
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._documentTypeID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._documentTypeID);
        }

        private void ShowData()
        {
            MsDocumentType _msDocumentType = this._documentTypeBL.GetSingleDocumentType(Convert.ToInt64(this._nvcExtractor.GetValue(this._documentTypeID)));

            this.DocumentTypeNameTextBox.Text = _msDocumentType.DocumentTypeName;
            this.NoteTextBox.Text = _msDocumentType.Remark;
            
            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msDocumentType.DocumentTypeID.ToString();

        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listDocumentTypePage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsDocumentType _msDocumentType = new MsDocumentType();
            _msDocumentType.DocumentTypeID = Convert.ToInt64(this._nvcExtractor.GetValue(this._documentTypeID));
            _msDocumentType.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msDocumentType.RowStatus = 1;

            _result = this._documentTypeBL.DeletedDocumentType(_msDocumentType);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                Response.Redirect(this._listDocumentTypePage);
            }
            else
            {
                this.WarningLabel.Text = ErrorHandler.ErrorMessage;
                ErrorHandler.ErrorMessage = "";
            }
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Boolean _result = false;

            MsDocumentType _msDocumentType = this._documentTypeBL.GetSingleDocumentType(Convert.ToInt64(this._nvcExtractor.GetValue(this._documentTypeID)));

            _msDocumentType.DocumentTypeName = this.DocumentTypeNameTextBox.Text;
            _msDocumentType.Remark = this.NoteTextBox.Text;
            _msDocumentType.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msDocumentType.ModifiedDate = DateTime.Now;

            _result = this._documentTypeBL.UpdateMsDocumentType(_msDocumentType);

            if (_result)
            {
                Response.Redirect(this._listDocumentTypePage);
            }
        }
    }
}
