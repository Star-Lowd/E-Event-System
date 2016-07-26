using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class ViewModel
    {
        public int CountView(int evtid)
        {
            List<VIEW> v = new List<VIEW>();
            using (EventEntities EE = new EventEntities())
            {
                foreach (VIEW view in EE.VIEWs.ToList())
                {
                    if (view.EVENTID == evtid)
                        v.Add(view);
                }
                return v.Count;
            }
        }
        public bool Exist(string ipaddress, int eventid)
        {
            using (EventEntities EE = new EventEntities())
            {
                foreach (VIEW view in EE.VIEWs.ToList())
                {
                    if (view.IPADDRESS == ipaddress && view.EVENTID == eventid)
                        return true;
                }
            }
            return false;
        }
        public string Add(VIEW v)
        {
            try
            {
                using (EventEntities EE = new EventEntities())
                {
                    //if (this.Exist(v.IPADDRESS, v.EVENTID.Value))
                    //    return "Duplicate Ip Address Found";
                    EE.VIEWs.Add(v);
                    EE.SaveChanges();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace + "<br />" + ex.Message;
            }
        }
    }
}