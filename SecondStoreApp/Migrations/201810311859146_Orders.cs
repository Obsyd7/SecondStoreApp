namespace SecondStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "Postcode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Order", "Phone", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Order", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "Email", c => c.String());
            AlterColumn("dbo.Order", "Phone", c => c.String());
            AlterColumn("dbo.Order", "Postcode", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Order", "Address");
            RenameIndex(table: "dbo.Order", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
