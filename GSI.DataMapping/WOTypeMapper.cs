using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class WOTypeMapper
    {
        public static WOTypeEnum GetWOType(Byte _value)
        {
            WOTypeEnum _result = WOTypeEnum.Normal;

            switch (_value)
            {
                case 0:
                    _result = WOTypeEnum.Normal;
                    break;
                case 1:
                    _result = WOTypeEnum.Correction;
                    break;
                case 2:
                    _result = WOTypeEnum.Complaint;
                    break;
                default:
                    break;
            }

            return _result;
        }

        public static Byte GetWOType(WOTypeEnum _value)
        {
            Byte _result = 0;

            switch (_value)
            {
                case WOTypeEnum.Normal:
                    _result = 0;
                    break;
                case WOTypeEnum.Correction:
                    _result = 1;
                    break;
                case WOTypeEnum.Complaint:
                    _result = 2;
                    break;
                default:
                    _result = 0;
                    break;
            }

            return _result;
        }

        public static String GetWOTypeText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 0:
                    _result = "Normal";
                    break;
                case 1:
                    _result = "Correction";
                    break;
                case 2:
                    _result = "Complaint";
                    break;
                default:
                    _result = "Normal";
                    break;
            }

            return _result;
        }

        public static String GetWOTypeText(WOTypeEnum _value)
        {
            String _result = "";

            switch (_value)
            {
                case WOTypeEnum.Normal:
                    _result = "Normal";
                    break;
                case WOTypeEnum.Correction:
                    _result = "Correction";
                    break;
                case WOTypeEnum.Complaint:
                    _result = "Complaint";
                    break;
                default:
                    _result = "Normal";
                    break;
            }

            return _result;
        }
    }
}
