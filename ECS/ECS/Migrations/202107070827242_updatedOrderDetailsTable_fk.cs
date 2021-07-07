namespace ECS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedOrderDetailsTable_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Orders_Id" });
            RenameColumn(table: "dbo.OrderDetails", name: "Orders_Id", newName: "OrderId");
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.OrderDetails", name: "OrderId", newName: "Orders_Id");
            CreateIndex("dbo.OrderDetails", "Orders_Id");
            AddForeignKey("dbo.OrderDetails", "Orders_Id", "dbo.Orders", "Id");
        }
    }
}
