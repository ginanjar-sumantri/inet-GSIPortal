using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class TimeFrameDurationMapper
    {
        public static String GetTimeFrame(TimeFrame _value)
        {
            String _result = "0";

            switch (_value)
            {
                case TimeFrame.LessThanOneHour:
                    _result = "1";
                    break;
                case TimeFrame.OneToTwoHour:
                    _result = "2";
                    break;
                case TimeFrame.MoreThanTwoHour:
                    _result = "3";
                    break;
                default:
                    _result = "1";
                    break;
            }

            return _result;
        }

        public static TimeFrame GetTimeFrame(String _value)
        {
            TimeFrame _result = TimeFrame.LessThanOneHour;

            switch (_value)
            {
                case "1":
                    _result = TimeFrame.LessThanOneHour;
                    break;
                case "2":
                    _result = TimeFrame.OneToTwoHour;
                    break;
                case "3":
                    _result = TimeFrame.MoreThanTwoHour;
                    break;
                default:
                    _result = TimeFrame.LessThanOneHour;
                    break;
            }

            return _result;
        }

        public static String GetTimeFrameString(String _value)
        {
            String _result = "";

            switch (_value)
            {
                case "1":
                    _result = "< 1 Hour";
                    break;
                case "2":
                    _result = "1 - 2 Hour";
                    break;
                case "3":
                    _result = "> 2 Hour";
                    break;
                default:
                    _result = "";
                    break;
            }

            return _result;
        }
    }
}
