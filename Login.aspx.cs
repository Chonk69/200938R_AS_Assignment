using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace AS_Assignment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void LoginMe(object sender, EventArgs e)
        {
            if (tb_userid.Text.Trim().Equals("u") && tb_pwd.Text.Trim().Equals("p"))
            {
                Session["LoggedIn"] = tb_userid.Text.Trim();

                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;

                Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                Response.Redirect("HomePage.aspx", false);
            }
            else
            {
                lblMessage.Text = "Wrong username or password";
            }
        }
        public class MyObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }

        public bool ValidateCaptcha()
        {
            bool result = true;
            string captchaResponse = Request.Form["g-recaptcha-response"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create
            ("https://google.com/recaptcha/api/siteverify?secret=6Ldw3WQeAAAAABhgjHl-mLa5HwzTWFHeiAitVpds &response=" + captchaResponse);
            try
            {
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        MyObject jsonObject = js.Deserialize<MyObject>(jsonResponse);
                        result = Convert.ToBoolean(jsonObject.success);
                    }
                }
                return result;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }
    }
}

