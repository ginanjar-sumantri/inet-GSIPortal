using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;

namespace GSIWebsiteCore
{
    public partial class CaptchaImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Random ran = new Random();
            //int no = ran.Next(0, 99999);
            //Session["Captcha"] = no.ToString("00000");

            string[] strArray = new string[36];
            strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random autoRand = new Random();
            string strCaptcha = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int j = Convert.ToInt32(autoRand.Next(0, 62));
                strCaptcha += strArray[j].ToString();
            }
            this.Session["Captcha"] = strCaptcha;

            // Create a CAPTCHA image using the text stored in the Session object.
            GenerateImages ci = new GenerateImages(this.Session["Captcha"].ToString(), 100, 40, "Tahoma", 32);

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
        }
    }
}