using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace GSI.Common
{
    public class Base
    {
        protected String _DBName = "DBConn";
        protected Database db = null;

        protected Base()
        {
            this.db = DatabaseFactory.CreateDatabase(this._DBName);            
        }
    }
}
