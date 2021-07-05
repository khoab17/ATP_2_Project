namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableUP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Unit");
        }
    }
}
