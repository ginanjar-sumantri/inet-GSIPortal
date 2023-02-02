using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Web;

namespace GSI.BusinessRuleCore
{
    public class ReportBL : Base
    {
        public ReportBL()
        {
        }

        public ReportDataSource ReportDetailCustomerTransaction(DateTime _prmFrom, DateTime _prmTo, String _prmCustomer)
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
                _cmd.CommandText = "sp_ReportDetailCustomerTransaction";
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);
                _cmd.Parameters.AddWithValue("@CustomerName", _prmCustomer);

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

        public ReportDataSource ReportSummaryCustomerTransaction(DateTime _prmFrom, DateTime _prmTo, String _prmCustomer)
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
                _cmd.CommandText = "sp_ReportSummaryCustomerTransaction";
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);
                _cmd.Parameters.AddWithValue("@CustomerName", _prmCustomer);

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

        public ReportDataSource ReportOrderSurveyPoint(DateTime _prmFrom, DateTime _prmTo, String _prmCustomer, String _prmOrderCodeFrom, String _prmOrderCodeTo, String _prmSPName, Int32 _prmStatus)
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
                _cmd.CommandTimeout = 3000;
                _cmd.CommandText = "sp_ReportOrderSurveyPoint";
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);
                _cmd.Parameters.AddWithValue("@CustomerName", _prmCustomer);
                _cmd.Parameters.AddWithValue("@OrderCodeFrom", _prmOrderCodeFrom);
                _cmd.Parameters.AddWithValue("@OrderCodeTo", _prmOrderCodeTo);
                _cmd.Parameters.AddWithValue("@SurveyPointName", _prmSPName);
                _cmd.Parameters.AddWithValue("@Status", _prmStatus);

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

        public ReportDataSource ReportProductivityDispatcher(Int64 _prmEmployeeID, DateTime _prmFrom, DateTime _prmTo)
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
                _cmd.CommandText = "sp_ReportProductivityDispatcher";
                _cmd.Parameters.AddWithValue("@EmployeeID", _prmEmployeeID);
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);                

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

        public ReportDataSource ReportProductivitySurveyor(Int64 _prmEmployeeID, DateTime _prmFrom, DateTime _prmTo)
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
                _cmd.CommandText = "sp_ReportProductivitySurveyor";
                _cmd.Parameters.AddWithValue("@EmployeeID", _prmEmployeeID);
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);

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

        public ReportDataSource ReportOrderSurveyPointDetail(DateTime _prmFrom, DateTime _prmTo, String _prmOrderCodeFrom, String _prmOrderCodeTo)
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
                _cmd.CommandText = "sp_ReportOrderSurveyPointDetail";                
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmFrom);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmTo);
                _cmd.Parameters.AddWithValue("@OrderCodeFrom", _prmOrderCodeFrom);
                _cmd.Parameters.AddWithValue("@OrderCodeTo", _prmOrderCodeTo);

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

        public ReportDataSource ReportAnalysysSLAByPeriod(Int32 _prmYear, Int32 _prmMonth)
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
                _cmd.CommandText = "sp_ReportAnalysysSLAByPeriod";
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@MonthPeriod", _prmMonth);

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

        public ReportDataSource ReportAnalysysSLABySurveyor(Int64 _prmEmployeeID, Int32 _prmYear, Int32 _prmMonthStart, Int32 _prmMonthEnd)
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
                _cmd.CommandText = "sp_ReportAnalysysSLABySurveyor";
                _cmd.Parameters.AddWithValue("@EmployeeID", _prmEmployeeID);
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmMonthStart);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmMonthEnd);

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

        public ReportDataSource ReportAnalysysSLASurveyByPeriod(Int64 _prmCustomerID, Int32 _prmYear, Int32 _prmMonthStart, Int32 _prmMonthEnd)
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
                _cmd.CommandText = "sp_ReportAnalysysSLAByCustomer";
                _cmd.Parameters.AddWithValue("@CustomerID", _prmCustomerID);
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmMonthStart);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmMonthEnd);

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

        public ReportDataSource ReportAnalysysSLATypeProcessByPeriod(Int32 _prmYear, Int32 _prmMonth)
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
                _cmd.CommandText = "sp_ReportAnalysysSLATypeProcessByPeriod";
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@MonthPeriod", _prmMonth);

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

        public ReportDataSource ReportOrderSLAByCustomer(Int64 _prmCustomerID, Int32 _prmYear, Int32 _prmMonthStart, Int32 _prmMonthEnd)
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
                _cmd.CommandText = "sp_ReportOrderSLAByCustomer";
                _cmd.Parameters.AddWithValue("@CustomerID", _prmCustomerID);
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@StartPeriod", _prmMonthStart);
                _cmd.Parameters.AddWithValue("@EndPeriod", _prmMonthEnd);

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

        public ReportDataSource ReportOrderSLAByPeriod(Int32 _prmYear, Int32 _prmMonth)
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
                _cmd.CommandText = "sp_ReportOrderSLAByPeriod";
                _cmd.Parameters.AddWithValue("@YearPeriod", _prmYear);
                _cmd.Parameters.AddWithValue("@MonthPeriod", _prmMonth);

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
