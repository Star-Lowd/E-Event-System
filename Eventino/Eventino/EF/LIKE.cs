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
    
    public partial class LIKE
    {
        public int LIKEID { get; set; }
        public Nullable<int> ACCOUNTID { get; set; }
        public Nullable<int> EVENTID { get; set; }
        public Nullable<int> LOGINID { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual EVENT EVENT { get; set; }
        public virtual LOGIN LOGIN { get; set; }
    }
}