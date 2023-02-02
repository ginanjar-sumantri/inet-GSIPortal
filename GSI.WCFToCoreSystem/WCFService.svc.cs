using System;
using System.Data;
using System.Collections.Generic;
using GSI.Common;
using GSI.Common.Enum;
using System.Transactions;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;
using GSI.DataMapping;
using System.ServiceModel;

namespace GSI.WCFToCoreSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    
    public class WCFCoreService : IService
    {
        private OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();
        private WorkOrderBL _woBL = new WorkOrderBL();
        private SurveyPointLogBL _spLogBL = new SurveyPointLogBL();
        private EmployeeBL _employeeBL = new EmployeeBL();
        private SurveyPointBL _surveyPointBL = new SurveyPointBL();

        
        public Boolean UpdateToCoreSystem(
            TrOrder _trOrder,
            List<TrOrderSPMovable> _trOrderSPMovable,
            List<TrOrderSPNotMovable> _trOrderSPNotMovable,
            List<TrReqDocMovable> _trReqDocMovable,
            List<TrReqDocNotMovable> _trReqDocNotMovable,
            ref String _prmErr)
        {
            Boolean _result = false;

            object data1 = null;
            object data2 = null;
            object data3 = null;
            object data4 = null;
            object data5 = null;
            object data6 = null;
            List<SPParam> _param1 = new List<SPParam>();
            List<SPParam> _param2 = new List<SPParam>();
            List<SPParam> _param3 = new List<SPParam>();
            List<SPParam> _param4 = new List<SPParam>();
            List<SPParam> _param5 = new List<SPParam>();
            List<SPParam> _param6 = new List<SPParam>();
            List<SPParamOut> _paramOut1 = new List<SPParamOut>();
            List<SPParamOut> _paramOut2 = new List<SPParamOut>();
            List<SPParamOut> _paramOut3 = new List<SPParamOut>();
            List<SPParamOut> _paramOut4 = new List<SPParamOut>();
            List<SPParamOut> _paramOut5 = new List<SPParamOut>();
            List<SPParamOut> _paramOut6 = new List<SPParamOut>();

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    _param1.Clear();
                    _paramOut1.Clear();
                    _param1.Add(new SPParam("@customerID", _trOrder.CustomerID, DbType.Int64));
                    _param1.Add(new SPParam("@orderCode", _trOrder.OrderCode, DbType.String));
                    _param1.Add(new SPParam("@orderTypeID", _trOrder.OrderTypeID, DbType.Int64));
                    _param1.Add(new SPParam("@orderDate", _trOrder.OrderDate, DbType.DateTime));
                    _param1.Add(new SPParam("@orderVersion", _trOrder.OrderVersion, DbType.String));
                    _param1.Add(new SPParam("@orderStatus", _trOrder.OrderStatus, DbType.Byte));
                    _param1.Add(new SPParam("@proceedDate", _trOrder.ProceedDate, DbType.DateTime));
                    _param1.Add(new SPParam("@remark", _trOrder.Remark, DbType.String));
                    _param1.Add(new SPParam("@rowStatus", _trOrder.RowStatus, DbType.Int32));
                    _param1.Add(new SPParam("@createdBy", _trOrder.CreatedBy, DbType.String));
                    _param1.Add(new SPParam("@createdDate", _trOrder.CreatedDate, DbType.DateTime));
                    _param1.Add(new SPParam("@modifiedBy", _trOrder.ModifiedBy, DbType.String));
                    _param1.Add(new SPParam("@modifiedDate", (_trOrder.ModifiedDate == null) ? DateTime.Now : _trOrder.ModifiedDate, DbType.DateTime));
                    _param1.Add(new SPParam("@OrderID", _trOrder.OrderID, DbType.Int64));


                    if (new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrder", _param1, ref _paramOut1, ref data1))
                    {
                        foreach (var _rowDt in _trOrderSPMovable)
                        {
                            //_rowDt.OrderID = Convert.ToInt64(_paramOut1[0].Value);
                            _param2.Clear();
                            _paramOut2.Clear();
                            _param2.Add(new SPParam("@orderID", _rowDt.OrderID, DbType.Int64));
                            _param2.Add(new SPParam("@surveyPointName", _rowDt.SurveyPointName, DbType.String));
                            _param2.Add(new SPParam("@maritalStatus", _rowDt.MaritalStatus, DbType.String));
                            _param2.Add(new SPParam("@spouseName", _rowDt.SpouseName, DbType.String));
                            _param2.Add(new SPParam("@nationality", _rowDt.Nationality, DbType.String));
                            _param2.Add(new SPParam("@placeOfBirth", _rowDt.PlaceOfBirth, DbType.String));
                            _param2.Add(new SPParam("@dateOfBirth", _rowDt.DateOfBirth, DbType.DateTime));
                            _param2.Add(new SPParam("@iDType", _rowDt.IDType, DbType.Int32));
                            _param2.Add(new SPParam("@iDNo", _rowDt.IDNo, DbType.String));
                            _param2.Add(new SPParam("@iDAddress", _rowDt.IDAddress, DbType.String));
                            _param2.Add(new SPParam("@surveyPointID", _rowDt.SurveyPointID, DbType.Int64));
                            _param2.Add(new SPParam("@clue", _rowDt.Clue, DbType.String));
                            _param2.Add(new SPParam("@zipCode", _rowDt.ZipCode, DbType.String));
                            _param2.Add(new SPParam("@remark", _rowDt.Remark, DbType.String));
                            _param2.Add(new SPParam("@homeAddress", _rowDt.HomeAddress, DbType.String));
                            _param2.Add(new SPParam("@sPStatus", _rowDt.SPStatus, DbType.Int64));
                            _param2.Add(new SPParam("@mobilePhoneNumber", _rowDt.MobilePhoneNumber, DbType.String));
                            _param2.Add(new SPParam("@homePhoneNumber", _rowDt.HomePhoneNumber, DbType.String));
                            _param2.Add(new SPParam("@regionID", _rowDt.RegionID, DbType.Int64));
                            _param2.Add(new SPParam("@extension", _rowDt.Extension, DbType.String));
                            _param2.Add(new SPParam("@userTakeOver", _rowDt.UserTakeOver, DbType.String));
                            _param2.Add(new SPParam("@rowStatus", _rowDt.RowStatus, DbType.Int32));
                            _param2.Add(new SPParam("@createdBy", _rowDt.CreatedBy, DbType.String));
                            _param2.Add(new SPParam("@createdDate", _rowDt.CreatedDate, DbType.DateTime));
                            _param2.Add(new SPParam("@modifiedBy", _rowDt.ModifiedBy, DbType.String));
                            _param2.Add(new SPParam("@modifiedDate", (_rowDt.ModifiedDate == null) ? DateTime.Now : _rowDt.ModifiedDate, DbType.DateTime));
                            _param2.Add(new SPParam("@orderSPMovableID", _rowDt.OrderSPMovableID, DbType.Int64));
                            _param2.Add(new SPParam("@originatorID", _rowDt.OriginatorID, DbType.String));
                            _param2.Add(new SPParam("@jobTitle", _rowDt.JobTitle, DbType.String));
                            _param2.Add(new SPParam("@jobType", _rowDt.JobType, DbType.String));
                            _param2.Add(new SPParam("@businessLine", _rowDt.BusinessLine, DbType.String));
                            _param2.Add(new SPParam("@cancelStatus", _rowDt.CancelStatus, DbType.Byte));
                            _param2.Add(new SPParam("@remarkCancel", _rowDt.RemarkCancel, DbType.String));
                            _param2.Add(new SPParam("@remarkComplaint", _rowDt.RemarkComplaint, DbType.String));
                            _param2.Add(new SPParam("@fgComplaint", _rowDt.FgComplaint, DbType.Boolean));

                            if (new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrderSPMovable", _param2, ref _paramOut2, ref data2))
                            {
                                foreach (var _rowDoc in _trReqDocMovable)
                                {
                                    if (_rowDoc.OrderSPMovableID == _rowDt.OrderSPMovableID)
                                    {
                                        //_rowDoc.OrderSPMovableID = Convert.ToInt64(_paramOut2[0].Value);
                                        _param4.Clear();
                                        _paramOut4.Clear();
                                        _param4.Add(new SPParam("@orderSPMovableID", _rowDoc.OrderSPMovableID, DbType.Int64));
                                        _param4.Add(new SPParam("@documentTypeID", _rowDoc.DocumentTypeID, DbType.Int32));
                                        _param4.Add(new SPParam("@remark", _rowDoc.Remark, DbType.String));
                                        _param4.Add(new SPParam("@rowStatus", _rowDoc.RowStatus, DbType.Int32));
                                        _param4.Add(new SPParam("@createdBy", _rowDoc.CreatedBy, DbType.String));
                                        _param4.Add(new SPParam("@createdDate", _rowDoc.CreatedDate, DbType.DateTime));
                                        _param4.Add(new SPParam("@modifiedBy", _rowDoc.ModifiedBy, DbType.String));
                                        _param4.Add(new SPParam("@modifiedDate", (_rowDoc.ModifiedDate == null) ? DateTime.Now : _rowDoc.ModifiedDate, DbType.DateTime));
                                        _param4.Add(new SPParam("@reqDocMovableID", _rowDoc.ReqDocMovableID, DbType.Int64));

                                        new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrReqDocMovable", _param4, ref _paramOut4, ref data4);
                                    }
                                }

                                BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = this._surveyPointBL.GetTemplateSurveyPoint(_trOrder.OrderTypeID, _rowDt.SurveyPointID);

                                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                                _trOrderSPLog.TypeProcess = 1;
                                _trOrderSPLog.RowStatus = 0;
                                _trOrderSPLog.Duration = 0;
                                _trOrderSPLog.EmployeeID = 0;
                                _param6.Clear();
                                _paramOut6.Clear();
                                _param6.Add(new SPParam("@createdBy", _rowDt.CreatedBy, DbType.String));
                                _param6.Add(new SPParam("@createdDate", _rowDt.CreatedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@modifiedBy", _rowDt.ModifiedBy, DbType.String));
                                _param6.Add(new SPParam("@modifiedDate", (_rowDt.ModifiedDate == null) ? DateTime.Now : _rowDt.ModifiedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@surveyPointType", _msSurveyPoint.TemplateForm, DbType.Int64));
                                _param6.Add(new SPParam("@orderSPID", _rowDt.OrderSPMovableID, DbType.Int64));
                                _param6.Add(new SPParam("@dateTime", _rowDt.CreatedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@duration", _trOrderSPLog.Duration, DbType.Int32));
                                _param6.Add(new SPParam("@status", _rowDt.SPStatus, DbType.Byte));
                                _param6.Add(new SPParam("@typeProcess", _trOrderSPLog.TypeProcess, DbType.Byte));
                                _param6.Add(new SPParam("@employeeID", _trOrderSPLog.EmployeeID, DbType.Int64));
                                _param6.Add(new SPParam("@rowStatus", _trOrderSPLog.RowStatus, DbType.Int32));

                                List<SPParamOut> _paramOut = new List<SPParamOut>();
                                _paramOut6.Add(new SPParamOut("@logID", null, DbType.Int64));

                                new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrderSPLog", _param6, ref _paramOut6, ref data6);
                            }
                        }

                        foreach (var _rowDt in _trOrderSPNotMovable)
                        {
                            //_rowDt.OrderID = Convert.ToInt64(_paramOut1[0].Value);
                            _param3.Clear();
                            _paramOut3.Clear();
                            _param3.Add(new SPParam("@orderID", _rowDt.OrderID, DbType.Int64));
                            _param3.Add(new SPParam("@surveyPointName", _rowDt.SurveyPointName, DbType.String));
                            _param3.Add(new SPParam("@surveyPointID", _rowDt.SurveyPointID, DbType.Int64));
                            _param3.Add(new SPParam("@businessTypeID", _rowDt.BusinessTypeID, DbType.Int64));
                            //_param3.Add(new SPParam("@businessLine", _rowDt.BusinessLine, DbType.String));
                            _param3.Add(new SPParam("@address", _rowDt.Address, DbType.String));
                            _param3.Add(new SPParam("@clue", _rowDt.Clue, DbType.String));
                            _param3.Add(new SPParam("@zipCode", _rowDt.ZipCode, DbType.String));
                            _param3.Add(new SPParam("@remark", _rowDt.Remark, DbType.String));
                            _param3.Add(new SPParam("@sPStatus", _rowDt.SPStatus, DbType.Int64));
                            _param3.Add(new SPParam("@phoneNumber", _rowDt.PhoneNumber, DbType.String));
                            _param3.Add(new SPParam("@contactNumber", _rowDt.ContactNumber, DbType.String));
                            _param3.Add(new SPParam("@extension", _rowDt.Extension, DbType.String));
                            _param3.Add(new SPParam("@regionID", _rowDt.RegionID, DbType.Int64));
                            _param3.Add(new SPParam("@userTakeOver", _rowDt.UserTakeOver, DbType.String));
                            _param3.Add(new SPParam("@rowStatus", _rowDt.RowStatus, DbType.Int32));
                            _param3.Add(new SPParam("@createdBy", _rowDt.CreatedBy, DbType.String));
                            _param3.Add(new SPParam("@createdDate", _rowDt.CreatedDate, DbType.DateTime));
                            _param3.Add(new SPParam("@modifiedBy", _rowDt.ModifiedBy, DbType.String));
                            _param3.Add(new SPParam("@modifiedDate", (_rowDt.ModifiedDate == null) ? DateTime.Now : _rowDt.ModifiedDate, DbType.DateTime));
                            _param3.Add(new SPParam("@orderSPNotMovableID", _rowDt.OrderSPNotMovableID, DbType.Int64));
                            _param3.Add(new SPParam("@originatorID", _rowDt.OriginatorID, DbType.String));
                            _param3.Add(new SPParam("@cancelStatus", _rowDt.CancelStatus, DbType.Byte));
                            _param3.Add(new SPParam("@remarkCancel", _rowDt.RemarkCancel, DbType.String));
                            _param3.Add(new SPParam("@remarkComplaint", _rowDt.RemarkComplaint, DbType.String));
                            _param3.Add(new SPParam("@fgComplaint", _rowDt.FgComplaint, DbType.Boolean));

                            if (new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrderSPNotMovable", _param3, ref _paramOut3, ref data3))
                            {
                                foreach (var _rowDoc in _trReqDocNotMovable)
                                {
                                    if (_rowDoc.OrderSPNotMovableID == _rowDt.OrderSPNotMovableID)
                                    {
                                        //_rowDoc.OrderSPNotMovableID = Convert.ToInt64(_paramOut3[0].Value);
                                        _param5.Clear();
                                        _paramOut5.Clear();
                                        _param5.Add(new SPParam("@orderSPNotMovableID", _rowDoc.OrderSPNotMovableID, DbType.Int64));
                                        _param5.Add(new SPParam("@documentTypeID", _rowDoc.DocumentTypeID, DbType.Int64));
                                        _param5.Add(new SPParam("@remark", _rowDoc.Remark, DbType.String));
                                        _param5.Add(new SPParam("@rowStatus", _rowDoc.RowStatus, DbType.Int32));
                                        _param5.Add(new SPParam("@createdBy", _rowDoc.CreatedBy, DbType.String));
                                        _param5.Add(new SPParam("@createdDate", _rowDoc.CreatedDate, DbType.DateTime));
                                        _param5.Add(new SPParam("@modifiedBy", _rowDoc.ModifiedBy, DbType.String));
                                        _param5.Add(new SPParam("@modifiedDate", (_rowDoc.ModifiedDate == null) ? DateTime.Now : _rowDoc.ModifiedDate, DbType.DateTime));
                                        _param5.Add(new SPParam("@reqDocNotMovableID", _rowDoc.ReqDocNotMovableID, DbType.Int64));

                                        new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrReqDocNotMovable", _param5, ref _paramOut5, ref data5);
                                    }
                                }

                                BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = this._surveyPointBL.GetTemplateSurveyPoint(_trOrder.OrderTypeID, _rowDt.SurveyPointID);

                                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                                _trOrderSPLog.RowStatus = 0;
                                _trOrderSPLog.Duration = 0;
                                _trOrderSPLog.EmployeeID = 0;
                                _param6.Clear();
                                _paramOut6.Clear();
                                _param6.Add(new SPParam("@createdBy", _rowDt.CreatedBy, DbType.String));
                                _param6.Add(new SPParam("@createdDate", _rowDt.CreatedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@modifiedBy", _rowDt.ModifiedBy, DbType.String));
                                _param6.Add(new SPParam("@modifiedDate", (_rowDt.ModifiedDate == null) ? DateTime.Now : _rowDt.ModifiedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@surveyPointType", _msSurveyPoint.TemplateForm, DbType.Int64));
                                _param6.Add(new SPParam("@orderSPID", _rowDt.OrderSPNotMovableID, DbType.Int64));
                                _param6.Add(new SPParam("@dateTime", _rowDt.CreatedDate, DbType.DateTime));
                                _param6.Add(new SPParam("@duration", _trOrderSPLog.Duration, DbType.Int32));
                                _param6.Add(new SPParam("@status", _rowDt.SPStatus, DbType.Byte));
                                _param6.Add(new SPParam("@typeProcess", _trOrderSPLog.TypeProcess, DbType.Byte));
                                _param6.Add(new SPParam("@employeeID", _trOrderSPLog.EmployeeID, DbType.Int64));
                                _param6.Add(new SPParam("@rowStatus", _trOrderSPLog.RowStatus, DbType.Int32));

                                List<SPParamOut> _paramOut = new List<SPParamOut>();
                                _paramOut6.Add(new SPParamOut("@logID", null, DbType.Int64));

                                new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_InsertTrOrderSPLog", _param6, ref _paramOut6, ref data6);

                            }
                        }

                    }
                    _result = true;
                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    _prmErr = "Transaction Failed!, " + ex.Message;
                }

                return _result;
            }
        }

        
        public Boolean ComplaintResultNotMovable(TrOrderSPNotMovable _trOrderSPNotMovable, ref String _prmErr)
        {
            Boolean _result = false;

            GSI.BusinessEntity.BusinessEntities.TrOrderSPNotMovable _orderSPNotMovable = this._orderSPBL.GetSingleTrOrderNotMovable(_trOrderSPNotMovable.OrderSPNotMovableID);
            GSI.BusinessEntity.BusinessEntities.TrWorkOrderNotMovable _woSpNotMovable = this._woBL.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_trOrderSPNotMovable.OrderSPNotMovableID);

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@address", _trOrderSPNotMovable.Address, DbType.String));
            //_param.Add(new SPParam("@businessLine", _trOrderSPNotMovable.BusinessLine, DbType.String));
            _param.Add(new SPParam("@businessTypeID", _trOrderSPNotMovable.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@clue", _trOrderSPNotMovable.Clue, DbType.String));
            _param.Add(new SPParam("@contactNumber", _trOrderSPNotMovable.ContactNumber, DbType.String));
            _param.Add(new SPParam("@extension", _trOrderSPNotMovable.Extension, DbType.String));
            _param.Add(new SPParam("@orderID", _trOrderSPNotMovable.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPNotMovableID", _trOrderSPNotMovable.OrderSPNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@phoneNumber", _trOrderSPNotMovable.PhoneNumber, DbType.String));
            _param.Add(new SPParam("@regionID", _trOrderSPNotMovable.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _trOrderSPNotMovable.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _trOrderSPNotMovable.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _trOrderSPNotMovable.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _trOrderSPNotMovable.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _trOrderSPNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _trOrderSPNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _trOrderSPNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _trOrderSPNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _trOrderSPNotMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _trOrderSPNotMovable.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _orderSPNotMovable.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _trOrderSPNotMovable.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _trOrderSPNotMovable.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@cancelStatus", _trOrderSPNotMovable.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _trOrderSPNotMovable.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _trOrderSPNotMovable.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _trOrderSPNotMovable.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _woSpNotMovable.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Complaint);
                this._woBL.UpdateWorkOrderNotMovable(_woSpNotMovable);

                GSI.BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPNotMovable.OrderID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPNotMovable.SurveyPointID);
                GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();

                DateTime _now = DateTime.Now;
                _trOrderSPLog.CreatedBy = _trOrderSPNotMovable.CreatedBy;
                _trOrderSPLog.CreatedDate = _now;
                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                _trOrderSPLog.OrderSPID = _trOrderSPNotMovable.OrderSPNotMovableID;
                _trOrderSPLog.DateTime = _now;
                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Complaint);
                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                _trOrderSPLog.EmployeeID = 0;
                _trOrderSPLog.RowStatus = 0;

                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

                _result = true;
            }

            return _result;
        }

        
        public Boolean ComplaintResultMovable(TrOrderSPMovable _trOrderSPMovable, ref String _prmErr)
        {
            Boolean _result = false;

            GSI.BusinessEntity.BusinessEntities.TrOrderSPMovable _orderSPMovable = this._orderSPBL.GetSingleTrOrderMovable(_trOrderSPMovable.OrderSPMovableID);
            GSI.BusinessEntity.BusinessEntities.TrWorkOrderMovable _woSpMovable = this._woBL.GetSingleWorkOrderMovableByOrderSPMovableID(_trOrderSPMovable.OrderSPMovableID);

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@clue", _trOrderSPMovable.Clue, DbType.String));
            _param.Add(new SPParam("@createdBy", _trOrderSPMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _trOrderSPMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@dateOfBirth", _trOrderSPMovable.DateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@extension", _trOrderSPMovable.Extension, DbType.String));
            _param.Add(new SPParam("@homeAddress", _trOrderSPMovable.HomeAddress, DbType.String));
            _param.Add(new SPParam("@homePhoneNumber", _trOrderSPMovable.HomePhoneNumber, DbType.String));
            _param.Add(new SPParam("@iDAddress", _trOrderSPMovable.IDAddress, DbType.String));
            _param.Add(new SPParam("@iDNo", _trOrderSPMovable.IDNo, DbType.String));
            _param.Add(new SPParam("@iDType", _trOrderSPMovable.IDType, DbType.Byte));
            _param.Add(new SPParam("@maritalStatus", _trOrderSPMovable.MaritalStatus, DbType.String));
            _param.Add(new SPParam("@mobilePhoneNumber", _trOrderSPMovable.MobilePhoneNumber, DbType.String));
            _param.Add(new SPParam("@nationality", _trOrderSPMovable.Nationality, DbType.String));
            _param.Add(new SPParam("@orderID", _trOrderSPMovable.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPMovableID", _trOrderSPMovable.OrderSPMovableID, DbType.Int64));
            _param.Add(new SPParam("@placeOfBirth", _trOrderSPMovable.PlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@spouseName", _trOrderSPMovable.SpouseName, DbType.String));
            _param.Add(new SPParam("@regionID", _trOrderSPMovable.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _trOrderSPMovable.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _trOrderSPMovable.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _trOrderSPMovable.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _trOrderSPMovable.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _trOrderSPMovable.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _trOrderSPMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@modifiedBy", _trOrderSPMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _trOrderSPMovable.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _orderSPMovable.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _trOrderSPMovable.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _trOrderSPMovable.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@jobTitle", _trOrderSPMovable.JobTitle, DbType.String));
            _param.Add(new SPParam("@jobType", _trOrderSPMovable.JobType, DbType.String));
            _param.Add(new SPParam("@businessLine", _trOrderSPMovable.BusinessLine, DbType.String));
            _param.Add(new SPParam("@cancelStatus", _trOrderSPMovable.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _trOrderSPMovable.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _trOrderSPMovable.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _trOrderSPMovable.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _woSpMovable.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Complaint);
                this._woBL.UpdateWorkOrderMovable(_woSpMovable);

                GSI.BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_trOrderSPMovable.OrderID);
                GSI.BusinessEntity.BusinessEntities.MsSurveyPoint _msSurveyPoint = new SurveyPointBL().GetTemplateSurveyPoint(_trOrder.OrderTypeID, _trOrderSPMovable.SurveyPointID);

                GSI.BusinessEntity.BusinessEntities.TrOrderSPLog _trOrderSPLog = new GSI.BusinessEntity.BusinessEntities.TrOrderSPLog();
                DateTime _now = DateTime.Now;
                _trOrderSPLog.CreatedBy = _trOrderSPMovable.CreatedBy;
                _trOrderSPLog.CreatedDate = _now;
                _trOrderSPLog.SurveyPointType = Convert.ToInt64(_msSurveyPoint.TemplateForm);
                _trOrderSPLog.OrderSPID = _trOrderSPMovable.OrderSPMovableID;
                _trOrderSPLog.DateTime = _now;
                _trOrderSPLog.Duration = this._spLogBL.GetDurationFromLastLogAction(_trOrderSPLog.SurveyPointType, _trOrderSPLog.OrderSPID, _now);
                _trOrderSPLog.Status = StatusMapper.GetStatusInternal(GSIInternalStatus.Complaint);
                _trOrderSPLog.TypeProcess = TypeProcessMapper.GetTypeProcess(TypeProcess.PreProcess);
                _trOrderSPLog.EmployeeID = 0;
                _trOrderSPLog.RowStatus = 0;

                this._spLogBL.InsertTrOrderSPLog(_trOrderSPLog);

                _result = true;
            }

            return _result;
        }

        
        public List<TrOrderSPLog> GetListTrOrderSPLogByOrderIDSurveyPointType(long _prmOrderSPID, long _prmSurveyPointType)
        {
            List<TrOrderSPLog> _result = new List<TrOrderSPLog>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointType", _prmSurveyPointType, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListTrOrderSPLogByOrderSPID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                    _trOrderSPLog.CreatedBy = (String)dr["CreatedBy"];
                    _trOrderSPLog.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trOrderSPLog.DateTime = (DateTime)dr["DateTime"];
                    _trOrderSPLog.Duration = (Int32)dr["Duration"];
                    _trOrderSPLog.EmployeeID = (Int64)dr["EmployeeID"];
                    _trOrderSPLog.LogID = (Int64)dr["LogID"];
                    _trOrderSPLog.ModifiedBy = (String)dr["ModifiedBy"];
                    _trOrderSPLog.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)dr["ModifiedDate"];
                    _trOrderSPLog.OrderSPID = (Int64)dr["OrderSPID"];
                    _trOrderSPLog.RowStatus = (Int32)dr["RowStatus"];
                    _trOrderSPLog.Status = (Byte)dr["Status"];
                    _trOrderSPLog.SurveyPointType = (Int64)dr["SurveyPointType"];
                    _trOrderSPLog.Timestamp = (byte[])dr["Timestamp"];
                    _trOrderSPLog.TypeProcess = (Byte)dr["TypeProcess"];
                    _result.Add(_trOrderSPLog);
                }
                dr.Close();
            }

            return _result;
        }
    }
}
