namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeThedepositMoneyNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BalanceInAccount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BalanceInAccount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
