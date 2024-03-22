namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CariDurum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carilers", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carilers", "Durum");
        }
    }
}
