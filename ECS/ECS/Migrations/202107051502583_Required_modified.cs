namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required_modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credentials", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "DOB", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Credentials", "Password", c => c.String());
        }
    }
}
