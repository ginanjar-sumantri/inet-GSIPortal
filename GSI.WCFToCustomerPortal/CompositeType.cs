using System;
using System.Runtime.Serialization;

namespace GSI.WCFToCustomerPortal
{
    [DataContract]
    public partial class TrOrder
    {
        public TrOrder()
        {
        }

        public TrOrder(System.String createdBy, System.DateTime createdDate, System.Int64 customerID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String orderCode, System.DateTime orderDate, System.Int64 orderID, System.Byte orderStatus, System.Int64 orderTypeID, System.Byte orderVersion, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp, System.Int64 originatorID)
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
            this.originatorIDField = originatorID;
        }

        [DataMember]
        public DateTime ProceedDate { get; set; }

        private System.Int64 originatorIDField;

        [DataMember]
        public System.Int64 OriginatorID
        {
            get { return this.originatorIDField; }
            set { this.originatorIDField = value; }
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

        public TrOrderSPMovable(System.String clue, System.String createdBy, System.DateTime createdDate, Nullable<System.DateTime> dateOfBirth, System.String extension, System.String homeAddress, System.String homePhoneNumber, System.String iDAddress, System.String iDNo, System.Byte iDType, System.String maritalStatus, System.String mobilePhoneNumber, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nationality, System.Int64 orderID, System.Int64 orderSPMovableID, System.String placeOfBirth, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.String spouseName, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode)
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
        }

        [DataMember]
        public Byte CancelStatus { get; set; }

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

    }

    [DataContract]
    public partial class TrOrderSPNotMovable
    {
        public TrOrderSPNotMovable()
        {
        }

        //public TrOrderSPNotMovable(System.String address, System.String businessLine, System.Int64 businessTypeID, System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate, System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.Int64 orderSPNotMovableID, System.String phoneNumber, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode)
        public TrOrderSPNotMovable(System.String address, System.Int64 businessTypeID, System.String clue, System.String contactNumber, System.String createdBy, System.DateTime createdDate, System.String extension, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 orderID, System.Int64 orderSPNotMovableID, System.String phoneNumber, Nullable<System.Int64> regionID, System.String remark, System.Int32 rowStatus, System.Byte sPStatus, System.Int64 surveyPointID, System.String surveyPointName, System.Byte[] timestamp, System.String userTakeOver, System.String zipCode)
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
        }

        [DataMember]
        public Byte CancelStatus { get; set; }

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
        public TrResultMovable(System.String buildingArea, System.String createdBy, System.DateTime createdDate, System.String environmentalConditions, System.String houseStatus, System.String lengthOfStay, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String personalCharacter, System.String position, System.String remark, System.String residenceConditions, System.Int64 resultMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.String workingPeriod, System.Int64 workOrderMovableID)
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
            this.positionField = position;
            this.remarkField = remark;
            this.residenceConditionsField = residenceConditions;
            this.resultMovableIDField = resultMovableID;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.workingPeriodField = workingPeriod;
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

        private System.String positionField;

        [DataMember]
        public System.String Position
        {
            get { return this.positionField; }
            set { this.positionField = value; }
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

        private System.String workingPeriodField;

        [DataMember]
        public System.String WorkingPeriod
        {
            get { return this.workingPeriodField; }
            set { this.workingPeriodField = value; }
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
            System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark,
            System.Int64 resultNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp,
            System.Int64 workOrderNotMovableID, System.String position, System.String workingPeriod)
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
    public partial class MsRegion
    {
        public MsRegion()
        {
        }

        public MsRegion(System.String createdBy, System.DateTime createdDate,
            System.String modifiedBy, Nullable<System.DateTime> modifiedDate,
            System.String regionCode, System.Int64 regionID, System.String regionName,
            System.Int32 rowStatus, System.Byte[] timestamp)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.regionCodeField = regionCode;
            this.regionIDField = regionID;
            this.regionNameField = regionName;
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

        private System.String regionCodeField;

        [DataMember]
        public System.String RegionCode
        {
            get { return this.regionCodeField; }
            set { this.regionCodeField = value; }
        }

        private System.Int64 regionIDField;

        [DataMember]
        public System.Int64 RegionID
        {
            get { return this.regionIDField; }
            set { this.regionIDField = value; }
        }

        private System.String regionNameField;

        [DataMember]
        public System.String RegionName
        {
            get { return this.regionNameField; }
            set { this.regionNameField = value; }
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
    public partial class MsCustomer
    {
        public MsCustomer()
        {
        }

        public MsCustomer(Nullable<System.Int64> businessTypeID, System.String city, System.String createdBy, System.DateTime createdDate, System.String currCode, System.String customerAddress1, System.String customerAddress2, System.String customerCode, System.Int64 customerID, System.String customerName, System.String fax, System.Boolean fgActive, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nPPKP, System.String nPWP, System.String nPWPAddress, System.String phone, System.String primaryContactDepartment, System.String primaryContactEmail, System.String primaryContactHP, System.String primaryContactName, System.String primaryGender, System.String primaryPlaceOfBirth, System.DateTime primaryDateOfBirth, System.String primaryContactTitle, System.String primayContactFax, System.String primayContactPhone, System.String primayContactPhoneExtension, System.String remark, System.Int32 rowStatus, System.String secondaryContactDepartment, System.String secondaryContactEmail, System.String secondaryContactFax, System.String secondaryContactHP, System.String secondaryContactName, System.String secondaryGender, System.String secondaryPlaceOfBirth, System.DateTime secondaryDateOfBirth, System.String secondaryContactPhone, System.String secondaryContactPhoneExtension, System.String secondaryContactTitle, System.Byte[] timestamp, System.String zipCode)
        {
            this.businessTypeIDField = businessTypeID;
            this.cityField = city;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.currCodeField = currCode;
            this.customerAddress1Field = customerAddress1;
            this.customerAddress2Field = customerAddress2;
            this.customerCodeField = customerCode;
            this.customerIDField = customerID;
            this.customerNameField = customerName;
            this.faxField = fax;
            this.fgActiveField = fgActive;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.nPPKPField = nPPKP;
            this.nPWPField = nPWP;
            this.nPWPAddressField = nPWPAddress;
            this.phoneField = phone;
            this.primaryContactDepartmentField = primaryContactDepartment;
            this.primaryContactEmailField = primaryContactEmail;
            this.primaryContactHPField = primaryContactHP;
            this.primaryContactNameField = primaryContactName;
            this.primaryGenderField = primaryGender;
            this.primaryPlaceOfBirthField = primaryPlaceOfBirth;
            this.primaryDateOfBirthField = primaryDateOfBirth;
            this.primaryContactTitleField = primaryContactTitle;
            this.primayContactFaxField = primayContactFax;
            this.primayContactPhoneField = primayContactPhone;
            this.primayContactPhoneExtensionField = primayContactPhoneExtension;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.secondaryContactDepartmentField = secondaryContactDepartment;
            this.secondaryContactEmailField = secondaryContactEmail;
            this.secondaryContactFaxField = secondaryContactFax;
            this.secondaryContactHPField = secondaryContactHP;
            this.secondaryContactNameField = secondaryContactName;
            this.secondaryGenderField = secondaryGender;
            this.secondaryPlaceOfBirthField = secondaryPlaceOfBirth;
            this.secondaryDateOfBirthField = secondaryDateOfBirth;
            this.secondaryContactTitleField = secondaryContactTitle;
            this.secondaryContactFaxField = secondaryContactFax;
            this.secondaryContactPhoneField = secondaryContactPhone;
            this.secondaryContactPhoneExtensionField = secondaryContactPhoneExtension;
            this.timestampField = timestamp;
            this.zipCodeField = zipCode;
        }

        private Nullable<System.Int64> businessTypeIDField;

        [DataMember]
        public Nullable<System.Int64> BusinessTypeID
        {
            get { return this.businessTypeIDField; }
            set { this.businessTypeIDField = value; }
        }

        private System.String cityField;

        [DataMember]
        public System.String City
        {
            get { return this.cityField; }
            set { this.cityField = value; }
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

        private System.String currCodeField;

        [DataMember]
        public System.String CurrCode
        {
            get { return this.currCodeField; }
            set { this.currCodeField = value; }
        }

        private System.String customerAddress1Field;

        [DataMember]
        public System.String CustomerAddress1
        {
            get { return this.customerAddress1Field; }
            set { this.customerAddress1Field = value; }
        }

        private System.String customerAddress2Field;

        [DataMember]
        public System.String CustomerAddress2
        {
            get { return this.customerAddress2Field; }
            set { this.customerAddress2Field = value; }
        }

        private System.String customerCodeField;

        [DataMember]
        public System.String CustomerCode
        {
            get { return this.customerCodeField; }
            set { this.customerCodeField = value; }
        }

        private System.Int64 customerIDField;

        [DataMember]
        public System.Int64 CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
        }

        private System.String customerNameField;

        [DataMember]
        public System.String CustomerName
        {
            get { return this.customerNameField; }
            set { this.customerNameField = value; }
        }

        private System.String faxField;

        [DataMember]
        public System.String Fax
        {
            get { return this.faxField; }
            set { this.faxField = value; }
        }

        private System.Boolean fgActiveField;

        [DataMember]
        public System.Boolean fgActive
        {
            get { return this.fgActiveField; }
            set { this.fgActiveField = value; }
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

        private System.String nPPKPField;

        [DataMember]
        public System.String NPPKP
        {
            get { return this.nPPKPField; }
            set { this.nPPKPField = value; }
        }

        private System.String nPWPField;

        [DataMember]
        public System.String NPWP
        {
            get { return this.nPWPField; }
            set { this.nPWPField = value; }
        }

        private System.String nPWPAddressField;

        [DataMember]
        public System.String NPWPAddress
        {
            get { return this.nPWPAddressField; }
            set { this.nPWPAddressField = value; }
        }

        private System.String phoneField;

        [DataMember]
        public System.String Phone
        {
            get { return this.phoneField; }
            set { this.phoneField = value; }
        }

        private System.String primaryContactDepartmentField;

        [DataMember]
        public System.String PrimaryContactDepartment
        {
            get { return this.primaryContactDepartmentField; }
            set { this.primaryContactDepartmentField = value; }
        }

        private System.String primaryContactEmailField;

        [DataMember]
        public System.String PrimaryContactEmail
        {
            get { return this.primaryContactEmailField; }
            set { this.primaryContactEmailField = value; }
        }

        private System.String primaryContactHPField;

        [DataMember]
        public System.String PrimaryContactHP
        {
            get { return this.primaryContactHPField; }
            set { this.primaryContactHPField = value; }
        }

        private System.String primaryContactNameField;

        [DataMember]
        public System.String PrimaryContactName
        {
            get { return this.primaryContactNameField; }
            set { this.primaryContactNameField = value; }
        }

        private System.String primaryGenderField;

        [DataMember]
        public System.String PrimaryGender
        {
            get { return this.primaryGenderField; }
            set { this.primaryGenderField = value; }
        }

        private System.String primaryPlaceOfBirthField;

        [DataMember]
        public System.String PrimaryPlaceOfBirth
        {
            get { return this.primaryPlaceOfBirthField; }
            set { this.primaryPlaceOfBirthField = value; }
        }

        private System.DateTime primaryDateOfBirthField;

        [DataMember]
        public System.DateTime PrimaryDateOfBirth
        {
            get { return this.primaryDateOfBirthField; }
            set { this.primaryDateOfBirthField = value; }
        }

        private System.String primaryContactTitleField;

        [DataMember]
        public System.String PrimaryContactTitle
        {
            get { return this.primaryContactTitleField; }
            set { this.primaryContactTitleField = value; }
        }

        private System.String primayContactFaxField;

        [DataMember]
        public System.String PrimayContactFax
        {
            get { return this.primayContactFaxField; }
            set { this.primayContactFaxField = value; }
        }

        private System.String primayContactPhoneField;

        [DataMember]
        public System.String PrimayContactPhone
        {
            get { return this.primayContactPhoneField; }
            set { this.primayContactPhoneField = value; }
        }

        private System.String primayContactPhoneExtensionField;

        [DataMember]
        public System.String PrimayContactPhoneExtension
        {
            get { return this.primayContactPhoneExtensionField; }
            set { this.primayContactPhoneExtensionField = value; }
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

        private System.String secondaryContactDepartmentField;

        [DataMember]
        public System.String SecondaryContactDepartment
        {
            get { return this.secondaryContactDepartmentField; }
            set { this.secondaryContactDepartmentField = value; }
        }

        private System.String secondaryContactEmailField;

        [DataMember]
        public System.String SecondaryContactEmail
        {
            get { return this.secondaryContactEmailField; }
            set { this.secondaryContactEmailField = value; }
        }

        private System.String secondaryContactFaxField;

        [DataMember]
        public System.String SecondaryContactFax
        {
            get { return this.secondaryContactFaxField; }
            set { this.secondaryContactFaxField = value; }
        }

        private System.String secondaryContactHPField;

        [DataMember]
        public System.String SecondaryContactHP
        {
            get { return this.secondaryContactHPField; }
            set { this.secondaryContactHPField = value; }
        }

        private System.String secondaryContactNameField;

        [DataMember]
        public System.String SecondaryContactName
        {
            get { return this.secondaryContactNameField; }
            set { this.secondaryContactNameField = value; }
        }

        private System.String secondaryGenderField;

        [DataMember]
        public System.String SecondaryGender
        {
            get { return this.secondaryGenderField; }
            set { this.secondaryGenderField = value; }
        }

        private System.String secondaryPlaceOfBirthField;

        [DataMember]
        public System.String SecondaryPlaceOfBirth
        {
            get { return this.secondaryPlaceOfBirthField; }
            set { this.secondaryPlaceOfBirthField = value; }
        }

        private System.DateTime secondaryDateOfBirthField;

        [DataMember]
        public System.DateTime SecondaryDateOfBirth
        {
            get { return this.secondaryDateOfBirthField; }
            set { this.secondaryDateOfBirthField = value; }
        }


        private System.String secondaryContactPhoneField;

        [DataMember]
        public System.String SecondaryContactPhone
        {
            get { return this.secondaryContactPhoneField; }
            set { this.secondaryContactPhoneField = value; }
        }

        private System.String secondaryContactPhoneExtensionField;

        [DataMember]
        public System.String SecondaryContactPhoneExtension
        {
            get { return this.secondaryContactPhoneExtensionField; }
            set { this.secondaryContactPhoneExtensionField = value; }
        }

        private System.String secondaryContactTitleField;

        [DataMember]
        public System.String SecondaryContactTitle
        {
            get { return this.secondaryContactTitleField; }
            set { this.secondaryContactTitleField = value; }
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
    public partial class MsCustomerUser
    {
        public MsCustomerUser()
        {
        }

        public MsCustomerUser(System.String createdBy, System.DateTime createdDate, Nullable<System.Int64> customerID, System.Int64 customerUserID, System.String displayName, System.String membershipUserName, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp, System.String userEmailAddress)
        {
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.customerIDField = customerID;
            this.customerUserIDField = customerUserID;
            this.displayNameField = displayName;
            this.membershipUserNameField = membershipUserName;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.userEmailAddressField = userEmailAddress;
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

        private Nullable<System.Int64> customerIDField;

        [DataMember]
        public Nullable<System.Int64> CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
        }

        private System.Int64 customerUserIDField;

        [DataMember]
        public System.Int64 CustomerUserID
        {
            get { return this.customerUserIDField; }
            set { this.customerUserIDField = value; }
        }

        private System.String displayNameField;

        [DataMember]
        public System.String DisplayName
        {
            get { return this.displayNameField; }
            set { this.displayNameField = value; }
        }

        private System.String membershipUserNameField;

        [DataMember]
        public System.String MembershipUserName
        {
            get { return this.membershipUserNameField; }
            set { this.membershipUserNameField = value; }
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

        private System.String userEmailAddressField;

        [DataMember]
        public System.String UserEmailAddress
        {
            get { return this.userEmailAddressField; }
            set { this.userEmailAddressField = value; }
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
        public Nullable<System.DateTime> ModifiedDate { get; set; }
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
    public partial class Gen_LoginHistory
    {
        public Gen_LoginHistory()
        {
        }

        public Gen_LoginHistory(System.Int64 loginHistoryID, System.String iPAddress, System.String userName, System.DateTime date, System.Int32 rowStatus, System.String createdBy, System.DateTime createdDate, System.String modifiedBy, System.DateTime modifiedDate, System.Byte[] timestamp)
        {
            this.loginHistoryIDField = loginHistoryID;
            this.iPAddressField = iPAddress;
            this.userNameField = userName;
            this.dateField = date;
            this.rowStatusField = rowStatus;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.timestampField = timestamp;
        }

        private System.Int64 loginHistoryIDField;

        [DataMember]
        public System.Int64 LoginHistoryID
        {
            get { return this.loginHistoryIDField; }
            set { this.loginHistoryIDField = value; }
        }

        private System.String iPAddressField;

        [DataMember]
        public System.String IPAddress
        {
            get { return this.iPAddressField; }
            set { this.iPAddressField = value; }
        }

        private System.String userNameField;

        [DataMember]
        public System.String UserName
        {
            get { return this.userNameField; }
            set { this.userNameField = value; }
        }

        private System.DateTime dateField;

        [DataMember]
        public System.DateTime Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }

        private System.Int32 rowStatusField;

        [DataMember]
        public System.Int32 RowStatus
        {
            get { return this.rowStatusField; }
            set { this.rowStatusField = value; }
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

        private System.Byte[] timestampField;

        [DataMember]
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

    }
}
