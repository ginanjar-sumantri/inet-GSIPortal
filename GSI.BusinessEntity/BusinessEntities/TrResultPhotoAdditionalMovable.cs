using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrResultPhotoAdditionalMovable
    {
        public TrResultPhotoAdditionalMovable()
        {
        }

        public TrResultPhotoAdditionalMovable(System.String createdBy, System.DateTime createdDate, System.String imageGuid, System.String latitude, System.String longitude, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String photoName, System.String remark, System.Int64 resultMovableID, System.Int64 resultPhotoAdditionalMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.DateTime uploadDate)
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

        private System.String imageGuidField;

        public System.String ImageGuid
        {
            get { return this.imageGuidField; }
            set { this.imageGuidField = value; }
        }

        private System.String latitudeField;

        public System.String Latitude
        {
            get { return this.latitudeField; }
            set { this.latitudeField = value; }
        }

        private System.String longitudeField;

        public System.String Longitude
        {
            get { return this.longitudeField; }
            set { this.longitudeField = value; }
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

        private System.String photoNameField;

        public System.String PhotoName
        {
            get { return this.photoNameField; }
            set { this.photoNameField = value; }
        }

        private System.String remarkField;

        public System.String Remark
        {
            get { return this.remarkField; }
            set { this.remarkField = value; }
        }

        private System.Int64 resultMovableIDField;

        public System.Int64 ResultMovableID
        {
            get { return this.resultMovableIDField; }
            set { this.resultMovableIDField = value; }
        }

        private System.Int64 resultPhotoAdditionalMovableIDField;

        public System.Int64 ResultPhotoAdditionalMovableID
        {
            get { return this.resultPhotoAdditionalMovableIDField; }
            set { this.resultPhotoAdditionalMovableIDField = value; }
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

        private System.DateTime uploadDateField;

        public System.DateTime UploadDate
        {
            get { return this.uploadDateField; }
            set { this.uploadDateField = value; }
        }

    }
}

