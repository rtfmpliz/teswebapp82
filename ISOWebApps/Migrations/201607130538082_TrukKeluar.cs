namespace ISOWebApps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrukKeluar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jabatan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JabatanDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Karyawan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NIK = c.String(),
                        NamaKaryawan = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TrukKeluar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TglReport = c.DateTime(nullable: false),
                        KaryawanID = c.String(),
                        KendaraanID = c.Int(nullable: false),
                        Tujuan = c.String(),
                        JenisMuatanBrkt = c.String(),
                        TonMuatanBrkt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JenisMuatanPlg = c.String(),
                        TonMuatanPlg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TglBerangkat = c.DateTime(nullable: false),
                        TglPulang = c.DateTime(nullable: false),
                        Karyawan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Karyawan", t => t.Karyawan_ID)
                .ForeignKey("dbo.Kendaraan", t => t.KendaraanID, cascadeDelete: true)
                .Index(t => t.KendaraanID)
                .Index(t => t.Karyawan_ID);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SectionDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrukKeluar", "KendaraanID", "dbo.Kendaraan");
            DropForeignKey("dbo.TrukKeluar", "Karyawan_ID", "dbo.Karyawan");
            DropIndex("dbo.TrukKeluar", new[] { "Karyawan_ID" });
            DropIndex("dbo.TrukKeluar", new[] { "KendaraanID" });
            DropTable("dbo.Section");
            DropTable("dbo.TrukKeluar");
            DropTable("dbo.Karyawan");
            DropTable("dbo.Jabatan");
            DropTable("dbo.Department");
        }
    }
}
