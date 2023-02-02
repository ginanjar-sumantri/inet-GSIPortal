using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class CustomerUserBL : Base
    {
        public CustomerUserBL()
        {
        }

        public MsCustomerUser GetMsCustomerUserByCustomerUserID(String _customerUserID)
        {
            MsCustomerUser _result = new MsCustomerUser();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerUserID", _customerUserID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerUserByCustomerUserID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomerUser _msCustomerUser = new MsCustomerUser();
                _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                //_msCustomerUser.CustomerID = (long)dr["CustomerID"];
                _msCustomerUser.CustomerID = (dr["CustomerID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["CustomerID"];
                _msCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                _msCustomerUser.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                _msCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                _msCustomerUser.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomerUser.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                _msCustomerUser.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomerUser.CustomerUserID = (long)dr["CustomerUserID"];
                _msCustomerUser.RowStatus = (Int32)dr["RowStatus"];
                _msCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                _msCustomerUser.Timestamp = (byte[])dr["Timestamp"];
                _result = _msCustomerUser;
                dr.Close();
            }

            return _result;
        }

        public MsCustomerUser CustomerUserByCustomerID(String _prmCustomerID)
        {
            MsCustomerUser _result = new MsCustomerUser();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustomerID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerUserByCustomerID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomerUser _msCustomerUser = new MsCustomerUser();
                _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                //_msCustomerUser.CustomerUserID = (long)dr["CustomerUserID"];
                _msCustomerUser.CustomerID = (dr["CustomerID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["CustomerID"];
                _msCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                _msCustomerUser.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                _msCustomerUser.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                _msCustomerUser.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomerUser.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                _msCustomerUser.CustomerID = (long)dr["CustomerID"];
                _msCustomerUser.RowStatus = (Int32)dr["RowStatus"];
                _msCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];


                _result = _msCustomerUser;
                dr.Close();
            }

            return _result;
        }

        public List<MsCustomerUser> GetListFromMsCustomerUser(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            CustomerUserBL _empBL = new CustomerUserBL();
            List<MsCustomerUser> _result = new List<MsCustomerUser>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsCustomerUser", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomerUser", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsCustomerUser _msCustomerUser = new MsCustomerUser();
                    _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                    _msCustomerUser.CreatedDate = (DateTime)dr["CreatedDate"];
                    //_msCustomerUser.CustomerID = (long)dr["CustomerID"];
                    _msCustomerUser.CustomerID = (dr["CustomerID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["CustomerID"]; 
                    _msCustomerUser.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                    _msCustomerUser.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                    _msCustomerUser.CustomerUserID = (long)dr["customerUserID"];
                    _msCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                    _msCustomerUser.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                    _msCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                    _msCustomerUser.RowStatus = (Int32)dr["RowStatus"];
                    _result.Add(_msCustomerUser);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsCustomerUser> GetListMsCustomerUser()
        {
            CustomerUserBL _empBL = new CustomerUserBL();
            List<MsCustomerUser> _result = new List<MsCustomerUser>();
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomerUser", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsCustomerUser _msCustomerUser = new MsCustomerUser();
                    _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                    _msCustomerUser.CreatedDate = (DateTime)dr["CreatedDate"];
                    //_msCustomerUser.CustomerID = (Int64)dr["CustomerID"];
                    _msCustomerUser.CustomerID = (dr["CustomerID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["CustomerID"];
                    _msCustomerUser.CustomerUserID = (Int64)dr["CustomerUserID"];
                    _msCustomerUser.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                    _msCustomerUser.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                    _msCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                    _msCustomerUser.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                    _msCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                    _msCustomerUser.RowStatus = (Int32)dr["RowStatus"];
                    _result.Add(_msCustomerUser);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsBusinessType> GetListBusinessFormsForDDL()
        {
            List<MsBusinessType> _result = new List<MsBusinessType>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            //_param.Add(new SPParam("@CustID", "", DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsBusinessType", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsBusinessType _CustomerUserBL = new MsBusinessType();
                    _CustomerUserBL.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _CustomerUserBL.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];

                    _result.Add(_CustomerUserBL);
                }
                dr.Close();
            }

            return _result;
        }

        public MsCustomerUser GetAllCustomerUserID(String _prmCustomerUserID)
        {
            MsCustomerUser _result = new MsCustomerUser();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustomerUserID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomerUser", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomerUser _msCustomerUser = new MsCustomerUser();
                _msCustomerUser.CreatedBy = (String)dr["CreatedBy"];
                _msCustomerUser.CreatedDate = (DateTime)dr["CreatedDate"];
                //_msCustomerUser.CustomerID = (long)dr["CustomerID"];
                _msCustomerUser.CustomerID = (dr["CustomerID"] == DBNull.Value) ? (Int64?)null : (Int64)dr["CustomerID"];
                _msCustomerUser.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                _msCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                _msCustomerUser.ModifiedDate = (DateTime)dr["ModifieDdate"];
                _msCustomerUser.CustomerUserID = (long)dr["CustomerUserID"];
                _msCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                _msCustomerUser.Remark = (dr["Remark"] == DBNull.Value) ? "" : (String)dr["Remark"];
                _msCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                _msCustomerUser.RowStatus = (Int32)dr["RowStatus"];
                _result = _msCustomerUser;
                dr.Close();
            }

            return _result;
        }

        public int DeleteMsCustomerUser(MsCustomerUser _prmCustomerUser)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsCustomerUser", DbType.String));
            _param.Add(new SPParam("@fieldName", "CustomerUserID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmCustomerUser.CustomerUserID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmCustomerUser.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomerUser.RowStatus, DbType.Int32));

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

        public Boolean UpdateCustomerUser(MsCustomerUser _prmCustomerUser)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@createdBy", _prmCustomerUser.CreatedBy, DbType.String));
            _param.Add(new SPParam("@customerUserID", _prmCustomerUser.CustomerUserID, DbType.String));
            _param.Add(new SPParam("@customerID", _prmCustomerUser.CustomerID, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@displayName", _prmCustomerUser.DisplayName, DbType.String));
            _param.Add(new SPParam("@membershipUserName", _prmCustomerUser.MembershipUserName, DbType.String));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmCustomerUser.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomerUser.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@userEmailAddress", _prmCustomerUser.UserEmailAddress, DbType.String));
            _param.Add(new SPParam("@timestamp", _prmCustomerUser.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsCustomerUser", _param, ref _paramOut, ref data);

            if (_success)
            {
                _result = true;
            }
            return _result;
        }

        public int InsertMsCustomerUser(MsCustomerUser _prmCustomerUser)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;
            _param.Add(new SPParam("@customerID", _prmCustomerUser.CustomerID, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmCustomerUser.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@displayName", _prmCustomerUser.DisplayName, DbType.String));
            _param.Add(new SPParam("@membershipUserName", _prmCustomerUser.MembershipUserName, DbType.String));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmCustomerUser.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomerUser.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@userEmailAddress", _prmCustomerUser.UserEmailAddress, DbType.String));

            _paramOut.Add(new SPParamOut("@customerUserID", _prmCustomerUser.CustomerUserID, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsCustomerUser", _param, ref _paramOut, ref data);

            if (_success == true)

                _result = (int)data;


            return _result;
        }
    }
}
