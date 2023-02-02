using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrResultNotMovable
    {
        public TrResultNotMovable()
        {
        }

        //public TrResultNotMovable(System.String businessLine, System.String companyCondition, System.String companyPeriod, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String others, System.String remark, System.Int64 resultNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.Int64 workOrderNotMovableID)
        public TrResultNotMovable(System.String businessLine, 
            System.String companyCondition, System.String companyPeriod, 
            System.String createdBy, System.DateTime createdDate, 
            System.String modifiedBy, Nullable<System.DateTime> modifiedDate, 
            System.String remark, System.Int64 resultNotMovableID, 
            System.Int32 rowStatus, System.Byte[] timestamp, System.Int64 workOrderNotMovableID,
            System.String position, System.String workingPeriod)
        {
            //this.businessLineField = businessLine;
            this.companyConditionField = companyCondition;
            this.companyPeriodField = companyPeriod;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            //this.othersField = others;
            this.remarkField = remark;
            this.resultNotMovableIDField = resultNotMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.workOrderNotMovableIDField = workOrderNotMovableID;
            this.positionField = position;
            this.workingPeriodField = workingPeriod;
        }

        //private System.String businessLineField;

        //public System.String BusinessLine
        //{
        //    get { return this.businessLineField; }
        //    set { this.businessLineField = value; }
        //}

        private System.String companyConditionField;

        public System.String CompanyCondition
        {
            get { return this.companyConditionField; }
            set { this.companyConditionField = value; }
        }

        private System.String companyPeriodField;

        public System.String CompanyPeriod
        {
            get { return this.companyPeriodField; }
            set { this.companyPeriodField = value; }
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

        //private System.String othersField;

        //public System.String Others
        //{
        //    get { return this.othersField; }
        //    set { this.othersField = value; }
        //}

        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 resultNotMovableIDField;

        public System.Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableIDField; }
            set { this.resultNotMovableIDField = value; }
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

        private System.Int64 workOrderNotMovableIDField;

        public System.Int64 WorkOrderNotMovableID
        {
            get { return this.workOrderNotMovableIDField; }
            set { this.workOrderNotMovableIDField = value; }
        }

        private System.String positionField;

        public System.String Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        private System.String workingPeriodField;

        public System.String WorkingPeriod
        {
            get { return this.workingPeriodField; }
            set { this.workingPeriodField = value; }
        }
    }
}

