using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GSIWebsiteApp.Testing
{
    public partial class TestCarousel : System.Web.UI.Page
    {
        private string[] imageURL = { "image1.jpg", "image2.jpg", "image3.jpg", "image4.jpg", "image5.jpg" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetAttribute();
                this.wrap.Attributes.Add("style", "visibility : hidden;");
            }
        }

        private void SetAttribute()
        {
            this.WrapVisibleHiddenField.Value = "0";
        }

        private void ShowData()
        {
            this.ListRepeater.DataSource = imageURL;
            this.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            if (this.WrapVisibleHiddenField.Value == "0")
            {
                this.ShowData();
                this.wrap.Attributes.Remove("style");
                this.WrapVisibleHiddenField.Value = "1";
            }
            else
            {
                this.wrap.Attributes.Add("style", "visibility : hidden;");
                this.WrapVisibleHiddenField.Value = "0";
            }
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            String _picURL = (String)e.Item.DataItem;
            Literal _image = (Literal)e.Item.FindControl("PicLiteral");
            _image.Text = "<img src='" + _picURL + "' class='picture'>";
        }
    }
}