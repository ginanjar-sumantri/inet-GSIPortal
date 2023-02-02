using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using System.Transactions;

namespace GSI.BusinessRuleCore
{
    public class BrandBL : Base
    {
        public BrandBL()
        {
        }

        public List<MsBrand> GetListMsBrand(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsBrand> _result = new List<MsBrand>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsBrand", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsBrand", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsBrand _msBrand = new MsBrand();
                    _msBrand.BrandID = (Int64)dr["BrandID"];
                    _msBrand.BrandCode = (String)dr["BrandCode"];
                    _msBrand.BrandName = (dr["BrandName"] == DBNull.Value) ? String.Empty : (String)dr["BrandName"];
                    _msBrand.BrandType = (Byte)dr["BrandType"];
                    _result.Add(_msBrand);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public MsBrand GetSingleMsBrandByBrandID(Int64 _prmBrandID)
        {
            MsBrand _result = new MsBrand();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@BrandID", _prmBrandID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsBrandByBrandID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsBrand _msBrand = new MsBrand();
                    _msBrand.BrandID = (Int64)dr["BrandID"];
                    _msBrand.BrandCode = (String)dr["BrandCode"];
                    _msBrand.BrandName = (dr["BrandName"] == DBNull.Value) ? String.Empty : (String)dr["BrandName"];
                    _msBrand.BrandType = (Byte)dr["BrandType"];
                    _msBrand.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msBrand.RowStatus = (Int32)dr["RowStatus"];
                    _msBrand.CreatedBy = (String)dr["CreatedBy"];
                    _msBrand.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msBrand.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msBrand.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msBrand.Timestamp = (byte[])dr["Timestamp"];
                    _result = _msBrand;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsBrand(MsBrand _prmBrand)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@brandCode", _prmBrand.BrandCode, DbType.String));
            _param.Add(new SPParam("@brandID", _prmBrand.BrandID, DbType.Int64));
            _param.Add(new SPParam("@brandName", _prmBrand.BrandName, DbType.String));
            _param.Add(new SPParam("@brandType", _prmBrand.BrandType, DbType.Byte));
            _param.Add(new SPParam("@createdBy", _prmBrand.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmBrand.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmBrand.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmBrand.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmBrand.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmBrand.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmBrand.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsBrand", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsBrand(MsBrand _prmMsBrand)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    _param.Add(new SPParam("@brandCode", _prmMsBrand.BrandCode, DbType.String));
                    _param.Add(new SPParam("@brandID", _prmMsBrand.BrandID, DbType.Int64));
                    _param.Add(new SPParam("@brandName", _prmMsBrand.BrandName, DbType.String));
                    _param.Add(new SPParam("@brandType", _prmMsBrand.BrandType, DbType.Byte));
                    _param.Add(new SPParam("@createdBy", _prmMsBrand.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
                    _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@remark", _prmMsBrand.Remark, DbType.String));
                    _param.Add(new SPParam("@rowStatus", _prmMsBrand.RowStatus, DbType.Int32));
                    _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsBrand", _param, ref _paramOut, ref data);

                    if (_success == true)
                    {
                        _result = (int)data;
                    }

                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage = ex.Message;
                }
            }

            return _result;
        }

        //public int DeletedBrand(MsBrand _prmBrand)
        //{
        //    int _result = 0;

        //    object data = null;
        //    List<SPParam> _param = new List<SPParam>();            

        //    using (TransactionScope _scope = new TransactionScope())
        //    {
        //        try
        //        {

        //            _param.Add(new SPParam("@IDS", _prmBrand.BrandID, DbType.Object));
        //            _param.Add(new SPParam("@userName", _prmBrand.ModifiedBy, DbType.String));
        //            //_param.Add(new SPParam("@rowStatus", _prmBrand.RowStatus, DbType.Int32));
        //            //_param.Add(new SPParam("@tableName", "MsBrand", DbType.Object));
        //            //_param.Add(new SPParam("@fieldName", "BrandID", DbType.String));

        //            List<SPParamOut> _paramOut = new List<SPParamOut>();
        //            //_paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

        //            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "gsp_deleteMsBrand", _param, ref _paramOut, ref data);
        //            if (_success)
        //            {
        //                //ErrorHandler.ErrorMessage = Convert.ToString(_paramOut[0].Value);
        //                _result = (int)data;
        //            }
        //            _scope.Complete();
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrorHandler.ErrorMessage = ex.Message;
        //        }
        //    }

        //    return _result;
        //}

        public int DeletedBrand(MsBrand _prmBrand)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsBrand", DbType.String));
            _param.Add(new SPParam("@fieldName", "BrandID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmBrand.BrandID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmBrand.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmBrand.RowStatus, DbType.Int32));

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
