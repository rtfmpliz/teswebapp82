using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class Kendaraan
       
    {
        public int ID { get; set; }
        public string NoPol { get; set; }
        public string TipeKendaraan { get; set; }

        public virtual ICollection<LapService> LapServices { get; set; }
        public virtual ICollection<TrukKeluar> TrukKeluars { get; set; }
    }
}