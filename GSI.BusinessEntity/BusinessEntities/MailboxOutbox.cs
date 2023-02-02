using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class MailboxOutbox
    {
        public MailboxOutbox()
        {
        }

        public MailboxOutbox(Nullable<System.DateTime> date, System.Int32 iD, System.String message, System.String messageFrom, System.String messageTo, System.String subject, System.String userID)
        {
            this.dateField = date;
            this.iDField = iD;
            this.messageField = message;
            this.messageFromField = messageFrom;
            this.messageToField = messageTo;
            this.subjectField = subject;
            this.userIDField = userID;
        }

        private Nullable<System.DateTime> dateField;

        public Nullable<System.DateTime> Date
        {
            get { return this.dateField; }
            set { this.dateField = value; }
        }

        private System.Int32 iDField;

        public System.Int32 ID
        {
            get { return this.iDField; }
            set { this.iDField = value; }
        }

        private System.String messageField;

        public System.String Message
        {
            get { return this.messageField; }
            set { this.messageField = value; }
        }

        private System.String messageFromField;

        public System.String MessageFrom
        {
            get { return this.messageFromField; }
            set { this.messageFromField = value; }
        }

        private System.String messageToField;

        public System.String MessageTo
        {
            get { return this.messageToField; }
            set { this.messageToField = value; }
        }

        private System.String subjectField;

        public System.String Subject
        {
            get { return this.subjectField; }
            set { this.subjectField = value; }
        }

        private System.String userIDField;

        public System.String UserID
        {
            get { return this.userIDField; }
            set { this.userIDField = value; }
        }

    }
}

