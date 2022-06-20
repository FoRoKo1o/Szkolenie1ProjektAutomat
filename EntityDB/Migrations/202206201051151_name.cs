namespace EntityDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "VendID", "dbo.Vends");
            /*DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Products", "ProductID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Vends");
            AddColumn("dbo.Vends", "VendID", c => c.Int(nullable: false, identity: true));
            */
            RenameColumn("dbo.Products", "ID", "ProductID");
            RenameColumn("dbo.Vends", "ID", "VendID");
            //AddPrimaryKey("dbo.Products", "ProductID");
            //AddPrimaryKey("dbo.Vends", "VendID");
            AddForeignKey("dbo.Products", "VendID", "dbo.Vends", "VendID", cascadeDelete: true);
            //DropColumn("dbo.Products", "ID");
            //DropColumn("dbo.Vends", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vends", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Products", "VendID", "dbo.Vends");
            DropPrimaryKey("dbo.Vends");
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Vends", "VendID");
            DropColumn("dbo.Products", "ProductID");
            AddPrimaryKey("dbo.Vends", "ID");
            AddPrimaryKey("dbo.Products", "ID");
            AddForeignKey("dbo.Products", "VendID", "dbo.Vends", "ID", cascadeDelete: true);
        }
    }
}
