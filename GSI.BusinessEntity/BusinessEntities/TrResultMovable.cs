using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrResultMovable
    {
        public TrResultMovable()
        {
        }

        //public TrResultMovable(System.String buildingArea, System.String createdBy, System.DateTime createdDate, System.String environmentalConditions, System.String houseStatus, System.String lengthOfStay, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String others, System.String personalCharacter, System.String position, System.String remark, System.String residenceConditions, System.Int64 resultMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.String workingPeriod, System.Int64 workOrderMovableID)
        public TrResultMovable(System.String buildingArea, System.String createdBy, System.DateTime createdDate, System.String environmentalConditions, System.String houseStatus, System.String lengthOfStay, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String personalCharacter, System.String remark, System.String residenceConditions, System.Int64 resultMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.Int64 workOrderMovableID)
        {
            this.buildingAreaField = buildingArea;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.environmentalConditionsField = environmentalConditions;
            this.houseStatusField = houseStatus;
            this.lengthOfStayField = lengthOfStay;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            //this.othersField = others;
            this.personalCharacterField = personalCharacter;            
            this.remarkField = remark;
            this.residenceConditionsField = residenceConditions;
            this.resultMovableIDField = resultMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;            
            this.workOrderMovableIDField = workOrderMovableID;
        }

        private System.String buildingAreaField;

        public System.String BuildingArea
        {
            get { return this.buildingAreaField; }
            set { this.buildingAreaField = value; }
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

        private System.String environmentalConditionsField;

        public System.String EnvironmentalConditions
        {
            get { return this.environmentalConditionsField; }
            set { this.environmentalConditionsField = value; }
        }

        private System.String houseStatusField;

        public System.String HouseStatus
        {
            get { return this.houseStatusField; }
            set { this.houseStatusField = value; }
        }

        private System.String lengthOfStayField;

        public System.String LengthOfStay
        {
            get { return this.lengthOfStayField; }
            set { this.lengthOfStayField = value; }
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

        private System.String personalCharacterField;

        public System.String PersonalCharacter
        {
            get { return this.personalCharacterField; }
            set { this.personalCharacterField = value; }
        }
        
        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.String residenceConditionsField;

        public System.String ResidenceConditions
        {
            get { return this.residenceConditionsField; }
            set { this.residenceConditionsField = value; }
        }

        private System.Int64 resultMovableIDField;

        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
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

        private System.Int64 workOrderMovableIDField;

        public System.Int64 WorkOrderMovableID
        {
            get { return this.workOrderMovableIDField; }
            set { this.workOrderMovableIDField = value; }
        }

    }
}

