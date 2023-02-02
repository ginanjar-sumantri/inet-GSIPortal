using System;
using GSI.Common;

/// <summary>
/// Summary description for OrderBase
/// </summary>
namespace GSIWebsiteAppBase
{
    public class ProfileBase : Base
    {
        protected string _pageTitleLiteral = "Profile";
  
        protected string _listOrderPage = "ListProfile.aspx";

        protected NameValueCollectionExtractor _nvcExtractor;
        protected String _queryString;
        protected String[] _orderType;

        public ProfileBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
