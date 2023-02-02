using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class Mapper_OrderType_SurveyPoint
    {
        public Mapper_OrderType_SurveyPoint()
        {
        }

        public Mapper_OrderType_SurveyPoint(System.String createdBy, System.DateTime createdDate, System.Int64 mapper_OrderType_SurveyPointID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderTypeID, System.String remark, System.Int32 rowStatus, System.Int64 surveyPointID, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.mapper_OrderType_SurveyPointIDField = mapper_OrderType_SurveyPointID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderTypeIDField = orderTypeID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyPointIDField = surveyPointID;
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

        private System.Int64 mapper_OrderType_SurveyPointIDField;

        public System.Int64 Mapper_OrderType_SurveyPointID
        {
            get { return this.mapper_OrderType_SurveyPointIDField; }
            set { this.mapper_OrderType_SurveyPointIDField = value; }
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

        private System.Int64 orderTypeIDField;

        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
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

        private System.Int64 surveyPointIDField;

        public System.Int64 SurveyPointID
        {
            get { return this.surveyPointIDField; }
            set { this.surveyPointIDField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

