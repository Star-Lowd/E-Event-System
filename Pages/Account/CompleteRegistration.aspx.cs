using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eventino.EF;
using Eventino.Models;

namespace Eventino.Pages.Account
{
    public partial class CompleteRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        private string SaveImage(Control c)
        {

            FileUpload fuImage = (FileUpload)c;
            if (!System.IO.Directory.Exists(Server.MapPath("~/images/PasImage/")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/images/PasImage/"));
            }
            string time = DateTime.Now.ToString("ttssmmddyy");
            string name = "~/images/PasImage/" + time + fuImage.PostedFile.FileName;
            fuImage.SaveAs(Server.MapPath(name));
        
            return name;

        }
        private ACCOUNT Create()
        {
            ACCOUNT acct = new ACCOUNT();
            acct.LOGINID = (new LoginSession().GetSession()).LOGINID;
            acct.FIRSTNAME = Fname.Text;
            acct.LASTNAME = Lname.Text;
            acct.PHONENUMBER = Pnumber.Text;
            acct.DOB = DateTime.Parse(Dob.Text);
            acct.COUNTRYID = int.Parse(Country.SelectedValue);
            acct.MARITALSTATUS = MaritalStatus.SelectedValue;
            acct.GENDER = RadioF.Checked ? "F" : "M";
            acct.IMAGE = this.SaveImage(FileUpload1);
            return acct;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

          
                AccountModel model = new AccountModel();

                ACCOUNT acc = Create();
                System.Windows.Forms.MessageBox.Show(model.Add(acc));

                // ACCOUNT acct  = this.Create();
                //new AccountModel().Add(acct);
                
              //  Panel1.Controls.Add(new Literal { Text = "<div class='alert alert-success'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <strong>Info!</strong> Conguatulation you information have been updated</div>" });
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pages/account/profile");
        }
    }
}