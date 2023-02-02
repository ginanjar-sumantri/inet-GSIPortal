using System;
using System.Collections.Generic;
using System.Text;

namespace GSI.BusinessEntity.BusinessEntities
{
    [Serializable]
    public partial class TrOrderSPLog
    {
        public TrOrderSPLog()
        {
        }

       
        public String CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public String ModifiedBy { get; set; }
        
        public Nullable<System.DateTime> ModifiedDate { get; set; }
       
        public Byte[] Timestamp { get; set; }

        public Int32 RowStatus { get; set; }
       
        public Int64 LogID { get; set; }
        
        public Int64 SurveyPointType { get; set; }

        public Int64 OrderSPID { get; set; }

        public DateTime DateTime { get; set; }

        public Int32 Duration { get; set; }

        public Byte Status { get; set; }

        public Byte TypeProcess { get; set; }

        public Int64 EmployeeID { get; set; }
        
    }
}

