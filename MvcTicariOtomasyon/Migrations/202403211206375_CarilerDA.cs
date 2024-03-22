﻿namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarilerDA : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carilers", "CariSoyad", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carilers", "CariSoyad", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
