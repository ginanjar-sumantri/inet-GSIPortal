using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsBrand
    {
        public MsBrand()
        {
        }

        public MsBrand(System.String brandCode, System.Int64 brandID, System.String brandName, Nullable<System.Byte> brandType, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark, Nullable<System.Int32> rowStatus, System.Byte[] timestamp)
        {
            this.brandCodeField = brandCode;
            this.brandIDField = brandID;
            this.brandNameField = brandName;
            this.brandTypeField = brandType;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.String brandCodeField;

        public System.String BrandCode
        {
            get { return this.brandCodeField; }
            set { this.brandCodeField = value; }
        }

        private System.Int64 brandIDField;

        public System.Int64 BrandID
        {
            get { return this.brandIDField; }
            set { this.brandIDField = value; }
        }

        private System.String brandNameField;

        public System.String BrandName
        {
            get { return this.brandNameField; }
            set { this.brandNameField = value; }
        }

        private Nullable<System.Byte> brandTypeField;

        public Nullable<System.Byte> BrandType
        {
            get { return this.brandTypeField; }
            set { this.brandTypeField = value; }
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

        private Nullable<System.Int32> rowStatusField;

        public Nullable<System.Int32> RowStatus
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

