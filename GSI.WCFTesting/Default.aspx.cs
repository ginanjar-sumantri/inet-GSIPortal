using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.WCFTesting.UpdateCPStatusServiceReference;
using GSI.WCFTesting.UpdateResultServiceReference;
using GSI.WCFTesting.UpdateStatusCoreSystemServiceReference;
using GSI.BusinessRuleCore;
using System.Configuration;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;

namespace GSI.WCFTesting
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Common.Enum.SurveyPointType _spType = Common.Enum.SurveyPointType.Movable;
            Common.Enum.GSIInternalStatus _status = Common.Enum.GSIInternalStatus.WaitingForDownload;

            if (this.SPTypeDropDownList.SelectedValue == "Movable")
            {
                _spType = Common.Enum.SurveyPointType.Movable;
            }
            else
            {
                _spType = Common.Enum.SurveyPointType.NotMovable;
            }

            switch (this.StatusDropDownList.SelectedValue)
            {

                case "WaitingForSurvey":
                    _status = Common.Enum.GSIInternalStatus.WaitingForSurvey;
                    break;
                case "OnTheWay":
                    _status = Common.Enum.GSIInternalStatus.OnTheWay;
                    break;
                case "OnTheSpot":
                    _status = Common.Enum.GSIInternalStatus.OnTheSpot;
                    break;
                case "ReceivedBySystem":
                    _status = Common.Enum.GSIInternalStatus.ReceivedBySystem;
                    break;
                default:
                    break;
            }

            UpdateStatusCoreSystemServiceReference.UpdateStatusServiceClient _client = new UpdateStatusCoreSystemServiceReference.UpdateStatusServiceClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.UpdateStatusCoreSystem(_spType, Convert.ToInt64(this.WOIDTextBox1.Text), _status, DateTime.Now);
            _client.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdateCPStatusServiceReference.SurveyPointType _spType2 = UpdateCPStatusServiceReference.SurveyPointType.Movable;
            UpdateCPStatusServiceReference.GSIInternalStatus _status2 = UpdateCPStatusServiceReference.GSIInternalStatus.WaitingForDownload;

            if (this.StatusCPDropDownList.SelectedValue == "Movable")
            {
                _spType2 = UpdateCPStatusServiceReference.SurveyPointType.Movable;
            }
            else
            {
                _spType2 = UpdateCPStatusServiceReference.SurveyPointType.NotMovable;
            }

            switch (this.StatusDropDownList.SelectedValue)
            {

                case "WaitingForSurvey":
                    _status2 = UpdateCPStatusServiceReference.GSIInternalStatus.WaitingForSurvey;
                    break;
                case "OnTheWay":
                    _status2 = UpdateCPStatusServiceReference.GSIInternalStatus.OnTheWay;
                    break;
                case "OnTheSpot":
                    _status2 = UpdateCPStatusServiceReference.GSIInternalStatus.OnTheSpot;
                    break;
                case "ReceivedBySystem":
                    _status2 = UpdateCPStatusServiceReference.GSIInternalStatus.ReceivedBySystem;
                    break;
                default:
                    break;
            }

            UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.UpdateStatusCustomerPortal(_spType2, Convert.ToInt64(this.OrderSPIDTextBox.Text), _status2, Request.ServerVariables["LOGON_USER"]);
            _client.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateResultServiceReference.UpdateResultServiceClient _client = new UpdateResultServiceReference.UpdateResultServiceClient();

            int _woID = 196;
            ////////////////////     MOVABLE     ////////////////////
            TrResultMovable _prmTrResultMovable = new TrResultMovable
            {
                WorkOrderMovableID = _woID,
                Remark = "result remark",
                BuildingArea = "sekitar sudirman",
                HouseStatus = "bagus",
                LengthOfStay = "1 year",
                PersonalCharacter = "nice",
                ResidenceConditions = "great",                
            };

            List<TrResultPhotoAdditionalMovable> _prmTrResultPhotoAdditionalMovable = new List<TrResultPhotoAdditionalMovable>()
            {
                new TrResultPhotoAdditionalMovable { PhotoName = "AP_GSI.JKT.SUR.003_003_67eeb12d-23b5-42b4-9b4c-f94c9f81238e_39.jpg", ImageGuid = "67EEB12D-23B5-42B4-9B4C-F94C9F81238E", Remark = "ada remark", Longitude = "106.742906", Latitude = "-6.2187253"}
                //new TrResultPhotoAdditionalMovable { PhotoName = "ada 2", ImageGuid = "ada", Remark = "ada", Longitude = "ada", Latitude = "ada"}
            };
            List<TrResultReqDocMovable> _prmTrResultReqDocMovable = new List<TrResultReqDocMovable>()
            {
                //new TrResultReqDocMovable { ReqDocMovableID = 264, PhotoName = "RD_GSI.JKT.SUR.001_001_705d6060-bdef-4ac7-92c4-8378f552b753_9.jpg", ImageGuid = "705d6060-bdef-4ac7-92c4-8378f552b753", Remark = "ada remark", Longitude = "106.77118626666667", Latitude = "-6.2324066"},
                //new TrResultReqDocMovable { ReqDocMovableID = 265, PhotoName = "RD_GSI.JKT.SUR.001_001_705d6060-bdef-4ac7-92c4-8378f552b753_9.jpg", ImageGuid = "705d6060-bdef-4ac7-92c4-8378f552b753", Remark = "ada remark", Longitude = "106.77118223666667", Latitude = "-6.2324066"}
            };
            ////////////////////     MOVABLE     ////////////////////

            //////////////////     NOT MOVABLE     //////////////////
            //TrResultNotMovable _prmTrResultNotMovable = new TrResultNotMovable { WorkOrderNotMovableID = _woID, CompanyPeriod = "januari", BusinessLine = "no line", CompanyCondition = "bobrok", Others = "-", Remark = "ga ada remark aja ahh" };
            TrResultNotMovable _prmTrResultNotMovable = new TrResultNotMovable 
            { 
                WorkOrderNotMovableID = _woID, 
                CompanyPeriod = "januari", 
                CompanyCondition = "bobrok", 
                Remark = "ga ada remark aja ahh", 
                Position = "Direktur", 
                WorkingPeriod = "2 tahun" 
            };

            List<TrResultPhotoAdditionalNotMovable> _prmTrResultPhotoAdditionalNotMovable = new List<TrResultPhotoAdditionalNotMovable>()
            {
                new TrResultPhotoAdditionalNotMovable { PhotoName = "RD_GSI.JKT.SUR.001_001_705d6060-bdef-4ac7-92c4-8378f552b753_9.jpg", ImageGuid = "705d6060-bdef-4ac7-92c4-8378f552b753", Remark = "document 1", Longitude = "106.742906", Latitude = "-6.2187253"},
                new TrResultPhotoAdditionalNotMovable { PhotoName = "AP_GSI.JKT.SUR.003_003_67eeb12d-23b5-42b4-9b4c-f94c9f81238e_39.jpg", ImageGuid = "67EEB12D-23B5-42B4-9B4C-F94C9F81238E", Remark = "document 2", Longitude = "106.77118223666667", Latitude = "-6.2324066"}
            };
            List<TrResultReqDocNotMovable> _prmTrResultReqDocNotMovable = new List<TrResultReqDocNotMovable>()
            {
                //new TrResultReqDocNotMovable { ReqDocNotMovableID = 109, PhotoName = "RD_GSI.JKT.SUR.003_003_9304ebc6-5ceb-46a8-98c8-c6ee2853a6dd_6.jpg", ImageGuid = "9304ebc6-5ceb-46a8-98c8-c6ee2853a6dd", Remark = "remark kalau panjang bisa ngefek apaan ya dicoba dulu ah ngarang-ngarang aja ah remarknya biar bisa panjang", Longitude = "106.74219512939453", Latitude = "-6.219478607177734"}
            };
            //////////////////     NOT MOVABLE     //////////////////

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            string _error = "";
            _client.InsertResultMovableCoreSystemBundle(_prmTrResultMovable, _prmTrResultPhotoAdditionalMovable.ToArray(), _prmTrResultReqDocMovable.ToArray(), ref _error);
            _client.InsertResultNotMovableCoreSystemBundle(_prmTrResultNotMovable, _prmTrResultPhotoAdditionalNotMovable.ToArray(), _prmTrResultReqDocNotMovable.ToArray(), ref _error);
            _client.Close();

            UpdateStatusCoreSystemServiceReference.UpdateStatusServiceClient _client2 = new UpdateStatusCoreSystemServiceReference.UpdateStatusServiceClient();
            //_client2.UpdateStatusCoreSystem(UpdateStatusCoreSystemServiceReference.SurveyPointType.Movable, _woID, UpdateStatusCoreSystemServiceReference.GSIInternalStatus.SurveyResultReceived);
            //_client2.UpdateStatusCoreSystem(UpdateStatusCoreSystemServiceReference.SurveyPointType.NotMovable, _woID, UpdateStatusCoreSystemServiceReference.GSIInternalStatus.SurveyResultReceived);
            //_client2.Close();
        }

        protected void SendEmailButton_Click(object sender, EventArgs e)
        {
            String _errMailMessage = "";
            GeneralHelper _helper = new GeneralHelper();
            String _EmailTO = this.EmailToTextBox.Text;
            List<String> _emailTo = new List<String>();
            _emailTo.Add(_EmailTO);
            //Boolean _resultMail = _helper.SendEmail(this.EmailFromTextBox.Text, _emailTo, this.EmailSubjectTextBox.Text, this.EmailMessageTextBox.Text, ref _errMailMessage);
            Boolean _resultMail2 = _helper.SendEmail(_emailTo, this.EmailSubjectTextBox.Text, this.EmailMessageTextBox.Text, ref _errMailMessage);
        }
    }
}
