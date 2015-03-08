namespace SocialSiteV4_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
