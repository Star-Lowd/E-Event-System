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
    
    public partial class LOGIN
    {
        public LOGIN()
        {
            this.ACCOUNTs = new HashSet<ACCOUNT>();
            this.EVENTs = new HashSet<EVENT>();
            this.LIKEs = new HashSet<LIKE>();
            this.COMMENTs = new HashSet<COMMENT>();
            this.REPLies = new HashSet<REPLY>();
        }
    
        public int LOGINID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORDHASH { get; set; }
        public string EMAIL { get; set; }
    
        public virtual ICollection<ACCOUNT> ACCOUNTs { get; set; }
        public virtual ICollection<EVENT> EVENTs { get; set; }
        public virtual ICollection<LIKE> LIKEs { get; set; }
        public virtual ICollection<COMMENT> COMMENTs { get; set; }
        public virtual ICollection<REPLY> REPLies { get; set; }
    }
}
