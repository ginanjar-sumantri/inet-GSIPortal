using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GSI.WCFToCoreSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Boolean UpdateToCoreSystem(TrOrder _trOrder,
            List<TrOrderSPMovable> _trOrderSPMovable,
            List<TrOrderSPNotMovable> _trOrderSPNotMovable,
            List<TrReqDocMovable> _trReqDocMovable,
            List<TrReqDocNotMovable> _trReqDocNotMovable,            
            ref String _prmErr);

        [OperationContract]
        Boolean ComplaintResultNotMovable(TrOrderSPNotMovable _trOrderSPNotMovable, ref String _prmErr);

        [OperationContract]
        Boolean ComplaintResultMovable(TrOrderSPMovable _trOrderSPMovable, ref String _prmErr);

        [OperationContract]
        List<TrOrderSPLog> GetListTrOrderSPLogByOrderIDSurveyPointType(long _prmOrderSPID, long _prmSurveyPointType);
    }
}
