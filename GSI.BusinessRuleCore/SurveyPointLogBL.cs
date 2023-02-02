using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;

namespace GSI.BusinessRuleCore
{
    public class SurveyPointLogBL : Base
    {
        public SurveyPointLogBL()
        {
        }

        public TrOrderSPLog GetSingleTrOrderSPLogByOrderSPIDAndSPType(long _prmOrderSPID, long _prmSurveyPointType)
        {
            TrOrderSPLog _result = null;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointType", _prmSurveyPointType, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrOrderSPLogByOrderSPIDAndSPType", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                    _trOrderSPLog.CreatedBy = (String)dr["CreatedBy"];
                    _trOrderSPLog.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trOrderSPLog.DateTime = (DateTime)dr["DateTime"];
                    _trOrderSPLog.Duration = (Int32)dr["Duration"];
                    _trOrderSPLog.EmployeeID = (Int64)dr["EmployeeID"];
                    _trOrderSPLog.LogID = (Int64)dr["LogID"];
                    _trOrderSPLog.ModifiedBy = (String)dr["ModifiedBy"];
                    _trOrderSPLog.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trOrderSPLog.OrderSPID = (Int64)dr["OrderSPID"];
                    _trOrderSPLog.RowStatus = (Int32)dr["RowStatus"];
                    _trOrderSPLog.Status = (Byte)dr["Status"];
                    _trOrderSPLog.SurveyPointType = (Int64)dr["SurveyPointType"];
                    _trOrderSPLog.Timestamp = (byte[])dr["Timestamp"];
                    _trOrderSPLog.TypeProcess = (Byte)dr["TypeProcess"];
                    _result = _trOrderSPLog;
                }
                dr.Close();
            }

            return _result;
        }

        public int InsertTrOrderSPLog(TrOrderSPLog _prmTrOrderSPLog)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@logID", null, DbType.Int64));

            bool _success = false;

            _param.Add(new SPParam("@createdBy", _prmTrOrderSPLog.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmTrOrderSPLog.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@surveyPointType", _prmTrOrderSPLog.SurveyPointType, DbType.Int64));
            _param.Add(new SPParam("@orderSPID", _prmTrOrderSPLog.OrderSPID, DbType.Int64));
            _param.Add(new SPParam("@dateTime", _prmTrOrderSPLog.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@duration", _prmTrOrderSPLog.Duration, DbType.Int32));
            _param.Add(new SPParam("@status", _prmTrOrderSPLog.Status, DbType.Byte));
            _param.Add(new SPParam("@typeProcess", _prmTrOrderSPLog.TypeProcess, DbType.Byte));
            _param.Add(new SPParam("@employeeID", _prmTrOrderSPLog.EmployeeID, DbType.Int64));
            _param.Add(new SPParam("@rowStatus", _prmTrOrderSPLog.RowStatus, DbType.Int32));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrderSPLog", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int GetDurationForSLA(long _prmOrderSPID, long _prmSurveyPoint)
        {
            int _result = 0;
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointType", _prmSurveyPoint, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetDurationTrOrderSPLogByOrderSPID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    _result = (dr["Duration"] == DBNull.Value) ? 0 : (Int32)dr["Duration"];
                }
                dr.Close();
            }
            return _result;
        }

        public int GetDurationFromLastLogAction(long _prmSurveyPointType, long _prmOrderSPID, DateTime _prmDate)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@SurveyPointType", _prmSurveyPointType, DbType.Int64));
            _param.Add(new SPParam("@OrderSPID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@Date", _prmDate, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetDurationFromLastLogAction", _param, ref _paramOut, ref data);
            if (_success == true)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                _result = (dr["Duration"] == DBNull.Value) ? 0 : (int)dr["Duration"];
                dr.Close();
            }

            return _result;
        }
    }
}
