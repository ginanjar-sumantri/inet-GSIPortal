using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class DocumentTypeBase : Base
    {
        protected string _pageTitleListLiteral = "List DocumentType";
        protected string _pageTitleViewLiteral = "Edit DocumentType";
        protected string _pageTitleAddLiteral = "Add DocumentType";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listDocumentTypePage = "~/DocumentType/ListDocumentType.aspx";
        protected string _viewDocumentTypePage = "~/DocumentType/ViewDocumentType.aspx";
        protected string _addDocumentTypePage = "~/DocumentType/AddDocumentType.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";


        // --Query String--
        protected string _type = "Type";
        protected string _documentTypeID = "DocumentTypeID";
        public DocumentTypeBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}