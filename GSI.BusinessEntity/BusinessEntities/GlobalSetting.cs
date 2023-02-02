using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class GlobalSetting
    {
        public GlobalSetting()
        {
        }

        public GlobalSetting(System.Int32 orderExpiredDay, System.String userID)
        {
            this.orderExpiredDayField = orderExpiredDay;
            this.userIDField = userID;
        }

        private System.Int32 orderExpiredDayField;

        public System.Int32 OrderExpiredDay
        {
            get { return this.orderExpiredDayField; }
            set { this.orderExpiredDayField = value; }
        }

        private System.String userIDField;

        public System.String UserID
        {
            get { return this.userIDField; }
            set { this.userIDField = value; }
        }

    }
}

