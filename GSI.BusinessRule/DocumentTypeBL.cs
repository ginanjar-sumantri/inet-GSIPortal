using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class DocumentTypeBL : Base
    {
        public DocumentTypeBL()
        {
        }

        //public MsDocumentType GetSingleDocumentType(long _prmDocumentTypeID)
        //{
        //    MsDocumentType _result = new MsDocumentType();

        //    object data = null;
        //    List<SPParam> _param = new List<SPParam>();
        //    _param.Add(new SPParam("@documentTypeID", _prmDocumentTypeID, DbType.Int64));

        //    List<SPParamOut> _paramOut = new List<SPParamOut>();

        //    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsDocumentTypeByDocumentTypeID", _param, ref _paramOut, ref data);
        //    if (_success)
        //    {
        //        IDataReader dr = (IDataReader)data;
        //        dr.Read();
        //        MsDocumentType _msDocumentType = new MsDocumentType();
        //        _msDocumentType.DocumentTypeID = (long)dr["DocumentTypeID"];
        //        _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];
        //        _msDocumentType.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
        //        _msDocumentType.RowStatus = (int)dr["RowStatus"];
        //        _msDocumentType.CreatedBy = (String)dr["CreatedBy"];
        //        _msDocumentType.CreatedDate = (DateTime)dr["CreatedDate"];
        //        _msDocumentType.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
        //        _msDocumentType.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
        //        _msDocumentType.Timestamp = (byte[])dr["Timestamp"];

        //        _result = _msDocumentType;
        //        dr.Close();
        //    }

        //    return _result;
        //}

        public List<MsDocumentType> GetDocumentType(Int64 _prmSurveyPoint)
        {
            List<MsDocumentType> _result = new List<MsDocumentType>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@SurveyPointID", _prmSurveyPoint, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_DocumentForSurveyPoint", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsDocumentType _msDocumentType = new MsDocumentType();
                    _msDocumentType.DocumentTypeID = (long)dr["DocumentTypeID"];
                    _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];

                    _result.Add(_msDocumentType);
                }
                dr.Close();
            }

            return _result;
        }
        
        public MsDocumentType GetListMsDocumentTypeByCode(long _prmDocumentType)
        {
            MsDocumentType _result = new MsDocumentType();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@DocumentTypeID", _prmDocumentType, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsDocumentTypeByDocumentTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    MsDocumentType _msDocumentType = new MsDocumentType();
                    _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];

                    _result = _msDocumentType;
                }
                dr.Close();
            }

            return _result;
        }

        public MsDocumentType GetSingleDocumentType(long _prmDocumentTypeID)
        {
            MsDocumentType _result = new MsDocumentType();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@documentTypeID", _prmDocumentTypeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsDocumentTypeByDocumentTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsDocumentType _msDocumentType = new MsDocumentType();
                _msDocumentType.DocumentTypeID = (Int64)dr["DocumentTypeID"];
                _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];
                _msDocumentType.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msDocumentType.RowStatus = (Int32)dr["RowStatus"];
                _msDocumentType.CreatedBy = (String)dr["CreatedBy"];
                _msDocumentType.CreatedDate = (DateTime)dr["CreatedDate"];
                _msDocumentType.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msDocumentType.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msDocumentType.Timestamp = (byte[])dr["Timestamp"];

                _result = _msDocumentType;
                dr.Close();
            }

            return _result;
        }

        //public List<MsDocumentType> GetListDocumentType()
        //{
        //    List<MsDocumentType> _result = new List<MsDocumentType>();

        //    object data = null;
        //    List<SPParam> _param = new List<SPParam>();

        //    List<SPParamOut> _paramOut = new List<SPParamOut>();

        //    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsDocumentType", _param, ref _paramOut, ref data);
        //    if (_success)
        //    {
        //        IDataReader dr = (IDataReader)data;
        //        while (dr.Read())
        //        {
        //            MsDocumentType _msDocumentType = new MsDocumentType();
        //            _msDocumentType.DocumentTypeID = (Int64)dr["DocumentTypeID"];
        //            _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];
        //            _msDocumentType.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
        //            _msDocumentType.RowStatus = (Int32)dr["RowStatus"];
        //            _msDocumentType.CreatedBy = (String)dr["CreatedBy"];
        //            _msDocumentType.CreatedDate = (DateTime)dr["CreatedDate"];
        //            _msDocumentType.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
        //            _msDocumentType.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
        //            _msDocumentType.Timestamp = (byte[])dr["Timestamp"];

        //            _result.Add(_msDocumentType);
        //        }
        //        dr.Close();
        //    }

        //    return _result;
        //}

        public List<MsDocumentType> GetListMsDocumentType(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsDocumentType> _result = new List<MsDocumentType>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsDocumentType", DbType.String));
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
                    MsDocumentType _msDocumentType = new MsDocumentType();
                    _msDocumentType.DocumentTypeID = (Int64)dr["DocumentTypeID"];
                    _msDocumentType.DocumentTypeName = (dr["DocumentTypeName"] == DBNull.Value) ? "" : (String)dr["DocumentTypeName"];
                    _msDocumentType.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                    _result.Add(_msDocumentType);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateMsDocumentType(MsDocumentType _prmDocumentType)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@createdBy", _prmDocumentType.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmDocumentType.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmDocumentType.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmDocumentType.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@documentTypeID", _prmDocumentType.DocumentTypeID, DbType.Int64));
            _param.Add(new SPParam("@documentTypeName", _prmDocumentType.DocumentTypeName, DbType.String));
            _param.Add(new SPParam("@remark", _prmDocumentType.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmDocumentType.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmDocumentType.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsDocumentType", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsDocumentType(MsDocumentType _prmDocumentType)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@createdBy", _prmDocumentType.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@DocumentTypeID", _prmDocumentType.DocumentTypeID, DbType.Int64));
            _param.Add(new SPParam("@documentTypeName", _prmDocumentType.DocumentTypeName, DbType.String));
            _param.Add(new SPParam("@remark", _prmDocumentType.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmDocumentType.RowStatus, DbType.Int32));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsDocumentType", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int DeletedDocumentType(MsDocumentType _prmDocumentType)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsDocumentType", DbType.String));
            _param.Add(new SPParam("@fieldName", "DocumentTypeID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmDocumentType.DocumentTypeID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmDocumentType.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmDocumentType.RowStatus, DbType.Int32));

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

        ~DocumentTypeBL()
        {
        }
    }
}
