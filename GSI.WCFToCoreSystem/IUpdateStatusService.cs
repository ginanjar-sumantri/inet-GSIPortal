using System;
using System.ServiceModel;
using GSI.Common.Enum;

namespace GSI.WCFToCoreSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdateStatusService" in both code and config file together.
    [ServiceContract]
    public interface IUpdateStatusService
    {
        [OperationContract]
        void UpdateStatusCoreSystem(SurveyPointType _prmSPType, Int64 _prmWorkOrderID, GSIInternalStatus _prmStatus, DateTime _prmDate);
    }
}
