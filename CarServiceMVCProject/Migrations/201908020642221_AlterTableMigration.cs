namespace CarServiceMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUserId" });
            DropColumn("dbo.Cars", "ApplicationUserId");
        }
        
        public override void Down()
        {
        }
    }
}
