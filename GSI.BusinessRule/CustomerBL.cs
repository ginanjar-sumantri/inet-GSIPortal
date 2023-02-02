using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class CustomerBL : Base
    {
        public CustomerBL()
        {
        }

        public MsCustomer GetCustomerInfoFromUser(String _prmUserName)
        {
            MsCustomer _result = new MsCustomer();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@prmUserName", _prmUserName, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetCustomerInfoFromUser", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomer _msCust = new MsCustomer();
                _msCust.CustomerID = (long)dr["CustomerID"];
                _msCust.CustomerName = (String)dr["CustomerName"];
                _msCust.DisplayName = (String)dr["DisplayName"];

                _result = _msCust;
                dr.Close();
            }

            return _result;
        }

        public MsCustomer CustomerByBusinessTypeID(long _prmBusinessTypeID)
        {
            MsCustomer _result = new MsCustomer();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@businessTypeID", _prmBusinessTypeID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerByBusinessTypeID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomer _msCustomer = new MsCustomer();
                _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                _msCustomer.City = (String)dr["City"];
                _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                _msCustomer.CustomerID = (long)dr["CustomerID"];
                _msCustomer.CustomerName = (String)dr["CustomerName"];
                _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                _msCustomer.fgActive = (bool)dr["fgActive"];
                _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                _msCustomer.PrimayContactFax = (String)dr["PrimaryContactFax"];
                _msCustomer.PrimayContactPhone = (String)dr["PrimaryContactPhone"];
                _msCustomer.PrimayContactPhoneExtension = (String)dr["PrimaryContactPhoneExtension"];
                _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                _msCustomer.Timestamp = (byte[])dr["Timestamp"];

                _result = _msCustomer;
                dr.Close();
            }

            return _result;
        }

        public MsCustomer CustomerNameByCustomerID(long _prmCustomerID)
        {
            MsCustomer _result = new MsCustomer();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustomerID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerByCustomerID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomer _msCustomer = new MsCustomer();
                _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                _msCustomer.City = (String)dr["City"];
                _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                _msCustomer.CustomerID = (long)dr["CustomerID"];
                _msCustomer.CustomerName = (String)dr["CustomerName"];
                _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                _msCustomer.fgActive = (bool)dr["fgActive"];
                _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                _msCustomer.PrimayContactFax = (String)dr["PrimaryContactFax"];
                _msCustomer.PrimayContactPhone = (String)dr["PrimaryContactPhone"];
                _msCustomer.PrimayContactPhoneExtension = (String)dr["PrimaryContactPhoneExtension"];
                _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                _msCustomer.Timestamp = (byte[])dr["Timestamp"];

                _result = _msCustomer;
                dr.Close();
            }

            return _result;
        }

        public MsCustomer GetMsCustomerByCustomerID(String _prmCustomerID)
        {
            MsCustomer _result = new MsCustomer();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustomerID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsCustomerByCustomerID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomer _msCustomer = new MsCustomer();
                _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                _msCustomer.City = (String)dr["City"];
                _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                _msCustomer.CustomerID = (long)dr["CustomerID"];
                _msCustomer.CustomerName = (String)dr["CustomerName"];
                _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                _msCustomer.fgActive = (bool)dr["fgActive"];
                _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                _msCustomer.PrimayContactFax = (String)dr["PrimaryContactFax"];
                _msCustomer.PrimayContactPhone = (String)dr["PrimaryContactPhone"];
                _msCustomer.PrimayContactPhoneExtension = (String)dr["PrimaryContactPhoneExtension"];
                _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                _msCustomer.Timestamp = (byte[])dr["Timestamp"];

                _result = _msCustomer;
                dr.Close();
            }

            return _result;
        }

        public List<MsCustomer> GetListFromMsCustomer(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            CustomerBL _empBL = new CustomerBL();
            List<MsCustomer> _result = new List<MsCustomer>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "MsCustomer", DbType.String));
            _param.Add(new SPParam("@fieldName", "", DbType.String));
            _param.Add(new SPParam("@fieldValue", 0, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomer", _param, ref _paramOut, ref data);
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTablePage", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {

                    MsCustomer _msCustomer = new MsCustomer();
                    _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _msCustomer.City = (String)dr["City"];
                    _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                    _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                    _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                    _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                    _msCustomer.CustomerID = (long)dr["CustomerID"];
                    _msCustomer.CustomerName = (String)dr["CustomerName"];
                    _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                    _msCustomer.fgActive = (bool)dr["fgActive"];
                    _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                    _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                    _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                    _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                    _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                    _msCustomer.PrimaryContactDepartment = (dr["PrimaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactDepartment"];
                    _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                    _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                    _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                    _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                    _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                    _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                    _msCustomer.PrimayContactFax = (dr["PrimayContactFax"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactFax"];
                    _msCustomer.PrimayContactPhone = (dr["PrimayContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhone"];
                    _msCustomer.PrimayContactPhoneExtension = (dr["PrimayContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhoneExtension"];
                    _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                    _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                    _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                    _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                    _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                    _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                    _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                    _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                    _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                    _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                    _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                    _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                    _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];

                    _result.Add(_msCustomer);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsCustomer> GetListFromMsCustomerForDDL()
        {
            List<MsCustomer> _result = new List<MsCustomer>();

            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMsCustomerForDDL", _param, ref _paramOut, ref data);

            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {

                    MsCustomer _msCustomer = new MsCustomer();
                    _msCustomer.CustomerID = (long)dr["CustomerID"];
                    _msCustomer.CustomerName = (String)dr["CustomerName"];

                    _result.Add(_msCustomer);
                }
                dr.Close();
            }

            return _result;
        }

        public List<MsCustomer> GetListMsCustomer()
        {
            List<MsCustomer> _result = new List<MsCustomer>();
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomer", _param, ref _paramOut, ref data);

            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {

                    MsCustomer _msCustomer = new MsCustomer();
                    _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _msCustomer.City = (String)dr["City"];
                    _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                    _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                    _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                    _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                    _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                    _msCustomer.CustomerID = (long)dr["CustomerID"];
                    _msCustomer.CustomerName = (String)dr["CustomerName"];
                    _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                    _msCustomer.fgActive = (bool)dr["fgActive"];
                    _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                    _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                    _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                    _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                    _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                    _msCustomer.PrimaryContactDepartment = (dr["PrimaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactDepartment"];
                    _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                    _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                    _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                    _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                    _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                    _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                    _msCustomer.PrimayContactFax = (dr["PrimayContactFax"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactFax"];
                    _msCustomer.PrimayContactPhone = (dr["PrimayContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhone"];
                    _msCustomer.PrimayContactPhoneExtension = (dr["PrimayContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhoneExtension"];
                    _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                    _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                    _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                    _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                    _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                    _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                    _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                    _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                    _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                    _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                    _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                    _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                    _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _result.Add(_msCustomer);
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
                    MsBusinessType _CustomertBL = new MsBusinessType();
                    _CustomertBL.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _CustomertBL.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];

                    _result.Add(_CustomertBL);
                }
                dr.Close();
            }

            return _result;
        }

        public MsCustomer GetAllCustomerID(String _prmCustomerID)
        {
            MsCustomer _result = new MsCustomer();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustomerID, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromMsCustomer", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsCustomer _msCustomer = new MsCustomer();
                _msCustomer.BusinessTypeID = (long)dr["BusinessTypeID"];
                _msCustomer.City = (String)dr["City"];
                _msCustomer.CreatedBy = (String)dr["CreatedBy"];
                _msCustomer.CreatedDate = (DateTime)dr["CreatedDate"];
                _msCustomer.CustomerAddress1 = (String)dr["CustomerAddress1"];
                _msCustomer.CustomerAddress2 = (dr["CustomerAddress2"] == DBNull.Value) ? String.Empty : (String)dr["CustomerAddress2"];
                _msCustomer.CustomerCode = (String)dr["CustomerCode"];
                _msCustomer.CustomerID = (long)dr["CustomerID"];
                _msCustomer.CustomerName = (String)dr["CustomerName"];
                _msCustomer.Fax = (dr["Fax"] == DBNull.Value) ? String.Empty : (String)dr["Fax"];
                _msCustomer.fgActive = (bool)dr["fgActive"];
                _msCustomer.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msCustomer.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msCustomer.NPPKP = (dr["NPPKP"] == DBNull.Value) ? String.Empty : (String)dr["NPPKP"];
                _msCustomer.NPWP = (dr["NPWP"] == DBNull.Value) ? String.Empty : (String)dr["NPWP"];
                _msCustomer.NPWPAddress = (dr["NPWPAddress"] == DBNull.Value) ? String.Empty : (String)dr["NPWPAddress"];
                _msCustomer.Phone = (dr["Phone"] == DBNull.Value) ? String.Empty : (String)dr["Phone"];
                _msCustomer.PrimaryContactEmail = (dr["PrimaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactEmail"];
                _msCustomer.PrimaryContactDepartment = (dr["PrimaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactDepartment"];
                _msCustomer.PrimaryContactHP = (dr["PrimaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactHP"];
                _msCustomer.PrimaryContactName = (dr["PrimaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactName"];
                _msCustomer.PrimaryGender = (String)dr["PrimaryGender"];
                _msCustomer.PrimaryPlaceOfBirth = (dr["PrimaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryPlaceOfBirth"];
                _msCustomer.PrimaryDateOfBirth = (dr["PrimaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["PrimaryDateOfBirth"];
                _msCustomer.PrimaryContactTitle = (dr["PrimaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["PrimaryContactTitle"];
                _msCustomer.PrimayContactFax = (dr["PrimayContactFax"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactFax"];
                _msCustomer.PrimayContactPhone = (dr["PrimayContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhone"];
                _msCustomer.PrimayContactPhoneExtension = (dr["PrimayContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["PrimayContactPhoneExtension"];
                _msCustomer.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msCustomer.RowStatus = (Int32)dr["RowStatus"];
                _msCustomer.SecondaryContactDepartment = (dr["SecondaryContactDepartment"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactDepartment"];
                _msCustomer.SecondaryContactEmail = (dr["SecondaryContactEmail"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactEmail"];
                _msCustomer.SecondaryContactFax = (dr["SecondaryContactFax"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactFax"];
                _msCustomer.SecondaryContactHP = (dr["SecondaryContactHP"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactHP"];
                _msCustomer.SecondaryGender = (String)dr["SecondaryGender"];
                _msCustomer.SecondaryPlaceOfBirth = (dr["SecondaryPlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryPlaceOfBirth"];
                _msCustomer.SecondaryDateOfBirth = (dr["SecondaryDateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SecondaryDateOfBirth"];
                _msCustomer.SecondaryContactName = (dr["SecondaryContactName"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactName"];
                _msCustomer.SecondaryContactPhone = (dr["SecondaryContactPhone"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhone"];
                _msCustomer.SecondaryContactPhoneExtension = (dr["SecondaryContactPhoneExtension"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactPhoneExtension"];
                _msCustomer.SecondaryContactTitle = (dr["SecondaryContactTitle"] == DBNull.Value) ? String.Empty : (String)dr["SecondaryContactTitle"];
                _msCustomer.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];

                _result = _msCustomer;
                dr.Close();
            }

            return _result;
        }

        public int DeletedCustomer(MsCustomer _prmCustomer)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "MsCustomer", DbType.String));
            _param.Add(new SPParam("@fieldName", "CustomerID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmCustomer.CustomerID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmCustomer.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomer.RowStatus, DbType.Int32));

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

        public Boolean UpdateCustomer(MsCustomer _prmMsCustomer)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@businessTypeID", _prmMsCustomer.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@city", _prmMsCustomer.City, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmMsCustomer.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@customerAddress1", _prmMsCustomer.CustomerAddress1, DbType.String));
            _param.Add(new SPParam("@customerAddress2", _prmMsCustomer.CustomerAddress2, DbType.String));
            _param.Add(new SPParam("@customerCode", _prmMsCustomer.CustomerCode, DbType.String)); ;
            _param.Add(new SPParam("@customerID", _prmMsCustomer.CustomerID, DbType.Int64));
            _param.Add(new SPParam("@customerName", _prmMsCustomer.CustomerName, DbType.String));
            _param.Add(new SPParam("@fax", _prmMsCustomer.Fax, DbType.String));
            _param.Add(new SPParam("@fgActive", _prmMsCustomer.fgActive, DbType.Boolean));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@nppkp", _prmMsCustomer.NPPKP, DbType.String));
            _param.Add(new SPParam("@npwp", _prmMsCustomer.NPWP, DbType.String));
            _param.Add(new SPParam("@npwpAddress", _prmMsCustomer.NPWPAddress, DbType.String));
            _param.Add(new SPParam("@phone", _prmMsCustomer.Phone, DbType.String));
            _param.Add(new SPParam("@primaryContactDepartment", _prmMsCustomer.PrimaryContactDepartment, DbType.String));
            _param.Add(new SPParam("@primaryContactEmail", _prmMsCustomer.PrimaryContactEmail, DbType.String));
            _param.Add(new SPParam("@primaryContactHP", _prmMsCustomer.PrimaryContactHP, DbType.String));
            _param.Add(new SPParam("@primaryContactName", _prmMsCustomer.PrimaryContactName, DbType.String));
            _param.Add(new SPParam("@primaryGender", _prmMsCustomer.PrimaryGender, DbType.String));
            _param.Add(new SPParam("@primaryPlaceOfBirth", _prmMsCustomer.PrimaryPlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@primaryDateOfBirth", _prmMsCustomer.PrimaryDateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@primaryContactTitle", _prmMsCustomer.PrimaryContactTitle, DbType.String));
            _param.Add(new SPParam("@primayContactFax", _prmMsCustomer.PrimayContactFax, DbType.String));
            _param.Add(new SPParam("@primayContactPhone", _prmMsCustomer.PrimayContactPhone, DbType.String));
            _param.Add(new SPParam("@primayContactPhoneExtension", _prmMsCustomer.PrimayContactPhoneExtension, DbType.String));
            _param.Add(new SPParam("@remark", _prmMsCustomer.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsCustomer.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@secondaryContactDepartment", _prmMsCustomer.SecondaryContactDepartment, DbType.String));
            _param.Add(new SPParam("@secondaryContactEmail", _prmMsCustomer.SecondaryContactEmail, DbType.String));
            _param.Add(new SPParam("@secondaryContactFax", _prmMsCustomer.SecondaryContactFax, DbType.String));
            _param.Add(new SPParam("@secondaryContactHP", _prmMsCustomer.SecondaryContactHP, DbType.String));
            _param.Add(new SPParam("@secondaryContactName", _prmMsCustomer.SecondaryContactName, DbType.String));
            _param.Add(new SPParam("@secondaryGender", _prmMsCustomer.SecondaryGender, DbType.String));
            _param.Add(new SPParam("@secondaryPlaceOfBirth", _prmMsCustomer.SecondaryPlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@secondaryDateOfBirth", _prmMsCustomer.SecondaryDateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@secondaryContactPhone", _prmMsCustomer.SecondaryContactPhone, DbType.String));
            _param.Add(new SPParam("@secondaryContactPhoneExtension", _prmMsCustomer.SecondaryContactPhoneExtension, DbType.String));
            _param.Add(new SPParam("@secondaryContactTitle", _prmMsCustomer.SecondaryContactTitle, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmMsCustomer.ZipCode, DbType.String));
            _param.Add(new SPParam("@timestamp", _prmMsCustomer.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateMsCustomer", _param, ref _paramOut, ref data);

            if (_success)
            {
                _result = true;
            }
            return _result;
        }
        //public int DeleteCustomer(MsCustomer _prmCustomer)
        //{
        //    int _result = 0;

        //    object data = null;
        //    List<SPParam> _param = new List<SPParam>();

        //    _param.Add(new SPParam("@customerID", _prmCustomer.CustomerID, DbType.Int64));


        //    List<SPParamOut> _paramOut = new List<SPParamOut>();

        //    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "DeleteMsSurveyor", _param, ref _paramOut, ref data);
        //    if (_success)
        //    {
        //        _result = (int)data;
        //    }

        //    return _result;
        //}

        public int InsertMsCustomer(MsCustomer _prmCustomer)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;


            _param.Add(new SPParam("@businessTypeID", _prmCustomer.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@city", _prmCustomer.City, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmCustomer.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@customerAddress1", _prmCustomer.CustomerAddress1, DbType.String));
            _param.Add(new SPParam("@customerAddress2", _prmCustomer.CustomerAddress2, DbType.String));
            _param.Add(new SPParam("@customerCode", _prmCustomer.CustomerCode, DbType.String)); ;
            _param.Add(new SPParam("@customerID", _prmCustomer.CustomerID, DbType.Int64));
            _param.Add(new SPParam("@customerName", _prmCustomer.CustomerName, DbType.String));
            _param.Add(new SPParam("@fax", _prmCustomer.Fax, DbType.String));
            _param.Add(new SPParam("@fgActive", _prmCustomer.fgActive, DbType.Boolean));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@nPPKP", _prmCustomer.NPPKP, DbType.String));
            _param.Add(new SPParam("@nPWP", _prmCustomer.NPWP, DbType.String));
            _param.Add(new SPParam("@nPWPAddress", _prmCustomer.NPWPAddress, DbType.String));
            _param.Add(new SPParam("@phone", _prmCustomer.Phone, DbType.String));
            _param.Add(new SPParam("@primaryContactDepartment", _prmCustomer.PrimaryContactDepartment, DbType.String));
            _param.Add(new SPParam("@primaryContactEmail", _prmCustomer.PrimaryContactEmail, DbType.String));
            _param.Add(new SPParam("@primaryContactHP", _prmCustomer.PrimaryContactHP, DbType.String));
            _param.Add(new SPParam("@primaryContactName", _prmCustomer.PrimaryContactName, DbType.String));
            _param.Add(new SPParam("@primaryGender", _prmCustomer.PrimaryGender, DbType.String));
            _param.Add(new SPParam("@primaryPlaceOfBirth", _prmCustomer.PrimaryPlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@primaryDateOfBirth", _prmCustomer.PrimaryDateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@primaryContactTitle", _prmCustomer.PrimaryContactTitle, DbType.String));
            _param.Add(new SPParam("@primayContactFax", _prmCustomer.PrimayContactFax, DbType.String));
            _param.Add(new SPParam("@primayContactPhone", _prmCustomer.PrimayContactPhone, DbType.String));
            _param.Add(new SPParam("@primayContactPhoneExtension", _prmCustomer.PrimayContactPhoneExtension, DbType.String));
            _param.Add(new SPParam("@remark", _prmCustomer.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomer.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@secondaryContactDepartment", _prmCustomer.SecondaryContactDepartment, DbType.String));
            _param.Add(new SPParam("@secondaryContactEmail", _prmCustomer.SecondaryContactEmail, DbType.String));
            _param.Add(new SPParam("@secondaryContactFax", _prmCustomer.SecondaryContactFax, DbType.String));
            _param.Add(new SPParam("@secondaryContactHP", _prmCustomer.SecondaryContactHP, DbType.String));
            _param.Add(new SPParam("@secondaryContactName", _prmCustomer.SecondaryContactName, DbType.String));
            _param.Add(new SPParam("@secondaryGender", _prmCustomer.SecondaryGender, DbType.String));
            _param.Add(new SPParam("@secondaryPlaceOfBirth", _prmCustomer.SecondaryPlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@secondaryDateOfBirth", _prmCustomer.SecondaryDateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@secondaryContactPhone", _prmCustomer.SecondaryContactPhone, DbType.String));
            _param.Add(new SPParam("@secondaryContactPhoneExtension", _prmCustomer.SecondaryContactPhoneExtension, DbType.String));
            _param.Add(new SPParam("@secondaryContactTitle", _prmCustomer.SecondaryContactTitle, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmCustomer.ZipCode, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertMsCustomer", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int InsertGen_LoginHistory(Gen_LoginHistory _prmGenLoginHistory)
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = false;
            _param.Add(new SPParam("@userName", _prmGenLoginHistory.UserName, DbType.String));
            _param.Add(new SPParam("@iPAddress", _prmGenLoginHistory.IPAddress, DbType.String));
            _param.Add(new SPParam("@date", _prmGenLoginHistory.Date, DbType.DateTime));
            _param.Add(new SPParam("@createdBy", _prmGenLoginHistory.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
            _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmGenLoginHistory.RowStatus, DbType.Int32));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertGen_LoginHistory", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }
    }
}
