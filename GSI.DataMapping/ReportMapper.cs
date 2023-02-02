using System;
using System.Collections.Generic;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class ReportMapper
    {
        private static List<String> _report = new List<String>()
        {
            //id, text, format
            "1|Report Detail Customer Transaction",
            "2|Report Summary Customer Transaction",
            "3|Report Order Survey Point",
            "4|Report Productivity Dispatcher",
            "5|Report Productivity Surveyor",
            "6|Report Order Survey Point Detail",
            "7|Report Analisys SLA Surveyor",
            "8|Report Analisys Proceess Surveyor",
            "9|Report Analisys Survey By Customer",
            "10|Report Analisys Survey By Period",
            "11|Report Order SLA Customer By Customer",
            "12|Report Order SLA Customer By Period"
        };

        public static List<String> ReportList
        {
            get { return _report; }
        }

        public static string GetFilterAttr(String _prmValue)
        {
            string _result = "0";

            switch (_prmValue)
            {
                case "1":
                    _result = "Date, Cust";
                    break;
                case "2":
                    _result = "Date, Cust";
                    break;
                case "3":
                    _result = "Date, Cust, OrNo, SPName, Status";
                    break;
                case "4":
                    _result = "Date, Dispatcher";
                    break;
                case "5":
                    _result = "Date, Surveyor";
                    break;
                case "6":
                    _result = "Date, OrNo";
                    break;
                case "7":
                    _result = "Year, Month";
                    break;
                case "8":
                    _result = "Period, Surveyor, Year";
                    break;
                case "9":
                    _result = "Year, CustDDL, Period";
                    break;
                case "10":
                    _result = "Month, Year";
                    break;
                case "11":
                    _result = "Period, CustDDL, Year";
                    break;
                case "12":
                    _result = "Month, Year";
                    break;
            }
            return _result;
        }

        public static String GetReportPath(String _value)
        {
            String _result = "0";

            switch (_value)
            {
                case "1":
                    _result = "/SurveyorSystem/ReportDetailCustomerTransaction";
                    break;
                case "2":
                    _result = "/SurveyorSystem/ReportSummaryCustomerTransaction";
                    break;
                case "3":
                    _result = "/SurveyorSystem/ReportOrderSurveyPoint";
                    break;
                case "4":
                    _result = "/SurveyorSystem/ReportProductivityDispatcher";
                    break;
                case "5":
                    _result = "/SurveyorSystem/ReportProductivitySurveyor";
                    break;
                case "6":
                    _result = "/SurveyorSystem/ReportOrderSurveyPointDetail";
                    break;
                case "7":
                    _result = "/SurveyorSystem/ReportAnalysysSLAByPeriod";
                    break;
                case "8":
                    _result = "/SurveyorSystem/ReportAnalysysSLABySurveyor";
                    break;
                case "9":
                    _result = "/SurveyorSystem/ReportAnalysysSLASurveyByPeriod";
                    break;
                case "10":
                    _result = "/SurveyorSystem/ReportAnalysysSLATypeProcessByPeriod";
                    break;
                case "11":
                    _result = "/SurveyorSystem/ReportOrderSLAByCustomer";
                    break;
                case "12":
                    _result = "/SurveyorSystem/ReportOrderSLAByPeriod";
                    break;
            }

            return _result;
        }
    }
}
