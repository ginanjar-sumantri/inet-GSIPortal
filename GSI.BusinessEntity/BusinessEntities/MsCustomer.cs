using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsCustomer
    {
        public MsCustomer()
        {
        }

        public MsCustomer(Nullable<System.Int64> businessTypeID, System.String city, System.String createdBy, System.DateTime createdDate, System.String customerAddress1, System.String customerAddress2, System.String customerCode, System.Int64 customerID, System.String customerName, System.String fax, System.Boolean fgActive, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nPPKP, System.String nPWP, System.String nPWPAddress, System.String phone, System.String primaryContactDepartment, System.String primaryContactEmail, System.String primaryContactHP, System.String primaryContactName, System.String primaryGender, System.String primaryPlaceOfBirth, System.DateTime primaryDateOfBirth, System.String primaryContactTitle, System.String primayContactFax, System.String primayContactPhone, System.String primayContactPhoneExtension, System.String remark, System.Int32 rowStatus, System.String secondaryContactDepartment, System.String secondaryContactEmail, System.String secondaryContactFax, System.String secondaryContactHP, System.String secondaryContactName, System.String secondaryGender, System.String secondaryPlaceOfBirth, System.DateTime secondaryDateOfBirth, System.String secondaryContactPhone, System.String secondaryContactPhoneExtension, System.String secondaryContactTitle, System.Byte[] timestamp, System.String zipCode)
        {
            this.businessTypeIDField = businessTypeID;
            this.cityField = city;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
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

        public Nullable<System.Int64> BusinessTypeID
        {
            get { return this.businessTypeIDField; }
            set { this.businessTypeIDField = value; }
        }

        private System.String cityField;

        public System.String City
        {
            get { return this.cityField; }
            set { this.cityField = value; }
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

        private System.String customerAddress1Field;

        public System.String CustomerAddress1
        {
            get { return this.customerAddress1Field; }
            set { this.customerAddress1Field = value; }
        }

        private System.String customerAddress2Field;

        public System.String CustomerAddress2
        {
            get { return this.customerAddress2Field; }
            set { this.customerAddress2Field = value; }
        }

        private System.String customerCodeField;

        public System.String CustomerCode
        {
            get { return this.customerCodeField; }
            set { this.customerCodeField = value; }
        }

        private System.Int64 customerIDField;

        public System.Int64 CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
        }

        private System.String customerNameField;

        public System.String CustomerName
        {
            get { return this.customerNameField; }
            set { this.customerNameField = value; }
        }

        private System.String faxField;

        public System.String Fax
        {
            get { return this.faxField; }
            set { this.faxField = value; }
        }

        private System.Boolean fgActiveField;

        public System.Boolean fgActive
        {
            get { return this.fgActiveField; }
            set { this.fgActiveField = value; }
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

        private System.String nPPKPField;

        public System.String NPPKP
        {
            get { return this.nPPKPField; }
            set { this.nPPKPField = value; }
        }

        private System.String nPWPField;

        public System.String NPWP
        {
            get { return this.nPWPField; }
            set { this.nPWPField = value; }
        }

        private System.String nPWPAddressField;

        public System.String NPWPAddress
        {
            get { return this.nPWPAddressField; }
            set { this.nPWPAddressField = value; }
        }

        private System.String phoneField;

        public System.String Phone
        {
            get { return this.phoneField; }
            set { this.phoneField = value; }
        }

        private System.String primaryContactDepartmentField;

        public System.String PrimaryContactDepartment
        {
            get { return this.primaryContactDepartmentField; }
            set { this.primaryContactDepartmentField = value; }
        }

        private System.String primaryContactEmailField;

        public System.String PrimaryContactEmail
        {
            get { return this.primaryContactEmailField; }
            set { this.primaryContactEmailField = value; }
        }

        private System.String primaryContactHPField;

        public System.String PrimaryContactHP
        {
            get { return this.primaryContactHPField; }
            set { this.primaryContactHPField = value; }
        }

        private System.String primaryContactNameField;

        public System.String PrimaryContactName
        {
            get { return this.primaryContactNameField; }
            set { this.primaryContactNameField = value; }
        }

        private System.String primaryGenderField;

        public System.String PrimaryGender
        {
            get { return this.primaryGenderField; }
            set { this.primaryGenderField = value; }
        }

        private System.String primaryPlaceOfBirthField;

        public System.String PrimaryPlaceOfBirth
        {
            get { return this.primaryPlaceOfBirthField; }
            set { this.primaryPlaceOfBirthField = value; }
        }

        private System.DateTime primaryDateOfBirthField;

        public System.DateTime PrimaryDateOfBirth
        {
            get { return this.primaryDateOfBirthField; }
            set { this.primaryDateOfBirthField = value; }
        }

        private System.String primaryContactTitleField;

        public System.String PrimaryContactTitle
        {
            get { return this.primaryContactTitleField; }
            set { this.primaryContactTitleField = value; }
        }

        private System.String primayContactFaxField;

        public System.String PrimayContactFax
        {
            get { return this.primayContactFaxField; }
            set { this.primayContactFaxField = value; }
        }

        private System.String primayContactPhoneField;

        public System.String PrimayContactPhone
        {
            get { return this.primayContactPhoneField; }
            set { this.primayContactPhoneField = value; }
        }

        private System.String primayContactPhoneExtensionField;

        public System.String PrimayContactPhoneExtension
        {
            get { return this.primayContactPhoneExtensionField; }
            set { this.primayContactPhoneExtensionField = value; }
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

        private System.String secondaryContactDepartmentField;

        public System.String SecondaryContactDepartment
        {
            get { return this.secondaryContactDepartmentField; }
            set { this.secondaryContactDepartmentField = value; }
        }

        private System.String secondaryContactEmailField;

        public System.String SecondaryContactEmail
        {
            get { return this.secondaryContactEmailField; }
            set { this.secondaryContactEmailField = value; }
        }

        private System.String secondaryContactFaxField;

        public System.String SecondaryContactFax
        {
            get { return this.secondaryContactFaxField; }
            set { this.secondaryContactFaxField = value; }
        }

        private System.String secondaryContactHPField;

        public System.String SecondaryContactHP
        {
            get { return this.secondaryContactHPField; }
            set { this.secondaryContactHPField = value; }
        }

        private System.String secondaryContactNameField;

        public System.String SecondaryContactName
        {
            get { return this.secondaryContactNameField; }
            set { this.secondaryContactNameField = value; }
        }

        private System.String secondaryGenderField;

        public System.String SecondaryGender
        {
            get { return this.secondaryGenderField; }
            set { this.secondaryGenderField = value; }
        }

        private System.String secondaryPlaceOfBirthField;

        public System.String SecondaryPlaceOfBirth
        {
            get { return this.secondaryPlaceOfBirthField; }
            set { this.secondaryPlaceOfBirthField = value; }
        }

        private System.DateTime secondaryDateOfBirthField;

        public System.DateTime SecondaryDateOfBirth
        {
            get { return this.secondaryDateOfBirthField; }
            set { this.secondaryDateOfBirthField = value; }
        }


        private System.String secondaryContactPhoneField;

        public System.String SecondaryContactPhone
        {
            get { return this.secondaryContactPhoneField; }
            set { this.secondaryContactPhoneField = value; }
        }

        private System.String secondaryContactPhoneExtensionField;

        public System.String SecondaryContactPhoneExtension
        {
            get { return this.secondaryContactPhoneExtensionField; }
            set { this.secondaryContactPhoneExtensionField = value; }
        }

        private System.String secondaryContactTitleField;

        public System.String SecondaryContactTitle
        {
            get { return this.secondaryContactTitleField; }
            set { this.secondaryContactTitleField = value; }
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

    }
}

