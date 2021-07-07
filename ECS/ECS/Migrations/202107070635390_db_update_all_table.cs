namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_update_all_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Orders_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Orders_Id);
            
            AddColumn("dbo.Products", "SellerId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "user_Id", c => c.Int());
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderAddress", c => c.String());
            AddColumn("dbo.Orders", "Amount", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "user_Id");
            AddForeignKey("dbo.Products", "user_Id", "dbo.Users", "Id");
            DropColumn("dbo.Orders", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "user_Id", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Orders_Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "user_Id" });
            DropColumn("dbo.Orders", "Amount");
            DropColumn("dbo.Orders", "OrderAddress");
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Products", "user_Id");
            DropColumn("dbo.Products", "SellerId");
            DropTable("dbo.OrderDetails");
        }
    }
}
