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
    
    public partial class Languages
    {
        public Languages()
        {
            this.StringsLocalization = new HashSet<StringsLocalization>();
            this.UserData = new HashSet<UserData>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    
        public virtual ICollection<StringsLocalization> StringsLocalization { get; set; }
        public virtual ICollection<UserData> UserData { get; set; }
    }
}
