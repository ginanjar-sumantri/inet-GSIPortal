using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using System.Web.Security;
using GSI.Authentication;

namespace GSI.BusinessRuleCore
{
    public class UserBL : Base
    {
        public UserBL()
        {
        }
        private MembershipService _membershipService = new MembershipService();

        public Boolean ChangePasswordWithoutOld(string _prmUserName, string _prmNewPassword)
        {
            Boolean _result = false;
            try
            {
                MembershipUser _member = _membershipService.GetUser(_prmUserName, false);
                _member.UnlockUser();
                _result = _member.ChangePassword(_member.ResetPassword(), _prmNewPassword);
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorMessage += ex.Message;
            }
            return _result;
        }

        public Boolean CreateUser(string _prmUserName, string _prmNewPassword, string _prmEmail)
        {
            Boolean _result = false;
            ErrorHandler.ErrorMessage = "";
            MembershipCreateStatus _prmOutput;
            try
            {
                this._membershipService.CreateUser(_prmUserName, _prmNewPassword, _prmEmail, this._defaultQuestion, this._defaultAnswer, false, out _prmOutput);
                switch (_prmOutput)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        ErrorHandler.ErrorMessage = "Email Already Use By Another User";
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        ErrorHandler.ErrorMessage = "User Name Already Use By Another User";
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        ErrorHandler.ErrorMessage = "Your Email is Invalid";
                        break;
                    case MembershipCreateStatus.Success:
                        ErrorHandler.ErrorMessage = "Success Save Data";
                        _result = true;
                        break;
                    default:
                        ErrorHandler.ErrorMessage = "Invalid Create New User";
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorMessage += ex.Message;
            }
            return _result;
        }

        public string ConnectionString(string _prmUserName)   
        {
            string _result = "Data Source=192.168.88.3\\SurveyorSystem;Initial Catalog=CoreSystem;User Id=webaccess;Password=password.1;";
            return _result;
        }
    }
}
