using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSI.DataMapping
{
    public static class BatteryTypeMapper
    {
        private static List<String> _batteryType = new List<String>()
        {
            "1,Internal",
            "2,External",
        };

        public static List<String> BatteryTypes
        {
            get { return _batteryType; }
        }

        public static String GetBatteryTypeText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 1:
                    _result = "Internal";
                    break;
                case 2:
                    _result = "External";
                    break;
                default:
                    _result = "Internal";
                    break;
            }

            return _result;
        }
    }
}
