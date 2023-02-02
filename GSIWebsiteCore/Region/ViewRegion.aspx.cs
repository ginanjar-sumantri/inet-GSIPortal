using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSIWebsiteCore;
using GSI.Common;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;
using System.Collections.Generic;

namespace GSIWebsiteCore.Region
{
    public partial class ViewRegion : RegionBase
    {
        private RegionBL _regionBL = new RegionBL();
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
                this.RegionCodeTextBox.Attributes.Add("ReadOnly", "True");
                this.RegionCodeTextBox.Attributes.Add("Style", "background-color: #CCCCCC");

                this.InitializeData();

                if ((this._nvcExtractor.GetValue(this._regionID) != ""))
                {
                    this.ShowData();

                }
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._regionID);
        }

        private void ShowData()
        {
            MsRegion _msRegion = this._regionBL.GetMsRegionByRegionId(Convert.ToInt64(this._nvcExtractor.GetValue(this._regionID)));

            this.RegionCodeTextBox.Text = _msRegion.RegionCode;
            this.RegionNameTextBox.Text = _msRegion.RegionName;

            ImageButton _dropButton = this.DropImageButton;
            _dropButton.CommandArgument = _msRegion.RegionID.ToString();

        }

        protected void CancelImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listRegionPage);
        }

        protected void DropImageButton_Click(object sender, ImageClickEventArgs e)
        {
            int _result = 0;

            MsRegion _msRegion = new MsRegion();
            _msRegion.RegionID = Convert.ToInt64(this._nvcExtractor.GetValue(this._regionID));
            _msRegion.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msRegion.RowStatus = 1;

            _result = this._regionBL.DeletedRegion(_msRegion);

            if (_result == -1 && ErrorHandler.ErrorMessage == "")
            {
                this.WarningLabel.Text = "You Success Update";
                Response.Redirect(this._listRegionPage);
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

            MsRegion _msRegion = this._regionBL.GetMsRegionByRegionId(Convert.ToInt64(this._nvcExtractor.GetValue(this._regionID)));

            _msRegion.RegionCode = this.RegionCodeTextBox.Text;
            _msRegion.RegionName = this.RegionNameTextBox.Text;
            _msRegion.ModifiedBy = Request.ServerVariables["LOGON_USER"];
            _msRegion.ModifiedDate = DateTime.Now;

            _result = this._regionBL.UpdateMsRegion(_msRegion);

            if (_result)
            {
                this.WarningLabel.Text = "You Success update";
                Response.Redirect(this._listRegionPage);
            }

        }
    }
}
