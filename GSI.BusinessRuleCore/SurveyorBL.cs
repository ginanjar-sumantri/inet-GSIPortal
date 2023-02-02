using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using System.Transactions;

namespace GSI.BusinessRuleCore
{
    public class SurveyorBL : Base
    {
        public SurveyorBL()
        {
        }

        public MsSurveyor GetSingleSurveyor(long _prmSurveyorID)
        {
            MsSurveyor _result = new MsSurveyor();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@surveyorID", _prmSurveyorID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsSurveyorBySurveyorID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsSurveyor _msSurveyor = new MsSurveyor();
                _msSurveyor.SurveyorID = (long)dr["SurveyorID"];
                _msSurveyor.SurveyorCode = (dr["SurveyorCode"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorCode"];
                _msSurveyor.RegionID = (long)dr["RegionID"];
                _msSurveyor.EmployeeID = (long)dr["EmployeeID"];
                _msSurveyor.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msSurveyor.RowStatus = (int)dr["RowStatus"];
                _msSurveyor.CreatedBy = (String)dr["CreatedBy"];
                _msSurveyor.CreatedDate = (DateTime)dr["CreatedDate"];
                _msSurveyor.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msSurveyor.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msSurveyor.Timestamp = (byte[])dr["Timestamp"];

                _result = _msSurveyor;
                dr.Close();
            }

            return _result;
        }

        public List<MsSurveyor> GetListSurveyorForDDL()
        {
            List<MsSurveyor> _result = new List<MsSurveyor>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsSurveyor", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyor _msSurveyor = new MsSurveyor();
                    _msSurveyor.SurveyorID = (long)dr["SurveyorID"];
                    _msSurveyor.SurveyorCode = (dr["SurveyorCode"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorCode"];
                    _msSurveyor.EmployeeID = (long)dr["EmployeeID"];
                    _msSurveyor.EmployeeName = new EmployeeBL().GetSingleEmployee((long)dr["EmployeeID"]).EmployeeName;
                    _msSurveyor.RegionID = (long)dr["RegionID"];
                    _msSurveyor.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msSurveyor.CreatedBy = (String)dr["CreatedBy"];
                    _msSurveyor.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msSurveyor.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msSurveyor.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msSurveyor.RowStatus = (int)dr["RowStatus"];
                    _msSurveyor.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_msSurveyor);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsSurveyor> GetSurveyorByRegionID(long _prmRegionID)
        {
            List<MsSurveyor> _result = new List<MsSurveyor>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@regionID", _prmRegionID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetSurveyorByRegionID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyor _msSurveyor = new MsSurveyor();
                    _msSurveyor.SurveyorID = (long)dr["SurveyorID"];
                    _msSurveyor.SurveyorCode = (dr["SurveyorCode"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorCode"];
                    _msSurveyor.RegionID = (long)dr["RegionID"];
                    _msSurveyor.EmployeeID = (long)dr["EmployeeID"];
                    _msSurveyor.EmployeeName = new EmployeeBL().GetSingleEmployee((long)dr["EmployeeID"]).EmployeeName;
                    _msSurveyor.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msSurveyor.RowStatus = (int)dr["RowStatus"];
                    _msSurveyor.CreatedBy = (String)dr["CreatedBy"];
                    _msSurveyor.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msSurveyor.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msSurveyor.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msSurveyor.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_msSurveyor);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsSurveyor> GetSurveyorByRegionIDAndZipCode(long _prmRegionID, String _prmZipCode)
        {
            List<MsSurveyor> _result = new List<MsSurveyor>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@regionID", _prmRegionID, DbType.Int64));
            _param.Add(new SPParam("@zipCode", _prmZipCode, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetSurveyorByRegionIDAndZipCode", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyor _msSurveyor = new MsSurveyor();
                    _msSurveyor.SurveyorID = (long)dr["SurveyorID"];
                    _msSurveyor.SurveyorCode = (dr["SurveyorCode"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorCode"];
                    _msSurveyor.RegionID = (long)dr["RegionID"];
                    _msSurveyor.EmployeeID = (long)dr["EmployeeID"];
                    _msSurveyor.EmployeeName = new EmployeeBL().GetSingleEmployee((long)dr["EmployeeID"]).EmployeeName;
                    _msSurveyor.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msSurveyor.RowStatus = (int)dr["RowStatus"];
                    _msSurveyor.CreatedBy = (String)dr["CreatedBy"];
                    _msSurveyor.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msSurveyor.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msSurveyor.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msSurveyor.Timestamp = (byte[])dr["Timestamp"];

                    if (_result.Exists(_temp => _temp.SurveyorID == _msSurveyor.SurveyorID) == false)
                    {
                        _result.Add(_msSurveyor);
                    }
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsSurveyor> GetListSurveyor(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            //SurveyorBL _empBL = new SurveyorBL();
            List<MsSurveyor> _result = new List<MsSurveyor>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsSurveyor", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsSurveyor", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyor _msSurveyor = new MsSurveyor();
                    _msSurveyor.SurveyorID = (long)dr["SurveyorID"];
                    _msSurveyor.SurveyorCode = (dr["SurveyorCode"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorCode"];
                    _msSurveyor.EmployeeID = (long)dr["EmployeeID"];
                    _msSurveyor.RegionID = (long)dr["RegionID"];
                    _msSurveyor.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msSurveyor.CreatedBy = (String)dr["CreatedBy"];
                    _msSurveyor.CreatedDate = (DateTime)dr["CreatedDate"];
                    _result.Add(_msSurveyor);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsSurveyorZipCode> GetListSurveyorZipCodeForDDLBySurveyorID(Int64 _prmSurveyorID)
        {
            List<MsSurveyorZipCode> _result = new List<MsSurveyorZipCode>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@surveyorID", _prmSurveyorID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsSurveyorZipCodebySurveyorID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyorZipCode _msSurveyorZipCode = new MsSurveyorZipCode();
                    _msSurveyorZipCode.SurveyorZipCodeID = (long)dr["SurveyorZipCodeID"];
                    _msSurveyorZipCode.SurveyorID = (long)dr["SurveyorID"];
                    _msSurveyorZipCode.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _msSurveyorZipCode.RowStatus = (int)dr["RowStatus"];
                    _msSurveyorZipCode.CreatedBy = (String)dr["CreatedBy"];
                    _msSurveyorZipCode.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msSurveyorZipCode.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msSurveyorZipCode.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msSurveyorZipCode.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_msSurveyorZipCode);
                }
                dr.Close();
            }

            return _result;
        }

        public String GetEmployeeNameBySurveyorID(long _prmSurveyorID)
        {
            String _result = "";

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@surveyorID", _prmSurveyorID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeNameBySurveyorID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                _result = (dr["EmployeeName"] == DBNull.Value) ? String.Empty : (String)dr["EmployeeName"];
                dr.Close();
            }

            return _result;
        }

        public int InsertMsSurveyor(MsSurveyor _prmMsSurveyor)
        {
            int _result = 0;
            bool _success = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    _param.Add(new SPParam("@createdBy", _prmMsSurveyor.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@employeeID", _prmMsSurveyor.EmployeeID, DbType.String));
                    _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                    _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@regionID", _prmMsSurveyor.RegionID, DbType.String));
                    _param.Add(new SPParam("@remark", _prmMsSurveyor.Remark, DbType.String));
                    _param.Add(new SPParam("@rowStatus", _prmMsSurveyor.RowStatus, DbType.String));
                    _param.Add(new SPParam("@surveyorCode", _prmMsSurveyor.SurveyorCode, DbType.String));
                    _param.Add(new SPParam("@surveyorID", null, DbType.Int64));
                    _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsSurveyor", _param, ref _paramOut, ref data);

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

        public int InsertMsSurveyorAndZipCodes(MsSurveyor _prmMsSurveyor, String _prmZipCodes)
        {
            int _result = 0;
            Boolean _success = false;
            long _outID = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    _param.Add(new SPParam("@createdBy", _prmMsSurveyor.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@employeeID", _prmMsSurveyor.EmployeeID, DbType.String));
                    _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                    _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@regionID", _prmMsSurveyor.RegionID, DbType.String));
                    _param.Add(new SPParam("@remark", _prmMsSurveyor.Remark, DbType.String));
                    _param.Add(new SPParam("@rowStatus", _prmMsSurveyor.RowStatus, DbType.Int32));
                    _param.Add(new SPParam("@surveyorCode", _prmMsSurveyor.SurveyorCode, DbType.String));

                    _paramOut.Add(new SPParamOut("@surveyorID", null, DbType.Int64));
                    _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsSurveyor", _param, ref _paramOut, ref data);

                    if (_success == true)
                    {
                        _result = (int)data;
                        _outID = Convert.ToInt64(_paramOut[0].Value);

                        bool _success2 = false;
                        object data2 = null;
                        long _outID2 = 0;

                        List<SPParam> _param2 = new List<SPParam>();
                        List<SPParamOut> _paramOut2 = new List<SPParamOut>();
                        String[] _zipCodeArr = _prmZipCodes.Split(',');
                        foreach (var _zipCode in _zipCodeArr)
                        {
                            _success2 = false;
                            data2 = null;
                            _param2.Clear();
                            _paramOut2.Clear();

                            _param2.Add(new SPParam("@surveyorID", _outID, DbType.Int64));
                            _param2.Add(new SPParam("@zipCode", _zipCode, DbType.String));
                            _param2.Add(new SPParam("@rowStatus", _prmMsSurveyor.RowStatus, DbType.Int32));
                            _param2.Add(new SPParam("@createdBy", _prmMsSurveyor.CreatedBy, DbType.String));
                            _param2.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                            _param2.Add(new SPParam("@modifiedBy", "", DbType.String));
                            _param2.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

                            _paramOut2.Add(new SPParamOut("@surveyorZipCodeID", null, DbType.Int64));
                            _success2 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsSurveyorZipCode", _param2, ref _paramOut2, ref data2);

                            if (_success2)
                            {
                                _result = (int)data2;
                                _outID2 = Convert.ToInt64(_paramOut2[0].Value);
                            }
                        }
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

        public Boolean UpdateMsSurveyor(MsSurveyor _prmSurveyor)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@createdBy", _prmSurveyor.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@employeeID", _prmSurveyor.EmployeeID, DbType.Int64));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@regionID", _prmSurveyor.RegionID, DbType.Int64));
            _param.Add(new SPParam("@remark", _prmSurveyor.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmSurveyor.RowStatus, DbType.String));
            _param.Add(new SPParam("@surveyorCode", _prmSurveyor.SurveyorCode, DbType.String));
            _param.Add(new SPParam("@surveyorID", _prmSurveyor.SurveyorID, DbType.Int64));
            _param.Add(new SPParam("@timestamp", _prmSurveyor.Timestamp, DbType.Binary));


            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsSurveyor", _param, ref _paramOut, ref data);

            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public Boolean UpdateMsSurveyorAndZipCode(MsSurveyor _prmSurveyor, String _prmZipCodes)
        {
            Boolean _result = false;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    object data = null;
                    List<SPParam> _param = new List<SPParam>();
                    _param.Add(new SPParam("@createdBy", _prmSurveyor.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@employeeID", _prmSurveyor.EmployeeID, DbType.Int64));
                    _param.Add(new SPParam("@modifiedBy", _prmSurveyor.ModifiedBy, DbType.String));
                    _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                    _param.Add(new SPParam("@regionID", _prmSurveyor.RegionID, DbType.Int64));
                    _param.Add(new SPParam("@remark", _prmSurveyor.Remark, DbType.String));
                    _param.Add(new SPParam("@rowStatus", _prmSurveyor.RowStatus, DbType.String));
                    _param.Add(new SPParam("@surveyorCode", _prmSurveyor.SurveyorCode, DbType.String));
                    _param.Add(new SPParam("@surveyorID", _prmSurveyor.SurveyorID, DbType.Int64));
                    _param.Add(new SPParam("@timestamp", _prmSurveyor.Timestamp, DbType.Binary));

                    List<SPParamOut> _paramOut = new List<SPParamOut>();

                    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsSurveyor", _param, ref _paramOut, ref data);

                    if (_success)
                    {
                        //delete surveyorzipcode yg exist -> add ulang surveyorzipcode yg baru
                        object data2 = null;
                        List<SPParam> _param2 = new List<SPParam>();
                        _param2.Add(new SPParam("@surveyorID", _prmSurveyor.SurveyorID, DbType.Int64));

                        List<SPParamOut> _paramOut2 = new List<SPParamOut>();

                        List<MsSurveyorZipCode> _listCurrentZipCode = new List<MsSurveyorZipCode>();

                        bool _success2 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetMsSurveyorZipCodeBySurveyorID", _param2, ref _paramOut2, ref data2);
                        if (_success2)
                        {
                            IDataReader dr = (IDataReader)data2;
                            while (dr.Read())
                            {
                                MsSurveyorZipCode _msSurvZipCode = new MsSurveyorZipCode();
                                _msSurvZipCode.SurveyorZipCodeID = (long)dr["SurveyorZipCodeID"];
                                _msSurvZipCode.SurveyorID = (long)dr["SurveyorID"];
                                _msSurvZipCode.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                                _msSurvZipCode.CreatedBy = (String)dr["CreatedBy"];
                                _msSurvZipCode.CreatedDate = (DateTime)dr["CreatedDate"];
                                _msSurvZipCode.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                                _msSurvZipCode.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                                _msSurvZipCode.RowStatus = (int)dr["RowStatus"];
                                _msSurvZipCode.Timestamp = (byte[])dr["Timestamp"];

                                _listCurrentZipCode.Add(_msSurvZipCode);
                            }
                            dr.Close();
                        }

                        List<String> _tobeRemove = new List<String>();
                        List<String> _tobeInsert = new List<String>();
                        String[] _zipCodeArr = _prmZipCodes.Split(',');
                        
                        //untuk cek item perlu diremove ato tidak
                        foreach (var _item in _listCurrentZipCode)
                        {
                            Boolean _itemExistInDBAndParam = false;
                            foreach (var _newItem in _zipCodeArr)
                            {
                                if (_newItem == _item.ZipCode)
                                {
                                    _itemExistInDBAndParam = true;
                                    break;
                                }
                            }
                            if (_itemExistInDBAndParam == false)
                            {
                                _tobeRemove.Add(_item.ZipCode);
                            }
                        }
                        
                        //untuk cek item perlu diinsert ato tidak
                        foreach (var _newItem in _zipCodeArr)
                        {
                            if (_listCurrentZipCode.Exists(_temp => _temp.ZipCode == _newItem) == false)
                            {
                                if (_tobeInsert.Exists(_temp => _temp == _newItem) == false)
                                {
                                    _tobeInsert.Add(_newItem);
                                }
                            }
                        }

                        foreach (var _removeItem in _tobeRemove)
                        {
                            object data3 = null;
                            
                            List<SPParam> _param3 = new List<SPParam>();
                            _param3.Add(new SPParam("@tableName", "MsSurveyorZipCode", DbType.String));
                            _param3.Add(new SPParam("@fieldName", "ZipCode", DbType.String));
                            _param3.Add(new SPParam("@fieldValue", _removeItem, DbType.Int64));
                            _param3.Add(new SPParam("@userName", _prmSurveyor.ModifiedBy, DbType.String));
                            _param3.Add(new SPParam("@rowStatus", 1, DbType.Int32));

                            List<SPParamOut> _paramOut3 = new List<SPParamOut>();
                            _paramOut3.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                            bool _success3 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param3, ref _paramOut3, ref data3);
                        }

                        foreach (var _insertItem in _tobeInsert)
                        {
                            List<SPParam> _param4 = new List<SPParam>();
                            List<SPParamOut> _paramOut4 = new List<SPParamOut>();
                            
                            object data4 = null;
                            long _outID4 = 0;
                            _param4.Clear();
                            _paramOut4.Clear();

                            _param4.Add(new SPParam("@surveyorID", _prmSurveyor.SurveyorID, DbType.Int64));
                            _param4.Add(new SPParam("@zipCode", _insertItem, DbType.String));
                            _param4.Add(new SPParam("@rowStatus", _prmSurveyor.RowStatus, DbType.Int32));
                            _param4.Add(new SPParam("@createdBy", _prmSurveyor.ModifiedBy, DbType.String));
                            _param4.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                            _param4.Add(new SPParam("@modifiedBy", _prmSurveyor.ModifiedBy, DbType.String));
                            _param4.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                            _paramOut4.Add(new SPParamOut("@surveyorZipCodeID", null, DbType.Int64));

                            bool _success4 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsSurveyorZipCode", _param4, ref _paramOut4, ref data4);

                            if (_success4)
                            {
                                //_result = (int)data4;
                                _outID4 = Convert.ToInt64(_paramOut4[0].Value);
                            }
                        }
                    }

                    _scope.Complete();
                    _result = true;
                }
                catch (Exception Ex)
                {
                    ErrorHandler.ErrorMessage = Ex.Message;
                }
            }

            return _result;
        }

        public int DeletedSurveyor(MsSurveyor _prmSurveyor)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsSurveyor", DbType.String));
            _param.Add(new SPParam("@fieldName", "SurveyorID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmSurveyor.SurveyorID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmSurveyor.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmSurveyor.RowStatus, DbType.Int32));

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

        public int DeleteSurveyorAndZipCode(MsSurveyor _prmSurveyor)
        {
            int _result = 0;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    object data = null;
                    List<SPParam> _param = new List<SPParam>();

                    _param.Add(new SPParam("@tableName", "MsSurveyorZipCode", DbType.String));
                    _param.Add(new SPParam("@fieldName", "SurveyorID", DbType.String));
                    _param.Add(new SPParam("@fieldValue", _prmSurveyor.SurveyorID, DbType.Int64));
                    _param.Add(new SPParam("@userName", _prmSurveyor.ModifiedBy, DbType.String));
                    _param.Add(new SPParam("@rowStatus", 1, DbType.Int32));

                    List<SPParamOut> _paramOut = new List<SPParamOut>();
                    _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
                    if (_success)
                    {
                        ErrorHandler.ErrorMessage = Convert.ToString(_paramOut[0].Value);
                        _result = (int)data;

                        object data2 = null;
                        List<SPParam> _param2 = new List<SPParam>();

                        _param2.Add(new SPParam("@tableName", "MsSurveyor", DbType.String));
                        _param2.Add(new SPParam("@fieldName", "SurveyorID", DbType.String));
                        _param2.Add(new SPParam("@fieldValue", _prmSurveyor.SurveyorID, DbType.Int64));
                        _param2.Add(new SPParam("@userName", _prmSurveyor.ModifiedBy, DbType.String));
                        _param2.Add(new SPParam("@rowStatus", _prmSurveyor.RowStatus, DbType.Int32));

                        List<SPParamOut> _paramOut2 = new List<SPParamOut>();
                        _paramOut2.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                        bool _success2 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param2, ref _paramOut2, ref data2);
                        if (_success2)
                        {
                            ErrorHandler.ErrorMessage = Convert.ToString(_paramOut2[0].Value);
                            _result = (int)data2;
                        }
                    }

                    _scope.Complete();
                }
                catch (Exception Ex)
                {
                    ErrorHandler.ErrorMessage = Ex.Message;
                }
            }

            return _result;
        }
    }
}
