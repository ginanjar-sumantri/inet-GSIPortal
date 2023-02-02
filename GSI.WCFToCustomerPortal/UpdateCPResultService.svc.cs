using System;
using GSI.Common;
using GSI.Common.Enum;
using GSI.DataMapping;
using System.Collections.Generic;
using GSI.BusinessRule;
using GSI.BusinessRuleCore;

namespace GSI.WCFToCustomerPortal
{
    public class UpdateCPResultService : IUpdateCPResultService
    {
        private ResultBL _resultBL = new ResultBL();
        private WorkOrderBL _workOrderBL = new WorkOrderBL();
        
        String _errorWCF = "";
        public void UpdateResultMovableCustomerPortal(TrWorkOrderMovable _prmWorkOrderMovable, TrResultMovable _prmResultMovable, List<TrResultPhotoAdditionalMovable> _prmResultPhotoAddtMovable, List<TrResultReqDocMovable> _prmResultReqDocMovableList)
        {
            GSI.BusinessEntity.BusinessEntities.TrWorkOrderMovable _resultWorkOrderMovable = new GSI.BusinessEntity.BusinessEntities.TrWorkOrderMovable();
            //_resultWorkOrderMovable.WorkOrderMovableID = _prmWorkOrderMovable.WorkOrderMovableID;
            _resultWorkOrderMovable.OrderSPMovableID = _prmWorkOrderMovable.OrderSPMovableID;
            _resultWorkOrderMovable.SurveyorID = _prmWorkOrderMovable.SurveyorID;
            _resultWorkOrderMovable.WorkOrderCode = _prmWorkOrderMovable.WorkOrderCode;
            _resultWorkOrderMovable.DateCreate = _prmWorkOrderMovable.DateCreate;
            _resultWorkOrderMovable.DateExecute = _prmWorkOrderMovable.DateExecute;
            _resultWorkOrderMovable.WorkOrderStatusID = _prmWorkOrderMovable.WorkOrderStatusID;
            _resultWorkOrderMovable.SyncStatus = _prmWorkOrderMovable.SyncStatus;
            _resultWorkOrderMovable.Remark = _prmWorkOrderMovable.Remark;
            _resultWorkOrderMovable.DownloadDate = _prmWorkOrderMovable.DownloadDate;
            _resultWorkOrderMovable.OnTheWayDate = _prmWorkOrderMovable.OnTheWayDate;
            _resultWorkOrderMovable.OnTheSpotDate = _prmWorkOrderMovable.OnTheSpotDate;
            _resultWorkOrderMovable.SurveyResultReceivedDate = _prmWorkOrderMovable.SurveyResultReceivedDate;
            _resultWorkOrderMovable.RowStatus = _prmWorkOrderMovable.RowStatus;
            _resultWorkOrderMovable.CreatedBy = _prmWorkOrderMovable.CreatedBy;
            _resultWorkOrderMovable.CreatedDate = _prmWorkOrderMovable.CreatedDate;
            _resultWorkOrderMovable.ModifiedBy = _prmWorkOrderMovable.ModifiedBy;
            _resultWorkOrderMovable.ModifiedDate = _prmWorkOrderMovable.ModifiedDate;
            //_resultWorkOrderMovable.Timestamp = _prmWorkOrderMovable.Timestamp;

            long _woMovableID = 0;
            _workOrderBL.InsertWorkOrderMovableWCF(_resultWorkOrderMovable, ref _woMovableID);
            if (_woMovableID == null)
            {
                _errorWCF = "Failed InsertWorkOrderMovableWCF. ID = " + Convert.ToString(_woMovableID);
            }

            //GSI.BusinessEntity.BusinessEntities.TrResultMovable _resultMov = this._resultBL.GetSingleResultMovableByResultMovableID(_prmResultMovable.ResultMovableID);
            GSI.BusinessEntity.BusinessEntities.TrResultMovable _resultMov = new GSI.BusinessEntity.BusinessEntities.TrResultMovable();
            _resultMov.ResultMovableID = _prmResultMovable.ResultMovableID;
            _resultMov.WorkOrderMovableID = _woMovableID;
            _resultMov.HouseStatus = _prmResultMovable.HouseStatus;
            _resultMov.LengthOfStay = _prmResultMovable.LengthOfStay;
            _resultMov.ResidenceConditions = _prmResultMovable.ResidenceConditions;
            _resultMov.EnvironmentalConditions = _prmResultMovable.EnvironmentalConditions;
            _resultMov.BuildingArea = _prmResultMovable.BuildingArea;            
            _resultMov.PersonalCharacter = _prmResultMovable.PersonalCharacter;
            //_resultMov.Others = _prmResultMovable.Others;
            _resultMov.Remark = _prmResultMovable.Remark;
            _resultMov.RowStatus = _prmResultMovable.RowStatus;
            _resultMov.CreatedBy = _prmResultMovable.CreatedBy;
            _resultMov.CreatedDate = _prmResultMovable.CreatedDate;
            _resultMov.ModifiedBy = _prmResultMovable.ModifiedBy;
            _resultMov.ModifiedDate = _prmResultMovable.ModifiedDate;
            //_resultMov.Timestamp = _prmResultMovable.Timestamp;

            //_resultBL.UpdateResultMovable(_resultMov);
            long _resultMovID = 0;
            _resultBL.InsertResultMovableWCF(_resultMov, ref _resultMovID);
            if (_resultMovID == null)
            {
                _errorWCF = "Failed InsertResultMovableWCF. ID = " + Convert.ToString(_resultMovID);
            }

            foreach (var _item in _prmResultPhotoAddtMovable)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = this._resultBL.GetSingleResultPhotoAddMovByResultPhotoAddMovID(_item.ResultPhotoAdditionalMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable _resultPhotoAddtMov = new GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalMovable();
                //_resultPhotoAddtMov.ResultPhotoAdditionalMovableID = _item.ResultPhotoAdditionalMovableID;
                _resultPhotoAddtMov.ResultMovableID = _resultMovID;
                _resultPhotoAddtMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtMov.Longitude = _item.Longitude;
                _resultPhotoAddtMov.Latitude = _item.Latitude;
                //_resultPhotoAddtMov.UploadDate = _item.uploadDate;
                _resultPhotoAddtMov.UploadDate = DateTime.Now;
                _resultPhotoAddtMov.Remark = _item.Remark;
                _resultPhotoAddtMov.RowStatus = _item.RowStatus;
                _resultPhotoAddtMov.CreatedBy = _item.CreatedBy;
                _resultPhotoAddtMov.CreatedDate = _item.CreatedDate;
                _resultPhotoAddtMov.ModifiedBy = _item.ModifiedBy;
                _resultPhotoAddtMov.ModifiedDate = _item.ModifiedDate;
                //_resultPhotoAddtMov.Timestamp = _item.Timestamp;
                _resultPhotoAddtMov.ImageGuid = _item.ImageGuid;

                //_resultBL.UpdateResultPhotoAddMov(_resultPhotoAddtMov);
                long _resultPhotoAdditionalMovableID = 0;
                _resultBL.InsertResultPhotoAddMovWCF(_resultPhotoAddtMov, ref _resultPhotoAdditionalMovableID);
                if (_resultPhotoAdditionalMovableID == null)
                {
                    _errorWCF = "Failed InsertResultPhotoAddMovWCF. ID = " + Convert.ToString(_resultPhotoAdditionalMovableID);
                }
            }

            foreach (var _item in _prmResultReqDocMovableList)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = this._resultBL.GetSingleResultReqDocMovableByResultReqDocMovableID(_item.ResultReqDocMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable _resultReqDocMov = new GSI.BusinessEntity.BusinessEntities.TrResultReqDocMovable();

                //_resultReqDocMov.ResultReqDocMovableID = _item.ResultReqDocMovableID;
                _resultReqDocMov.ResultMovableID = _resultMovID;
                _resultReqDocMov.ReqDocMovableID = _item.ReqDocMovableID;
                _resultReqDocMov.PhotoName = _item.PhotoName;
                _resultReqDocMov.Longitude = _item.Longitude;
                _resultReqDocMov.Latitude = _item.Latitude;
                //_resultReqDocMov.UploadDate = _item.UploadDate;
                _resultReqDocMov.UploadDate = DateTime.Now;
                _resultReqDocMov.Remark = _item.Remark;
                _resultReqDocMov.RowStatus = _item.RowStatus;
                _resultReqDocMov.CreatedBy = _item.CreatedBy;
                _resultReqDocMov.CreatedDate = _item.CreatedDate;
                _resultReqDocMov.ModifiedBy = _item.ModifiedBy;
                _resultReqDocMov.ModifiedDate = _item.ModifiedDate;
                //_resultReqDocMov.Timestamp = _item.Timestamp;
                _resultReqDocMov.ImageGuid = _item.ImageGuid;

                //_resultBL.UpdateResultReqDocMovable(_resultReqDocMov);
                long _resultReqDocMovableID = 0;
                _resultBL.InsertResultReqDocMovableWCF(_resultReqDocMov, ref _resultReqDocMovableID);
                if (_resultReqDocMovableID == null)
                {
                    _errorWCF = "Failed InsertResultReqDocMovableWCF. ID = " + Convert.ToString(_resultReqDocMovableID);
                }
            }

            
            //
        }

        public void UpdateResultNotMovableCustomerPortal(TrWorkOrderNotMovable _prmWorkOrderNotMovable, TrResultNotMovable _prmResultNotMovable, List<TrResultPhotoAdditionalNotMovable> _prmResultPhotoAddtNotMovable, List<TrResultReqDocNotMovable> _prmResultReqDocNotMovableList)
        {
            GSI.BusinessEntity.BusinessEntities.TrWorkOrderNotMovable _resultWorkOrderNotMovable = new GSI.BusinessEntity.BusinessEntities.TrWorkOrderNotMovable();
            //_resultWorkOrderNotMovable.WorkOrderNotMovableID = _prmWorkOrderNotMovable.WorkOrderNotMovableID;
            _resultWorkOrderNotMovable.OrderSPNotMovableID = _prmWorkOrderNotMovable.OrderSPNotMovableID;
            _resultWorkOrderNotMovable.SurveyorID = _prmWorkOrderNotMovable.SurveyorID;
            _resultWorkOrderNotMovable.WorkOrderCode = _prmWorkOrderNotMovable.WorkOrderCode;
            _resultWorkOrderNotMovable.DateCreate = _prmWorkOrderNotMovable.DateCreate;
            _resultWorkOrderNotMovable.DateExecute = _prmWorkOrderNotMovable.DateExecute;
            _resultWorkOrderNotMovable.WorkOrderStatusID = _prmWorkOrderNotMovable.WorkOrderStatusID;
            _resultWorkOrderNotMovable.SyncStatus = _prmWorkOrderNotMovable.SyncStatus;
            _resultWorkOrderNotMovable.Remark = _prmWorkOrderNotMovable.Remark;
            _resultWorkOrderNotMovable.DownloadDate = _prmWorkOrderNotMovable.DownloadDate;
            _resultWorkOrderNotMovable.OnTheWayDate = _prmWorkOrderNotMovable.OnTheWayDate;
            _resultWorkOrderNotMovable.OnTheSpotDate = _prmWorkOrderNotMovable.OnTheSpotDate;
            _resultWorkOrderNotMovable.SurveyResultReceivedDate = _prmWorkOrderNotMovable.SurveyResultReceivedDate;
            _resultWorkOrderNotMovable.RowStatus = _prmWorkOrderNotMovable.RowStatus;
            _resultWorkOrderNotMovable.CreatedBy = _prmWorkOrderNotMovable.CreatedBy;
            _resultWorkOrderNotMovable.CreatedDate = _prmWorkOrderNotMovable.CreatedDate;
            _resultWorkOrderNotMovable.ModifiedBy = _prmWorkOrderNotMovable.ModifiedBy;
            _resultWorkOrderNotMovable.ModifiedDate = _prmWorkOrderNotMovable.ModifiedDate;
            //_resultWorkOrderNotMovable.Timestamp = _prmWorkOrderNotMovable.Timestamp;

            long _woNotMovableID = 0;
            _workOrderBL.InsertWorkOrderNotMovableWCF(_resultWorkOrderNotMovable, ref _woNotMovableID);
            if (_woNotMovableID == null)
            {
                _errorWCF = "Failed InsertWorkOrderNotMovableWCF. ID = " + Convert.ToString(_woNotMovableID);
            }

            //GSI.BusinessEntity.BusinessEntities.TrResultNotMovable _resultMov = this._resultBL.GetSingleResultNotMovableByResultNotMovableID(_prmResultNotMovable.ResultNotMovableID);
            GSI.BusinessEntity.BusinessEntities.TrResultNotMovable _resultNotMov = new GSI.BusinessEntity.BusinessEntities.TrResultNotMovable();
            _resultNotMov.ResultNotMovableID = _prmResultNotMovable.ResultNotMovableID;
            _resultNotMov.WorkOrderNotMovableID = _woNotMovableID;
            //_resultNotMov.BusinessLine = _prmResultNotMovable.BusinessLine;
            _resultNotMov.CompanyCondition = _prmResultNotMovable.CompanyCondition;
            _resultNotMov.CompanyPeriod = _prmResultNotMovable.CompanyPeriod;
            //_resultNotMov.Others = _prmResultNotMovable.Others;
            _resultNotMov.Position = _prmResultNotMovable.Position;
            _resultNotMov.WorkingPeriod = _prmResultNotMovable.WorkingPeriod;
            _resultNotMov.Remark = _prmResultNotMovable.Remark;
            _resultNotMov.RowStatus = _prmResultNotMovable.RowStatus;
            _resultNotMov.CreatedBy = _prmResultNotMovable.CreatedBy;
            _resultNotMov.CreatedDate = _prmResultNotMovable.CreatedDate;
            _resultNotMov.ModifiedBy = _prmResultNotMovable.ModifiedBy;
            _resultNotMov.ModifiedDate = _prmResultNotMovable.ModifiedDate;
            //_resultMov.Timestamp = _prmResultNotMovable.Timestamp;

            //_resultBL.UpdateResultNotMovable(_resultMov);
            long _resultNotMovID = 0;
            _resultBL.InsertResultNotMovableWCF(_resultNotMov, ref _resultNotMovID);
            if (_resultNotMovID == null)
            {
                _errorWCF = "Failed InsertResultNotMovableWCF. ID = " + Convert.ToString(_resultNotMovID);
            }

            foreach (var _item in _prmResultPhotoAddtNotMovable)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtMov = this._resultBL.GetSingleResultPhotoAddMovByResultPhotoAddMovID(_item.ResultPhotoAdditionalNotMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable _resultPhotoAddtNotMov = new GSI.BusinessEntity.BusinessEntities.TrResultPhotoAdditionalNotMovable();
                //_resultPhotoAddtMov.ResultPhotoAdditionalNotMovableID = _item.ResultPhotoAdditionalNotMovableID;
                _resultPhotoAddtNotMov.ResultNotMovableID = _resultNotMovID;
                _resultPhotoAddtNotMov.PhotoName = _item.PhotoName;
                _resultPhotoAddtNotMov.Longitude = _item.Longitude;
                _resultPhotoAddtNotMov.Latitude = _item.Latitude;
                //_resultPhotoAddtMov.UploadDate = _item.uploadDate;
                _resultPhotoAddtNotMov.UploadDate = DateTime.Now;
                _resultPhotoAddtNotMov.Remark = _item.Remark;
                _resultPhotoAddtNotMov.RowStatus = _item.RowStatus;
                _resultPhotoAddtNotMov.CreatedBy = _item.CreatedBy;
                _resultPhotoAddtNotMov.CreatedDate = _item.CreatedDate;
                _resultPhotoAddtNotMov.ModifiedBy = _item.ModifiedBy;
                _resultPhotoAddtNotMov.ModifiedDate = _item.ModifiedDate;
                //_resultPhotoAddtMov.Timestamp = _item.Timestamp;
                _resultPhotoAddtNotMov.ImageGuid = _item.ImageGuid;

                //_resultBL.UpdateResultPhotoAddMov(_resultPhotoAddtMov);
                long _resultPhotoAdditionalNotMovableID = 0;
                _resultBL.InsertResultPhotoAddNotMovWCF(_resultPhotoAddtNotMov, ref _resultPhotoAdditionalNotMovableID);
                if (_resultPhotoAdditionalNotMovableID == null)
                {
                    _errorWCF = "Failed InsertResultPhotoAddNotMovWCF. ID = " + Convert.ToString(_resultPhotoAdditionalNotMovableID);
                }
            }

            foreach (var _item in _prmResultReqDocNotMovableList)
            {
                //GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable _resultReqDocMov = this._resultBL.GetSingleResultReqDocNotMovableByResultReqDocNotMovableID(_item.ResultReqDocNotMovableID);
                GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable _resultReqDocNotMov = new GSI.BusinessEntity.BusinessEntities.TrResultReqDocNotMovable();

                //_resultReqDocMov.ResultReqDocNotMovableID = _item.ResultReqDocNotMovableID;
                _resultReqDocNotMov.ResultNotMovableID = _resultNotMovID;
                _resultReqDocNotMov.ReqDocNotMovableID = _item.ReqDocNotMovableID;
                _resultReqDocNotMov.PhotoName = _item.PhotoName;
                _resultReqDocNotMov.Longitude = _item.Longitude;
                _resultReqDocNotMov.Latitude = _item.Latitude;
                //_resultReqDocMov.UploadDate = _item.UploadDate;
                _resultReqDocNotMov.UploadDate = DateTime.Now;
                _resultReqDocNotMov.Remark = _item.Remark;
                _resultReqDocNotMov.RowStatus = _item.RowStatus;
                _resultReqDocNotMov.CreatedBy = _item.CreatedBy;
                _resultReqDocNotMov.CreatedDate = _item.CreatedDate;
                _resultReqDocNotMov.ModifiedBy = _item.ModifiedBy;
                _resultReqDocNotMov.ModifiedDate = _item.ModifiedDate;
                //_resultReqDocMov.Timestamp = _item.Timestamp;
                _resultReqDocNotMov.ImageGuid = _item.ImageGuid;

                //_resultBL.UpdateResultReqDocNotMovable(_resultReqDocMov);
                long _resultReqDocNotMovableID = 0;
                _resultBL.InsertResultReqDocNotMovableWCF(_resultReqDocNotMov, ref _resultReqDocNotMovableID);
                if (_resultReqDocNotMovableID == null)
                {
                    _errorWCF = "Failed InsertResultReqDocNotMovableWCF. ID = " + Convert.ToString(_resultReqDocNotMovableID);
                }                
            }
        }
    }
}
