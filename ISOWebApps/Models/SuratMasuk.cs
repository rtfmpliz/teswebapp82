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
    
    public partial class SuratMasuk
    {
        public int SuratMasukId { get; set; }
        public System.DateTime TglSuratMasuk { get; set; }
        public System.TimeSpan JamSuratMasuk { get; set; }
        public short JumlahSurat { get; set; }
        public string JenisSurat { get; set; }
        public string Pengirim { get; set; }
        public string Kepada { get; set; }
        public string PenerimaSecurity { get; set; }
        public string PenerimaKantor { get; set; }
        public string Verifikasi { get; set; }
    }
}