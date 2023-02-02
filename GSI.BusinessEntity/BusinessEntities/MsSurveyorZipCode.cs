using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsSurveyorZipCode
    {
        public MsSurveyorZipCode()
        {
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

        private System.Int32 rowStatusField;

        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Int64 surveyorZipCodeIDField;

        public System.Int64 SurveyorZipCodeID
        {
            get { return this.surveyorZipCodeIDField; }
            set { this.surveyorZipCodeIDField = value; }
        }

        private System.Int64 surveyorIDField;

        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.String ZipCodeField;

        public System.String ZipCode
        {
            get { return this.ZipCodeField; }
            set { this.ZipCodeField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }
    }
}

