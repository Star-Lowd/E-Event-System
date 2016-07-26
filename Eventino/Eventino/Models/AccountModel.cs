using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class AccountModel
    {
        public string update(int accountid, ACCOUNT newAcc)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    ACCOUNT acc = EE.ACCOUNTs.Find(accountid);
                    acc.COUNTRYID = newAcc.COUNTRYID;
                    acc.FIRSTNAME = newAcc.FIRSTNAME;
                    acc.LASTNAME = newAcc.LASTNAME;
                    acc.GENDER = newAcc.GENDER;
                    acc.DOB = newAcc.DOB;
                    acc.PHONENUMBER = newAcc.PHONENUMBER;
                    acc.MARITALSTATUS = newAcc.MARITALSTATUS;
                    acc.IMAGE = newAcc.IMAGE;
                    acc.CoverImage = newAcc.CoverImage;
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }
        public string delete(ACCOUNT acc)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.ACCOUNTs.Remove(acc);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public string delete(int accid)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    ACCOUNT account = EE.ACCOUNTs.Find(accid);
                    if (account == null)
                        return "login not found ";
                    else
                        return this.delete(account);
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public ACCOUNT getAccount(int accid)
        {
            using (EventEntities EE = new EventEntities())
            {
               return  EE.ACCOUNTs.Find(accid);
            }
        }


        public ACCOUNT GetAccountByLogin(int Loginid)
        {
            using (EventEntities EE = new EventEntities())
            {
                foreach (ACCOUNT a in EE.ACCOUNTs.ToList())
                {
                    if (a.LOGINID == Loginid)
                        return a;
                }
            }
            return null;
        }

        public string Add(ACCOUNT account)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.ACCOUNTs.Add(account);
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