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

namespace GSIWebsiteCore.Brand
{
    public partial class AddBrand : BrandBase
    {
        private BrandBL _brandBL = new BrandBL();

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
                this.ShowBrandTypeDDL();
                this.ClearData();
            }
        }

        protected void ShowBrandTypeDDL()
        {
            List<String> _brandTypes = BrandTypeMapper.BrandTypes;
            this.BrandTypeDropDownList.Items.Clear();
            foreach (var _brandType in _brandTypes)
            {
                String[] _row = _brandType.Split(',');
                this.BrandTypeDropDownList.Items.Add(new ListItem(_row[1], _row[0]));
            }
        }

        private void ClearData()
        {
            this.BrandCodeTextBox.Text = "";
            this.BrandNameTextBox.Text = "";
            this.BrandTypeDropDownList.SelectedValue = "1";
            this.NoteTextBox.Text = "";
        }

        protected void ResetImageButton_Click(object sender, ImageClickEventArgs e)
        {
            this.ClearData();
        }

        protected void SaveImageButton_Click(object sender, ImageClickEventArgs e)
        {
            MsBrand _msBrand = new MsBrand();

            _msBrand.BrandCode = this.BrandCodeTextBox.Text;
            _msBrand.BrandName = this.BrandNameTextBox.Text;
            _msBrand.BrandType = Convert.ToByte(this.BrandTypeDropDownList.SelectedValue);
            _msBrand.Remark = this.NoteTextBox.Text;
            _msBrand.RowStatus = 0;
            _msBrand.CreatedBy = Request.ServerVariables["LOGON_USER"];

            int _success = this._brandBL.InsertMsBrand(_msBrand);

            if (_success == -1)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listBrandPage);
            }
            else
            {
                this.WarningLabel.Text = "You Failed Add Data";
            }
        }
        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listBrandPage);
        }
    }
}
