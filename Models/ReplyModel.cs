using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class ReplyModel
    {
        public string Add (REPLY reply)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.REPLies.Add(reply);
                    EE.SaveChanges();
                    return "Saved";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public List<REPLY> List(int Commentid)
        {
            List<REPLY> reply = new List<REPLY>();
            using (EventEntities EE = new EventEntities())
            {
                foreach (REPLY re in EE.REPLies.ToList())
                {
                    if (re.COMMENTID == Commentid)
                        reply.Add(re);
                }
                
            }
            return reply;
        }
    }
}