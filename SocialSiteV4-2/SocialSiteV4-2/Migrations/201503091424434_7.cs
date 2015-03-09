namespace SocialSiteV4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "User_Id" });
            DropColumn("dbo.Profiles", "User_Id");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropTable("dbo.News");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Article = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Profiles", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Profiles", "User_Id");
            AddForeignKey("dbo.Profiles", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
