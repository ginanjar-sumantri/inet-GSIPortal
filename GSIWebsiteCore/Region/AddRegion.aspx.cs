using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;

namespace GSIWebsiteCore.Region
{
    public partial class AddRegion : RegionBase
    {
        private RegionBL _regionBL = new RegionBL();

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
            this.RegionCodeTextBox.Text = "";
            this.RegionNameTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsRegion _msRegion = new MsRegion();

            _msRegion.RegionCode = this.RegionCodeTextBox.Text;
            _msRegion.RegionName = this.RegionNameTextBox.Text;
            _msRegion.CreatedBy = Request.ServerVariables["LOGON_USER"];

            int _success = this._regionBL.InsertMsRegion(_msRegion);

            if (_success == -1)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listRegionPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listRegionPage);
        }

    }
}
