namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToInventoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Inventories(MeatKindId, QuantityInStock) VALUES(1, 100)");
            Sql("INSERT INTO Inventories(MeatKindId, QuantityInStock) VALUES(3, 120)");
            Sql("INSERT INTO Inventories(MeatKindId, QuantityInStock) VALUES(2, 85)");
        }
        
        public override void Down()
        {
        }
    }
}
