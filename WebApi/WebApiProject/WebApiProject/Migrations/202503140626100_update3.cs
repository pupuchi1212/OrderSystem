namespace WebApiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderInfoes", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單明細表' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderDetails'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'流水號' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderDetails', @level2type = N'COLUMN',@level2name = N'Id'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderDetails', @level2type = N'COLUMN',@level2name = N'OrderId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'產品Id' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderDetails', @level2type = N'COLUMN',@level2name = N'ProductId'");

            CreateTable(
                "dbo.OrderInfoes",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單主表' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderInfoes'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderInfoes', @level2type = N'COLUMN',@level2name = N'OrderId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'使用者Id' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderInfoes', @level2type = N'COLUMN',@level2name = N'UserId'");
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'訂單日期' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderInfoes', @level2type = N'COLUMN',@level2name = N'OrderDate'");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.ProductInfoes");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderInfoes");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.OrderInfoes");
            DropTable("dbo.OrderDetails");
        }
    }
}
