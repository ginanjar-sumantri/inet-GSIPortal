using System;
using System.Collections.Generic;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.Common;
using System.Data;
using GSI.Common.Enum;

namespace GSI.WCFToCustomerPortal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SyncMasterService" in code, svc and config file together.
    public class SyncMasterService : ISyncMasterService
    {
        private WCFBL _wcfBL = new WCFBL();

        String _errorWCF = "";
        int _result;
        public void UpdateMsRegion(List<MsRegion> _prmMsRegion)
        {
            foreach (var _item in _prmMsRegion)
            {
                GSI.BusinessEntity.BusinessEntities.MsRegion _msRegion = new GSI.BusinessEntity.BusinessEntities.MsRegion();
                _msRegion.CreatedBy = _item.CreatedBy;
                _msRegion.CreatedDate = _item.CreatedDate;
                _msRegion.ModifiedBy = _item.ModifiedBy;
                _msRegion.ModifiedDate = _item.ModifiedDate;
                _msRegion.RegionCode = _item.RegionCode;
                _msRegion.RegionID = _item.RegionID;
                _msRegion.RegionName = _item.RegionName;
                _msRegion.RowStatus = _item.RowStatus;

                _result = _wcfBL.SyncMsRegion(_msRegion);
                if (_result != -1)
                {
                    _errorWCF = "Failed SyncMsRegion. ID = " + Convert.ToString(_item.RegionID);
                }
            }
            ErrorHandler.ErrorMessage = _errorWCF;
        }
        public void UpdateMsCustomer(List<MsCustomer> _prmMsCustomer)
        {
            foreach (var _item in _prmMsCustomer)
            {
                GSI.BusinessEntity.BusinessEntities.MsCustomer _msCustomer = new GSI.BusinessEntity.BusinessEntities.MsCustomer();
                _msCustomer.BusinessTypeID = _item.BusinessTypeID;
                _msCustomer.City = _item.City;
                _msCustomer.CreatedBy = _item.CreatedBy;
                _msCustomer.CreatedDate = _item.CreatedDate;
                _msCustomer.CustomerAddress1 = _item.CustomerAddress1;
                _msCustomer.CustomerAddress2 = _item.CustomerAddress2;
                _msCustomer.CustomerCode = _item.CustomerCode;
                _msCustomer.CustomerID = _item.CustomerID;
                _msCustomer.CustomerName = _item.CustomerName;
                _msCustomer.Fax = _item.Fax;
                _msCustomer.fgActive = _item.fgActive;
                _msCustomer.ModifiedBy = _item.ModifiedBy;
                _msCustomer.ModifiedDate = _item.ModifiedDate;
                _msCustomer.NPPKP = _item.NPPKP;
                _msCustomer.NPWP = _item.NPWP;
                _msCustomer.NPWPAddress = _item.NPWPAddress;
                _msCustomer.Phone = _item.Phone;
                _msCustomer.PrimaryContactDepartment = _item.PrimaryContactDepartment;
                _msCustomer.PrimaryContactEmail = _item.PrimaryContactEmail;
                _msCustomer.PrimaryContactHP = _item.PrimaryContactHP;
                _msCustomer.PrimaryContactName = _item.PrimaryContactName;
                _msCustomer.PrimaryGender = _item.PrimaryGender;
                _msCustomer.PrimaryPlaceOfBirth = _item.PrimaryPlaceOfBirth;
                _msCustomer.PrimaryDateOfBirth = _item.PrimaryDateOfBirth;
                _msCustomer.PrimaryContactTitle = _item.PrimaryContactTitle;
                _msCustomer.PrimayContactFax = _item.PrimayContactFax;
                _msCustomer.PrimayContactPhone = _item.PrimayContactPhone;
                _msCustomer.PrimayContactPhoneExtension = _item.PrimayContactPhoneExtension;
                _msCustomer.Remark = _item.Remark;
                _msCustomer.RowStatus = _item.RowStatus;
                _msCustomer.SecondaryContactDepartment = _item.SecondaryContactDepartment;
                _msCustomer.SecondaryContactEmail = _item.SecondaryContactEmail;
                _msCustomer.SecondaryContactFax = _item.SecondaryContactFax;
                _msCustomer.SecondaryContactHP = _item.SecondaryContactHP;
                _msCustomer.SecondaryContactName = _item.SecondaryContactName;
                _msCustomer.SecondaryGender = _item.SecondaryGender;
                _msCustomer.SecondaryPlaceOfBirth = _item.SecondaryPlaceOfBirth;
                _msCustomer.SecondaryDateOfBirth = _item.SecondaryDateOfBirth;
                _msCustomer.SecondaryContactPhone = _item.SecondaryContactPhone;
                _msCustomer.SecondaryContactPhoneExtension = _item.SecondaryContactPhoneExtension;
                _msCustomer.SecondaryContactTitle = _item.SecondaryContactTitle;
                _msCustomer.ZipCode = _item.ZipCode;

                _result = _wcfBL.SyncMsCustomer(_msCustomer);
                if (_result == 0)
                {
                    _errorWCF = "Failed SyncMsCustomer. ID = " + Convert.ToString(_item.CustomerID);
                }
            }
        }
        public void UpdateMsCustomerUser(List<MsCustomerUser> _prmMsCustomerUser)
        {
            foreach (var _item in _prmMsCustomerUser)
            {
                GSI.BusinessEntity.BusinessEntities.MsCustomerUser _msCustomerUser = new GSI.BusinessEntity.BusinessEntities.MsCustomerUser();
                _msCustomerUser.CustomerID = _item.CustomerID;
                _msCustomerUser.CreatedBy = _item.CreatedBy;
                _msCustomerUser.CreatedDate = _item.CreatedDate;
                _msCustomerUser.DisplayName = _item.DisplayName;
                _msCustomerUser.MembershipUserName = _item.MembershipUserName;
                _msCustomerUser.ModifiedBy = _item.ModifiedBy;
                _msCustomerUser.ModifiedDate = _item.ModifiedDate;
                _msCustomerUser.Remark = _item.Remark;
                _msCustomerUser.RowStatus = _item.RowStatus;
                _msCustomerUser.UserEmailAddress = _item.UserEmailAddress;
                _msCustomerUser.CustomerUserID = _item.CustomerUserID;

                _result = _wcfBL.SyncMsCustomerUser(_msCustomerUser);
                if (_result != -1)
                {
                    _errorWCF = "Failed SyncMsCustomerUser. ID = " + Convert.ToString(_item.CustomerID);
                }
            }
            ErrorHandler.ErrorMessage = _errorWCF;
        }
        public void UpdateMsRegionZipCode(List<MsRegionZipCode> _prmMsRegion)
        {
            foreach (var _item in _prmMsRegion)
            {
                GSI.BusinessEntity.BusinessEntities.MsRegionZipCode _msRegionZipCode = new GSI.BusinessEntity.BusinessEntities.MsRegionZipCode();
                _msRegionZipCode.CreatedBy = _item.CreatedBy;
                _msRegionZipCode.CreatedDate = _item.CreatedDate;
                _msRegionZipCode.ModifiedBy = _item.ModifiedBy;
                _msRegionZipCode.ModifiedDate = _item.ModifiedDate;
                _msRegionZipCode.ZipCode = _item.ZipCode;
                _msRegionZipCode.RegionID = _item.RegionID;
                _msRegionZipCode.RegionZipCodeID = _item.RegionZipCodeID;
                _msRegionZipCode.RowStatus = _item.RowStatus;

                _result = _wcfBL.SyncMsRegionZipCode(_msRegionZipCode);
                if (_result != -1)
                {
                    _errorWCF = "Failed SyncMsRegionZipCode. ID = " + Convert.ToString(_item.RegionZipCodeID);
                }
            }
            ErrorHandler.ErrorMessage = _errorWCF;
        }

        public void DoWork()
        {
        }

        public List<Gen_LoginHistory> GetListGenLoginHistory(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmFieldName, Int64 _prmFieldValue, String _prmOrderBy, String _prmAscDesc, ref Int32 _countData)
        {
            List<Gen_LoginHistory> _genLoginHistory = new List<Gen_LoginHistory>();

            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@tableName", "Gen_LoginHistory", DbType.String));
            _param.Add(new SPParam("@fieldName", _prmFieldName, DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmFieldValue, DbType.Int64));
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
                    Gen_LoginHistory _msUserHistory = new Gen_LoginHistory();
                    _msUserHistory.LoginHistoryID = (dr["LoginHistoryID"] == DBNull.Value) ? 0 : (Int64)dr["LoginHistoryID"];
                    _msUserHistory.IPAddress = (dr["IPAddress"] == DBNull.Value) ? "" : (String)dr["IPAddress"];
                    _msUserHistory.UserName = (dr["UserName"] == DBNull.Value) ? "" : (String)dr["UserName"];
                    _msUserHistory.Date = (DateTime)dr["Date"];
                    _msUserHistory.RowStatus = (dr["RowStatus"] == DBNull.Value) ? 0 : (Int32)dr["RowStatus"];
                    _msUserHistory.CreatedBy = (dr["CreatedBy"] == DBNull.Value) ? "" : (String)dr["CreatedBy"];
                    _msUserHistory.CreatedDate = (DateTime)dr["Date"];
                    _msUserHistory.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? "" : (String)dr["ModifiedBy"];
                    _msUserHistory.ModifiedDate = (DateTime)dr["ModifiedDate"];
                    _genLoginHistory.Add(_msUserHistory);
                    //RequestVariable.RowCount = (Int32)dr["RowCounts"];
                    _countData = (Int32)dr["RowCounts"];
                }                
                dr.Close();
            }

            return _genLoginHistory;
        }
    }
}
