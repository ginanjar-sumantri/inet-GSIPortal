using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using GSI.Common.Enum;
using System.Data.SqlClient;

namespace GSI.Common
{
    public class StoreProcedureClass : Base
    {
        public bool CallStoreProcedure(StoreProcType _prmType, String _prmSPName, List<SPParam> _prmParam, ref List<SPParamOut> _prmParamOut, ref object _prmReturnValue)
        {
            bool _result = false;

            switch (_prmType)
            {
                case GSI.Common.Enum.StoreProcType.SPReader:
                    DbCommand _cmd = this.db.GetStoredProcCommand(_prmSPName);
                    foreach (var _prmParamUnit in _prmParam)
                    {
                        this.db.AddInParameter(_cmd, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
                    }
                    foreach (var _prmParamUnitOut in _prmParamOut)
                    {
                        int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
                        this.db.AddOutParameter(_cmd, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
                    }

                    IDataReader reader = this.db.ExecuteReader(_cmd);
                    _prmReturnValue = reader;

                    foreach (var _outputParam in _prmParamOut)
                    {
                        _outputParam.Value = db.GetParameterValue(_cmd, _outputParam.Key);
                    }

                    _result = true;
                    break;
                case GSI.Common.Enum.StoreProcType.SPScalar:
                    DbCommand _cmd2 = this.db.GetStoredProcCommand(_prmSPName);
                    foreach (var _prmParamUnit in _prmParam)
                    {
                        this.db.AddInParameter(_cmd2, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
                    }
                    foreach (var _prmParamUnitOut in _prmParamOut)
                    {
                        int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
                        this.db.AddOutParameter(_cmd2, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
                    }

                    int scalar = (int)this.db.ExecuteScalar(_cmd2);
                    _prmReturnValue = scalar;

                    foreach (var _outputParam in _prmParamOut)
                    {
                        _outputParam.Value = db.GetParameterValue(_cmd2, _outputParam.Key);
                    }

                    _result = true;
                    break;
                case GSI.Common.Enum.StoreProcType.SPDataSet:
                    DbCommand _cmd3 = this.db.GetStoredProcCommand(_prmSPName);
                    foreach (var _prmParamUnit in _prmParam)
                    {
                        this.db.AddInParameter(_cmd3, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
                    }
                    foreach (var _prmParamUnitOut in _prmParamOut)
                    {
                        int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
                        this.db.AddOutParameter(_cmd3, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
                    }

                    DataSet dataSet = this.db.ExecuteDataSet(_cmd3);
                    _prmReturnValue = dataSet;

                    foreach (var _outputParam in _prmParamOut)
                    {
                        _outputParam.Value = db.GetParameterValue(_cmd3, _outputParam.Key);
                    }

                    _result = true;
                    break;
                case GSI.Common.Enum.StoreProcType.SPNonQuery:
                    DbCommand _cmd4 = this.db.GetStoredProcCommand(_prmSPName);
                    foreach (var _prmParamUnit in _prmParam)
                    {
                        this.db.AddInParameter(_cmd4, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
                    }
                    foreach (var _prmParamUnitOut in _prmParamOut)
                    {
                        int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
                        this.db.AddOutParameter(_cmd4, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
                    }

                    int affectedRow = this.db.ExecuteNonQuery(_cmd4);
                    _prmReturnValue = affectedRow;

                    foreach (var _outputParam in _prmParamOut)
                    {
                        _outputParam.Value = db.GetParameterValue(_cmd4, _outputParam.Key);
                    }

                    _result = true;
                    break;
                default:
                    _prmReturnValue = null;

                    break;
            }

            return _result;
        }

        //public bool CallStoreProcedureDelete(StoreProcType _prmType, String _prmSPName, List<SPParamDelete> _prmParam, ref List<SPParamOut> _prmParamOut, ref object _prmReturnValue)
        //{
        //    bool _result = false;

        //    switch (_prmType)
        //    {
        //        case GSI.Common.Enum.StoreProcType.SPReader:
        //            DbCommand _cmd = this.db.GetStoredProcCommand(_prmSPName);
        //            foreach (var _prmParamUnit in _prmParam)
        //            {
        //                this.db.AddInParameter(_cmd, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
        //            }
        //            foreach (var _prmParamUnitOut in _prmParamOut)
        //            {
        //                int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
        //                this.db.AddOutParameter(_cmd, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
        //            }

        //            IDataReader reader = this.db.ExecuteReader(_cmd);
        //            _prmReturnValue = reader;

        //            foreach (var _outputParam in _prmParamOut)
        //            {
        //                _outputParam.Value = db.GetParameterValue(_cmd, _outputParam.Key);
        //            }

        //            _result = true;
        //            break;
        //        case GSI.Common.Enum.StoreProcType.SPScalar:
        //            DbCommand _cmd2 = this.db.GetStoredProcCommand(_prmSPName);
        //            foreach (var _prmParamUnit in _prmParam)
        //            {
        //                this.db.AddInParameter(_cmd2, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
        //            }
        //            foreach (var _prmParamUnitOut in _prmParamOut)
        //            {
        //                int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
        //                this.db.AddOutParameter(_cmd2, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
        //            }

        //            int scalar = (int)this.db.ExecuteScalar(_cmd2);
        //            _prmReturnValue = scalar;

        //            foreach (var _outputParam in _prmParamOut)
        //            {
        //                _outputParam.Value = db.GetParameterValue(_cmd2, _outputParam.Key);
        //            }

        //            _result = true;
        //            break;
        //        case GSI.Common.Enum.StoreProcType.SPDataSet:
        //            DbCommand _cmd3 = this.db.GetStoredProcCommand(_prmSPName);
        //            foreach (var _prmParamUnit in _prmParam)
        //            {
        //                this.db.AddInParameter(_cmd3, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
        //            }
        //            foreach (var _prmParamUnitOut in _prmParamOut)
        //            {
        //                int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
        //                this.db.AddOutParameter(_cmd3, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
        //            }

        //            DataSet dataSet = this.db.ExecuteDataSet(_cmd3);
        //            _prmReturnValue = dataSet;

        //            foreach (var _outputParam in _prmParamOut)
        //            {
        //                _outputParam.Value = db.GetParameterValue(_cmd3, _outputParam.Key);
        //            }

        //            _result = true;
        //            break;
        //        case GSI.Common.Enum.StoreProcType.SPNonQuery:
        //            DbCommand _cmd4 = this.db.GetStoredProcCommand(_prmSPName);
        //            foreach (var _prmParamUnit in _prmParam)
        //            {
        //                this.db.AddInParameter(_cmd4, _prmParamUnit.Key, _prmParamUnit.DataType, _prmParamUnit.Value);
        //            }
        //            foreach (var _prmParamUnitOut in _prmParamOut)
        //            {
        //                int size = DataTypeSizeMapper.GetSize(_prmParamUnitOut.DataType);
        //                this.db.AddOutParameter(_cmd4, _prmParamUnitOut.Key, _prmParamUnitOut.DataType, size);
        //            }

        //            int affectedRow = this.db.ExecuteNonQuery(_cmd4);
        //            _prmReturnValue = affectedRow;

        //            foreach (var _outputParam in _prmParamOut)
        //            {
        //                _outputParam.Value = db.GetParameterValue(_cmd4, _outputParam.Key);
        //            }

        //            _result = true;
        //            break;
        //        default:
        //            _prmReturnValue = null;

        //            break;
        //    }

        //    return _result;
        //}
    }

    public static class DataTypeSizeMapper
    {
        public static int GetSize(DbType _prmValue)
        {
            int _result = 0;
            switch (_prmValue)
            {
                case DbType.Boolean: _result = 1; break;
                case DbType.Byte: _result = 1; break;
                case DbType.Int16: _result = 2; break;
                case DbType.Int32: _result = 4; break;
                case DbType.Int64: _result = 8; break;
                case DbType.Decimal: _result = 19; break;
                case DbType.Double: _result = 8; break;
                case DbType.Single: _result = 4; break;
                case DbType.DateTime: _result = 10; break;
                case DbType.Guid: _result = 16; break;
                case DbType.String: _result = 8000; break;
                case DbType.Binary: _result = 8000; break;
                default: _result = 8000; break;
            }
            return _result;
        }
    }
}
