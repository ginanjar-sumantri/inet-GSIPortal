using System;
using System.Runtime.Serialization;

namespace GSI.WCFToCoreSystem
{
    [DataContract]
    public partial class TrOrder
    {
        public TrOrder()
        {
        }

        public TrOrder(System.String createdBy, System.DateTime createdDate, System.Int64 customerID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String orderCode, System.DateTime orderDate, System.Int64 orderID, System.Byte orderStatus, System.Int64 orderTypeID, System.Byte orderVersion, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.customerIDField = customerID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderCodeField = orderCode;
            this.orderDateField = orderDate;
            this.orderIDField = orderID;
            this.orderStatusField = orderStatus;
            this.orderTypeIDField = orderTypeID;
            this.orderVersionField = orderVersion;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        [DataMember]
        public DateTime ProceedDate { get; set; }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.Int64 customerIDField;

        [DataMember]
        public System.Int64 CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String orderCodeField;

        [DataMember]
        public System.String OrderCode
        {
            get { return this.orderCodeField; }
            set { this.orderCodeField = value; }
        }

        private System.DateTime orderDateField;

        [DataMember]
        public System.DateTime OrderDate
        {
            get { return this.orderDateField; }
            set { this.orderDateField = value; }
        }

        private System.Int64 orderIDField;

        [DataMember]
        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Byte orderStatusField;

        [DataMember]
        public System.Byte OrderStatus
        {
            get { return this.orderStatusField; }
            set { this.orderStatusField = value; }
        }

        private System.Int64 orderTypeIDField;

        [DataMember]
        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
        }

        private System.Byte orderVersionField;

        [DataMember]
        public System.Byte OrderVersion
        {
            get { return this.orderVersionField; }
            set { this.orderVersionField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }

    [DataContract]
    public partial class TrOrderSPMovable
    {
        public TrOrderSPMovable()
        {
        }

        public TrOrderSPMovable(System.String clue, System.String createdBy, System.DateTime createdDate, Nullable<System.DateTime> dateOfBirth, System.String extension, System.String homeAddress, System.String homePhoneNumber, System.String iDAddress, System.String iDNo, System.Byte iDType, System.String maritalStatus, System.String mobilePhoneNumber, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nationality, System.Int64 orderID, System.Int64 orderSPMovableID, System.String placeOfBirth, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.String spouseName, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode, System.String jobTitle, System.String jobType, System.String businessLine, System.Int64 originatorID)
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
        }

        [DataMember]
        public System.String RemarkComplaint { get; set; }

        [DataMember]
        public System.String RemarkCancel { get; set; }

        [DataMember]
        public System.Boolean FgComplaint { get; set; }

        [DataMember]
        public Byte CancelStatus { get; set; }

        private System.Int64 originatorIDField;

        [DataMember]
        public System.Int64 OriginatorID
        {
            get { return this.originatorIDField; }
            set { this.originatorIDField = value; }
        }

        private System.String userTakeOverField;

        [DataMember]
        public System.String UserTakeOver
        {
            get { return this.userTakeOverField; }
            set { this.userTakeOverField = value; }
        }

        private System.String clueField;

        [DataMember]
        public System.String Clue
        {
            get { return this.clueField; }
            set { this.clueField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private Nullable<System.DateTime> dateOfBirthField;

        [DataMember]
        public Nullable<System.DateTime> DateOfBirth
        {
            get { return this.dateOfBirthField; }
            set { this.dateOfBirthField = value; }
        }

        private System.String extensionField;

        [DataMember]
        public System.String Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        private System.String homeAddressField;

        [DataMember]
        public System.String HomeAddress
        {
            get { return this.homeAddressField; }
            set { this.homeAddressField = value; }
        }

        private System.String homePhoneNumberField;

        [DataMember]
        public System.String HomePhoneNumber
        {
            get { return this.homePhoneNumberField; }
            set { this.homePhoneNumberField = value; }
        }

        private System.String iDAddressField;

        [DataMember]
        public System.String IDAddress
        {
            get { return this.iDAddressField; }
            set { this.iDAddressField = value; }
        }

        private System.String iDNoField;

        [DataMember]
        public System.String IDNo
        {
            get { return this.iDNoField; }
            set { this.iDNoField = value; }
        }

        private System.Byte iDTypeField;

        [DataMember]
        public System.Byte IDType
        {
            get { return this.iDTypeField; }
            set { this.iDTypeField = value; }
        }

        private System.String maritalStatusField;

        [DataMember]
        public System.String MaritalStatus
        {
            get { return this.maritalStatusField; }
            set { this.maritalStatusField = value; }
        }

        private System.String mobilePhoneNumberField;

        [DataMember]
        public System.String MobilePhoneNumber
        {
            get { return this.mobilePhoneNumberField; }
            set { this.mobilePhoneNumberField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String nationalityField;

        [DataMember]
        public System.String Nationality
        {
            get { return this.nationalityField; }
            set { this.nationalityField = value; }
        }

        private System.Int64 orderIDField;

        [DataMember]
        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Int64 orderSPMovableIDField;

        [DataMember]
        public System.Int64 OrderSPMovableID
        {
            get { return this.orderSPMovableIDField; }
            set { this.orderSPMovableIDField = value; }
        }

        private System.String placeOfBirthField;

        [DataMember]
        public System.String PlaceOfBirth
        {
            get { return this.placeOfBirthField; }
            set { this.placeOfBirthField = value; }
        }

        private Nullable<System.Int64> regionIDField;

        [DataMember]
        public Nullable<System.Int64> RegionID
        {
            get { return this.regionIDField; }
            set { this.regionIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.String spouseNameField;

        [DataMember]
        public System.String SpouseName
        {
            get { return this.spouseNameField; }
            set { this.spouseNameField = value; }
        }

        private System.Byte sPStatusField;

        [DataMember]
        public System.Byte SPStatus
        {
            get { return this.sPStatusField; }
            set { this.sPStatusField = value; }
        }

        private System.Int64 surveyPointIDField;

        [DataMember]
        public System.Int64 SurveyPointID
        {
            get { return this.surveyPointIDField; }
            set { this.surveyPointIDField = value; }
        }

        private System.String surveyPointNameField;

        [DataMember]
        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String zipCodeField;

        [DataMember]
        public System.String ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
        }

        private System.String jobTitleField;

        [DataMember]
        public System.String JobTitle
        {
            get { return this.jobTitleField; }
            set { this.jobTitleField = value; }
        }

        private System.String jobTypeField;

        [DataMember]
        public System.String JobType
        {
            get { return this.jobTypeField; }
            set { this.jobTypeField = value; }
        }

        private System.String businessLineField;

        [DataMember]
        public System.String BusinessLine
        {
            get { return this.businessLineField; }
            set { this.businessLineField = value; }
        }
    }

    [DataContract]
    public partial class TrOrderSPNotMovable
    {
        public TrOrderSPNotMovable()
        {
        }

        //public TrOrderSPNotMovable(System.String address, System.String businessLine, System.Int64 businessTypeID, System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate, System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.Int64 orderSPNotMovableID, System.String phoneNumber, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode)
        public TrOrderSPNotMovable(System.String address, System.Int64 businessTypeID, System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate, System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.Int64 orderSPNotMovableID, System.String phoneNumber, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode, System.Int64 originatorID)
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
        }

        [DataMember]
        public System.String RemarkComplaint { get; set; }

        [DataMember]
        public System.String RemarkCancel { get; set; }

        [DataMember]
        public System.Boolean FgComplaint { get; set; }

        [DataMember]
        public Byte CancelStatus { get; set; }

        private System.Int64 originatorIDField;

        [DataMember]
        public System.Int64 OriginatorID
        {
            get { return this.originatorIDField; }
            set { this.originatorIDField = value; }
        }

        private System.String userTakeOverField;

        [DataMember]
        public System.String UserTakeOver
        {
            get { return this.userTakeOverField; }
            set { this.userTakeOverField = value; }
        }

        private System.String addressField;

        [DataMember]
        public System.String Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        //private System.String businessLineField;

        //[DataMember]
        //public System.String BusinessLine
        //{
        //    get { return this.businessLineField; }
        //    set { this.businessLineField = value; }
        //}

        private System.Int64 businessTypeIDField;

        [DataMember]
        public System.Int64 BusinessTypeID
        {
            get { return this.businessTypeIDField; }
            set { this.businessTypeIDField = value; }
        }

        private System.String clueField;

        [DataMember]
        public System.String Clue
        {
            get { return this.clueField; }
            set { this.clueField = value; }
        }

        private System.String contactNumberField;

        [DataMember]
        public System.String ContactNumber
        {
            get { return this.contactNumberField; }
            set { this.contactNumberField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String extensionField;

        [DataMember]
        public System.String Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.Int64 orderIDField;

        [DataMember]
        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Int64 orderSPNotMovableIDField;

        [DataMember]
        public System.Int64 OrderSPNotMovableID
        {
            get { return this.orderSPNotMovableIDField; }
            set { this.orderSPNotMovableIDField = value; }
        }

        private System.String phoneNumberField;

        [DataMember]
        public System.String PhoneNumber
        {
            get { return this.phoneNumberField; }
            set { this.phoneNumberField = value; }
        }

        private Nullable<System.Int64> regionIDField;

        [DataMember]
        public Nullable<System.Int64> RegionID
        {
            get { return this.regionIDField; }
            set { this.regionIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte sPStatusField;

        [DataMember]
        public System.Byte SPStatus
        {
            get { return this.sPStatusField; }
            set { this.sPStatusField = value; }
        }

        private System.Int64 surveyPointIDField;

        [DataMember]
        public System.Int64 SurveyPointID
        {
            get { return this.surveyPointIDField; }
            set { this.surveyPointIDField = value; }
        }

        private System.String surveyPointNameField;

        [DataMember]
        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String zipCodeField;

        [DataMember]
        public System.String ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
        }

    }

    [DataContract]
    public partial class TrReqDocMovable
    {
        public TrReqDocMovable()
        {
        }

        public TrReqDocMovable(System.String createdBy, System.DateTime createdDate, System.Int64 documentTypeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderSPMovableID, System.String remark, System.Int64 reqDocMovableID, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.documentTypeIDField = documentTypeID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderSPMovableIDField = orderSPMovableID;
            this.remarkField = remark;
            this.reqDocMovableIDField = reqDocMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.Int64 documentTypeIDField;

        [DataMember]
        public System.Int64 DocumentTypeID
        {
            get { return this.documentTypeIDField; }
            set { this.documentTypeIDField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.Int64 orderSPMovableIDField;

        [DataMember]
        public System.Int64 OrderSPMovableID
        {
            get { return this.orderSPMovableIDField; }
            set { this.orderSPMovableIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocMovableIDField;

        [DataMember]
        public System.Int64 ReqDocMovableID
        {
            get { return this.reqDocMovableIDField; }
            set { this.reqDocMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }

    [DataContract]
    public partial class TrReqDocNotMovable
    {
        public TrReqDocNotMovable()
        {
        }

        public TrReqDocNotMovable(System.String createdBy, System.DateTime createdDate, System.Int64 documentTypeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderSPNotMovableID, System.String remark, System.Int64 reqDocNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.documentTypeIDField = documentTypeID;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.orderSPNotMovableIDField = orderSPNotMovableID;
            this.remarkField = remark;
            this.reqDocNotMovableIDField = reqDocNotMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.Int64 documentTypeIDField;

        [DataMember]
        public System.Int64 DocumentTypeID
        {
            get { return this.documentTypeIDField; }
            set { this.documentTypeIDField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.Int64 orderSPNotMovableIDField;

        [DataMember]
        public System.Int64 OrderSPNotMovableID
        {
            get { return this.orderSPNotMovableIDField; }
            set { this.orderSPNotMovableIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocNotMovableIDField;

        [DataMember]
        public System.Int64 ReqDocNotMovableID
        {
            get { return this.reqDocNotMovableIDField; }
            set { this.reqDocNotMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }

    [DataContract]
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

        [DataMember]
        public System.String BuildingArea
        {
            get { return this.buildingAreaField; }
            set { this.buildingAreaField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String environmentalConditionsField;

        [DataMember]
        public System.String EnvironmentalConditions
        {
            get { return this.environmentalConditionsField; }
            set { this.environmentalConditionsField = value; }
        }

        private System.String houseStatusField;

        [DataMember]
        public System.String HouseStatus
        {
            get { return this.houseStatusField; }
            set { this.houseStatusField = value; }
        }

        private System.String lengthOfStayField;

        [DataMember]
        public System.String LengthOfStay
        {
            get { return this.lengthOfStayField; }
            set { this.lengthOfStayField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        //private System.String othersField;

        //[DataMember]
        //public System.String Others
        //{
        //    get { return this.othersField; }
        //    set { this.othersField = value; }
        //}

        private System.String personalCharacterField;

        [DataMember]
        public System.String PersonalCharacter
        {
            get { return this.personalCharacterField; }
            set { this.personalCharacterField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.String residenceConditionsField;

        [DataMember]
        public System.String ResidenceConditions
        {
            get { return this.residenceConditionsField; }
            set { this.residenceConditionsField = value; }
        }

        private System.Int64 resultMovableIDField;

        [DataMember]
        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.Int64 workOrderMovableIDField;

        [DataMember]
        public System.Int64 WorkOrderMovableID
        {
            get { return this.workOrderMovableIDField; }
            set { this.workOrderMovableIDField = value; }
        }

    }

    [DataContract]
    public partial class TrResultNotMovable
    {
        public TrResultNotMovable()
        {
        }

        //public TrResultNotMovable(System.String businessLine, System.String companyCondition, System.String companyPeriod, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String others, System.String remark, System.Int64 resultNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.Int64 workOrderNotMovableID)
        public TrResultNotMovable(System.String businessLine, System.String companyCondition,
            System.String companyPeriod, System.String createdBy, System.DateTime createdDate,
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

        //[DataMember]
        //public System.String BusinessLine
        //{
        //    get { return this.businessLineField; }
        //    set { this.businessLineField = value; }
        //}

        private System.String companyConditionField;

        [DataMember]
        public System.String CompanyCondition
        {
            get { return this.companyConditionField; }
            set { this.companyConditionField = value; }
        }

        private System.String companyPeriodField;

        [DataMember]
        public System.String CompanyPeriod
        {
            get { return this.companyPeriodField; }
            set { this.companyPeriodField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        //private System.String othersField;

        //[DataMember]
        //public System.String Others
        //{
        //    get { return this.othersField; }
        //    set { this.othersField = value; }
        //}

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 resultNotMovableIDField;

        [DataMember]
        public System.Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableIDField; }
            set { this.resultNotMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.Int64 workOrderNotMovableIDField;

        [DataMember]
        public System.Int64 WorkOrderNotMovableID
        {
            get { return this.workOrderNotMovableIDField; }
            set { this.workOrderNotMovableIDField = value; }
        }

        private System.String positionField;

        [DataMember]
        public System.String Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
        }

        private System.String workingPeriodField;

        [DataMember]
        public System.String WorkingPeriod
        {
            get { return this.workingPeriodField; }
            set { this.workingPeriodField = value; }
        }

    }

    [DataContract]
    public partial class TrResultPhotoAdditionalMovable
    {
        public TrResultPhotoAdditionalMovable()
        {
        }

        public TrResultPhotoAdditionalMovable(System.String createdBy,
            System.DateTime createdDate,
            System.String imageGuid,
            System.String modifiedBy,
            Nullable<System.DateTime> modifiedDate,
            System.String photoName,
            System.String remark,
            System.Int64 resultMovableID,
            System.Int64 resultPhotoAdditionalMovableID,
            System.Int32 rowStatus,
            System.Byte[] timestamp,
            System.String longitude,
            System.String latitude,
            System.DateTime uploadDate)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.imageGuidField = imageGuid;
            this.latitudeField = latitude;
            this.longitudeField = longitude;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.photoNameField = photoName;
            this.remarkField = remark;
            this.resultMovableIDField = resultMovableID;
            this.resultPhotoAdditionalMovableIDField = resultPhotoAdditionalMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.uploadDateField = uploadDate;
        }

        private System.String imageGuidField;

        [DataMember]
        public System.String ImageGuid
        {
            get { return this.imageGuidField; }
            set { this.imageGuidField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String photoNameField;

        [DataMember]
        public System.String PhotoName
        {
            get { return this.photoNameField; }
            set { this.photoNameField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 resultMovableIDField;

        [DataMember]
        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
        }

        private System.Int64 resultPhotoAdditionalMovableIDField;

        [DataMember]
        public System.Int64 ResultPhotoAdditionalMovableID
        {
            get { return this.resultPhotoAdditionalMovableIDField; }
            set { this.resultPhotoAdditionalMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String longitudeField;

        [DataMember]
        public System.String Longitude
        {
            get { return this.longitudeField; }
            set { this.longitudeField = value; }
        }
        private System.String latitudeField;

        [DataMember]
        public System.String Latitude
        {
            get { return this.latitudeField; }
            set { this.latitudeField = value; }
        }

        private Nullable<System.DateTime> uploadDateField;

        [DataMember]
        public Nullable<System.DateTime> UploadDate
        {
            get { return this.uploadDateField; }
            set { this.uploadDateField = value; }
        }

    }

    [DataContract]
    public partial class TrResultPhotoAdditionalNotMovable
    {
        public TrResultPhotoAdditionalNotMovable()
        {
        }

        public TrResultPhotoAdditionalNotMovable(System.String createdBy,
            System.DateTime createdDate,
            System.String imageGuid,
            System.String modifiedBy,
            Nullable<System.DateTime> modifiedDate,
            System.String photoName,
            System.String remark,
            System.Int64 resultNotMovableID,
            System.Int64 resultPhotoAdditionalNotMovableID,
            System.Int32 rowStatus,
            System.Byte[] timestamp,
            System.String longitude,
            System.String latitude,
            System.DateTime uploadDate)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.imageGuidField = imageGuid;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.photoNameField = photoName;
            this.remarkField = remark;
            this.resultNotMovableIDField = resultNotMovableID;
            this.resultPhotoAdditionalNotMovableIDField = resultPhotoAdditionalNotMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.longitudeField = longitude;
            this.latitudeField = latitude;
            this.uploadDateField = uploadDate;
        }

        private System.String imageGuidField;

        [DataMember]
        public System.String ImageGuid
        {
            get { return this.imageGuidField; }
            set { this.imageGuidField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String photoNameField;

        [DataMember]
        public System.String PhotoName
        {
            get { return this.photoNameField; }
            set { this.photoNameField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 resultNotMovableIDField;

        [DataMember]
        public System.Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableIDField; }
            set { this.resultNotMovableIDField = value; }
        }

        private System.Int64 resultPhotoAdditionalNotMovableIDField;

        [DataMember]
        public System.Int64 ResultPhotoAdditionalNotMovableID
        {
            get { return this.resultPhotoAdditionalNotMovableIDField; }
            set { this.resultPhotoAdditionalNotMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String longitudeField;

        [DataMember]
        public System.String Longitude
        {
            get { return this.longitudeField; }
            set { this.longitudeField = value; }
        }
        private System.String latitudeField;

        [DataMember]
        public System.String Latitude
        {
            get { return this.latitudeField; }
            set { this.latitudeField = value; }
        }

        private Nullable<System.DateTime> uploadDateField;

        [DataMember]
        public Nullable<System.DateTime> UploadDate
        {
            get { return this.uploadDateField; }
            set { this.uploadDateField = value; }
        }
    }

    [DataContract]
    public partial class TrResultReqDocMovable
    {
        public TrResultReqDocMovable()
        {
        }

        public TrResultReqDocMovable(System.String createdBy,
            System.DateTime createdDate,
            System.String imageGuid,
            System.String modifiedBy,
            Nullable<System.DateTime> modifiedDate,
            System.String photoName,
            System.String remark,
            System.Int64 reqDocMovableID,
            System.Int64 resultMovableID,
            System.Int64 resultReqDocMovableID,
            System.Int32 rowStatus,
            System.Byte[] timestamp,
            System.String longitude,
            System.String latitude,
            System.DateTime uploadDate)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.imageGuidField = imageGuid;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.photoNameField = photoName;
            this.remarkField = remark;
            this.reqDocMovableIDField = reqDocMovableID;
            this.resultMovableIDField = resultMovableID;
            this.resultReqDocMovableIDField = resultReqDocMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.longitudeField = longitude;
            this.latitudeField = latitude;
            this.uploadDateField = uploadDate;
        }

        private System.String imageGuidField;

        [DataMember]
        public System.String ImageGuid
        {
            get { return this.imageGuidField; }
            set { this.imageGuidField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String photoNameField;

        [DataMember]
        public System.String PhotoName
        {
            get { return this.photoNameField; }
            set { this.photoNameField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocMovableIDField;

        [DataMember]
        public System.Int64 ReqDocMovableID
        {
            get { return this.reqDocMovableIDField; }
            set { this.reqDocMovableIDField = value; }
        }

        private System.Int64 resultMovableIDField;

        [DataMember]
        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
        }

        private System.Int64 resultReqDocMovableIDField;

        [DataMember]
        public System.Int64 ResultReqDocMovableID
        {
            get { return this.resultReqDocMovableIDField; }
            set { this.resultReqDocMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String longitudeField;

        [DataMember]
        public System.String Longitude
        {
            get { return this.longitudeField; }
            set { this.longitudeField = value; }
        }
        private System.String latitudeField;

        [DataMember]
        public System.String Latitude
        {
            get { return this.latitudeField; }
            set { this.latitudeField = value; }
        }

        private Nullable<System.DateTime> uploadDateField;

        [DataMember]
        public Nullable<System.DateTime> UploadDate
        {
            get { return this.uploadDateField; }
            set { this.uploadDateField = value; }
        }

    }

    [DataContract]
    public partial class TrResultReqDocNotMovable
    {
        public TrResultReqDocNotMovable()
        {
        }

        public TrResultReqDocNotMovable(System.String createdBy,
            System.DateTime createdDate,
            System.String imageGuid,
            System.String modifiedBy,
            Nullable<System.DateTime> modifiedDate,
            System.String photoName,
            System.String remark,
            System.Int64 reqDocNotMovableID,
            System.Int64 resultNotMovableID,
            System.Int64 resultReqDocNotMovableID,
            System.Int32 rowStatus,
            System.Byte[] timestamp,
            System.String longitude,
            System.String latitude,
            System.DateTime uploadDate)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.imageGuidField = imageGuid;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.photoNameField = photoName;
            this.remarkField = remark;
            this.reqDocNotMovableIDField = reqDocNotMovableID;
            this.resultNotMovableIDField = resultNotMovableID;
            this.resultReqDocNotMovableIDField = resultReqDocNotMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.longitudeField = longitude;
            this.latitudeField = latitude;
            this.uploadDateField = uploadDate;
        }

        private System.String imageGuidField;

        [DataMember]
        public System.String ImageGuid
        {
            get { return this.imageGuidField; }
            set { this.imageGuidField = value; }
        }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private System.String photoNameField;

        [DataMember]
        public System.String PhotoName
        {
            get { return this.photoNameField; }
            set { this.photoNameField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 reqDocNotMovableIDField;

        [DataMember]
        public System.Int64 ReqDocNotMovableID
        {
            get { return this.reqDocNotMovableIDField; }
            set { this.reqDocNotMovableIDField = value; }
        }

        private System.Int64 resultNotMovableIDField;

        [DataMember]
        public System.Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableIDField; }
            set { this.resultNotMovableIDField = value; }
        }

        private System.Int64 resultReqDocNotMovableIDField;

        [DataMember]
        public System.Int64 ResultReqDocNotMovableID
        {
            get { return this.resultReqDocNotMovableIDField; }
            set { this.resultReqDocNotMovableIDField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String longitudeField;

        [DataMember]
        public System.String Longitude
        {
            get { return this.longitudeField; }
            set { this.longitudeField = value; }
        }
        private System.String latitudeField;

        [DataMember]
        public System.String Latitude
        {
            get { return this.latitudeField; }
            set { this.latitudeField = value; }
        }

        private Nullable<System.DateTime> uploadDateField;

        [DataMember]
        public Nullable<System.DateTime> UploadDate
        {
            get { return this.uploadDateField; }
            set { this.uploadDateField = value; }
        }

    }

    [DataContract]
    public partial class TrWorkOrderMovable
    {
        public TrWorkOrderMovable()
        {
        }

        public TrWorkOrderMovable(System.String createdBy, System.DateTime createdDate, System.DateTime dateCreate, Nullable<System.DateTime> dateExecute, Nullable<System.DateTime> downloadDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<System.DateTime> onTheSpotDate, Nullable<System.DateTime> onTheWayDate, System.Int64 orderSPMovableID, System.String remark, System.Int32 rowStatus, System.Int64 surveyorID, System.Boolean syncStatus, System.Byte[] timestamp, System.String workOrderCode, System.Int64 workOrderMovableID, System.Byte workOrderStatusID)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.dateCreateField = dateCreate;
            this.dateExecuteField = dateExecute;
            this.downloadDateField = downloadDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.onTheSpotDateField = onTheSpotDate;
            this.onTheWayDateField = onTheWayDate;
            this.orderSPMovableIDField = orderSPMovableID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyorIDField = surveyorID;
            this.syncStatusField = syncStatus;
            this.timestampField = timestamp;
            this.workOrderCodeField = workOrderCode;
            this.workOrderMovableIDField = workOrderMovableID;
            this.workOrderStatusIDField = workOrderStatusID;
        }

        [DataMember]
        public DateTime SurveyResultReceivedDate { get; set; }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.DateTime dateCreateField;

        [DataMember]
        public System.DateTime DateCreate
        {
            get { return this.dateCreateField; }
            set { this.dateCreateField = value; }
        }

        private Nullable<System.DateTime> dateExecuteField;

        [DataMember]
        public Nullable<System.DateTime> DateExecute
        {
            get { return this.dateExecuteField; }
            set { this.dateExecuteField = value; }
        }

        private Nullable<System.DateTime> downloadDateField;

        [DataMember]
        public Nullable<System.DateTime> DownloadDate
        {
            get { return this.downloadDateField; }
            set { this.downloadDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private Nullable<System.DateTime> onTheSpotDateField;

        [DataMember]
        public Nullable<System.DateTime> OnTheSpotDate
        {
            get { return this.onTheSpotDateField; }
            set { this.onTheSpotDateField = value; }
        }

        private Nullable<System.DateTime> onTheWayDateField;

        [DataMember]
        public Nullable<System.DateTime> OnTheWayDate
        {
            get { return this.onTheWayDateField; }
            set { this.onTheWayDateField = value; }
        }

        private System.Int64 orderSPMovableIDField;

        [DataMember]
        public System.Int64 OrderSPMovableID
        {
            get { return this.orderSPMovableIDField; }
            set { this.orderSPMovableIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Int64 surveyorIDField;

        [DataMember]
        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.Boolean syncStatusField;

        [DataMember]
        public System.Boolean SyncStatus
        {
            get { return this.syncStatusField; }
            set { this.syncStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String workOrderCodeField;

        [DataMember]
        public System.String WorkOrderCode
        {
            get { return this.workOrderCodeField; }
            set { this.workOrderCodeField = value; }
        }

        private System.Int64 workOrderMovableIDField;

        [DataMember]
        public System.Int64 WorkOrderMovableID
        {
            get { return this.workOrderMovableIDField; }
            set { this.workOrderMovableIDField = value; }
        }

        private System.Byte workOrderStatusIDField;

        [DataMember]
        public System.Byte WorkOrderStatusID
        {
            get { return this.workOrderStatusIDField; }
            set { this.workOrderStatusIDField = value; }
        }

    }

    [DataContract]
    public partial class TrWorkOrderNotMovable
    {
        public TrWorkOrderNotMovable()
        {
        }

        public TrWorkOrderNotMovable(System.String createdBy, System.DateTime createdDate, System.DateTime dateCreate, Nullable<System.DateTime> dateExecute, Nullable<System.DateTime> downloadDate, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, Nullable<System.DateTime> onTheSpotDate, Nullable<System.DateTime> onTheWayDate, System.Int64 orderSPNotMovableID, System.String remark, System.Int32 rowStatus, System.Int64 surveyorID, System.Boolean syncStatus, System.Byte[] timestamp, System.String workOrderCode, System.Int64 workOrderNotMovableID, System.Byte workOrderStatusID)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.dateCreateField = dateCreate;
            this.dateExecuteField = dateExecute;
            this.downloadDateField = downloadDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.onTheSpotDateField = onTheSpotDate;
            this.onTheWayDateField = onTheWayDate;
            this.orderSPNotMovableIDField = orderSPNotMovableID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.surveyorIDField = surveyorID;
            this.syncStatusField = syncStatus;
            this.timestampField = timestamp;
            this.workOrderCodeField = workOrderCode;
            this.workOrderNotMovableIDField = workOrderNotMovableID;
            this.workOrderStatusIDField = workOrderStatusID;
        }

        [DataMember]
        public DateTime SurveyResultReceivedDate { get; set; }

        private System.String createdByField;

        [DataMember]
        public System.String CreatedBy
        {
            get { return this.createdByField; }
            set { this.createdByField = value; }
        }

        private System.DateTime createdDateField;

        [DataMember]
        public System.DateTime CreatedDate
        {
            get { return this.createdDateField; }
            set { this.createdDateField = value; }
        }

        private System.DateTime dateCreateField;

        [DataMember]
        public System.DateTime DateCreate
        {
            get { return this.dateCreateField; }
            set { this.dateCreateField = value; }
        }

        private Nullable<System.DateTime> dateExecuteField;

        [DataMember]
        public Nullable<System.DateTime> DateExecute
        {
            get { return this.dateExecuteField; }
            set { this.dateExecuteField = value; }
        }

        private Nullable<System.DateTime> downloadDateField;

        [DataMember]
        public Nullable<System.DateTime> DownloadDate
        {
            get { return this.downloadDateField; }
            set { this.downloadDateField = value; }
        }

        private System.String modifiedByField;

        [DataMember]
        public System.String ModifiedBy
        {
            get { return this.modifiedByField; }
            set { this.modifiedByField = value; }
        }

        private Nullable<System.DateTime> modifiedDateField;

        [DataMember]
        public Nullable<System.DateTime> ModifiedDate
        {
            get { return this.modifiedDateField; }
            set { this.modifiedDateField = value; }
        }

        private Nullable<System.DateTime> onTheSpotDateField;

        [DataMember]
        public Nullable<System.DateTime> OnTheSpotDate
        {
            get { return this.onTheSpotDateField; }
            set { this.onTheSpotDateField = value; }
        }

        private Nullable<System.DateTime> onTheWayDateField;

        [DataMember]
        public Nullable<System.DateTime> OnTheWayDate
        {
            get { return this.onTheWayDateField; }
            set { this.onTheWayDateField = value; }
        }

        private System.Int64 orderSPNotMovableIDField;

        [DataMember]
        public System.Int64 OrderSPNotMovableID
        {
            get { return this.orderSPNotMovableIDField; }
            set { this.orderSPNotMovableIDField = value; }
        }

        private System.String remarkField;

        [DataMember]
        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
        }

        private System.Int64 surveyorIDField;

        [DataMember]
        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.Boolean syncStatusField;

        [DataMember]
        public System.Boolean SyncStatus
        {
            get { return this.syncStatusField; }
            set { this.syncStatusField = value; }
        }

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String workOrderCodeField;

        [DataMember]
        public System.String WorkOrderCode
        {
            get { return this.workOrderCodeField; }
            set { this.workOrderCodeField = value; }
        }

        private System.Int64 workOrderNotMovableIDField;

        [DataMember]
        public System.Int64 WorkOrderNotMovableID
        {
            get { return this.workOrderNotMovableIDField; }
            set { this.workOrderNotMovableIDField = value; }
        }

        private System.Byte workOrderStatusIDField;

        [DataMember]
        public System.Byte WorkOrderStatusID
        {
            get { return this.workOrderStatusIDField; }
            set { this.workOrderStatusIDField = value; }
        }

    }

    [DataContract]
    public partial class MsRegionZipCode
    {
        public MsRegionZipCode()
        {
        }

        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public Byte[] Timestamp { get; set; }
        [DataMember]
        public Int64 RegionZipCodeID { get; set; }
        [DataMember]
        public Int64 RegionID { get; set; }
        [DataMember]
        public String ZipCode { get; set; }
        [DataMember]
        public Int32 RowStatus { get; set; }
    }

    [DataContract]
    public partial class TrOrderSPLog
    {
        public TrOrderSPLog()
        {
        }

        [DataMember]
        public String CreatedBy { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [DataMember]
        public Byte[] Timestamp { get; set; }
        [DataMember]
        public Int32 RowStatus { get; set; }
        [DataMember]
        public Int64 LogID { get; set; }
        [DataMember]
        public Int64 SurveyPointType { get; set; }
        [DataMember]
        public Int64 OrderSPID { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public Int32 Duration { get; set; }
        [DataMember]
        public Byte Status { get; set; }
        [DataMember]
        public Byte TypeProcess { get; set; }
        [DataMember]
        public Int64 EmployeeID { get; set; }

    }
    
}
