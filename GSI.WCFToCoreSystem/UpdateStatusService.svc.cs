using System;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using System.Configuration;

namespace GSI.WCFToCoreSystem
{
    public class UpdateStatusService : IUpdateStatusService
    {
        private WorkOrderBL _woBL = new WorkOrderBL();
        private OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private EmployeeBL _employeeBL = new EmployeeBL();

        public void UpdateStatusCoreSystem(SurveyPointType _prmSPType, Int64 _prmWorkOrderID, GSIInternalStatus _prmStatus, DateTime _prmDate)
        {
            if (_prmSPType == SurveyPointType.Movable)
            {
                GSI.BusinessEntity.BusinessEntities.TrWorkOrderMovable _trWO = _woBL.GetSingleWorkOrderMovable(_prmWorkOrderID);
                _trWO.WorkOrderStatusID = StatusMapper.GetStatusInternal(_prmStatus);

                GSI.BusinessEntity.BusinessEntities.TrOrderSPMovable _orderSP = this._orderSPBL.GetSingleTrOrderMovable(_trWO.OrderSPMovableID);
                _orderSP.SPStatus = StatusMapper.GetStatusInternal(_prmStatus);
                if (_prmStatus == GSIInternalStatus.Cancelled)
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                else
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

                switch (_prmStatus)
                {
                    case GSIInternalStatus.WaitingForSurvey:
                        //_trWO.DownloadDate = DateTime.Now;
                        _trWO.DownloadDate = _prmDate;
                        break;
                    case GSIInternalStatus.OnTheWay:
                        //_trWO.OnTheWayDate = DateTime.Now;
                        _trWO.OnTheWayDate = _prmDate;
                        break;
                    case GSIInternalStatus.OnTheSpot:
                        //_trWO.OnTheSpotDate = DateTime.Now;
                        _trWO.OnTheSpotDate = _prmDate;
                        break;
                    case GSIInternalStatus.SurveyResultReceived:
                        _trWO.SurveyResultReceivedDate = _prmDate;
                        _trWO.SyncStatus = false;
                        break;
                    default:
                        break;
                }

                this._orderSPBL.UpdateTrOrderSPMovable(_orderSP);
                this._woBL.UpdateWorkOrderMovable(_trWO);

                OrderBL _orderBL = new OrderBL();
                if (_orderBL.IsOrderSurveyPointAllComplete(_orderSP.OrderID))
                {
                    GSI.BusinessEntity.BusinessEntities.TrOrder _order = _orderBL.GetSingleOrderByOrderID(_orderSP.OrderID);
                    _order.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed);
                    _orderBL.UpdateOrder(_order);
                }

                UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateStatusCustomerPortal(SurveyPointType.Movable, _trWO.OrderSPMovableID, _prmStatus, _orderSP.UserTakeOver);
                _client.Close();

                GSI.BusinessEntity.BusinessEntities.TrOrderSPMovable _trOrderMovable = new OrderSurveyPointBL().GetSingleTrOrderMovable(_trWO.OrderSPMovableID);
                GSI.BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderMovable.OrderID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(_trWO.SurveyorID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderMovable.SurveyPointID);
                GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

                DateTime _now = DateTime.Now;
                _trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWO.SurveyorID);
                _trOrderSPLog.CreatedDate = _now;
                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                _trOrderSPLog.OrderSPID = _trWO.OrderSPMovableID;
                _trOrderSPLog.DateTime = _now;
                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                _trOrderSPLog.Status = Convert.ToByte(_prmStatus);
                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.SurveyProcess);
                _trOrderSPLog.EmployeeID = _msSurveyor.EmployeeID;
                _trOrderSPLog.RowStatus = 0;

                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
            }
            else
            {
                GSI.BusinessEntity.BusinessEntities.TrWorkOrderNotMovable _trWO = _woBL.GetSingleWorkOrderNotMovable(_prmWorkOrderID);
                _trWO.WorkOrderStatusID = StatusMapper.GetStatusInternal(_prmStatus);

                GSI.BusinessEntity.BusinessEntities.TrOrderSPNotMovable _orderSP = this._orderSPBL.GetSingleTrOrderNotMovable(_trWO.OrderSPNotMovableID);
                _orderSP.SPStatus = StatusMapper.GetStatusInternal(_prmStatus);
                if (_prmStatus == GSIInternalStatus.Cancelled)
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                else
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

                switch (_prmStatus)
                {
                    case GSIInternalStatus.WaitingForSurvey:
                        //_trWO.DownloadDate = DateTime.Now;
                        _trWO.DownloadDate = _prmDate;
                        break;
                    case GSIInternalStatus.OnTheWay:
                        //_trWO.OnTheWayDate = DateTime.Now;
                        _trWO.OnTheWayDate = _prmDate;
                        break;
                    case GSIInternalStatus.OnTheSpot:
                        //_trWO.OnTheSpotDate = DateTime.Now;
                        _trWO.OnTheSpotDate = _prmDate;
                        break;
                    case GSIInternalStatus.SurveyResultReceived:
                        _trWO.SurveyResultReceivedDate = _prmDate;
                        _trWO.SyncStatus = false;
                        break;
                    default:
                        break;
                }

                this._orderSPBL.UpdateTrOrderSPNotMovable(_orderSP);
                this._woBL.UpdateWorkOrderNotMovable(_trWO);

                OrderBL _orderBL = new OrderBL();
                if (_orderBL.IsOrderSurveyPointAllComplete(_orderSP.OrderID))
                {
                    GSI.BusinessEntity.BusinessEntities.TrOrder _order = _orderBL.GetSingleOrderByOrderID(_orderSP.OrderID);
                    _order.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed);
                    _orderBL.UpdateOrder(_order);
                }

                UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateStatusCustomerPortal(SurveyPointType.NotMovable, _trWO.OrderSPNotMovableID, _prmStatus, _orderSP.UserTakeOver);
                _client.Close();

                GSI.BusinessEntity.BusinessEntities.TrOrderSPNotMovable _trOrderNotMovable = new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_trWO.OrderSPNotMovableID);
                GSI.BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderNotMovable.OrderID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(_trWO.SurveyorID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderNotMovable.SurveyPointID);
                GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

                DateTime _now = DateTime.Now;
                _trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWO.SurveyorID);
                _trOrderSPLog.CreatedDate = _now;
                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                _trOrderSPLog.OrderSPID = _trWO.OrderSPNotMovableID;
                _trOrderSPLog.DateTime = _now;
                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                _trOrderSPLog.Status = Convert.ToByte(_prmStatus);
                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.SurveyProcess);
                _trOrderSPLog.EmployeeID = _msSurveyor.EmployeeID;
                _trOrderSPLog.RowStatus = 0;

                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
            }
        }
    }
}
