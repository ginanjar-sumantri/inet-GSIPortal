using System;
using System.Collections.Generic;
using System.Net.Mail;
using GSI.Common.Enum;
using GSI.BusinessRule;
using GSI.BusinessEntity.BusinessEntities;

namespace GSI.BusinessRuleCore
{
    public class GeneralHelper : Base
    {
        public GeneralHelper()
        {
        }
        ~GeneralHelper()
        {
        }

        public Boolean SendEmail(List<String> _prmEmailTo, String _prmSubject, String _prmMsg, ref String _errMessage)
        {
            Boolean _result = false;

            try
            {
                if (_prmEmailTo.Count == 0) { _errMessage = "Unable to send Email, Invalid Destination Email Address"; return false; }

                MailMessage _msgMail = new MailMessage();
                foreach (var _item in _prmEmailTo) { _msgMail.To.Add(new MailAddress(_item)); }
                //_msgMail.From = new MailAddress(_prmEmailFrom);
                _msgMail.Subject = _prmSubject;
                _msgMail.IsBodyHtml = true;

                String _oldBody = "";
                String _newBody = _oldBody + _prmMsg;
                _msgMail.Body = _newBody;

                SmtpClient _smtp = new SmtpClient();
                _smtp.Send(_msgMail);
                _result = true;
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message;
            }

            return _result;
        }

        public Boolean SendEmail(String _prmEmailFrom, List<String> _prmEmailTo, String _prmSubject, String _prmMsg, ref String _errMessage)
        {
            Boolean _result = false;

            try
            {
                if (_prmEmailTo.Count == 0) { _errMessage = "Unable to send Email, Invalid Destination Email Address"; return false; }

                MailMessage _msgMail = new MailMessage();
                foreach (var _item in _prmEmailTo) { _msgMail.To.Add(new MailAddress(_item)); }
                _msgMail.From = new MailAddress(_prmEmailFrom);
                _msgMail.Subject = _prmSubject;
                _msgMail.IsBodyHtml = true;

                String _oldBody = "";
                String _newBody = _oldBody + _prmMsg;
                _msgMail.Body = _newBody;

                SmtpClient _smtp = new SmtpClient();
                _smtp.Send(_msgMail);
                _result = true;
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message;
            }

            return _result;
        }

        public List<String> GetEmailFromTarget(DestinationEmail _prmTarget, String _prmTargetID)
        {
            List<String> _result = new List<String>();

            switch (_prmTarget)
            {
                case DestinationEmail.Customer:
                    CustomerBL _custBL = new CustomerBL();
                    MsCustomer _msCust = _custBL.GetMsCustomerByCustomerID(_prmTargetID);
                    if (_msCust.PrimaryContactEmail != "") _result.Add(_msCust.PrimaryContactEmail);
                    if (_msCust.SecondaryContactEmail != "") _result.Add(_msCust.SecondaryContactEmail);
                    //if (_msCust.UserEmailAddress != "") _result.Add(_msCust.UserEmailAddress);
                    break;
                case DestinationEmail.Dispatcher:
                    _result.Add(new EmployeeBL().GetSingleEmployeeByEmployeeLogon(_prmTargetID).Email);
                    break;
                case DestinationEmail.Surveyor:
                    long _empID = new SurveyorBL().GetSingleSurveyor(Convert.ToInt64(_prmTargetID)).EmployeeID;
                    _result.Add(new EmployeeBL().GetSingleEmployee(_empID).Email);
                    break;
            }

            return _result;
        }

        public String MailMessengeBuilderToSurveyor(String _prmWONo, String _prmSurveyPoint, String _prmSurveyName, String _prmSurveyorName)
        {
            String _result = "";

            _result += "<br>" + "No. WO             : " + _prmWONo;
            _result += "<br>" + "Survey Point       : " + _prmSurveyPoint;
            _result += "<br>" + "Nama Survey 		: " + _prmSurveyName;
            _result += "<br>" + "Kepada Surveyor 	: " + _prmSurveyorName;
            _result += "<br>";
            _result += "<br>" + "Telah diterima, silahkan download pada GSI – Mobile Application";
            _result += "<br>";
            _result += "<br>" + "Global Survey Indonesia";

            return _result;
        }
        public String MailMessengeBuilderToCustomer(String _prmCustName, String _prmSurveyPoint, String _prmOrderNo, String _prmSurveyName, String _prmWebPage)
        {
            String _result = "";

            _result += "<br>" + "Kepada Pelanggan Yth " + _prmCustName + ",";
            _result += "<br>";
            _result += "<br>" + "No. Order  		: " + _prmOrderNo;
            _result += "<br>" + "Survey Point       : " + _prmSurveyPoint;
            _result += "<br>" + "Survey Name 		: " + _prmSurveyName;
            _result += "<br>";
            _result += "<br>" + " Telah selesai di survey, silahkan cek kelengkapan datanya di " + _prmWebPage + " pada menu \'List Order\'";
            _result += "<br>";
            _result += "<br>" + "Global Survey Indonesia";

            return _result;
        }
        public String MailMessengeBuilderToDispatcher(String _prmWONo, String _prmSurveyPoint, String _prmSurveyName, String _prmSurveyorName, String _prmOrderNo)
        {
            String _result = "";

            _result += "<br>" + "No. WO             : " + _prmWONo;
            _result += "<br>" + "Survey Point       : " + _prmSurveyPoint;
            _result += "<br>" + "Survey Name        : " + _prmSurveyName;
            _result += "<br>" + "Oleh Surveyor      : " + _prmSurveyorName;
            _result += "<br>";
            _result += "<br>" + "Telah selesai disurvey, silahkan cek kelengkapan data hasil survey pada  Core System pada menu \'Survey Point List\' dengan no. Order : " + _prmOrderNo;
            _result += "<br>";
            _result += "<br>" + "Surveyor Division";

            return _result;
        }

        public static String GetEmailSubject(DestinationEmail _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case DestinationEmail.Customer:
                    _result = "Notifikasi Survey Order Selesai";
                    break;
                case DestinationEmail.Dispatcher:
                    _result = "Notifikasi Survey Order selesai di survey oleh Surveyor";
                    break;
                case DestinationEmail.Surveyor:
                    _result = "Notifikasi Survey Order";
                    break;
                default:
                    break;
            }

            return _result;
        }
    }
}
