using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using GSI.BusinessRule;
using GSI.BusinessRuleCore.MobileSystemWorkOrderServices;
using System.Transactions;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Web;

namespace GSI.BusinessRuleCore
{
    public class WorkOrderBL : Base
    {
        public WorkOrderBL()
        {
        }
        ~WorkOrderBL()
        {
        }

        #region WorkOrderMovable
        public TrWorkOrderMovable GetSingleWorkOrderMovable(Int64 _prmWorkOrderMovableID)
        {
            TrWorkOrderMovable _result = new TrWorkOrderMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderMovableID", _prmWorkOrderMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrWorkOrderMovableByWorkOrderMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrWorkOrderMovable _woMov = new TrWorkOrderMovable();
                    _woMov.WorkOrderMovableID = (Int64)dr["WorkOrderMovableID"];
                    _woMov.OrderSPMovableID = (Int64)dr["OrderSPMovableID"];
                    _woMov.SurveyorID = (Int64)dr["SurveyorID"];
                    _woMov.WorkOrderCode = (String)dr["WorkOrderCode"];
                    _woMov.DateCreate = (DateTime)dr["DateCreate"];
                    _woMov.DateExecute = (DateTime)dr["DateExecute"];
                    _woMov.WorkOrderStatusID = (Byte)dr["WorkOrderStatusID"];
                    _woMov.SyncStatus = (Boolean)dr["SyncStatus"];
                    _woMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _woMov.DownloadDate = (DateTime)dr["DownloadDate"];
                    _woMov.OnTheWayDate = (DateTime)dr["OnTheWayDate"];
                    _woMov.OnTheSpotDate = (DateTime)dr["OnTheSpotDate"];
                    _woMov.SurveyResultReceivedDate = (dr["SurveyResultReceivedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SurveyResultReceivedDate"];
                    _woMov.RowStatus = (int)dr["RowStatus"];
                    _woMov.CreatedBy = (String)dr["CreatedBy"];
                    _woMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _woMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _woMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _woMov.Timestamp = (byte[])dr["Timestamp"];
                    _woMov.WORef = (dr["WORef"] == DBNull.Value) ? Convert.ToInt64(0) : (Int64)dr["WORef"];

                    _result = _woMov;
                }
                dr.Close();
            }

            return _result;
        }

        public TrWorkOrderMovable GetSingleWorkOrderMovableByOrderSPMovableID(Int64 _prmOrderSPMovableID)
        {
            TrWorkOrderMovable _result = null;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSPMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrWorkOrderMovableByOrderSPMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrWorkOrderMovable _woMov = new TrWorkOrderMovable();
                    _woMov.WorkOrderMovableID = (Int64)dr["WorkOrderMovableID"];
                    _woMov.OrderSPMovableID = (Int64)dr["OrderSPMovableID"];
                    _woMov.SurveyorID = (Int64)dr["SurveyorID"];
                    _woMov.WorkOrderCode = (String)dr["WorkOrderCode"];
                    _woMov.DateCreate = (DateTime)dr["DateCreate"];
                    _woMov.DateExecute = (DateTime)dr["DateExecute"];
                    _woMov.WorkOrderStatusID = (Byte)dr["WorkOrderStatusID"];
                    _woMov.SyncStatus = (Boolean)dr["SyncStatus"];
                    _woMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _woMov.DownloadDate = (DateTime)dr["DownloadDate"];
                    _woMov.OnTheWayDate = (DateTime)dr["OnTheWayDate"];
                    _woMov.OnTheSpotDate = (DateTime)dr["OnTheSpotDate"];
                    _woMov.SurveyResultReceivedDate = (dr["SurveyResultReceivedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SurveyResultReceivedDate"];
                    _woMov.RowStatus = (int)dr["RowStatus"];
                    _woMov.CreatedBy = (String)dr["CreatedBy"];
                    _woMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _woMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _woMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _woMov.Timestamp = (byte[])dr["Timestamp"];
                    _woMov.WOType = (dr["WOType"] == DBNull.Value) ? Convert.ToByte(0) : (Byte)dr["WOType"];
                    _woMov.WORef = (dr["WORef"] == DBNull.Value) ? Convert.ToInt64(0) : (Int64)dr["WORef"];


                    _result = _woMov;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean InsertWorkOrderMovable(TrWorkOrderMovable _prmWorkOrder)
        {
            Boolean _result = false;
            String _userName = _prmWorkOrder.CreatedBy;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    TrWorkOrderMovable _trWorkOrderMovable = this.GetSingleWorkOrderMovableByOrderSPMovableID(_prmWorkOrder.OrderSPMovableID);
                    if (_trWorkOrderMovable != null)
                    {
                        if (_prmWorkOrder.WOType == WOTypeMapper.GetWOType(WOTypeEnum.Correction))
                        {
                            _trWorkOrderMovable.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Correction);
                            _result = this.UpdateWorkOrderMovable(_trWorkOrderMovable);
                        }
                    }

                    object data = null;
                    List<SPParam> _param = new List<SPParam>();
                    _param.Add(new SPParam("@orderSPMovableID", _prmWorkOrder.OrderSPMovableID, DbType.Int64));
                    _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
                    _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
                    _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
                    _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
                    _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
                    _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
                    _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
                    _param.Add(new SPParam("@downloadDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@onTheWayDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@onTheSpotDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@surveyResultReceivedDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
                    _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
                    _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                    _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@wOType", _prmWorkOrder.WOType, DbType.Byte));
                    _param.Add(new SPParam("@wORef", _prmWorkOrder.WORef, DbType.Int64));

                    List<SPParamOut> _paramOut = new List<SPParamOut>();
                    _paramOut.Add(new SPParamOut("@workOrderMovableID", null, DbType.Int64));

                    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrWorkOrderMovable", _param, ref _paramOut, ref data);
                    if (_success)
                    {
                        long _woID = Convert.ToInt64(_paramOut[0].Value);
                        //this.CreateWorkOrderMovableSequence(_woID, _prmWorkOrder.OrderSPMovableID, _userName);

                        OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();
                        TrOrderSPMovable _orderSPMov = _orderSPBL.GetSingleTrOrderMovable(_prmWorkOrder.OrderSPMovableID);
                        _orderSPMov.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                        //_orderSPMov.ModifiedBy = HttpContext.Current.User.Identity.Name;
                        _orderSPMov.ModifiedBy = _prmWorkOrder.CreatedBy;
                        _orderSPMov.ModifiedDate = DateTime.Now;

                        bool _success2 = _orderSPBL.UpdateTrOrderSPMovable(_orderSPMov);
                        if (_success2)
                        {
                            UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                            _client.UpdateStatusCustomerPortal(SurveyPointType.Movable, _prmWorkOrder.OrderSPMovableID, GSIInternalStatus.WaitingForDownload, _orderSPMov.UserTakeOver);
                            _client.Close();


                            GSIWorkOrderData _woData = new GSIWorkOrderData();
                            TrOrderSPMovable _spMov = new OrderSurveyPointBL().GetSingleTrOrderMovable(_prmWorkOrder.OrderSPMovableID);
                            _woData.WorkOrderID = Convert.ToInt64(_paramOut[0].Value);
                            _woData.WorkOrderCode = _prmWorkOrder.WorkOrderCode;
                            _woData.SurveyorID = _prmWorkOrder.SurveyorID;
                            _woData.SurveyorCode = new SurveyorBL().GetSingleSurveyor(_prmWorkOrder.SurveyorID).SurveyorCode;
                            _woData.RemarkAssign = _prmWorkOrder.Remark;
                            _woData.Clue = _spMov.Clue;
                            _woData.Address = _spMov.HomeAddress;
                            _woData.ZipCode = _spMov.ZipCode;
                            _woData.MaritalStatus = _spMov.MaritalStatus;
                            _woData.Nationality = _spMov.Nationality;
                            _woData.Remark = _spMov.Remark;
                            _woData.SpouseName = _spMov.SpouseName;
                            _woData.BusinessFormName = "";
                            _woData.SurveyPointName = _spMov.SurveyPointName;
                            _woData.SurveyPointID = _spMov.SurveyPointID;
                            _woData.JobTitle = _spMov.JobTitle;
                            _woData.JobType = _spMov.JobType;
                            _woData.LineBussines = _spMov.BusinessLine;

                            //ambil data originator
                            TrOrderSPMovable _originatorData = new TrOrderSPMovable();
                            if (_spMov.OriginatorID == -1)
                            {
                                _originatorData = _orderSPBL.GetSingleTrOrderMovable(_prmWorkOrder.OrderSPMovableID);
                            }
                            else
                            {
                                _originatorData = _orderSPBL.GetSingleTrOrderMovable(_spMov.OriginatorID);
                            }

                            _woData.OriginatorName = _originatorData.SurveyPointName;
                            _woData.OriginatorMaritalStatus = _originatorData.MaritalStatus;
                            _woData.OriginatorSpouseName = _originatorData.SpouseName;
                            _woData.OriginatorNationality = _originatorData.Nationality;
                            _woData.OriginatorJobTitle = _originatorData.JobTitle;
                            _woData.OriginatorJobType = _originatorData.JobType;
                            _woData.OriginatorLineBussines = _originatorData.BusinessLine;
                            _woData.OriginatorAddress = _originatorData.HomeAddress;
                            _woData.OriginatorClue = _originatorData.Clue;
                            _woData.OriginatorZipCode = _originatorData.ZipCode;
                            _woData.OriginatorRemark = _originatorData.Remark;
                            //ambil data originator end

                            List<TrReqDocMovable> _docMov = new OrderSurveyPointBL().GetListReqDocbySPIDMovable(_prmWorkOrder.OrderSPMovableID);
                            List<GSIRequiredDocumentData> _reqDocList = new List<GSIRequiredDocumentData>();
                            foreach (var _item in _docMov)
                            {
                                GSIRequiredDocumentData _row = new GSIRequiredDocumentData();
                                _row.MobileRequiredDocumentID = _item.ReqDocMovableID;
                                _row.DocumentTypeName = new DocumentTypeBL().GetSingleDocumentType(_item.DocumentTypeID).DocumentTypeName;
                                _row.Remark = _item.Remark;

                                _reqDocList.Add(_row);
                            }

                            this.SendToMobile(SurveyPointType.Movable, _woData, _reqDocList);

                            String _errMailMessage = "";
                            GeneralHelper _helper = new GeneralHelper();
                            List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Surveyor, _prmWorkOrder.SurveyorID.ToString());
                            //Boolean _resultMail = _helper.SendEmail(_emailTo, "Notification", "No WO : " + _prmWorkOrder.WorkOrderCode + " Survey Point : " + new SurveyPointBL().GetSingleSurveyPoint(_spMov.SurveyPointID).SurveyPointName + " untuk Surveyor : " + new SurveyorBL().GetEmployeeNameBySurveyorID(_prmWorkOrder.SurveyorID) + " Telah diterima, silahkan untuk didownload.", ref _errMailMessage);

                            BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_spMov.OrderID);
                            String _message = _helper.MailMessengeBuilderToSurveyor(_prmWorkOrder.WorkOrderCode, OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID), new OrderSurveyPointBL().GetSingleTrOrderMovable(_spMov.OrderSPMovableID).SurveyPointName, new SurveyorBL().GetEmployeeNameBySurveyorID(_prmWorkOrder.SurveyorID));
                            Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Surveyor), _message, ref _errMailMessage);

                            if (_errMailMessage != "") ErrorHandler.ErrorMessage = _errMailMessage;

                            _result = true;
                            if (_resultMail) _scope.Complete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage += ex.Message;
                }
            }

            return _result;
        }

        public Boolean InsertWorkOrderMovableWCF(TrWorkOrderMovable _prmWorkOrder, ref long _prmOutID)
        {
            Boolean _result = false;
            String _userName = _prmWorkOrder.CreatedBy;

            try
            {
                object data = null;
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
                _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
                _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
                _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
                _param.Add(new SPParam("@downloadDate", _prmWorkOrder.DownloadDate, DbType.DateTime));
                _param.Add(new SPParam("@modifiedBy", _prmWorkOrder.ModifiedBy, DbType.String));
                _param.Add(new SPParam("@modifiedDate", _prmWorkOrder.ModifiedDate, DbType.DateTime));
                _param.Add(new SPParam("@onTheSpotDate", _prmWorkOrder.OnTheSpotDate, DbType.DateTime));
                _param.Add(new SPParam("@onTheWayDate", _prmWorkOrder.OnTheWayDate, DbType.DateTime));
                _param.Add(new SPParam("@surveyResultReceivedDate", _prmWorkOrder.SurveyResultReceivedDate, DbType.DateTime));
                _param.Add(new SPParam("@orderSPMovableID", _prmWorkOrder.OrderSPMovableID, DbType.Int64));
                _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
                _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
                _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
                _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
                _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
                _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
                _param.Add(new SPParam("@wOType", _prmWorkOrder.WOType, DbType.Byte));
                _param.Add(new SPParam("@wORef", _prmWorkOrder.WORef, DbType.Int64));

                List<SPParamOut> _paramOut = new List<SPParamOut>();
                _paramOut.Add(new SPParamOut("@workOrderMovableID", null, DbType.Int64));

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrWorkOrderMovable", _param, ref _paramOut, ref data);
                if (_success)
                {
                    _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                }
            }
            catch (Exception ex)
            {
                String _err = ex.Message;
            }

            return _result;
        }

        public Boolean UpdateWorkOrderMovable(TrWorkOrderMovable _prmWorkOrder)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderMovableID", _prmWorkOrder.WorkOrderMovableID, DbType.Int64));
            _param.Add(new SPParam("@orderSPMovableID", _prmWorkOrder.OrderSPMovableID, DbType.Int64));
            _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
            _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
            _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
            _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
            _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
            _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
            _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
            _param.Add(new SPParam("@downloadDate", _prmWorkOrder.DownloadDate, DbType.DateTime));
            _param.Add(new SPParam("@onTheWayDate", _prmWorkOrder.OnTheWayDate, DbType.DateTime));
            _param.Add(new SPParam("@onTheSpotDate", _prmWorkOrder.OnTheSpotDate, DbType.DateTime));
            _param.Add(new SPParam("@surveyResultReceivedDate", _prmWorkOrder.SurveyResultReceivedDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmWorkOrder.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmWorkOrder.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmWorkOrder.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrWorkOrderMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        private void CreateWorkOrderMovableSequence(Int64 _prmWorkOrderID, Int64 _prmOrderSPID, String _prmUserName)
        {
            //ResultBL _resultBL = new ResultBL();

            //TrResultMovable _resultMov = new TrResultMovable();
            //_resultMov.WorkOrderMovableID = _prmWorkOrderID;
            //_resultMov.WorkingPeriod = String.Empty;
            //_resultMov.BuildingArea = String.Empty;
            //_resultMov.EnvironmentalConditions = String.Empty;
            //_resultMov.HouseStatus = String.Empty;
            //_resultMov.LengthOfStay = String.Empty;
            //_resultMov.Others = String.Empty;
            //_resultMov.PersonalCharacter = String.Empty;
            //_resultMov.Position = String.Empty;
            //_resultMov.Remark = String.Empty;
            //_resultMov.ResidenceConditions = String.Empty;
            //_resultMov.RowStatus = 0;
            //_resultMov.CreatedBy = _prmUserName;
            //_resultMov.CreatedDate = DateTime.Now;
            //_resultMov.ModifiedBy = String.Empty;
            //_resultMov.ModifiedDate = this._defaultDate;

            //long _resultMovID = 0;
            //_resultBL.InsertResultMovable(_resultMov, ref _resultMovID);
            //if (_resultBL.InsertResultMovable(_resultMov, ref _resultMovID))
            //{
            //    TrResultPhotoAdditionalMovable _resultPhotoAddtMov = new TrResultPhotoAdditionalMovable();
            //    _resultPhotoAddtMov.ResultMovableID = _resultMovID;
            //    _resultPhotoAddtMov.PhotoName = String.Empty;
            //    _resultPhotoAddtMov.ImageGuid = Guid.Empty;
            //    _resultPhotoAddtMov.Remark = String.Empty;
            //    _resultPhotoAddtMov.Longitude = String.Empty;
            //    _resultPhotoAddtMov.Latitude = String.Empty;
            //    _resultPhotoAddtMov.UploadDate = DateTime.Now;
            //    _resultPhotoAddtMov.RowStatus = 0;
            //    _resultPhotoAddtMov.CreatedBy = _prmUserName;
            //    _resultPhotoAddtMov.CreatedDate = DateTime.Now;
            //    _resultPhotoAddtMov.ModifiedBy = String.Empty;
            //    _resultPhotoAddtMov.ModifiedDate = DateTime.Now;

            //    long _resultPhotoAddtMovID = 0;
            //    if (_resultBL.InsertResultPhotoAddMov(_resultPhotoAddtMov, ref _resultPhotoAddtMovID))
            //    {
            //        List<TrReqDocMovable> _reqDocList = new OrderSurveyPointBL().GetListReqDocbySPIDMovable(_prmOrderSPID);
            //        foreach (var _docItem in _reqDocList)
            //        {
            //            TrResultReqDocMovable _resultReqDocMov = new TrResultReqDocMovable();
            //            _resultReqDocMov.ResultMovableID = _resultMovID;
            //            _resultReqDocMov.ReqDocMovableID = _docItem.ReqDocMovableID;
            //            _resultReqDocMov.PhotoName = String.Empty;
            //            _resultReqDocMov.ImageGuid = Guid.Empty;
            //            _resultReqDocMov.Remark = String.Empty;
            //            _resultReqDocMov.Longitude = String.Empty;
            //            _resultReqDocMov.Latitude = String.Empty;
            //            _resultReqDocMov.UploadDate = DateTime.Now;
            //            _resultReqDocMov.RowStatus = 0;
            //            _resultReqDocMov.CreatedBy = _prmUserName;
            //            _resultReqDocMov.CreatedDate = DateTime.Now;
            //            _resultReqDocMov.ModifiedBy = String.Empty;
            //            _resultReqDocMov.ModifiedDate = DateTime.Now;

            //            long _resultReqDocMovID = 0;
            //            _resultBL.InsertResultReqDocMovable(_resultReqDocMov, ref _resultReqDocMovID);
            //        }
            //    }
            //}
        }
        #endregion

        #region WorkOrderNotMovable
        public TrWorkOrderNotMovable GetSingleWorkOrderNotMovable(long _prmWorkOrderNotMovableID)
        {
            TrWorkOrderNotMovable _result = new TrWorkOrderNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderNotMovableID", _prmWorkOrderNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrWorkOrderNotMovableByWorkOrderNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrWorkOrderNotMovable _woMov = new TrWorkOrderNotMovable();
                    _woMov.WorkOrderNotMovableID = (long)dr["WorkOrderNotMovableID"];
                    _woMov.OrderSPNotMovableID = (long)dr["OrderSPNotMovableID"];
                    _woMov.SurveyorID = (long)dr["SurveyorID"];
                    _woMov.WorkOrderCode = (String)dr["WorkOrderCode"];
                    _woMov.DateCreate = (DateTime)dr["DateCreate"];
                    _woMov.DateExecute = (DateTime)dr["DateExecute"];
                    _woMov.WorkOrderStatusID = (Byte)dr["WorkOrderStatusID"];
                    _woMov.SyncStatus = (Boolean)dr["SyncStatus"];
                    _woMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _woMov.DownloadDate = (DateTime)dr["DownloadDate"];
                    _woMov.OnTheWayDate = (DateTime)dr["OnTheWayDate"];
                    _woMov.OnTheSpotDate = (DateTime)dr["OnTheSpotDate"];
                    _woMov.SurveyResultReceivedDate = (dr["SurveyResultReceivedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SurveyResultReceivedDate"];
                    _woMov.RowStatus = (int)dr["RowStatus"];
                    _woMov.CreatedBy = (String)dr["CreatedBy"];
                    _woMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _woMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _woMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _woMov.Timestamp = (byte[])dr["Timestamp"];
                    _woMov.WORef = (dr["WORef"] == DBNull.Value) ? Convert.ToInt64(0) : (Int64)dr["WORef"];

                    _result = _woMov;
                }
                dr.Close();
            }

            return _result;
        }

        public TrWorkOrderNotMovable GetSingleWorkOrderNotMovableByOrderSPNotMovableID(Int64 _prmOrderSPNotMovableID)
        {
            TrWorkOrderNotMovable _result = null;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPNotMovableID", _prmOrderSPNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrWorkOrderNotMovableByOrderSPNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrWorkOrderNotMovable _woMov = new TrWorkOrderNotMovable();
                    _woMov.WorkOrderNotMovableID = (Int64)dr["WorkOrderNotMovableID"];
                    _woMov.OrderSPNotMovableID = (Int64)dr["OrderSPNotMovableID"];
                    _woMov.SurveyorID = (Int64)dr["SurveyorID"];
                    _woMov.WorkOrderCode = (String)dr["WorkOrderCode"];
                    _woMov.DateCreate = (DateTime)dr["DateCreate"];
                    _woMov.DateExecute = (DateTime)dr["DateExecute"];
                    _woMov.WorkOrderStatusID = (Byte)dr["WorkOrderStatusID"];
                    _woMov.SyncStatus = (Boolean)dr["SyncStatus"];
                    _woMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _woMov.DownloadDate = (DateTime)dr["DownloadDate"];
                    _woMov.OnTheWayDate = (DateTime)dr["OnTheWayDate"];
                    _woMov.OnTheSpotDate = (DateTime)dr["OnTheSpotDate"];
                    _woMov.SurveyResultReceivedDate = (dr["SurveyResultReceivedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["SurveyResultReceivedDate"];
                    _woMov.RowStatus = (int)dr["RowStatus"];
                    _woMov.CreatedBy = (String)dr["CreatedBy"];
                    _woMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _woMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _woMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _woMov.Timestamp = (byte[])dr["Timestamp"];
                    _woMov.WOType = (dr["WOType"] == DBNull.Value) ? Convert.ToByte(0) : (Byte)dr["WOType"];
                    _woMov.WORef = (dr["WORef"] == DBNull.Value) ? Convert.ToInt64(0) : (Int64)dr["WORef"];
                    _result = _woMov;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean InsertWorkOrderNotMovable(TrWorkOrderNotMovable _prmWorkOrder)
        {
            Boolean _result = false;
            String _userName = _prmWorkOrder.CreatedBy;
            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    //TrWorkOrderNotMovable _trWorkOrderNotMovable = this.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_prmWorkOrder.OrderSPNotMovableID);
                    if (_prmWorkOrder.WOType == WOTypeMapper.GetWOType(WOTypeEnum.Correction))
                    {
                        TrWorkOrderNotMovable _trWorkOrderNotMovable = this.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_prmWorkOrder.OrderSPNotMovableID);
                        _trWorkOrderNotMovable.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Correction);
                        _trWorkOrderNotMovable.ModifiedDate = DateTime.Now;
                        _result = this.UpdateWorkOrderNotMovable(_trWorkOrderNotMovable);
                    }

                    object data = null;
                    List<SPParam> _param = new List<SPParam>();
                    _param.Add(new SPParam("@orderSPNotMovableID", _prmWorkOrder.OrderSPNotMovableID, DbType.Int64));
                    _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
                    _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
                    _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
                    _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
                    _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
                    _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
                    _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
                    _param.Add(new SPParam("@downloadDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@onTheWayDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@onTheSpotDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@surveyResultReceivedDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
                    _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
                    _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
                    _param.Add(new SPParam("@modifiedBy", String.Empty, DbType.String));
                    _param.Add(new SPParam("@modifiedDate", this._defaultDate, DbType.DateTime));
                    _param.Add(new SPParam("@wOType", _prmWorkOrder.WOType, DbType.Byte));
                    _param.Add(new SPParam("@wORef", _prmWorkOrder.WORef, DbType.Int64));

                    List<SPParamOut> _paramOut = new List<SPParamOut>();
                    _paramOut.Add(new SPParamOut("@workOrderNotMovableID", null, DbType.Int64));

                    bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrWorkOrderNotMovable", _param, ref _paramOut, ref data);
                    if (_success)
                    {
                        long _woID = Convert.ToInt64(_paramOut[0].Value);
                        //this.CreateWorkOrderNotMovableSequence(_woID, _prmWorkOrder.OrderSPNotMovableID, _userName);

                        OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();
                        TrOrderSPNotMovable _orderSPNotMov = _orderSPBL.GetSingleTrOrderNotMovable(_prmWorkOrder.OrderSPNotMovableID);
                        _orderSPNotMov.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.WaitingForDownload);
                        //_orderSPNotMov.ModifiedBy = HttpContext.Current.User.Identity.Name;
                        _orderSPNotMov.ModifiedBy = _prmWorkOrder.CreatedBy;
                        _orderSPNotMov.ModifiedDate = DateTime.Now;

                        bool _success2 = _orderSPBL.UpdateTrOrderSPNotMovable(_orderSPNotMov);
                        if (_success2)
                        {
                            UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                            _client.UpdateStatusCustomerPortal(SurveyPointType.NotMovable, _prmWorkOrder.OrderSPNotMovableID, GSIInternalStatus.WaitingForDownload, _orderSPNotMov.UserTakeOver);
                            _client.Close();

                            GSIWorkOrderData _woData = new GSIWorkOrderData();
                            TrOrderSPNotMovable _spNotMov = new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_prmWorkOrder.OrderSPNotMovableID);
                            _woData.WorkOrderID = Convert.ToInt64(_paramOut[0].Value);
                            _woData.WorkOrderCode = _prmWorkOrder.WorkOrderCode;
                            _woData.SurveyorID = _prmWorkOrder.SurveyorID;
                            _woData.RemarkAssign = _prmWorkOrder.Remark;
                            _woData.SurveyorCode = new SurveyorBL().GetSingleSurveyor(_prmWorkOrder.SurveyorID).SurveyorCode;
                            _woData.Clue = _spNotMov.Clue;
                            _woData.Address = _spNotMov.Address;
                            _woData.ZipCode = _spNotMov.ZipCode;
                            _woData.Remark = _spNotMov.Remark;
                            //_woData.BusinessFormName = _spNotMov.BusinessLine;
                            _woData.MaritalStatus = "";
                            _woData.Nationality = "";
                            _woData.SpouseName = "";
                            String _businessTypeName = new BusinessTypeBL().GetSingleBusinessType(_spNotMov.BusinessTypeID).BusinessTypeName;
                            String _spName = _spNotMov.SurveyPointName; //new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_spNotMov.OrderSPNotMovableID).SurveyPointName;
                            _woData.SurveyPointName = _businessTypeName + " " + _spName;
                            _woData.JobTitle = "";
                            _woData.JobType = "";
                            _woData.LineBussines = "";

                            //ambil data originator
                            TrOrderSPMovable _originatorData = new TrOrderSPMovable();
                            if (_spNotMov.OriginatorID == -1)
                            {
                                _originatorData = new OrderSurveyPointBL().GetSingleTrOrderMovable(_prmWorkOrder.OrderSPNotMovableID);
                            }
                            else
                            {
                                _originatorData = new OrderSurveyPointBL().GetSingleTrOrderMovable(_spNotMov.OriginatorID);
                            }

                            _woData.OriginatorName = _originatorData.SurveyPointName;
                            _woData.OriginatorMaritalStatus = _originatorData.MaritalStatus;
                            _woData.OriginatorSpouseName = _originatorData.SpouseName;
                            _woData.OriginatorNationality = _originatorData.Nationality;
                            _woData.OriginatorJobTitle = _originatorData.JobTitle;
                            _woData.OriginatorJobType = _originatorData.JobType;
                            _woData.OriginatorLineBussines = _originatorData.BusinessLine;
                            _woData.OriginatorAddress = _originatorData.HomeAddress;
                            _woData.OriginatorClue = _originatorData.Clue;
                            _woData.OriginatorZipCode = _originatorData.ZipCode;
                            _woData.OriginatorRemark = _originatorData.Remark;
                            //ambil data originator end

                            List<TrReqDocNotMovable> _docMov = new OrderSurveyPointBL().GetListReqDocbySPIDNotMovable(_prmWorkOrder.OrderSPNotMovableID);
                            List<GSIRequiredDocumentData> _reqDocList = new List<GSIRequiredDocumentData>();
                            foreach (var _item in _docMov)
                            {
                                GSIRequiredDocumentData _row = new GSIRequiredDocumentData();
                                _row.MobileRequiredDocumentID = _item.ReqDocNotMovableID;
                                _row.DocumentTypeName = new DocumentTypeBL().GetSingleDocumentType(_item.DocumentTypeID).DocumentTypeName;
                                _row.Remark = _item.Remark;

                                _reqDocList.Add(_row);
                            }

                            this.SendToMobile(SurveyPointType.NotMovable, _woData, _reqDocList);

                            String _errMailMessage = "";
                            GeneralHelper _helper = new GeneralHelper();
                            List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Surveyor, _prmWorkOrder.SurveyorID.ToString());
                            //Boolean _resultMail = _helper.SendEmail(_emailTo, "Notification", "No WO : " + _prmWorkOrder.WorkOrderCode + " Survey Point : " + new SurveyPointBL().GetSingleSurveyPoint(_spNotMov.SurveyPointID).SurveyPointName + " untuk Surveyor : " + new SurveyorBL().GetEmployeeNameBySurveyorID(_prmWorkOrder.SurveyorID) + " Telah diterima, silahkan untuk didownload.", ref _errMailMessage);

                            BusinessEntity.BusinessEntities.TrOrder _trOrder = new OrderBL().GetSingleOrderByOrderID(_spNotMov.OrderID);
                            String _message = _helper.MailMessengeBuilderToSurveyor(_prmWorkOrder.WorkOrderCode, OrderMapper.GetOrderTypeName(_trOrder.OrderTypeID), new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_spNotMov.OrderSPNotMovableID).SurveyPointName, new SurveyorBL().GetEmployeeNameBySurveyorID(_prmWorkOrder.SurveyorID));
                            Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Surveyor), _message, ref _errMailMessage);

                            if (_errMailMessage != "") ErrorHandler.ErrorMessage = _errMailMessage;

                            _result = true;
                            _scope.Complete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage += ex.Message;
                }
            }
            return _result;
        }

        public Boolean InsertWorkOrderNotMovableWCF(TrWorkOrderNotMovable _prmWorkOrder, ref long _prmOutID)
        {
            Boolean _result = false;
            String _userName = _prmWorkOrder.CreatedBy;

            try
            {
                object data = null;
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
                _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
                _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
                _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
                _param.Add(new SPParam("@downloadDate", _prmWorkOrder.DownloadDate, DbType.DateTime));
                _param.Add(new SPParam("@modifiedBy", _prmWorkOrder.ModifiedBy, DbType.String));
                _param.Add(new SPParam("@modifiedDate", _prmWorkOrder.ModifiedDate, DbType.DateTime));
                _param.Add(new SPParam("@onTheSpotDate", _prmWorkOrder.OnTheSpotDate, DbType.DateTime));
                _param.Add(new SPParam("@onTheWayDate", _prmWorkOrder.OnTheWayDate, DbType.DateTime));
                _param.Add(new SPParam("@surveyResultReceivedDate", _prmWorkOrder.SurveyResultReceivedDate, DbType.DateTime));
                _param.Add(new SPParam("@orderSPNotMovableID", _prmWorkOrder.OrderSPNotMovableID, DbType.Int64));
                _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
                _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
                _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
                _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
                _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
                _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
                _param.Add(new SPParam("@wOType", _prmWorkOrder.WOType, DbType.Byte));
                _param.Add(new SPParam("@wORef", _prmWorkOrder.WORef, DbType.Int64));

                List<SPParamOut> _paramOut = new List<SPParamOut>();
                _paramOut.Add(new SPParamOut("@workOrderNotMovableID", null, DbType.Int64));

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrWorkOrderNotMovable", _param, ref _paramOut, ref data);
                if (_success)
                {
                    _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                }
            }
            catch (Exception ex)
            {
                String _err = ex.Message;
            }

            return _result;
        }

        public Boolean UpdateWorkOrderNotMovable(TrWorkOrderNotMovable _prmWorkOrder)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderNotMovableID", _prmWorkOrder.WorkOrderNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@orderSPNotMovableID", _prmWorkOrder.OrderSPNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@surveyorID", _prmWorkOrder.SurveyorID, DbType.Int64));
            _param.Add(new SPParam("@workOrderCode", _prmWorkOrder.WorkOrderCode, DbType.String));
            _param.Add(new SPParam("@dateCreate", _prmWorkOrder.DateCreate, DbType.DateTime));
            _param.Add(new SPParam("@dateExecute", _prmWorkOrder.DateExecute, DbType.DateTime));
            _param.Add(new SPParam("@workOrderStatusID", _prmWorkOrder.WorkOrderStatusID, DbType.Byte));
            _param.Add(new SPParam("@syncStatus", _prmWorkOrder.SyncStatus, DbType.Boolean));
            _param.Add(new SPParam("@remark", _prmWorkOrder.Remark, DbType.String));
            _param.Add(new SPParam("@downloadDate", _prmWorkOrder.DownloadDate, DbType.DateTime));
            _param.Add(new SPParam("@onTheWayDate", _prmWorkOrder.OnTheWayDate, DbType.DateTime));
            _param.Add(new SPParam("@onTheSpotDate", _prmWorkOrder.OnTheSpotDate, DbType.DateTime));
            _param.Add(new SPParam("@surveyResultReceivedDate", _prmWorkOrder.SurveyResultReceivedDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmWorkOrder.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmWorkOrder.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmWorkOrder.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmWorkOrder.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmWorkOrder.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmWorkOrder.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrWorkOrderNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        private void CreateWorkOrderNotMovableSequence(Int64 _prmWorkOrderID, Int64 _prmOrderSPID, String _prmUserName)
        {
            ResultBL _resultBL = new ResultBL();

            TrResultNotMovable _resultNotMov = new TrResultNotMovable();
            _resultNotMov.WorkOrderNotMovableID = _prmWorkOrderID;
            //_resultNotMov.BusinessLine = String.Empty;
            _resultNotMov.CompanyCondition = String.Empty;
            _resultNotMov.CompanyPeriod = String.Empty;
            //_resultNotMov.Others = String.Empty;
            _resultNotMov.Remark = String.Empty;
            _resultNotMov.RowStatus = 0;
            _resultNotMov.CreatedBy = _prmUserName;
            _resultNotMov.CreatedDate = DateTime.Now;
            _resultNotMov.ModifiedBy = String.Empty;
            _resultNotMov.ModifiedDate = DateTime.Now;

            long _resultNotMovID = 0;
            _resultBL.InsertResultNotMovable(_resultNotMov, ref _resultNotMovID);
            //if (_resultBL.InsertResultNotMovable(_resultNotMov, ref _resultNotMovID))
            //{
            //    TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = new TrResultPhotoAdditionalNotMovable();
            //    _resultPhotoAddtNotMov.ResultNotMovableID = _resultNotMovID;
            //    _resultPhotoAddtNotMov.PhotoName = String.Empty;
            //    _resultPhotoAddtNotMov.ImageGuid = Guid.Empty;
            //    _resultPhotoAddtNotMov.Remark = String.Empty;
            //    _resultPhotoAddtNotMov.Longitude = String.Empty;
            //    _resultPhotoAddtNotMov.Latitude = String.Empty;
            //    _resultPhotoAddtNotMov.UploadDate = DateTime.Now;
            //    _resultPhotoAddtNotMov.RowStatus = 0;
            //    _resultPhotoAddtNotMov.CreatedBy = _prmUserName;
            //    _resultPhotoAddtNotMov.CreatedDate = DateTime.Now;
            //    _resultPhotoAddtNotMov.ModifiedBy = String.Empty;
            //    _resultPhotoAddtNotMov.ModifiedDate = DateTime.Now;

            //    long _resultPhotoAddtNotMovID = 0;
            //    if (_resultBL.InsertResultPhotoAddNotMov(_resultPhotoAddtNotMov, ref _resultPhotoAddtNotMovID))
            //    {
            //        List<TrReqDocNotMovable> _reqDocList = new OrderSurveyPointBL().GetListReqDocbySPIDNotMovable(_prmOrderSPID);
            //        foreach (var _docItem in _reqDocList)
            //        {
            //            TrResultReqDocNotMovable _resultReqDocNotMov = new TrResultReqDocNotMovable();
            //            _resultReqDocNotMov.ResultNotMovableID = _resultNotMovID;
            //            _resultReqDocNotMov.ReqDocNotMovableID = _docItem.ReqDocNotMovableID;
            //            _resultReqDocNotMov.PhotoName = String.Empty;
            //            _resultReqDocNotMov.ImageGuid = Guid.Empty;
            //            _resultReqDocNotMov.Remark = String.Empty;
            //            _resultReqDocNotMov.Longitude = String.Empty;
            //            _resultReqDocNotMov.Latitude = String.Empty;
            //            _resultReqDocNotMov.UploadDate = DateTime.Now;
            //            _resultReqDocNotMov.RowStatus = 0;
            //            _resultReqDocNotMov.CreatedBy = _prmUserName;
            //            _resultReqDocNotMov.CreatedDate = DateTime.Now;
            //            _resultReqDocNotMov.ModifiedBy = String.Empty;
            //            _resultReqDocNotMov.ModifiedDate = DateTime.Now;

            //            long _resultReqDocNotMovID = 0;
            //            _resultBL.InsertResultReqDocNotMovable(_resultReqDocNotMov, ref _resultReqDocNotMovID);
            //        }
            //    }
            //}
        }
        #endregion

        public List<TrWorkOrder> GetListWorkOrder(String _prmWorkOrderCode, String _prmWorkOrderStatus, String _prmCustName, DateTime _prmWorkOrderStartDate, DateTime _prmWorkOrderEndDate, String _prmEmployeeName, String _prmSPName, Int64 _prmRegion, Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc, Int16 _prmWOType)
        {
            List<TrWorkOrder> _result = new List<TrWorkOrder>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderCode", _prmWorkOrderCode, DbType.String));
            _param.Add(new SPParam("@startDateCreate", _prmWorkOrderStartDate, DbType.DateTime));
            _param.Add(new SPParam("@endDateCreate", _prmWorkOrderEndDate, DbType.DateTime));
            _param.Add(new SPParam("@customerName", _prmCustName, DbType.String));
            _param.Add(new SPParam("@workOrderStatusID", Convert.ToByte(_prmWorkOrderStatus), DbType.Byte));
            _param.Add(new SPParam("@employeeName", _prmEmployeeName, DbType.String));
            _param.Add(new SPParam("@surveyPointName", _prmSPName, DbType.String));
            _param.Add(new SPParam("@regionID", _prmRegion, DbType.Int64));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));
            _param.Add(new SPParam("@wOType", _prmWOType, DbType.Byte));            

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListWorkOrder", _param, ref _paramOut, ref data);
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListWorkOrder_Trial", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrWorkOrder _workOrder = new TrWorkOrder();
                    _workOrder.WorkOrderID = (long)dr["WorkOrderID"];
                    _workOrder.WorkOrderCode = (String)dr["WorkOrderCode"];
                    _workOrder.DateCreate = (DateTime)dr["DateCreate"];
                    _workOrder.DateExecute = (DateTime)dr["DateExecute"];
                    _workOrder.WorkOrderStatusID = (Byte)dr["WorkOrderStatusID"];
                    _workOrder.CustomerName = (dr["CustomerName"] == DBNull.Value) ? "" : (String)dr["CustomerName"];
                    _workOrder.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _workOrder.EmployeeName = (dr["EmployeeName"] == DBNull.Value) ? "" : (String)dr["EmployeeName"];
                    _workOrder.SurveyPointID = (dr["SurveyPointID"] == DBNull.Value) ? 0 : (Int64)dr["SurveyPointID"];
                    _workOrder.SPStatus = (dr["SPStatus"] == DBNull.Value) ? Convert.ToByte(0) : (Byte)dr["SPStatus"];
                    _workOrder.OrderTypeID = (dr["OrderTypeID"] == DBNull.Value) ? 0 : (Int64)dr["OrderTypeID"];
                    _workOrder.OrderID = (dr["OrderID"] == DBNull.Value) ? 0 : (Int64)dr["OrderID"];
                    _workOrder.OrderSPID = (dr["OrderSPID"] == DBNull.Value) ? 0 : (Int64)dr["OrderSPID"];
                    _workOrder.OnTheWayDate = (DateTime)dr["OnTheWayDate"];
                    _workOrder.OnTheSpotDate = (DateTime)dr["OnTheSpotDate"];
                    _workOrder.SurveyResultReceivedDate = (dr["SurveyResultReceivedDate"] == DBNull.Value) ? DateTime.Now : (DateTime)dr["SurveyResultReceivedDate"];
                    _workOrder.WOType = (dr["WOType"] == DBNull.Value) ? Convert.ToByte(0) : (Byte)dr["WOType"];
                    _workOrder.SurveyorID = (dr["SurveyorID"] == DBNull.Value) ? 0 : (Int64)dr["SurveyorID"];
                    _workOrder.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];
                    //_workOrder.WORef = (dr["WORef"] == DBNull.Value) ? (Byte)0 : (Byte)dr["WORef"];
                    _result.Add(_workOrder);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }
            return _result;
        }

        public void UpdateStatusCustomerPortal(SurveyPointType _prmSPType, long _prmSPID, GSIInternalStatus _prmStatus, String _prmUserTakeOver)
        {
            UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.UpdateStatusCustomerPortal(_prmSPType, _prmSPID, _prmStatus, _prmUserTakeOver);
            _client.Close();
        }

        public bool PublishedToCustomerPortal(string[] _cd, ref string _prmWarninglabel)
        {
            bool _resultPublish = false;
            SurveyPointBL _surveyPointBL = new SurveyPointBL();
            OrderBL _orderBL = new OrderBL();
            OrderSurveyPointBL _orderSurveyPointBL = new OrderSurveyPointBL();
            WCFBL _wCFBL = new WCFBL();

            MsSurveyPoint _template = _surveyPointBL.GetTemplateSurveyPoint((Convert.ToInt64(_cd[0])), Convert.ToInt64(_cd[1]));
            if (_template.TemplateForm == 1)
            {
                TrOrderSPNotMovable _trOrderSPNotMovable = _orderSurveyPointBL.GetSingleTrOrderNotMovable(Convert.ToInt64(_cd[3]));

                if (_trOrderSPNotMovable.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
                {
                    using (TransactionScope _scope = new TransactionScope())
                    {
                        try
                        {
                            _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
                            Boolean _result = _orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                            TrWorkOrderNotMovable _workOrderNotMov = this.GetSingleWorkOrderNotMovableByOrderSPNotMovableID(_trOrderSPNotMovable.OrderSPNotMovableID);
                            _workOrderNotMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);

                            Boolean _result2 = this.UpdateWorkOrderNotMovable(_workOrderNotMov);

                            if (_result == true && _result2 == true)
                            {
                                String _resultMov = _wCFBL.PublishedNotMoveable(Convert.ToInt64(_cd[3]));

                                UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                                _client.UpdateStatusCustomerPortal(SurveyPointType.NotMovable, _trOrderSPNotMovable.OrderSPNotMovableID, GSIInternalStatus.Published, _trOrderSPNotMovable.UserTakeOver);
                                _client.Close();

                                Boolean _cekTrOrder = _orderBL.IsOrderSurveyPointAllComplete(Convert.ToInt64(_cd[2]));
                                if (_cekTrOrder == true)
                                {
                                    TrOrder _trOrder = _orderBL.GetSingleOrderByOrderID(Convert.ToInt64(_cd[2]));
                                    _trOrder.OrderStatus = OrderVersionMapper.GetOrderVersion(OrderVersion.Final);

                                    if (_orderBL.UpdateOrder(_trOrder))
                                    {
                                        _prmWarninglabel = "Order Complete. ";
                                    }
                                }

                                _prmWarninglabel = _prmWarninglabel + "Success Publish";

                                TrOrder _order = _orderBL.GetSingleOrderByOrderID(_trOrderSPNotMovable.OrderID);
                                long _customerID = _order.CustomerID;
                                String _errMailMessage = "";
                                GeneralHelper _helper = new GeneralHelper();
                                List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Customer, _customerID.ToString());
                                //Boolean _resultMail = _helper.SendEmail(_emailTo, "Notification", "No Order : " + _order.OrderCode + " Survey Point " + new SurveyPointBL().GetSingleSurveyPoint(_trOrderSPNotMovable.SurveyPointID).SurveyPointName + " telah selesai.", ref _errMailMessage);

                                String _message = _helper.MailMessengeBuilderToCustomer(new CustomerBL().CustomerNameByCustomerID(_customerID).CustomerName, OrderMapper.GetOrderTypeName(_order.OrderTypeID), _order.OrderCode, new OrderSurveyPointBL().GetSingleTrOrderNotMovable(_trOrderSPNotMovable.OrderSPNotMovableID).SurveyPointName, ConfigurationManager.AppSettings["WebPage"]);
                                Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Customer), _message, ref _errMailMessage);

                                if (_errMailMessage != "") ErrorHandler.ErrorMessage = _errMailMessage;

                                if (_resultMail) _scope.Complete();
                                _resultPublish = true;
                            }
                            //else
                            //{
                            //    _trOrderSPNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                            //    _orderSurveyPointBL.UpdateTrOrderSPNotMovable(_trOrderSPNotMovable);

                            //    _workOrderNotMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                            //    this.UpdateWorkOrderNotMovable(_workOrderNotMov);
                            //}
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.ErrorMessage += ex.Message;
                        }
                    }
                }
            }

            if (_template.TemplateForm == 0)
            {
                TrOrderSPMovable _trOrderSPMovable = _orderSurveyPointBL.GetSingleTrOrderMovable(Convert.ToInt64(_cd[3]));

                if (_trOrderSPMovable.SPStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived))
                {
                    using (TransactionScope _scope = new TransactionScope())
                    {
                        try
                        {
                            _trOrderSPMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);
                            Boolean _result = _orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);

                            TrWorkOrderMovable _workOrderMov = this.GetSingleWorkOrderMovableByOrderSPMovableID(_trOrderSPMovable.OrderSPMovableID);
                            _workOrderMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.Published);

                            Boolean _result2 = this.UpdateWorkOrderMovable(_workOrderMov);

                            if (_result == true && _result2 == true)
                            {
                                String _resultMov = _wCFBL.PublishedMoveable(Convert.ToInt64(_cd[3]));

                                UpdateCPStatusServiceReference.UpdateCPStatusServiceClient _client = new UpdateCPStatusServiceReference.UpdateCPStatusServiceClient();

                                //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                                //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);

                                _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                                _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                                _client.UpdateStatusCustomerPortal(SurveyPointType.Movable, _trOrderSPMovable.OrderSPMovableID, GSIInternalStatus.Published, _trOrderSPMovable.UserTakeOver);
                                _client.Close();

                                Boolean _cekTrOrder = _orderBL.IsOrderSurveyPointAllComplete(Convert.ToInt64(_cd[2]));
                                if (_cekTrOrder == true)
                                {
                                    TrOrder _trOrder = _orderBL.GetSingleOrderByOrderID(Convert.ToInt64(_cd[2]));
                                    _trOrder.OrderStatus = OrderVersionMapper.GetOrderVersion(OrderVersion.Final);

                                    if (_orderBL.UpdateOrder(_trOrder))
                                    {
                                        _prmWarninglabel = "Order Complete. ";
                                    }
                                }
                                _prmWarninglabel = _prmWarninglabel + "Success Publish";

                                TrOrder _order = _orderBL.GetSingleOrderByOrderID(_trOrderSPMovable.OrderID);
                                long _customerID = _order.CustomerID;
                                String _errMailMessage = "";
                                GeneralHelper _helper = new GeneralHelper();
                                List<String> _emailTo = _helper.GetEmailFromTarget(DestinationEmail.Customer, _customerID.ToString());
                                //Boolean _resultMail = _helper.SendEmail(_emailTo, "Notification", "No Order : " + _order.OrderCode + " Survey Point " + new SurveyPointBL().GetSingleSurveyPoint(_trOrderSPMovable.SurveyPointID).SurveyPointName + " telah selesai.", ref _errMailMessage);

                                String _message = _helper.MailMessengeBuilderToCustomer(new CustomerBL().CustomerNameByCustomerID(_customerID).CustomerName, OrderMapper.GetOrderTypeName(_order.OrderTypeID), _order.OrderCode, new OrderSurveyPointBL().GetSingleTrOrderMovable(_trOrderSPMovable.OrderSPMovableID).SurveyPointName, ConfigurationManager.AppSettings["WebPage"]);
                                Boolean _resultMail = _helper.SendEmail(_emailTo, GeneralHelper.GetEmailSubject(DestinationEmail.Customer), _message, ref _errMailMessage);

                                if (_errMailMessage != "") ErrorHandler.ErrorMessage = _errMailMessage;

                                if (_resultMail) _scope.Complete();
                                _resultPublish = true;
                            }
                            //else
                            //{
                            //    _trOrderSPMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                            //    _orderSurveyPointBL.UpdateTrOrderSPMovable(_trOrderSPMovable);

                            //    _workOrderMov.WorkOrderStatusID = StatusMapper.GetStatusInternal(GSIInternalStatus.SurveyResultReceived);
                            //    this.UpdateWorkOrderMovable(_workOrderMov);
                            //}
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.ErrorMessage += ex.Message;
                        }
                    }
                }
            }

            return _resultPublish;
        }

        public bool SendToMobile(SurveyPointType _prmSPType, GSIWorkOrderData _prmWO, List<GSIRequiredDocumentData> _prmReqDoc)
        {
            bool _result = false;

            WorkOrderData _dataWO = new WorkOrderData();
            _dataWO.WorkOrderID = _prmWO.WorkOrderID;
            _dataWO.WorkOrderCode = _prmWO.WorkOrderCode;
            _dataWO.SurveyorID = _prmWO.SurveyorID;
            _dataWO.SurveyorCode = _prmWO.SurveyorCode;
            _dataWO.Clue = _prmWO.Clue;
            _dataWO.Address = _prmWO.Address;
            _dataWO.ZipCode = _prmWO.ZipCode;
            _dataWO.MaritalStatus = _prmWO.MaritalStatus;
            _dataWO.Nationality = _prmWO.Nationality;
            _dataWO.Remark = _prmWO.Remark;
            _dataWO.RemarkFromDispatcher = _prmWO.RemarkAssign;
            _dataWO.BusinessFormName = _prmWO.BusinessFormName;
            _dataWO.SpouseName = _prmWO.SpouseName;
            if (_prmSPType == SurveyPointType.Movable)
            {
                if (_prmWO.SurveyPointID == Convert.ToInt64(ConfigurationManager.AppSettings["OriginatorID"].ToString()))
                {
                    _dataWO.SurveyPointTemplateForm = SurveyPointTemplateForm.Originator;
                }
                else
                {
                    _dataWO.SurveyPointTemplateForm = SurveyPointTemplateForm.Movable;
                }
            }
            else
            {
                _dataWO.SurveyPointTemplateForm = SurveyPointTemplateForm.NotMovable;
            }
            //_dataWO.SurveyPointTemplateForm = (_prmSPType == SurveyPointType.Movable) ? SurveyPointTemplateForm.Movable : SurveyPointTemplateForm.NotMovable;
            _dataWO.SurveyPointName = _prmWO.SurveyPointName;
            _dataWO.JobTitle = _prmWO.JobTitle;
            _dataWO.JobType = _prmWO.JobType;
            _dataWO.LineBussines = _prmWO.LineBussines;

            _dataWO.OriginatorName = _prmWO.OriginatorName;
            _dataWO.OriginatorMaritalStatus = _prmWO.OriginatorMaritalStatus;
            _dataWO.OriginatorSpouseName = _prmWO.OriginatorSpouseName;
            _dataWO.OriginatorNationality = _prmWO.OriginatorNationality;
            _dataWO.OriginatorJobTitle = _prmWO.OriginatorJobTitle;
            _dataWO.OriginatorJobType = _prmWO.OriginatorJobType;
            _dataWO.OriginatorLineBussines = _prmWO.OriginatorLineBussines;
            _dataWO.OriginatorAddress = _prmWO.OriginatorAddress;
            _dataWO.OriginatorClue = _prmWO.OriginatorClue;
            _dataWO.OriginatorZipCode = _prmWO.OriginatorZipCode;
            _dataWO.OriginatorRemark = _prmWO.OriginatorRemark;

            GSI.BusinessRuleCore.MobileSystemWorkOrderServices.WorkOrderData _a = new WorkOrderData();
            List<RequiredDocumentData> _reqDocList = new List<RequiredDocumentData>();
            foreach (var _item in _prmReqDoc)
            {
                RequiredDocumentData _reqDoc = new RequiredDocumentData();
                _reqDoc.MobileRequiredDocumentID = _item.MobileRequiredDocumentID;
                _reqDoc.DocumentTypeName = _item.DocumentTypeName;
                _reqDoc.Remark = _item.Remark;
                _reqDocList.Add(_reqDoc);
            }
            _dataWO.RequiredDocument = _reqDocList.ToArray();

            MobileSystemWorkOrderServices.WorkOrderClient _client = new MobileSystemWorkOrderServices.WorkOrderClient();

            //_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);
            //System.Net.NetworkCredential _ncre = new System.Net.NetworkCredential();
            //_ncre.UserName = (ConfigurationManager.AppSettings["UserName"]);
            //_ncre.Password = (ConfigurationManager.AppSettings["Password"]);
            //_client.ClientCredentials.Windows.ClientCredential = _ncre; 

            //<add key="UserName" value="GSIDEV\GSIAppPool" />;
            //<add key="Password" value="GlobalSurve   

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            _client.Create(_dataWO);
            _client.Close();

            return _result;
        }

        public ReportDataSource PrintPreview(String _prmType,Int64 _prmWorkOrderID)
        {
            ReportDataSource _result = new ReportDataSource();
            DataTable _dataTable = new DataTable();

            try
            {
                SqlConnection _conn = new SqlConnection(new UserBL().ConnectionString(HttpContext.Current.User.Identity.Name));

                SqlCommand _cmd = new SqlCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.Clear();
                _cmd.Connection = _conn;
                if (_prmType == "OrderNotMovable")
                {
                    _cmd.CommandText = "sp_ReportByWorkOrderNotMovableID";
                    _cmd.Parameters.AddWithValue("@workOrderNotMovableID", _prmWorkOrderID);
                }
                else if (_prmType == "OrderMovable")
                {
                    _cmd.CommandText = "sp_ReportByWorkOrderMovableID";
                    _cmd.Parameters.AddWithValue("@workOrderMovableID", _prmWorkOrderID);
                }
                SqlDataAdapter _da = new SqlDataAdapter();

                _da.SelectCommand = _cmd;
                _da.Fill(_dataTable);

                _result.Value = _dataTable;
                _result.Name = "CoreSystem";
            }
            catch (Exception ex)
            {
                String _err = ex.Message;
            }

            return _result;
        }
    }
}
