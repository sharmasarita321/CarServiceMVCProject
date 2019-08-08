namespace CarServiceMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthenticateUpgrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "ApplicationUserId");
            AddForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUserId" });
            DropColumn("dbo.Cars", "ApplicationUserId");
        }
    }
}
