﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ISOEntities : DbContext
    {
        public ISOEntities()
            : base("name=ISOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SuratMasuk> SuratMasuks { get; set; }
        public virtual DbSet<MtcReport> MtcReports { get; set; }
        public virtual DbSet<Truk> Truks { get; set; }
        public virtual DbSet<TrukReport> TrukReports { get; set; }
    }
}
