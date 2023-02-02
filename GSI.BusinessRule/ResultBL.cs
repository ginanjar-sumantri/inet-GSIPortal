using System;
using System.Collections.Generic;
using System.Data;
using GSI.BusinessEntity.BusinessEntities;
using GSI.Common;
using GSI.Common.Enum;

namespace GSI.BusinessRule
{
    public class ResultBL : Base
    {
        #region Standard
        public TrResultMovable GetSingleResultMovableByResultMovableID(Int64 _prmResultMovableID)
        {
            TrResultMovable _result = new TrResultMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultMovableByResultMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultMovable _resultMov = new TrResultMovable();
                    _resultMov.ResultMovableID = (long)dr["ResultMovableID"];
                    _resultMov.WorkOrderMovableID = (long)dr["WorkOrderMovableID"];
                    _resultMov.BuildingArea = (dr["BuildingArea"] == DBNull.Value) ? String.Empty : (String)dr["BuildingArea"];
                    _resultMov.EnvironmentalConditions = (dr["EnvironmentalConditions"] == DBNull.Value) ? String.Empty : (String)dr["EnvironmentalConditions"];
                    _resultMov.HouseStatus = (dr["HouseStatus"] == DBNull.Value) ? String.Empty : (String)dr["HouseStatus"];
                    _resultMov.LengthOfStay = (dr["LengthOfStay"] == DBNull.Value) ? String.Empty : (String)dr["LengthOfStay"];
                    //_resultMov.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _resultMov.PersonalCharacter = (dr["PersonalCharacter"] == DBNull.Value) ? String.Empty : (String)dr["PersonalCharacter"]; 
                    _resultMov.ResidenceConditions = (dr["ResidenceConditions"] == DBNull.Value) ? String.Empty : (String)dr["ResidenceConditions"];
                    _resultMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];  
                    _resultMov.RowStatus = (int)dr["RowStatus"];
                    _resultMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultMovable(TrResultMovable _prmResultMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@buildingArea", _prmResultMovable.BuildingArea, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmResultMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@environmentalConditions", _prmResultMovable.EnvironmentalConditions, DbType.String));
            _param.Add(new SPParam("@houseStatus", _prmResultMovable.HouseStatus, DbType.String));
            _param.Add(new SPParam("@lengthOfStay", _prmResultMovable.LengthOfStay, DbType.String));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            //_param.Add(new SPParam("@others", _prmResultMovable.Others, DbType.String));
            _param.Add(new SPParam("@personalCharacter", _prmResultMovable.PersonalCharacter, DbType.String));            
            _param.Add(new SPParam("@remark", _prmResultMovable.Remark, DbType.String));
            _param.Add(new SPParam("@residenceConditions", _prmResultMovable.ResidenceConditions, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmResultMovable.RowStatus, DbType.Int32));            
            _param.Add(new SPParam("@workOrderMovableID", _prmResultMovable.WorkOrderMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultMovable(TrResultMovable _prmResultMovable)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultMovable.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@workOrderMovableID", _prmResultMovable.WorkOrderMovableID, DbType.Int64));
            _param.Add(new SPParam("@buildingArea", _prmResultMovable.BuildingArea, DbType.String));
            _param.Add(new SPParam("@environmentalConditions", _prmResultMovable.EnvironmentalConditions, DbType.String));
            _param.Add(new SPParam("@houseStatus", _prmResultMovable.HouseStatus, DbType.String));
            _param.Add(new SPParam("@lengthOfStay", _prmResultMovable.LengthOfStay, DbType.String));
            //_param.Add(new SPParam("@others", _prmResultMovable.Others, DbType.String));
            _param.Add(new SPParam("@personalCharacter", _prmResultMovable.PersonalCharacter, DbType.String));            
            _param.Add(new SPParam("@remark", _prmResultMovable.Remark, DbType.String));
            _param.Add(new SPParam("@residenceConditions", _prmResultMovable.ResidenceConditions, DbType.String));            
            _param.Add(new SPParam("@rowStatus", _prmResultMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultMovable.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultMovable.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }


        public TrResultNotMovable GetSingleResultNotMovableByResultNotMovableID(Int64 _prmResultNotMovableID)
        {
            TrResultNotMovable _result = new TrResultNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultNotMovableByResultNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultNotMovable _resultNotMov = new TrResultNotMovable();
                    _resultNotMov.ResultNotMovableID = (long)dr["ResultNotMovableID"];
                    _resultNotMov.WorkOrderNotMovableID = (long)dr["WorkOrderNotMovableID"];
                    //_resultNotMov.BusinessLine = (String)dr["BusinessLine"];
                    _resultNotMov.CompanyCondition = (String)dr["CompanyCondition"];
                    _resultNotMov.CompanyPeriod = (dr["CompanyPeriod"] == DBNull.Value) ? String.Empty : (String)dr["CompanyPeriod"];
                    //_resultNotMov.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _resultNotMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _resultNotMov.Position = (dr["Position"] == DBNull.Value) ? String.Empty : (String)dr["Position"];
                    _resultNotMov.WorkingPeriod = (dr["WorkingPeriod"] == DBNull.Value) ? String.Empty : (String)dr["WorkingPeriod"];
                    _resultNotMov.RowStatus = (int)dr["RowStatus"];
                    _resultNotMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultNotMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultNotMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultNotMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultNotMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultNotMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultNotMovable(TrResultNotMovable _prmResultNotMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderNotMovableID", _prmResultNotMovable.WorkOrderNotMovableID, DbType.Int64));
            //_param.Add(new SPParam("@businessLine", _prmResultNotMovable.BusinessLine, DbType.String));
            _param.Add(new SPParam("@companyCondition", _prmResultNotMovable.CompanyCondition, DbType.String));
            _param.Add(new SPParam("@companyPeriod", _prmResultNotMovable.CompanyPeriod, DbType.String));
            //_param.Add(new SPParam("@others", _prmResultNotMovable.Others, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@position", _prmResultNotMovable.Position, DbType.String));
            _param.Add(new SPParam("@workingPeriod", _prmResultNotMovable.WorkingPeriod, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmResultNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultNotMovable(TrResultNotMovable _prmResultNotMovable)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultNotMovable.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@workOrderNotMovableID", _prmResultNotMovable.WorkOrderNotMovableID, DbType.Int64));
            //_param.Add(new SPParam("@businessLine", _prmResultNotMovable.BusinessLine, DbType.String));
            _param.Add(new SPParam("@companyCondition", _prmResultNotMovable.CompanyCondition, DbType.String));
            _param.Add(new SPParam("@companyPeriod", _prmResultNotMovable.CompanyPeriod, DbType.String));
            //_param.Add(new SPParam("@others", _prmResultNotMovable.Others, DbType.String));
            _param.Add(new SPParam("@position", _prmResultNotMovable.Position, DbType.String));
            _param.Add(new SPParam("@workingPeriod", _prmResultNotMovable.WorkingPeriod, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmResultNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultNotMovable.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }


        public TrResultPhotoAdditionalMovable GetSingleResultPhotoAddMovByResultPhotoAddMovID(Int64 _prmResultPhotoAddMovID)
        {
            TrResultPhotoAdditionalMovable _result = new TrResultPhotoAdditionalMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultPhotoAdditionalMovableID", _prmResultPhotoAddMovID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultPhotoAdditionalMovableByResultPhotoAdditionalMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultPhotoAdditionalMovable _resultPhotoAddMov = new TrResultPhotoAdditionalMovable();
                    _resultPhotoAddMov.ResultPhotoAdditionalMovableID = (long)dr["ResultPhotoAdditionalMovableID"];
                    _resultPhotoAddMov.ResultMovableID = (long)dr["ResultMovableID"];
                    _resultPhotoAddMov.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _resultPhotoAddMov.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _resultPhotoAddMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _resultPhotoAddMov.Longitude = (String)dr["Longitude"];
                    _resultPhotoAddMov.Latitude = (String)dr["Latitude"];
                    _resultPhotoAddMov.UploadDate = (DateTime)dr["UploadDate"];
                    _resultPhotoAddMov.RowStatus = (int)dr["RowStatus"];
                    _resultPhotoAddMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultPhotoAddMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultPhotoAddMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultPhotoAddMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultPhotoAddMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultPhotoAddMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultPhotoAddMov(TrResultPhotoAdditionalMovable _prmResultPhotoAddMov, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultPhotoAddMov.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultPhotoAdditionalMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultPhotoAdditionalMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultPhotoAddMov(TrResultPhotoAdditionalMovable _prmResultPhotoAddMov)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultPhotoAdditionalMovableID", _prmResultPhotoAddMov.ResultPhotoAdditionalMovableID, DbType.Int64));
            _param.Add(new SPParam("@resultMovableID", _prmResultPhotoAddMov.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultPhotoAddMov.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultPhotoAdditionalMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }


        public TrResultPhotoAdditionalNotMovable GetSingleResultPhotoAddNotMovByResultPhotoAddNotMovID(Int64 _prmResultPhotoAddNotMovID)
        {
            TrResultPhotoAdditionalNotMovable _result = new TrResultPhotoAdditionalNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultPhotoAdditionalNotMovableID", _prmResultPhotoAddNotMovID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultPhotoAdditionalNotMovableByResultPhotoAdditionalNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultPhotoAdditionalNotMovable _resultPhotoAddNotMov = new TrResultPhotoAdditionalNotMovable();
                    _resultPhotoAddNotMov.ResultPhotoAdditionalNotMovableID = (long)dr["ResultPhotoAdditionalNotMovableID"];
                    _resultPhotoAddNotMov.ResultNotMovableID = (long)dr["ResultNotMovableID"];
                    _resultPhotoAddNotMov.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _resultPhotoAddNotMov.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _resultPhotoAddNotMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _resultPhotoAddNotMov.Longitude = (String)dr["Longitude"];
                    _resultPhotoAddNotMov.Latitude = (String)dr["Latitude"];
                    _resultPhotoAddNotMov.UploadDate = (DateTime)dr["UploadDate"];
                    _resultPhotoAddNotMov.RowStatus = (int)dr["RowStatus"];
                    _resultPhotoAddNotMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultPhotoAddNotMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultPhotoAddNotMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultPhotoAddNotMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultPhotoAddNotMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultPhotoAddNotMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultPhotoAddNotMov(TrResultPhotoAdditionalNotMovable _prmResultPhotoAddNotMov, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultPhotoAddNotMov.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddNotMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddNotMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddNotMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddNotMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddNotMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddNotMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddNotMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddNotMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddNotMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultPhotoAdditionalNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultPhotoAdditionalNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultPhotoAddNotMov(TrResultPhotoAdditionalNotMovable _prmResultPhotoAddNotMov)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultPhotoAdditionalNotMovableID", _prmResultPhotoAddNotMov.ResultPhotoAdditionalNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@resultNotMovableID", _prmResultPhotoAddNotMov.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddNotMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddNotMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddNotMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddNotMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddNotMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddNotMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddNotMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddNotMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddNotMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultPhotoAddNotMov.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultPhotoAdditionalNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }


        public TrResultReqDocMovable GetSingleResultReqDocMovableByResultReqDocMovableID(Int64 _prmResultReqDocMovableID)
        {
            TrResultReqDocMovable _result = new TrResultReqDocMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultReqDocMovableID", _prmResultReqDocMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultReqDocMovableByResultReqDocMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultReqDocMovable _resultReqDocMov = new TrResultReqDocMovable();
                    _resultReqDocMov.ResultReqDocMovableID = (long)dr["ResultReqDocMovableID"];
                    _resultReqDocMov.ResultMovableID = (long)dr["ResultMovableID"];
                    _resultReqDocMov.ReqDocMovableID = (long)dr["ReqDocMovableID"];
                    _resultReqDocMov.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _resultReqDocMov.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _resultReqDocMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _resultReqDocMov.Longitude = (String)dr["Longitude"];
                    _resultReqDocMov.Latitude = (String)dr["Latitude"];
                    _resultReqDocMov.UploadDate = (DateTime)dr["UploadDate"];
                    _resultReqDocMov.RowStatus = (int)dr["RowStatus"];
                    _resultReqDocMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultReqDocMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultReqDocMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultReqDocMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultReqDocMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultReqDocMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultReqDocMovable(TrResultReqDocMovable _prmResultReqDocMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultReqDocMovable.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocMovableID", _prmResultReqDocMovable.ReqDocMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultReqDocMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultReqDocMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultReqDocMovable(TrResultReqDocMovable _prmResultReqDocMovable)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultReqDocMovableID", _prmResultReqDocMovable.ResultReqDocMovableID, DbType.Int64));
            _param.Add(new SPParam("@resultMovableID", _prmResultReqDocMovable.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocMovableID", _prmResultReqDocMovable.ReqDocMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultReqDocMovable.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultReqDocMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }


        public TrResultReqDocNotMovable GetSingleResultReqDocNotMovableByResultReqDocNotMovableID(Int64 _prmResultReqDocNotMovableID)
        {
            TrResultReqDocNotMovable _result = new TrResultReqDocNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultReqDocNotMovableID", _prmResultReqDocNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "GetTrResultReqDocNotMovableByResultReqDocNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultReqDocNotMovable _resultReqDocNotMov = new TrResultReqDocNotMovable();
                    _resultReqDocNotMov.ResultReqDocNotMovableID = (long)dr["ResultReqDocNotMovableID"];
                    _resultReqDocNotMov.ResultNotMovableID = (long)dr["ResultNotMovableID"];
                    _resultReqDocNotMov.ReqDocNotMovableID = (long)dr["ReqDocNotMovableID"];
                    _resultReqDocNotMov.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _resultReqDocNotMov.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _resultReqDocNotMov.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _resultReqDocNotMov.Longitude = (String)dr["Longitude"];
                    _resultReqDocNotMov.Latitude = (String)dr["Latitude"];
                    _resultReqDocNotMov.UploadDate = (DateTime)dr["UploadDate"];
                    _resultReqDocNotMov.RowStatus = (int)dr["RowStatus"];
                    _resultReqDocNotMov.CreatedBy = (String)dr["CreatedBy"];
                    _resultReqDocNotMov.CreatedDate = (DateTime)dr["CreatedDate"];
                    _resultReqDocNotMov.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _resultReqDocNotMov.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _resultReqDocNotMov.Timestamp = (byte[])dr["Timestamp"];
                    _result = _resultReqDocNotMov;
                }
                dr.Close();
            }

            return _result;
        }
        public Boolean InsertResultReqDocNotMovable(TrResultReqDocNotMovable _prmResultReqDocNotMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultReqDocNotMovable.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocNotMovableID", _prmResultReqDocNotMovable.ReqDocNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocNotMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocNotMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocNotMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocNotMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocNotMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultReqDocNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultReqDocNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }
        public Boolean UpdateResultReqDocNotMovable(TrResultReqDocNotMovable _prmResultReqDocNotMovable)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultReqDocNotMovableID", _prmResultReqDocNotMovable.ResultReqDocNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@resultNotMovableID", _prmResultReqDocNotMovable.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocNotMovableID", _prmResultReqDocNotMovable.ReqDocNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocNotMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocNotMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocNotMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocNotMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocNotMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", "", DbType.String));
            _param.Add(new SPParam("@modifiedDate", DateTime.Now, DbType.DateTime));
            _param.Add(new SPParam("@timestamp", _prmResultReqDocNotMovable.Timestamp, DbType.Binary));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "UpdateTrResultReqDocNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _result = true;
            }

            return _result;
        }
        #endregion

        public ResultMoveable GetResultMovable(Int64 _prmOrderSPID, Byte _prmWorkOrderStatusID)
        {
            ResultMoveable _result = new ResultMoveable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPMoveableID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@WorkOrderStatusID", _prmWorkOrderStatusID, DbType.Byte));
            //_param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetResultMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    ResultMoveable _ResultMoveable = new ResultMoveable();

                    _ResultMoveable.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _ResultMoveable.ResultMovableID = (long)dr["ResultMovableID"];
                    _ResultMoveable.HomeAddress = (String)dr["HomeAddress"];
                    _ResultMoveable.Clue = (String)dr["Clue"];
                    _ResultMoveable.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _ResultMoveable.HouseStatus = (dr["HouseStatus"] == DBNull.Value) ? String.Empty : (String)dr["HouseStatus"];
                    _ResultMoveable.LengthOfStay = (dr["LengthOfStay"] == DBNull.Value) ? String.Empty : (String)dr["LengthOfStay"];
                    _ResultMoveable.ResidenceConditions = (dr["ResidenceConditions"] == DBNull.Value) ? String.Empty : (String)dr["ResidenceConditions"];
                    _ResultMoveable.EnvironmentalConditions = (dr["EnvironmentalConditions"] == DBNull.Value) ? String.Empty : (String)dr["EnvironmentalConditions"];
                    _ResultMoveable.BuildingArea = (dr["BuildingArea"] == DBNull.Value) ? String.Empty : (String)dr["BuildingArea"];
                    _ResultMoveable.PersonalCharacter = (dr["PersonalCharacter"] == DBNull.Value) ? String.Empty : (String)dr["PersonalCharacter"];
                    _ResultMoveable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    //_ResultMoveable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _ResultMoveable.ReqDocMovableID = (long)dr["ReqDocMovableID"];
                    _ResultMoveable.JobTitle = (dr["JobTitle"] == DBNull.Value) ? String.Empty : (String)dr["JobTitle"];
                    _ResultMoveable.JobType = (dr["JobType"] == DBNull.Value) ? String.Empty : (String)dr["JobType"];
                    _ResultMoveable.BusinessLine = (dr["BusinessLine"] == DBNull.Value) ? String.Empty : (String)dr["BusinessLine"];
                    
                    _result = _ResultMoveable;
                }
                dr.Close();
            }

            return _result;
        }

        public ResultNotMovable GetResultNotMovable(Int64 _prmOrderSPID, Byte _prmWorkOrderStatusID)
        {
            ResultNotMovable _result = new ResultNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMoveableID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@WorkOrderStatusID", _prmWorkOrderStatusID, DbType.Byte));
            //_param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetResultNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    ResultNotMovable _ResultNotMoveable = new ResultNotMovable();

                    _ResultNotMoveable.SurveyPointName = (dr["SurveyPointName"] == DBNull.Value) ? "" : (String)dr["SurveyPointName"];
                    _ResultNotMoveable.BusinessTypeID = (long)dr["BusinessTypeID"];
                    _ResultNotMoveable.Address = (String)dr["Address"];
                    _ResultNotMoveable.Clue = (String)dr["Clue"];
                    _ResultNotMoveable.ZipCode = (dr["ZipCode"] == DBNull.Value) ? String.Empty : (String)dr["ZipCode"];
                    _ResultNotMoveable.ResultNotMovableID = (long)dr["ResultNotMovableID"];
                    _ResultNotMoveable.CompanyPeriod = (dr["CompanyPeriod"] == DBNull.Value) ? String.Empty : (String)dr["CompanyPeriod"];
                    _ResultNotMoveable.Position = (dr["Position"] == DBNull.Value) ? String.Empty : (String)dr["Position"];
                    _ResultNotMoveable.WorkingPeriod = (dr["WorkingPeriod"] == DBNull.Value) ? String.Empty : (String)dr["WorkingPeriod"];
                    _ResultNotMoveable.CompanyCondition = (dr["CompanyCondition"] == DBNull.Value) ? String.Empty : (String)dr["CompanyCondition"];
                    _ResultNotMoveable.ReqDocNotMovableID = (long)dr["ReqDocNotMovableID"];
                    _ResultNotMoveable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    //_ResultNotMoveable.BusinessLine = (String)dr["BusinessLine"];
                    //_ResultNotMoveable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _result = _ResultNotMoveable;
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultPhotoAdditionalMovable> GetResultAdditionalPhotobyResultMovableID(Int64 _prmResultMovableID)
        {
            List<TrResultPhotoAdditionalMovable> _result = new List<TrResultPhotoAdditionalMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultPhotoAdditionalMovableByResultMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultPhotoAdditionalMovable _trResultPhotoAdditionalMovable = new TrResultPhotoAdditionalMovable();
                    _trResultPhotoAdditionalMovable.ResultPhotoAdditionalMovableID = (Int64)dr["ResultPhotoAdditionalMovableID"];
                    _trResultPhotoAdditionalMovable.ResultMovableID = (Int64)dr["ResultMovableID"];
                    _trResultPhotoAdditionalMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultPhotoAdditionalMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultPhotoAdditionalMovable.Longitude = (String)dr["Longitude"];
                    _trResultPhotoAdditionalMovable.Latitude = (String)dr["Latitude"];
                    _trResultPhotoAdditionalMovable.UploadDate = (DateTime)dr["UploadDate"];
                    _trResultPhotoAdditionalMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultPhotoAdditionalMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trResultPhotoAdditionalMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultPhotoAdditionalMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultPhotoAdditionalMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trResultPhotoAdditionalMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trResultPhotoAdditionalMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_trResultPhotoAdditionalMovable);
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultPhotoAdditionalNotMovable> GetResultAdditionalPhotobyResultNotMovableID(Int64 _prmResultNotMovableID)
        {
            List<TrResultPhotoAdditionalNotMovable> _result = new List<TrResultPhotoAdditionalNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultNotMovableID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultPhotoAdditionalNotMovableByResultNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultPhotoAdditionalNotMovable _trResultPhotoAdditionalNotMovable = new TrResultPhotoAdditionalNotMovable();
                    _trResultPhotoAdditionalNotMovable.ResultPhotoAdditionalNotMovableID = (Int64)dr["ResultPhotoAdditionalNotMovableID"];
                    _trResultPhotoAdditionalNotMovable.ResultNotMovableID = (Int64)dr["ResultNotMovableID"];
                    _trResultPhotoAdditionalNotMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultPhotoAdditionalNotMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultPhotoAdditionalNotMovable.Longitude = (String)dr["Longitude"];
                    _trResultPhotoAdditionalNotMovable.Latitude = (String)dr["Latitude"];
                    _trResultPhotoAdditionalNotMovable.UploadDate = (DateTime)dr["UploadDate"];
                    _trResultPhotoAdditionalNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultPhotoAdditionalNotMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trResultPhotoAdditionalNotMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultPhotoAdditionalNotMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultPhotoAdditionalNotMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trResultPhotoAdditionalNotMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trResultPhotoAdditionalNotMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_trResultPhotoAdditionalNotMovable);
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultReqDocMovable> GetResultReqDocMoveable(Int64 _prmOrderSPID, Int64 _prmDocType)
        {
            List<TrResultReqDocMovable> _result = new List<TrResultReqDocMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPMovableID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@DocumentType", _prmDocType, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetResultReqDocMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultReqDocMovable _trResultReqDocMovable = new TrResultReqDocMovable();
                    _trResultReqDocMovable.ResultReqDocMovableID = (Int64)dr["ResultReqDocMovableID"];
                    _trResultReqDocMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultReqDocMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultReqDocMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultReqDocMovable.Longitude = (String)dr["Longitude"];
                    _trResultReqDocMovable.Latitude = (String)dr["Latitude"];

                    _result.Add(_trResultReqDocMovable);
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultReqDocNotMovable> GetResultReqDocNotMoveable(Int64 _prmOrderSPID, Int64 _prmDocType)
        {
            List<TrResultReqDocNotMovable> _result = new List<TrResultReqDocNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@OrderSPNotMovableID", _prmOrderSPID, DbType.Int64));
            _param.Add(new SPParam("@DocumentType", _prmDocType, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetResultReqDocNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultReqDocNotMovable _trResultReqDocNotMovable = new TrResultReqDocNotMovable();
                    _trResultReqDocNotMovable.ResultReqDocNotMovableID = (Int64)dr["ResultReqDocNotMovableID"];
                    _trResultReqDocNotMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultReqDocNotMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultReqDocNotMovable.Longitude = (dr["Longitude"] == DBNull.Value) ? String.Empty : (String)dr["Longitude"];
                    _trResultReqDocNotMovable.Latitude = (dr["Latitude"] == DBNull.Value) ? String.Empty : (String)dr["Latitude"];
                    _trResultReqDocNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];

                    _result.Add(_trResultReqDocNotMovable);
                }
                dr.Close();
            }

            return _result;
        }

        #region UseByWCF
        public TrResultMovable GetSingleTrResultMovable(Int64 _prmWorkOrderMovableID)
        {
            TrResultMovable _result = new TrResultMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderMovableID", _prmWorkOrderMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultMovableByWorkOrderMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultMovable _trResultMovable = new TrResultMovable();
                    _trResultMovable.ResultMovableID = (Int64)dr["ResultMovableID"];
                    _trResultMovable.WorkOrderMovableID = (Int64)dr["WorkOrderMovableID"];
                    _trResultMovable.HouseStatus = (dr["HouseStatus"] == DBNull.Value) ? String.Empty : (String)dr["HouseStatus"];
                    _trResultMovable.LengthOfStay = (dr["LengthOfStay"] == DBNull.Value) ? String.Empty : (String)dr["LengthOfStay"];
                    _trResultMovable.ResidenceConditions = (dr["ResidenceConditions"] == DBNull.Value) ? String.Empty : (String)dr["ResidenceConditions"];
                    _trResultMovable.EnvironmentalConditions = (dr["EnvironmentalConditions"] == DBNull.Value) ? String.Empty : (String)dr["EnvironmentalConditions"];
                    _trResultMovable.BuildingArea = (dr["BuildingArea"] == DBNull.Value) ? String.Empty : (String)dr["BuildingArea"];                    
                    _trResultMovable.PersonalCharacter = (dr["PersonalCharacter"] == DBNull.Value) ? String.Empty : (String)dr["PersonalCharacter"];
                    //_trResultMovable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _trResultMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultMovable.RowStatus = (int)dr["RowStatus"];
                    _trResultMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultMovable.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _trResultMovable.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _trResultMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result = _trResultMovable;
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultReqDocMovable> GetListTrResultReqDocMovable(Int64 _prmResultMovableID)
        {
            List<TrResultReqDocMovable> _result = new List<TrResultReqDocMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultReqDocMovableByResultMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultReqDocMovable _trResultReqDocMovable = new TrResultReqDocMovable();
                    _trResultReqDocMovable.ResultReqDocMovableID = (Int64)dr["ResultReqDocMovableID"];
                    _trResultReqDocMovable.ResultMovableID = (Int64)dr["ResultMovableID"];
                    _trResultReqDocMovable.ReqDocMovableID = (Int64)dr["ReqDocMovableID"];
                    _trResultReqDocMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultReqDocMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultReqDocMovable.Longitude = (String)dr["Longitude"];
                    _trResultReqDocMovable.Latitude = (String)dr["Latitude"];
                    _trResultReqDocMovable.UploadDate = (DateTime)dr["UploadDate"];
                    _trResultReqDocMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultReqDocMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trResultReqDocMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultReqDocMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultReqDocMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trResultReqDocMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trResultReqDocMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_trResultReqDocMovable);
                }
                dr.Close();
            }
            return _result;
        }

        public Boolean InsertResultMovableWCF(TrResultMovable _prmResultMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@buildingArea", _prmResultMovable.BuildingArea, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmResultMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@environmentalConditions", _prmResultMovable.EnvironmentalConditions, DbType.String));
            _param.Add(new SPParam("@houseStatus", _prmResultMovable.HouseStatus, DbType.String));
            _param.Add(new SPParam("@lengthOfStay", _prmResultMovable.LengthOfStay, DbType.String));
            _param.Add(new SPParam("@modifiedBy", _prmResultMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultMovable.ModifiedDate, DbType.DateTime));
            //_param.Add(new SPParam("@others", _prmResultMovable.Others, DbType.String));
            _param.Add(new SPParam("@personalCharacter", _prmResultMovable.PersonalCharacter, DbType.String));            
            _param.Add(new SPParam("@remark", _prmResultMovable.Remark, DbType.String));
            _param.Add(new SPParam("@residenceConditions", _prmResultMovable.ResidenceConditions, DbType.String));
            _param.Add(new SPParam("@rowStatus", _prmResultMovable.RowStatus, DbType.Int32));            
            _param.Add(new SPParam("@workOrderMovableID", _prmResultMovable.WorkOrderMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public Boolean InsertResultNotMovableWCF(TrResultNotMovable _prmResultNotMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            //_param.Add(new SPParam("@businessLine", _prmResultNotMovable.BusinessLine, DbType.String));
            _param.Add(new SPParam("@companyCondition", _prmResultNotMovable.CompanyCondition, DbType.String));
            _param.Add(new SPParam("@companyPeriod", _prmResultNotMovable.CompanyPeriod, DbType.String));
            //_param.Add(new SPParam("@others", _prmResultNotMovable.Others, DbType.String));
            _param.Add(new SPParam("@position", _prmResultNotMovable.Position, DbType.String));
            _param.Add(new SPParam("@workingPeriod", _prmResultNotMovable.WorkingPeriod, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@createdBy", _prmResultNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultNotMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultNotMovable.ModifiedDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@workOrderNotMovableID", _prmResultNotMovable.WorkOrderNotMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public Boolean InsertResultPhotoAddMovWCF(TrResultPhotoAdditionalMovable _prmResultPhotoAddMov, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultPhotoAddMov.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultPhotoAddMov.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultPhotoAddMov.ModifiedDate, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultPhotoAdditionalMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultPhotoAdditionalMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public Boolean InsertResultPhotoAddNotMovWCF(TrResultPhotoAdditionalNotMovable _prmResultPhotoAddMov, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultPhotoAddMov.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultPhotoAddMov.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultPhotoAddMov.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultPhotoAddMov.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultPhotoAddMov.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultPhotoAddMov.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultPhotoAddMov.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultPhotoAddMov.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultPhotoAddMov.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultPhotoAddMov.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultPhotoAddMov.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultPhotoAddMov.ModifiedDate, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultPhotoAdditionalNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultPhotoAdditionalNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public Boolean InsertResultReqDocMovableWCF(TrResultReqDocMovable _prmResultReqDocMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultMovableID", _prmResultReqDocMovable.ResultMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocMovableID", _prmResultReqDocMovable.ReqDocMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultReqDocMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultReqDocMovable.ModifiedDate, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultReqDocMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultReqDocMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public Boolean InsertResultReqDocNotMovableWCF(TrResultReqDocNotMovable _prmResultReqDocNotMovable, ref Int64 _prmOutID)
        {
            Boolean _result = false;

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultReqDocNotMovable.ResultNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@reqDocNotMovableID", _prmResultReqDocNotMovable.ReqDocNotMovableID, DbType.Int64));
            _param.Add(new SPParam("@photoName", _prmResultReqDocNotMovable.PhotoName, DbType.String));
            _param.Add(new SPParam("@imageGuid", _prmResultReqDocNotMovable.ImageGuid, DbType.String));
            _param.Add(new SPParam("@remark", _prmResultReqDocNotMovable.Remark, DbType.String));
            _param.Add(new SPParam("@longitude", _prmResultReqDocNotMovable.Longitude, DbType.String));
            _param.Add(new SPParam("@latitude", _prmResultReqDocNotMovable.Latitude, DbType.String));
            _param.Add(new SPParam("@uploadDate", _prmResultReqDocNotMovable.UploadDate, DbType.DateTime));
            _param.Add(new SPParam("@rowStatus", _prmResultReqDocNotMovable.RowStatus, DbType.Int32));
            _param.Add(new SPParam("@createdBy", _prmResultReqDocNotMovable.CreatedBy, DbType.String));
            _param.Add(new SPParam("@createdDate", _prmResultReqDocNotMovable.CreatedDate, DbType.DateTime));
            _param.Add(new SPParam("@modifiedBy", _prmResultReqDocNotMovable.ModifiedBy, DbType.String));
            _param.Add(new SPParam("@modifiedDate", _prmResultReqDocNotMovable.ModifiedDate, DbType.DateTime));

            List<SPParamOut> _paramOut = new List<SPParamOut>();
            _paramOut.Add(new SPParamOut("@resultReqDocNotMovableID", null, DbType.Int64));

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPNonQuery, "InsertTrResultReqDocNotMovable", _param, ref _paramOut, ref data);
            if (_success)
            {
                _prmOutID = Convert.ToInt64(_paramOut[0].Value);
                _result = true;
            }

            return _result;
        }

        public TrResultNotMovable GetSingleTrResultNotMovable(Int64 _prmWorkOrderNotMovableID)
        {
            TrResultNotMovable _result = new TrResultNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderNotMovableID", _prmWorkOrderNotMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultNotMovableByWorkOrderNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultNotMovable _trResultNotMovable = new TrResultNotMovable();
                    _trResultNotMovable.ResultNotMovableID = (Int64)dr["ResultNotMovableID"];
                    _trResultNotMovable.WorkOrderNotMovableID = (Int64)dr["WorkOrderNotMovableID"];
                    _trResultNotMovable.CompanyPeriod = (dr["CompanyPeriod"] == DBNull.Value) ? String.Empty : (String)dr["CompanyPeriod"];
                    //_trResultNotMovable.BusinessLine = (String)dr["BusinessLine"];
                    _trResultNotMovable.CompanyCondition = (String)dr["CompanyCondition"];
                    //_trResultNotMovable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _trResultNotMovable.Position = (dr["Position"] == DBNull.Value) ? String.Empty : (String)dr["Position"];
                    _trResultNotMovable.WorkingPeriod = (dr["WorkingPeriod"] == DBNull.Value) ? String.Empty : (String)dr["WorkingPeriod"];
                    _trResultNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultNotMovable.RowStatus = (int)dr["RowStatus"];
                    _trResultNotMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultNotMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultNotMovable.ModifiedBy = (dr["ModifiedBy"].ToString() == "") ? "" : (String)dr["ModifiedBy"];
                    _trResultNotMovable.ModifiedDate = (dr["ModifiedDate"].ToString() == "") ? new DateTime() : (DateTime)dr["ModifiedDate"];
                    _trResultNotMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result = _trResultNotMovable;
                }
                dr.Close();
            }

            return _result;
        }

        public List<TrResultReqDocNotMovable> GetListTrResultReqDocNotMovable(Int64 _prmResultNotMovableID)
        {
            List<TrResultReqDocNotMovable> _result = new List<TrResultReqDocNotMovable>();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@resultNotMovableID", _prmResultNotMovableID, DbType.Int64));

            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultReqDocNotMovableByResultNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                while (dr.Read())
                {
                    TrResultReqDocNotMovable _trResultReqDocNotMovable = new TrResultReqDocNotMovable();
                    _trResultReqDocNotMovable.ResultReqDocNotMovableID = (Int64)dr["ResultReqDocNotMovableID"];
                    _trResultReqDocNotMovable.ResultNotMovableID = (Int64)dr["ResultNotMovableID"];
                    _trResultReqDocNotMovable.ReqDocNotMovableID = (Int64)dr["ReqDocNotMovableID"];
                    _trResultReqDocNotMovable.ImageGuid = (dr["ImageGuid"] == DBNull.Value) ? String.Empty : (String)dr["ImageGuid"];
                    _trResultReqDocNotMovable.PhotoName = (dr["PhotoName"] == DBNull.Value) ? String.Empty : (String)dr["PhotoName"];
                    _trResultReqDocNotMovable.Longitude = (String)dr["Longitude"];
                    _trResultReqDocNotMovable.Latitude = (String)dr["Latitude"];
                    _trResultReqDocNotMovable.UploadDate = (DateTime)dr["UploadDate"];
                    _trResultReqDocNotMovable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _trResultReqDocNotMovable.RowStatus = (Int32)dr["RowStatus"];
                    _trResultReqDocNotMovable.CreatedBy = (String)dr["CreatedBy"];
                    _trResultReqDocNotMovable.CreatedDate = (DateTime)dr["CreatedDate"];
                    _trResultReqDocNotMovable.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? String.Empty : (String)dr["ModifiedBy"];
                    _trResultReqDocNotMovable.ModifiedDate = (dr["ModifiedDate"] == DBNull.Value) ? this._defaultDate : (DateTime)dr["ModifiedDate"];
                    _trResultReqDocNotMovable.Timestamp = (byte[])dr["Timestamp"];

                    _result.Add(_trResultReqDocNotMovable);
                }
                dr.Close();
            }
            return _result;
        }
        #endregion

        #region WorkOrderResult

        public TrResultMovable GetResultMovableForWorkOrder(Int64 _prmWorkOrderMoveId)
        {
            TrResultMovable _result = new TrResultMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderMovableID", _prmWorkOrderMoveId, DbType.Int64));
            //_param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultMovableByWorkOrderMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultMovable _ResultMoveable = new TrResultMovable();

                    _ResultMoveable.BuildingArea = (dr["BuildingArea"] == DBNull.Value) ? String.Empty : (String)dr["BuildingArea"];
                    _ResultMoveable.ResultMovableID = (long)dr["ResultMovableID"];
                    _ResultMoveable.HouseStatus = (dr["HouseStatus"] == DBNull.Value) ? String.Empty : (String)dr["HouseStatus"];
                    _ResultMoveable.LengthOfStay = (dr["LengthOfStay"] == DBNull.Value) ? String.Empty : (String)dr["LengthOfStay"];
                    _ResultMoveable.PersonalCharacter = (dr["PersonalCharacter"] == DBNull.Value) ? String.Empty : (String)dr["PersonalCharacter"];                    
                    _ResultMoveable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _ResultMoveable.ResidenceConditions = (dr["ResidenceConditions"] == DBNull.Value) ? String.Empty : (String)dr["ResidenceConditions"];
                    _ResultMoveable.EnvironmentalConditions = (dr["EnvironmentalConditions"] == DBNull.Value) ? String.Empty : (String)dr["EnvironmentalConditions"];                    
                    //_ResultMoveable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                
                    _result = _ResultMoveable;
                }
                dr.Close();
            }

            return _result;
        }
        public TrResultNotMovable GetResultNotMovableForWorkOrder(Int64 _prmWorkOrderNotMoveId)
        {
            TrResultNotMovable _result = new TrResultNotMovable();

            object data = null;
            List<SPParam> _param = new List<SPParam>();
            _param.Add(new SPParam("@workOrderNotMovableID", _prmWorkOrderNotMoveId, DbType.Int64));
            //_param.Add(new SPParam("@CustomerID", _prmCustomerID, DbType.Int64));
            List<SPParamOut> _paramOut = new List<SPParamOut>();

            bool _success = new StoreProcedureClass().CallStoreProcedure(StoreProcType.SPReader, "sp_GetTrResultNotMovableByWorkOrderNotMovableID", _param, ref _paramOut, ref data);
            if (_success)
            {
                IDataReader dr = (IDataReader)data;
                if (dr.Read())
                {
                    TrResultNotMovable _ResultMoveable = new TrResultNotMovable();

                    //_ResultMoveable.BusinessLine = (String)dr["BusinessLine"];
                    _ResultMoveable.CompanyCondition = (String)dr["CompanyCondition"];
                    _ResultMoveable.CompanyPeriod = (dr["CompanyPeriod"] == DBNull.Value) ? String.Empty : (String)dr["CompanyPeriod"];
                    //_ResultMoveable.Others = (dr["Others"] == DBNull.Value) ? String.Empty : (String)dr["Others"];
                    _ResultMoveable.Position = (dr["Position"] == DBNull.Value) ? String.Empty : (String)dr["Position"];
                    _ResultMoveable.WorkingPeriod = (dr["WorkingPeriod"] == DBNull.Value) ? String.Empty : (String)dr["WorkingPeriod"];
                    _ResultMoveable.Remark = (dr["Remark"] == DBNull.Value) ? String.Empty : (String)dr["Remark"];
                    _ResultMoveable.ResultNotMovableID = (long)dr["ResultNotMovableID"];

                    _result = _ResultMoveable;
                }
                dr.Close();
            }

            return _result;
        }

        #endregion


    }
}
