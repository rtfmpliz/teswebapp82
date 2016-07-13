using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class ProblemKendaraan
    {
        public int ProblemKendaraanID { get; set; }
        public string Problem { get; set; }
        public bool Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JadwalTunda { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TglDikerjakan { get; set; }
        
        public string Detail { get; set; }

        public virtual LapService LapService { get; set; }
    }
}