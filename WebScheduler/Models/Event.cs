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
    
    public partial class Event
    {
        public Event()
        {
            this.PropertiesValuesBool = new HashSet<PropertiesValuesBool>();
            this.PropertiesValuesDateTime = new HashSet<PropertiesValuesDateTime>();
            this.PropertiesValuesImages = new HashSet<PropertiesValuesImages>();
            this.PropertiesValuesInt = new HashSet<PropertiesValuesInt>();
            this.PropertiesValuesString = new HashSet<PropertiesValuesString>();
            this.Folders = new HashSet<Folders>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDateTime { get; set; }
        public int TemplateId { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    
        public virtual EventTemplates EventTemplates { get; set; }
        public virtual UserData UserData { get; set; }
        public virtual ICollection<PropertiesValuesBool> PropertiesValuesBool { get; set; }
        public virtual ICollection<PropertiesValuesDateTime> PropertiesValuesDateTime { get; set; }
        public virtual ICollection<PropertiesValuesImages> PropertiesValuesImages { get; set; }
        public virtual ICollection<PropertiesValuesInt> PropertiesValuesInt { get; set; }
        public virtual ICollection<PropertiesValuesString> PropertiesValuesString { get; set; }
        public virtual ICollection<Folders> Folders { get; set; }
    }
}
