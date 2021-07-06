namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Id", "dbo.Credentials");
            DropIndex("dbo.Users", new[] { "Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Credentials", "UserId");
            AddForeignKey("dbo.Credentials", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credentials", "UserId", "dbo.Users");
            DropIndex("dbo.Credentials", new[] { "UserId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            CreateIndex("dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Id", "dbo.Credentials", "Id");
        }
    }
}
