using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class CommentModel
    {
        public string Add(COMMENT comment)
        {
            using (EventEntities EE = new EventEntities())
            {
                try
                {
                    EE.COMMENTs.Add(comment);
                    EE.SaveChanges();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.StackTrace + "<br />" + ex.Message;
                }
            }
        }


        public int CountComment(int evtid)
        {
            List<COMMENT> v = new List<COMMENT>();
            using (EventEntities EE = new EventEntities())
            {
                foreach (COMMENT comment in EE.COMMENTs.ToList())
                {
                    if (comment.EVENTID == evtid)
                        v.Add(comment);
                }
                return v.Count;
            }
        }

        public List<COMMENT> List(int eventid)
        {
            List<COMMENT> comments = new List<COMMENT>();
            foreach (COMMENT comm in new EventEntities().COMMENTs.ToList())
            {
                if (comm.EVENTID == eventid)
                    comments.Add(comm);
            }
            return comments;
        }
    }
}