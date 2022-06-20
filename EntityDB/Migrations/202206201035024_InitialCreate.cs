namespace EntityDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendID = c.Int(nullable: false),
                        Name = c.String(),
                        Cost = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vends", t => t.VendID, cascadeDelete: true)
                .Index(t => t.VendID);
            
            CreateTable(
                "dbo.Vends",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerBalance = c.Single(nullable: false),
                        VendBalance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendID", "dbo.Vends");
            DropIndex("dbo.Products", new[] { "VendID" });
            DropTable("dbo.Vends");
            DropTable("dbo.Products");
        }
    }
}
