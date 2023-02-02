using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class SIMCardBL : Base
    {
        public SIMCardBL()
        {
        }

        public MsSIMCard GetSingleSIMCard(Int64 _prmSIMCardID)
        {
            MsSIMCard _result = new MsSIMCard();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@sIMCardID", _prmSIMCardID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsSIMCardBySIMCardID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsSIMCard _msSIMCard = new MsSIMCard();
                _msSIMCard.SIMCardID = (Int64)dr["SIMCardID"];
                _msSIMCard.SIMCardCode = (String)dr["SIMCardCode"];
                _msSIMCard.SIMCardNumber = (dr["SIMCardNumber"] == DBNull.Value) ? "" : (String)dr["SIMCardNumber"];
                _msSIMCard.OperatorID = (Int64)dr["OperatorID"];
                _msSIMCard.PhonePulsa = (dr["PhonePulsa"] == DBNull.Value) ? 0 : (Int32)dr["PhonePulsa"];
                _msSIMCard.InternetPulsa = (dr["InternetPulsa"] == DBNull.Value) ? 0 : (Int32)dr["InternetPulsa"];
                _msSIMCard.NoCheckPulsa = (dr["NoCheckPulsa"] == DBNull.Value) ? 0 : (Int32)dr["NoCheckPulsa"];
                _msSIMCard.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msSIMCard.RowStatus = (Int32)dr["RowStatus"];
                _msSIMCard.CreatedBy = (String)dr["CreatedBy"];
                _msSIMCard.CreatedDate = (DateTime)dr["CreatedDate"];
                _msSIMCard.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msSIMCard.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msSIMCard.Timestamp = (byte[])dr["Timestamp"];
                _msSIMCard.OperatorName = (dr["OperatorName"] == DBNull.Value) ? "" : (String)dr["OperatorName"];

                _result = _msSIMCard;
                dr.Close();
            }

            return _result;
        }

        public List<MsSIMCard> GetListMsSIMCard(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsSIMCard> _result = new List<MsSIMCard>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsSIMCard", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListMsSIMCard", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSIMCard _msSIMCard = new MsSIMCard();
                    _msSIMCard.SIMCardID = (Int64)dr["SIMCardID"];
                    _msSIMCard.SIMCardCode = (String)dr["SIMCardCode"];
                    _msSIMCard.SIMCardNumber = (dr["SIMCardNumber"] == DBNull.Value) ? "" : (String)dr["SIMCardNumber"];
                    _msSIMCard.OperatorName = (dr["OperatorName"] == DBNull.Value) ? "" : (String)dr["OperatorName"];
                    _result.Add(_msSIMCard);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsSIMCard(MsSIMCard _prmSIMCard)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@createdBy", _prmSIMCard.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmSIMCard.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@internetPulsa", _prmSIMCard.InternetPulsa, DbType.Int32));
            _param.Add(new SPParam("@modifiedBy", _prmSIMCard.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmSIMCard.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@noCheckPulsa", _prmSIMCard.NoCheckPulsa, DbType.String));
            _param.Add(new SPParam("@operatorID", _prmSIMCard.OperatorID, DbType.Int64));
            _param.Add(new SPParam("@phonePulsa", _prmSIMCard.PhonePulsa, DbType.Int32));
            _param.Add(new SPParam("@remark", _prmSIMCard.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmSIMCard.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@sIMCardCode", _prmSIMCard.SIMCardCode, DbType.String));
            _param.Add(new SPParam("@sIMCardID", _prmSIMCard.SIMCardID, DbType.Int64));
            _param.Add(new SPParam("@sIMCardNumber", _prmSIMCard.SIMCardNumber, DbType.String));
            _param.Add(new SPParam("@timestamp", _prmSIMCard.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsSIMCard", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsSIMCard(MsSIMCard _prmSIMCard)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@createdBy", _prmSIMCard.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@internetPulsa", _prmSIMCard.InternetPulsa, DbType.Int32));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@noCheckPulsa", _prmSIMCard.NoCheckPulsa, DbType.String));
            _param.Add(new SPParam("@operatorID", _prmSIMCard.OperatorID, DbType.Int64));
            _param.Add(new SPParam("@phonePulsa", _prmSIMCard.PhonePulsa, DbType.Int32));
            _param.Add(new SPParam("@remark", _prmSIMCard.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmSIMCard.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@sIMCardCode", _prmSIMCard.SIMCardCode, DbType.String));
            _param.Add(new SPParam("@sIMCardID", _prmSIMCard.SIMCardID, DbType.Int64));
            _param.Add(new SPParam("@sIMCardNumber", _prmSIMCard.SIMCardNumber, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsSIMCard", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedSIMCard(MsSIMCard _prmSIMCard)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsSIMCard", DbType.String));
            _param.Add(new SPParam("@fieldName", "SIMCardID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmSIMCard.SIMCardID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmSIMCard.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmSIMCard.RowStatus, DbType.Int32));

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
