//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebScheduler.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Images
    {
        public Images()
        {
            this.EventTemplates = new HashSet<EventTemplates>();
            this.PropertiesValuesImages = new HashSet<PropertiesValuesImages>();
            this.UserData = new HashSet<UserData>();
        }
    
        public int Id { get; set; }
        public byte[] Image { get; set; }
    
        public virtual ICollection<EventTemplates> EventTemplates { get; set; }
        public virtual ICollection<PropertiesValuesImages> PropertiesValuesImages { get; set; }
        public virtual ICollection<UserData> UserData { get; set; }
    }
}
