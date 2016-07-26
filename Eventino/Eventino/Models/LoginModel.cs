using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Eventino.Models
{
    public class LoginModel
    {
        public string update(int logid, LOGIN newLogin)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    LOGIN login = EE.LOGINs.Find(logid);
                    login.EMAIL = newLogin.EMAIL;
                    login.USERNAME = newLogin.USERNAME;
                    login.PASSWORDHASH = newLogin.PASSWORDHASH;

                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }
        public string delete(LOGIN login)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.LOGINs.Remove(login);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public string delete(int loginid)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    LOGIN login = EE.LOGINs.Find(loginid);
                    if (login == null)
                        return "login not found ";
                    else
                       return  this.delete(login);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public string CreateMD5(string input)
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


        public LOGIN AuthenticateUser(string username, string password)
        {
            using (EventEntities EE = new EventEntities())
            {
                foreach(LOGIN l in EE.LOGINs.ToList())
                {
                    if ((l.USERNAME == username || l.EMAIL == username) && l.PASSWORDHASH == this.CreateMD5(password))
                    {
                        return l;
                    }
                }
                return null;
            }
        }
        public LOGIN getLogin(int loginid)
        {
            using (EventEntities EE = new EventEntities())
            {
               return  EE.LOGINs.Find(loginid);
            }
        }

        public string Add(LOGIN login)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.LOGINs.Add(login);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch(Exception ex )
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }
    }
}