using System;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using System.Collections.Generic;
using System.Transactions;

namespace GSI.WCFToCoreSystem
{
    public class UpdateResultService : IUpdateResultService
    {
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();
        private SurveyorBL _surveyorBL = new SurveyorBL();
        private OrderBL _orderBL = new OrderBL();

        private DateTime _defaultDate = new DateTime(1900, 1, 1);

        private ResultBL _resultBL = new ResultBL();

        public void InsertResultMovableCoreSystem(TrResultMovable _prmResultMovable, ref long _resultID)
        {
            GSI.BusinessEntity.BusinessEntities.TrResultMovable _resultMov = new BusinessEntity.BusinessEntities.TrResultMovable();
            _resultMov.WorkOrderMovableID = _prmResultMovable.WorkOrderMovableID;
            _resultMov.LengthOfStay = _prmResultMovable.LengthOfStay;
            _resultMov.HouseStatus = _prmResultMovable.HouseStatus;
            _resultMov.ResidenceConditions = _prmResultMovable.ResidenceConditions;
            _resultMov.EnvironmentalConditions = _prmResultMovable.EnvironmentalConditions;
            _resultMov.BuildingArea = _prmResultMovable.BuildingArea;
            _resultMov.PersonalCharacter = _prmResultMovable.PersonalCharacter;
            _resultMov.Remark = _prmResultMovable.Remark;
            //_resultMov.Others = _prmResultMovable.Others;
            _resultMov.CreatedBy = "Mobile";
            _resultMov.CreatedDate = DateTime.Now;
            _resultMov.ModifiedBy = String.Empty;
            _resultMov.ModifiedDate = this._defaultDate;
            _resultMov.RowStatus = 0;

            _resultBL.InsertResultMovable(_resultMov, ref _resultID);
        }

        public void InsertResultPhotoAddtMovableCoreSystem(long _resultID, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable)
        {
            foreach (var _item in _prmResultPhotoAddtMovable)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = this._resultBL.GetSingleResultPhotoAddMovByResultPhotoAddMovID(_item.ResultPhotoAdditionalMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable();
                _resultPhotoAddtMov.ResultMovableID = _resultID;
                _resultPhotoAddtMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtMov.ImageGuid = _item.ImageGuid;
                _resultPhotoAddtMov.Remark = _item.Remark;
                _resultPhotoAddtMov.Longitude = _item.Longitude;
                _resultPhotoAddtMov.Latitude = _item.Latitude;
                _resultPhotoAddtMov.UploadDate = DateTime.Now;
                _resultPhotoAddtMov.CreatedBy = "Mobile";
                _resultPhotoAddtMov.CreatedDate = DateTime.Now;
                _resultPhotoAddtMov.ModifiedBy = String.Empty;
                _resultPhotoAddtMov.ModifiedDate = this._defaultDate;
                _resultPhotoAddtMov.RowStatus = 0;

                //_resultBL.UpdateResultPhotoAddMov(_resultPhotoAddtMov);
                long _prmOutID = 0;
                _resultBL.InsertResultPhotoAddMov(_resultPhotoAddtMov, ref _prmOutID);
            }
        }

        public void InsertResultReqDocMovableCoreSystem(long _resultID, List<TrResultReqDocMovable> _prmResultReqDocMovableList)
        {
            foreach (var _item in _prmResultReqDocMovableList)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = this._resultBL.GetSingleResultReqDocMovableByResultReqDocMovableID(_item.ResultReqDocMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = new BusinessEntity.BusinessEntities.TrResultReqDocMovable();
                _resultReqDocMov.ResultMovableID = _resultID;
                _resultReqDocMov.ReqDocMovableID = _item.ReqDocMovableID;
                _resultReqDocMov.PhotoName = _item.PhotoName;
                _resultReqDocMov.ImageGuid = _item.ImageGuid;
                _resultReqDocMov.Remark = _item.Remark;
                _resultReqDocMov.Longitude = _item.Longitude;
                _resultReqDocMov.Latitude = _item.Latitude;
                _resultReqDocMov.UploadDate = DateTime.Now;
                _resultReqDocMov.CreatedBy = "Mobile";
                _resultReqDocMov.CreatedDate = DateTime.Now;
                _resultReqDocMov.ModifiedBy = String.Empty;
                _resultReqDocMov.ModifiedDate = this._defaultDate;
                _resultReqDocMov.RowStatus = 0;

                //_resultBL.UpdateResultReqDocMovable(_resultReqDocMov);
                long _prmOutID = 0;
                _resultBL.InsertResultReqDocMovable(_resultReqDocMov, ref _prmOutID);
            }
        }

        public bool InsertResultMovableCoreSystemBundle(TrResultMovable _prmResultMovable, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable, List<TrResultReqDocMovable> _prmResultReqDocMovableList, ref string _errMessage)
        {
            bool _result = false;
            long _resultID = 0;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    GSI.BusinessEntity.BusinessEntities.TrResultMovable _resultMov = new BusinessEntity.BusinessEntities.TrResultMovable();
                    _resultMov.WorkOrderMovableID = _prmResultMovable.WorkOrderMovableID;
                    _resultMov.LengthOfStay = _prmResultMovable.LengthOfStay;
                    _resultMov.HouseStatus = _prmResultMovable.HouseStatus;
                    _resultMov.ResidenceConditions = _prmResultMovable.ResidenceConditions;
                    _resultMov.EnvironmentalConditions = _prmResultMovable.EnvironmentalConditions;
                    _resultMov.BuildingArea = _prmResultMovable.BuildingArea;
                    _resultMov.PersonalCharacter = _prmResultMovable.PersonalCharacter;
                    _resultMov.Remark = _prmResultMovable.Remark;
                    //_resultMov.Others = _prmResultMovable.Others;
                    _resultMov.CreatedBy = "Mobile";
                    _resultMov.CreatedDate = DateTime.Now;
                    _resultMov.ModifiedBy = String.Empty;
                    _resultMov.ModifiedDate = this._defaultDate;
                    _resultMov.RowStatus = 0;

                    _result = _resultBL.InsertResultMovable(_resultMov, ref _resultID);

                    if (_result)
                    {
                        foreach (var _item in _prmResultPhotoAddtMovable)
                        {
                            GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable();
                            _resultPhotoAddtMov.ResultMovableID = _resultID;
                            _resultPhotoAddtMov.PhotoName = _item.PhotoName;
                            _resultPhotoAddtMov.ImageGuid = _item.ImageGuid;
                            _resultPhotoAddtMov.Remark = _item.Remark;
                            _resultPhotoAddtMov.Longitude = _item.Longitude;
                            _resultPhotoAddtMov.Latitude = _item.Latitude;
                            _resultPhotoAddtMov.UploadDate = DateTime.Now;
                            _resultPhotoAddtMov.CreatedBy = "Mobile";
                            _resultPhotoAddtMov.CreatedDate = DateTime.Now;
                            _resultPhotoAddtMov.ModifiedBy = String.Empty;
                            _resultPhotoAddtMov.ModifiedDate = this._defaultDate;
                            _resultPhotoAddtMov.RowStatus = 0;

                            long _prmOutID = 0;
                            _result = _resultBL.InsertResultPhotoAddMov(_resultPhotoAddtMov, ref _prmOutID);
                        }
                    }
                    if (_result)
                    {
                        foreach (var _item in _prmResultReqDocMovableList)
                        {
                            GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = new BusinessEntity.BusinessEntities.TrResultReqDocMovable();
                            _resultReqDocMov.ResultMovableID = _resultID;
                            _resultReqDocMov.ReqDocMovableID = _item.ReqDocMovableID;
                            _resultReqDocMov.PhotoName = _item.PhotoName;
                            _resultReqDocMov.ImageGuid = _item.ImageGuid;
                            _resultReqDocMov.Remark = _item.Remark;
                            _resultReqDocMov.Longitude = _item.Longitude;
                            _resultReqDocMov.Latitude = _item.Latitude;
                            _resultReqDocMov.UploadDate = DateTime.Now;
                            _resultReqDocMov.CreatedBy = "Mobile";
                            _resultReqDocMov.CreatedDate = DateTime.Now;
                            _resultReqDocMov.ModifiedBy = String.Empty;
                            _resultReqDocMov.ModifiedDate = this._defaultDate;
                            _resultReqDocMov.RowStatus = 0;

                            long _prmOutID = 0;
                            _result = _resultBL.InsertResultReqDocMovable(_resultReqDocMov, ref _prmOutID);
                        }
                    }

                    // cari usertakeover nya
                    BusinessEntity.BusinessEntities.TrWorkOrderMovable _trWOMov = new WorkOrderBL().GetSingleWorkOrderMovable(_prmResultMovable.WorkOrderMovableID);
                    BusinessEntity.BusinessEntities.TrOrderSPMovable _trOrderSPMov = new OrderSurveyPointBL().GetSingleTrOrderMovable(_trWOMov.OrderSPMovableID);
                    BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMov.OrderID);

                    ////Log
                    //GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMov.SurveyPointID);
                    //GSI.BusinessEntity.BusinessEntities.MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(_trWOMov.SurveyorID);
                    //GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

                    //DateTime _now = DateTime.Now;
                    //_trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWOMov.SurveyorID);
                    //_trOrderSPLog.CreatedDate = _now;
                    //_trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                    //_trOrderSPLog.OrderSPID = _trOrderSPMov.OrderSPMovableID;
                    //_trOrderSPLog.DateTime = _now;
                    //_trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                    //_trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                    //_trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.SurveyProcess);
                    //_trOrderSPLog.EmployeeID = _msSurveyor.EmployeeID;
                    //_trOrderSPLog.RowStatus = 0;

                    //this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    //

                    String _errMailMessage = "";
                    GeneralHelper _helper = new GeneralHelper();
                    List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Dispatcher, _trOrderSPMov.UserTakeOver);
                    String _message = _helper.MailMessengeBuilderToDispatcher(_trWOMov.WorkOrderCode, OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID), new OrderSurveyPointBL().GetSingleTrOrderMovable(_trOrderSPMov.OrderSPMovableID).SurveyPointName, new SurveyorBL().GetEmployeeNameBySurveyorID(_trWOMov.SurveyorID), new OrderBL().GetSingleOrderByOrderID(_trOrderSPMov.OrderID).OrderCode);
                    Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Dispatcher), _message, ref _errMailMessage);

                    if (_errMailMessage != "") _errMessage = _errMailMessage;

                    if (_resultMail) _scope.Complete();
                }
                catch (Exception ex)
                {
                    _scope.Dispose();
                    _result = false;
                    _errMessage += ex.Message;
                }

                return _result;
            }
        }


        public void InsertResultNotMovableCoreSystem(TrResultNotMovable _prmResultNotMovable, ref long _resultID)
        {
            GSI.BusinessEntity.BusinessEntities.TrResultNotMovable _resultNotMov = new BusinessEntity.BusinessEntities.TrResultNotMovable();
            _resultNotMov.WorkOrderNotMovableID = _prmResultNotMovable.WorkOrderNotMovableID;
            //_resultNotMov.BusinessLine = _prmResultNotMovable.BusinessLine;
            _resultNotMov.CompanyCondition = _prmResultNotMovable.CompanyCondition;
            _resultNotMov.CompanyPeriod = _prmResultNotMovable.CompanyPeriod;
            //_resultNotMov.Others = _prmResultNotMovable.Others;
            _resultNotMov.Remark = _prmResultNotMovable.Remark;
            _resultNotMov.CreatedBy = "Mobile";
            _resultNotMov.CreatedDate = DateTime.Now;
            _resultNotMov.ModifiedBy = String.Empty;
            _resultNotMov.ModifiedDate = this._defaultDate;
            _resultNotMov.RowStatus = 0;

            _resultBL.InsertResultNotMovable(_resultNotMov, ref _resultID);
        }

        public void InsertResultPhotoAddtNotMovableCoreSystem(long _resultID, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable)
        {
            foreach (var _item in _prmResultPhotoAddtNotMovable)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = this._resultBL.GetSingleResultPhotoAddNotMovByResultPhotoAddNotMovID(_item.ResultPhotoAdditionalNotMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable();
                _resultPhotoAddtNotMov.ResultNotMovableID = _resultID;
                _resultPhotoAddtNotMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtNotMov.ImageGuid = _item.ImageGuid;
                _resultPhotoAddtNotMov.Remark = _item.Remark;
                _resultPhotoAddtNotMov.Longitude = _item.Longitude;
                _resultPhotoAddtNotMov.Latitude = _item.Latitude;
                _resultPhotoAddtNotMov.UploadDate = DateTime.Now;
                _resultPhotoAddtNotMov.CreatedBy = "Mobile";
                _resultPhotoAddtNotMov.CreatedDate = DateTime.Now;
                _resultPhotoAddtNotMov.ModifiedBy = String.Empty;
                _resultPhotoAddtNotMov.ModifiedDate = this._defaultDate;
                _resultPhotoAddtNotMov.RowStatus = 0;

                long _prmOutID = 0;
                //_resultBL.UpdateResultPhotoAddNotMov(_resultPhotoAddtNotMov);
                _resultBL.InsertResultPhotoAddNotMov(_resultPhotoAddtNotMov, ref _prmOutID);
            }
        }

        public void InsertResultReqDocNotMovableCoreSystem(long _resultID, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList)
        {
            foreach (var _item in _prmResultReqDocNotMovableList)
            {
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable _resultReqDocNotMov = this._resultBL.GetSingleResultReqDocNotMovableByResultReqDocNotMovableID(_item.ResultReqDocNotMovableID);
                _resultReqDocNotMov.ResultNotMovableID = _resultID;
                _resultReqDocNotMov.ReqDocNotMovableID = _item.ReqDocNotMovableID;
                _resultReqDocNotMov.PhotoName = _item.PhotoName;
                _resultReqDocNotMov.ImageGuid = _item.ImageGuid;
                _resultReqDocNotMov.Remark = _item.Remark;
                _resultReqDocNotMov.Longitude = _item.Longitude;
                _resultReqDocNotMov.Latitude = _item.Latitude;
                _resultReqDocNotMov.UploadDate = DateTime.Now;
                _resultReqDocNotMov.CreatedBy = "Mobile";
                _resultReqDocNotMov.CreatedDate = DateTime.Now;
                _resultReqDocNotMov.ModifiedBy = String.Empty;
                _resultReqDocNotMov.ModifiedDate = this._defaultDate;
                _resultReqDocNotMov.RowStatus = 0;

                //_resultBL.UpdateResultReqDocNotMovable(_resultReqDocNotMov);
                long _prmOutID = 0;
                _resultBL.InsertResultReqDocNotMovable(_resultReqDocNotMov, ref _prmOutID);
            }
        }

        public bool InsertResultNotMovableCoreSystemBundle(TrResultNotMovable _prmResultNotMovable, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList, ref string _errMessage)
        {
            bool _result = false;
            long _resultID = 0;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    GSI.BusinessEntity.BusinessEntities.TrResultNotMovable _resultNotMov = new BusinessEntity.BusinessEntities.TrResultNotMovable();
                    _resultNotMov.WorkOrderNotMovableID = _prmResultNotMovable.WorkOrderNotMovableID;
                    //_resultNotMov.BusinessLine = _prmResultNotMovable.BusinessLine;
                    _resultNotMov.CompanyCondition = _prmResultNotMovable.CompanyCondition;
                    _resultNotMov.CompanyPeriod = _prmResultNotMovable.CompanyPeriod;
                    //_resultNotMov.Others = _prmResultNotMovable.Others;
                    _resultNotMov.Position = _prmResultNotMovable.Position;
                    _resultNotMov.WorkingPeriod = _prmResultNotMovable.WorkingPeriod;
                    _resultNotMov.Remark = _prmResultNotMovable.Remark;
                    _resultNotMov.CreatedBy = "Mobile";
                    _resultNotMov.CreatedDate = DateTime.Now;
                    _resultNotMov.ModifiedBy = String.Empty;
                    _resultNotMov.ModifiedDate = this._defaultDate;
                    _resultNotMov.RowStatus = 0;

                    _result = _resultBL.InsertResultNotMovable(_resultNotMov, ref _resultID);

                    if (_result)
                    {
                        foreach (var _item in _prmResultPhotoAddtNotMovable)
                        {
                            GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable();
                            _resultPhotoAddtNotMov.ResultNotMovableID = _resultID;
                            _resultPhotoAddtNotMov.PhotoName = _item.PhotoName;
                            _resultPhotoAddtNotMov.ImageGuid = _item.ImageGuid;
                            _resultPhotoAddtNotMov.Remark = _item.Remark;
                            _resultPhotoAddtNotMov.Longitude = _item.Longitude;
                            _resultPhotoAddtNotMov.Latitude = _item.Latitude;
                            _resultPhotoAddtNotMov.UploadDate = DateTime.Now;
                            _resultPhotoAddtNotMov.CreatedBy = "Mobile";
                            _resultPhotoAddtNotMov.CreatedDate = DateTime.Now;
                            _resultPhotoAddtNotMov.ModifiedBy = String.Empty;
                            _resultPhotoAddtNotMov.ModifiedDate = this._defaultDate;
                            _resultPhotoAddtNotMov.RowStatus = 0;

                            long _prmOutID = 0;
                            _result = _resultBL.InsertResultPhotoAddNotMov(_resultPhotoAddtNotMov, ref _prmOutID);
                        }
                    }
                    if (_result)
                    {
                        foreach (var _item in _prmResultReqDocNotMovableList)
                        {
                            GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable _resultReqDocNotMov = new BusinessEntity.BusinessEntities.TrResultReqDocNotMovable();
                            _resultReqDocNotMov.ResultNotMovableID = _resultID;
                            _resultReqDocNotMov.ReqDocNotMovableID = _item.ReqDocNotMovableID;
                            _resultReqDocNotMov.PhotoName = _item.PhotoName;
                            _resultReqDocNotMov.ImageGuid = _item.ImageGuid;
                            _resultReqDocNotMov.Remark = _item.Remark;
                            _resultReqDocNotMov.Longitude = _item.Longitude;
                            _resultReqDocNotMov.Latitude = _item.Latitude;
                            _resultReqDocNotMov.UploadDate = DateTime.Now;
                            _resultReqDocNotMov.CreatedBy = "Mobile";
                            _resultReqDocNotMov.CreatedDate = DateTime.Now;
                            _resultReqDocNotMov.ModifiedBy = String.Empty;
                            _resultReqDocNotMov.ModifiedDate = this._defaultDate;
                            _resultReqDocNotMov.RowStatus = 0;

                            long _prmOutID = 0;
                            _result = _resultBL.InsertResultReqDocNotMovable(_resultReqDocNotMov, ref _prmOutID);
                        }
                    }

                    // cari usertakeover nya
                    BusinessEntity.BusinessEntities.TrWorkOrderNotMovable _trWONotMov = new WorkOrderBL().GetSingleWorkOrderNotMovable(_prmResultNotMovable.WorkOrderNotMovableID);
                    BusinessEntity.BusinessEntities.TrOrderSPNotMovable _trOrderSPNotMov = new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_trWONotMov.OrderSPNotMovableID);
                    BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMov.OrderID);

                    ////Log
                    //GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMov.SurveyPointID);
                    //GSI.BusinessEntity.BusinessEntities.MsSurveyor _msSurveyor = this._surveyorBL.GetSingleSurveyor(_trWONotMov.SurveyorID);
                    //GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

                    //DateTime _now = DateTime.Now;
                    //_trOrderSPLog.CreatedBy = new SurveyorBL().GetEmployeeNameBySurveyorID(_trWONotMov.SurveyorID);
                    //_trOrderSPLog.CreatedDate = _now;
                    //_trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                    //_trOrderSPLog.OrderSPID = _trOrderSPNotMov.OrderSPNotMovableID;
                    //_trOrderSPLog.DateTime = _now;
                    //_trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                    //_trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                    //_trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.SurveyProcess);
                    //_trOrderSPLog.EmployeeID = _msSurveyor.EmployeeID;
                    //_trOrderSPLog.RowStatus = 0;

                    //this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);
                    ////

                    String _errMailMessage = "";
                    GeneralHelper _helper = new GeneralHelper();
                    List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Dispatcher, _trOrderSPNotMov.UserTakeOver);
                    String _message = _helper.MailMessengeBuilderToDispatcher(_trWONotMov.WorkOrderCode, OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID), new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_trOrderSPNotMov.OrderSPNotMovableID).SurveyPointName, new SurveyorBL().GetEmployeeNameBySurveyorID(_trWONotMov.SurveyorID), new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMov.OrderID).OrderCode);
                    Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Dispatcher), _message, ref _errMailMessage);

                    if (_errMailMessage != "") _errMessage = _errMailMessage;

                    if (_resultMail) _scope.Complete();
                }
                catch (Exception ex)
                {
                    _errMessage += ex.Message;
                    _scope.Dispose();
                    _result = false;
                }
            }

            return _result;
        }
    }
}
