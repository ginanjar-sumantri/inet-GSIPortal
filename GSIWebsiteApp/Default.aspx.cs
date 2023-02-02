using System;
using GSIWebsiteAppBase;

namespace GSIWebsiteApp
{
    public partial class _Default : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(this._baseURL + "\\Login.aspx");
        }
    }
}