namespace CarServiceMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForAuthentication : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            AlterColumn("dbo.ServiceTypes", "ServiceName", c => c.String(nullable: false));
            DropColumn("dbo.Cars", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceTypes", "ServiceName", c => c.String());
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
