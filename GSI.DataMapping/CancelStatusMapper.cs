using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class CancelStatusMapper
    {
        public static CancelStatusEnum GetCancelStatus(Byte _value)
        {
            CancelStatusEnum _result = CancelStatusEnum.Normal;

            switch (_value)
            {
                case 0:
                    _result = CancelStatusEnum.Normal;
                    break;
                case 1:
                    _result = CancelStatusEnum.WaitingForCancel;
                    break;
                case 2:
                    _result = CancelStatusEnum.Cancelled;
                    break;
                default:
                    break;
            }

            return _result;
        }

        public static Byte GetCancelStatus(CancelStatusEnum _value)
        {
            Byte _result = 0;

            switch (_value)
            {
                case CancelStatusEnum.Normal:
                    _result = 0;
                    break;
                case CancelStatusEnum.WaitingForCancel:
                    _result = 1;
                    break;
                case CancelStatusEnum.Cancelled:
                    _result = 2;
                    break;
                default:
                    _result = 0;
                    break;
            }

            return _result;
        }

        public static String GetCancelStatusText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 0:
                    _result = "Normal";
                    break;
                case 1:
                    _result = "Waiting For Cancel";
                    break;
                case 2:
                    _result = "Cancelled";
                    break;
                default:
                    _result = "Normal";
                    break;
            }

            return _result;
        }

        public static String GetCancelStatusText(CancelStatusEnum _value)
        {
            String _result = "";

            switch (_value)
            {
                case CancelStatusEnum.Normal:
                    _result = "Normal";
                    break;
                case CancelStatusEnum.WaitingForCancel:
                    _result = "Waiting For Cancel";
                    break;
                case CancelStatusEnum.Cancelled:
                    _result = "Cancelled";
                    break;
                default:
                    _result = "Normal";
                    break;
            }

            return _result;
        }
    }
}
