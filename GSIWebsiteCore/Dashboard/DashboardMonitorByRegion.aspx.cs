using System;
using System.Web;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;

namespace GSIWebsiteCore.Dashboard
{
    public partial class DashboardMonitorByRegion : DashboardBase
    {
        private DashboardBL _dasboardBL = new DashboardBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.BackImageButton.ImageUrl = this.BackImageButton2.ImageUrl = this._imageURL + "btnBack.png";

                this.TimeFrameLiteral.Text = "( " + TimeFrameDurationMapper.GetTimeFrameString(this._nvcExtractor.GetValue(this._codeKey)) + " )";

                this.ClearLabel();
                this.ShowData();
            }
        }

        private void ClearLabel()
        {
        }

        private void ShowData()
        {
            String _errMsg = "";
            this._dasboardBL = new DashboardBL();
            this.ListRepeater.DataSource = this._dasboardBL.GetListViewByRegion(Convert.ToInt32(this._nvcExtractor.GetValue(this._codeKey)), ref _errMsg);
            this.ListRepeater.DataBind();
        }

        protected void ListRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            DashboardByRegion _temp = (DashboardByRegion)e.Item.DataItem;

            Literal _regionNameLiteral = (Literal)e.Item.FindControl("RegionLiteral");
            _regionNameLiteral.Text = HttpUtility.HtmlEncode(_temp.RegionName);

            Literal _RBSLiteral = (Literal)e.Item.FindControl("RBSLiteral");
            _RBSLiteral.Text = HttpUtility.HtmlEncode(_temp.ReceivedBySystem);

            Literal _WFALiteral = (Literal)e.Item.FindControl("WFALiteral");
            _WFALiteral.Text = HttpUtility.HtmlEncode(_temp.WaitingForAssign);

            Literal _WFDLiteral = (Literal)e.Item.FindControl("WFDLiteral");
            _WFDLiteral.Text = HttpUtility.HtmlEncode(_temp.WaitingForDownload);

            Literal _WFSLiteral = (Literal)e.Item.FindControl("WFSLiteral");
            _WFSLiteral.Text = HttpUtility.HtmlEncode(_temp.WaitingForSurvey);

            Literal _OTWLiteral = (Literal)e.Item.FindControl("OTWLiteral");
            _OTWLiteral.Text = HttpUtility.HtmlEncode(_temp.OnTheWay);

            Literal _OTSLiteral = (Literal)e.Item.FindControl("OTSLiteral");
            _OTSLiteral.Text = HttpUtility.HtmlEncode(_temp.OnTheSpot);

            Literal _SRRLiteral = (Literal)e.Item.FindControl("SRRLiteral");
            _SRRLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyResultReceived);

            Literal _publishedLiteral = (Literal)e.Item.FindControl("PublishedLiteral");
            _publishedLiteral.Text = HttpUtility.HtmlEncode(_temp.Published);
        }

        protected void BackImageButton_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardMonitor);
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            this.ShowData();
        }
    }
}