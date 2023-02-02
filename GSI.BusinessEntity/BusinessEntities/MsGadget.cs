using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsGadget
    {
        public MsGadget()
        {
        }

        public MsGadget(System.Int64 brandID, System.String createdBy, System.DateTime createdDate, System.String gadgetCode, System.Int64 gadgetID, System.String gadgetName, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String noIMEI, System.String remark, System.Int32 rowStatus, System.Int64 sIMCardID, System.Byte[] timestamp)
        {
            this.brandIDField = brandID;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.gadgetCodeField = gadgetCode;
            this.gadgetIDField = gadgetID;
            this.gadgetNameField = gadgetName;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.noIMEIField = noIMEI;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.sIMCardIDField = sIMCardID;
            this.timestampField = timestamp;
        }

        private System.Int64 brandIDField;

        public System.Int64 BrandID
        {
            get { return this.brandIDField; }
            set { this.brandIDField = value; }
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

        private System.String gadgetCodeField;

        public System.String GadgetCode
        {
            get { return this.gadgetCodeField; }
            set { this.gadgetCodeField = value; }
        }

        private System.Int64 gadgetIDField;

        public System.Int64 GadgetID
        {
            get { return this.gadgetIDField; }
            set { this.gadgetIDField = value; }
        }

        private System.String gadgetNameField;

        public System.String GadgetName
        {
            get { return this.gadgetNameField; }
            set { this.gadgetNameField = value; }
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

        private System.String noIMEIField;

        public System.String NoIMEI
        {
            get { return this.noIMEIField; }
            set { this.noIMEIField = value; }
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

        private System.Int64 sIMCardIDField;

        public System.Int64 SIMCardID
        {
            get { return this.sIMCardIDField; }
            set { this.sIMCardIDField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

