using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrReqDocMovable
    {
        public TrReqDocMovable()
        {
        }

        public TrReqDocMovable(System.String createdBy, System.DateTime createdDate, System.Int64 documentTypeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderSPMovableID, System.String remark, System.Int64 reqDocMovableID, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.documentTypeIDField = documentTypeID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderSPMovableIDField = orderSPMovableID;
            this.remarkField = remark;
            this.reqDocMovableIDField = reqDocMovableID;
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

        private System.Int64 orderSPMovableIDField;

        public System.Int64 OrderSPMovableID
        {
            get { return this.orderSPMovableIDField; }
            set { this.orderSPMovableIDField = value; }
        }

        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocMovableIDField;

        public System.Int64 ReqDocMovableID
        {
            get { return this.reqDocMovableIDField; }
            set { this.reqDocMovableIDField = value; }
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

