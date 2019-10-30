namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificationChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationObjectId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.NotificationObjects", t => t.NotificationObjectId, cascadeDelete: true)
                .Index(t => t.NotificationObjectId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.NotificationObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityTypeId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationObjectId = c.Int(nullable: false),
                        NotifierId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsReminder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NotificationObjects", t => t.NotificationObjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.NotifierId, cascadeDelete: true)
                .Index(t => t.NotificationObjectId)
                .Index(t => t.NotifierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "NotifierId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotificationObjectId", "dbo.NotificationObjects");
            DropForeignKey("dbo.NotificationChanges", "NotificationObjectId", "dbo.NotificationObjects");
            DropForeignKey("dbo.NotificationChanges", "ActorId", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "NotifierId" });
            DropIndex("dbo.Notifications", new[] { "NotificationObjectId" });
            DropIndex("dbo.NotificationChanges", new[] { "ActorId" });
            DropIndex("dbo.NotificationChanges", new[] { "NotificationObjectId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.NotificationObjects");
            DropTable("dbo.NotificationChanges");
        }
    }
}
