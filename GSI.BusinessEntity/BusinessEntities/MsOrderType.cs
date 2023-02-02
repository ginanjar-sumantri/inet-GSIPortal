using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsOrderType
    {
        public MsOrderType()
        {
        }

        public MsOrderType(System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderTypeID, System.String orderTypeName, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderTypeIDField = orderTypeID;
            this.orderTypeNameField = orderTypeName;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
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

        private System.Int64 orderTypeIDField;

        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
        }

        private System.String orderTypeNameField;

        public System.String OrderTypeName
        {
            get { return this.orderTypeNameField; }
            set { this.orderTypeNameField = value; }
        }

        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

