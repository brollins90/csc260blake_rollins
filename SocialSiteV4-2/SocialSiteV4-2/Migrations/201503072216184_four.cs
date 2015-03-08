namespace SocialSiteV4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class four : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Id" });
            DropColumn("dbo.AspNetUsers", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Profile_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Profile_Id");
            AddForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
