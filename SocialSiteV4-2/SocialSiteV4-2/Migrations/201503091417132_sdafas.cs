//namespace SocialSiteV4_2.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class sdafas : DbMigration
//    {
//        public override void Up()
//        {
//            DropIndex("dbo.Profiles", new[] { "User_Id" });
//            RenameColumn(table: "dbo.AspNetUsers", name: "User_Id", newName: "Profile_Id");
//            CreateIndex("dbo.AspNetUsers", "Profile_Id");
//            DropColumn("dbo.Profiles", "User_Id");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.Profiles", "User_Id", c => c.String(maxLength: 128));
//            DropIndex("dbo.AspNetUsers", new[] { "Profile_Id" });
//            RenameColumn(table: "dbo.AspNetUsers", name: "Profile_Id", newName: "User_Id");
//            CreateIndex("dbo.Profiles", "User_Id");
//        }
//    }
//}
