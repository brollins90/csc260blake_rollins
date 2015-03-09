namespace SocialSiteV4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles");
            AddForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles");
            AddForeignKey("dbo.AspNetUsers", "Profile_Id", "dbo.Profiles", "Id", cascadeDelete: true);
        }
    }
}
