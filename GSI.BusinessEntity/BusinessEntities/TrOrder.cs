using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrOrder
    {
        public TrOrder()
        {
        }

        public TrOrder(System.String createdBy, System.DateTime createdDate, System.Int64 customerID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String orderCode, System.DateTime orderDate, System.Int64 orderID, System.Byte orderStatus, System.Int64 orderTypeID, System.Byte orderVersion, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.customerIDField = customerID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderCodeField = orderCode;
            this.orderDateField = orderDate;
            this.orderIDField = orderID;
            this.orderStatusField = orderStatus;
            this.orderTypeIDField = orderTypeID;
            this.orderVersionField = orderVersion;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        public DateTime ProceedDate { get; set; }

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

        private System.Int64 customerIDField;

        public System.Int64 CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
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

        private System.String orderCodeField;

        public System.String OrderCode
        {
            get { return this.orderCodeField; }
            set { this.orderCodeField = value; }
        }

        private System.DateTime orderDateField;

        public System.DateTime OrderDate
        {
            get { return this.orderDateField; }
            set { this.orderDateField = value; }
        }

        private System.Int64 orderIDField;

        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Byte orderStatusField;

        public System.Byte OrderStatus
        {
            get { return this.orderStatusField; }
            set { this.orderStatusField = value; }
        }

        private System.Int64 orderTypeIDField;

        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
        }

        private System.Byte orderVersionField;

        public System.Byte OrderVersion
        {
            get { return this.orderVersionField; }
            set { this.orderVersionField = value; }
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

