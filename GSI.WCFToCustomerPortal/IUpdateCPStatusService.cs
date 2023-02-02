using System;
using System.ServiceModel;
using GSI.Common.Enum;

namespace GSI.WCFToCustomerPortal
{
    [ServiceContract]
    public interface IUpdateCPStatusService
    {
        [OperationContract]
        void UpdateStatusCustomerPortal(SurveyPointType _prmSPType, long _prmSPID, GSIInternalStatus _prmStatus, String _prmUserTakeOver);
    }
}
