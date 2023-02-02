using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class OrderVersionMapper
    {
        public static Byte GetOrderVersion(OrderVersion _value)
        {
            Byte _result = 0;

            switch (_value)
            {
                case OrderVersion.Draft:
                    _result = 0;
                    break;
                case OrderVersion.Final:
                    _result = 1;
                    break;
                default:
                    break;
            }

            return _result;
        }

        public static OrderVersion GetOrderVersion(Byte _value)
        {
            OrderVersion _result = OrderVersion.Draft;

            switch (_value)
            {
                case 0:
                    _result = OrderVersion.Draft;
                    break;
                case 1:
                    _result = OrderVersion.Final;
                    break;
                default:
                    break;
            }

            return _result;
        }

        public static String GetOrderVersionText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 0:
                    _result = "Draft";
                    break;
                case 1:
                    _result = "Final";
                    break;
                default:
                    break;
            }

            return _result;
        }
    }
}
