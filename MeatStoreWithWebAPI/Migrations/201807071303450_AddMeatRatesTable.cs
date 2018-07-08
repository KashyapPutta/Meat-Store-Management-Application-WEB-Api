namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeatRatesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeatRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatKindId = c.Int(nullable: false),
                        CostPerLb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerLbBoneless = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeatKinds", t => t.MeatKindId, cascadeDelete: true)
                .Index(t => t.MeatKindId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeatRates", "MeatKindId", "dbo.MeatKinds");
            DropIndex("dbo.MeatRates", new[] { "MeatKindId" });
            DropTable("dbo.MeatRates");
        }
    }
}
