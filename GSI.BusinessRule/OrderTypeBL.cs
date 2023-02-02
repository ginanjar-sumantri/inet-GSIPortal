using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class OrderTypeBL : Base
    {
        public OrderTypeBL()
        {
        }

        public List<MsOrderType> GetListOrderType()
        {
            List<MsOrderType> _result = new List<MsOrderType>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();            
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsOrderType", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsOrderType _order = new MsOrderType();
                    _order.OrderTypeID = (long)dr["OrderTypeID"];
                    _order.OrderTypeName = (dr["OrderTypeName"] == DBNull.Value) ? "" : (String)dr["OrderTypeName"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        ~OrderTypeBL()
        {
        }
    }
}
