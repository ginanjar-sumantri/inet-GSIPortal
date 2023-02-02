using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.Common;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common.Enum;
using GSI.BusinessRuleCore;

namespace GSIWebsiteCore.WorkOrder
{
    public partial class ViewWorkOrder : WorkOrderBase
    {
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();

        private ResultBL _resultBL = new ResultBL();
        private RequiredDocumentBL _reqDocBL = new RequiredDocumentBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._nvcExtractor = new NameValueCollectionExtractor(Request.QueryString);

            if (!this.Page.IsPostBack == true)
            {
                this.PageTitleLiteral.Text = this._pageTitleLiteral;

                this.BackImageButton.ImageUrl = this._imageURL + "btnBack.png";

                this.InitializeData();

                this.ShowData();
            }
        }

        private void InitializeData()
        {
            this._queryString = this._nvcExtractor.GetValue(this._workOrderCode);
            this._orderType = _queryString.Split('/');
        }

        private void ShowData()
        {
            if (this._orderType[1] == SPTypeMapper.GetSPType(SurveyPointType.Movable))
            {
                TrWorkOrderMovable _trWorkOrderMovable = this._workOrderBL.GetSingleWorkOrderMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));

                this.WorkOrderCodeLabel.Text = _trWorkOrderMovable.WorkOrderCode;
                this.SurveyorNameLabel.Text = (new EmployeeBL().GetSingleEmployee((this._surveyorBL.GetSingleSurveyor(_trWorkOrderMovable.SurveyorID).EmployeeID)).EmployeeName);
                this.DateLabel.Text = DateFormMapper.GetValue(_trWorkOrderMovable.CreatedDate);
                //this.WorkOrderStatusLabel.Text = GlobalStatusMapper.GetStatusText(_trWorkOrderMovable.WorkOrderStatusID);
                this.WorkOrderStatusLabel.Text = StatusMapper.GetStatusInternalText(_trWorkOrderMovable.WorkOrderStatusID);
                this.RemarkLabel.Text = _trWorkOrderMovable.Remark;

                TrOrderSPMovable _trOrderSPMovable = _surveyPointBL.GetSingleTrOrderMovable(_trWorkOrderMovable.OrderSPMovableID);
                this.SurveyPointNameLiteral.Text = _trOrderSPMovable.SurveyPointName;
                this.HomeAddressLiteral.Text = _trOrderSPMovable.HomeAddress;
                this.ZipCodeLiteral.Text = _trOrderSPMovable.ZipCode;
                this.ClueLiteral.Text = _trOrderSPMovable.Clue;

                TrResultMovable _trResultMovable = this._resultBL.GetResultMovableForWorkOrder(_trWorkOrderMovable.WorkOrderMovableID);
                this.HouseStatusLiteral.Text = _trResultMovable.HouseStatus;
                this.LengthOfStayLiteral.Text = _trResultMovable.LengthOfStay;
                this.ResidenceConditionsLiteral.Text = _trResultMovable.ResidenceConditions;
                this.EnvironmentalConditionsLiteral.Text = _trResultMovable.EnvironmentalConditions;
                this.BuildingAreaLiteral.Text = _trResultMovable.BuildingArea;
                this.PersonalCharacterLiteral.Text = _trResultMovable.PersonalCharacter;
                this.OthersLiteral.Text = _trResultMovable.Others;


            }
            if (this._orderType[1] == SPTypeMapper.GetSPType(SurveyPointType.NotMovable))
            {
                TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovable(Convert.ToInt64(this._nvcExtractor.GetValue(this._codeKey)));

                this.WorkOrderCodeLabel.Text = _trWorkOrderNotMovable.WorkOrderCode;
                this.SurveyorNameLabel.Text = (new EmployeeBL().GetSingleEmployee((this._surveyorBL.GetSingleSurveyor(_trWorkOrderNotMovable.SurveyorID).EmployeeID)).EmployeeName);
                this.DateLabel.Text = DateFormMapper.GetValue(_trWorkOrderNotMovable.CreatedDate);
                //this.WorkOrderStatusLabel.Text = GlobalStatusMapper.GetStatusText(_trWorkOrderNotMovable.WorkOrderStatusID);
                this.WorkOrderStatusLabel.Text = StatusMapper.GetStatusInternalText(_trWorkOrderNotMovable.WorkOrderStatusID);
                this.RemarkLabel.Text = _trWorkOrderNotMovable.Remark;
                //this.ListRepeater.DataBind();
            }
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            OrderDetail _temp = (OrderDetail)e.Item.DataItem;

            ImageButton _viewButton = (ImageButton)e.Item.FindControl("ViewImageButton");
            _viewButton.ImageUrl = this._imageURL + "btnView_small2.jpg";

            Literal _spLiteral = (Literal)e.Item.FindControl("SPLiteral");
            _spLiteral.Text = HttpUtility.HtmlEncode(PointSurveyMapper.GetPointSurveyName((int)_temp.SurveyPointID));
            Literal _nameLiteral = (Literal)e.Item.FindControl("NameLiteral");
            _nameLiteral.Text = HttpUtility.HtmlEncode(_temp.SurveyPointName);
            Literal _statusLiteral = (Literal)e.Item.FindControl("StatusLiteral");
            //_statusLiteral.Text = HttpUtility.HtmlEncode(GlobalStatusMapper.GetStatusText(_temp.SurveyPointStatus));
            _statusLiteral.Text = HttpUtility.HtmlEncode(StatusMapper.GetStatusInternalText(_temp.SurveyPointStatus));
        }

        protected void BackImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(this._listWorkOrderPage);
        }
    }
}
