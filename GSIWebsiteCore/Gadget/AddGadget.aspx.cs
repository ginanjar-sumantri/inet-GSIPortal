using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
//using GSI.DataMapping;
using System.Collections.Generic;

namespace GSIWebsiteCore.Gadget
{
    public partial class AddGadget : GadgetBase
    {
        private GadgetBL _gadgetBL = new GadgetBL();
        private BrandBL _brandBL = new BrandBL();
        private SIMCardBL _sIMCardBL = new SIMCardBL();

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
                this.ResetImageButton.ToolTip = this._toolTipReset;
                this.ShowBrandDDL();
                this.ShowSIMCardDDL();
                this.Notice();
                this.ClearData();
            }
        }

        protected void ShowBrandDDL()
        {
            this.BrandDDL.Items.Clear();
            this.BrandDDL.DataValueField = "BrandID";
            this.BrandDDL.DataTextField = "BrandName";
            List<MsBrand> _msBrand = this._brandBL.GetListMsBrand(10000, 0, "BrandName", "");
            this.BrandDDL.DataSource = _msBrand;
            this.BrandDDL.DataBind();
            this.BrandDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
            //if (_msBrand.Count <= 0)
            //{
            //    this.WarningLabel.Text = "Master Brand Empty, please use the first master brand";
            //};
        }

        protected void ShowSIMCardDDL()
        {
            this.SIMCardDDL.Items.Clear();
            this.SIMCardDDL.DataValueField = "SIMCardID";
            this.SIMCardDDL.DataTextField = "SIMCardNumber";
            List<MsSIMCard> _msSimCard = this._sIMCardBL.GetListMsSIMCard(10000, 0, "SIMCardNumber", "");
            this.SIMCardDDL.DataSource = _msSimCard;
            this.SIMCardDDL.DataBind();
            this.SIMCardDDL.Items.Insert(0, new ListItem("[Choose One]", "null"));
            //if (_msSimCard.Count <= 0)
            //{
            //    this.WarningLabel.Text = "Master SimCard, please use the first master SimCard";
            //};
        }

        private void ClearData()
        {
            this.GadgetCodeTextBox.Text = "";
            this.GadgetNameTextBox.Text = "";
            //this.BrandDDL.SelectedValue = "1";
            this.NoIMEITextBox.Text = "";
            //this.SIMCardDDL.SelectedValue = "3";
            this.NoteTextBox.Text = "";
        }

        private void Notice()
        {
            this.WarningLabel.Text = "";
            String _messageNotice = "";
            if (this.BrandDDL.Items.Count == 1)
            {
                _messageNotice = "the Brand data";
            }
            if (this.SIMCardDDL.Items.Count == 1)
            {
                if (_messageNotice != "")
                {
                    _messageNotice = _messageNotice + " and ";
                }
                _messageNotice = _messageNotice + "the SIM Card data";
            }
            if (_messageNotice != "")
            {
                this.WarningLabel.Text = "Please fill in " + _messageNotice + ", before performing Gadget data storage ";
            }
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
                MsGadget _msGadget = new MsGadget();

                _msGadget.GadgetCode = this.GadgetCodeTextBox.Text;
                _msGadget.GadgetName = this.GadgetNameTextBox.Text;
                _msGadget.BrandID = Convert.ToInt64(this.BrandDDL.SelectedValue);
                _msGadget.NoIMEI = this.NoIMEITextBox.Text;
                _msGadget.SIMCardID = Convert.ToInt64(this.SIMCardDDL.SelectedValue);
                _msGadget.Remark = this.NoteTextBox.Text;
                _msGadget.CreatedBy = Request.ServerVariables["LOGON_USER"];

                int _success = this._gadgetBL.InsertMsGadget(_msGadget);

                if (_success == -1)
                {
                    Response.Redirect(this._listGadgetPage);
                }
                else
                {
                    this.WarningLabel.Text = "You Failed Add Data";
                }
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listGadgetPage);
        }
    }
}
