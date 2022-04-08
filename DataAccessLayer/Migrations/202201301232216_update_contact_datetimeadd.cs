namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_contact_datetimeadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactMDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactMDate");
        }
    }
}
