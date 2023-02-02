using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class RegionBL : Base
    {
        public RegionBL()
        {
        }

        public List<MsRegion> GetListRegionForDDL(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsRegion> _result = new List<MsRegion>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsRegion", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsRegion", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsRegion _msRegion = new MsRegion();
                    _msRegion.RegionID = (long)dr["RegionID"];
                    _msRegion.RegionCode = (String)dr["RegionCode"];
                    _msRegion.RegionName = (dr["RegionName"] == DBNull.Value) ? "" : (String)dr["RegionName"];
                    _result.Add(_msRegion);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public MsRegion GetMsRegionByRegionId(long _prmRegionID)
        {
            MsRegion _result = new MsRegion();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@regionID", _prmRegionID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsRegionByRegionID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    MsRegion _msRegion = new MsRegion();
                    _msRegion.RegionID = (Int64)dr["RegionID"];
                    _msRegion.RegionCode = (String)dr["RegionCode"];
                    _msRegion.RegionName = (dr["RegionName"] == DBNull.Value) ? "" : (String)dr["RegionName"];
                    _msRegion.CreatedBy = (String)dr["CreatedBy"];
                    _msRegion.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msRegion.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msRegion.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msRegion.Timestamp = (byte[])dr["Timestamp"];
                    _result = _msRegion;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsRegion(MsRegion _prmRegion)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@createdBy", _prmRegion.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmRegion.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmRegion.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmRegion.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@regionID", _prmRegion.RegionID, DbType.Int64));
            _param.Add(new SPParam("@regionCode", _prmRegion.RegionCode, DbType.String));
            _param.Add(new SPParam("@regionName", _prmRegion.RegionName, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmRegion.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmRegion.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsRegion", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsRegion(MsRegion _prmMsRegion)
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
            _param.Add(new SPParam("@regionCode", _prmMsRegion.RegionCode, DbType.String));
            _param.Add(new SPParam("@regionID", _prmMsRegion.RegionID, DbType.String));
            _param.Add(new SPParam("@regionName", _prmMsRegion.RegionName, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsRegion.RowStatus, DbType.Int32));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsRegion", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedRegion(MsRegion _prmRegion)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsRegion", DbType.String));
            _param.Add(new SPParam("@fieldName", "RegionID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmRegion.RegionID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmRegion.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmRegion.RowStatus, DbType.Int32));

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

        public List<MsRegion> GetListRegionDDLForWorkAssign()
        {
            List<MsRegion> _result = new List<MsRegion>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsRegionJoinMsSurveyor", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsRegion _msRegion = new MsRegion();
                    _msRegion.RegionID = (long)dr["RegionID"];
                    _msRegion.RegionCode = (String)dr["RegionCode"];
                    _msRegion.RegionName = (dr["RegionName"] == DBNull.Value) ? "" : (String)dr["RegionName"];

                    _result.Add(_msRegion);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsRegion> GetListMsRegion()
        {
            List<MsRegion> _result = new List<MsRegion>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsRegion", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsRegion _msRegion = new MsRegion();
                    _msRegion.RegionID = (Int64)dr["RegionID"];
                    _msRegion.RegionCode = (String)dr["RegionCode"];
                    _msRegion.RegionName = (dr["RegionName"] == DBNull.Value) ? "" : (String)dr["RegionName"];
                    _msRegion.CreatedBy = (dr["CreatedBy"] == DBNull.Value) ? "" : (String)dr["CreatedBy"];
                    _msRegion.CreatedDate = (dr["CreatedDate"] == DBNull.Value) ? _defaultDate : (DateTime)dr["CreatedDate"];
                    _msRegion.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                    _msRegion.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? _defaultDate : (DateTime)dr["ModifiedDate"];
                    _msRegion.RowStatus = (Int32)dr["RowStatus"];
                    _result.Add(_msRegion);
                }
                dr.Close();
            }

            return _result;
        }

        ~RegionBL()
        {
        }
    }
}