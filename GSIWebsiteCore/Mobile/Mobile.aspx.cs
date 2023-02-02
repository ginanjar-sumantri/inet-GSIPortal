using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSI.BusinessEntity.BusinessEntities;
using GSI.BusinessRule;

namespace GSIWebsiteCore.Mobile
{
    public partial class Mobile : System.Web.UI.Page
    {
        OrderBL _orderBL = new OrderBL();

        //Movable

        List<TrResultPhotoAdditionalMovable> _table = new List<TrResultPhotoAdditionalMovable>()
        {            
            new TrResultPhotoAdditionalMovable { ResultMovableID = 5, PhotoName = "home1.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalMovable { ResultMovableID = 5, PhotoName = "home2.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalMovable { ResultMovableID = 5, PhotoName = "home3.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalMovable { ResultMovableID = 5, PhotoName = "home4.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  }
        };

        private Guid _newGuid = Guid.NewGuid();
        List<TrResultReqDocMovable> _table2 = new List<TrResultReqDocMovable>()
        {            
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 15, PhotoName = "ktp1.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 15, PhotoName = "ktp2.png", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 16, PhotoName = "kk1.png", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 16, PhotoName = "kk2.png", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 17, PhotoName = "npwp1.png", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocMovable { ResultMovableID = 5, ReqDocMovableID = 17, PhotoName = "npwp2.png", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) }
        };

        //Not Movable

        List<TrResultPhotoAdditionalNotMovable> _table3 = new List<TrResultPhotoAdditionalNotMovable>()
        {            
            new TrResultPhotoAdditionalNotMovable { ResultNotMovableID = 15, PhotoName = "company1.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalNotMovable { ResultNotMovableID = 15, PhotoName = "company2.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalNotMovable { ResultNotMovableID = 15, PhotoName = "company3.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  },
            new TrResultPhotoAdditionalNotMovable { ResultNotMovableID = 15, PhotoName = "company4.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Vidy", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26)  }
        };

        private Guid _newGuid2 = Guid.NewGuid();
        List<TrResultReqDocNotMovable> _table4 = new List<TrResultReqDocNotMovable>()
        {            
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 8, PhotoName = "akte1.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 8, PhotoName = "akte2.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 8, PhotoName = "akte3.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 8, PhotoName = "akte4.jpg", ImageGuid = Guid.NewGuid(), Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 9, PhotoName = "data1.jpg", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 9, PhotoName = "data2.jpg", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 9, PhotoName = "data3.jpg", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
            new TrResultReqDocNotMovable { ResultNotMovableID = 15, ReqDocNotMovableID = 9, PhotoName = "data4.jpg", ImageGuid = Guid.NewGuid() , Longitude="24 BT", Latitude="24 BT", UploadDate = new DateTime(2011,8,26) , Remark = "From Mobile to Coresystem", RowStatus = 0, CreatedBy = "Herman", CreatedDate = new DateTime(2011,8,26) , ModifiedBy = "", ModifiedDate = new DateTime(2011,8,26) },
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButtonResult_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultMovableCoreSystem2();
        }

        protected void SendAddPhoto_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultPhotoAddtMovableCoreSystem(this._table);
        }

        protected void SendReqDocPhoto_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultReqDocMovableCoreSystem(this._table2);
        }

        protected void SendSurveyPointNot_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultNotMovableCoreSystem();
        }

        protected void SendAddPhotoNot_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultPhotoAddtNotMovableCoreSystem(this._table3);
        }

        protected void SendReqDocPhotoNot_Click(object sender, EventArgs e)
        {
            this._orderBL.UpdateResultReqDocNotMovableCoreSystem(this._table4);
        }
    }
}