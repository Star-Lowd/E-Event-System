using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class EventModel
    {
        public string Add(EVENT evt)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.EVENTs.Add(evt);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public EVENT Find(int evtid)
        {
            using (EventEntities EE = new EventEntities())
            {
                return EE.EVENTs.Find(evtid);
            }
        }

        public List<EVENT> UserEvent()
        {
            int loggeduserid = (new LoginSession()).GetSession().LOGINID;
            using (EventEntities EE = new EventEntities())
            {
                List<EVENT> evts = new List<EVENT>();
                foreach (EVENT e in EE.EVENTs.ToList())
                {
                    if (e.LOGINID == loggeduserid)
                        evts.Add(e);
                }
                return evts;
            }
        }

    }
}