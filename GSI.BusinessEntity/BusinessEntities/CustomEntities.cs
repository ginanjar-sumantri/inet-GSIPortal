using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    #region MsCustomer
    public partial class MsCustomer
    {
        public MsCustomer(long _prmCustomerID, long _prmCustomerUserID, String _prmDisplayName, String _prmUserEmailAddress,
            String _prmMembershipUserName, String _prmCustomerUserRemark, String _prmCustomerCode, String _prmCustomerName,
            Boolean _prmFgActive, String _prmCustomerRemark)
        {
            this.customerIDField = _prmCustomerID;
            this.customerUserIDField = _prmCustomerUserID;
            this.displayNameField = _prmDisplayName;
            this.userEmailAddressField = _prmUserEmailAddress;
            this.membershipUserNameField = _prmMembershipUserName;
            this.customerUserRemarkField = _prmCustomerUserRemark;
            this.customerCodeField = _prmCustomerCode;
            this.customerNameField = _prmCustomerName;
            this.fgActive = _prmFgActive;
            this.CustomerRemark = _prmCustomerRemark;
        }

        private long customerUserIDField;
        public long CustomerUserID
        {
            get { return this.customerUserIDField; }
            set { this.customerUserIDField = value; }
        }

        private String displayNameField;
        public String DisplayName
        {
            get { return this.displayNameField; }
            set { this.displayNameField = value; }
        }

        private String userEmailAddressField;
        public String UserEmailAddress
        {
            get { return this.userEmailAddressField; }
            set { this.userEmailAddressField = value; }
        }

        private String membershipUserNameField;
        public String MembershipUserName
        {
            get { return this.membershipUserNameField; }
            set { this.membershipUserNameField = value; }
        }

        private String customerUserRemarkField;
        public String CustomerUserRemark
        {
            get { return this.customerUserRemarkField; }
            set { this.customerUserRemarkField = value; }
        }

        private String customerRemarkField;
        public String CustomerRemark
        {
            get { return this.customerRemarkField; }
            set { this.customerRemarkField = value; }
        }
    }
    #endregion

    #region Employee
    public partial class MsEmployee
    {
        public MsEmployee(System.String gadgetName)
        {
            this.gadgetNameField = gadgetName;
        }

        private System.String gadgetNameField;

        public System.String GadgetName
        {
            get { return this.gadgetNameField; }
            set { this.gadgetNameField = value; }
        }
    }
    #endregion

    #region Surveyor
    public partial class MsSurveyor
    {
        public MsSurveyor(System.String createdBy, System.DateTime createdDate, System.Int64 employeeID, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.Int64 regionID, System.String remark, System.Int32 rowStatus, System.String surveyorCode, System.Int64 surveyorID, System.Byte[] timestamp, String employeeName)
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
            this.employeeNameField = employeeName;
            this.timestampField = timestamp;
        }

        private String employeeNameField;

        public String EmployeeName
        {
            get { return this.employeeNameField; }
            set { this.employeeNameField = value; }
        }
    }

    public partial class MsSurveyorZipCode
    {
        private String surveyorNameField;

        public String SurveyorName
        {
            get { return this.surveyorNameField; }
            set { this.surveyorNameField = value; }
        }
    }
    #endregion

    #region SIMCard
    public partial class MsSIMCard
    {
        public MsSIMCard(System.String OperatorName)
        {
            this.operatorNameField = OperatorName;
        }

        private System.String operatorNameField;

        public System.String OperatorName
        {
            get { return this.operatorNameField; }
            set { this.operatorNameField = value; }
        }
    }
    #endregion

    #region Gadget
    public partial class MsGadget
    {

        public MsGadget(System.String BrandName, System.String SIMCardNumber)
        {
            this.BrandNameField = BrandName;
            this.SIMCardNumberField = SIMCardNumber;
        }

        private System.String BrandNameField;

        public System.String BrandName
        {
            get { return this.BrandNameField; }
            set { this.BrandNameField = value; }
        }

        private System.String SIMCardNumberField;

        public System.String SIMCardNumber
        {
            get { return this.SIMCardNumberField; }
            set { this.SIMCardNumberField = value; }
        }
    }
    #endregion

    #region Order
    [Serializable]
    public partial class OrderDetail
    {
        public OrderDetail()
        {
        }

        public OrderDetail(long _prmOrderSPID, long _prmOrderID, long _prmSPID, String _prmSPName, Byte _prmSPStatus)
        {
            this.orderSPID = _prmOrderSPID;
            //this.orderSPNotMovableID = _prmOrderSPNotMovableID;
            this.orderID = _prmOrderID;
            this.spID = _prmSPID;
            this.surveyPointName = _prmSPName;
            this.spStatus = _prmSPStatus;
        }

        private long orderSPID;
        public long OrderSPID
        {
            get { return this.orderSPID; }
            set { this.orderSPID = value; }
        }

        private long orderID;
        public long OrderID
        {
            get { return this.orderID; }
            set { this.orderID = value; }
        }

        private long spID;
        public long SurveyPointID
        {
            get { return this.spID; }
            set { this.spID = value; }
        }

        private String surveyPointName;
        public String SurveyPointName
        {
            get { return this.surveyPointName; }
            set { this.surveyPointName = value; }
        }

        private Byte spStatus;
        public Byte SurveyPointStatus
        {
            get { return this.spStatus; }
            set { this.spStatus = value; }
        }

        ~OrderDetail()
        {
        }
    }
    #endregion

    #region OrderSurveyPoint
    [Serializable]
    public partial class OrderSurveyPoint
    {
        public OrderSurveyPoint()
        {
        }

        public OrderSurveyPoint(System.String clue, System.String createdBy, System.DateTime createdDate, Nullable<System.DateTime> dateOfBirth, System.String extension, System.String address, System.String homePhoneNumber, System.String iDAddress, System.String iDNo, System.Byte iDType, System.String maritalStatus, System.String mobilePhoneNumber, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nationality, System.Int64 orderID, System.Int64 orderSPID, System.String placeOfBirth, System.Int64 regionID, System.String remark, System.Int32 rowStatus, System.String spouseName, System.Byte sPStatus, System.Int64 surveyPointID, System.String orderSurveyPointName, System.Byte[] timestamp, System.String zipCode,
            String orderCode, DateTime orderDate, Int64 orderTypeID, String orderTypeName, String surveyPointName, String regionName, Int32 templateForm, String customerName)
        {
            this.orderSPIDField = orderSPID;
            this.orderIDField = orderID;
            this.orderCodeField = orderCode;
            this.orderDateField = orderDate;
            this.orderTypeIDField = orderTypeID;
            this.orderTypeNameField = orderTypeName;
            this.surveyPointIDField = surveyPointID;
            this.templateFormField = templateForm;
            this.surveyPointNameField = surveyPointName;
            this.orderSurveyPointNameField = orderSurveyPointName;
            this.addressField = address;
            this.clueField = clue;
            this.zipCodeField = zipCode;
            this.homePhoneNumberField = homePhoneNumber;
            this.extensionField = extension;
            this.mobilePhoneNumberField = mobilePhoneNumber;
            this.regionIDField = regionID;
            this.regionNameField = regionName;
            this.sPStatusField = sPStatus;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.timestampField = timestamp;
            this.customerNameField = customerName;
        }

        public String RemarkCancel { get; set; }

        public Byte CancelStatus { get; set; }

        private System.String surveyPointNameField;
        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private System.String orderTypeNameField;
        public System.String OrderTypeName
        {
            get { return this.orderTypeNameField; }
            set { this.orderTypeNameField = value; }
        }

        private System.Int64 orderTypeIDField;
        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
        }

        private System.String orderCodeField;
        public System.String OrderCode
        {
            get { return this.orderCodeField; }
            set { this.orderCodeField = value; }
        }

        private System.DateTime orderDateField;
        public System.DateTime OrderDate
        {
            get { return this.orderDateField; }
            set { this.orderDateField = value; }
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

        private System.String extensionField;
        public System.String Extension
        {
            get { return this.extensionField; }
            set { this.extensionField = value; }
        }

        private System.String addressField;
        public System.String Address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        private System.String homePhoneNumberField;
        public System.String HomePhoneNumber
        {
            get { return this.homePhoneNumberField; }
            set { this.homePhoneNumberField = value; }
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

        private System.Int64 orderIDField;
        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }

        private System.Int64 orderSPIDField;
        public System.Int64 OrderSPID
        {
            get { return this.orderSPIDField; }
            set { this.orderSPIDField = value; }
        }

        private System.Int64 regionIDField;
        public System.Int64 RegionID
        {
            get { return this.regionIDField; }
            set { this.regionIDField = value; }
        }

        private String regionNameField;
        public String RegionName
        {
            get { return this.regionNameField; }
            set { this.regionNameField = value; }
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

        private System.Int32 templateFormField;
        public System.Int32 TemplateForm
        {
            get { return this.templateFormField; }
            set { this.templateFormField = value; }
        }

        private System.String orderSurveyPointNameField;
        public System.String OrderSurveyPointName
        {
            get { return this.orderSurveyPointNameField; }
            set { this.orderSurveyPointNameField = value; }
        }

        private System.Byte[] timestampField;
        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String zipCodeField;
        public System.String ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
        }
        private System.String customerNameField;
        public System.String CustomerName
        {
            get { return this.customerNameField; }
            set { this.customerNameField = value; }
        }

    }
    #endregion

    #region Mapper
    [Serializable]
    public partial class Mapper_OrderType_PointSurveybySurveyPoint
    {
        public Mapper_OrderType_PointSurveybySurveyPoint()
        {
        }

        public Mapper_OrderType_PointSurveybySurveyPoint(Int64 _prmOrderTypeIDMapper, Int64 _prmPointSurveyIDMapper, Int64 _prmTemplateFormMapper, String _prmPointSurveyNameMapper)
        {
            this.orderTypeIDMapper = _prmOrderTypeIDMapper;
            this.pointSurveyIDMapper = _prmPointSurveyIDMapper;
            this.templateFormMapper = _prmTemplateFormMapper;
            this.pointSurveyNameMapper = _prmPointSurveyNameMapper;
        }

        private Int64 orderTypeIDMapper;
        public Int64 OrderTypeIDMapper
        {
            get { return this.orderTypeIDMapper; }
            set { this.orderTypeIDMapper = value; }
        }

        private Int64 pointSurveyIDMapper;
        public Int64 PointSurveyIDMapper
        {
            get { return this.pointSurveyIDMapper; }
            set { this.pointSurveyIDMapper = value; }
        }

        private Int64 templateFormMapper;
        public Int64 TemplateFormMapper
        {
            get { return this.templateFormMapper; }
            set { this.templateFormMapper = value; }
        }

        private String pointSurveyNameMapper;
        public String PointSurveyNameMapper
        {
            get { return this.pointSurveyNameMapper; }
            set { this.pointSurveyNameMapper = value; }
        }

        ~Mapper_OrderType_PointSurveybySurveyPoint()
        {
        }
    }
    #endregion

    #region WorkOrder
    [Serializable]
    public partial class TrWorkOrder
    {
        public TrWorkOrder()
        {
        }

        public Byte CancelStatus { get; set; }

        public Int64 WORef { get; set; }

        private System.Byte spStatusField;

        public System.Byte SPStatus
        {
            get { return this.spStatusField; }
            set { this.spStatusField = value; }
        }

        private System.Int64 surveyPointIDField;

        public System.Int64 SurveyPointID
        {
            get { return this.surveyPointIDField; }
            set { this.surveyPointIDField = value; }
        }

        private System.Int64 orderTypeIDField;

        public System.Int64 OrderTypeID
        {
            get { return this.orderTypeIDField; }
            set { this.orderTypeIDField = value; }
        }

        private System.Int64 orderIDField;

        public System.Int64 OrderID
        {
            get { return this.orderIDField; }
            set { this.orderIDField = value; }
        }


        private System.String surveyPointNameField;

        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private System.String customerNameField;

        public System.String CustomerName
        {
            get { return this.customerNameField; }
            set { this.customerNameField = value; }
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

        private System.DateTime dateCreateField;

        public System.DateTime DateCreate
        {
            get { return this.dateCreateField; }
            set { this.dateCreateField = value; }
        }

        private Nullable<System.DateTime> dateExecuteField;

        public Nullable<System.DateTime> DateExecute
        {
            get { return this.dateExecuteField; }
            set { this.dateExecuteField = value; }
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

        private System.Int64 orderSPIDField;

        public System.Int64 OrderSPID
        {
            get { return this.orderSPIDField; }
            set { this.orderSPIDField = value; }
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

        private System.Int64 surveyorIDField;

        public System.Int64 SurveyorID
        {
            get { return this.surveyorIDField; }
            set { this.surveyorIDField = value; }
        }

        private System.Boolean syncStatusField;

        public System.Boolean SyncStatus
        {
            get { return this.syncStatusField; }
            set { this.syncStatusField = value; }
        }

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String workOrderCodeField;

        public System.String WorkOrderCode
        {
            get { return this.workOrderCodeField; }
            set { this.workOrderCodeField = value; }
        }

        private System.Int64 workOrderIDField;

        public System.Int64 WorkOrderID
        {
            get { return this.workOrderIDField; }
            set { this.workOrderIDField = value; }
        }

        private System.Byte workOrderStatusIDField;

        public System.Byte WorkOrderStatusID
        {
            get { return this.workOrderStatusIDField; }
            set { this.workOrderStatusIDField = value; }
        }

        private System.String employeeNameField;

        public System.String EmployeeName
        {
            get { return this.employeeNameField; }
            set { this.employeeNameField = value; }
        }

        private Nullable<System.DateTime> onTheWayDateField;

        public Nullable<System.DateTime> OnTheWayDate
        {
            get { return this.onTheWayDateField; }
            set { this.onTheWayDateField = value; }
        }

        private Nullable<System.DateTime> onTheSpotDateField;

        public Nullable<System.DateTime> OnTheSpotDate
        {
            get { return this.onTheSpotDateField; }
            set { this.onTheSpotDateField = value; }
        }

        private Nullable<System.DateTime> surveyResultReceivedDateField;

        public Nullable<System.DateTime> SurveyResultReceivedDate
        {
            get { return this.surveyResultReceivedDateField; }
            set { this.surveyResultReceivedDateField = value; }
        }

        private Nullable<System.Byte> wOTypeField;

        public Nullable<System.Byte> WOType
        {
            get { return this.wOTypeField; }
            set { this.wOTypeField = value; }
        }
    }

    [Serializable]
    public partial class GSIWorkOrderData
    {
        public GSIWorkOrderData()
        {
        }

        public GSIWorkOrderData(
                long _prmWorkOrderID,
                String _prmWorkOrderCode,
                long _prmSurveyorID,
                String _prmSurveyorCode,
                String _prmClue,
                String _prmAddress,
                String _prmZipCode,
                String _prmMaritalStatus,
                String _prmNationality,
                String _prmRemark,
                String _prmRemarkAssign,
                String _prmBusinessFormName,
                String _prmSpouseName,
                String _prmSurveyPointTemplateForm,
                String _prmSurveyPointName,
                long _prmSurveyPointID
            )
        {
            this.workOrderID = _prmWorkOrderID;
            this.workOrderCode = _prmWorkOrderCode;
            this.surveyorID = _prmSurveyorID;
            this.surveyorCode = _prmSurveyorCode;
            this.clue = _prmClue;
            this.address = _prmAddress;
            this.zipCode = _prmZipCode;
            this.maritalStatus = _prmMaritalStatus;
            this.Nationality = _prmNationality;
            this.remark = _prmRemark;
            this.remarkAssign = _prmRemarkAssign;
            this.businessFormName = _prmBusinessFormName;
            this.spouseName = _prmSpouseName;
            this.surveyPointTemplateForm = _prmSurveyPointTemplateForm;
            this.surveyPointName = _prmSurveyPointName;
            this.surveyPointID = _prmSurveyPointID;
        }

        private long workOrderID;
        private String workOrderCode;
        private long surveyorID;
        private String surveyorCode;
        private String businessFormName;
        private String surveyPointName;
        private String surveyPointTemplateForm;
        private String maritalStatus;
        private String spouseName;
        private String nationality;
        private String address;
        private String clue;
        private String zipCode;
        private String remark;
        private String remarkAssign;
        private long surveyPointID;

        public string OriginatorName { get; set; }

        public string OriginatorMaritalStatus { get; set; }

        public string OriginatorSpouseName { get; set; }

        public string OriginatorNationality { get; set; }

        public string OriginatorJobTitle { get; set; }

        public string OriginatorJobType { get; set; }

        public string OriginatorLineBussines { get; set; }

        public string OriginatorAddress { get; set; }

        public string OriginatorClue { get; set; }

        public string OriginatorZipCode { get; set; }

        public string OriginatorRemark { get; set; }

        public string JobTitle { get; set; }

        public string JobType { get; set; }

        public string LineBussines { get; set; }

        public long WorkOrderID
        {
            get { return this.workOrderID; }
            set { this.workOrderID = value; }
        }
        public String WorkOrderCode
        {
            get { return this.workOrderCode; }
            set { this.workOrderCode = value; }
        }
        public long SurveyorID
        {
            get { return this.surveyorID; }
            set { this.surveyorID = value; }
        }
        public String SurveyorCode
        {
            get { return this.surveyorCode; }
            set { this.surveyorCode = value; }
        }
        public String BusinessFormName
        {
            get { return this.businessFormName; }
            set { this.businessFormName = value; }
        }
        public String SurveyPointName
        {
            get { return this.surveyPointName; }
            set { this.surveyPointName = value; }
        }
        public String SurveyPointTemplateForm
        {
            get { return this.surveyPointTemplateForm; }
            set { this.surveyPointTemplateForm = value; }
        }
        public String MaritalStatus
        {
            get { return this.maritalStatus; }
            set { this.maritalStatus = value; }
        }
        public String SpouseName
        {
            get { return this.spouseName; }
            set { this.spouseName = value; }
        }
        public String Nationality
        {
            get { return this.nationality; }
            set { this.nationality = value; }
        }
        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public String Clue
        {
            get { return this.clue; }
            set { this.clue = value; }
        }
        public String ZipCode
        {
            get { return this.zipCode; }
            set { this.zipCode = value; }
        }
        public String Remark
        {
            get { return this.remark; }
            set { this.remark = value; }
        }

        public String RemarkAssign
        {
            get { return this.remarkAssign; }
            set { this.remarkAssign = value; }
        }

        public long SurveyPointID
        {
            get { return this.surveyPointID; }
            set { this.surveyPointID = value; }
        }
    }

    [Serializable]
    public partial class GSIRequiredDocumentData
    {
        public GSIRequiredDocumentData()
        {
        }

        public GSIRequiredDocumentData(long _prmMobileRequiredDocumentID, String _prmDocumentTypeName, String _prmRemark)
        {
            this.MobileRequiredDocumentID = _prmMobileRequiredDocumentID;
            this.DocumentTypeName = _prmDocumentTypeName;
            this.Remark = _prmRemark;
        }

        public long MobileRequiredDocumentID { get; set; }
        public String DocumentTypeName { get; set; }
        public String Remark { get; set; }
    }
    #endregion

    #region Result
    [Serializable]
    public partial class ResultMoveable
    {
        public ResultMoveable()
        {
        }

        public ResultMoveable(
            System.Int64 ResultMovableID,
            System.String SurveyPointName,
            System.String HomeAddress,
            System.String Clue,
            System.String ZipCode,
            System.String HouseStatus,
            System.String LengthOfStay,
            System.String ResidenceConditions,
            System.String EnvironmentalConditions,
            System.String BuildingArea,
            System.String PersonalCharacter,
            //System.String Others,
            System.Int64 ReqDocMovableID,
            System.String JobTitle,
            System.String JobType,
            System.String BusinessLine
            )
        {
            this.surveyPointNameField = SurveyPointName;
            this.resultMovableIDField = ResultMovableID;
            this.homeAddressField = HomeAddress;
            this.clueField = Clue;
            this.zipCodeField = ZipCode;
            this.houseStatusField = HouseStatus;
            this.lengthOfStayField = LengthOfStay;
            this.residenceConditionsField = ResidenceConditions;
            this.environmentalConditionsField = EnvironmentalConditions;
            this.buildingAreaField = BuildingArea;
            this.personalCharacterField = PersonalCharacter;
            //this.othersField = Others;
            this.reqDocMovableIDField = ReqDocMovableID;
            this.jobTitleField = JobTitle;
            this.jobTypeField = JobType;
            this.businessLineField = BusinessLine;
        }

        public String Remark { get; set; }

        private System.Int64 resultMovableIDField;
        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
        }

        private System.String surveyPointNameField;
        public System.String SurveyPointName
        {
            get { return this.surveyPointNameField; }
            set { this.surveyPointNameField = value; }
        }

        private System.String homeAddressField;
        public System.String HomeAddress
        {
            get { return this.homeAddressField; }
            set { this.homeAddressField = value; }
        }

        private System.String clueField;
        public System.String Clue
        {
            get { return this.clueField; }
            set { this.clueField = value; }
        }

        private System.String zipCodeField;
        public System.String ZipCode
        {
            get { return this.zipCodeField; }
            set { this.zipCodeField = value; }
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

        private System.String residenceConditionsField;
        public System.String ResidenceConditions
        {
            get { return this.residenceConditionsField; }
            set { this.residenceConditionsField = value; }
        }

        private System.String environmentalConditionsField;
        public System.String EnvironmentalConditions
        {
            get { return this.environmentalConditionsField; }
            set { this.environmentalConditionsField = value; }
        }

        private System.String buildingAreaField;
        public System.String BuildingArea
        {
            get { return this.buildingAreaField; }
            set { this.buildingAreaField = value; }
        }

        private System.String personalCharacterField;
        public System.String PersonalCharacter
        {
            get { return this.personalCharacterField; }
            set { this.personalCharacterField = value; }
        }

        //private System.String othersField;
        //public System.String Others
        //{
        //    get { return this.othersField; }
        //    set { this.othersField = value; }
        //}

        private System.Int64 reqDocMovableIDField;
        public System.Int64 ReqDocMovableID
        {
            get { return this.reqDocMovableIDField; }
            set { this.reqDocMovableIDField = value; }
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
    }

    [Serializable]
    public partial class ResultNotMovable
    {
        public ResultNotMovable()
        {
        }

        public ResultNotMovable(
            System.Int64 _prmResultNotMovableID,
            System.Int64 _prmOrderNotMovableSurveyPointName,
            System.Int64 _prmSurveyPointID,
            System.Int64 _prmBusinessTypeID,
            System.String SurveyPointName,
            System.String _prmAddress,
            System.String _prmClue,
            System.String _prmZipCode,
            //System.String _prmBusinessLine,
            System.String _prmCompanyPeriod,
            System.String _prmCompanyCondition,
            //System.String _prmOthers,
            System.Int64 _prmReqDocNotMovableID,
            System.String position, System.String workingPeriod)
        {
            this.resultNotMovableID = _prmResultNotMovableID;
            this.reqDocNotMovableID = _prmReqDocNotMovableID;
            this.orderNotMovableSurveyPointName = _prmOrderNotMovableSurveyPointName;
            this.surveyPointName = SurveyPointName;
            this.surveyPointID = _prmSurveyPointID;
            this.businessTypeID = _prmBusinessTypeID;
            this.address = _prmAddress;
            this.clue = _prmClue;
            //this.businessLine = _prmBusinessLine;
            this.companyCondition = _prmCompanyCondition;
            this.companyPeriod = _prmCompanyPeriod;
            this.ZipCode = _prmZipCode;
            this.positionField = position;
            this.workingPeriodField = workingPeriod;
        }

        public String Remark { get; set; }

        private Int64 resultNotMovableID;
        public Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableID; }
            set { this.resultNotMovableID = value; }
        }

        private Int64 reqDocNotMovableID;
        public Int64 ReqDocNotMovableID
        {
            get { return this.reqDocNotMovableID; }
            set { this.reqDocNotMovableID = value; }
        }

        private System.String surveyPointName;
        public System.String SurveyPointName
        {
            get { return this.surveyPointName; }
            set { this.surveyPointName = value; }
        }

        //private System.String businessLine;
        //public System.String BusinessLine
        //{
        //    get { return this.businessLine; }
        //    set { this.businessLine = value; }
        //}

        private System.String companyCondition;
        public System.String CompanyCondition
        {
            get { return this.companyCondition; }
            set { this.companyCondition = value; }
        }

        //private System.String others;
        //public System.String Others
        //{
        //    get { return this.others; }
        //    set { this.others = value; }
        //}

        private System.String companyPeriod;
        public System.String CompanyPeriod
        {
            get { return this.companyPeriod; }
            set { this.companyPeriod = value; }
        }

        private Int64 orderNotMovableSurveyPointName;
        public Int64 OrderNotMovableSurveyPointName
        {
            get { return this.orderNotMovableSurveyPointName; }
            set { this.orderNotMovableSurveyPointName = value; }
        }
        private Int64 surveyPointID;
        public Int64 SurveyPointID
        {
            get { return this.surveyPointID; }
            set { this.surveyPointID = value; }
        }
        private Int64 businessTypeID;
        public Int64 BusinessTypeID
        {
            get { return this.businessTypeID; }
            set { this.businessTypeID = value; }

        }
        private String address;
        public String Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        private String clue;
        public String Clue
        {
            get { return this.clue; }
            set { this.clue = value; }
        }
        private String zipCode;
        public String ZipCode
        {
            get { return this.zipCode; }
            set { this.zipCode = value; }
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

        ~ResultNotMovable()
        {
        }
    }
    #endregion

    #region ReqDocument
    [Serializable]
    public partial class ReqDocument
    {
        public ReqDocument()
        {
        }

        public ReqDocument(
            System.Int64 _prmDocumentTypeID,
            System.String _prmDocumentName)
        {
            this.documentTypeID = _prmDocumentTypeID;
            this.documentName = _prmDocumentName;

        }

        private Int64 documentTypeID;
        public Int64 DocumentTypeID
        {
            get { return this.documentTypeID; }
            set { this.documentTypeID = value; }
        }

        private String documentName;
        public String DocumentName
        {
            get { return this.documentName; }
            set { this.documentName = value; }
        }

        ~ReqDocument()
        {
        }
    }
    #endregion

    #region Dashboard
    [Serializable]
    public partial class DashboardByRegion
    {
        public DashboardByRegion()
        {
        }

        public DashboardByRegion(long _prmRegionID, String _prmRegionName, int _prmReceivedBySystem, int _prmWaitingForAssign,
            int _prmWaitingForDownload, int _prmWaitingForSurvey, int _prmOnTheWay, int _prmOnTheSpot, int _prmSurveyResultReceived, int _prmPublished)
        {
            this.RegionID = _prmRegionID;
            this.RegionName = _prmRegionName;
            this.ReceivedBySystem = _prmReceivedBySystem;
            this.WaitingForAssign = _prmWaitingForAssign;
            this.WaitingForDownload = _prmWaitingForDownload;
            this.WaitingForSurvey = _prmWaitingForSurvey;
            this.OnTheWay = _prmOnTheWay;
            this.OnTheSpot = _prmOnTheSpot;
            this.SurveyResultReceived = _prmSurveyResultReceived;
            this.Published = _prmPublished;
        }

        public long RegionID { get; set; }
        public String RegionName { get; set; }
        public int ReceivedBySystem { get; set; }
        public int WaitingForAssign { get; set; }
        public int WaitingForDownload { get; set; }
        public int WaitingForSurvey { get; set; }
        public int OnTheWay { get; set; }
        public int OnTheSpot { get; set; }
        public int SurveyResultReceived { get; set; }
        public int Published { get; set; }
    }

    [Serializable]
    public partial class DashboardBySurveyor
    {
        public DashboardBySurveyor()
        {
        }

        public DashboardBySurveyor(long _prmSurveyorID, String _prmSurveyorName, int _prmWaitingForDownload,
            int _prmWaitingForSurvey, int _prmOnTheWay, int _prmOnTheSpot, int _prmSurveyResultReceived, int _prmPublished)
        {
            this.SurveyorID = _prmSurveyorID;
            this.SurveyorName = _prmSurveyorName;
            this.WaitingForDownload = _prmWaitingForDownload;
            this.WaitingForSurvey = _prmWaitingForSurvey;
            this.OnTheWay = _prmOnTheWay;
            this.OnTheSpot = _prmOnTheSpot;
            this.SurveyResultReceived = _prmSurveyResultReceived;
            this.Published = _prmPublished;
        }

        public long SurveyorID { get; set; }
        public String SurveyorName { get; set; }
        public int WaitingForDownload { get; set; }
        public int WaitingForSurvey { get; set; }
        public int OnTheWay { get; set; }
        public int OnTheSpot { get; set; }
        public int SurveyResultReceived { get; set; }
        public int Published { get; set; }
    }

    [Serializable]
    public partial class OrderWFD
    {
        public OrderWFD()
        {
        }

        public OrderWFD(Int64 _prmNewOrder, Int64 _prmOutStanding, Int64 _prmOnProgress,
            DateTime _prmOrderDate, String _prmCustomerName, Byte _prmSPStatus, String _prmRegionName)
        {
            this.NewOrder = _prmNewOrder;
            this.OutStanding = _prmOutStanding;
            this.OnProgress = _prmOnProgress;
            this.OrderDate = _prmOrderDate;
            this.CustomerName = _prmCustomerName;
            this.SPStatus = _prmSPStatus;
            this.RegionName = _prmRegionName;
        }

        public Int64 NewOrder { get; set; }
        public Int64 OutStanding { get; set; }
        public Int64 OnProgress { get; set; }
        public DateTime OrderDate { get; set; }
        public String CustomerName { get; set; }
        public Byte SPStatus { get; set; }
        public String RegionName { get; set; }
    }
    #endregion
}

