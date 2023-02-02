using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSI.DataMapping
{
    public static class BrandTypeMapper
    {
        private static List<String> _brandType = new List<String>()
        {
            "1,Gadget",
            "2,Battery",
        };

        public static List<String> BrandTypes
        {
            get { return _brandType; }
        }

        public static String GetBrandTypeText(Byte _value)
        {
            String _result = "";

            switch (_value)
            {
                case 1:
                    _result = "Gadget";
                    break;
                case 2:
                    _result = "Battery";
                    break;
                default:
                    _result = "Gadget";
                    break;
            }

            return _result;
        }
    }
}
