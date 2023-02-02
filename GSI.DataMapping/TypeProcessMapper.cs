using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class TypeProcessMapper
    {
        #region Process
        public static TypeProcess GetTypeProcess(Byte _prmValue)
        {
            TypeProcess _result = TypeProcess.PreProcess;

            switch (_prmValue)
            {                
                case 1:
                    _result = TypeProcess.PreProcess;
                    break;
                case 2:
                    _result = TypeProcess.SurveyProcess;
                    break;
                case 3:
                    _result = TypeProcess.AfterProcess;
                    break;                
            }
            return _result;
        }

        public static String GetTypeProcessText(Byte _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {                
                case 1:
                    _result = "Pre Process";
                    break;
                case 2:
                    _result = "Survey Process";
                    break;
                case 3:
                    _result = "After Process";
                    break;                
                default:
                    _result = "Pre Process";
                    break;
            }

            return _result;
        }

        public static Byte GetTypeProcess(TypeProcess _prmValue)
        {
            Byte _result = 0;

            switch (_prmValue)
            {
                case TypeProcess.PreProcess:
                    _result = 1;
                    break;
                case TypeProcess.SurveyProcess:
                    _result = 2;
                    break;
                case TypeProcess.AfterProcess:
                    _result = 3;
                    break;                
                default:
                    _result = 1;
                    break;
            }
            
            return _result;
        }
        #endregion
       
    }
}
