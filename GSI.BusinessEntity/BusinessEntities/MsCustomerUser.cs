using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
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

        private Nullable<System.Int64> customerIDField;

        public Nullable<System.Int64> CustomerID
        {
            get { return this.customerIDField; }
            set { this.customerIDField = value; }
        }

        private System.Int64 customerUserIDField;

        public System.Int64 CustomerUserID
        {
            get { return this.customerUserIDField; }
            set { this.customerUserIDField = value; }
        }

        private System.String displayNameField;

        public System.String DisplayName
        {
            get { return this.displayNameField; }
            set { this.displayNameField = value; }
        }

        private System.String membershipUserNameField;

        public System.String MembershipUserName
        {
            get { return this.membershipUserNameField; }
            set { this.membershipUserNameField = value; }
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

        private System.Byte[] timestampField;

        public System.Byte[] Timestamp
        {
            get { return this.timestampField; }
            set { this.timestampField = value; }
        }

        private System.String userEmailAddressField;

        public System.String UserEmailAddress
        {
            get { return this.userEmailAddressField; }
            set { this.userEmailAddressField = value; }
        }

    }
}

