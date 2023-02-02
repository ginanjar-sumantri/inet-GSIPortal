using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class UserManagementBL : Base
    {
        public List<MsCustomerUser> GetMsCustomerUserByCustomerID(Int64 _prmCustomerID, Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<MsCustomerUser> _result = new List<MsCustomerUser>();

            List<SPParam> _param = new List<SPParam>();
            //_param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            _param.Add(new SPParam("@tableName", "MsCustomerUser", DbType.String));
            _param.Add(new SPParam("@fieldName", "CustomerID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmCustomerID, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerUserByCustomerID", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsCustomerUser _MsCustomerUser = new MsCustomerUser();
                    _MsCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                    _MsCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                    _MsCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                    _MsCustomerUser.CustomerID = (long)dr["CustomerID"];
                    _result.Add(_MsCustomerUser);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }
            return _result;
        }

        public MsCustomerUser GetSingleMsCustomerUserByCustomerID(Int64 _prmCustomerID)
        {
            MsCustomerUser _result = new MsCustomerUser();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerUserByCustomerID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    MsCustomerUser _MsCustomerUser = new MsCustomerUser();
                    _MsCustomerUser.DisplayName = (dr["DisplayName"] == DBNull.Value) ? "" : (String)dr["DisplayName"];
                    _MsCustomerUser.UserEmailAddress = (dr["UserEmailAddress"] == DBNull.Value) ? "" : (String)dr["UserEmailAddress"];
                    _MsCustomerUser.MembershipUserName = (dr["MembershipUserName"] == DBNull.Value) ? "" : (String)dr["MembershipUserName"];
                    _MsCustomerUser.CustomerID = (long)dr["CustomerID"];
                    _result = _MsCustomerUser;
                }
                dr.Close();
            }
            return _result;
        }
    }
}
