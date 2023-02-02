using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class UserHistoryBase : Base
    {
        protected NameValueCollectionExtractor _nvcExtractor;

        protected string _pageTitleListLiteral = "List UserHistory";

        // --Link Page--
        protected string _listUserHistoryPage = "~/UserHistory/ListUserHistory.aspx";

        public UserHistoryBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}