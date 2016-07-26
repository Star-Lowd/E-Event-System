using Eventino.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventino.Models
{
    public class EventTypeModel
    {
        public string FindEventType(int evtType)
        {
            using (EventEntities EE = new EventEntities())
            {
                return EE.EVENTTYPEs.Find(evtType).EVENTTYENAME;
            }
        }
    }
}