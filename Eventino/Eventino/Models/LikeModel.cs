using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class LikeModel
    {
        public int CountLikes(int evtid)
        {
            List<LIKE> v = new List<LIKE>();
            using (EventEntities EE = new EventEntities())
            {
                foreach (LIKE like in EE.LIKEs.ToList())
                {
                    if (like.EVENTID == evtid)
                        v.Add(like);
                }
                return v.Count;
            }
        }
        public bool Exist(int eventid, int loginid)
        {
            using (EventEntities EE = new EventEntities())
            {
                foreach (LIKE like in EE.LIKEs.ToList())
                {
                    if (like.EVENTID == eventid && like.LOGINID == loginid)
                        return true;
                }
            }
            return false;
        }
        public string Add(LIKE lk)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.LIKEs.Add(lk);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace +
                    "<br />" + ex.Message;
            }
        }
    }
}