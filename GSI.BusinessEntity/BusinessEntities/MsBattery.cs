using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsBattery
    {
        public MsBattery()
        {
        }

        public MsBattery(System.Int32 ampere, System.String batteryCode, System.Int64 batteryID, System.String batteryName, System.Byte batteryType, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark, System.Int32 rowStatus, System.String serialNumber, System.Byte[] timestamp)
        {
            this.ampereField = ampere;
            this.batteryCodeField = batteryCode;
            this.batteryIDField = batteryID;
            this.batteryNameField = batteryName;
            this.batteryTypeField = batteryType;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.serialNumberField = serialNumber;
            this.timestampField = timestamp;
        }

        private System.Int32 ampereField;

        public System.Int32 Ampere
        {
            get { return this.ampereField; }
            set { this.ampereField = value; }
        }

        private System.String batteryCodeField;

        public System.String BatteryCode
        {
            get { return this.batteryCodeField; }
            set { this.batteryCodeField = value; }
        }

        private System.Int64 batteryIDField;

        public System.Int64 BatteryID
        {
            get { return this.batteryIDField; }
            set { this.batteryIDField = value; }
        }

        private System.String batteryNameField;

        public System.String BatteryName
        {
            get { return this.batteryNameField; }
            set { this.batteryNameField = value; }
        }

        private System.Byte batteryTypeField;

        public System.Byte BatteryType
        {
            get { return this.batteryTypeField; }
            set { this.batteryTypeField = value; }
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

        private System.String serialNumberField;

        public System.String SerialNumber
        {
            get { return this.serialNumberField; }
            set { this.serialNumberField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

