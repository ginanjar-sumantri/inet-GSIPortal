using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class OperatorBL : Base
    {
        public OperatorBL()
        {
        }

        public MsOperator GetSingleOperator(long _prmOperatorID)
        {
            MsOperator _result = new MsOperator();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@operatorID", _prmOperatorID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsOperatorByOperatorID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsOperator _msOperator = new MsOperator();
                _msOperator.OperatorID = (Int64)dr["OperatorID"];
                _msOperator.OperatorCode = (String)dr["OperatorCode"];
                _msOperator.OperatorName = (dr["OperatorName"] == DBNull.Value) ? "" : (String)dr["OperatorName"];
                _msOperator.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msOperator.RowStatus = (Int32)dr["RowStatus"];
                _msOperator.CreatedBy = (String)dr["CreatedBy"];
                _msOperator.CreatedDate = (DateTime)dr["CreatedDate"];
                _msOperator.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msOperator.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msOperator.Timestamp = (byte[])dr["Timestamp"];

                _result = _msOperator;
                dr.Close();
            }

            return _result;
        }

        public List<MsOperator> GetListOperator()
        {
            List<MsOperator> _result = new List<MsOperator>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsOperator", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsOperator _msOperator = new MsOperator();
                    _msOperator.OperatorID = (Int64)dr["OperatorID"];
                    _msOperator.OperatorCode = (String)dr["OperatorCode"];
                    _msOperator.OperatorName = (dr["OperatorName"] == DBNull.Value) ? "" : (String)dr["OperatorName"];
                    _msOperator.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msOperator.RowStatus = (Int32)dr["RowStatus"];
                    _msOperator.CreatedBy = (String)dr["CreatedBy"];
                    _msOperator.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msOperator.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msOperator.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msOperator.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_msOperator);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsOperator> GetListMsOperator(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsOperator> _result = new List<MsOperator>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsOperator", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsOperator _msOperator = new MsOperator();
                    _msOperator.OperatorID = (Int64)dr["OperatorID"];
                    _msOperator.OperatorCode = (String)dr["OperatorCode"];
                    _msOperator.OperatorName = (dr["OperatorName"] == DBNull.Value) ? "" : (String)dr["OperatorName"];
                    _result.Add(_msOperator);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsOperator(MsOperator _prmOperator)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@createdBy", _prmOperator.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmOperator.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmOperator.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOperator.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@operatorCode", _prmOperator.OperatorCode, DbType.String));
            _param.Add(new SPParam("@operatorID", _prmOperator.OperatorID, DbType.Int64));
            _param.Add(new SPParam("@operatorName", _prmOperator.OperatorName, DbType.String));
            _param.Add(new SPParam("@remark", _prmOperator.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOperator.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmOperator.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsOperator", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsOperator(MsOperator _prmOperator)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@createdBy", _prmOperator.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@OperatorCode", _prmOperator.OperatorCode, DbType.String));
            _param.Add(new SPParam("@OperatorID", _prmOperator.OperatorID, DbType.Int64));
            _param.Add(new SPParam("@operatorName", _prmOperator.OperatorName, DbType.String));
            _param.Add(new SPParam("@remark", _prmOperator.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOperator.RowStatus, DbType.Int32));
            
            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsOperator", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedOperator(MsOperator _prmOperator)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsOperator", DbType.String));
            _param.Add(new SPParam("@fieldName", "OperatorID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmOperator.OperatorID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmOperator.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOperator.RowStatus, DbType.Int32));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
            if (_success)
            {
                ErrorHandler.ErrorMessage = Convert.ToString(_paramOut[0].Value);
                _result = (int)data;
            }

            return _result;
        }
    }
}
