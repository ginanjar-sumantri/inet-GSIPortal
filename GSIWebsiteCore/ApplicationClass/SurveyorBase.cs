using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GSI.Common;

namespace GSIWebsiteCore
{
    public class SurveyorBase : Base
    {
        protected string _pageTitleListLiteral = "List Surveyor";
        protected string _pageTitleViewLiteral = "Edit Surveyor";
        protected string _pageTitleAddLiteral = "Add Surveyor";
        protected NameValueCollectionExtractor _nvcExtractor;

        // --Link Page--
        protected string _listSurveyorPage = "~/Surveyor/Surveyor.aspx";
        protected string _addSurveyorPage = "~/Surveyor/AddSurveyor.aspx";

        // --ToolTip button--
       
        protected string _toolTipSave = "Save";
        protected string _toolTipCancel = "Cancel";
        protected string _toolTipDrop = "Drop";
        protected string _toolTipReset = "Reset";

        protected string _pageTitleLiteral = "Surveyor";

       

        // --Link Page--
        protected string _viewSurveyorPage = "~/Surveyor/ViewSurveyor.aspx";

        // --ToolTip button--
        protected string _toolTipView = "View";

        // --Query String--
        protected string _type = "Type";
        protected string _surveyorID = "SurveyorID";


        public SurveyorBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}