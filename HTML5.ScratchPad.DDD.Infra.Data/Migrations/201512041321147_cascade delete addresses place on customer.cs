namespace HTML5.ScratchPad.DDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedeleteaddressesplaceoncustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "AddressId", "dbo.Customer");
            AddForeignKey("dbo.Address", "AddressId", "dbo.Customer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "AddressId", "dbo.Customer");
            AddForeignKey("dbo.Address", "AddressId", "dbo.Customer", "Id");
        }
    }
}
