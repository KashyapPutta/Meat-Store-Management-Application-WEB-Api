namespace MeatStoreWithWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToVendorTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Vendors(VendorName, ContactNum, EmailId, DateAdded, Address) VALUES('Kashyap', 4092739375, 'kbcputta.1994@gmail.com', getDate(), '5160 Cheek street')");
            Sql("INSERT INTO Vendors(VendorName, ContactNum, EmailId, DateAdded, Address) VALUES('Rethan', 8603800381, 'rethanvit@gmail.com', getDate(), '5160 Cheek street')");

        }
        
        public override void Down()
        {
        }
    }
}
