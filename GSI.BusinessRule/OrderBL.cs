using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using System.Transactions;
using System.Configuration;

namespace GSI.BusinessRule
{
    public class OrderBL : Base
    {
        private ResultBL _resultBL = new ResultBL();

        private OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

        public OrderBL()
        {
        }

        #region Order

        public int GetRowCountOrder()
        {
            int _result = 0;

            object data = null;
            List<SPParam> _param = new List<SPParam>();


            List<SPParamOut> _paramOut = new List<SPParamOut>();
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "GetCountTrOrder", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = (int)data;
            }

            return _result;
        }

        public List<TrOrder> GetListOrder()
        {
            List<TrOrder> _result = new List<TrOrder>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetAllFromTrOrder", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrder _order = new TrOrder();
                    _order.OrderID = (long)dr["OrderID"];
                    _order.CustomerID = (long)dr["CustomerID"];
                    _order.OrderCode = (String)dr["OrderCode"];
                    _order.OrderTypeID = (long)dr["OrderTypeID"];
                    _order.OrderDate = (DateTime)dr["OrderDate"];
                    _order.OrderVersion = (Byte)dr["OrderVersion"];
                    _order.OrderStatus = (Byte)dr["OrderStatus"];
                    _order.ProceedDate = (dr["ProceedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ProceedDate"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrOrder> GetListOrderbyCustomerID(Int64 _prmCustID, Int32 _prmRow)
        {
            List<TrOrder> _result = new List<TrOrder>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustID, DbType.Int64));
            _param.Add(new SPParam("@rowStatus", _prmRow, DbType.Int32));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrOrderByCustomerID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrder _order = new TrOrder();
                    _order.OrderID = (long)dr["OrderID"];
                    _order.CustomerID = (long)dr["CustomerID"];
                    _order.OrderCode = (String)dr["OrderCode"];
                    _order.OrderTypeID = (long)dr["OrderTypeID"];
                    _order.OrderDate = (DateTime)dr["OrderDate"];
                    _order.OrderVersion = (Byte)dr["OrderVersion"];
                    _order.OrderStatus = (Byte)dr["OrderStatus"];
                    _order.ProceedDate = (dr["ProceedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ProceedDate"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrOrder> GetListOrderStatus(Int64 _prmCustID, String _prmOrderCode, Int64 _prmOrderTypeID, Int16 _prmOrderStatus, Int16 _prmOrderDocStatus, DateTime _prmOrderStartDate, DateTime _prmOrderEndDate, Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<TrOrder> _result = new List<TrOrder>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@customerID", _prmCustID, DbType.Int64));
            _param.Add(new SPParam("@orderCode", _prmOrderCode, DbType.String));
            _param.Add(new SPParam("@orderTypeID", _prmOrderTypeID, DbType.Int64));
            _param.Add(new SPParam("@orderStatus", _prmOrderStatus, DbType.Int16));
            _param.Add(new SPParam("@orderDocStatus", _prmOrderDocStatus, DbType.Int16));
            _param.Add(new SPParam("@orderStartDate", _prmOrderStartDate, DbType.DateTime));
            _param.Add(new SPParam("@orderEndDate", _prmOrderEndDate, DbType.DateTime));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_Search_TrOrder", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrder _order = new TrOrder();
                    _order.OrderID = (long)dr["OrderID"];
                    _order.CustomerID = (long)dr["CustomerID"];
                    _order.OrderCode = (String)dr["OrderCode"];
                    _order.OrderTypeID = (long)dr["OrderTypeID"];
                    _order.OrderDate = (DateTime)dr["OrderDate"];
                    _order.OrderVersion = (Byte)dr["OrderVersion"];
                    _order.OrderStatus = (Byte)dr["OrderStatus"];
                    _order.ProceedDate = (dr["ProceedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ProceedDate"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _result.Add(_order);
                    RequestVariable.RowCount = (Int32)dr["CountTrOrder"];
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean IsOrderSurveyPointAllComplete(Int64 _prmOrderID)
        {
            Boolean _result = true;

            OrderBL _orderBL = new OrderBL();
            List<OrderDetail> _orderDetail = _orderBL.GetListSPByOrderID(_prmOrderID);
            foreach (var _item in _orderDetail)
            {
                if (_item.SurveyPointStatus != StatusMapper.GetStatusInternal(GSIInternalStatus.Published))
                {
                    _result = false;
                }
                if (_item.SurveyPointStatus == StatusMapper.GetStatusInternal(GSIInternalStatus.Cancelled))
                {
                    _result = false;
                    break;
                }
            }

            return _result;
        }

        public TrOrder GetSingleOrderByOrderID(Int64 _prmOrderID)
        {
            TrOrder _result = new TrOrder();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderID", _prmOrderID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrOrderByOrderID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrOrder _order = new TrOrder();
                    _order.OrderID = (long)dr["OrderID"];
                    _order.CustomerID = (long)dr["CustomerID"];
                    _order.OrderCode = (String)dr["OrderCode"];
                    _order.OrderTypeID = (long)dr["OrderTypeID"];
                    _order.OrderDate = (DateTime)dr["OrderDate"];
                    _order.OrderVersion = (Byte)dr["OrderVersion"];
                    _order.OrderStatus = (Byte)dr["OrderStatus"];
                    _order.ProceedDate = (dr["ProceedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ProceedDate"];
                    _order.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _order.RowStatus = (int)dr["RowStatus"];
                    _order.CreatedBy = (String)dr["CreatedBy"];
                    _order.CreatedDate = (DateTime)dr["CreatedDate"];
                    _order.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _order.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _order.Timestamp = (byte[])dr["Timestamp"];
                    _result = _order;
                }
                dr.Close();
            }

            return _result;
        }

        public Boolean InsertOrder(TrOrder _prmOrder)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
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

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@OrderID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrOrder", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        public Boolean UpdateOrder(TrOrder _prmOrder)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
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
            _param.Add(new SPParam("@createdDate", _prmOrder.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmOrder.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmOrder.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmOrder.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrOrder", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }

        public int DeletedOrder(TrOrder _prmOrder)
        {
            int _result = 0;
            int _resultTrOrder = 0;
            ErrorHandler.ErrorMessage = "";

            //Movable
            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    List<TrOrderSPMovable> _prmTrOrderSPMovable = this.GetListTrOrderSPMovableByOrderId(_prmOrder.OrderID);

                    foreach (var _item in _prmTrOrderSPMovable)
                    {
                        object data = null;
                        List<SPParam> _param = new List<SPParam>();
                        _param.Add(new SPParam("@tableName", "TrReqDocMovable", DbType.String));
                        _param.Add(new SPParam("@fieldName", "OrderSPMovableID", DbType.String));
                        _param.Add(new SPParam("@fieldValue", _item.OrderSPMovableID, DbType.Int64));
                        _param.Add(new SPParam("@userName", _prmOrder.ModifiedBy, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));

                        List<SPParamOut> _paramOut = new List<SPParamOut>();
                        _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                        bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
                        if (_success)
                        {
                            ErrorHandler.ErrorMessage = ErrorHandler.ErrorMessage + Convert.ToString(_paramOut[0].Value);
                        }
                    }

                    foreach (var _item in _prmTrOrderSPMovable)
                    {
                        object data = null;
                        List<SPParam> _param = new List<SPParam>();
                        _param.Add(new SPParam("@tableName", "TrOrderSPMovable", DbType.String));
                        _param.Add(new SPParam("@fieldName", "OrderID", DbType.String));
                        _param.Add(new SPParam("@fieldValue", _item.OrderID, DbType.Int64));
                        _param.Add(new SPParam("@userName", _prmOrder.ModifiedBy, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));

                        List<SPParamOut> _paramOut = new List<SPParamOut>();
                        _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                        bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
                        if (_success)
                        {
                            ErrorHandler.ErrorMessage = ErrorHandler.ErrorMessage + Convert.ToString(_paramOut[0].Value);
                        }
                    }

                    //NotMovable
                    List<TrOrderSPNotMovable> _prmTrOrderSPNotMovable = this.GetListTrOrderSPNotMovableByOrderId(_prmOrder.OrderID);

                    foreach (var _item in _prmTrOrderSPNotMovable)
                    {
                        object data = null;
                        List<SPParam> _param = new List<SPParam>();
                        _param.Add(new SPParam("@tableName", "TrReqDocNotMovable", DbType.String));
                        _param.Add(new SPParam("@fieldName", "OrderSPNotMovableID", DbType.String));
                        _param.Add(new SPParam("@fieldValue", _item.OrderSPNotMovableID, DbType.Int64));
                        _param.Add(new SPParam("@userName", _prmOrder.ModifiedBy, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));

                        List<SPParamOut> _paramOut = new List<SPParamOut>();
                        _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                        bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
                        if (_success)
                        {
                            ErrorHandler.ErrorMessage = ErrorHandler.ErrorMessage + Convert.ToString(_paramOut[0].Value);
                        }
                    }

                    foreach (var _item in _prmTrOrderSPNotMovable)
                    {
                        object data = null;
                        List<SPParam> _param = new List<SPParam>();
                        _param.Add(new SPParam("@tableName", "TrOrderSPNotMovable", DbType.String));
                        _param.Add(new SPParam("@fieldName", "OrderID", DbType.String));
                        _param.Add(new SPParam("@fieldValue", _item.OrderID, DbType.Int64));
                        _param.Add(new SPParam("@userName", _prmOrder.ModifiedBy, DbType.String));
                        _param.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));

                        List<SPParamOut> _paramOut = new List<SPParamOut>();
                        _paramOut.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                        bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param, ref _paramOut, ref data);
                        if (_success)
                        {
                            ErrorHandler.ErrorMessage = ErrorHandler.ErrorMessage + Convert.ToString(_paramOut[0].Value);
                        }
                    }

                    //Order
                    object data2 = null;
                    List<SPParam> _param2 = new List<SPParam>();
                    _param2.Add(new SPParam("@tableName", "TrOrder", DbType.String));
                    _param2.Add(new SPParam("@fieldName", "OrderID", DbType.String));
                    _param2.Add(new SPParam("@fieldValue", _prmOrder.OrderID, DbType.Int64));
                    _param2.Add(new SPParam("@userName", _prmOrder.ModifiedBy, DbType.String));
                    _param2.Add(new SPParam("@rowStatus", _prmOrder.RowStatus, DbType.Int32));

                    List<SPParamOut> _paramOut2 = new List<SPParamOut>();
                    _paramOut2.Add(new SPParamOut("@tableChildDescription", String.Empty, DbType.String));

                    bool _success2 = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "sp_DeleteGSITable", _param2, ref _paramOut2, ref data2);
                    if (_success2)
                    {
                        ErrorHandler.ErrorMessage = ErrorHandler.ErrorMessage + Convert.ToString(_paramOut2[0].Value);
                        _resultTrOrder = (int)data2;
                    }

                    if (_resultTrOrder != 0 && ErrorHandler.ErrorMessage == "")
                    {
                        _result = 1;
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

        public List<OrderDetail> GetListSPByOrderID(Int64 _prmOrderID)
        {
            List<OrderDetail> _result = new List<OrderDetail>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderID", _prmOrderID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListSPByOrderID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    OrderDetail _order = new OrderDetail();
                    _order.OrderSPID = (long)dr["OrderSPID"];
                    _order.OrderID = (long)dr["OrderID"];
                    _order.SurveyPointID = (long)dr["SPID"];
                    _order.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _order.SurveyPointStatus = (Byte)dr["SPStatus"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        public List<Mapper_OrderType_PointSurveybySurveyPoint> GetListSurveyPoinPersonal(long _prmOrderTypeID)
        {
            List<Mapper_OrderType_PointSurveybySurveyPoint> _result = new List<Mapper_OrderType_PointSurveybySurveyPoint>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@prmOrderTypeID", _prmOrderTypeID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetAllFromMapper_OrderType_PointSurveybyOrderType", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    Mapper_OrderType_PointSurveybySurveyPoint _order = new Mapper_OrderType_PointSurveybySurveyPoint();
                    _order.PointSurveyIDMapper = (long)dr["PointSurveyID"];
                    _order.PointSurveyNameMapper = (String)dr["PointSurveyName"];
                    _order.TemplateFormMapper = (Int32)dr["TemplateForm"];

                    _result.Add(_order);
                }
                dr.Close();
            }

            return _result;
        }

        #endregion

        ~OrderBL()
        {
        }

        #region Order Confirmation

        public List<TrOrderSPMovable> GetListTrOrderSPMovableByOrderId(Int64 _prmOrderID)
        {
            List<TrOrderSPMovable> _result = new List<TrOrderSPMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderID", _prmOrderID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrOrderSPMovableByOrderId", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPMovable _trOrderSPMovable = new TrOrderSPMovable();
                    _trOrderSPMovable.HomeAddress = (dr["HomeAddress"] == DBNull.Value) ? String.Empty : (String)dr["HomeAddress"];
                    _trOrderSPMovable.IDAddress = (dr["IDAddress"] == DBNull.Value) ? String.Empty : (String)dr["IDAddress"];
                    _trOrderSPMovable.DateOfBirth = (dr["DateOfBirth"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["DateOfBirth"];
                    _trOrderSPMovable.IDNo = (String)dr["IDNo"];
                    _trOrderSPMovable.IDType = (Byte)dr["IDType"];
                    _trOrderSPMovable.MaritalStatus = (dr["MaritalStatus"] == DBNull.Value) ? String.Empty : (String)dr["MaritalStatus"];
                    _trOrderSPMovable.Nationality = (dr["Nationality"] == DBNull.Value) ? String.Empty : (String)dr["Nationality"];
                    _trOrderSPMovable.PlaceOfBirth = (dr["PlaceOfBirth"] == DBNull.Value) ? String.Empty : (String)dr["PlaceOfBirth"];
                    _trOrderSPMovable.SurveyPointID = (Int64)dr["SurveyPointID"];
                    _trOrderSPMovable.Clue = (dr["Clue"] == DBNull.Value) ? String.Empty : (String)dr["Clue"];
                    _trOrderSPMovable.OrderID = (long)dr["OrderID"];
                    _trOrderSPMovable.OrderSPMovableID = (long)dr["OrderSPMovableID"];
                    _trOrderSPMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trOrderSPMovable.SpouseName = (dr["SpouseName"] == DBNull.Value) ? String.Empty : (String)dr["SpouseName"];
                    _trOrderSPMovable.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _trOrderSPMovable.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _trOrderSPMovable.MobilePhoneNumber = (dr["MobilePhoneNumber"] == DBNull.Value) ? String.Empty : (String)dr["MobilePhoneNumber"];
                    _trOrderSPMovable.HomePhoneNumber = (dr["HomePhoneNumber"] == DBNull.Value) ? String.Empty : (String)dr["HomePhoneNumber"];
                    _trOrderSPMovable.RegionID = (long)dr["RegionID"];
                    _trOrderSPMovable.Extension = (dr["Extension"] == DBNull.Value) ? String.Empty : (String)dr["Extension"];
                    _trOrderSPMovable.SPStatus = (Byte)dr["SPStatus"];
                    _trOrderSPMovable.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _trOrderSPMovable.RowStatus = (int)dr["RowStatus"];
                    _trOrderSPMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trOrderSPMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trOrderSPMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trOrderSPMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trOrderSPMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trOrderSPMovable.Timestamp = (byte[])dr["Timestamp"];
                    _trOrderSPMovable.OriginatorID = (dr["OriginatorID"] == DBNull.Value) ? 0 : (Int64)dr["OriginatorID"];
                    _trOrderSPMovable.JobTitle = (dr["JobTitle"] == DBNull.Value) ? String.Empty : (String)dr["JobTitle"];
                    _trOrderSPMovable.JobType = (dr["JobType"] == DBNull.Value) ? String.Empty : (String)dr["JobType"];
                    _trOrderSPMovable.BusinessLine = (dr["BusinessLine"] == DBNull.Value) ? String.Empty : (String)dr["BusinessLine"];
                    _trOrderSPMovable.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];

                    _result.Add(_trOrderSPMovable);
                }
                dr.Close();
            }
            return _result;
        }

        public List<TrReqDocMovable> GetListReqDocMovableByOrderSPMovableID(Int64 _prmOrderSPMovableID)
        {
            List<TrReqDocMovable> _result = new List<TrReqDocMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderSPMovableID", _prmOrderSPMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrReqDocMovableByOrderSPMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrReqDocMovable _trReqDocMovable = new TrReqDocMovable();
                    _trReqDocMovable.ReqDocMovableID = (long)dr["ReqDocMovableID"];
                    _trReqDocMovable.DocumentTypeID = (long)dr["DocumentTypeID"];
                    _trReqDocMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _trReqDocMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trReqDocMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trReqDocMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trReqDocMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trReqDocMovable.OrderSPMovableID = (long)dr["OrderSPMovableID"];
                    _trReqDocMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trReqDocMovable.Timestamp = (byte[])dr["Timestamp"];
                    _result.Add(_trReqDocMovable);
                }
                dr.Close();
            }
            return _result;
        }

        public List<TrOrderSPNotMovable> GetListTrOrderSPNotMovableByOrderId(Int64 _prmOrderID)
        {
            List<TrOrderSPNotMovable> _result = new List<TrOrderSPNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@orderID", _prmOrderID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrOrderSPNotMovableByOrderID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrOrderSPNotMovable _trOrderSPNotMovable = new TrOrderSPNotMovable();

                    _trOrderSPNotMovable.Address = (dr["Address"] == DBNull.Value) ? String.Empty : (String)dr["Address"];
                    //_trOrderSPNotMovable.BusinessLine = (dr["BusinessLine"] == DBNull.Value) ? String.Empty : (String)dr["BusinessLine"];
                    _trOrderSPNotMovable.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _trOrderSPNotMovable.Clue = (dr["Clue"] == DBNull.Value) ? String.Empty : (String)dr["Clue"];
                    _trOrderSPNotMovable.OrderID = (long)dr["OrderID"];
                    _trOrderSPNotMovable.OrderSPNotMovableID = (long)dr["OrderSPNotMovableID"];
                    _trOrderSPNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trOrderSPNotMovable.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _trOrderSPNotMovable.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _trOrderSPNotMovable.SurveyPointID = (long)dr["SurveyPointID"];
                    _trOrderSPNotMovable.ContactNumber = (dr["ContactNumber"] == DBNull.Value) ? String.Empty : (String)dr["ContactNumber"];
                    _trOrderSPNotMovable.Extension = (dr["Extension"] == DBNull.Value) ? String.Empty : (String)dr["Extension"];
                    _trOrderSPNotMovable.PhoneNumber = (dr["PhoneNumber"] == DBNull.Value) ? String.Empty : (String)dr["PhoneNumber"];
                    _trOrderSPNotMovable.RegionID = (long)dr["RegionID"];
                    _trOrderSPNotMovable.SPStatus = (Byte)dr["SPStatus"];
                    _trOrderSPNotMovable.UserTakeOver = (dr["UserTakeOver"] == DBNull.Value) ? String.Empty : (String)dr["UserTakeOver"];
                    _trOrderSPNotMovable.RowStatus = (int)dr["RowStatus"];
                    _trOrderSPNotMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trOrderSPNotMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trOrderSPNotMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trOrderSPNotMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trOrderSPNotMovable.Timestamp = (byte[])dr["Timestamp"];
                    _trOrderSPNotMovable.OriginatorID = (dr["OriginatorID"] == DBNull.Value) ? 0 : (Int64)dr["OriginatorID"];
                    _trOrderSPNotMovable.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];

                    _result.Add(_trOrderSPNotMovable);
                }
                dr.Close();
            }
            return _result;
        }

        public List<TrReqDocNotMovable> GetListReqDocNotMovableByOrderSPnotMovableID(Int64 _prmOrderSPMovableID)
        {
            List<TrReqDocNotMovable> _result = new List<TrReqDocNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMovableID", _prmOrderSPMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrReqDocNotMovableByOrderSPNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrReqDocNotMovable _trReqDocNotMovable = new TrReqDocNotMovable();
                    _trReqDocNotMovable.ReqDocNotMovableID = (long)dr["ReqDocNotMovableID"];
                    _trReqDocNotMovable.DocumentTypeID = (long)dr["DocumentTypeID"];
                    _trReqDocNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _trReqDocNotMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trReqDocNotMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trReqDocNotMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trReqDocNotMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trReqDocNotMovable.OrderSPNotMovableID = (long)dr["OrderSPNotMovableID"];
                    _trReqDocNotMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trReqDocNotMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_trReqDocNotMovable);
                }
                dr.Close();
            }
            return _result;
        }

        public String SendToCoreSystem(Int64 _prmOrderID, String _prmUserName)
        {
            String _result = "";

            WCFCoreServiceReference.ServiceClient _client = new WCFCoreServiceReference.ServiceClient();

            TrOrder _trOrder = this.GetSingleOrderByOrderID(_prmOrderID);

            _trOrder.OrderVersion = OrderVersionMapper.GetOrderVersion(OrderVersion.Final);
            _trOrder.OrderStatus = StatusMapper.GetStatusEksternal(GSIEksternalStatus.Submitted);
            _trOrder.ProceedDate = DateTime.Now;

            WCFCoreServiceReference.TrOrder _order = new WCFCoreServiceReference.TrOrder();
            _order.OrderID = _trOrder.OrderID;
            _order.OrderTypeID = _trOrder.OrderTypeID;
            _order.OrderCode = _trOrder.OrderCode;
            _order.OrderDate = _trOrder.OrderDate;
            _order.CustomerID = _trOrder.CustomerID;
            _order.OrderVersion = _trOrder.OrderVersion;
            _order.OrderStatus = _trOrder.OrderStatus;
            _order.ProceedDate = DateTime.Now;
            _order.Remark = _trOrder.Remark;
            _order.RowStatus = _trOrder.RowStatus;
            _order.CreatedBy = _prmUserName;
            _order.CreatedDate = DateTime.Now;
            _order.ModifiedBy = _trOrder.ModifiedBy;
            _order.ModifiedDate = _trOrder.ModifiedDate;
            _order.Timestamp = _trOrder.Timestamp;

            //movable
            List<TrOrderSPMovable> _trOrderMovable = this.GetListTrOrderSPMovableByOrderId(_prmOrderID);
            List<TrReqDocMovable> _trReqDocMovable = new List<TrReqDocMovable>();
            List<TrOrderSPNotMovable> _trOrderNotMovable = this.GetListTrOrderSPNotMovableByOrderId(_prmOrderID);
            List<TrReqDocNotMovable> _trReqDocNotMovable = new List<TrReqDocNotMovable>();
            List<WCFCoreServiceReference.TrOrderSPMovable> _orderSPMovable = new List<WCFCoreServiceReference.TrOrderSPMovable>();
            List<WCFCoreServiceReference.TrReqDocMovable> _orderSPMovableDoc = new List<WCFCoreServiceReference.TrReqDocMovable>();
            List<WCFCoreServiceReference.TrOrderSPNotMovable> _orderSPNotMovable = new List<WCFCoreServiceReference.TrOrderSPNotMovable>();
            List<WCFCoreServiceReference.TrReqDocNotMovable> _orderSPNotMovableDoc = new List<WCFCoreServiceReference.TrReqDocNotMovable>();

            foreach (var _dt in _trOrderMovable)
            {
                _dt.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);

                WCFCoreServiceReference.TrOrderSPMovable _wcfDt = new WCFCoreServiceReference.TrOrderSPMovable();
                _wcfDt.OrderSPMovableID = _dt.OrderSPMovableID;
                _wcfDt.OrderID = _dt.OrderID;
                _wcfDt.Clue = _dt.Clue;
                _wcfDt.DateOfBirth = _dt.DateOfBirth;
                _wcfDt.Extension = _dt.Extension;
                _wcfDt.HomeAddress = _dt.HomeAddress;
                _wcfDt.HomePhoneNumber = _dt.HomePhoneNumber;
                _wcfDt.IDAddress = _dt.IDAddress;
                _wcfDt.IDNo = _dt.IDNo;
                _wcfDt.IDType = _dt.IDType;
                _wcfDt.MaritalStatus = _dt.MaritalStatus;
                _wcfDt.MobilePhoneNumber = _dt.MobilePhoneNumber;
                _wcfDt.Nationality = _dt.Nationality;
                _wcfDt.PlaceOfBirth = _dt.PlaceOfBirth;
                _wcfDt.RegionID = _dt.RegionID;
                _wcfDt.UserTakeOver = _dt.UserTakeOver;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.SpouseName = _dt.SpouseName;
                _wcfDt.SPStatus = _dt.SPStatus;
                _wcfDt.SurveyPointID = _dt.SurveyPointID;
                _wcfDt.SurveyPointName = _dt.SurveyPointName;
                _wcfDt.ZipCode = _dt.ZipCode;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.CreatedBy = _prmUserName;
                _wcfDt.CreatedDate = DateTime.Now;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                _wcfDt.Timestamp = _dt.Timestamp;
                _wcfDt.OriginatorID = _dt.OriginatorID;
                _wcfDt.JobTitle = _dt.JobTitle;
                _wcfDt.JobType = _dt.JobType;
                _wcfDt.BusinessLine = _dt.BusinessLine;
                _wcfDt.CancelStatus = _dt.CancelStatus;
                _wcfDt.RemarkCancel = _dt.RemarkCancel;
                _wcfDt.RemarkComplaint = _dt.RemarkComplaint;
                _wcfDt.FgComplaint = _dt.FgComplaint;

                _orderSPMovable.Add(_wcfDt);

                List<TrReqDocMovable> _detail = this.GetListReqDocMovableByOrderSPMovableID(_dt.OrderSPMovableID);
                foreach (var _doc in _detail)
                {
                    WCFCoreServiceReference.TrReqDocMovable _wcfDtDoc = new WCFCoreServiceReference.TrReqDocMovable();
                    _wcfDtDoc.DocumentTypeID = _doc.DocumentTypeID;
                    _wcfDtDoc.OrderSPMovableID = _doc.OrderSPMovableID;
                    _wcfDtDoc.Remark = _doc.Remark;
                    _wcfDtDoc.ReqDocMovableID = _doc.ReqDocMovableID;
                    _wcfDtDoc.RowStatus = _doc.RowStatus;
                    _wcfDtDoc.CreatedBy = _prmUserName;
                    _wcfDtDoc.CreatedDate = DateTime.Now;
                    _wcfDtDoc.ModifiedBy = _doc.ModifiedBy;
                    _wcfDtDoc.ModifiedDate = _doc.ModifiedDate;
                    _wcfDtDoc.Timestamp = _doc.Timestamp;
                    _orderSPMovableDoc.Add(_wcfDtDoc);
                }
            }

            //not movable
            foreach (var _dt in _trOrderNotMovable)
            {
                _dt.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);

                WCFCoreServiceReference.TrOrderSPNotMovable _wcfDt = new WCFCoreServiceReference.TrOrderSPNotMovable();
                _wcfDt.Address = _dt.Address;
                //_wcfDt.BusinessLine = _dt.BusinessLine;
                _wcfDt.BusinessTypeID = _dt.BusinessTypeID;
                _wcfDt.Clue = _dt.Clue;
                _wcfDt.ContactNumber = _dt.ContactNumber;
                _wcfDt.Extension = _dt.Extension;
                _wcfDt.OrderID = _dt.OrderID;
                _wcfDt.OrderSPNotMovableID = _dt.OrderSPNotMovableID;
                _wcfDt.PhoneNumber = _dt.PhoneNumber;
                _wcfDt.RegionID = _dt.RegionID;
                _wcfDt.UserTakeOver = _dt.UserTakeOver;
                _wcfDt.ZipCode = _dt.ZipCode;
                _wcfDt.Remark = _dt.Remark;
                _wcfDt.RowStatus = _dt.RowStatus;
                _wcfDt.SPStatus = _dt.SPStatus;
                _wcfDt.SurveyPointID = _dt.SurveyPointID;
                _wcfDt.SurveyPointName = _dt.SurveyPointName;
                _wcfDt.CreatedBy = _prmUserName;
                _wcfDt.CreatedDate = DateTime.Now;
                _wcfDt.ModifiedBy = _dt.ModifiedBy;
                _wcfDt.ModifiedDate = _dt.ModifiedDate;
                _wcfDt.Timestamp = _dt.Timestamp;
                _wcfDt.OriginatorID = _dt.OriginatorID;
                _wcfDt.CancelStatus = _dt.CancelStatus;
                _wcfDt.RemarkCancel = _dt.RemarkCancel;
                _wcfDt.RemarkComplaint = _dt.RemarkComplaint;
                _wcfDt.FgComplaint = _dt.FgComplaint;

                _orderSPNotMovable.Add(_wcfDt);

                List<TrReqDocNotMovable> _detail = this.GetListReqDocNotMovableByOrderSPnotMovableID(_dt.OrderSPNotMovableID);
                foreach (var _doc in _detail)
                {
                    WCFCoreServiceReference.TrReqDocNotMovable _wcfDtDoc = new WCFCoreServiceReference.TrReqDocNotMovable();
                    _wcfDtDoc.DocumentTypeID = _doc.DocumentTypeID;
                    _wcfDtDoc.OrderSPNotMovableID = _doc.OrderSPNotMovableID;
                    _wcfDtDoc.Remark = _doc.Remark;
                    _wcfDtDoc.ReqDocNotMovableID = _doc.ReqDocNotMovableID;
                    _wcfDtDoc.RowStatus = _doc.RowStatus;
                    _wcfDtDoc.CreatedBy = _prmUserName;
                    _wcfDtDoc.CreatedDate = DateTime.Now;
                    _wcfDtDoc.ModifiedBy = _doc.ModifiedBy;
                    _wcfDtDoc.ModifiedDate = _doc.ModifiedDate;
                    _wcfDtDoc.Timestamp = _doc.Timestamp;
                    _orderSPNotMovableDoc.Add(_wcfDtDoc);
                }
            }

            String _errMessage = "";

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    ////_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    ////_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);
                    //System.Net.NetworkCredential _ncre = new System.Net.NetworkCredential();
                    //_ncre.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    //_ncre.Password = (ConfigurationManager.AppSettings["Password"]);
                    //_client.ClientCredentials.Windows.ClientCredential.UserName = _ncre.UserName;
                    //_client.ClientCredentials.Windows.ClientCredential.Password = _ncre.Password;

                    _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    Boolean _transfer = _client.UpdateToCoreSystem(_order, _orderSPMovable.ToArray(), _orderSPNotMovable.ToArray(), _orderSPMovableDoc.ToArray(), _orderSPNotMovableDoc.ToArray(), ref _errMessage);
                    _client.Close();

                    if (_transfer)
                    {
                        OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

                        Boolean _uptResult = this.UpdateOrder(_trOrder);
                        if (_uptResult)
                        {
                            foreach (var _spMov in _trOrderMovable)
                            {
                                _spMov.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
                                _orderSPBL.UpdateTrOrderSPMovable(_spMov);
                            }

                            foreach (var _spNotMov in _trOrderNotMovable)
                            {
                                _spNotMov.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
                                _orderSPBL.UpdateTrOrderSPNotMovable(_spNotMov);
                            }
                        }
                    }
                    else
                    {
                        if (_errMessage != "") ErrorHandler.ErrorMessage += " " + _errMessage;
                    }

                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage += " " + ex.Message;
                }
            }
            return _result;
        }

        public String CompalintOrderSPNotMovable(Int64 _prmOrderSPNotMovableID, String _prmUserName, String _prmRemark)
        {
            String _result = "";

            WCFCoreServiceReference.ServiceClient _client = new WCFCoreServiceReference.ServiceClient();

            TrOrderSPNotMovable _trOrderNotMovable = this._orderSPBL.GetSingleTrOrderNotMovable(_prmOrderSPNotMovableID);
            WCFCoreServiceReference.TrOrderSPNotMovable _orderSPNotMovable = new WCFCoreServiceReference.TrOrderSPNotMovable();

            _trOrderNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
            _trOrderNotMovable.FgComplaint = true;

            _orderSPNotMovable.Address = _trOrderNotMovable.Address;
            //_orderSPNotMovable.BusinessLine = _dt.BusinessLine;
            _orderSPNotMovable.BusinessTypeID = _trOrderNotMovable.BusinessTypeID;
            _orderSPNotMovable.Clue = _trOrderNotMovable.Clue;
            _orderSPNotMovable.ContactNumber = _trOrderNotMovable.ContactNumber;
            _orderSPNotMovable.Extension = _trOrderNotMovable.Extension;
            _orderSPNotMovable.OrderID = _trOrderNotMovable.OrderID;
            _orderSPNotMovable.OrderSPNotMovableID = _trOrderNotMovable.OrderSPNotMovableID;
            _orderSPNotMovable.PhoneNumber = _trOrderNotMovable.PhoneNumber;
            _orderSPNotMovable.RegionID = _trOrderNotMovable.RegionID;
            _orderSPNotMovable.UserTakeOver = _trOrderNotMovable.UserTakeOver;
            _orderSPNotMovable.ZipCode = _trOrderNotMovable.ZipCode;
            _orderSPNotMovable.Remark = _trOrderNotMovable.Remark;
            _orderSPNotMovable.RowStatus = _trOrderNotMovable.RowStatus;
            _orderSPNotMovable.SPStatus = _trOrderNotMovable.SPStatus;
            _orderSPNotMovable.SurveyPointID = _trOrderNotMovable.SurveyPointID;
            _orderSPNotMovable.SurveyPointName = _trOrderNotMovable.SurveyPointName;
            _orderSPNotMovable.CreatedBy = _trOrderNotMovable.CreatedBy;
            _orderSPNotMovable.CreatedDate = _trOrderNotMovable.CreatedDate;
            _orderSPNotMovable.ModifiedBy = _prmUserName;
            _orderSPNotMovable.ModifiedDate = DateTime.Now;
            _orderSPNotMovable.Timestamp = _trOrderNotMovable.Timestamp;
            _orderSPNotMovable.OriginatorID = _trOrderNotMovable.OriginatorID;
            _orderSPNotMovable.CancelStatus = _trOrderNotMovable.CancelStatus;
            _orderSPNotMovable.RemarkCancel = _trOrderNotMovable.RemarkCancel;
            _orderSPNotMovable.RemarkComplaint = _prmRemark;
            _orderSPNotMovable.FgComplaint = _trOrderNotMovable.FgComplaint;

            String _errMessage = "";

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    ////_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    ////_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);
                    //System.Net.NetworkCredential _ncre = new System.Net.NetworkCredential();
                    //_ncre.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    //_ncre.Password = (ConfigurationManager.AppSettings["Password"]);
                    //_client.ClientCredentials.Windows.ClientCredential.UserName = _ncre.UserName;
                    //_client.ClientCredentials.Windows.ClientCredential.Password = _ncre.Password;

                    _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    Boolean _transfer = _client.ComplaintResultNotMovable(_orderSPNotMovable, ref _errMessage);
                    _client.Close();

                    if (_transfer)
                    {
                        OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

                        _trOrderNotMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
                        _trOrderNotMovable.RemarkComplaint = _prmRemark;
                        _orderSPBL.UpdateTrOrderSPNotMovable(_trOrderNotMovable);

                    }
                    else
                    {
                        if (_errMessage != "") ErrorHandler.ErrorMessage += " " + _errMessage;
                    }

                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage += " " + ex.Message;
                }
            }
            return _result;
        }

        public String CompalintOrderSPMovable(Int64 _prmOrderSPMovableID, String _prmUserName, String _prmRemark)
        {
            String _result = "";

            WCFCoreServiceReference.ServiceClient _client = new WCFCoreServiceReference.ServiceClient();

            TrOrderSPMovable _trOrderMovable = this._orderSPBL.GetSingleTrOrderMovable(_prmOrderSPMovableID);
            WCFCoreServiceReference.TrOrderSPMovable _orderSPMovable = new WCFCoreServiceReference.TrOrderSPMovable();

            _trOrderMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
            _trOrderMovable.FgComplaint = true;

            _orderSPMovable.OrderSPMovableID = _trOrderMovable.OrderSPMovableID;
            _orderSPMovable.OrderID = _trOrderMovable.OrderID;
            _orderSPMovable.Clue = _trOrderMovable.Clue;
            _orderSPMovable.DateOfBirth = _trOrderMovable.DateOfBirth;
            _orderSPMovable.Extension = _trOrderMovable.Extension;
            _orderSPMovable.HomeAddress = _trOrderMovable.HomeAddress;
            _orderSPMovable.HomePhoneNumber = _trOrderMovable.HomePhoneNumber;
            _orderSPMovable.IDAddress = _trOrderMovable.IDAddress;
            _orderSPMovable.IDNo = _trOrderMovable.IDNo;
            _orderSPMovable.IDType = _trOrderMovable.IDType;
            _orderSPMovable.MaritalStatus = _trOrderMovable.MaritalStatus;
            _orderSPMovable.MobilePhoneNumber = _trOrderMovable.MobilePhoneNumber;
            _orderSPMovable.Nationality = _trOrderMovable.Nationality;
            _orderSPMovable.PlaceOfBirth = _trOrderMovable.PlaceOfBirth;
            _orderSPMovable.RegionID = _trOrderMovable.RegionID;
            _orderSPMovable.UserTakeOver = _trOrderMovable.UserTakeOver;
            _orderSPMovable.Remark = _trOrderMovable.Remark;
            _orderSPMovable.SpouseName = _trOrderMovable.SpouseName;
            _orderSPMovable.SPStatus = _trOrderMovable.SPStatus;
            _orderSPMovable.SurveyPointID = _trOrderMovable.SurveyPointID;
            _orderSPMovable.SurveyPointName = _trOrderMovable.SurveyPointName;
            _orderSPMovable.ZipCode = _trOrderMovable.ZipCode;
            _orderSPMovable.RowStatus = _trOrderMovable.RowStatus;
            _orderSPMovable.CreatedBy = _prmUserName;
            _orderSPMovable.CreatedDate = DateTime.Now;
            _orderSPMovable.ModifiedBy = _trOrderMovable.ModifiedBy;
            _orderSPMovable.ModifiedDate = _trOrderMovable.ModifiedDate;
            _orderSPMovable.Timestamp = _trOrderMovable.Timestamp;
            _orderSPMovable.OriginatorID = _trOrderMovable.OriginatorID;
            _orderSPMovable.JobTitle = _trOrderMovable.JobTitle;
            _orderSPMovable.JobType = _trOrderMovable.JobType;
            _orderSPMovable.BusinessLine = _trOrderMovable.BusinessLine;
            _orderSPMovable.CancelStatus = _trOrderMovable.CancelStatus;
            _orderSPMovable.RemarkCancel = _trOrderMovable.RemarkCancel;
            _orderSPMovable.RemarkComplaint = _prmRemark;
            _orderSPMovable.FgComplaint = _trOrderMovable.FgComplaint;

            String _errMessage = "";

            using (TransactionScope _scope = new TransactionScope())
            {
                try
                {
                    ////_client.ClientCredentials.UserName.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    ////_client.ClientCredentials.UserName.Password = (ConfigurationManager.AppSettings["Password"]);
                    //System.Net.NetworkCredential _ncre = new System.Net.NetworkCredential();
                    //_ncre.UserName = (ConfigurationManager.AppSettings["UserName"]);
                    //_ncre.Password = (ConfigurationManager.AppSettings["Password"]);
                    //_client.ClientCredentials.Windows.ClientCredential.UserName = _ncre.UserName;
                    //_client.ClientCredentials.Windows.ClientCredential.Password = _ncre.Password;

                    _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
                    _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    Boolean _transfer = _client.ComplaintResultMovable(_orderSPMovable, ref _errMessage);
                    _client.Close();

                    if (_transfer)
                    {
                        OrderSurveyPointBL _orderSPBL = new OrderSurveyPointBL();

                        _trOrderMovable.SPStatus = StatusMapper.GetStatusInternal(GSIInternalStatus.ReceivedBySystem);
                        _trOrderMovable.RemarkComplaint = _prmRemark;
                        _orderSPBL.UpdateTrOrderSPMovable(_trOrderMovable);

                    }
                    else
                    {
                        if (_errMessage != "") ErrorHandler.ErrorMessage += " " + _errMessage;
                    }

                    _scope.Complete();
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorMessage += " " + ex.Message;
                }
            }
            return _result;
        }

        #endregion

        public void UpdateResultPhotoAddtMovableCoreSystem(List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable)
        {
            foreach (var _item in _prmResultPhotoAddtMovable)
            {
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable();
                _resultPhotoAddtMov.ResultMovableID = _item.ResultMovableID;
                _resultPhotoAddtMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtMov.ImageGuid = _item.ImageGuid;
                _resultPhotoAddtMov.Remark = _item.Remark;
                _resultPhotoAddtMov.Longitude = _item.Longitude;
                _resultPhotoAddtMov.Latitude = _item.Latitude;
                _resultPhotoAddtMov.UploadDate = this._defaultDate;
                _resultPhotoAddtMov.CreatedBy = "Mobile";
                _resultPhotoAddtMov.CreatedDate = DateTime.Now;
                _resultPhotoAddtMov.ModifiedBy = String.Empty;
                _resultPhotoAddtMov.ModifiedDate = this._defaultDate;
                _resultPhotoAddtMov.RowStatus = 0;

                long _prmOutID = 0;
                _resultBL.InsertResultPhotoAddMov(_resultPhotoAddtMov, ref _prmOutID);
            }
        }

        public void UpdateResultReqDocMovableCoreSystem(List<TrResultReqDocMovable> _prmResultReqDocMovableList)
        {
            foreach (var _item in _prmResultReqDocMovableList)
            {
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = new BusinessEntity.BusinessEntities.TrResultReqDocMovable();
                _resultReqDocMov.ReqDocMovableID = _item.ReqDocMovableID;
                _resultReqDocMov.ResultMovableID = _item.ResultMovableID;
                _resultReqDocMov.PhotoName = _item.PhotoName;
                _resultReqDocMov.ImageGuid = _item.ImageGuid;
                _resultReqDocMov.PhotoName = _item.PhotoName;
                _resultReqDocMov.Remark = _item.Remark;
                _resultReqDocMov.Longitude = _item.Longitude;
                _resultReqDocMov.Latitude = _item.Latitude;
                _resultReqDocMov.UploadDate = this._defaultDate;
                _resultReqDocMov.CreatedBy = "Mobile";
                _resultReqDocMov.CreatedDate = DateTime.Now;
                _resultReqDocMov.ModifiedBy = String.Empty;
                _resultReqDocMov.ModifiedDate = this._defaultDate;
                _resultReqDocMov.RowStatus = 0;

                long _prmOutID = 0;
                _resultBL.InsertResultReqDocMovable(_resultReqDocMov, ref _prmOutID);
            }
        }

        public void UpdateResultPhotoAddtNotMovableCoreSystem(List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable)
        {
            foreach (var _item in _prmResultPhotoAddtNotMovable)
            {
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = new BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable();
                _resultPhotoAddtNotMov.ResultNotMovableID = _item.ResultNotMovableID;
                _resultPhotoAddtNotMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtNotMov.ImageGuid = _item.ImageGuid;
                _resultPhotoAddtNotMov.Remark = _item.Remark;
                _resultPhotoAddtNotMov.Longitude = _item.Longitude;
                _resultPhotoAddtNotMov.Latitude = _item.Latitude;
                _resultPhotoAddtNotMov.UploadDate = this._defaultDate;
                _resultPhotoAddtNotMov.CreatedBy = "Mobile";
                _resultPhotoAddtNotMov.CreatedDate = DateTime.Now;
                _resultPhotoAddtNotMov.ModifiedBy = String.Empty;
                _resultPhotoAddtNotMov.ModifiedDate = this._defaultDate;
                _resultPhotoAddtNotMov.RowStatus = 0;

                long _prmOutID = 0;
                _resultBL.InsertResultPhotoAddNotMov(_resultPhotoAddtNotMov, ref _prmOutID);
            }
        }

        public void UpdateResultReqDocNotMovableCoreSystem(List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList)
        {
            foreach (var _item in _prmResultReqDocNotMovableList)
            {
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable _resultReqDocNotMov = this._resultBL.GetSingleResultReqDocNotMovableByResultReqDocNotMovableID(_item.ResultReqDocNotMovableID);
                _resultReqDocNotMov.ReqDocNotMovableID = _item.ReqDocNotMovableID;
                _resultReqDocNotMov.ResultNotMovableID = _item.ResultNotMovableID;
                _resultReqDocNotMov.PhotoName = _item.PhotoName;
                _resultReqDocNotMov.ImageGuid = _item.ImageGuid;
                _resultReqDocNotMov.Remark = _item.Remark;
                _resultReqDocNotMov.Longitude = _item.Longitude;
                _resultReqDocNotMov.Latitude = _item.Latitude;
                _resultReqDocNotMov.UploadDate = this._defaultDate;
                _resultReqDocNotMov.CreatedBy = "Mobile";
                _resultReqDocNotMov.CreatedDate = DateTime.Now;
                _resultReqDocNotMov.ModifiedBy = String.Empty;
                _resultReqDocNotMov.ModifiedDate = this._defaultDate;
                _resultReqDocNotMov.RowStatus = 0;

                long _prmOutID = 0;
                _resultBL.InsertResultReqDocNotMovable(_resultReqDocNotMov, ref _prmOutID);
            }
        }

        public List<TrOrderSPLog> GetListTrOrderSPLogByOrderIDSurveyPointType(long _prmOrderSPID, long _prmSurveyPointType)
        {
            List<TrOrderSPLog> _result = new List<TrOrderSPLog>();
            WCFCoreServiceReference.ServiceClient _client = new WCFCoreServiceReference.ServiceClient();

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            WCFCoreServiceReference.TrOrderSPLog[] _wcfTrOrderSPLog = _client.GetListTrOrderSPLogByOrderIDSurveyPointType(_prmOrderSPID, _prmSurveyPointType);

            RequestVariable.RowCount = 0;
            _client.Close();

            foreach (var _dt in _wcfTrOrderSPLog)
            {
                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                _trOrderSPLog.CreatedBy = _dt.CreatedBy;
                _trOrderSPLog.CreatedDate = _dt.CreatedDate;
                _trOrderSPLog.DateTime = _dt.DateTime;
                _trOrderSPLog.Duration = _dt.Duration;
                _trOrderSPLog.EmployeeID = _dt.EmployeeID;
                _trOrderSPLog.LogID = _dt.LogID;
                _trOrderSPLog.ModifiedBy = _dt.ModifiedBy;
                _trOrderSPLog.ModifiedDate = _dt.ModifiedDate;
                _trOrderSPLog.OrderSPID = _dt.OrderSPID;
                _trOrderSPLog.RowStatus = _dt.RowStatus;
                _trOrderSPLog.Status = _dt.Status;
                _trOrderSPLog.SurveyPointType = _dt.SurveyPointType;
                _trOrderSPLog.Timestamp = _dt.Timestamp;
                _trOrderSPLog.TypeProcess = _dt.TypeProcess;
                _result.Add(_trOrderSPLog);
                if (_dt.Status == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Complaint))
                {
                    RequestVariable.RowCount = RequestVariable.RowCount + 1;
                }
            }
            return _result;
        }

        public List<TrOrderSPLog> GetListTrOrderSPLogByOrderIDSurveyPointTypeForComplaintTime(long _prmOrderSPID, long _prmSurveyPointType)
        {
            DateTime _defaultDate2 = new DateTime(1900, 1, 1);
            List<TrOrderSPLog> _result = new List<TrOrderSPLog>();
            WCFCoreServiceReference.ServiceClient _client = new WCFCoreServiceReference.ServiceClient();

            _client.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"], ConfigurationManager.AppSettings["Domain"]);
            _client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            WCFCoreServiceReference.TrOrderSPLog[] _wcfTrOrderSPLog = _client.GetListTrOrderSPLogByOrderIDSurveyPointType(_prmOrderSPID, _prmSurveyPointType);

            RequestVariable.RowCount = 0;
            _client.Close();

            foreach (var _dt in _wcfTrOrderSPLog)
            {
                TrOrderSPLog _trOrderSPLog = new TrOrderSPLog();
                _trOrderSPLog.CreatedBy = _dt.CreatedBy;
                _trOrderSPLog.CreatedDate = _dt.CreatedDate;
                _trOrderSPLog.DateTime = _dt.DateTime;
                _trOrderSPLog.Duration = _dt.Duration;
                _trOrderSPLog.EmployeeID = _dt.EmployeeID;
                _trOrderSPLog.LogID = _dt.LogID;
                _trOrderSPLog.ModifiedBy = _dt.ModifiedBy;
                _trOrderSPLog.ModifiedDate = _dt.ModifiedDate;
                _trOrderSPLog.OrderSPID = _dt.OrderSPID;
                _trOrderSPLog.RowStatus = _dt.RowStatus;
                _trOrderSPLog.Status = _dt.Status;
                _trOrderSPLog.SurveyPointType = _dt.SurveyPointType;
                _trOrderSPLog.Timestamp = _dt.Timestamp;
                _trOrderSPLog.TypeProcess = _dt.TypeProcess;
                _result.Add(_trOrderSPLog);
                if (_dt.Status == StatusMapper.GetStatusEksternal(GSIEksternalStatus.Completed))
                {

                    if (_defaultDate2 == Convert.ToDateTime("1/1/1900"))
                    {
                        _defaultDate2 = _trOrderSPLog.DateTime;
                    }
                    else
                    {
                        if (_trOrderSPLog.DateTime > _defaultDate)
                        {
                            _defaultDate2 = _trOrderSPLog.DateTime;                            
                        }
                    }
                }                
            }
            RequestVariable.Time = _defaultDate2;
            return _result;
        }
    }
}
