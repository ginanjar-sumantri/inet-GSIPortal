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
    public partial class ViewOperator : OperatorBase
    {
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
                this.CodeOperatorTextBox.Attributes.Add("ReadOnly", "True");
                this.CodeOperatorTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._operatorID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._operatorID);
        }

        private void ShowData()
        {
            MsOperator _msOperator = this._operatorBL.GetSingleOperator(Convert.ToInt64(this._nvcExtractor.GetValue(this._operatorID)));

            this.CodeOperatorTextBox.Text = _msOperator.OperatorCode;
            this.OperatorNameTextBox.Text = _msOperator.OperatorName;
            this.NoteTextBox.Text = _msOperator.Remark;
            
            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msOperator.OperatorID.ToString();

        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listOperatorPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsOperator _msOperator = new MsOperator();
            _msOperator.OperatorID = Convert.ToInt64(this._nvcExtractor.GetValue(this._operatorID));
            _msOperator.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msOperator.RowStatus = 1;

            _result = this._operatorBL.DeletedOperator(_msOperator);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                Response.Redirect(this._listOperatorPage);
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

            MsOperator _msOperator = this._operatorBL.GetSingleOperator(Convert.ToInt64(this._nvcExtractor.GetValue(this._operatorID)));

            _msOperator.OperatorCode = this.CodeOperatorTextBox.Text;
            _msOperator.OperatorName = this.OperatorNameTextBox.Text;
            _msOperator.Remark = this.NoteTextBox.Text;
            _msOperator.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msOperator.ModifiedDate = DateTime.Now;

            _result = this._operatorBL.UpdateMsOperator(_msOperator);

            if (_result)
            {
                Response.Redirect(this._listOperatorPage);
            }
        }
    }
}
