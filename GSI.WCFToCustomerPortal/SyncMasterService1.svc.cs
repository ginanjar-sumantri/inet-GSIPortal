using System;
using System.Collections.Generic;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;

namespace GSI.WCFToCustomerPortal
{
    public class SyncMasterService : ISyncMasterService
    {
        private WCFBL _wcfBL = new WCFBL();
        
        String _errorWCF = "";
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

                long _msRegionID = 0;
                _wcfBL.SyncMsRegion(_msRegion, ref _msRegionID);
                if (_msRegionID == 0)
                {
                    _errorWCF = "Failed SyncMsRegion. ID = " + Convert.ToString(_msRegionID);
                }
            }
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
               
                long _msCustomerID = 0;
                _wcfBL.SyncMsCustomer(_msCustomer, ref _msCustomerID);
                if (_msCustomerID == 0)
                {
                    _errorWCF = "Failed SyncMsCustomer. ID = " + Convert.ToString(_msCustomerID);
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
                
                long _msCustomerUserID = 0;
                _wcfBL.SyncMsCustomerUser(_msCustomerUser, ref _msCustomerUserID);
                if (_msCustomerUserID == 0)
                {
                    _errorWCF = "Failed SyncMsCustomerUser. ID = " + Convert.ToString(_msCustomerUserID);
                }
            }
        }

    }
}
