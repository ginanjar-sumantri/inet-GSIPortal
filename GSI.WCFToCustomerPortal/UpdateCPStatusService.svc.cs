using System;
using GSI.Common.Enum;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.BusinessEntity.BusinessEntities;
using GSI.DataMapping;

namespace GSI.WCFToCustomerPortal
{
    public class UpdateCPStatusService : IUpdateCPStatusService
    {
        public void UpdateStatusCustomerPortal(SurveyPointType _prmSPType, long _prmSPID, GSIInternalStatus _prmStatus, String _prmUserTakeOver)
        {
            OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

            if (_prmSPType == SurveyPointType.Movable)
            {
                GSI.BusinessEntity.BusinessEntities.TrOrderSPMovable _orderSP = _orderSPBL.GetSingleTrOrderMovable(_prmSPID);
                _orderSP.UserTakeOver = _prmUserTakeOver;
                _orderSP.SPStatus = StatusMapper.GetStatusInternal(_prmStatus);
                if (_prmStatus == GSIInternalStatus.Cancelled)
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                else
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

                _orderSPBL.UpdateTrOrderSPMovable(_orderSP);

                OrderBL _orderBL = new OrderBL();
                if (_orderBL.IsOrderSurveyPointAllComplete(_orderSP.OrderID))
                {
                    GSI.BusinessEntity.BusinessEntities.TrOrder _order = _orderBL.GetSingleOrderByOrderID(_orderSP.OrderID);
                    _order.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed);
                    _orderBL.UpdateOrder(_order);
                }
            }
            else
            {
                GSI.BusinessEntity.BusinessEntities.TrOrderSPNotMovable _orderSP = _orderSPBL.GetSingleTrOrderNotMovable(_prmSPID);
                _orderSP.UserTakeOver = _prmUserTakeOver;
                _orderSP.SPStatus = StatusMapper.GetStatusInternal(_prmStatus);
                if (_prmStatus == GSIInternalStatus.Cancelled)
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Cancelled);
                else
                    _orderSP.CancelStatus = CancelStatusMapper.GetCancelStatus(CancelStatusEnum.Normal);

                _orderSPBL.UpdateTrOrderSPNotMovable(_orderSP);

                OrderBL _orderBL = new OrderBL();
                if (_orderBL.IsOrderSurveyPointAllComplete(_orderSP.OrderID))
                {
                    GSI.BusinessEntity.BusinessEntities.TrOrder _order = _orderBL.GetSingleOrderByOrderID(_orderSP.OrderID);
                    _order.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed);
                    _orderBL.UpdateOrder(_order);
                }
            }
        }
    }
}
