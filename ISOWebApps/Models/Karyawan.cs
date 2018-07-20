using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class Karyawan
    {
        public int ID { get; set; }
        public string NIK { get; set; }
        public string NamaKaryawan { get; set; }
        public virtual ICollection<TrukKeluar> TrukKeluars { get; set; }
    }
}