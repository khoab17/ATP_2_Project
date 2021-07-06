namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productTable_updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
