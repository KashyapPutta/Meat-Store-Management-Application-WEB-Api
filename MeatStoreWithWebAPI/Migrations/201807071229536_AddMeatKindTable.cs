namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeatKindTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeatKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MeatKinds");
        }
    }
}
