using System;
using System.Data;

namespace GSI.Common
{
    public class SPParam
    {
        public SPParam()
        {
        }

        public SPParam(String _prmKey, Object _prmValue, DbType _prmDataType)
        {
            this.Key = _prmKey;
            this.Value = _prmValue;
            this.DataType = _prmDataType;
        }

        private String _key;
        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        private DbType _dataType;
        public DbType DataType
        {
            get { return this._dataType; }
            set { this._dataType = value; }
        }

        private Object _value;
        public Object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        ~SPParam()
        {
        }
    }

    public class SPParamDelete
    {
        public SPParamDelete()
        {
        }

        public SPParamDelete(String _prmKey, Object _prmValue, SqlDbType _prmDataType)
        {
            this.Key = _prmKey;
            this.Value = _prmValue;
            this.DataType = _prmDataType;
        }

        private String _key;
        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        private SqlDbType _dataType;
        public SqlDbType DataType
        {
            get { return this._dataType; }
            set { this._dataType = value; }
        }

        private Object _value;
        public Object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        ~SPParamDelete()
        {
        }
    }

    public class SPParamOut
    {
        public SPParamOut()
        {
        }

        public SPParamOut(String _prmKey, Object _prmValue, DbType _prmDataType)
        {
            this.Key = _prmKey;
            this.Value = _prmValue;
            this.DataType = _prmDataType;
        }

        private String _key;
        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        private DbType _dataType;
        public DbType DataType
        {
            get { return this._dataType; }
            set { this._dataType = value; }
        }

        private Object _value;
        public Object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        ~SPParamOut()
        {
        }
    }
}
