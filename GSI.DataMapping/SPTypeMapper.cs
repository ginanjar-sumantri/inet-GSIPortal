using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class SPTypeMapper
    {
        public static String GetSPType(SurveyPointType _value)
        {
            String _result = "";

            switch (_value)
            {
                case SurveyPointType.Movable:
                    _result = "MOV";
                    break;
                case SurveyPointType.NotMovable:
                    _result = "NMOV";
                    break;
                default:
                    break;
            }

            return _result;
        }
    }
}
