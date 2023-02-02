using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class StatusMapper
    {
        #region Eksternal
        public static GSIEksternalStatus GetStatusEksternal(Byte _prmValue)
        {
            GSIEksternalStatus _result = GSIEksternalStatus.Initialized;

            switch (_prmValue)
            {
                case 0:
                    _result = GSIEksternalStatus.Initialized;
                    break;
                case 1:
                    _result = GSIEksternalStatus.Submitted;
                    break;
                case 2:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 3:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 4:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 5:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 6:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 7:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 8:
                    _result = GSIEksternalStatus.Completed;
                    break;
                case 9:
                    _result = GSIEksternalStatus.Cancelled;
                    break;
                case 10:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                case 11:
                    _result = GSIEksternalStatus.OnProgress;
                    break;
                default:
                    _result = GSIEksternalStatus.Initialized;
                    break;
            }
            return _result;
        }

        public static String GetStatusEksternalText(Byte _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 0:
                    _result = "Initialized";
                    break;
                case 1:
                    _result = "Submitted";
                    break;
                case 2:
                    _result = "On Progress";
                    break;
                case 3:
                    _result = "On Progress";
                    break;
                case 4:
                    _result = "On Progress";
                    break;
                case 5:
                    _result = "On Progress";
                    break;
                case 6:
                    _result = "On Progress";
                    break;
                case 7:
                    _result = "On Progress";
                    break;
                case 8:
                    _result = "Completed";
                    break;
                case 9:
                    _result = "Cancelled";
                    break;
                case 10:
                    _result = "On Progress";
                    break;
                case 11:
                    _result = "On Progress";
                    break;
                default:
                    _result = "Initialized";
                    break;
            }

            return _result;
        }

        public static Byte GetStatusEksternal(GSIEksternalStatus _prmValue)
        {
            Byte _result = 0;

            switch (_prmValue)
            {
                case GSIEksternalStatus.Initialized:
                    _result = 0;
                    break;
                case GSIEksternalStatus.Submitted:
                    _result = 1;
                    break;
                case GSIEksternalStatus.Completed:
                    _result = 8;
                    break;
                case GSIEksternalStatus.Cancelled:
                    _result = 9;
                    break;
                case GSIEksternalStatus.Correction:
                    _result = 10;
                    break;
                case GSIEksternalStatus.Complaint:
                    _result = 11;
                    break;
                default:
                    _result = 0;
                    break;
            }
            
            return _result;
        }
        #endregion

        #region Internal
        public static GSIInternalStatus GetStatusInternal(Byte _prmValue)
        {
            GSIInternalStatus _result = GSIInternalStatus.ReceivedBySystem;

            switch (_prmValue)
            {
                case 0:
                    _result = GSIInternalStatus.NA;
                    break;
                case 1:
                    _result = GSIInternalStatus.ReceivedBySystem;
                    break;
                case 2:
                    _result = GSIInternalStatus.WaitingForAssigment;
                    break;
                case 3:
                    _result = GSIInternalStatus.WaitingForDownload;
                    break;
                case 4:
                    _result = GSIInternalStatus.WaitingForSurvey;
                    break;
                case 5:
                    _result = GSIInternalStatus.OnTheWay;
                    break;
                case 6:
                    _result = GSIInternalStatus.OnTheSpot;
                    break;
                case 7:
                    _result = GSIInternalStatus.SurveyResultReceived;
                    break;
                case 8:
                    _result = GSIInternalStatus.Published;
                    break;
                case 9:
                    _result = GSIInternalStatus.Cancelled;
                    break;
                case 10:
                    _result = GSIInternalStatus.Correction;
                    break;
                case 11:
                    _result = GSIInternalStatus.Complaint;
                    break;
                default:
                    _result = GSIInternalStatus.NA;
                    break;
            }

            return _result;
        }

        public static String GetStatusInternalText(Byte _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 0:
                    _result = "N/A";
                    break;
                case 1:
                    _result = "Received By System";
                    break;
                case 2:
                    _result = "Waiting For Assigment";
                    break;
                case 3:
                    _result = "Waiting For Download";
                    break;
                case 4:
                    _result = "Waiting For Survey";
                    break;
                case 5:
                    _result = "On The Way";
                    break;
                case 6:
                    _result = "On The Spot";
                    break;
                case 7:
                    _result = "Survey Result Received";
                    break;
                case 8:
                    _result = "Published";
                    break;
                case 9:
                    _result = "Cancelled";
                    break;
                case 10:
                    _result = "Correction";
                    break;
                case 11:
                    _result = "Complaint";
                    break;
                default:
                    _result = "N/A";
                    break;
            }

            return _result;
        }

        public static Byte GetStatusInternal(GSIInternalStatus _prmValue)
        {
            Byte _result = 0;

            switch (_prmValue)
            {
                case GSIInternalStatus.NA:
                    _result = 0;
                    break;
                case GSIInternalStatus.ReceivedBySystem:
                    _result = 1;
                    break;
                case GSIInternalStatus.WaitingForAssigment:
                    _result = 2;
                    break;
                case GSIInternalStatus.WaitingForDownload:
                    _result = 3;
                    break;
                case GSIInternalStatus.WaitingForSurvey:
                    _result = 4;
                    break;
                case GSIInternalStatus.OnTheWay:
                    _result = 5;
                    break;
                case GSIInternalStatus.OnTheSpot:
                    _result = 6;
                    break;
                case GSIInternalStatus.SurveyResultReceived:
                    _result = 7;
                    break;
                case GSIInternalStatus.Published:
                    _result = 8;
                    break;
                case GSIInternalStatus.Cancelled:
                    _result = 9;
                    break;
                case GSIInternalStatus.Correction:
                    _result = 10;
                    break;
                case GSIInternalStatus.Complaint:
                    _result = 11;
                    break;
                default:
                    _result = 0;
                    break;
            }

            return _result;
        }
        #endregion
    }
}
