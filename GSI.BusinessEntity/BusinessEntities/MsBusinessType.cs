using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsBusinessType
    {
        public MsBusinessType()
        {
        }

        public MsBusinessType(System.String businessTypeCode, System.Int64 businessTypeID, System.String businessTypeName, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.businessTypeCodeField = businessTypeCode;
            this.businessTypeIDField = businessTypeID;
            this.businessTypeNameField = businessTypeName;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.String businessTypeCodeField;

        public System.String BusinessTypeCode
        {
            get { return this.businessTypeCodeField; }
            set { this.businessTypeCodeField = value; }
        }

        private System.Int64 businessTypeIDField;

        public System.Int64 BusinessTypeID
        {
            get { return this.businessTypeIDField; }
            set { this.businessTypeIDField = value; }
        }

        private System.String businessTypeNameField;

        public System.String BusinessTypeName
        {
            get { return this.businessTypeNameField; }
            set { this.businessTypeNameField = value; }
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

