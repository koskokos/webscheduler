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
    
    public partial class StringNames
    {
        public StringNames()
        {
            this.StringsLocalization = new HashSet<StringsLocalization>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<StringsLocalization> StringsLocalization { get; set; }
    }
}
