using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class LapService
    {
        public int LapServiceID { get; set; }
        public int KendaraanID { get; set; }

        public int Perkiraan { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Waktu { get; set; }
        public string Bengkel { get; set; }
        public string AlamatTelp { get; set; }
        public string Keterangan { get; set; }

        public virtual Kendaraan Kendaraan { get; set; }
        //public virtual KendBengkel KendBengkel { get; set; }

        public virtual ICollection<ProblemKendaraan> ProblemKendaraans { get; set; }
    }
}