namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Adminid = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Adminid);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        Cariid = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        SatisHareket_Satisid = c.Int(),
                    })
                .PrimaryKey(t => t.Cariid)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_Satisid)
                .Index(t => t.SatisHareket_Satisid);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        Satisid = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Satisid);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Personelid = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departman_Departmanid = c.Int(),
                        SatisHareket_Satisid = c.Int(),
                    })
                .PrimaryKey(t => t.Personelid)
                .ForeignKey("dbo.Departmen", t => t.Departman_Departmanid)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_Satisid)
                .Index(t => t.Departman_Departmanid)
                .Index(t => t.SatisHareket_Satisid);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Departmanid = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Departmanid);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Urunid = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        Kategori_KategoriID = c.Int(),
                        SatisHareket_Satisid = c.Int(),
                    })
                .PrimaryKey(t => t.Urunid)
                .ForeignKey("dbo.Kategoris", t => t.Kategori_KategoriID)
                .ForeignKey("dbo.SatisHarekets", t => t.SatisHareket_Satisid)
                .Index(t => t.Kategori_KategoriID)
                .Index(t => t.SatisHareket_Satisid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturalar_Faturaid = c.Int(),
                    })
                .PrimaryKey(t => t.FaturaKalemid)
                .ForeignKey("dbo.Faturalars", t => t.Faturalar_Faturaid)
                .Index(t => t.Faturalar_Faturaid);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        Faturaid = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSiraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.DateTime(nullable: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Faturaid);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        Giderid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Giderid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturalar_Faturaid", "dbo.Faturalars");
            DropForeignKey("dbo.Uruns", "SatisHareket_Satisid", "dbo.SatisHarekets");
            DropForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris");
            DropForeignKey("dbo.Personels", "SatisHareket_Satisid", "dbo.SatisHarekets");
            DropForeignKey("dbo.Personels", "Departman_Departmanid", "dbo.Departmen");
            DropForeignKey("dbo.Carilers", "SatisHareket_Satisid", "dbo.SatisHarekets");
            DropIndex("dbo.FaturaKalems", new[] { "Faturalar_Faturaid" });
            DropIndex("dbo.Uruns", new[] { "SatisHareket_Satisid" });
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriID" });
            DropIndex("dbo.Personels", new[] { "SatisHareket_Satisid" });
            DropIndex("dbo.Personels", new[] { "Departman_Departmanid" });
            DropIndex("dbo.Carilers", new[] { "SatisHareket_Satisid" });
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
