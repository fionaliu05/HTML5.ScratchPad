namespace HTML5.ScratchPad.DDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 100, unicode: false),
                        Surname = c.String(nullable: false, maxLength: 150, unicode: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Active = c.Boolean(),
                        InceptionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        Value = c.Decimal(nullable: false, precision: 9, scale: 2),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Product", new[] { "CustomerId" });
            DropTable("dbo.Product");
            DropTable("dbo.Customer");
        }
    }
}
