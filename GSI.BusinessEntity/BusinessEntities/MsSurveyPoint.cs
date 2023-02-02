using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsSurveyPoint
    {
        public MsSurveyPoint()
        {
        }

        public MsSurveyPoint(System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark, System.Int32 rowStatus, System.Int64 surveyPointID, System.String surveyPointName, Nullable<System.Int32> templateForm, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyPointIDField = surveyPointID;
            this.surveyPointNameField = surveyPointName;
            this.templateFormField = templateForm;
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

        private System.Int64 surveyPointIDField;

        public System.Int64 SurveyPointID
        {
            get { return this.surveyPointIDField; }
            set { this.surveyPointIDField = value; }
        }

        private System.String surveyPointNameField;

        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private Nullable<System.Int32> templateFormField;

        public Nullable<System.Int32> TemplateForm
        {
            get { return this.templateFormField; }
            set { this.templateFormField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}

