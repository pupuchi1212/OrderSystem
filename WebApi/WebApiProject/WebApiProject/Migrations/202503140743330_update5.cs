namespace WebApiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProdCount", c => c.Int(nullable: false));
            Sql("EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'數量' , @level0type = N'SCHEMA',@level0name = N'dbo', @level1type = N'TABLE',@level1name = N'OrderDetails', @level2type = N'COLUMN',@level2name = N'ProdCount'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "ProdCount");
        }
    }
}
