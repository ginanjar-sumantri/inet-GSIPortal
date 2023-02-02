using System;
using GSI.Common;

/// <summary>
/// Summary description for DashboardBase
/// </summary>

namespace GSIWebsiteCore
{
    public class DashboardBase : Base
    {
        protected String _pageDashboardMonitor = "DashboardMonitor.aspx";
        protected String _pageDashboardRegion = "DashboardMonitorByRegion.aspx";
        protected String _pageDashboardSurveyor = "DashboardMonitorBySurveyor.aspx";

        protected String _codeKey = "TimeFrame";

        protected NameValueCollectionExtractor _nvcExtractor;

        public DashboardBase()
        {
        }
    }
}