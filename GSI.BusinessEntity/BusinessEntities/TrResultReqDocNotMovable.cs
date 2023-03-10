using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrResultReqDocNotMovable
    {
        public TrResultReqDocNotMovable()
        {
        }

        public TrResultReqDocNotMovable(System.String createdBy, System.DateTime createdDate, System.String imageGuid, System.String latitude, System.String longitude, System.String modifiedBy, Nullable<System.DateTime> modifiedDate, System.String photoName, System.String remark, System.Int64 reqDocNotMovableID, System.Int64 resultNotMovableID, System.Int64 resultReqDocNotMovableID, System.Int32 rowStatus, System.Byte[] timestamp, System.DateTime uploadDate)
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
            this.reqDocNotMovableIDField = reqDocNotMovableID;
            this.resultNotMovableIDField = resultNotMovableID;
            this.resultReqDocNotMovableIDField = resultReqDocNotMovableID;
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

        private System.Int64 reqDocNotMovableIDField;

        public System.Int64 ReqDocNotMovableID
        {
            get { return this.reqDocNotMovableIDField; }
            set { this.reqDocNotMovableIDField = value; }
        }

        private System.Int64 resultNotMovableIDField;

        public System.Int64 ResultNotMovableID
        {
            get { return this.resultNotMovableIDField; }
            set { this.resultNotMovableIDField = value; }
        }

        private System.Int64 resultReqDocNotMovableIDField;

        public System.Int64 ResultReqDocNotMovableID
        {
            get { return this.resultReqDocNotMovableIDField; }
            set { this.resultReqDocNotMovableIDField = value; }
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

