using System;
using System.Collections.Generic;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class IDTypeMapper
    {
        private static List<String> _IDType = new List<String>()
        {
            //id, text, format
            "1,ID Card,0",
            "2,Passport,1",
            "3,Driving License,0",
            "4,KIMS,1"
        };

        public static List<String> IDTypes
        {
            get { return _IDType; }
        }

        public static string GetIDFormat(FormatTextBox _value)
        {
            string _result = "0";

            switch (_value)
            {
                case FormatTextBox.AllowDot:
                    _result = "0";
                    break;
                case FormatTextBox.AllowAlphabet:
                    _result = "1";
                    break;
            }
            return _result;
        }

        public static String GetIDTypeText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 1:
                    _result = "ID Card";
                    break;
                case 2:
                    _result = "Passport";
                    break;
                case 3:
                    _result = "Driving License";
                    break;
                case 4:
                    _result = "KIMS";
                    break;
                default:
                    _result = "ID Card";
                    break;
            }

            return _result;
        }
    }
}
