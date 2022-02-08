using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;

namespace AS_Assignment
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private int checkPassword(string password)
        {
            int score = 0;

            if (password.Length < 12)
            {
                return 1;
            }

            else
            {
                score = 1;
            }

            if (Regex.IsMatch(password, "[a-z]"))
            {
                score++;
            }

            if (Regex.IsMatch(password, "[A-Z]"))
            {
                score++;
            }

            if (Regex.IsMatch(password, "[0-9]"))
            {
                score++;
            }

            if (Regex.IsMatch(password, "[$&+,:;=?@#|'<>.^*()%!-]"))
            {
                score++;
            }

            return score;
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            if (ValidateCaptcha())
            {
                var fname = HttpUtility.HtmlEncode(FName.Text);
                var lname = HttpUtility.HtmlEncode(LName.Text);
                var email = HttpUtility.HtmlEncode(Email.Text);
                var creditname = HttpUtility.HtmlEncode(CreditName.Text);
                var creditno = HttpUtility.HtmlEncode(CreditNo.Text);
                var creditdate = HttpUtility.HtmlEncode(CreditDate.Text);
                var cvv = HttpUtility.HtmlEncode(CVV.Text);
                var pass = HttpUtility.HtmlEncode(tb_password.Text);
                var dob = HttpUtility.HtmlEncode(DoB.Text);
                var error = "";
                if (fname == "")
                {
                    error = error + " Enter First Name </br>";
                }
                if (lname == "")
                {
                    error = error + "  Enter Last Name  </br>";
                }
                if (email == "")
                {
                    error = error + " Enter Email  </br>";
                }
                else
                {
                    var validEmail = IsValidEmail(email);
                    if (!validEmail)
                    {
                        error = error + " Enter Email properly </br>";
                    }
                }
                if (creditname == "")
                {
                    error = error + " Enter credit name  </br>";
                }
                if (!Regex.IsMatch(creditno, @"\d{16}"))
                {
                    error = error + " Enter credit number  </br>";
                }
                if (creditdate == "")
                {
                    error = error + " Enter credit date  </br>";
                }
                if (!Regex.IsMatch(cvv, @"\d{3}"))
                {
                    error = error + " Enter cvv  </br>";
                }
                if (pass == "")
                {
                    error = error + " Enter password  </br>";
                }
                if (dob == "")
                {
                    error = error + " Enter date of birth  </br>";
                }
                if (error != "")
                {
                    errorMsg.Text = error;
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    Debug.WriteLine(error);
                    return;
                }

                int scores = checkPassword(tb_password.Text);
                string status = "";
                switch (scores)
                {
                    case 1:
                        status = "Very Weak";
                        break;
                    case 2:
                        status = "Weak";
                        break;
                    case 3:
                        status = "Medium";
                        break;
                    case 4:
                        status = "Strong";
                        break;
                    case 5:
                        status = "Excellent!";
                        break;
                    default:
                        break;
                }

                lbl_pwdchecker.Text = "Status : " + status;
                if (scores < 4)
                {
                    lbl_pwdchecker.ForeColor = Color.Red;
                    lbl_pwdchecker.Visible = true;
                    
                    return;
                }
                lbl_pwdchecker.ForeColor = Color.Green;

                //int score = checkPassword(tb_password.Text);
                //if (score < 4)
                //{
                //    errorMsg.Text = "Password too weak";
                //    errorMsg.ForeColor = Color.Red;
                //    errorMsg.Visible = true;
                //    return;
                //}
                Response.Redirect("Login.aspx");
            }
            
        }

        public class MyObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
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