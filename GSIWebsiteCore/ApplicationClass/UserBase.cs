using GSI.Common;

namespace GSIWebsiteCore
{
    public class UserBase : Base
    {
        protected string _pageTitleListLiteral = "List User";
        protected string _pageTitleEditLiteral = "Edit User";
        protected string _pageTitleViewLiteral = "View User";
        protected string _pageTitleAddLiteral = "Add User";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listUserPage = "~/User/ListUser.aspx";
        protected string _editUserPage = "~/User/EditUser.aspx";
        protected string _viewUserPage = "~/User/ViewUser.aspx";
        protected string _addUserPage = "~/User/AddUser.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipEdit = "Edit";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";
        protected string _toolTipBack = "Back";
        protected string _toolTipActivate = "Activate";
        protected string _toolTipDisable = "Disable";

        // --Query String--
        protected string _userID = "UserID";
        protected string _userName = "UserName";

        public UserBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}