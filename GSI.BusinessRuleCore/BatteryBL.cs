using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class BatteryBL : Base
    {
        public BatteryBL()
        {
        }

        public List<MsBattery> GetListMsBattery(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsBattery> _result = new List<MsBattery>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsBattery", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsBattery", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsBattery _msBattery = new MsBattery();
                    _msBattery.BatteryID = (Int64)dr["BatteryID"];
                    _msBattery.BatteryCode = (String)dr["BatteryCode"];
                    _msBattery.BatteryName = (String)dr["BatteryName"];
                    _msBattery.BatteryType = (Byte)dr["BatteryType"];
                    _msBattery.Ampere = (int)dr["Ampere"];
                    _msBattery.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? String.Empty : (String)dr["SerialNumber"];
                    _result.Add(_msBattery);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public MsBattery GetSingleMsBatteryByBatteryID(Int64 _prmBatteryID)
        {
            MsBattery _result = new MsBattery();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@BatteryID", _prmBatteryID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsBatteryByBatteryID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsBattery _msBattery = new MsBattery();
                    _msBattery.BatteryID = (Int64)dr["BatteryID"];
                    _msBattery.BatteryCode = (String)dr["BatteryCode"];
                    _msBattery.BatteryName = (String)dr["BatteryName"];
                    _msBattery.BatteryType = (Byte)dr["BatteryType"];
                    _msBattery.Ampere = (int)dr["Ampere"];
                    _msBattery.SerialNumber = (dr["SerialNumber"] == DBNull.Value) ? String.Empty : (String)dr["SerialNumber"];
                    _msBattery.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msBattery.RowStatus = (Int32)dr["RowStatus"];
                    _msBattery.CreatedBy = (String)dr["CreatedBy"];
                    _msBattery.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msBattery.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msBattery.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msBattery.Timestamp = (byte[])dr["Timestamp"];

                    _result = _msBattery;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsBattery(MsBattery _prmBattery)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@ampere", _prmBattery.Ampere, DbType.Int32));
            _param.Add(new SPParam("@batteryCode", _prmBattery.BatteryCode, DbType.String));
            _param.Add(new SPParam("@batteryID", _prmBattery.BatteryID, DbType.Int64));
            _param.Add(new SPParam("@batteryName", _prmBattery.BatteryName, DbType.String));
            _param.Add(new SPParam("@batteryType", _prmBattery.BatteryType, DbType.Byte));
            _param.Add(new SPParam("@createdBy", _prmBattery.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmBattery.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmBattery.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmBattery.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmBattery.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmBattery.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@serialNumber", _prmBattery.SerialNumber, DbType.String));
            _param.Add(new SPParam("@timestamp", _prmBattery.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsBattery", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsBattery(MsBattery _prmMsBattery)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@ampere", _prmMsBattery.Ampere, DbType.Int32));
            _param.Add(new SPParam("@batteryCode", _prmMsBattery.BatteryCode, DbType.String));
            _param.Add(new SPParam("@batteryID", _prmMsBattery.BatteryID, DbType.Int64));
            _param.Add(new SPParam("@batteryName", _prmMsBattery.BatteryName, DbType.String));
            _param.Add(new SPParam("@batteryType", _prmMsBattery.BatteryType, DbType.Byte));
            _param.Add(new SPParam("@createdBy", _prmMsBattery.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmMsBattery.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsBattery.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@serialNumber", _prmMsBattery.SerialNumber, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsBattery", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedBattery(MsBattery _prmBattery)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsBattery", DbType.String));
            _param.Add(new SPParam("@fieldName", "BatteryID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmBattery.BatteryID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmBattery.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmBattery.RowStatus, DbType.Int32));

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
