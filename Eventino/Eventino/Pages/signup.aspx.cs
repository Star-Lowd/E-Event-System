using Eventino.EF;
using Eventino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventino.Pages
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private LOGIN createLogin()
        {
            string pas = txtpass.Text;
            LOGIN p = new LOGIN();
           
            p.USERNAME = txtuname.Text;
            p.PASSWORDHASH = CreateMD5(pas);
            p.EMAIL = txtemail.Text;
   

            return p;

        }


        protected void addLogin_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            LoginModel model = new LoginModel();

            LOGIN login = createLogin();
            model.Add(login) ;
            Response.Redirect("~/Index");
        }
    }
}