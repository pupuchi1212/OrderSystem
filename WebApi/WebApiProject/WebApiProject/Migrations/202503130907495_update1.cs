﻿namespace WebApiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "ProductInfoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductInfoes", newName: "Products");
        }
    }
}
