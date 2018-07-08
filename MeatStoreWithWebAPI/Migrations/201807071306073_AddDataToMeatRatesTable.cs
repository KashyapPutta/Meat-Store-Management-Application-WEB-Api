namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMeatRatesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MeatRates(MeatKindId, CostPerLb, CostPerLbBoneless) VALUES(1, 3, 5)");
            Sql("INSERT INTO MeatRates(MeatKindId, CostPerLb, CostPerLbBoneless) VALUES(2, 8, 12)");
            Sql("INSERT INTO MeatRates(MeatKindId, CostPerLb, CostPerLbBoneless) VALUES(3, 15, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
