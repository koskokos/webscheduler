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
    
    public partial class PropertyTypes
    {
        public PropertyTypes()
        {
            this.Properties = new HashSet<Properties>();
        }
    
        public int Id { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Properties> Properties { get; set; }
    }
}
