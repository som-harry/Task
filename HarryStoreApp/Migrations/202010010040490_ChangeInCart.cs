namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Cart_Id", c => c.Int());
            CreateIndex("dbo.OrderItems", "Cart_Id");
            AddForeignKey("dbo.OrderItems", "Cart_Id", "dbo.Carts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.OrderItems", new[] { "Cart_Id" });
            DropColumn("dbo.OrderItems", "Cart_Id");
        }
    }
}
