using System;
using GSI.Common.Enum;

namespace GSI.DataMapping
{
    public static class PointSurveyMapper
    {
        public static String GetTemplateFormPath(int _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 0:
                    _result = "AddPersonalRespondent.aspx";
                    break;
                case 1:
                    _result = "AddOfficeRespondent.aspx";
                    break;
                default:
                    _result = "AddPersonalRespondent.aspx";
                    break;
            }

            return _result;
        }

        public static String GetTemplateFormPathForViewResult(int _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 0:
                    _result = "ViewResultPersonal.aspx";
                    break;
                case 1:
                    _result = "ViewResultCompany.aspx";
                    break;
                default:
                    _result = "ViewResultPersonal.aspx";
                    break;
            }

            return _result;
        }

        public static String GetPointSurveyName(int _prmValue)
        {
            String _result = "";

            switch (_prmValue)
            {
                case 1:
                    _result = "Guarantor";
                    break;
                case 2:
                    _result = "Individual";
                    break;
                case 3:
                    _result = "Office";
                    break;
                case 4:
                    _result = "House";
                    break;
                default:
                    _result = "Guarantor";
                    break;
            }

            return _result;
        }

        public static long GetSurveyPointMapper(SurveyPointMapper _value)
        {
            long _result = 0;

            switch (_value)
            {
                case SurveyPointMapper.Guarantor:
                    _result = 1;
                    break;
                case SurveyPointMapper.Originator:
                    _result = 2;
                    break;
                case SurveyPointMapper.Office:
                    _result = 3;
                    break;
                case SurveyPointMapper.House:
                    _result = 4;
                    break;
                default:
                    break;
            }

            return _result;
        }

        public static SurveyPointMapper GetSurveyPointMapper(long _value)
        {
            SurveyPointMapper _result = SurveyPointMapper.Guarantor;

            switch (_value)
            {
                case 1:
                    _result = SurveyPointMapper.Guarantor;
                    break;
                case 2:
                    _result = SurveyPointMapper.Originator;
                    break;
                case 3:
                    _result = SurveyPointMapper.Office;
                    break;
                case 4:
                    _result = SurveyPointMapper.House;
                    break;
                default:
                    break;
            }

            return _result;
        }
    }
}
