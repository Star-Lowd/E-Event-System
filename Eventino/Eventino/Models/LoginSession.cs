using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Eventino.Models
{
    public class LoginSession
    {
        public LOGIN GetSession()
        {
            LOGIN login = (LOGIN)System.Web.HttpContext.Current.Session["LoggedUser"];
            return login;
        }

        public ACCOUNT GetAccount()
        {
            return (new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID);
        }

        
        public string GetImage()
        {
            try
            {
                //    string imagePath = "";
                if (this.GetAccount() == null)
                {
                    return "~/DataFiles/Images/unisex.jpg";
                }
                else if (this.GetAccount().IMAGE == "" || string.IsNullOrWhiteSpace(this.GetAccount().IMAGE))
                {
                    if (this.GetAccount().GENDER == "M" || this.GetAccount().GENDER == "m")
                    {
                        return "~/DataFiles/Images/male.png";
                    }
                    else
                    {
                        return "~/DataFiles/Images/female.png";
                    }

                }

                else
                {
                    return (new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID).IMAGE;
                }
            }
            catch
            {
                return "~/DataFiles/Images/unisex.jpg";
            }
          //  return imagePath;
        }

        public string Getusername()
        {
            if (this.GetAccount() == null)
                return this.GetSession().USERNAME;
            else
                return this.GetAccount().FIRSTNAME + " " + this.GetAccount().LASTNAME;
        }
        public string GetCoverImage()
        {
            if (this.GetAccount() == null|| this.GetAccount().CoverImage == "" || string.IsNullOrWhiteSpace(this.GetAccount().CoverImage))
            {
                return "";
            }
            return (new AccountModel()).GetAccountByLogin((new LoginSession().GetSession()).LOGINID).CoverImage;
        }
        public bool LoggedOutUsers()
        {
            try
            {
                System.Web.HttpContext.Current.Session["LoggedUser"] = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void setLoggedUser(LOGIN Login)
        {
            System.Web.HttpContext.Current.Session["LoggedUser"] = Login;
        }
        public bool IsLoggedIn()
        {
            return System.Web.HttpContext.Current.Session["LoggedUser"] == null;
        }
    }
}