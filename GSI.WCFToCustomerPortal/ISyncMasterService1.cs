using System.Collections.Generic;
using System.ServiceModel;

namespace GSI.WCFToCustomerPortal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISyncMasterService" in both code and config file together.
    [ServiceContract]
    public interface ISyncMasterService
    {
        [OperationContract]
        void UpdateMsRegion(List<MsRegion> _prmMsRegion);

        [OperationContract]
        void UpdateMsCustomer(List<MsCustomer> _prmMsCustomer);

        [OperationContract]
        void UpdateMsCustomerUser(List<MsCustomerUser> _prmMsCustomerUser);
    }
}
