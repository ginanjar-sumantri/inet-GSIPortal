using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class Gen_LoginHistory
    {
        public Gen_LoginHistory()
        {
        }

        public Gen_LoginHistory(System.Int64 loginHistoryID, System.String iPAddress, System.String userName, System.DateTime date, System.Int32 rowStatus, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, System.DateTime modifiedDate, System.Byte[] timestamp)
        {
            this.loginHistoryIDField = loginHistoryID;
            this.iPAddressField = iPAddress;
            this.userNameField = userName;
            this.dateField = date;
            this.rowStatusField = rowStatus;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.timestampField = timestamp;
        }

        private System.Int64 loginHistoryIDField;

        public System.Int64 LoginHistoryID
        {
            get { return this.loginHistoryIDField; }
            set { this.loginHistoryIDField = value; }
        }

        private System.String iPAddressField;

        public System.String IPAddress
        {
            get { return this.iPAddressField; }
            set { this.iPAddressField = value; }
        }

        private System.String userNameField;

        public System.String UserName
        {
            get { return this.userNameField; }
            set { this.userNameField = value; }
        }

        private System.DateTime dateField;

        public System.DateTime Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }

        private System.Int32 rowStatusField;

        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.String createdByField;

        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

