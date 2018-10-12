namespace SecondStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingUpDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDescription = c.String(nullable: false, maxLength: 100),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CourseTitle = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                        ImgFileName = c.String(maxLength: 100),
                        CourseDescription = c.String(),
                        CoursePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderPosition",
                c => new
                    {
                        OrderPositionId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        OrderCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderPositionId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Postcode = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderPosition", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderPosition", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.OrderPosition", new[] { "CourseId" });
            DropIndex("dbo.OrderPosition", new[] { "OrderId" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderPosition");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
