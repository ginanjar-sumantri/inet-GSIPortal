using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrOrderSPMovable
    {
        public TrOrderSPMovable()
        {
        }

        public TrOrderSPMovable(System.String clue, System.String createdBy, System.DateTime createdDate, 
            Nullable<System.DateTime> dateOfBirth, System.String extension, System.String homeAddress, 
            System.String homePhoneNumber, System.String iDAddress, System.String iDNo, System.Byte iDType, 
            System.String maritalStatus, System.String mobilePhoneNumber, System.String modifiedBy, 
            Nullable<System.DateTime> modifiedDate, System.String nationality, System.Int64 orderID, 
            System.Int64 orderSPMovableID, System.String placeOfBirth, System.Int64 regionID, System.String remark, 
            System.Int32 rowStatus, System.String spouseName, System.Byte sPStatus, System.Int64 surveyPointID, 
            System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode, 
            System.String jobTitle, System.String jobType, System.String businessLine, System.Int64 originatorID, System.String remarkComplaint)
        {
            this.clueField = clue;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.dateOfBirthField = dateOfBirth;
            this.extensionField = extension;
            this.homeAddressField = homeAddress;
            this.homePhoneNumberField = homePhoneNumber;
            this.iDAddressField = iDAddress;
            this.iDNoField = iDNo;
            this.iDTypeField = iDType;
            this.maritalStatusField = maritalStatus;
            this.mobilePhoneNumberField = mobilePhoneNumber;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.nationalityField = nationality;
            this.orderIDField = orderID;
            this.orderSPMovableIDField = orderSPMovableID;
            this.placeOfBirthField = placeOfBirth;
            this.regionIDField = regionID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.spouseNameField = spouseName;
            this.sPStatusField = sPStatus;
            this.surveyPointIDField = surveyPointID;
            this.surveyPointNameField = surveyPointName;
            this.timestampField = timestamp;
            this.userTakeOverField = userTakeOver;
            this.zipCodeField = zipCode;
            this.jobTitleField = jobTitle;
            this.jobTypeField = jobType;
            this.businessLineField = businessLine;
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

        private System.String clueField;

        public System.String Clue
        {
            get { return this.clueField; }
            set { this.clueField = value; }
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

        private Nullable<System.DateTime> dateOfBirthField;

        public Nullable<System.DateTime> DateOfBirth
        {
            get { return this.dateOfBirthField; }
            set { this.dateOfBirthField = value; }
        }

        private System.String extensionField;

        public System.String Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        private System.String homeAddressField;

        public System.String HomeAddress
        {
            get { return this.homeAddressField; }
            set { this.homeAddressField = value; }
        }

        private System.String homePhoneNumberField;

        public System.String HomePhoneNumber
        {
            get { return this.homePhoneNumberField; }
            set { this.homePhoneNumberField = value; }
        }

        private System.String iDAddressField;

        public System.String IDAddress
        {
            get { return this.iDAddressField; }
            set { this.iDAddressField = value; }
        }

        private System.String iDNoField;

        public System.String IDNo
        {
            get { return this.iDNoField; }
            set { this.iDNoField = value; }
        }

        private System.Byte iDTypeField;

        public System.Byte IDType
        {
            get { return this.iDTypeField; }
            set { this.iDTypeField = value; }
        }

        private System.String maritalStatusField;

        public System.String MaritalStatus
        {
            get { return this.maritalStatusField; }
            set { this.maritalStatusField = value; }
        }

        private System.String mobilePhoneNumberField;

        public System.String MobilePhoneNumber
        {
            get { return this.mobilePhoneNumberField; }
            set { this.mobilePhoneNumberField = value; }
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

        private System.String nationalityField;

        public System.String Nationality
        {
            get { return this.nationalityField; }
            set { this.nationalityField = value; }
        }

        private System.Int64 orderIDField;

        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Int64 orderSPMovableIDField;

        public System.Int64 OrderSPMovableID
        {
            get { return this.orderSPMovableIDField; }
            set { this.orderSPMovableIDField = value; }
        }

        private System.String placeOfBirthField;

        public System.String PlaceOfBirth
        {
            get { return this.placeOfBirthField; }
            set { this.placeOfBirthField = value; }
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

        private System.String spouseNameField;

        public System.String SpouseName
        {
            get { return this.spouseNameField; }
            set { this.spouseNameField = value; }
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

        private System.String jobTitleField;

        public System.String JobTitle
        {
            get { return this.jobTitleField; }
            set { this.jobTitleField = value; }
        }

        private System.String jobTypeField;

        public System.String JobType
        {
            get { return this.jobTypeField; }
            set { this.jobTypeField = value; }
        }

        private System.String businessLineField;

        public System.String BusinessLine
        {
            get { return this.businessLineField; }
            set { this.businessLineField = value; }
        }

        private System.String remarkComplaintField;

        public System.String RemarkComplaint
        {
            get { return this.remarkComplaintField; }
            set { this.remarkComplaintField = value; }
        }

    }
}

