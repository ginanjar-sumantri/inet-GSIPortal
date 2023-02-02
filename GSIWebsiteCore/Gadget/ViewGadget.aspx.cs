using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;


namespace GSIWebsiteCore.Gadget
{
    public partial class ViewGadget : GadgetBase
    {
        private GadgetBL _gadgetBL = new GadgetBL();
        private BrandBL _brandBL = new BrandBL();
        private SIMCardBL _sIMCardBL = new SIMCardBL();
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
                this.CancelImageButton.ImageUrl = this._imageURL + "btnCancel2.png";
                this.CancelImageButton.ToolTip = this._toolTipCancel;
                this.DropImageButton.ImageUrl = this._imageURL + "btnDrop.png";
                this.DropImageButton.ToolTip = this._toolTipDrop;
                this.GadgetCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.GadgetCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ShowBrandDDL();
                this.ShowSIMCardDDL();
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._gadgetID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._gadgetID);
        }

        private void ShowData()
        {
            MsGadget _msGadget = this._gadgetBL.GetSingleGadget(Convert.ToInt64(this._nvcExtractor.GetValue(this._gadgetID)));

            this.GadgetCodeTextBox.Text = _msGadget.GadgetCode;
            this.GadgetNameTextBox.Text = _msGadget.GadgetName;
            this.BrandDDL.SelectedValue = _msGadget.BrandID.ToString();
            this.NoIMEITextBox.Text = _msGadget.NoIMEI;
            this.SIMCardDDL.SelectedValue = _msGadget.SIMCardID.ToString();
            this.NoteTextBox.Text = _msGadget.Remark;
            
            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msGadget.GadgetID.ToString();
        }

        protected void ShowBrandDDL()
        {
            this.BrandDDL.Items.Clear();
            this.BrandDDL.DataValueField = "BrandID";
            this.BrandDDL.DataTextField = "BrandName";
            this.BrandDDL.DataSource = this._brandBL.GetListMsBrand(10000, 0, "", "");
            this.BrandDDL.DataBind();
        }

        protected void ShowSIMCardDDL()
        {
            this.SIMCardDDL.Items.Clear();
            this.SIMCardDDL.DataValueField = "SIMCardID";
            this.SIMCardDDL.DataTextField = "SIMCardNumber";
            this.SIMCardDDL.DataSource = this._sIMCardBL.GetListMsSIMCard(10000, 0, "SIMCardNumber", "");
            this.SIMCardDDL.DataBind();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listGadgetPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsGadget _msGadget = new MsGadget();
            _msGadget.GadgetID = Convert.ToInt64(this._nvcExtractor.GetValue(this._gadgetID));
            _msGadget.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msGadget.RowStatus = 1;

            _result = this._gadgetBL.DeletedGadget(_msGadget);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listGadgetPage);
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

            MsGadget _msGadget = this._gadgetBL.GetSingleGadget(Convert.ToInt64(this._nvcExtractor.GetValue(this._gadgetID)));

            _msGadget.GadgetName = this.GadgetNameTextBox.Text;
            _msGadget.BrandID = Convert.ToInt64 (this.BrandDDL.SelectedValue);
            _msGadget.NoIMEI = this.NoIMEITextBox.Text;
            _msGadget.SIMCardID = Convert.ToInt64(this.SIMCardDDL.SelectedValue);
            _msGadget.Remark = this.NoteTextBox.Text;
            _msGadget.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msGadget.ModifiedDate = DateTime.Now;

            _result = this._gadgetBL.UpdateMsGadget(_msGadget);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listGadgetPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Edit Data";
            }

        }
    }
}
