namespace SocialSiteV4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Profile_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Profile_Id");
            AddForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Id" });
            DropColumn("dbo.AspNetUsers", "Profile_Id");
        }
    }
}
