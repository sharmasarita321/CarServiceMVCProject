namespace CarServiceMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ApplicationUserId", c => c.String(maxLength:128));
           
            CreateIndex("dbo.Cars", "ApplicationUserId");
            AddForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
