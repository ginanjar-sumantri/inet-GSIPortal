using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using System.Transactions;

namespace GSI.BusinessRuleCore
{
    public class DashboardBL : Base
    {
        public DashboardBL()
        {
        }

        public int GetTotalSurveyPoint(ref String _prmErrMsg)
        {
            int _result = 0;

            try
            {
                object data = null;
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@period", DateTime.Now, DbType.DateTime));

                List<SPParamOut> _paramOut = new List<SPParamOut>();

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_SurveyPointTotal", _param, ref _paramOut, ref data);
                if (_success)
                {
                    IDataReader dr = (IDataReader)data;
                    dr.Read();
                    _result = (dr["SurveyPointCount"] == DBNull.Value) ? 0 : (int)dr["SurveyPointCount"];
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                _prmErrMsg = ex.Message;
            }
            
            return _result;
        }

        public String GetBarCount(ref String _prmErrMsg)
        {
            String _result = "";

            try
            {
                object data = null;
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@period", DateTime.Now, DbType.DateTime));

                List<SPParamOut> _paramOut = new List<SPParamOut>();

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_SurveyPointCountPerDuration", _param, ref _paramOut, ref data);
                if (_success)
                {
                    IDataReader dr = (IDataReader)data;
                    dr.Read();
                    _result = (dr["SurveyPointCountPerDuration"] == DBNull.Value) ? "" : (String)dr["SurveyPointCountPerDuration"];
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                _prmErrMsg = ex.Message;
            }

            return _result;
        }

        public List<DashboardByRegion> GetListViewByRegion(int _prmTimeFrameValue, ref String _prmErrMsg)
        {
            List<DashboardByRegion> _result = null;

            try
            {
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@timeFrame", _prmTimeFrameValue, DbType.Int32));
                _param.Add(new SPParam("@period", DateTime.Now, DbType.DateTime));

                List<SPParamOut> _paramOut = new List<SPParamOut>();
                object data = null;

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListDashboardViewByRegion", _param, ref _paramOut, ref data);
                if (_success)
                {
                    _result = new List<DashboardByRegion>();

                    IDataReader dr = (IDataReader)data;
                    while (dr.Read())
                    {
                        DashboardByRegion _dashboardRegion = new DashboardByRegion();
                        _dashboardRegion.RegionID = (long)dr["RegionID"];
                        _dashboardRegion.RegionName = (dr["RegionName"] == DBNull.Value) ? String.Empty : (String)dr["RegionName"];
                        _dashboardRegion.ReceivedBySystem = (dr["RBS"] == DBNull.Value) ? 0 : (int)dr["RBS"];
                        _dashboardRegion.WaitingForAssign = (dr["WFA"] == DBNull.Value) ? 0 : (int)dr["WFA"];
                        _dashboardRegion.WaitingForDownload = (dr["WFD"] == DBNull.Value) ? 0 : (int)dr["WFD"];
                        _dashboardRegion.WaitingForSurvey = (dr["WFS"] == DBNull.Value) ? 0 : (int)dr["WFS"];
                        _dashboardRegion.OnTheWay = (dr["OTW"] == DBNull.Value) ? 0 : (int)dr["OTW"];
                        _dashboardRegion.OnTheSpot = (dr["OTS"] == DBNull.Value) ? 0 : (int)dr["OTS"];
                        _dashboardRegion.SurveyResultReceived = (dr["SRR"] == DBNull.Value) ? 0 : (int)dr["SRR"];
                        _dashboardRegion.Published = (dr["Published"] == DBNull.Value) ? 0 : (int)dr["Published"];
                        _result.Add(_dashboardRegion);
                    }
                    dr.Close();
                }
            }
            catch (Exception Ex)
            {
                _prmErrMsg = Ex.Message;
            }

            return _result;
        }

        public List<DashboardBySurveyor> GetListViewBySurveyor(String _prmTimeFrameValue, ref int _prmSPNotYetAssigned, ref String _prmErrMsg)
        {
            List<DashboardBySurveyor> _result = null;

            try
            {
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@timeFrame", _prmTimeFrameValue, DbType.Int32));
                _param.Add(new SPParam("@period", DateTime.Now, DbType.DateTime));

                List<SPParamOut> _paramOut = new List<SPParamOut>();
                //_paramOut.Add(new SPParamOut("@spNotYetAssigned", _prmSPNotYetAssigned, DbType.Int32));

                object data = null;

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListDashboardViewBySurveyor", _param, ref _paramOut, ref data);
                if (_success)
                {
                    _result = new List<DashboardBySurveyor>();

                    IDataReader dr = (IDataReader)data;
                    dr.Read();
                    _prmSPNotYetAssigned = (dr["SPNotYetAssigned"] == DBNull.Value) ? 0 : (int)dr["SPNotYetAssigned"];

                    dr.NextResult();
                    while (dr.Read())
                    {
                        DashboardBySurveyor _dashboardSurveyor = new DashboardBySurveyor();
                        _dashboardSurveyor.SurveyorID = (long)dr["SurveyorID"];
                        _dashboardSurveyor.SurveyorName = (dr["SurveyorName"] == DBNull.Value) ? String.Empty : (String)dr["SurveyorName"];
                        _dashboardSurveyor.WaitingForDownload = (dr["WFD"] == DBNull.Value) ? 0 : (int)dr["WFD"];
                        _dashboardSurveyor.WaitingForSurvey = (dr["WFS"] == DBNull.Value) ? 0 : (int)dr["WFS"];
                        _dashboardSurveyor.OnTheWay = (dr["OTW"] == DBNull.Value) ? 0 : (int)dr["OTW"];
                        _dashboardSurveyor.OnTheSpot = (dr["OTS"] == DBNull.Value) ? 0 : (int)dr["OTS"];
                        _dashboardSurveyor.SurveyResultReceived = (dr["SRR"] == DBNull.Value) ? 0 : (int)dr["SRR"];
                        _dashboardSurveyor.Published = (dr["Published"] == DBNull.Value) ? 0 : (int)dr["Published"];
                        _result.Add(_dashboardSurveyor);
                    }
                    dr.Close();
                }
            }
            catch (Exception Ex)
            {
                _prmErrMsg = Ex.Message;
            }

            return _result;
        }

        public List<OrderWFD> GetListOrderWFD(Int32 _prmCount, ref String _prmErrMsg)
        {
            List<OrderWFD> _result = null;

            try
            {
                List<SPParam> _param = new List<SPParam>();
                _param.Add(new SPParam("@count", _prmCount, DbType.Int32));

                List<SPParamOut> _paramOut = new List<SPParamOut>();
                //_paramOut.Add(new SPParamOut("@spNotYetAssigned", _prmSPNotYetAssigned, DbType.Int32));

                object data = null;

                bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetListOrderWFD", _param, ref _paramOut, ref data);
                if (_success)
                {
                    _result = new List<OrderWFD>();

                    IDataReader dr = (IDataReader)data;
                    while (dr.Read())
                    {
                        OrderWFD _orderWFD = new OrderWFD();
                        _orderWFD.NewOrder = (Int64)dr["NewOrder"]; //(dr["NewOrder"] == DBNull.Value) ? 0 :
                        _orderWFD.OutStanding = (Int64)dr["OutStanding"];//(dr["OutStanding"] == DBNull.Value) ? 0 : 
                        _orderWFD.OnProgress = (Int64)dr["OnProgress"];//(dr["OnProgress"] == DBNull.Value) ? 0 : 
                        _orderWFD.OrderDate = (dr["OrderDate"] == DBNull.Value) ? _defaultDate : (DateTime)dr["OrderDate"];
                        _orderWFD.CustomerName = (dr["CustomerName"] == DBNull.Value) ? String.Empty : (String)dr["CustomerName"];
                        _orderWFD.SPStatus = (Byte)dr["SPStatus"];
                        _orderWFD.RegionName = (dr["RegionName"] == DBNull.Value) ? String.Empty : (String)dr["RegionName"];
                        _result.Add(_orderWFD);
                    }
                    dr.Close();
                }
            }
            catch (Exception Ex)
            {
                _prmErrMsg = Ex.Message;
            }

            return _result;
        }
    }
}
