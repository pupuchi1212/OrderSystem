namespace WebApiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單表' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Orders'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Orders', @level2type = N'COLUMN',@level2name = N'OrderId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'使用者Id' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Orders', @level2type = N'COLUMN',@level2name = N'UserId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'產品Id' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Orders', @level2type = N'COLUMN',@level2name = N'ProductId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單日期' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Orders', @level2type = N'COLUMN',@level2name = N'OrderDate'");

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'產品表' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Products'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'產品編號' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Products', @level2type = N'COLUMN',@level2name = N'ProductId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'產品名稱' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Products', @level2type = N'COLUMN',@level2name = N'Name'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'價格' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'Products', @level2type = N'COLUMN',@level2name = N'Price'");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
