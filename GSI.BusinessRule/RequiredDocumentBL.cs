using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class RequiredDocumentBL : Base
    {
        public List<ReqDocument> GetListDocTypeByOrderSPIDNotMovable(Int64 _prmOrderSPNotMovableID)
        {
            List<ReqDocument> _result = new List<ReqDocument>();
            
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMoveableID", _prmOrderSPNotMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetDocTypeNotMovablebyOrderSPNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    ReqDocument _resultMoveable = new ReqDocument();

                    _resultMoveable.DocumentTypeID = (long)dr["DocumentTypeID"];
                    _resultMoveable.DocumentName = (String)dr["DocumentTypeName"];

                    _result.Add(_resultMoveable);
                }
                dr.Close();
            }

            return _result;
        }

        public List<ReqDocument> GetListDocTypeByOrderSPIDMovable(Int64 _prmOrderSPMovableID)
        {
            List<ReqDocument> _result = new List<ReqDocument>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPMoveableID", _prmOrderSPMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetDocTypeMovablebyOrderSPMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    ReqDocument _resultMoveable = new ReqDocument();

                    _resultMoveable.DocumentTypeID = (long)dr["DocumentTypeID"];
                    _resultMoveable.DocumentName = (String)dr["DocumentTypeName"];

                    _result.Add(_resultMoveable);
                }
                dr.Close();
            }

            return _result;
        }

        
    }
}
