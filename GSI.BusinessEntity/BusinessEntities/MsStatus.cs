using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsStatus
    {
        public MsStatus()
        {
        }

        public MsStatus(System.String createdBy, System.DateTime createdDate, System.String description, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int32 rowStatus, System.String statusCode, System.Int64 statusID, System.Byte[] timestamp, System.String transCode)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.descriptionField = description;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.rowStatusField = rowStatus;
            this.statusCodeField = statusCode;
            this.statusIDField = statusID;
            this.timestampField = timestamp;
            this.transCodeField = transCode;
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

        private System.String descriptionField;

        public System.String Description
        {
            get { return this.descriptionField; }
            set { this.descriptionField = value; }
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

        private System.Int32 rowStatusField;

        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.String statusCodeField;

        public System.String StatusCode
        {
            get { return this.statusCodeField; }
            set { this.statusCodeField = value; }
        }

        private System.Int64 statusIDField;

        public System.Int64 StatusID
        {
            get { return this.statusIDField; }
            set { this.statusIDField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String transCodeField;

        public System.String TransCode
        {
            get { return this.transCodeField; }
            set { this.transCodeField = value; }
        }

    }
}

