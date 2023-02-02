using System;
using System.Data;

namespace GSI.Common
{
    public static class RequestVariable
    {
        private static Int32 _rowCount;
        public static Int32 RowCount
        {
            get { return _rowCount; }
            set { _rowCount = value; }
        }

        private static DateTime _time;
        public static DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
