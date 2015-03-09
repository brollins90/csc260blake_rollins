//namespace SocialSiteV4_2.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class sdaf : DbMigration
//    {
//        public override void Up()
//        {
//            DropIndex("dbo.Profiles", new[] { "User_Id" });
//            AlterColumn("dbo.Profiles", "User_Id", c => c.String(maxLength: 128));
//            CreateIndex("dbo.Profiles", "User_Id");
//            DropColumn("dbo.AspNetUsers", "BirthDate");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
//            DropIndex("dbo.Profiles", new[] { "User_Id" });
//            AlterColumn("dbo.Profiles", "User_Id", c => c.String(nullable: false, maxLength: 128));
//            CreateIndex("dbo.Profiles", "User_Id");
//        }
//    }
//}
