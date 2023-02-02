using System.Collections.Generic;
using System.ServiceModel;

namespace GSI.WCFToCustomerPortal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdateResultService" in both code and config file together.
    [ServiceContract]
    public interface IUpdateCPResultService
    {
        [OperationContract]
        void UpdateResultMovableCustomerPortal(TrWorkOrderMovable _prmWorkOrderMovable, TrResultMovable _prmResultMovable, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable, List<TrResultReqDocMovable> _prmResultReqDocMovableList);

        [OperationContract]
        void UpdateResultNotMovableCustomerPortal(TrWorkOrderNotMovable _prmWorkOrderNotMovable, TrResultNotMovable _prmResultNotMovable, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList);
    }
}
