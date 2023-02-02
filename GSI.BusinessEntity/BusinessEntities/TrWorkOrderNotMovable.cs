using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrWorkOrderNotMovable
    {
        public TrWorkOrderNotMovable()
        {
        }

        public TrWorkOrderNotMovable(System.String createdBy, System.DateTime createdDate, System.DateTime dateCreate, Nullable<System.DateTime> dateExecute, Nullable<System.DateTime> downloadDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<System.DateTime> onTheSpotDate, Nullable<System.DateTime> onTheWayDate, System.Int64 orderSPNotMovableID, System.String remark, System.Int32 rowStatus, System.Int64 surveyorID, System.Boolean syncStatus, System.Byte[] timestamp, System.String workOrderCode, System.Int64 workOrderNotMovableID, System.Byte workOrderStatusID)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.dateCreateField = dateCreate;
            this.dateExecuteField = dateExecute;
            this.downloadDateField = downloadDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.onTheSpotDateField = onTheSpotDate;
            this.onTheWayDateField = onTheWayDate;
            this.orderSPNotMovableIDField = orderSPNotMovableID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyorIDField = surveyorID;
            this.syncStatusField = syncStatus;
            this.timestampField = timestamp;
            this.workOrderCodeField = workOrderCode;
            this.workOrderNotMovableIDField = workOrderNotMovableID;
            this.workOrderStatusIDField = workOrderStatusID;
        }

        public Byte WOType { get; set; }

        public Int64 WORef { get; set; }

        public DateTime SurveyResultReceivedDate { get; set; }

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

        private System.DateTime dateCreateField;

        public System.DateTime DateCreate
        {
            get { return this.dateCreateField; }
            set { this.dateCreateField = value; }
        }

        private Nullable<System.DateTime> dateExecuteField;

        public Nullable<System.DateTime> DateExecute
        {
            get { return this.dateExecuteField; }
            set { this.dateExecuteField = value; }
        }

        private Nullable<System.DateTime> downloadDateField;

        public Nullable<System.DateTime> DownloadDate
        {
            get { return this.downloadDateField; }
            set { this.downloadDateField = value; }
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

        private Nullable<System.DateTime> onTheSpotDateField;

        public Nullable<System.DateTime> OnTheSpotDate
        {
            get { return this.onTheSpotDateField; }
            set { this.onTheSpotDateField = value; }
        }

        private Nullable<System.DateTime> onTheWayDateField;

        public Nullable<System.DateTime> OnTheWayDate
        {
            get { return this.onTheWayDateField; }
            set { this.onTheWayDateField = value; }
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

        private System.Int32 rowStatusField;

        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Int64 surveyorIDField;

        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.Boolean syncStatusField;

        public System.Boolean SyncStatus
        {
            get { return this.syncStatusField; }
            set { this.syncStatusField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String workOrderCodeField;

        public System.String WorkOrderCode
        {
            get { return this.workOrderCodeField; }
            set { this.workOrderCodeField = value; }
        }

        private System.Int64 workOrderNotMovableIDField;

        public System.Int64 WorkOrderNotMovableID
        {
            get { return this.workOrderNotMovableIDField; }
            set { this.workOrderNotMovableIDField = value; }
        }

        private System.Byte workOrderStatusIDField;

        public System.Byte WorkOrderStatusID
        {
            get { return this.workOrderStatusIDField; }
            set { this.workOrderStatusIDField = value; }
        }

    }
}

