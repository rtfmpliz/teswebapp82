using ISOWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISOWebApps.DAL
{
    public class KendaraanInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<KendaraanContext>
    {
        protected override void Seed(KendaraanContext context)
        {
            var kendaraans = new List<Kendaraan>
            {
                new Kendaraan { NoPol="Forlift 20 ton",TipeKendaraan="Forklift" },
            };
            kendaraans.ForEach(s => context.Kendaraans.Add(s));
            context.SaveChanges();

            var lapservices = new List<LapService>
            {
                new LapService {KendaraanID=1,Perkiraan=300000,Waktu=DateTime.Parse("04-03-2016") }
            };
            lapservices.ForEach(s => context.LapServices.Add(s));
            context.SaveChanges();
        }
    }
}