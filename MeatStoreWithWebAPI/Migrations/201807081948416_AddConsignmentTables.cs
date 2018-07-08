namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsignmentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consignments",
                c => new
                    {
                        ConsignmentId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        MeatType = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SuppliedDate = c.DateTime(nullable: false),
                        BillAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ConsignmentId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consignments", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Consignments", new[] { "VendorId" });
            DropTable("dbo.Consignments");
        }
    }
}
