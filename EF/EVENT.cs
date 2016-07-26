//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eventino.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class EVENT
    {
        public EVENT()
        {
            this.COMMENTs = new HashSet<COMMENT>();
            this.EVENTIMAGEs = new HashSet<EVENTIMAGE>();
            this.EVENTVIDEOs = new HashSet<EVENTVIDEO>();
            this.LIKEs = new HashSet<LIKE>();
            this.VIEWs = new HashSet<VIEW>();
        }
    
        public int EVENTID { get; set; }
        public string NAME { get; set; }
        public string DATE { get; set; }
        public string STARTTIME { get; set; }
        public string STOPTIME { get; set; }
        public string LOCATION { get; set; }
        public string SHORTDESC { get; set; }
        public string LONGDESC { get; set; }
        public string POSTEDDATE { get; set; }
        public Nullable<int> EVENTTYPEID { get; set; }
        public Nullable<bool> RELEASED { get; set; }
        public Nullable<int> LOGINID { get; set; }
    
        public virtual ICollection<COMMENT> COMMENTs { get; set; }
        public virtual EVENTTYPE EVENTTYPE { get; set; }
        public virtual ICollection<EVENTIMAGE> EVENTIMAGEs { get; set; }
        public virtual ICollection<EVENTVIDEO> EVENTVIDEOs { get; set; }
        public virtual ICollection<LIKE> LIKEs { get; set; }
        public virtual ICollection<VIEW> VIEWs { get; set; }
        public virtual LOGIN LOGIN { get; set; }
    }
}
