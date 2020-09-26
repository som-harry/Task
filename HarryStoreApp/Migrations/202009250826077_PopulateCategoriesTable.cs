namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ( 'Bags')");
            Sql("INSERT INTO Categories (Name) VALUES ('Apparel')");
            Sql("INSERT INTO Categories (Name) VALUES ('Accessories')");
            Sql("INSERT INTO Categories (Name) VALUES ('Beauty')");
            Sql("INSERT INTO Categories (Name) VALUES ('Cosmetics')");
            Sql("INSERT INTO Categories (Name) VALUES ('Electronics')");
            Sql("INSERT INTO Categories (Name) VALUES ('Toys')");
            Sql("INSERT INTO Categories (Name) VALUES ('Supplements')");
        }
        
        public override void Down()
        {
        }
    }
}
