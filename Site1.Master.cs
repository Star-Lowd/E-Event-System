using Eventino.EF;
using Eventino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventino
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.MaintainScrollPositionOnPostBack = true;
            if (!(new Eventino.Models.LoginSession().IsLoggedIn()))
            {
                loginOp.Visible = false;
                LoginText.Visible = false;
                if ((new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID) != null)
                {
                    profileImg.Src = (new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID).IMAGE;
                    if ((new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID).IMAGE == "")
                    {

                    }
                }
            }
            else
            {
                loggedUser.Visible = false;
            }
            
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string usern = username.Text;
            string password = pwd.Text;
            LOGIN login = new LoginModel().AuthenticateUser(usern, password);
            string message = "";
            if (login == null)
                message = "Username or pasword is incorrect";
            else
            { 
                message = "User loggedin";
                new LoginSession().setLoggedUser(login);
                if ((new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID) == null)
                {
                    Response.Redirect("~/Pages/Account/CompleteRegistration");
                }
                else
                    Response.Redirect("~/pages/Account/Profile");
            }

            

        }

        protected void logoutControl_Click(object sender, EventArgs e)
        {
            if ((new LoginSession()).LoggedOutUsers())
            {
                Response.Redirect("~/index");
            }
        }
    }
}