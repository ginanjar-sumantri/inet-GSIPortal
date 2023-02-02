using System.Collections.Generic;
using System.ServiceModel;
using System;

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

        [OperationContract]
        void UpdateMsRegionZipCode(List<MsRegionZipCode> _prmMsRegionZipCode);
    
		[OperationContract]
		void DoWork();

        [OperationContract]
        List<Gen_LoginHistory> GetListGenLoginHistory(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmFieldName, Int64 _prmFieldValue, String _prmOrderBy, String _prmAscDesc, ref Int32 _countData);
	}
}
