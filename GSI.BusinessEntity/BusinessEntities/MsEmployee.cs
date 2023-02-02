using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MsEmployee
    {
        public MsEmployee()
        {
        }

        public MsEmployee(System.DateTime birthDate, System.String birthPlace, System.String createdBy, System.DateTime createdDate, System.String email, System.String employeeAddress1, System.String employeeAddress2, System.String employeeCode, System.Int64 employeeID, System.String employeeName, System.String fgActive, Nullable<System.Int64> gadgetID, System.String gender, System.String handPhone1, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String nationality, System.String noID, System.String remark, System.Int32 rowStatus, System.Byte[] timestamp, System.String typeID, System.String EmployeeLogOn)
        {
            this.birthDateField = birthDate;
            this.birthPlaceField = birthPlace;
            this.createdByField = createdBy;
            this.createdDateField = createdDate;
            this.emailField = email;
            this.employeeAddress1Field = employeeAddress1;
            this.employeeAddress2Field = employeeAddress2;
            this.employeeCodeField = employeeCode;
            this.employeeIDField = employeeID;
            this.employeeNameField = employeeName;
            this.fgActiveField = fgActive;
            this.gadgetIDField = gadgetID;
            this.genderField = gender;
            this.handPhone1Field = handPhone1;
            this.modifiedByField = modifiedBy;
            this.modifiedDateField = modifiedDate;
            this.nationalityField = nationality;
            this.noIDField = noID;
            this.remarkField = remark;
            this.rowStatusField = rowStatus;
            this.timestampField = timestamp;
            this.typeIDField = typeID;
            this.employeeLogOnField = EmployeeLogOn;
        }

        private System.DateTime birthDateField;

        public System.DateTime BirthDate
        {
            get { return this.birthDateField; }
            set { this.birthDateField = value; }
        }

        private System.String birthPlaceField;

        public System.String BirthPlace
        {
            get { return this.birthPlaceField; }
            set { this.birthPlaceField = value; }
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

        private System.String emailField;

        public System.String Email
        {
            get { return this.emailField; }
            set { this.emailField = value; }
        }

        private System.String employeeAddress1Field;

        public System.String EmployeeAddress1
        {
            get { return this.employeeAddress1Field; }
            set { this.employeeAddress1Field = value; }
        }

        private System.String employeeAddress2Field;

        public System.String EmployeeAddress2
        {
            get { return this.employeeAddress2Field; }
            set { this.employeeAddress2Field = value; }
        }

        private System.String employeeCodeField;

        public System.String EmployeeCode
        {
            get { return this.employeeCodeField; }
            set { this.employeeCodeField = value; }
        }

        private System.Int64 employeeIDField;

        public System.Int64 EmployeeID
        {
            get { return this.employeeIDField; }
            set { this.employeeIDField = value; }
        }

        private System.String employeeNameField;

        public System.String EmployeeName
        {
            get { return this.employeeNameField; }
            set { this.employeeNameField = value; }
        }

        private System.String fgActiveField;

        public System.String FgActive
        {
            get { return this.fgActiveField; }
            set { this.fgActiveField = value; }
        }

        private Nullable<System.Int64> gadgetIDField;

        public Nullable<System.Int64> GadgetID
        {
            get { return this.gadgetIDField; }
            set { this.gadgetIDField = value; }
        }

        private System.String genderField;

        public System.String Gender
        {
            get { return this.genderField; }
            set { this.genderField = value; }
        }

        private System.String handPhone1Field;

        public System.String HandPhone1
        {
            get { return this.handPhone1Field; }
            set { this.handPhone1Field = value; }
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

        private System.String noIDField;

        public System.String NoID
        {
            get { return this.noIDField; }
            set { this.noIDField = value; }
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

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String typeIDField;

        public System.String TypeID
        {
            get { return this.typeIDField; }
            set { this.typeIDField = value; }
        }

        private System.String employeeLogOnField;

        public System.String EmployeeLogOn
        {
            get { return this.employeeLogOnField; }
            set { this.employeeLogOnField = value; }
        }
      
    }
}

