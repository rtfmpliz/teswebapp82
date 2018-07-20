using ISOWebApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ISOWebApps.DAL
{
    public class KendaraanContext :DbContext

    {
        public KendaraanContext() : base("KendaraanContext")
        {

        }
        public DbSet<Kendaraan> Kendaraans { get; set; }
        public DbSet<LapService> LapServices { get; set; }
        public DbSet<ProblemKendaraan> ProblemKendaraan { get; set; }

        public DbSet<Karyawan> Karyawans { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Jabatan> Jabatans { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ISOWebApps.Models.TrukKeluar> TrukKeluars { get; set; }
    }
}