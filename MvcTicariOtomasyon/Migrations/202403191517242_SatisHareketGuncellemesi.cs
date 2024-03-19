namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SatisHareketGuncellemesi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHarekets", "Cariler_Cariid", "dbo.Carilers");
            DropForeignKey("dbo.SatisHarekets", "Personel_Personelid", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Urun_Urunid", "dbo.Uruns");
            DropIndex("dbo.SatisHarekets", new[] { "Cariler_Cariid" });
            DropIndex("dbo.SatisHarekets", new[] { "Personel_Personelid" });
            DropIndex("dbo.SatisHarekets", new[] { "Urun_Urunid" });
            RenameColumn(table: "dbo.SatisHarekets", name: "Cariler_Cariid", newName: "Cariid");
            RenameColumn(table: "dbo.SatisHarekets", name: "Personel_Personelid", newName: "Personelid");
            RenameColumn(table: "dbo.SatisHarekets", name: "Urun_Urunid", newName: "Urunid");
            AlterColumn("dbo.SatisHarekets", "Cariid", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "Personelid", c => c.Int(nullable: false));
            AlterColumn("dbo.SatisHarekets", "Urunid", c => c.Int(nullable: false));
            CreateIndex("dbo.SatisHarekets", "Urunid");
            CreateIndex("dbo.SatisHarekets", "Cariid");
            CreateIndex("dbo.SatisHarekets", "Personelid");
            AddForeignKey("dbo.SatisHarekets", "Cariid", "dbo.Carilers", "Cariid", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "Personelid", "dbo.Personels", "Personelid", cascadeDelete: true);
            AddForeignKey("dbo.SatisHarekets", "Urunid", "dbo.Uruns", "Urunid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisHarekets", "Urunid", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarekets", "Personelid", "dbo.Personels");
            DropForeignKey("dbo.SatisHarekets", "Cariid", "dbo.Carilers");
            DropIndex("dbo.SatisHarekets", new[] { "Personelid" });
            DropIndex("dbo.SatisHarekets", new[] { "Cariid" });
            DropIndex("dbo.SatisHarekets", new[] { "Urunid" });
            AlterColumn("dbo.SatisHarekets", "Urunid", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "Personelid", c => c.Int());
            AlterColumn("dbo.SatisHarekets", "Cariid", c => c.Int());
            RenameColumn(table: "dbo.SatisHarekets", name: "Urunid", newName: "Urun_Urunid");
            RenameColumn(table: "dbo.SatisHarekets", name: "Personelid", newName: "Personel_Personelid");
            RenameColumn(table: "dbo.SatisHarekets", name: "Cariid", newName: "Cariler_Cariid");
            CreateIndex("dbo.SatisHarekets", "Urun_Urunid");
            CreateIndex("dbo.SatisHarekets", "Personel_Personelid");
            CreateIndex("dbo.SatisHarekets", "Cariler_Cariid");
            AddForeignKey("dbo.SatisHarekets", "Urun_Urunid", "dbo.Uruns", "Urunid");
            AddForeignKey("dbo.SatisHarekets", "Personel_Personelid", "dbo.Personels", "Personelid");
            AddForeignKey("dbo.SatisHarekets", "Cariler_Cariid", "dbo.Carilers", "Cariid");
        }
    }
}
