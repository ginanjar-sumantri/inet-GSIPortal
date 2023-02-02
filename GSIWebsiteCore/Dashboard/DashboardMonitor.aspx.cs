using System;
using System.Web.UI;
using GSI.BusinessRuleCore;
using GSI.DataMapping;
using GSI.Common.Enum;
using GSI.BusinessEntity.BusinessEntities;
using System.Web.UI.WebControls;
using System.Web;

namespace GSIWebsiteCore.Dashboard
{
    public partial class DashboardMonitor : DashboardBase
    {
        private DashboardBL _dasboardBL = new DashboardBL();

        private static class BarProperties
        {
            public static String TableWitdh { get; set; }
            public static String ProgressColor { get; set; }
            public static String BackColor { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BarProperties.TableWitdh = "350";
            BarProperties.ProgressColor = "#000066";
            BarProperties.BackColor = "#FFF7CE";

            if (!this.Page.IsPostBack == true)
            {
                this.Region1ImageButton.ImageUrl = this._imageURL + "btnRegion.png";
                this.Region2ImageButton.ImageUrl = this._imageURL + "btnRegion.png";
                this.Region3ImageButton.ImageUrl = this._imageURL + "btnRegion.png";
                this.Surveyor1ImageButton.ImageUrl = this._imageURL + "btnSurveyor.png";
                this.Surveyor2ImageButton.ImageUrl = this._imageURL + "btnSurveyor.png";
                this.Surveyor3ImageButton.ImageUrl = this._imageURL + "btnSurveyor.png";

                this.ClearLabel();
                this.ShowData();
            }
        }

        private void ClearLabel()
        {
            this.TotalSurveyPointLiteral.Text = "";
        }

        private void ShowData()
        {
            String _errMsg1 = "";
            String _errMsg2 = "";

            int _totalSurveyPoint = this._dasboardBL.GetTotalSurveyPoint(ref _errMsg1);
            String[] _barCount = this._dasboardBL.GetBarCount(ref _errMsg2).Split(',');

            this.TotalSurveyPointLiteral.Text = _totalSurveyPoint.ToString("#,##0");

            if (_totalSurveyPoint > 0)
            {
                this.SetBar1(Int32.Parse(_barCount[0]), _totalSurveyPoint);
                this.SetBar2(Int32.Parse(_barCount[1]), _totalSurveyPoint);
                this.SetBar3(Int32.Parse(_barCount[2]), _totalSurveyPoint);
            }

            this.OrderWFDListRepeater.DataSource = this._dasboardBL.GetListOrderWFD(10, ref _errMsg1);
            this.OrderWFDListRepeater.DataBind();
        }

        private void SetBar1(int current, int max)
        {
            String percent = (current * 100 / max).ToString("0");

            this.Progress1Literal.Text = this.GenerateProgressBar("ProgressTable1", percent);
        }

        private void SetBar2(int current, int max)
        {
            String percent = (current * 100 / max).ToString("0");

            this.Progress2Literal.Text = this.GenerateProgressBar("ProgressTable2", percent);
        }

        private void SetBar3(int current, int max)
        {
            String percent = (current * 100 / max).ToString("0");

            this.Progress3Literal.Text = this.GenerateProgressBar("ProgressTable3", percent);
        }

        private String GenerateProgressBar(String _prmID, String percent)
        {
            if (int.Parse(percent) > 4)
            {
                if (int.Parse(percent) == 100)
                {
                    return "<table cellspacing=0 cellpadding=0 border=0 width=" + BarProperties.TableWitdh + " ID='" + _prmID + "'><tr><td bgcolor=" + BarProperties.ProgressColor + " width='" + percent + "%' style='color:#FFFFFF'>" + percent + "%</td></tr></table>";
                }
                return "<table cellspacing=0 cellpadding=0 border=0 width=" + BarProperties.TableWitdh + " ID='" + _prmID + "'><tr><td bgcolor=" + BarProperties.ProgressColor + " width='" + percent + "%' style='color:#FFFFFF'>" + percent + "%</td><td bgcolor=" + BarProperties.BackColor + ">&nbsp;</td></tr></table>";
            }
            else
            {
                if (int.Parse(percent) == 0)
                {
                    return "<table cellspacing=0 cellpadding=0 border=0 width=" + BarProperties.TableWitdh + " ID='" + _prmID + "'><tr><td bgcolor=" + BarProperties.BackColor + ">" + percent + "%</td></tr></table>";
                }
                return "<table cellspacing=0 cellpadding=0 border=0 width=" + BarProperties.TableWitdh + " ID='" + _prmID + "'><tr><td bgcolor=" + BarProperties.ProgressColor + " width='" + percent + "%'>&nbsp;</td><td bgcolor=" + BarProperties.BackColor + ">" + percent + "%</td></tr></table>";
            }
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            this.ShowData();
        }

        protected void Region1ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardRegion + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.LessThanOneHour));
        }

        protected void Region2ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardRegion + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.OneToTwoHour));
        }

        protected void Region3ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardRegion + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.MoreThanTwoHour));
        }

        protected void Surveyor1ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardSurveyor + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.LessThanOneHour));
        }

        protected void Surveyor2ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardSurveyor + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.OneToTwoHour));
        }

        protected void Surveyor3ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._pageDashboardSurveyor + "?" + this._codeKey + "=" + TimeFrameDurationMapper.GetTimeFrame(TimeFrame.MoreThanTwoHour));
        }
        
        protected void OrderWFDListRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            OrderWFD _temp = (OrderWFD)e.Item.DataItem;

            this.NewOrderLiteral.Text = HttpUtility.HtmlEncode(_temp.NewOrder);

            this.OutStandingLiteral.Text = HttpUtility.HtmlEncode(_temp.OutStanding);

            this.OnProgressLiteral.Text = HttpUtility.HtmlEncode(_temp.OnProgress);

            Literal _orderDateLiteral = (Literal)e.Item.FindControl("OrderDateLiteral");
            _orderDateLiteral.Text = HttpUtility.HtmlEncode(_temp.OrderDate);

            Literal _customerNameLiteral = (Literal)e.Item.FindControl("CustomerNameLiteral");
            _customerNameLiteral.Text = HttpUtility.HtmlEncode(_temp.CustomerName);

            Literal _sPStatusLiteral = (Literal)e.Item.FindControl("SPStatusLiteral");
            _sPStatusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusInternalText(_temp.SPStatus));

            Literal _regionNameLiteral = (Literal)e.Item.FindControl("RegionNameLiteral");
            _regionNameLiteral.Text = HttpUtility.HtmlEncode(_temp.RegionName);
        }
    }
}