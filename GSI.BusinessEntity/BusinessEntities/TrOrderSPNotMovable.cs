using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrOrderSPNotMovable
    {
        public TrOrderSPNotMovable()
        {
        }

        //public TrOrderSPNotMovable(System.String address, System.String businessLine, System.Int64 businessTypeID, System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate, System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.Int64 orderSPNotMovableID, System.String phoneNumber, System.Int64 regionID, System.String remark, System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode)
        public TrOrderSPNotMovable(System.String address, System.Int64 businessTypeID,
            System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate,
            System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID,
            System.Int64 orderSPNotMovableID, System.String phoneNumber, System.Int64 regionID, System.String remark,
            System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName,
            System.Byte[] timestamp, System.String userTakeOver, System.String zipCode, System.Int64 originatorID, System.String remarkComplaint)
        {
            this.addressField = address;
            //this.businessLineField = businessLine;
            this.businessTypeIDField = businessTypeID;
            this.clueField = clue;
            this.contactNumberField = contactNumber;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.extensionField = extension;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderIDField = orderID;
            this.orderSPNotMovableIDField = orderSPNotMovableID;
            this.phoneNumberField = phoneNumber;
            this.regionIDField = regionID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.sPStatusField = sPStatus;
            this.surveyPointIDField = surveyPointID;
            this.surveyPointNameField = surveyPointName;
            this.timestampField = timestamp;
            this.userTakeOverField = userTakeOver;
            this.zipCodeField = zipCode;
            this.originatorIDField = originatorID;
            this.remarkComplaintField = remarkComplaint;
        }

        public System.Byte CancelStatus { get; set; }

        public System.String RemarkCancel { get; set; }

        public System.Boolean FgComplaint { get; set; }

        private System.Int64 originatorIDField;

        public System.Int64 OriginatorID
        {
            get { return this.originatorIDField; }
            set { this.originatorIDField = value; }
        }

        private System.String addressField;

        public System.String Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        //private System.String businessLineField;

        //public System.String BusinessLine
        //{
        //    get { return this.businessLineField; }
        //    set { this.businessLineField = value; }
        //}

        private System.Int64 businessTypeIDField;

        public System.Int64 BusinessTypeID
        {
            get { return this.businessTypeIDField; }
            set { this.businessTypeIDField = value; }
        }

        private System.String clueField;

        public System.String Clue
        {
            get { return this.clueField; }
            set { this.clueField = value; }
        }

        private System.String contactNumberField;

        public System.String ContactNumber
        {
            get { return this.contactNumberField; }
            set { this.contactNumberField = value; }
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

        private System.String extensionField;

        public System.String Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
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

        private System.Int64 orderIDField;

        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Int64 orderSPNotMovableIDField;

        public System.Int64 OrderSPNotMovableID
        {
            get { return this.orderSPNotMovableIDField; }
            set { this.orderSPNotMovableIDField = value; }
        }

        private System.String phoneNumberField;

        public System.String PhoneNumber
        {
            get { return this.phoneNumberField; }
            set { this.phoneNumberField = value; }
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

        private System.Byte sPStatusField;

        public System.Byte SPStatus
        {
            get { return this.sPStatusField; }
            set { this.sPStatusField = value; }
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

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String userTakeOverField;

        public System.String UserTakeOver
        {
            get { return this.userTakeOverField; }
            set { this.userTakeOverField = value; }
        }

        private System.String zipCodeField;

        public System.String ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
        }

        private System.String remarkComplaintField;

        public System.String RemarkComplaint
        {
            get { return this.remarkComplaintField; }
            set { this.remarkComplaintField = value; }
        }
    }
}

