using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;
using System.Web.Security;
using GSI.Authentication;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using System.Configuration;

namespace GSI.BusinessRuleCore
{
    public class WCFBL : Base
    {
        private ResultBL _resultBL = new ResultBL();
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();
        private EmployeeBL _employeeBL = new EmployeeBL();
        private OrderSurveyPointBL _trOrderSP = new OrderSurveyPointBL();


        public String PublishedMoveable(Int64 _prmOrderSPMovableID)
        {

            String _result = "";

            TrWorkOrderMovable _trWorkOrderMovable = this._workOrderBL.GetSingleWorkOrderMovableByOrderSPMovableID(_prmOrderSPMovableID);

            UpdateCPResultServiceReference.TrWorkOrderMovable _wcfTrWorkOrderMovable = new UpdateCPResultServiceReference.TrWorkOrderMovable();
            _wcfTrWorkOrderMovable.WorkOrderMovableID = _trWorkOrderMovable.WorkOrderMovableID;
            _wcfTrWorkOrderMovable.OrderSPMovableID = _trWorkOrderMovable.OrderSPMovableID;
            _wcfTrWorkOrderMovable.SurveyorID = _trWorkOrderMovable.SurveyorID;
            _wcfTrWorkOrderMovable.WorkOrderCode = _trWorkOrderMovable.WorkOrderCode;
            _wcfTrWorkOrderMovable.DateCreate = _trWorkOrderMovable.DateCreate;
            _wcfTrWorkOrderMovable.DateExecute = _trWorkOrderMovable.DateExecute;
            _wcfTrWorkOrderMovable.WorkOrderStatusID = _trWorkOrderMovable.WorkOrderStatusID;
            _wcfTrWorkOrderMovable.SyncStatus = _trWorkOrderMovable.SyncStatus;
            _wcfTrWorkOrderMovable.Remark = _trWorkOrderMovable.Remark;
            _wcfTrWorkOrderMovable.DownloadDate = _trWorkOrderMovable.DownloadDate;
            _wcfTrWorkOrderMovable.OnTheWayDate = _trWorkOrderMovable.OnTheWayDate;
            _wcfTrWorkOrderMovable.OnTheSpotDate = _trWorkOrderMovable.OnTheSpotDate;
            _wcfTrWorkOrderMovable.SurveyResultReceivedDate = _trWorkOrderMovable.SurveyResultReceivedDate;
            _wcfTrWorkOrderMovable.RowStatus = _trWorkOrderMovable.RowStatus;
            _wcfTrWorkOrderMovable.CreatedBy = _trWorkOrderMovable.CreatedBy;
            _wcfTrWorkOrderMovable.CreatedDate = _trWorkOrderMovable.CreatedDate;
            _wcfTrWorkOrderMovable.ModifiedBy = _trWorkOrderMovable.ModifiedBy;
            _wcfTrWorkOrderMovable.ModifiedDate = _trWorkOrderMovable.ModifiedDate;
            //_wcfTrWorkOrderMovable.Timestamp = _trWorkOrderMovable.Timestamp;

            TrResultMovable _trResultMovable = this._resultBL.GetSingleTrResultMovable(_trWorkOrderMovable.WorkOrderMovableID);

            UpdateCPResultServiceReference.TrResultMovable _wcfTrResultMovable = new UpdateCPResultServiceReference.TrResultMovable();
            //_wcfTrResultMovable.ResultMovableID = _trResultMovable.ResultMovableID;
            _wcfTrResultMovable.WorkOrderMovableID = _trResultMovable.WorkOrderMovableID;
            _wcfTrResultMovable.HouseStatus = _trResultMovable.HouseStatus;
            _wcfTrResultMovable.LengthOfStay = _trResultMovable.LengthOfStay;
            _wcfTrResultMovable.ResidenceConditions = _trResultMovable.ResidenceConditions;
            _wcfTrResultMovable.EnvironmentalConditions = _trResultMovable.EnvironmentalConditions;
            _wcfTrResultMovable.BuildingArea = _trResultMovable.BuildingArea;
            _wcfTrResultMovable.PersonalCharacter = _trResultMovable.PersonalCharacter;
            //_wcfTrResultMovable.Others = _trResultMovable.Others;
            _wcfTrResultMovable.Remark = _trResultMovable.Remark;
            _wcfTrResultMovable.RowStatus = _trResultMovable.RowStatus;
            _wcfTrResultMovable.CreatedBy = _trResultMovable.CreatedBy;
            _wcfTrResultMovable.CreatedDate = _trResultMovable.CreatedDate;
            _wcfTrResultMovable.ModifiedBy = _trResultMovable.ModifiedBy;
            _wcfTrResultMovable.ModifiedDate = _trResultMovable.ModifiedDate;
            //_wcfTrResultMovable.Timestamp = _trResultMovable.Timestamp;

            List<TrResultPhotoAdditionalMovable> _trResultPhotoAdditionalMovable = this._resultBL.GetResultAdditionalPhotobyResultMovableID(_trResultMovable.ResultMovableID);
            List<UpdateCPResultServiceReference.TrResultPhotoAdditionalMovable> _wcfTrResultPhotoAdditionalMovable = new List<UpdateCPResultServiceReference.TrResultPhotoAdditionalMovable>();

            foreach (var _dt in _trResultPhotoAdditionalMovable)
            {
                UpdateCPResultServiceReference.TrResultPhotoAdditionalMovable _wcfDt = new UpdateCPResultServiceReference.TrResultPhotoAdditionalMovable();
                //_wcfDt.ResultPhotoAdditionalMovableID = _dt.ResultPhotoAdditionalMovableID;
                //_wcfDt.ResultMovableID = _dt.ResultMovableID;
                _wcfDt.ImageGuid = _dt.ImageGuid;
                _wcfDt.PhotoName = _dt.PhotoName;
                _wcfDt.Longitude = _dt.Longitude;
                _wcfDt.Latitude = _dt.Latitude;
                _wcfDt.UploadDate = _dt.UploadDate;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.CreatedBy = _dt.CreatedBy;
                _wcfDt.CreatedDate = _dt.CreatedDate;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                //_wcfDt.Timestamp = _dt.Timestamp;
                _wcfTrResultPhotoAdditionalMovable.Add(_wcfDt);
            }

            List<TrResultReqDocMovable> _trResultReqDocMovable = this._resultBL.GetListTrResultReqDocMovable(_trResultMovable.ResultMovableID);
            List<UpdateCPResultServiceReference.TrResultReqDocMovable> _wcfTrResultReqDocMovable = new List<UpdateCPResultServiceReference.TrResultReqDocMovable>();

            foreach (var _dt in _trResultReqDocMovable)
            {
                UpdateCPResultServiceReference.TrResultReqDocMovable _wcfDt = new UpdateCPResultServiceReference.TrResultReqDocMovable();
                //_wcfDt.ResultReqDocMovableID = _dt.ResultReqDocMovableID;
                //_wcfDt.ResultMovableID = _dt.ResultMovableID;
                _wcfDt.ReqDocMovableID = _dt.ReqDocMovableID;
                _wcfDt.ImageGuid = _dt.ImageGuid;
                _wcfDt.PhotoName = _dt.PhotoName;
                _wcfDt.Longitude = _dt.Longitude;
                _wcfDt.Latitude = _dt.Latitude;
                _wcfDt.UploadDate = _dt.UploadDate;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.CreatedBy = _dt.CreatedBy;
                _wcfDt.CreatedDate = _dt.CreatedDate;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                //_wcfDt.Timestamp = _dt.Timestamp;
                _wcfTrResultReqDocMovable.Add(_wcfDt);
            }

            UpdateCPResultServiceReference.UpdateCPResultServiceClient _client = new UpdateCPResultServiceReference.UpdateCPResultServiceClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.UpdateResultMovableCustomerPortal(_wcfTrWorkOrderMovable, _wcfTrResultMovable, _wcfTrResultPhotoAdditionalMovable.ToArray(), _wcfTrResultReqDocMovable.ToArray());
            _client.Close();

            //Log


            GSI.BusinessEntity.BusinessEntities.TrOrderSPMovable _trOrderSPMov = this._trOrderSP.GetSingleTrOrderMovable(_trWorkOrderMovable.OrderSPMovableID);
            TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMov.OrderID);
            MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMov.SurveyPointID);
            GSI.BusinessEntity.BusinessEntities.MsEmployee _msEmployee = this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPMov.UserTakeOver);
            //GSI.BusinessEntity.BusinessEntities.MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(_trWorkOrderMovable.SurveyorID);

            GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

            DateTime _now = DateTime.Now;
            _trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWorkOrderMovable.SurveyorID);
            _trOrderSPLog.CreatedDate = _now;
            _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
            _trOrderSPLog.OrderSPID = _trOrderSPMov.OrderSPMovableID;
            _trOrderSPLog.DateTime = _now;
            _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
            _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
            _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.AfterProcess);
            _trOrderSPLog.EmployeeID = _msEmployee.EmployeeID;
            _trOrderSPLog.RowStatus = 0;

            this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

            return _result;
        }

        public String PublishedNotMoveable(Int64 _prmOrderSPNotMovableID)
        {
            String _result = "";

            TrWorkOrderNotMovable _trWorkOrderNotMovable = this._workOrderBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_prmOrderSPNotMovableID);

            UpdateCPResultServiceReference.TrWorkOrderNotMovable _wcfTrWorkOrderNotMovable = new UpdateCPResultServiceReference.TrWorkOrderNotMovable();
            _wcfTrWorkOrderNotMovable.WorkOrderNotMovableID = _trWorkOrderNotMovable.WorkOrderNotMovableID;
            _wcfTrWorkOrderNotMovable.OrderSPNotMovableID = _trWorkOrderNotMovable.OrderSPNotMovableID;
            _wcfTrWorkOrderNotMovable.SurveyorID = _trWorkOrderNotMovable.SurveyorID;
            _wcfTrWorkOrderNotMovable.WorkOrderCode = _trWorkOrderNotMovable.WorkOrderCode;
            _wcfTrWorkOrderNotMovable.DateCreate = _trWorkOrderNotMovable.DateCreate;
            _wcfTrWorkOrderNotMovable.DateExecute = _trWorkOrderNotMovable.DateExecute;
            _wcfTrWorkOrderNotMovable.WorkOrderStatusID = _trWorkOrderNotMovable.WorkOrderStatusID;
            _wcfTrWorkOrderNotMovable.SyncStatus = _trWorkOrderNotMovable.SyncStatus;
            _wcfTrWorkOrderNotMovable.Remark = _trWorkOrderNotMovable.Remark;
            _wcfTrWorkOrderNotMovable.DownloadDate = _trWorkOrderNotMovable.DownloadDate;
            _wcfTrWorkOrderNotMovable.OnTheWayDate = _trWorkOrderNotMovable.OnTheWayDate;
            _wcfTrWorkOrderNotMovable.OnTheSpotDate = _trWorkOrderNotMovable.OnTheSpotDate;
            _wcfTrWorkOrderNotMovable.SurveyResultReceivedDate = _trWorkOrderNotMovable.SurveyResultReceivedDate;
            _wcfTrWorkOrderNotMovable.RowStatus = _trWorkOrderNotMovable.RowStatus;
            _wcfTrWorkOrderNotMovable.CreatedBy = _trWorkOrderNotMovable.CreatedBy;
            _wcfTrWorkOrderNotMovable.CreatedDate = _trWorkOrderNotMovable.CreatedDate;
            _wcfTrWorkOrderNotMovable.ModifiedBy = _trWorkOrderNotMovable.ModifiedBy;
            _wcfTrWorkOrderNotMovable.ModifiedDate = _trWorkOrderNotMovable.ModifiedDate;
            //_wcfTrWorkOrderNotMovable.Timestamp = _trWorkOrderNotMovable.Timestamp;

            TrResultNotMovable _trResultNotMovable = this._resultBL.GetSingleTrResultNotMovable(_trWorkOrderNotMovable.WorkOrderNotMovableID);

            UpdateCPResultServiceReference.TrResultNotMovable _wcfTrResultNotMovable = new UpdateCPResultServiceReference.TrResultNotMovable();
            //_wcfTrResultNotMovable.ResultNotMovableID = _trResultNotMovable.ResultNotMovableID;
            _wcfTrResultNotMovable.WorkOrderNotMovableID = _trResultNotMovable.WorkOrderNotMovableID;
            _wcfTrResultNotMovable.CompanyPeriod = _trResultNotMovable.CompanyPeriod;
            _wcfTrResultNotMovable.CompanyCondition = _trResultNotMovable.CompanyCondition;
            _wcfTrResultNotMovable.Position = _trResultNotMovable.Position;
            _wcfTrResultNotMovable.WorkingPeriod = _trResultNotMovable.WorkingPeriod;
            //_wcfTrResultNotMovable.BusinessLine = _trResultNotMovable.BusinessLine;
            //_wcfTrResultNotMovable.Others = _trResultNotMovable.Others;
            _wcfTrResultNotMovable.Remark = _trResultNotMovable.Remark;
            _wcfTrResultNotMovable.RowStatus = _trResultNotMovable.RowStatus;
            _wcfTrResultNotMovable.CreatedBy = _trResultNotMovable.CreatedBy;
            _wcfTrResultNotMovable.CreatedDate = _trResultNotMovable.CreatedDate;
            _wcfTrResultNotMovable.ModifiedBy = _trResultNotMovable.ModifiedBy;
            _wcfTrResultNotMovable.ModifiedDate = _trResultNotMovable.ModifiedDate;
            //_wcfTrResultNotMovable.Timestamp = _trResultNotMovable.Timestamp;

            List<TrResultPhotoAdditionalNotMovable> _trResultPhotoAdditionalNotMovable = this._resultBL.GetResultAdditionalPhotobyResultNotMovableID(_trResultNotMovable.ResultNotMovableID);
            List<UpdateCPResultServiceReference.TrResultPhotoAdditionalNotMovable> _wcfTrResultPhotoAdditionalNotMovable = new List<UpdateCPResultServiceReference.TrResultPhotoAdditionalNotMovable>();

            foreach (var _dt in _trResultPhotoAdditionalNotMovable)
            {
                UpdateCPResultServiceReference.TrResultPhotoAdditionalNotMovable _wcfDt = new UpdateCPResultServiceReference.TrResultPhotoAdditionalNotMovable();
                //_wcfDt.ResultPhotoAdditionalNotMovableID = _dt.ResultPhotoAdditionalNotMovableID;
                //_wcfDt.ResultNotMovableID = _dt.ResultNotMovableID;
                _wcfDt.ImageGuid = _dt.ImageGuid;
                _wcfDt.PhotoName = _dt.PhotoName;
                _wcfDt.Longitude = _dt.Longitude;
                _wcfDt.Latitude = _dt.Latitude;
                _wcfDt.UploadDate = _dt.UploadDate;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.CreatedBy = _dt.CreatedBy;
                _wcfDt.CreatedDate = _dt.CreatedDate;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                //_wcfDt.Timestamp = _dt.Timestamp;
                _wcfTrResultPhotoAdditionalNotMovable.Add(_wcfDt);
            }

            List<TrResultReqDocNotMovable> _trResultReqDocNotMovable = this._resultBL.GetListTrResultReqDocNotMovable(_trResultNotMovable.ResultNotMovableID);
            List<UpdateCPResultServiceReference.TrResultReqDocNotMovable> _wcfTrResultReqDocNotMovable = new List<UpdateCPResultServiceReference.TrResultReqDocNotMovable>();

            foreach (var _dt in _trResultReqDocNotMovable)
            {
                UpdateCPResultServiceReference.TrResultReqDocNotMovable _wcfDt = new UpdateCPResultServiceReference.TrResultReqDocNotMovable();
                //_wcfDt.ResultReqDocNotMovableID = _dt.ResultReqDocNotMovableID;
                //_wcfDt.ResultNotMovableID = _dt.ResultNotMovableID;
                _wcfDt.ReqDocNotMovableID = _dt.ReqDocNotMovableID;
                _wcfDt.ImageGuid = _dt.ImageGuid;
                _wcfDt.PhotoName = _dt.PhotoName;
                _wcfDt.Longitude = _dt.Longitude;
                _wcfDt.Latitude = _dt.Latitude;
                _wcfDt.UploadDate = _dt.UploadDate;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.CreatedBy = _dt.CreatedBy;
                _wcfDt.CreatedDate = _dt.CreatedDate;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                //_wcfDt.Timestamp = _dt.Timestamp;
                _wcfTrResultReqDocNotMovable.Add(_wcfDt);
            }



            UpdateCPResultServiceReference.UpdateCPResultServiceClient _client = new UpdateCPResultServiceReference.UpdateCPResultServiceClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.UpdateResultNotMovableCustomerPortal(_wcfTrWorkOrderNotMovable, _wcfTrResultNotMovable, _wcfTrResultPhotoAdditionalNotMovable.ToArray(), _wcfTrResultReqDocNotMovable.ToArray());
            _client.Close();

            //Log
            GSI.BusinessEntity.BusinessEntities.TrOrderSPNotMovable _trOrderSPNotMov = this._trOrderSP.GetSingleTrOrderNotMovable(_trWorkOrderNotMovable.OrderSPNotMovableID);
            TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMov.OrderID);
            MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMov.SurveyPointID);
            GSI.BusinessEntity.BusinessEntities.MsEmployee _msEmployee = this._employeeBL.GetSingleEmployeeByEmployeeLogon(_trOrderSPNotMov.UserTakeOver);

            GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

            DateTime _now = DateTime.Now;
            _trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWorkOrderNotMovable.SurveyorID);
            _trOrderSPLog.CreatedDate = _now;
            _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
            _trOrderSPLog.OrderSPID = _trOrderSPNotMov.OrderSPNotMovableID;
            _trOrderSPLog.DateTime = _now;
            _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
            _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
            _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.AfterProcess);
            _trOrderSPLog.EmployeeID = _msEmployee.EmployeeID;
            _trOrderSPLog.RowStatus = 0;

            this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
            //

            return _result;
        }

        #region SyncMaster
        private MembershipService _membershipService = new MembershipService();
        private RegionBL _regionBL = new RegionBL();
        private RegionZipCodeBL _regionalZipCodeBL = new RegionZipCodeBL();
        private CustomerBL _customerBL = new CustomerBL();
        private CustomerUserBL _customerUserBL = new CustomerUserBL();


        public int SyncMsRegion(MsRegion _prmMsRegion)
        {
            int _result = 0;
            bool _success = false;
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();


            _param.Add(new SPParam("@createdBy", _prmMsRegion.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmMsRegion.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmMsRegion.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmMsRegion.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@regionCode", _prmMsRegion.RegionCode, DbType.String));
            _param.Add(new SPParam("@regionName", _prmMsRegion.RegionName, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsRegion.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@regionID", _prmMsRegion.RegionID, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_SyncMsRegion", _param, ref _paramOut, ref data);
            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int SyncMsRegionZipCode(MsRegionZipCode _prmMsRegionZipCode)
        {
            int _result = 0;
            bool _success = false;
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();


            _param.Add(new SPParam("@createdBy", _prmMsRegionZipCode.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmMsRegionZipCode.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmMsRegionZipCode.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmMsRegionZipCode.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@regionZipCodeID", _prmMsRegionZipCode.RegionZipCodeID, DbType.Int64));
            _param.Add(new SPParam("@zipCode", _prmMsRegionZipCode.ZipCode, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmMsRegionZipCode.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@regionID", _prmMsRegionZipCode.RegionID, DbType.Int64));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_SyncMsRegionZipCode", _param, ref _paramOut, ref data);
            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public int SyncMsCustomer(MsCustomer _prmCustomer)
        {
            int _result = 0;
            bool _success = false;
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            _param.Add(new SPParam("@businessTypeID", _prmCustomer.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@city", _prmCustomer.City, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmCustomer.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmCustomer.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@customerAddress1", _prmCustomer.CustomerAddress1, DbType.String));
            _param.Add(new SPParam("@customerAddress2", _prmCustomer.CustomerAddress2, DbType.String));
            _param.Add(new SPParam("@customerCode", _prmCustomer.CustomerCode, DbType.String)); ;
            _param.Add(new SPParam("@customerID", _prmCustomer.CustomerID, DbType.Int64));
            _param.Add(new SPParam("@customerName", _prmCustomer.CustomerName, DbType.String));
            _param.Add(new SPParam("@fax", _prmCustomer.Fax, DbType.String));
            _param.Add(new SPParam("@fgActive", _prmCustomer.fgActive, DbType.Boolean));
            _param.Add(new SPParam("@modifiedBy", _prmCustomer.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmCustomer.ModifiedDate, DbType.DateTime));
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

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_SyncMsCustomer", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }
            return _result;
        }

        public int SyncMsCustomerUser(MsCustomerUser _prmCustomerUser)
        {
            int _result = 0;
            bool _success = false;
            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            _param.Add(new SPParam("@customerID", _prmCustomerUser.CustomerID, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmCustomerUser.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmCustomerUser.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@customerUserID", _prmCustomerUser.CustomerUserID, DbType.String));
            _param.Add(new SPParam("@displayName", _prmCustomerUser.DisplayName, DbType.String));
            _param.Add(new SPParam("@membershipUserName", _prmCustomerUser.MembershipUserName, DbType.String));
            _param.Add(new SPParam("@modifiedBy", _prmCustomerUser.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmCustomerUser.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@remark", _prmCustomerUser.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmCustomerUser.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@userEmailAddress", _prmCustomerUser.UserEmailAddress, DbType.String));

            _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_SyncMsCustomerUser", _param, ref _paramOut, ref data);

            if (_success == true)
            {
                _result = (int)data;
            }

            return _result;
        }

        public String SyncMaster(String _prmTableMaster)
        {
            String _result = "";

            if (_prmTableMaster == "MsRegion")
            {
                List<MsRegion> _msRegion = this._regionBL.GetListMsRegion();
                List<SyncMasterServiceReference.MsRegion> _wcfMsRegion = new List<SyncMasterServiceReference.MsRegion>();

                foreach (var _dt in _msRegion)
                {
                    SyncMasterServiceReference.MsRegion _wcfDt = new SyncMasterServiceReference.MsRegion();
                    _wcfDt.CreatedBy = _dt.CreatedBy;
                    _wcfDt.CreatedDate = _dt.CreatedDate;
                    _wcfDt.ModifiedBy = _dt.ModifiedBy;
                    _wcfDt.ModifiedDate = _dt.ModifiedDate;
                    _wcfDt.RegionCode = _dt.RegionCode;
                    _wcfDt.RegionID = _dt.RegionID;
                    _wcfDt.RegionName = _dt.RegionName;
                    _wcfDt.RowStatus = _dt.RowStatus;
                    _wcfMsRegion.Add(_wcfDt);
                }

                SyncMasterServiceReference.SyncMasterServiceClient _client = new SyncMasterServiceReference.SyncMasterServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateMsRegion(_wcfMsRegion.ToArray());
                _client.Close();
            }

            else if (_prmTableMaster == "MsCustomer")
            {
                List<MsCustomer> _msCustomer = this._customerBL.GetListMsCustomer();
                List<SyncMasterServiceReference.MsCustomer> _wcfMsCustomer = new List<SyncMasterServiceReference.MsCustomer>();

                foreach (var _dt in _msCustomer)
                {
                    SyncMasterServiceReference.MsCustomer _wcfDt = new SyncMasterServiceReference.MsCustomer();
                    _wcfDt.BusinessTypeID = _dt.BusinessTypeID;
                    _wcfDt.City = _dt.City;
                    _wcfDt.CreatedBy = _dt.CreatedBy;
                    _wcfDt.CreatedDate = _dt.CreatedDate;
                    _wcfDt.CustomerAddress1 = _dt.CustomerAddress1;
                    _wcfDt.CustomerAddress2 = _dt.CustomerAddress2;
                    _wcfDt.CustomerCode = _dt.CustomerCode;
                    _wcfDt.CustomerID = _dt.CustomerID;
                    _wcfDt.CustomerName = _dt.CustomerName;
                    _wcfDt.Fax = _dt.Fax;
                    _wcfDt.fgActive = _dt.fgActive;
                    _wcfDt.ModifiedBy = _dt.ModifiedBy;
                    _wcfDt.ModifiedDate = _dt.ModifiedDate;
                    _wcfDt.NPPKP = _dt.NPPKP;
                    _wcfDt.NPWP = _dt.NPWP;
                    _wcfDt.NPWPAddress = _dt.NPWPAddress;
                    _wcfDt.Phone = _dt.Phone;
                    _wcfDt.PrimaryContactDepartment = _dt.PrimaryContactDepartment;
                    _wcfDt.PrimaryContactEmail = _dt.PrimaryContactEmail;
                    _wcfDt.PrimaryContactHP = _dt.PrimaryContactHP;
                    _wcfDt.PrimaryContactName = _dt.PrimaryContactName;
                    _wcfDt.PrimaryGender = _dt.PrimaryGender;
                    _wcfDt.PrimaryPlaceOfBirth = _dt.PrimaryPlaceOfBirth;
                    _wcfDt.PrimaryDateOfBirth = _dt.PrimaryDateOfBirth;
                    _wcfDt.PrimaryContactTitle = _dt.PrimaryContactTitle;
                    _wcfDt.PrimayContactFax = _dt.PrimayContactFax;
                    _wcfDt.PrimayContactPhone = _dt.PrimayContactPhone;
                    _wcfDt.PrimayContactPhoneExtension = _dt.PrimayContactPhoneExtension;
                    _wcfDt.Remark = _dt.Remark;
                    _wcfDt.RowStatus = _dt.RowStatus;
                    _wcfDt.SecondaryContactDepartment = _dt.SecondaryContactDepartment;
                    _wcfDt.SecondaryContactEmail = _dt.SecondaryContactEmail;
                    _wcfDt.SecondaryContactFax = _dt.SecondaryContactFax;
                    _wcfDt.SecondaryContactHP = _dt.SecondaryContactHP;
                    _wcfDt.SecondaryContactName = _dt.SecondaryContactName;
                    _wcfDt.SecondaryGender = _dt.SecondaryGender;
                    _wcfDt.SecondaryPlaceOfBirth = _dt.SecondaryPlaceOfBirth;
                    _wcfDt.SecondaryDateOfBirth = _dt.SecondaryDateOfBirth;
                    _wcfDt.SecondaryContactPhone = _dt.SecondaryContactPhone;
                    _wcfDt.SecondaryContactPhoneExtension = _dt.SecondaryContactPhoneExtension;
                    _wcfDt.SecondaryContactTitle = _dt.SecondaryContactTitle;
                    _wcfDt.ZipCode = _dt.ZipCode;
                    _wcfMsCustomer.Add(_wcfDt);
                }

                SyncMasterServiceReference.SyncMasterServiceClient _client = new SyncMasterServiceReference.SyncMasterServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateMsCustomer(_wcfMsCustomer.ToArray());
                _client.Close();
            }

            else if (_prmTableMaster == "MsCustomerUser")
            {
                List<MsCustomerUser> _msCustomerUser = this._customerUserBL.GetListMsCustomerUser();
                List<SyncMasterServiceReference.MsCustomerUser> _wcfMsCustomerUser = new List<SyncMasterServiceReference.MsCustomerUser>();

                foreach (var _dt in _msCustomerUser)
                {
                    SyncMasterServiceReference.MsCustomerUser _wcfDt = new SyncMasterServiceReference.MsCustomerUser();
                    _wcfDt.CustomerID = _dt.CustomerID;
                    _wcfDt.CustomerUserID = _dt.CustomerUserID;
                    _wcfDt.CreatedBy = _dt.CreatedBy;
                    _wcfDt.CreatedDate = _dt.CreatedDate;
                    _wcfDt.DisplayName = _dt.DisplayName;
                    _wcfDt.MembershipUserName = _dt.MembershipUserName;
                    _wcfDt.ModifiedBy = _dt.ModifiedBy;
                    _wcfDt.ModifiedDate = _dt.ModifiedDate;
                    _wcfDt.Remark = _dt.Remark;
                    _wcfDt.RowStatus = _dt.RowStatus;
                    _wcfDt.UserEmailAddress = _dt.UserEmailAddress;
                    _wcfMsCustomerUser.Add(_wcfDt);
                }
                SyncMasterServiceReference.SyncMasterServiceClient _client = new SyncMasterServiceReference.SyncMasterServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateMsCustomerUser(_wcfMsCustomerUser.ToArray());
                _client.Close();
            }

            else if (_prmTableMaster == "MsRegionZipCode")
            {
                List<MsRegion> _msRegion = this._regionBL.GetListMsRegion();
                List<SyncMasterServiceReference.MsRegion> _wcfMsRegion = new List<SyncMasterServiceReference.MsRegion>();

                foreach (var _dt in _msRegion)
                {
                    SyncMasterServiceReference.MsRegion _wcfDt = new SyncMasterServiceReference.MsRegion();
                    _wcfDt.CreatedBy = _dt.CreatedBy;
                    _wcfDt.CreatedDate = _dt.CreatedDate;
                    _wcfDt.ModifiedBy = _dt.ModifiedBy;
                    _wcfDt.ModifiedDate = _dt.ModifiedDate;
                    _wcfDt.RegionCode = _dt.RegionCode;
                    _wcfDt.RegionID = _dt.RegionID;
                    _wcfDt.RegionName = _dt.RegionName;
                    _wcfDt.RowStatus = _dt.RowStatus;
                    _wcfMsRegion.Add(_wcfDt);
                }

                SyncMasterServiceReference.SyncMasterServiceClient _client = new SyncMasterServiceReference.SyncMasterServiceClient();

                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                _client.UpdateMsRegion(_wcfMsRegion.ToArray());
                _client.Close();

                List<MsRegionZipCode> _msRegionZipCode = this._regionalZipCodeBL.GetListRegionZipCode();
                List<SyncMasterServiceReference.MsRegionZipCode> _wcfMsRegionZipCOde = new List<SyncMasterServiceReference.MsRegionZipCode>();

                foreach (var _dt2 in _msRegionZipCode)
                {
                    SyncMasterServiceReference.MsRegionZipCode _wcfDt2 = new SyncMasterServiceReference.MsRegionZipCode();

                    _wcfDt2.CreatedBy = _dt2.CreatedBy;
                    _wcfDt2.CreatedDate = _dt2.CreatedDate;
                    _wcfDt2.ModifiedBy = _dt2.ModifiedBy;
                    _wcfDt2.ModifiedDate = _dt2.ModifiedDate;
                    _wcfDt2.ZipCode = _dt2.ZipCode;
                    _wcfDt2.RegionID = _dt2.RegionID;
                    _wcfDt2.RegionZipCodeID = _dt2.RegionZipCodeID;
                    _wcfDt2.RowStatus = _dt2.RowStatus;
                    _wcfMsRegionZipCOde.Add(_wcfDt2);

                    SyncMasterServiceReference.SyncMasterServiceClient _client2 = new SyncMasterServiceReference.SyncMasterServiceClient();
                    _client2.UpdateMsRegionZipCode(_wcfMsRegionZipCOde.ToArray());
                    _client2.Close();
                }
            }

            return _result;
        }

        public List<Gen_LoginHistory> GetListGenLoginHistory(Int32 _prmPageSize, Int32 _prmPageNumb, String _prmFieldName, Int64 _prmFieldValue, String _prmOrderBy, String _prmAscDesc)
        {
            List<Gen_LoginHistory> _result = new List<Gen_LoginHistory>();
            SyncMasterServiceReference.SyncMasterServiceClient _client = new SyncMasterServiceReference.SyncMasterServiceClient();

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            int _prmCountData = 0;
            SyncMasterServiceReference.Gen_LoginHistory[] _wcfGenLoginHistory = _client.GetListGenLoginHistory(_prmPageSize, _prmPageNumb, _prmFieldName, _prmFieldValue, _prmOrderBy, _prmAscDesc, ref _prmCountData);

            RequestVariable.RowCount = _prmCountData;
            _client.Close();

            foreach (var _dt in _wcfGenLoginHistory)
            {
                Gen_LoginHistory _genLoginHistory = new Gen_LoginHistory();
                _genLoginHistory.LoginHistoryID = _dt.LoginHistoryID;
                _genLoginHistory.IPAddress = _dt.IPAddress;
                _genLoginHistory.UserName = _dt.UserName;
                _genLoginHistory.Date = _dt.Date;
                _genLoginHistory.RowStatus = _dt.RowStatus;
                _genLoginHistory.CreatedBy = _dt.CreatedBy;
                _genLoginHistory.CreatedDate = _dt.CreatedDate;
                _genLoginHistory.ModifiedBy = _dt.ModifiedBy;
                _genLoginHistory.ModifiedDate = _dt.ModifiedDate;
                _result.Add(_genLoginHistory);
                //int result = _userHistoryBL.InsertUserHistory(_genLoginHistory);
                //if (result == 0)
                //{
                //_result = "Synchronize Failed";
                //}
            }
            return _result;
        }

        #endregion
    }
}
