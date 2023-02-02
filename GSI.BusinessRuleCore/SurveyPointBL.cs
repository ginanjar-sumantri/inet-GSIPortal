using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRuleCore
{
    public class SurveyPointBL : Base
    {
        public SurveyPointBL()
        {
        }

        public MsSurveyPoint GetSingleSurveyPoint(long _prmSurveyPointID)
        {
            MsSurveyPoint _result = new MsSurveyPoint();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@surveyPointID", _prmSurveyPointID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetMsSurveyPointBySurveyPointID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                dr.Read();
                MsSurveyPoint _msSurveyPoint = new MsSurveyPoint();
                _msSurveyPoint.SurveyPointID = (long)dr["SurveyPointID"];
                _msSurveyPoint.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                _msSurveyPoint.TemplateForm = (dr["TemplateForm"] == DBNull.Value) ? 0 : (int)dr["TemplateForm"];
                _msSurveyPoint.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                _msSurveyPoint.RowStatus = (int)dr["RowStatus"];
                _msSurveyPoint.CreatedBy = (String)dr["CreatedBy"];
                _msSurveyPoint.CreatedDate = (DateTime)dr["CreatedDate"];
                _msSurveyPoint.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                _msSurveyPoint.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                _msSurveyPoint.Timestamp = (byte[])dr["Timestamp"];

                _result = _msSurveyPoint;
                dr.Close();
            }

            return _result;
        }

        public List<OrderSurveyPoint> GetListSurveyPointForAssign(String _prmCustName, String _prmUserTakeOver, long _prmRegion, String _prmOrderCode, String _prmOrderSPName, DateTime _prmStartDate, DateTime _prmEndDate, Byte _prmSPStatus, Int32 _prmPageSize, Int32 _prmPageNumb, String _prmOrderBy, String _prmAscDesc)
        {
            List<OrderSurveyPoint> _result = new List<OrderSurveyPoint>();
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@CustomerName", _prmCustName, DbType.String));
            _param.Add(new SPParam("@OrderCode", _prmOrderCode, DbType.String));
            _param.Add(new SPParam("@OrderSurveyPointName", _prmOrderSPName, DbType.String));
            _param.Add(new SPParam("@OrderStartDate", _prmStartDate, DbType.DateTime));
            _param.Add(new SPParam("@OrderEndDate", _prmEndDate, DbType.DateTime));
            _param.Add(new SPParam("@SPStatus", Convert.ToByte(_prmSPStatus), DbType.Byte));
            _param.Add(new SPParam("@Region", Convert.ToInt64(_prmRegion), DbType.Int64));
            _param.Add(new SPParam("@UserTakeOver", _prmUserTakeOver, DbType.String));
            _param.Add(new SPParam("@pageSize", _prmPageSize, DbType.Int32));
            _param.Add(new SPParam("@pageNumb", _prmPageNumb, DbType.Int32));
            _param.Add(new SPParam("@orderBy", _prmOrderBy, DbType.String));
            _param.Add(new SPParam("@ascDesc", _prmAscDesc, DbType.String));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            object data = null;

            RequestVariable.RowCount = 0;
            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListSurveyPointForAssign", _param, ref _paramOut, ref data);
            //bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListSurveyPointForAssign_Trial", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    OrderSurveyPoint _orderSP = new OrderSurveyPoint();
                    _orderSP.OrderSPID = (Int64)dr["OrderSurveyPointID"];
                    _orderSP.OrderID = (Int64)dr["OrderID"];
                    _orderSP.OrderCode = (String)dr["OrderCode"];
                    _orderSP.OrderDate = (DateTime)dr["OrderDate"];
                    _orderSP.OrderTypeID = (Int64)dr["OrderTypeID"];
                    _orderSP.OrderTypeName = (dr["OrderTypeName"] == DBNull.Value) ? "" : (String)dr["OrderTypeName"];
                    _orderSP.SurveyPointID = (Int64)dr["SurveyPointID"];
                    _orderSP.TemplateForm = (dr["TemplateForm"] == DBNull.Value) ? 0 : (int)dr["TemplateForm"];
                    _orderSP.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _orderSP.OrderSurveyPointName = (String)dr["OrderSurveyPointName"];
                    _orderSP.Address = (String)dr["Address"];
                    _orderSP.Clue = (String)dr["Clue"];
                    _orderSP.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _orderSP.HomePhoneNumber = (String)dr["HomePhoneNumber"];
                    _orderSP.Extension = (String)dr["Extension"];
                    _orderSP.MobilePhoneNumber = (String)dr["MobilePhoneNumber"];
                    _orderSP.RegionID = (Int64)dr["RegionID"];
                    _orderSP.RegionName = (dr["RegionName"] == DBNull.Value) ? "" : (String)dr["RegionName"];
                    _orderSP.SPStatus = (Byte)dr["SPStatus"];
                    _orderSP.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _orderSP.CancelStatus = (dr["CancelStatus"] == DBNull.Value) ? (Byte)0 : (Byte)dr["CancelStatus"];
                    _orderSP.RowStatus = (Int32)dr["RowStatus"];
                    _orderSP.CreatedBy = (String)dr["CreatedBy"];
                    _orderSP.CreatedDate = (DateTime)dr["CreatedDate"];
                    _orderSP.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _orderSP.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _orderSP.Timestamp = (byte[])dr["Timestamp"];
                    _orderSP.CustomerName = (String)dr["CustomerName"];
                    _result.Add(_orderSP);
                    RequestVariable.RowCount = (Int32)dr["RowCounts"];
                }
                dr.Close();
            }

            return _result;
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

        public Boolean IsSurveyPointOriginator(long _prmSurveyPointID, long _prmOriginatorID, ref String _errMessage)
        {
            Boolean _result = false;

            try
            {
                if (this.GetSingleSurveyPoint(_prmSurveyPointID).SurveyPointID == _prmOriginatorID)
                {
                    _result = true;
                }
            }
            catch (Exception Ex)
            {
                _errMessage += Ex.Message;
            }

            return _result;
        }

        ~SurveyPointBL()
        {
        }
    }
}
