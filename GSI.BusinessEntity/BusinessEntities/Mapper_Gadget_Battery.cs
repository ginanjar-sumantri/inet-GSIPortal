using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class Mapper_Gadget_Battery
    {
        public Mapper_Gadget_Battery()
        {
        }

        public Mapper_Gadget_Battery(System.Int64 batteryID, System.String createdBy, System.DateTime createdDate, System.Int64 gadgetID, System.Int64 mapper_Gadget_BatteryID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.batteryIDField = batteryID;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.gadgetIDField = gadgetID;
            this.mapper_Gadget_BatteryIDField = mapper_Gadget_BatteryID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.Int64 batteryIDField;

        public System.Int64 BatteryID
        {
            get { return this.batteryIDField; }
            set { this.batteryIDField = value; }
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

        private System.Int64 gadgetIDField;

        public System.Int64 GadgetID
        {
            get { return this.gadgetIDField; }
            set { this.gadgetIDField = value; }
        }

        private System.Int64 mapper_Gadget_BatteryIDField;

        public System.Int64 Mapper_Gadget_BatteryID
        {
            get { return this.mapper_Gadget_BatteryIDField; }
            set { this.mapper_Gadget_BatteryIDField = value; }
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

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

