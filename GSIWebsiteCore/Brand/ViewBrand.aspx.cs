using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;


namespace GSIWebsiteCore.Brand
{
    public partial class ViewBrand : BrandBase
    {
        private BrandBL _brandBL = new BrandBL();
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
                this.BrandCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.BrandCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");
                this.ShowBrandTypeDDL();
                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._brandID) != ""))
                {
                    this.ShowData();
                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._brandID);
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

        private void ShowData()
        {
            MsBrand _msBrand = this._brandBL.GetSingleMsBrandByBrandID(Convert.ToInt64(this._nvcExtractor.GetValue(this._brandID)));

            this.BrandCodeTextBox.Text = _msBrand.BrandCode;
            this.BrandNameTextBox.Text = _msBrand.BrandName;
            this.BrandTypeDropDownList.SelectedValue = Convert.ToString(_msBrand.BrandType);
            this.NoteTextBox.Text = _msBrand.Remark;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msBrand.BrandID.ToString();
        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listBrandPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsBrand _msBrand = new MsBrand();
            _msBrand.BrandID = Convert.ToInt64(this._nvcExtractor.GetValue(this._brandID));
            _msBrand.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msBrand.RowStatus = 1;

            _result = this._brandBL.DeletedBrand(_msBrand);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listBrandPage);
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

            MsBrand _msBrand = this._brandBL.GetSingleMsBrandByBrandID(Convert.ToInt64(this._nvcExtractor.GetValue(this._brandID)));

            _msBrand.BrandCode = this.BrandCodeTextBox.Text;
            _msBrand.BrandName = this.BrandNameTextBox.Text;
            _msBrand.BrandType = Convert.ToByte(this.BrandTypeDropDownList.SelectedValue);
            _msBrand.Remark = this.NoteTextBox.Text;
            _msBrand.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msBrand.ModifiedDate = DateTime.Now;

            _result = this._brandBL.UpdateMsBrand(_msBrand);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listBrandPage);
            }

        }

    }
}
