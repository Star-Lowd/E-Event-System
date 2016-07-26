using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class Imagemodel
    {
        public string Add(EVENTIMAGE evt)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    EE.EVENTIMAGEs.Add(evt);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }

        public List<EVENTIMAGE> EventImage(int evtid)
        {
            using (EventEntities EE = new EventEntities())
            {
                List<EVENTIMAGE> images = new List<EVENTIMAGE>();
                foreach (EVENTIMAGE img in EE.EVENTIMAGEs.ToList())
                {
                    if (img.EVENTID == evtid)
                        images.Add(img);
                }
                return images;
            }
        }

    }
}