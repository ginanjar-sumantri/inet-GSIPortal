using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class RegionZipCodeBL : Base
    {
        public RegionZipCodeBL()
        {
        }

        public List<MsRegionZipCode> GetListRegionZipCode()
        {
            List<MsRegionZipCode> _result = new List<MsRegionZipCode>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsRegionZipCode", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsRegionZipCode _msRegionZipCode = new MsRegionZipCode();
                    _msRegionZipCode.RegionID = (Int64)dr["RegionID"];
                    _msRegionZipCode.ZipCode = (dr["ZipCode"] == DBNull.Value) ? "" : (String)dr["ZipCode"];
                    _msRegionZipCode.RegionZipCodeID = (Int64)dr["RegionZipCodeID"];
                    _msRegionZipCode.CreatedBy = (dr["CreatedBy"] == DBNull.Value) ? "" : (String)dr["CreatedBy"];
                    _msRegionZipCode.CreatedDate = (dr["CreatedDate"] == DBNull.Value) ? _defaultDate : (DateTime)dr["CreatedDate"];
                    _msRegionZipCode.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                    _msRegionZipCode.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? _defaultDate : (DateTime)dr["ModifiedDate"];
                    _msRegionZipCode.RowStatus = (Int32)dr["RowStatus"];
                    _result.Add(_msRegionZipCode);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsRegionZipCode> GetListZipCodeDDLByRegionID(long _prmRegionID)
        {
            List<MsRegionZipCode> _result = new List<MsRegionZipCode>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@regionID", _prmRegionID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsRegionZipCodebyRegionID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsRegionZipCode _msRegion = new MsRegionZipCode();
                    _msRegion.RegionID = (long)dr["RegionID"];
                    _msRegion.RegionZipCodeID = (long)dr["RegionZipCodeID"];
                    _msRegion.ZipCode = (dr["ZipCode"] == DBNull.Value) ? "" : (String)dr["ZipCode"];
                    _result.Add(_msRegion);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsRegionZipCode> GetListZipCodeByRegion(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc, Int64 _prmRegionID)
        {
            List<MsRegionZipCode> _result = new List<MsRegionZipCode>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsRegionZipCode", DbType.String));
            _param.Add(new SPParam("@fieldName", "RegionID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmRegionID, DbType.Int64));
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
                    MsRegionZipCode _msRegion = new MsRegionZipCode();
                    _msRegion.RegionID = (long)dr["RegionID"];
                    _msRegion.RegionZipCodeID = (long)dr["RegionZipCodeID"];
                    _msRegion.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _result.Add(_msRegion);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public MsRegionZipCode GetRegionZipCodeByRegionZipCodeId(long _prmRegionnZipCodeID)
        {
            MsRegionZipCode _result = new MsRegionZipCode();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@regionZipCodeID", _prmRegionnZipCodeID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsRegionZipCodeByRegionZipCodeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    MsRegionZipCode _msRegionZipCode = new MsRegionZipCode();
                    _msRegionZipCode.RegionID = (Int64)dr["RegionID"];
                    _msRegionZipCode.RegionZipCodeID = (Int64)dr["RegionZipCodeID"];
                    _msRegionZipCode.ZipCode = (dr["ZipCode"] == DBNull.Value) ? "" : (String)dr["ZipCode"];
                    _msRegionZipCode.CreatedBy = (String)dr["CreatedBy"];
                    _msRegionZipCode.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msRegionZipCode.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msRegionZipCode.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msRegionZipCode.Timestamp = (byte[])dr["Timestamp"];
                    _result = _msRegionZipCode;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsRegionZipCode(MsRegionZipCode _prmRegionZipCode)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@createdBy", _prmRegionZipCode.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmRegionZipCode.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmRegionZipCode.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmRegionZipCode.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@regionID", _prmRegionZipCode.RegionID, DbType.Int64));
            _param.Add(new SPParam("@regionZipCodeID", _prmRegionZipCode.RegionZipCodeID, DbType.Int64));
            _param.Add(new SPParam("@zipCode", _prmRegionZipCode.ZipCode, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmRegionZipCode.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmRegionZipCode.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_UpdateMsRegionZipCode", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsRegionZipCode(MsRegionZipCode _prmMsRegion)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@createdBy", _prmMsRegion.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@ZipCode", _prmMsRegion.ZipCode, DbType.String));
            _param.Add(new SPParam("@regionID", _prmMsRegion.RegionID, DbType.Int64));
            _param.Add(new SPParam("@regionZipCodeID", _prmMsRegion.RegionZipCodeID, DbType.Int64));
            _param.Add(new SPParam("@rowStatus", _prmMsRegion.RowStatus, DbType.Int32));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsRegionZipCode", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedRegionZipCode(MsRegionZipCode _prmRegionZipCode)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsRegionZipCode", DbType.String));
            _param.Add(new SPParam("@fieldName", "RegionZipCodeID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmRegionZipCode.RegionZipCodeID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmRegionZipCode.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmRegionZipCode.RowStatus, DbType.Int32));

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

        ~RegionZipCodeBL()
        {
        }
    }
}