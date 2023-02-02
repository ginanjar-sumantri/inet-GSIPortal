using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class BusinessTypeBL : Base
    {
        public BusinessTypeBL()
        {
        }

        public MsBusinessType GetSingleBusinessType(long _prmBusinessTypeID)
        {
            MsBusinessType _result = new MsBusinessType();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("businessTypeID", _prmBusinessTypeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsBusinessTypeByBusinessTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsBusinessType _msBusinessType = new MsBusinessType();
                _msBusinessType.BusinessTypeID = (long)dr["BusinessTypeID"];
                _msBusinessType.BusinessTypeCode = (dr["BusinessTypeCode"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeCode"];
                _msBusinessType.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];
                _msBusinessType.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msBusinessType.RowStatus = (int)dr["RowStatus"];
                _msBusinessType.CreatedBy = (String)dr["CreatedBy"];
                _msBusinessType.CreatedDate = (DateTime)dr["CreatedDate"];
                _msBusinessType.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msBusinessType.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msBusinessType.Timestamp = (byte[])dr["Timestamp"];

                _result = _msBusinessType;
                dr.Close();
            }

            return _result;
        }

        public MsBusinessType GetBusinessTypeByCode(long _prmDocumentType)
        {
            MsBusinessType _result = new MsBusinessType();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@businessTypeID", _prmDocumentType, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsBusinessTypeByBusinessTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    MsBusinessType _msDocumentType = new MsBusinessType();
                    _msDocumentType.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];

                    _result = _msDocumentType;
                }
            }

            return _result;
        }

        public MsBusinessType GetBusinessTypeNameByBusinessTypeID(long _prmBusinessTypeID)
        {
            MsBusinessType _result = new MsBusinessType();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@businessTypeID", _prmBusinessTypeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetBusinessTypeNameByBusinessTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsBusinessType _msBusinessType = new MsBusinessType();                
                _msBusinessType.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];                

                _result = _msBusinessType;
            }

            return _result;
        }

        ~BusinessTypeBL()
        {
        }
    }
}
