using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class VideoModel
    {
        public List<EVENTVIDEO> Videos (int evid )
        {
            using (EventEntities EE = new EventEntities())
            {
                List<EVENTVIDEO> Videos = new List<EVENTVIDEO>();
                foreach (EVENTVIDEO Ev in EE.EVENTVIDEOs.ToList())
                {
                    if (Ev.EVENTID == evid)
                        Videos.Add(Ev);
                }
                return Videos;
            }
        }
        public string Add(EVENTVIDEO video)
        {
            using (EventEntities EE = new EventEntities())
            {
                try
                {
                    EE.EVENTVIDEOs.Add(video);
                    EE.SaveChanges();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.StackTrace + "<br />" + ex.Message;
                }
            }
        }
    }
}