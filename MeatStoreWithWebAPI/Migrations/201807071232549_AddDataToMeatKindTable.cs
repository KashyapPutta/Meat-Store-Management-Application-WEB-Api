namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMeatKindTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MeatKinds(MeatName) VALUES('Beef')");
            Sql("INSERT INTO MeatKinds(MeatName) VALUES('Chicken')");
            Sql("INSERT INTO MeatKinds(MeatName) VALUES('Fish')");
        }
        
        public override void Down()
        {

        }
    }
}
