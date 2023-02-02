using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class GlobalStatusMapper
    {
        public static GlobalStatus GetStatus(Byte _prmValue)
        {
            GlobalStatus _result;

            switch (_prmValue)
            {
                case 0:
                    _result = GlobalStatus.OnHold;
                    break;
                case 1:
                    _result = GlobalStatus.InProcess;
                    break;
                case 2:
                    _result = GlobalStatus.Surveying;
                    break;
                case 3:
                    _result = GlobalStatus.Done;
                    break;
                case 4:
                    _result = GlobalStatus.Draft;
                    break;
                case 5:
                    _result = GlobalStatus.Final;
                    break;
                case 6:
                    _result = GlobalStatus.Cancel;
                    break;
                case 7:
                    _result = GlobalStatus.Assigned;
                    break;
                case 8:
                    _result = GlobalStatus.SentToCS;
                    break;
                case 99:
                    _result = GlobalStatus.All;
                    break;
                default:
                    _result = GlobalStatus.OnHold;
                    break;
            }
            return _result;
        }

        public static Byte GetStatus(GlobalStatus _prmValue)
        {
            Byte _result;

            switch (_prmValue)
            {
                case GlobalStatus.OnHold:
                    _result = 0;
                    break;
                case GlobalStatus.InProcess:
                    _result = 1;
                    break;
                case GlobalStatus.Surveying:
                    _result = 2;
                    break;
                case GlobalStatus.Done:
                    _result = 3;
                    break;
                case GlobalStatus.Draft:
                    _result = 4;
                    break;
                case GlobalStatus.Final:
                    _result = 5;
                    break;
                case GlobalStatus.Cancel:
                    _result = 6;
                    break;
                case GlobalStatus.Assigned:
                    _result = 7;
                    break;
                case GlobalStatus.SentToCS:
                    _result = 8;
                    break;
                case GlobalStatus.All:
                    _result = 99;
                    break;
                default:
                    _result = 0;
                    break;
            }
            
            return _result;
        }

        public static String GetStatusText(GlobalStatus _prmValue)
        {
            String _result;

            switch (_prmValue)
            {
                case GlobalStatus.OnHold:
                    _result = "On Hold";
                    break;
                case GlobalStatus.InProcess:
                    _result = "In Process";
                    break;
                case GlobalStatus.Surveying:
                    _result = "Surveying";
                    break;
                case GlobalStatus.Done:
                    _result = "Done";
                    break;
                case GlobalStatus.Draft:
                    _result = "Draft";
                    break;
                case GlobalStatus.Final:
                    _result = "Final";
                    break;
                case GlobalStatus.Cancel:
                    _result = "Cancel";
                    break;
                case GlobalStatus.Assigned:
                    _result = "Assigned";
                    break;
                case GlobalStatus.SentToCS:
                    _result = "Sent";
                    break;
                case GlobalStatus.All:
                    _result = "All";
                    break;
                default:
                    _result = "On Hold";
                    break;
            }

            return _result;
        }

        public static String GetStatusText(Byte _prmValue)
        {
            String _result;

            switch (_prmValue)
            {
                case 0:
                    _result = "On Hold";
                    break;
                case 1:
                    _result = "In Process";
                    break;
                case 2:
                    _result = "Surveying";
                    break;
                case 3:
                    _result = "Done";
                    break;
                case 4:
                    _result = "Draft";
                    break;
                case 5:
                    _result = "Final";
                    break;
                case 6:
                    _result = "Cancel";
                    break;
                case 7:
                    _result = "Assigned";
                    break;
                case 8:
                    _result = "Sent";
                    break;
                case 99:
                    _result = "All";
                    break;
                default:
                    _result = "On Hold";
                    break;
            }

            return _result;
        }
    }
}
