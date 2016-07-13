using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISOWebApps.Models
{
    public class KendBengkel
    {
        public int ID { get; set; }
        public string NamaBengkel { get; set; }
        public string Telepon { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<KendBengkel> KendBengkels { get; set; }

    }
}