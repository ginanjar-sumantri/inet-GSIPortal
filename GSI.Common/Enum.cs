using System;

namespace GSI.Common.Enum
{
    public enum YesNo : byte
    {
        Yes = 1,
        No = 0
    }

    public enum DateForm : byte
    {
        SQL,
        English,
        Indonesian
    }

    public enum StoreProcType : byte
    {
        SPReader,
        SPScalar,
        SPDataSet,
        SPNonQuery
    }

    public enum GlobalStatus : byte
    {
        OnHold,
        InProcess,
        Surveying,
        Done,
        Draft,
        Final,
        All,
        Cancel,
        Assigned,
        SentToCS
    }

    public enum GSIEksternalStatus : byte
    {
        Initialized,
        Submitted,
        OnProgress,
        Completed,
        Cancelled,
        Correction,
        Complaint
    }

    public enum GSIInternalStatus : byte
    {
        NA,
        ReceivedBySystem,
        WaitingForAssigment,
        WaitingForDownload,
        WaitingForSurvey,
        OnTheWay,
        OnTheSpot,
        SurveyResultReceived,
        Published,
        Cancelled,
        Correction,
        Complaint
    }

    public enum WOTypeEnum : long
    {
        Normal,
        Correction,
        Complaint
    }

    public enum CancelStatusEnum : long
    {
        Normal,
        WaitingForCancel,
        Cancelled
    }

    public enum TypeProcess : byte
    {
        PreProcess,
        SurveyProcess,
        AfterProcess
    }

    public enum OrderVersion : byte
    {
        Draft,
        Final
    }

    public enum SurveyPointType : byte
    {
        Movable,
        NotMovable,
        Originator
    }

    public enum OrderType : byte
    {
        Personal,
        Corporate
    }

    public enum FormToUpdate : byte
    {
        WorkOrder,
        SurveyPoint
    }

    public enum FormatTextBox : byte
    {
        AllowDot,
        AllowAlphabet
    }

    public enum DestinationEmail : byte
    {
        Customer,
        Dispatcher,
        Surveyor
    }

    public enum SurveyPointMapper : long
    {
        Guarantor,
        Originator,
        Office,
        House
    }

    public enum TimeFrame : byte
    {
        LessThanOneHour,
        OneToTwoHour,
        MoreThanTwoHour
    }
}