//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.Entity
{
    using System;
    using System.Collections.Generic;
    
    [Serializable] 
     public partial class Hotkeys
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Modifiers { get; set; }
    }
}
