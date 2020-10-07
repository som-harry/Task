namespace HarryStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrandTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Brands (Name) VALUES ('Funky Footwear')");
            Sql("INSERT INTO Brands (Name) VALUES ('Jewelery Place')");
            Sql("INSERT INTO Brands (Name) VALUES ('Happy Handi')");
            Sql("INSERT INTO Brands (Name) VALUES ('Catchy Ladies')");
            Sql("INSERT INTO Brands (Name) VALUES ('NBA')");
            Sql("INSERT INTO Brands (Name) VALUES ('Benz')");
            Sql("INSERT INTO Brands (Name) VALUES ('Provison')");
            Sql("INSERT INTO Brands (Name) VALUES ('Fruits')");
            Sql("INSERT INTO Brands (Name) VALUES ('LG')");
            Sql("INSERT INTO Brands (Name) VALUES ('SamSong')");
            Sql("INSERT INTO Brands (Name) VALUES ('Jack Canfield')");
        }
        
        public override void Down()
        {
        }
    }
}
