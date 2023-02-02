using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using System.Transactions;

namespace GSI.BusinessRule
{
    public class OrderSurveyPointBL : Base
    {
        List<String> _DocReqCheckList = new List<String>();

        public OrderSurveyPointBL()
        {
        }

        public MsSurveyPoint GetTemplateSurveyPoint(Int64 _prmOrderTypeID, Int64 _prmSurveyPointID)
        {
            MsSurveyPoint _result = new MsSurveyPoint();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderTypeID", _prmOrderTypeID, DbType.Int64));
            _param.Add(new SPParam("@SurveyPointID", _prmSurveyPointID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTemplateSurveyPoint", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    MsSurveyPoint _order = new MsSurveyPoint();
                    _order.TemplateForm = (Int32)dr["TemplateForm"];

                    _result = _order;
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
                    MsBusinessType _bussinessType = new MsBusinessType();
                    _bussinessType.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _bussinessType.BusinessTypeName = (dr["BusinessTypeName"] == DBNull.Value) ? String.Empty : (String)dr["BusinessTypeName"];

                    _result.Add(_bussinessType);
                }
                dr.Close();
            }

            return _result;
        }

        #region SurveyPointMovable

        public int InsertOrderWithPersonal(String _prmDocumentType, String _prmOrderID, TrOrder _prmOrder, TrOrderSPMovable _prmOrderSPMovable, TrReqDocMovable _prmTrReqDocMovable, ref long _prmOrderIDOut)
        {
            int _result = 0;

            object data = null;
            object data2 = null;
            object data3 = null;

            List<SPParam> _param = new List<SPParam>();
            List<SPParam> _param2 = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            List<SPParamOut> _paramOut2 = new List<SPParamOut>();

            Int64 _orderID = 0;
            Int64 _orderSPMovableID = 0;

            bool _successTrOrder = false;
            bool _successOrderSPMovable = false;
            bool _successTrReqDocMovable = false;
            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    if (_prmOrderID == "")
                    {
                        _param.Add(new SPParam("@customerID", _prmOrder.CustomerID, DbType.Int64));
                        _param.Add(new SPParam("@orderCode", _prmOrder.OrderCode, DbType.String));
                        _param.Add(new SPParam("@orderTypeID", _prmOrder.OrderTypeID, DbType.Int64));
                        _param.Add(new SPParam("@orderDate", _prmOrder.OrderDate, DbType.DateTime));
                        _param.Add(new SPParam("@orderVersion", _prmOrder.OrderVersion, DbType.String));
                        _param.Add(new SPParam("@orderStatus", _prmOrder.OrderStatus, DbType.Byte));
                        _param.Add(new SPParam("@proceedDate", _prmOrder.ProceedDate, DbType.DateTime));
                        _param.Add(new SPParam("@remark", _prmOrder.Remark, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));
                        _param.Add(new SPParam("@createdBy", _prmOrder.CreatedBy, DbType.String));
                        _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                        _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

                        _paramOut.Add(new SPParamOut("@orderID", null, DbType.Int32));

                        _successTrOrder = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrder", _param, ref _paramOut, ref data);

                        _orderID = Convert.ToInt64(_paramOut[0].Value);
                        _prmOrderIDOut = _orderID;
                    }
                    else
                    {
                        _param.Add(new SPParam("@orderID", _prmOrder.OrderID, DbType.Int64));
                        _param.Add(new SPParam("@customerID", _prmOrder.CustomerID, DbType.Int64));
                        _param.Add(new SPParam("@orderCode", _prmOrder.OrderCode, DbType.String));
                        _param.Add(new SPParam("@orderTypeID", _prmOrder.OrderTypeID, DbType.Int64));
                        _param.Add(new SPParam("@orderDate", _prmOrder.OrderDate, DbType.DateTime));
                        _param.Add(new SPParam("@orderVersion", _prmOrder.OrderVersion, DbType.String));
                        _param.Add(new SPParam("@orderStatus", _prmOrder.OrderStatus, DbType.Byte));
                        _param.Add(new SPParam("@proceedDate", _prmOrder.ProceedDate, DbType.DateTime));
                        _param.Add(new SPParam("@remark", _prmOrder.Remark, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));
                        _param.Add(new SPParam("@createdBy", _prmOrder.CreatedBy, DbType.String));
                        _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                        _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@timestamp", _prmOrder.Timestamp, DbType.Binary));

                        _successTrOrder = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrder", _param, ref _paramOut, ref data);

                        _orderID = _prmOrder.OrderID;
                    }

                    _param2.Add(new SPParam("@surveyPointName", _prmOrderSPMovable.SurveyPointName, DbType.String));
                    _param2.Add(new SPParam("@maritalStatus", _prmOrderSPMovable.MaritalStatus, DbType.String));
                    _param2.Add(new SPParam("@spouseName", _prmOrderSPMovable.SpouseName, DbType.String));
                    _param2.Add(new SPParam("@nationality", _prmOrderSPMovable.Nationality, DbType.String));
                    _param2.Add(new SPParam("@placeOfBirth", _prmOrderSPMovable.PlaceOfBirth, DbType.String));
                    _param2.Add(new SPParam("@dateOfBirth", _prmOrderSPMovable.DateOfBirth, DbType.DateTime));
                    _param2.Add(new SPParam("@iDType", _prmOrderSPMovable.IDType, DbType.Int32));
                    _param2.Add(new SPParam("@iDNo", _prmOrderSPMovable.IDNo, DbType.String));
                    _param2.Add(new SPParam("@iDAddress", _prmOrderSPMovable.IDAddress, DbType.String));
                    _param2.Add(new SPParam("@surveyPointID", _prmOrderSPMovable.SurveyPointID, DbType.Int64));
                    _param2.Add(new SPParam("@clue", _prmOrderSPMovable.Clue, DbType.String));
                    _param2.Add(new SPParam("@zipCode", _prmOrderSPMovable.ZipCode, DbType.String));
                    _param2.Add(new SPParam("@remark", _prmOrderSPMovable.Remark, DbType.String));
                    _param2.Add(new SPParam("@homeAddress", _prmOrderSPMovable.HomeAddress, DbType.String));
                    _param2.Add(new SPParam("@sPStatus", _prmOrderSPMovable.SPStatus, DbType.Int64));
                    _param2.Add(new SPParam("@mobilePhoneNumber", _prmOrderSPMovable.MobilePhoneNumber, DbType.String));
                    _param2.Add(new SPParam("@homePhoneNumber", _prmOrderSPMovable.HomePhoneNumber, DbType.String));
                    _param2.Add(new SPParam("@userTakeOver", "", DbType.String));
                    _param2.Add(new SPParam("@regionID", _prmOrderSPMovable.RegionID, DbType.Int64));
                    _param2.Add(new SPParam("@extension", _prmOrderSPMovable.Extension, DbType.String));
                    _param2.Add(new SPParam("@originatorID", _prmOrderSPMovable.OriginatorID, DbType.Int64));
                    _param2.Add(new SPParam("@rowStatus", _prmOrderSPMovable.RowStatus, DbType.Int32));
                    _param2.Add(new SPParam("@createdBy", _prmOrderSPMovable.CreatedBy, DbType.String));
                    _param2.Add(new SPParam("@createdDate", _prmOrderSPMovable.CreatedDate, DbType.DateTime));
                    _param2.Add(new SPParam("@modifiedBy", "", DbType.String));
                    _param2.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                    _param2.Add(new SPParam("@jobTitle", _prmOrderSPMovable.JobTitle, DbType.String));
                    _param2.Add(new SPParam("@jobType", _prmOrderSPMovable.JobType, DbType.String));
                    _param2.Add(new SPParam("@businessLine", _prmOrderSPMovable.BusinessLine, DbType.String));
                    _param2.Add(new SPParam("@remarkComplaint", "", DbType.String));
                    _param2.Add(new SPParam("@remarkCancel", "", DbType.String));
                    _param2.Add(new SPParam("@fgComplaint", _prmOrderSPMovable.FgComplaint, DbType.Boolean));
                    _param2.Add(new SPParam("@cancelStatus", _prmOrderSPMovable.CancelStatus, DbType.Byte));

                    _paramOut2.Add(new SPParamOut("@orderSPMovableID", null, DbType.Int64));

                    if (_prmOrderID == "")
                    {
                        _param2.Add(new SPParam("@orderID", _orderID, DbType.Int64));
                    }
                    else
                    {
                        _param2.Add(new SPParam("@orderID", _prmOrderID, DbType.Int32));
                    }
                    if (_prmOrderID == "")
                    {
                        if (_successTrOrder == true)
                        {
                            _successOrderSPMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrderSPMovable", _param2, ref _paramOut2, ref data2);
                        }
                    }
                    else
                    {
                        _successOrderSPMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrderSPMovable", _param2, ref _paramOut2, ref data2);

                    }
                    _orderSPMovableID = Convert.ToInt64(_paramOut2[0].Value);

                    if (_successOrderSPMovable == true)
                    {
                        if (_prmDocumentType != "")
                        {
                            string[] _split = _prmDocumentType.Split(',');
                            for (int i = 0; i < _split.Length; i++)
                            {
                                List<SPParam> _param3 = new List<SPParam>();
                                _param3.Add(new SPParam("@documentTypeID", _split[i], DbType.Int32));
                                _param3.Add(new SPParam("@orderSPMovableID", _orderSPMovableID, DbType.Int64));
                                _param3.Add(new SPParam("@remark", _prmTrReqDocMovable.Remark, DbType.String));
                                _param3.Add(new SPParam("@reqDocMovableID", null, DbType.Int64));
                                _param3.Add(new SPParam("@rowStatus", _prmTrReqDocMovable.RowStatus, DbType.Int32));
                                _param3.Add(new SPParam("@createdBy", _prmTrReqDocMovable.CreatedBy, DbType.String));
                                _param3.Add(new SPParam("@createdDate", _prmTrReqDocMovable.CreatedDate, DbType.DateTime));
                                _param3.Add(new SPParam("@modifiedBy", "", DbType.String));
                                _param3.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                                List<SPParamOut> _paramOut3 = new List<SPParamOut>();

                                _successTrReqDocMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrReqDocMovable", _param3, ref _paramOut3, ref data3);
                            }
                        }
                        else
                        {
                            _result = (int)data2;
                        }
                    }

                    if (_successTrReqDocMovable == true)
                    {
                        _result = (int)data3;
                    }
                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage = ex.Message;
                }
            }
            return _result;
        }

        public TrOrderSPMovable GetSingleTrOrderMovable(Int64 _prmOrderSPID)
        {
            TrOrderSPMovable _result = new TrOrderSPMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSPID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrOrderSPMovableByOrderSPMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPMovable _order = new TrOrderSPMovable();
                    _order.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    _order.HomeAddress = (String)dr["HomeAddress"];
                    _order.IDAddress = (String)dr["IDAddress"];
                    _order.Clue = (String)dr["Clue"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _order.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _order.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _order.HomePhoneNumber = (String)dr["HomePhoneNumber"];
                    _order.IDNo = (String)dr["IDNo"];
                    _order.IDType = (Byte)dr["IDType"];
                    _order.MaritalStatus = (String)dr["MaritalStatus"];
                    _order.MobilePhoneNumber = (String)dr["MobilePhoneNumber"];
                    _order.Nationality = (String)dr["Nationality"];
                    _order.OrderSPMovableID = (long)dr["OrderSPMovableID"];
                    _order.PlaceOfBirth = (String)dr["PlaceOfBirth"];
                    _order.SpouseName = (String)dr["SpouseName"];
                    _order.OrderID = (long)dr["OrderID"];
                    _order.SurveyPointID = (long)dr["SurveyPointID"];
                    _order.Extension = (String)dr["Extension"];
                    _order.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _order.SPStatus = (Byte)dr["SPStatus"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _order.RegionID = (long)dr["RegionID"];
                    _order.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _order.RowStatus = (Int32)dr["RowStatus"];
                    _order.CreatedBy = (String)dr["CreatedBy"];
                    _order.CreatedDate = (DateTime)dr["CreatedDate"];
                    _order.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _order.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _order.Timestamp = (byte[])dr["Timestamp"];
                    _order.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _order.OriginatorID = (dr["OriginatorID"] == DBNull.Value) ? 0 : (long)dr["OriginatorID"];
                    _order.JobTitle = (dr["JobTitle"] == DBNull.Value) ? String.Empty : (String)dr["JobTitle"];
                    _order.JobType = (dr["JobType"] == DBNull.Value) ? String.Empty : (String)dr["JobType"];
                    _order.BusinessLine = (dr["BusinessLine"] == DBNull.Value) ? String.Empty : (String)dr["BusinessLine"];
                    _order.RemarkComplaint = (dr["RemarkComplaint"] == DBNull.Value) ? String.Empty : (String)dr["RemarkComplaint"];
                    _order.RemarkCancel = (dr["RemarkCancel"] == DBNull.Value) ? String.Empty : (String)dr["RemarkCancel"];
                    _order.FgComplaint = (dr["FgComplaint"] == DBNull.Value) ? false : (Boolean)dr["FgComplaint"];
                    _order.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];

                    _result = _order;
                }
                dr.Close();
            }

            return _result;
        }

        public TrOrderSPMovable GetOriginatorPersonalByOrderID(Int64 _prmOrderID)
        {
            TrOrderSPMovable _result = new TrOrderSPMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderId", _prmOrderID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetOriginatorPersonalByOrderId", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPMovable _order = new TrOrderSPMovable();
                    _order.OrderSPMovableID = (long)dr["OrderSPMovableID"];
                    _order.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];                    
                    _order.SPStatus = (Byte)dr["SPStatus"];                    

                    _result = _order;
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrReqDocMovable> GetListReqDocbySPIDMovable(Int64 _prmOrderSPMovableID)
        {
            List<TrReqDocMovable> _result = new List<TrReqDocMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSPMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            //_paramOut.Add(new SPParamOut("@CustID", "", DbType.String));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrReqDocMovableByOrderSPMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrReqDocMovable _order = new TrReqDocMovable();
                    _order.DocumentTypeID = (Int64)dr["DocumentTypeID"];
                    _order.ReqDocMovableID = (long)dr["ReqDocMovableID"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateTrOrderSPMovable(TrOrderSPMovable _prmOrderSPID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@clue", _prmOrderSPID.Clue, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmOrderSPID.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmOrderSPID.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@dateOfBirth", _prmOrderSPID.DateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@extension", _prmOrderSPID.Extension, DbType.String));
            _param.Add(new SPParam("@homeAddress", _prmOrderSPID.HomeAddress, DbType.String));
            _param.Add(new SPParam("@homePhoneNumber", _prmOrderSPID.HomePhoneNumber, DbType.String));
            _param.Add(new SPParam("@iDAddress", _prmOrderSPID.IDAddress, DbType.String));
            _param.Add(new SPParam("@iDNo", _prmOrderSPID.IDNo, DbType.String));
            _param.Add(new SPParam("@iDType", _prmOrderSPID.IDType, DbType.Byte));
            _param.Add(new SPParam("@maritalStatus", _prmOrderSPID.MaritalStatus, DbType.String));
            _param.Add(new SPParam("@mobilePhoneNumber", _prmOrderSPID.MobilePhoneNumber, DbType.String));
            _param.Add(new SPParam("@nationality", _prmOrderSPID.Nationality, DbType.String));
            _param.Add(new SPParam("@orderID", _prmOrderSPID.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSPID.OrderSPMovableID, DbType.Int64));
            _param.Add(new SPParam("@placeOfBirth", _prmOrderSPID.PlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@spouseName", _prmOrderSPID.SpouseName, DbType.String));
            _param.Add(new SPParam("@regionID", _prmOrderSPID.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _prmOrderSPID.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _prmOrderSPID.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _prmOrderSPID.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmOrderSPID.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _prmOrderSPID.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOrderSPID.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@modifiedBy", _prmOrderSPID.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOrderSPID.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmOrderSPID.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _prmOrderSPID.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _prmOrderSPID.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@jobTitle", _prmOrderSPID.JobTitle, DbType.String));
            _param.Add(new SPParam("@jobType", _prmOrderSPID.JobType, DbType.String));
            _param.Add(new SPParam("@businessLine", _prmOrderSPID.BusinessLine, DbType.String));
            _param.Add(new SPParam("@cancelStatus", _prmOrderSPID.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _prmOrderSPID.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _prmOrderSPID.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _prmOrderSPID.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        public Boolean UpdateTrOrderSPMovable(TrOrderSPMovable _prmOrderSP, TrReqDocMovable _prmTrReqDocMovable, String _prmDocumentType)
        {
            Boolean _result = false;
            Boolean _successTrReqDocMovable = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParam> _paramDoc = new List<SPParam>();

            _param.Add(new SPParam("@clue", _prmOrderSP.Clue, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmOrderSP.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmOrderSP.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@dateOfBirth", _prmOrderSP.DateOfBirth, DbType.DateTime));
            _param.Add(new SPParam("@extension", _prmOrderSP.Extension, DbType.String));
            _param.Add(new SPParam("@homeAddress", _prmOrderSP.HomeAddress, DbType.String));
            _param.Add(new SPParam("@homePhoneNumber", _prmOrderSP.HomePhoneNumber, DbType.String));
            _param.Add(new SPParam("@iDAddress", _prmOrderSP.IDAddress, DbType.String));
            _param.Add(new SPParam("@iDNo", _prmOrderSP.IDNo, DbType.String));
            _param.Add(new SPParam("@iDType", _prmOrderSP.IDType, DbType.Byte));
            _param.Add(new SPParam("@maritalStatus", _prmOrderSP.MaritalStatus, DbType.String));
            _param.Add(new SPParam("@mobilePhoneNumber", _prmOrderSP.MobilePhoneNumber, DbType.String));
            _param.Add(new SPParam("@nationality", _prmOrderSP.Nationality, DbType.String));
            _param.Add(new SPParam("@orderID", _prmOrderSP.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSP.OrderSPMovableID, DbType.Int64));
            _param.Add(new SPParam("@placeOfBirth", _prmOrderSP.PlaceOfBirth, DbType.String));
            _param.Add(new SPParam("@spouseName", _prmOrderSP.SpouseName, DbType.String));
            _param.Add(new SPParam("@regionID", _prmOrderSP.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _prmOrderSP.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _prmOrderSP.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _prmOrderSP.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmOrderSP.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _prmOrderSP.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOrderSP.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@modifiedBy", _prmOrderSP.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOrderSP.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmOrderSP.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _prmOrderSP.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _prmOrderSP.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@jobTitle", _prmOrderSP.JobTitle, DbType.String));
            _param.Add(new SPParam("@jobType", _prmOrderSP.JobType, DbType.String));
            _param.Add(new SPParam("@businessLine", _prmOrderSP.BusinessLine, DbType.String));
            _param.Add(new SPParam("@cancelStatus", _prmOrderSP.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _prmOrderSP.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _prmOrderSP.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _prmOrderSP.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _paramDoc.Add(new SPParam("@Checklist", _prmDocumentType, DbType.String));
                _paramDoc.Add(new SPParam("@modifiedBy", _prmTrReqDocMovable.ModifiedBy, DbType.String));
                _paramDoc.Add(new SPParam("@modifiedDate", _prmTrReqDocMovable.ModifiedDate, DbType.DateTime));
                _paramDoc.Add(new SPParam("@orderSPMovableID", _prmOrderSP.OrderSPMovableID, DbType.Int64));
                _paramDoc.Add(new SPParam("@remark", _prmTrReqDocMovable.Remark, DbType.String));

                _successTrReqDocMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_UpdateTrReqDocMovable", _paramDoc, ref _paramOut, ref data);
                if (_successTrReqDocMovable)
                {
                    _result = true;
                }
            }

            return _result;
        }

        public int DeleteTrOrderSPMovable(TrOrderSPMovable _prmOrderSP)
        {
            //delete TrWorkOrderNotMovable
            int _resultWO = 0;
            object dataWO = null;
            List<SPParam> _paramWO = new List<SPParam>();

            _paramWO.Add(new SPParam("@tableName", "TrWorkOrderMovable", DbType.String));
            _paramWO.Add(new SPParam("@fieldName", "OrderSPMovableID", DbType.String));
            _paramWO.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPMovableID, DbType.Int64));
            _paramWO.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _paramWO.Add(new SPParam("@rowStatus", 1, DbType.Int32));

            List<SPParamOut> _paramOutWO = new List<SPParamOut>();
            _paramOutWO.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

            bool _successWO = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _paramWO, ref _paramOutWO, ref dataWO);
            if (_successWO)
            {
                ErrorHandler.ErrorMessage = Convert.ToString(_paramOutWO[0].Value);
                _resultWO = (int)dataWO;
            }
            
            //delete TrReqDocMovable
            int _resultDoc = 0;
            object dataDoc = null;
            List<SPParam> _paramDoc = new List<SPParam>();

            _paramDoc.Add(new SPParam("@tableName", "TrReqDocMovable", DbType.String));
            _paramDoc.Add(new SPParam("@fieldName", "OrderSPMovableID", DbType.String));
            _paramDoc.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPMovableID, DbType.Int64));
            _paramDoc.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _paramDoc.Add(new SPParam("@rowStatus", 1, DbType.Int32));

            List<SPParamOut> _paramOutDoc = new List<SPParamOut>();
            _paramOutDoc.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

            bool _successDoc = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _paramDoc, ref _paramOutDoc, ref dataDoc);
            if (_successDoc)
            {
                ErrorHandler.ErrorMessage = Convert.ToString(_paramOutDoc[0].Value);
                _resultDoc = (int)dataDoc;
            }


            // delete TrOrderSPMovable
            int _result = 0;
            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "TrOrderSPMovable", DbType.String));
            _param.Add(new SPParam("@fieldName", "OrderSPMovableID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPMovableID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", 1, DbType.Int32));

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

        #endregion

        #region SurveyPointNotMovable

        public int InsertOrderWithCorporate(String _prmDocumentType, String _prmOrderID, TrOrder _prmOrder, TrOrderSPNotMovable _prmOrderSPNotMovable, TrReqDocNotMovable _prmTrReqDocNotMovable, ref long _prmOrderIDOut)
        {
            int _result = 0;

            object data = null;
            object data2 = null;
            object data3 = null;

            List<SPParam> _param = new List<SPParam>();
            List<SPParam> _param2 = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            List<SPParamOut> _paramOut2 = new List<SPParamOut>();

            Int64 _orderID = 0;
            Int64 _orderSPMovableID = 0;

            bool _successTrOrder = false;
            bool _successOrderSPMovable = false;
            bool _successTrReqDocMovable = false;

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    if (_prmOrderID == "")
                    {
                        _param.Add(new SPParam("@customerID", _prmOrder.CustomerID, DbType.Int64));
                        _param.Add(new SPParam("@orderCode", _prmOrder.OrderCode, DbType.String));
                        _param.Add(new SPParam("@orderTypeID", _prmOrder.OrderTypeID, DbType.Int64));
                        _param.Add(new SPParam("@orderDate", _prmOrder.OrderDate, DbType.DateTime));
                        _param.Add(new SPParam("@orderVersion", _prmOrder.OrderVersion, DbType.String));
                        _param.Add(new SPParam("@orderStatus", _prmOrder.OrderStatus, DbType.Byte));
                        _param.Add(new SPParam("@proceedDate", _prmOrder.ProceedDate, DbType.DateTime));
                        _param.Add(new SPParam("@remark", _prmOrder.Remark, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));
                        _param.Add(new SPParam("@createdBy", _prmOrder.CreatedBy, DbType.String));
                        _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                        _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

                        _paramOut.Add(new SPParamOut("@orderID", null, DbType.Int32));

                        _successTrOrder = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrder", _param, ref _paramOut, ref data);

                        _orderID = Convert.ToInt64(_paramOut[0].Value);
                        _prmOrderIDOut = _orderID;
                    }
                    else
                    {
                        _param.Add(new SPParam("@orderID", _prmOrder.OrderID, DbType.Int64));
                        _param.Add(new SPParam("@customerID", _prmOrder.CustomerID, DbType.Int64));
                        _param.Add(new SPParam("@orderCode", _prmOrder.OrderCode, DbType.String));
                        _param.Add(new SPParam("@orderTypeID", _prmOrder.OrderTypeID, DbType.Int64));
                        _param.Add(new SPParam("@orderDate", _prmOrder.OrderDate, DbType.DateTime));
                        _param.Add(new SPParam("@orderVersion", _prmOrder.OrderVersion, DbType.String));
                        _param.Add(new SPParam("@orderStatus", _prmOrder.OrderStatus, DbType.Byte));
                        _param.Add(new SPParam("@proceedDate", _prmOrder.ProceedDate, DbType.DateTime));
                        _param.Add(new SPParam("@remark", _prmOrder.Remark, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));
                        _param.Add(new SPParam("@createdBy", _prmOrder.CreatedBy, DbType.String));
                        _param.Add(new SPParam("@createdDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@modifiedBy", "", DbType.String));
                        _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                        _param.Add(new SPParam("@timestamp", _prmOrder.Timestamp, DbType.Binary));
                        
                        _successTrOrder = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrder", _param, ref _paramOut, ref data);

                        _orderID = _prmOrder.OrderID;
                    }

                    _param2.Add(new SPParam("@surveyPointName", _prmOrderSPNotMovable.SurveyPointName, DbType.String));
                    _param2.Add(new SPParam("@surveyPointID", _prmOrderSPNotMovable.SurveyPointID, DbType.Int64));
                    _param2.Add(new SPParam("@businessTypeID", _prmOrderSPNotMovable.BusinessTypeID, DbType.Int64));
                    //_param2.Add(new SPParam("@businessLine", _prmOrderSPNotMovable.BusinessLine, DbType.String));
                    _param2.Add(new SPParam("@address", _prmOrderSPNotMovable.Address, DbType.String));
                    _param2.Add(new SPParam("@clue", _prmOrderSPNotMovable.Clue, DbType.String));
                    _param2.Add(new SPParam("@zipCode", _prmOrderSPNotMovable.ZipCode, DbType.String));
                    _param2.Add(new SPParam("@remark", _prmOrderSPNotMovable.Remark, DbType.String));
                    _param2.Add(new SPParam("@sPStatus", _prmOrderSPNotMovable.SPStatus, DbType.Int64));
                    _param2.Add(new SPParam("@phoneNumber", _prmOrderSPNotMovable.PhoneNumber, DbType.String));
                    _param2.Add(new SPParam("@contactNumber", _prmOrderSPNotMovable.ContactNumber, DbType.String));
                    _param2.Add(new SPParam("@extension", _prmOrderSPNotMovable.Extension, DbType.String));
                    _param2.Add(new SPParam("@regionID", _prmOrderSPNotMovable.RegionID, DbType.Int64));
                    _param2.Add(new SPParam("@originatorID", _prmOrderSPNotMovable.OriginatorID, DbType.Int64));
                    _param2.Add(new SPParam("@rowStatus", _prmOrderSPNotMovable.RowStatus, DbType.Int32));
                    _param2.Add(new SPParam("@createdBy", _prmOrderSPNotMovable.CreatedBy, DbType.String));
                    _param2.Add(new SPParam("@createdDate", _prmOrderSPNotMovable.CreatedDate, DbType.DateTime));
                    _param2.Add(new SPParam("@modifiedBy", "", DbType.String));
                    _param2.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                    _param2.Add(new SPParam("@userTakeOver", "", DbType.String));
                    _param2.Add(new SPParam("@remarkComplaint", "", DbType.String));
                    _param2.Add(new SPParam("@remarkCancel", "", DbType.String));
                    _param2.Add(new SPParam("@fgComplaint", _prmOrderSPNotMovable.FgComplaint, DbType.Boolean));
                    _param2.Add(new SPParam("@cancelStatus", _prmOrderSPNotMovable.CancelStatus, DbType.Byte));

                    _paramOut2.Add(new SPParamOut("@orderSPNotMovableID", null, DbType.Int64));

                    if (_prmOrderID == "")
                    {
                        _param2.Add(new SPParam("@orderID", _orderID, DbType.Int64));
                    }
                    else
                    {
                        _param2.Add(new SPParam("@orderID", _prmOrderID, DbType.Int32));
                    }
                    if (_prmOrderID == "")
                    {
                        if (_successTrOrder == true)
                        {
                            _successOrderSPMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrderSPNotMovable", _param2, ref _paramOut2, ref data2);
                        }
                    }
                    else
                    {
                        _successOrderSPMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrderSPNotMovable", _param2, ref _paramOut2, ref data2);

                    }
                    _orderSPMovableID = Convert.ToInt64(_paramOut2[0].Value);

                    if (_successOrderSPMovable == true)
                    {
                        if (_prmDocumentType != "")
                        {

                            string[] _split = _prmDocumentType.Split(',');
                            for (int i = 0; i < _split.Length; i++)
                            {
                                List<SPParam> _param3 = new List<SPParam>();
                                _param3.Add(new SPParam("@documentTypeID", _split[i], DbType.Int32));
                                _param3.Add(new SPParam("@orderSPNotMovableID", _orderSPMovableID, DbType.Int64));
                                _param3.Add(new SPParam("@remark", _prmTrReqDocNotMovable.Remark, DbType.String));
                                _param3.Add(new SPParam("@reqDocNotMovableID", null, DbType.Int64));
                                _param3.Add(new SPParam("@rowStatus", _prmTrReqDocNotMovable.RowStatus, DbType.Int32));
                                _param3.Add(new SPParam("@createdBy", _prmTrReqDocNotMovable.CreatedBy, DbType.String));
                                _param3.Add(new SPParam("@createdDate", _prmTrReqDocNotMovable.CreatedDate, DbType.DateTime));
                                _param3.Add(new SPParam("@modifiedBy", "", DbType.String));
                                _param3.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
                                List<SPParamOut> _paramOut3 = new List<SPParamOut>();

                                _successTrReqDocMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrReqDocNotMovable", _param3, ref _paramOut3, ref data3);
                            }
                        }
                        else
                        {
                            _result = (int)data2;
                        }
                    }

                    if (_successTrReqDocMovable == true)
                    {
                        _result = (int)data3;
                    }

                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage = ex.Message;
                }
            }
            return _result;
        }

        public TrOrderSPNotMovable GetSingleTrOrderNotMovable(Int64 _prmOrderSPID)
        {
            TrOrderSPNotMovable _result = new TrOrderSPNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMovableID", _prmOrderSPID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrOrderSPNotMovableByOrderSPNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPNotMovable _order = new TrOrderSPNotMovable();
                    _order.Address = (String)dr["Address"];
                    //_order.BusinessLine = (String)dr["BusinessLine"];
                    _order.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _order.Clue = (String)dr["Clue"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _order.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? String.Empty : (String)dr["SurveyPointName"];
                    _order.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _order.PhoneNumber = (String)dr["PhoneNumber"];
                    _order.ContactNumber = (String)dr["ContactNumber"];
                    _order.OrderSPNotMovableID = (long)dr["OrderSPNotMovableID"];
                    _order.OrderID = (long)dr["OrderID"];
                    _order.SurveyPointID = (long)dr["SurveyPointID"];
                    _order.Extension = (String)dr["Extension"];
                    _order.SPStatus = (Byte)dr["SPStatus"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _order.RegionID = (long)dr["RegionID"];
                    _order.RowStatus = (Int32)dr["RowStatus"];
                    _order.CreatedBy = (String)dr["CreatedBy"];
                    _order.CreatedDate = (DateTime)dr["CreatedDate"];
                    _order.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _order.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _order.Timestamp = (byte[])dr["Timestamp"];
                    _order.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _order.OriginatorID = (dr["OriginatorID"] == DBNull.Value) ? 0 : (long)dr["OriginatorID"];
                    _order.RemarkComplaint = (dr["RemarkComplaint"] == DBNull.Value) ? String.Empty : (String)dr["RemarkComplaint"];
                    _order.RemarkCancel = (dr["RemarkCancel"] == DBNull.Value) ? String.Empty : (String)dr["RemarkCancel"];
                    _order.FgComplaint = (dr["FgComplaint"] == DBNull.Value) ? false : (Boolean)dr["FgComplaint"];
                    _order.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];

                    _result = _order;
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrReqDocNotMovable> GetListReqDocbySPIDNotMovable(Int64 _prmOrderSPNotMovableID)
        {
            List<TrReqDocNotMovable> _result = new List<TrReqDocNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMovableID", _prmOrderSPNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();
            //_paramOut.Add(new SPParamOut("@CustID", "", DbType.String));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrReqDocNotMovableByOrderSPNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrReqDocNotMovable _order = new TrReqDocNotMovable();
                    _order.DocumentTypeID = (Int64)dr["DocumentTypeID"];
                    _order.ReqDocNotMovableID = (long)dr["ReqDocNotMovableID"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean UpdateTrOrderSPNotMovable(TrOrderSPNotMovable _prmOrderSPID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@address", _prmOrderSPID.Address, DbType.String));
            //_param.Add(new SPParam("@businessLine", _prmOrderSPID.BusinessLine, DbType.String));
            _param.Add(new SPParam("@businessTypeID", _prmOrderSPID.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@clue", _prmOrderSPID.Clue, DbType.String));
            _param.Add(new SPParam("@contactNumber", _prmOrderSPID.ContactNumber, DbType.String));
            _param.Add(new SPParam("@extension", _prmOrderSPID.Extension, DbType.String));
            _param.Add(new SPParam("@orderID", _prmOrderSPID.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPNotMovableID", _prmOrderSPID.OrderSPNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@phoneNumber", _prmOrderSPID.PhoneNumber, DbType.String));
            _param.Add(new SPParam("@regionID", _prmOrderSPID.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _prmOrderSPID.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _prmOrderSPID.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _prmOrderSPID.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmOrderSPID.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _prmOrderSPID.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOrderSPID.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmOrderSPID.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmOrderSPID.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmOrderSPID.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOrderSPID.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmOrderSPID.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _prmOrderSPID.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _prmOrderSPID.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@cancelStatus", _prmOrderSPID.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _prmOrderSPID.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _prmOrderSPID.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _prmOrderSPID.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        public Boolean UpdateTrOrderSPNotMovable(TrOrderSPNotMovable _prmOrderSPID, TrReqDocNotMovable _prmTrReqDocNotMovable, String _prmDocumentType)
        {
            Boolean _result = false;
            Boolean _successTrReqDocNotMovable = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            List<SPParam> _paramDoc = new List<SPParam>();

            _param.Add(new SPParam("@address", _prmOrderSPID.Address, DbType.String));
            //_param.Add(new SPParam("@businessLine", _prmOrderSPID.BusinessLine, DbType.String));
            _param.Add(new SPParam("@businessTypeID", _prmOrderSPID.BusinessTypeID, DbType.Int64));
            _param.Add(new SPParam("@clue", _prmOrderSPID.Clue, DbType.String));
            _param.Add(new SPParam("@contactNumber", _prmOrderSPID.ContactNumber, DbType.String));
            _param.Add(new SPParam("@extension", _prmOrderSPID.Extension, DbType.String));
            _param.Add(new SPParam("@orderID", _prmOrderSPID.OrderID, DbType.Int64));
            _param.Add(new SPParam("@orderSPNotMovableID", _prmOrderSPID.OrderSPNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@phoneNumber", _prmOrderSPID.PhoneNumber, DbType.String));
            _param.Add(new SPParam("@regionID", _prmOrderSPID.RegionID, DbType.Int64));
            _param.Add(new SPParam("@sPStatus", _prmOrderSPID.SPStatus, DbType.Byte));
            _param.Add(new SPParam("@surveyPointID", _prmOrderSPID.SurveyPointID, DbType.Int64));
            _param.Add(new SPParam("@surveyPointName", _prmOrderSPID.SurveyPointName, DbType.String));
            _param.Add(new SPParam("@zipCode", _prmOrderSPID.ZipCode, DbType.String));
            _param.Add(new SPParam("@remark", _prmOrderSPID.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmOrderSPID.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmOrderSPID.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmOrderSPID.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmOrderSPID.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOrderSPID.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmOrderSPID.Timestamp, DbType.Binary));
            _param.Add(new SPParam("@userTakeOver", _prmOrderSPID.UserTakeOver, DbType.String));
            _param.Add(new SPParam("@originatorID", _prmOrderSPID.OriginatorID, DbType.Int64));
            _param.Add(new SPParam("@cancelStatus", _prmOrderSPID.CancelStatus, DbType.Byte));
            _param.Add(new SPParam("@remarkCancel", _prmOrderSPID.RemarkCancel, DbType.String));
            _param.Add(new SPParam("@remarkComplaint", _prmOrderSPID.RemarkComplaint, DbType.String));
            _param.Add(new SPParam("@fgComplaint", _prmOrderSPID.FgComplaint, DbType.Boolean));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrderSPNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _paramDoc.Add(new SPParam("@Checklist", _prmDocumentType, DbType.String));
                _paramDoc.Add(new SPParam("@modifiedBy", _prmTrReqDocNotMovable.ModifiedBy, DbType.String));
                _paramDoc.Add(new SPParam("@modifiedDate", _prmTrReqDocNotMovable.ModifiedDate, DbType.DateTime));
                _paramDoc.Add(new SPParam("@orderSPNotMovableID", _prmOrderSPID.OrderSPNotMovableID, DbType.Int64));
                _paramDoc.Add(new SPParam("@remark", _prmTrReqDocNotMovable.Remark, DbType.String));

                _successTrReqDocNotMovable = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_UpdateTrReqDocNotMovable", _paramDoc, ref _paramOut, ref data);
                if (_successTrReqDocNotMovable)
                {
                    _result = true;
                }
            }
            return _result;
        }

        public int DeleteTrOrderSPNotMovable(TrOrderSPNotMovable _prmOrderSP)
        {
            //delete TrWorkOrderNotNotMovable
            int _resultWO = 0;
            object dataWO = null;
            List<SPParam> _paramWO = new List<SPParam>();

            _paramWO.Add(new SPParam("@tableName", "TrWorkOrderNotMovable", DbType.String));
            _paramWO.Add(new SPParam("@fieldName", "OrderSPNotMovableID", DbType.String));
            _paramWO.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPNotMovableID, DbType.Int64));
            _paramWO.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _paramWO.Add(new SPParam("@rowStatus", 1, DbType.Int32));

            List<SPParamOut> _paramOutWO = new List<SPParamOut>();
            _paramOutWO.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

            bool _successWO = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _paramWO, ref _paramOutWO, ref dataWO);
            if (_successWO)
            {
                ErrorHandler.ErrorMessage = Convert.ToString(_paramOutWO[0].Value);
                _resultWO = (int)dataWO;
            }

            //delete TrReqDocNotMovable
            int _resultDoc = 0;
            object dataDoc = null;
            List<SPParam> _paramDoc = new List<SPParam>();

            _paramDoc.Add(new SPParam("@tableName", "TrReqDocNotMovable", DbType.String));
            _paramDoc.Add(new SPParam("@fieldName", "OrderSPNotMovableID", DbType.String));
            _paramDoc.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPNotMovableID, DbType.Int64));
            _paramDoc.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _paramDoc.Add(new SPParam("@rowStatus", 1, DbType.Int32));

            List<SPParamOut> _paramOutDoc = new List<SPParamOut>();
            _paramOutDoc.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

            bool _successDoc = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _paramDoc, ref _paramOutDoc, ref dataDoc);
            if (_successDoc)
            {
                ErrorHandler.ErrorMessage = Convert.ToString(_paramOutDoc[0].Value);
                _resultDoc = (int)dataDoc;
            }

            // delete TrOrderSPNotMovable
            int _result = 0;
            object data = null;
            List<SPParam> _param = new List<SPParam>();

            _param.Add(new SPParam("@tableName", "TrOrderSPNotMovable", DbType.String));
            _param.Add(new SPParam("@fieldName", "OrderSPNotMovableID", DbType.String));
            _param.Add(new SPParam("@fieldValue", _prmOrderSP.OrderSPNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@userName", _prmOrderSP.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@rowStatus", 1, DbType.Int32));

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

        #endregion

        ~OrderSurveyPointBL()
        {
        }

    }
}
