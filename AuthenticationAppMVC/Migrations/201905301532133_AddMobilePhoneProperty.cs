namespace AuthenticationAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMobilePhoneProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobilePhone");
        }
    }
}
