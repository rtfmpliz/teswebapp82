using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class TrukKeluar
    {
        public int ID { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TglReport { get; set; }

        public string KaryawanID { get; set; }
        public int KendaraanID { get; set; }
        public string Tujuan { get; set; }
        public string JenisMuatanBrkt { get; set; }
        public decimal TonMuatanBrkt { get; set; }

        public string JenisMuatanPlg { get; set; }
        public decimal TonMuatanPlg { get; set; }

        public DateTime TglBerangkat { get; set; }
        public DateTime TglPulang { get; set; }


        public virtual Kendaraan Kendaraan { get; set; }
        public virtual Karyawan Karyawan { get; set; }
    }
}