//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISOWebApps.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MtcReport
    {
        public int ID { get; set; }
        public string DocNumber { get; set; }
        public System.DateTime ReportDate { get; set; }
        public string Mesin { get; set; }
        public string Unit { get; set; }
        public string Part { get; set; }
        public string Kerusakan { get; set; }
        public string PartsPengganti { get; set; }
        public string Penyimpanan { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Inspection { get; set; }
        public string Repaired { get; set; }
    }
}
