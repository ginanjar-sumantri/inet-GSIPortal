using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsSurveyor
    {
        public MsSurveyor()
        {
        }

        public MsSurveyor(System.String createdBy, System.DateTime createdDate, System.Int64 employeeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 regionID, System.String remark, System.Int32 rowStatus, System.String surveyorCode, System.Int64 surveyorID, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.employeeIDField = employeeID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.regionIDField = regionID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyorCodeField = surveyorCode;
            this.surveyorIDField = surveyorID;
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

        private System.Int64 employeeIDField;

        public System.Int64 EmployeeID
        {
            get { return this.employeeIDField; }
            set { this.employeeIDField = value; }
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

        private System.Int64 regionIDField;

        public System.Int64 RegionID
        {
            get { return this.regionIDField; }
            set { this.regionIDField = value; }
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

        private System.String surveyorCodeField;

        public System.String SurveyorCode
        {
            get { return this.surveyorCodeField; }
            set { this.surveyorCodeField = value; }
        }

        private System.Int64 surveyorIDField;

        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

