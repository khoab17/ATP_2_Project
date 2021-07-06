namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_user_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
