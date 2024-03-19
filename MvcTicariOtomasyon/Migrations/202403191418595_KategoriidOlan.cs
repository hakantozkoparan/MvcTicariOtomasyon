namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriidOlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategori_KategoriID" });
            RenameColumn(table: "dbo.Uruns", name: "Kategori_KategoriID", newName: "Kategoriid");
            AlterColumn("dbo.Uruns", "Kategoriid", c => c.Int(nullable: false));
            CreateIndex("dbo.Uruns", "Kategoriid");
            AddForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris", "KategoriID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "Kategoriid" });
            AlterColumn("dbo.Uruns", "Kategoriid", c => c.Int());
            RenameColumn(table: "dbo.Uruns", name: "Kategoriid", newName: "Kategori_KategoriID");
            CreateIndex("dbo.Uruns", "Kategori_KategoriID");
            AddForeignKey("dbo.Uruns", "Kategori_KategoriID", "dbo.Kategoris", "KategoriID");
        }
    }
}
