namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Credentials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Credentials");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
