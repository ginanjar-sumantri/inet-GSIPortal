using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class GadgetBL : Base
    {
        public GadgetBL()
        {
        }

        public MsGadget GetSingleGadget(long _prmGadgetID)
        {
            MsGadget _result = new MsGadget();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@gadgetID", _prmGadgetID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsGadgetByGadgetID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsGadget _msGadget = new MsGadget();
                _msGadget.GadgetID = (Int64)dr["GadgetID"];
                _msGadget.GadgetCode = (String)dr["GadgetCode"];
                _msGadget.GadgetName = (dr["GadgetName"] == DBNull.Value) ? "" : (String)dr["GadgetName"];
                _msGadget.BrandID = (Int64)dr["BrandID"];
                _msGadget.NoIMEI = (dr["NoIMEI"] == DBNull.Value) ? "" : (String)dr["NoIMEI"];
                _msGadget.SIMCardID = (Int64)dr["SIMCardID"];
                _msGadget.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msGadget.CreatedBy = (String)dr["CreatedBy"];
                _msGadget.CreatedDate = (DateTime)dr["CreatedDate"];
                _msGadget.Timestamp = (byte[])dr["Timestamp"];
                _result = _msGadget;
                dr.Close();
            }

            return _result;
        }

        public List<MsGadget> GetListGadget(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsGadget> _result = new List<MsGadget>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsGadget", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListMsGadget", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsGadget _msGadget = new MsGadget();
                    _msGadget.GadgetID = (Int64)dr["GadgetID"];
                    _msGadget.GadgetCode = (String)dr["GadgetCode"];
                    _msGadget.GadgetName = (dr["GadgetName"] == DBNull.Value) ? "" : (String)dr["GadgetName"];
                    _msGadget.BrandName = (dr["BrandName"] == DBNull.Value) ? String.Empty : (String)dr["BrandName"];
                    _msGadget.NoIMEI = (dr["NoIMEI"] == DBNull.Value) ? "" : (String)dr["NoIMEI"];
                    _msGadget.SIMCardNumber = (dr["SIMCardNumber"] == DBNull.Value) ? "" : (String)dr["SIMCardNumber"];
                    _result.Add(_msGadget);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public int DeletedGadget(MsGadget _prmGadget)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsGadget", DbType.String));
            _param.Add(new SPParam("@fieldName", "GadgetID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmGadget.GadgetID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmGadget.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmGadget.RowStatus, DbType.Int32));

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

        public Boolean UpdateMsGadget(MsGadget _prmGadget)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@brandID", _prmGadget.BrandID, DbType.Int64));
            _param.Add(new SPParam("@createdBy", _prmGadget.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmGadget.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@gadgetCode", _prmGadget.GadgetCode, DbType.String));
            _param.Add(new SPParam("@gadgetID", _prmGadget.GadgetID, DbType.Int64));
            _param.Add(new SPParam("@gadgetName", _prmGadget.GadgetName, DbType.String));
            _param.Add(new SPParam("@modifiedBy", _prmGadget.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmGadget.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@noIMEI", _prmGadget.NoIMEI, DbType.String));
            _param.Add(new SPParam("@remark", _prmGadget.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmGadget.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@sIMCardID", _prmGadget.SIMCardID, DbType.Int64));
            _param.Add(new SPParam("@timestamp", _prmGadget.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsGadget", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsGadget(MsGadget _prmGadget)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@brandID", _prmGadget.BrandID, DbType.Int64));
            _param.Add(new SPParam("@createdBy", _prmGadget.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@gadgetCode", _prmGadget.GadgetCode, DbType.String));
            _param.Add(new SPParam("@gadgetID", _prmGadget.GadgetID, DbType.Int64));
            _param.Add(new SPParam("@gadgetName", _prmGadget.GadgetName, DbType.String));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@noIMEI", _prmGadget.NoIMEI, DbType.String));
            _param.Add(new SPParam("@remark", _prmGadget.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmGadget.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@sIMCardID", _prmGadget.SIMCardID, DbType.Int64));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsGadget", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }
    }
}
