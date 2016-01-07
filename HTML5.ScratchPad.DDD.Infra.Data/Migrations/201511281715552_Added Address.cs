namespace HTML5.ScratchPad.DDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        AddressLine1 = c.String(nullable: false, maxLength: 100, unicode: false),
                        AddressLine2 = c.String(maxLength: 100, unicode: false),
                        AddressLine3 = c.String(maxLength: 100, unicode: false),
                        AddressLine4 = c.String(maxLength: 100, unicode: false),
                        Postcode = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Customer", t => t.AddressId)
                .Index(t => t.AddressId);
            
            AddColumn("dbo.Customer", "AddressId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "AddressId", "dbo.Customer");
            DropIndex("dbo.Address", new[] { "AddressId" });
            DropColumn("dbo.Customer", "AddressId");
            DropTable("dbo.Address");
        }
    }
}
