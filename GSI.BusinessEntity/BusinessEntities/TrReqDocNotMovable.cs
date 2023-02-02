using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrReqDocNotMovable
    {
        public TrReqDocNotMovable()
        {
        }

        public TrReqDocNotMovable(System.String createdBy, System.DateTime createdDate, System.Int64 documentTypeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderSPNotMovableID, System.String remark, System.Int64 reqDocNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.documentTypeIDField = documentTypeID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderSPNotMovableIDField = orderSPNotMovableID;
            this.remarkField = remark;
            this.reqDocNotMovableIDField = reqDocNotMovableID;
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

        private System.Int64 documentTypeIDField;

        public System.Int64 DocumentTypeID
        {
            get { return this.documentTypeIDField; }
            set { this.documentTypeIDField = value; }
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

        private System.Int64 orderSPNotMovableIDField;

        public System.Int64 OrderSPNotMovableID
        {
            get { return this.orderSPNotMovableIDField; }
            set { this.orderSPNotMovableIDField = value; }
        }

        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocNotMovableIDField;

        public System.Int64 ReqDocNotMovableID
        {
            get { return this.reqDocNotMovableIDField; }
            set { this.reqDocNotMovableIDField = value; }
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

