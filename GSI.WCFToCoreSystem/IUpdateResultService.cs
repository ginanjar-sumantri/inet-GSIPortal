using System.Collections.Generic;
using System.ServiceModel;

namespace GSI.WCFToCoreSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpdateResultService" in both code and config file together.
    [ServiceContract]
    public interface IUpdateResultService
    {
        [OperationContract]
        bool InsertResultMovableCoreSystemBundle(TrResultMovable _prmResultMovable, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable, List<TrResultReqDocMovable> _prmResultReqDocMovableList, ref string _errMessage);

        [OperationContract]
        void InsertResultMovableCoreSystem(TrResultMovable _prmResultMovable, ref long _resultID);

        [OperationContract]
        void InsertResultPhotoAddtMovableCoreSystem(long _resultID, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable);

        [OperationContract]
        void InsertResultReqDocMovableCoreSystem(long _resultID, List<TrResultReqDocMovable> _prmResultReqDocMovableList);

        [OperationContract]
        bool InsertResultNotMovableCoreSystemBundle(TrResultNotMovable _prmResultNotMovable, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList, ref string _errMessage);

        [OperationContract]
        void InsertResultNotMovableCoreSystem(TrResultNotMovable _prmResultNotMovable, ref long _resultID);

        [OperationContract]
        void InsertResultPhotoAddtNotMovableCoreSystem(long _resultID, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable);

        [OperationContract]
        void InsertResultReqDocNotMovableCoreSystem(long _resultID, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList);
    }
}
