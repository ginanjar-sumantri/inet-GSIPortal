using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsSIMCard
    {
        public MsSIMCard()
        {
        }

        public MsSIMCard(System.String createdBy, System.DateTime createdDate, Nullable<System.Int32> internetPulsa, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<System.Int32> noCheckPulsa, System.Int64 operatorID, Nullable<System.Int32> phonePulsa, System.String remark, System.Int32 rowStatus, System.String sIMCardCode, System.Int64 sIMCardID, System.String sIMCardNumber, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.internetPulsaField = internetPulsa;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.noCheckPulsaField = noCheckPulsa;
            this.operatorIDField = operatorID;
            this.phonePulsaField = phonePulsa;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.sIMCardCodeField = sIMCardCode;
            this.sIMCardIDField = sIMCardID;
            this.sIMCardNumberField = sIMCardNumber;
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

        private Nullable<System.Int32> internetPulsaField;

        public Nullable<System.Int32> InternetPulsa
        {
            get { return this.internetPulsaField; }
            set { this.internetPulsaField = value; }
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

        private Nullable<System.Int32> noCheckPulsaField;

        public Nullable<System.Int32> NoCheckPulsa
        {
            get { return this.noCheckPulsaField; }
            set { this.noCheckPulsaField = value; }
        }

        private System.Int64 operatorIDField;

        public System.Int64 OperatorID
        {
            get { return this.operatorIDField; }
            set { this.operatorIDField = value; }
        }

        private Nullable<System.Int32> phonePulsaField;

        public Nullable<System.Int32> PhonePulsa
        {
            get { return this.phonePulsaField; }
            set { this.phonePulsaField = value; }
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

        private System.String sIMCardCodeField;

        public System.String SIMCardCode
        {
            get { return this.sIMCardCodeField; }
            set { this.sIMCardCodeField = value; }
        }

        private System.Int64 sIMCardIDField;

        public System.Int64 SIMCardID
        {
            get { return this.sIMCardIDField; }
            set { this.sIMCardIDField = value; }
        }

        private System.String sIMCardNumberField;

        public System.String SIMCardNumber
        {
            get { return this.sIMCardNumberField; }
            set { this.sIMCardNumberField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

