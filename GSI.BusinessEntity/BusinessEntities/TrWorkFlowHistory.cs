using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrWorkFlowHistory
    {
        public TrWorkFlowHistory()
        {
        }

        public TrWorkFlowHistory(System.String action, System.String actor, System.String createdBy, System.DateTime createdDate, Nullable<System.DateTime> date, System.Int64 historyID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.actionField = action;
            this.actorField = actor;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.dateField = date;
            this.historyIDField = historyID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderIDField = orderID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.String actionField;

        public System.String Action
        {
            get { return this.actionField; }
            set { this.actionField = value; }
        }

        private System.String actorField;

        public System.String Actor
        {
            get { return this.actorField; }
            set { this.actorField = value; }
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

        private Nullable<System.DateTime> dateField;

        public Nullable<System.DateTime> Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }

        private System.Int64 historyIDField;

        public System.Int64 HistoryID
        {
            get { return this.historyIDField; }
            set { this.historyIDField = value; }
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

        private System.Int64 orderIDField;

        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
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

