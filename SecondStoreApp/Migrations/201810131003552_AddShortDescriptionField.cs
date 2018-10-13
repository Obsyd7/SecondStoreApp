namespace SecondStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "ShortDescription");
        }
    }
}
