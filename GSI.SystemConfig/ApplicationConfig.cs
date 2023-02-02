using System;

namespace GSI.SystemConfig
{
    public static class ApplicationConfig
    {
        private static String _dateForm = Properties.settings.Default.DateForm;
        private static String _membershipAppName = Properties.settings.Default.MembershipAppName;

        public static String DateForm
        {
            get { return _dateForm; }
        }
        public static String MembershipAppName
        {
            get { return _membershipAppName; }
        }
    }
}
