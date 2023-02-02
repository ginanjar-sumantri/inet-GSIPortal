using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class EmployeeBL : Base
    {
        public EmployeeBL()
        {
        }

        public MsEmployee GetSingleEmployee(long _prmEmployeeID)
        {
            MsEmployee _result = new MsEmployee();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@employeeID", _prmEmployeeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeByEmployeeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsEmployee _msEmployee = new MsEmployee();
                _msEmployee.EmployeeID = (long)dr["EmployeeID"];
                _msEmployee.EmployeeCode = (String)dr["EmployeeCode"]; 
                _msEmployee.EmployeeName = (String)dr["EmployeeName"];
                _msEmployee.NoID = (String)dr["NoID"];
                _msEmployee.TypeID = (dr["TypeID"] == DBNull.Value) ? String.Empty : (String)dr["TypeID"];
                _msEmployee.BirthDate = (DateTime)dr["BirthDate"];
                _msEmployee.BirthPlace = (dr["BirthPlace"] == DBNull.Value) ? String.Empty : (String)dr["BirthPlace"];
                _msEmployee.Email = (dr["Email"] == DBNull.Value) ? String.Empty : (String)dr["Email"];
                _msEmployee.EmployeeAddress1 = (dr["EmployeeAddress1"] == DBNull.Value) ? String.Empty : (String)dr["EmployeeAddress1"];
                _msEmployee.EmployeeAddress2 = (dr["EmployeeAddress2"] == DBNull.Value) ? String.Empty : (String)dr["EmployeeAddress2"];
                _msEmployee.FgActive = (String)dr["FgActive"];
                _msEmployee.GadgetID = (dr["GadgetID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["GadgetID"];
                _msEmployee.Gender = (String)dr["Gender"];
                _msEmployee.HandPhone1 = (dr["HandPhone1"] == DBNull.Value) ? String.Empty : (String)dr["HandPhone1"];
                _msEmployee.Nationality = (dr["Nationality"] == DBNull.Value) ? String.Empty : (String)dr["Nationality"];
                _msEmployee.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msEmployee.RowStatus = (int)dr["RowStatus"];
                _msEmployee.CreatedBy = (String)dr["CreatedBy"];
                _msEmployee.CreatedDate = (DateTime)dr["CreatedDate"];
                _msEmployee.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msEmployee.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msEmployee.Timestamp = (byte[])dr["Timestamp"];
                _msEmployee.EmployeeLogOn = (String)dr["EmployeeLogOn"];

                _result = _msEmployee;
                dr.Close();
            }

            return _result;
        }

        public MsEmployee GetSingleEmployeeByEmployeeLogon(String _prmEmployeeLogon)
        {
            MsEmployee _result = new MsEmployee();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@employeeLogon", _prmEmployeeLogon, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeByEmployeeLogon", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsEmployee _msEmployee = new MsEmployee();
                _msEmployee.EmployeeID = (long)dr["EmployeeID"];
                _msEmployee.EmployeeCode = (String)dr["EmployeeCode"];
                _msEmployee.EmployeeName = (String)dr["EmployeeName"];
                _msEmployee.NoID = (String)dr["NoID"];
                _msEmployee.TypeID = (dr["TypeID"] == DBNull.Value) ? String.Empty : (String)dr["TypeID"];
                _msEmployee.BirthDate = (DateTime)dr["BirthDate"];
                _msEmployee.BirthPlace = (dr["BirthPlace"] == DBNull.Value) ? String.Empty : (String)dr["BirthPlace"];
                _msEmployee.Email = (dr["Email"] == DBNull.Value) ? String.Empty : (String)dr["Email"];
                _msEmployee.EmployeeAddress1 = (dr["EmployeeAddress1"] == DBNull.Value) ? String.Empty : (String)dr["EmployeeAddress1"];
                _msEmployee.EmployeeAddress2 = (dr["EmployeeAddress2"] == DBNull.Value) ? String.Empty : (String)dr["EmployeeAddress2"];
                _msEmployee.FgActive = (String)dr["FgActive"];
                _msEmployee.GadgetID = (dr["GadgetID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["GadgetID"];
                _msEmployee.Gender = (String)dr["Gender"];
                _msEmployee.HandPhone1 = (dr["HandPhone1"] == DBNull.Value) ? String.Empty : (String)dr["HandPhone1"];
                _msEmployee.Nationality = (dr["Nationality"] == DBNull.Value) ? String.Empty : (String)dr["Nationality"];
                _msEmployee.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msEmployee.RowStatus = (int)dr["RowStatus"];
                _msEmployee.CreatedBy = (String)dr["CreatedBy"];
                _msEmployee.CreatedDate = (DateTime)dr["CreatedDate"];
                _msEmployee.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msEmployee.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msEmployee.Timestamp = (byte[])dr["Timestamp"];
                _msEmployee.EmployeeLogOn = (String)dr["EmployeeLogOn"];

                _result = _msEmployee;
                dr.Close();
            }

            return _result;
        }

        public List<MsEmployee> GetListEmployee(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsEmployee> _result = new List<MsEmployee>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsEmployee", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsEmployee", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsEmployee _msEmployee = new MsEmployee();
                    _msEmployee.EmployeeID = (Int64)dr["EmployeeID"];
                    _msEmployee.EmployeeCode = (String)dr["EmployeeCode"];
                    _msEmployee.EmployeeName = (String)dr["EmployeeName"];
                    _msEmployee.Gender = (String)dr["Gender"];
                    _msEmployee.HandPhone1 = (dr["HandPhone1"] == DBNull.Value) ? String.Empty : (String)dr["HandPhone1"];
                    _msEmployee.Email = (dr["Email"] == DBNull.Value) ? String.Empty : (String)dr["Email"];
                    _result.Add(_msEmployee);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsEmployee> GetListEmployeeNotInMsSurveyor()
        {
            List<MsEmployee> _result = new List<MsEmployee>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeBySurveyor", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsEmployee _msEmployee = new MsEmployee();
                    _msEmployee.EmployeeID = (Int64)dr["EmployeeID"];
                    _msEmployee.EmployeeName = (String)dr["EmployeeName"];

                    _result.Add(_msEmployee);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsEmployee> GetSingleEmployeeForDDL(long _prmEmployeeID)
        {
            List<MsEmployee> _result = new List<MsEmployee>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@employeeID", _prmEmployeeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeByEmployeeIDSurveyor", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsEmployee _msEmployee = new MsEmployee();
                    _msEmployee.EmployeeID = (Int64)dr["EmployeeID"];
                    _msEmployee.EmployeeName = (String)dr["EmployeeName"];

                    _result.Add(_msEmployee);
                }
                dr.Close();
            }

            return _result;
        }

        public int DeletedEmployee(MsEmployee _prmEmployee)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsEmployee", DbType.String));
            _param.Add(new SPParam("@fieldName", "EmployeeID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmEmployee.EmployeeID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmEmployee.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmEmployee.RowStatus, DbType.Int32));

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

        public Boolean UpdateMsEmployee(MsEmployee _prmEmployee)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@birthDate", _prmEmployee.BirthDate, DbType.DateTime));
            _param.Add(new SPParam("@birthPlace", _prmEmployee.BirthPlace, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmEmployee.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmEmployee.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@email", _prmEmployee.Email, DbType.String));
            _param.Add(new SPParam("@employeeAddress1", _prmEmployee.EmployeeAddress1, DbType.String));
            _param.Add(new SPParam("@employeeAddress2", _prmEmployee.EmployeeAddress2, DbType.String));
            _param.Add(new SPParam("@employeeCode", _prmEmployee.EmployeeCode, DbType.String));
            _param.Add(new SPParam("@employeeID", _prmEmployee.EmployeeID, DbType.Int64));
            _param.Add(new SPParam("@employeeName", _prmEmployee.EmployeeName, DbType.String));
            _param.Add(new SPParam("@fgActive", _prmEmployee.FgActive, DbType.String));
            _param.Add(new SPParam("@gadgetID", _prmEmployee.GadgetID, DbType.Int64));
            _param.Add(new SPParam("@gender", _prmEmployee.Gender, DbType.String));
            _param.Add(new SPParam("@handPhone1", _prmEmployee.HandPhone1, DbType.String));
            _param.Add(new SPParam("@modifiedBy", _prmEmployee.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmEmployee.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@nationality", _prmEmployee.Nationality, DbType.String));
            _param.Add(new SPParam("@noID", _prmEmployee.NoID, DbType.String));
            _param.Add(new SPParam("@remark", _prmEmployee.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmEmployee.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@timestamp", _prmEmployee.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@typeID", _prmEmployee.TypeID, DbType.String));
            _param.Add(new SPParam("@employeeLogOn", _prmEmployee.EmployeeLogOn, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsEmployee", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsEmployee(MsEmployee _prmMsEmployee)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;

            _param.Add(new SPParam("@birthDate", _prmMsEmployee.BirthDate, DbType.DateTime));
            _param.Add(new SPParam("@birthPlace", _prmMsEmployee.BirthPlace, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmMsEmployee.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@email", _prmMsEmployee.Email, DbType.String));
            _param.Add(new SPParam("@employeeAddress1", _prmMsEmployee.EmployeeAddress1, DbType.String));
            _param.Add(new SPParam("@employeeAddress2", _prmMsEmployee.EmployeeAddress2, DbType.String));
            _param.Add(new SPParam("@employeeCode", _prmMsEmployee.EmployeeCode, DbType.String));
            _param.Add(new SPParam("@employeeID", _prmMsEmployee.EmployeeID, DbType.String));
            _param.Add(new SPParam("@employeeName", _prmMsEmployee.EmployeeName, DbType.String));
            _param.Add(new SPParam("@fgActive", _prmMsEmployee.FgActive, DbType.String));
            _param.Add(new SPParam("@gadgetID", _prmMsEmployee.GadgetID, DbType.Int64));
            _param.Add(new SPParam("@gender", _prmMsEmployee.Gender, DbType.String));
            _param.Add(new SPParam("@handPhone1", _prmMsEmployee.HandPhone1, DbType.String));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@nationality", _prmMsEmployee.Nationality, DbType.String));
            _param.Add(new SPParam("@noID", _prmMsEmployee.NoID, DbType.String));
            _param.Add(new SPParam("@remark", _prmMsEmployee.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsEmployee.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@typeID", _prmMsEmployee.TypeID, DbType.String));
            _param.Add(new SPParam("@employeeLogOn", _prmMsEmployee.EmployeeLogOn, DbType.String));
            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsEmployee", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public List<MsEmployee> GetListMsEmployeeForDispatcherDDL()
        {
            List<MsEmployee> _result = new List<MsEmployee>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetEmployeeLogonFromMsEmployee", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsEmployee _msEmployee = new MsEmployee();
                    _msEmployee.EmployeeID = (Int64)dr["EmployeeID"];
                    _msEmployee.EmployeeLogOn = (String)dr["EmployeeLogOn"];

                    _result.Add(_msEmployee);
                }
                dr.Close();
            }

            return _result;
        }
        
    }
}
