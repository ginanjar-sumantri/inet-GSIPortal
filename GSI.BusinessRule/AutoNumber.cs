using System;
using System.Data;
using System.Collections.Generic;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessEntity.BusinessEntities;


namespace GSI.BusinessRule
{
    public class AutoNumber
    {
        public String GetAutoNumberOrder(long _prmCustID)
        {
            String _orderCode = "";
            String _customerCode = "";
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@custID", _prmCustID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetOrderCodeByCustID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                //dr.Read();
                if (dr.Read())
                {
                    _orderCode = (String)dr["OrderCode"];
                    if (_orderCode == "")
                    {
                        _orderCode = "//0/";
                    }
                    _customerCode = (String)dr["CustomerCode"];
                }
                else
                {
                    return "Unable to Generate Auto Number";
                }
            }

            String _result = "";
            int digit = 5;
            String[] _codeSplit = _orderCode.Split('/'); //custcode, ORD, number, year

            String _nextNumber = (Convert.ToInt32(_codeSplit[2]) + 1).ToString().PadLeft(digit, '0');

            _result = _customerCode + "/" + "ORD" + "/" + _nextNumber + "/" + DateTime.Now.Year.ToString();

            return _result;
        }

        public String GetAutoNumberWorkOrder(SurveyPointType _prmSPType)
        {
            byte _spType = 0;
            String _spPrefixCode = "";
            if (_prmSPType == SurveyPointType.Movable)
            {
                _spType = 0;
            }
            else
            {
                _spType = 1;
            }
            _spPrefixCode = SPTypeMapper.GetSPType(_prmSPType);
            
            //WO/Mov/000001/2011
            //WO/NMov/000001/2011

            String _woCode = "";

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@spType", _spType, DbType.Byte));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetWorkOrderCodeBySPType", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                //dr.Read();
                if (dr.Read())
                {
                    _woCode = (String)dr["WorkOrderCode"];
                    if (_woCode == "")
                    {
                        _woCode = "//0/";
                    }
                }
                else
                {
                    _woCode = "//0/";
                }
            }

            String _result = "";
            int digit = 6;
            String[] _codeSplit = _woCode.Split('/'); //WO, SPType, number, year

            String _nextNumber = (Convert.ToInt32(_codeSplit[2]) + 1).ToString().PadLeft(digit, '0');

            _result = "WO/" + _spPrefixCode + "/" + _nextNumber + "/" + DateTime.Now.Year.ToString();

            return _result;
        }
    }
}
