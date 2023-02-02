using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class OrderMapper
    {
        public static String GetOrderTypeName(long _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 0:
                    _result = "Personal";
                    break;
                case 1:
                    _result = "Corporate";
                    break;
                default:
                    _result = "Personal";
                    break;
            }

            return _result;
        }

        public static long GetOrderType(OrderType _value)
        {
            Int64 _result = 0;

            switch (_value)
            {
                case OrderType.Personal:
                    _result = 0;
                    break;
                case OrderType.Corporate:
                    _result = 1;
                    break;
                default:
                    break;
            }

            return _result;
        }
    }
}
