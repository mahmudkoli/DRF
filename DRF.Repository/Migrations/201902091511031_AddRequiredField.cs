namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chambers", "MapId", "dbo.Maps");
            DropForeignKey("dbo.Doctors", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.Schedules", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.Vacations", "ChamberId", "dbo.Chambers");
            DropIndex("dbo.Chambers", new[] { "MapId" });
            DropIndex("dbo.Doctors", new[] { "BloodGroupId" });
            DropIndex("dbo.Schedules", new[] { "ChamberId" });
            DropIndex("dbo.Vacations", new[] { "ChamberId" });
            AlterColumn("dbo.Appointments", "AppointmentType", c => c.Int(nullable: false));
            AlterColumn("dbo.Chambers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Chambers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Chambers", "MapId", c => c.Int());
            AlterColumn("dbo.Areas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Maps", "Lat", c => c.String(nullable: false));
            AlterColumn("dbo.Maps", "Long", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "FathersName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "MothersName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "PresentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "PermanentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Experience", c => c.Int());
            AlterColumn("dbo.Doctors", "BloodGroupId", c => c.Int());
            AlterColumn("dbo.BloodGroups", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genders", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Degrees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Specialties", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Schedules", "ChamberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vacations", "ChamberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Chambers", "MapId");
            CreateIndex("dbo.Doctors", "BloodGroupId");
            CreateIndex("dbo.Schedules", "ChamberId");
            CreateIndex("dbo.Vacations", "ChamberId");
            AddForeignKey("dbo.Chambers", "MapId", "dbo.Maps", "Id");
            AddForeignKey("dbo.Doctors", "BloodGroupId", "dbo.BloodGroups", "Id");
            AddForeignKey("dbo.Schedules", "ChamberId", "dbo.Chambers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vacations", "ChamberId", "dbo.Chambers", "Id", cascadeDelete: true);
            DropColumn("dbo.BloodGroups", "CreatedAt");
            DropColumn("dbo.BloodGroups", "UpdatedAt");
            DropColumn("dbo.BloodGroups", "Status");
            DropColumn("dbo.Genders", "CreatedAt");
            DropColumn("dbo.Genders", "UpdatedAt");
            DropColumn("dbo.Genders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genders", "Status", c => c.Byte(nullable: false));
            AddColumn("dbo.Genders", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Genders", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.BloodGroups", "Status", c => c.Byte(nullable: false));
            AddColumn("dbo.BloodGroups", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.BloodGroups", "CreatedAt", c => c.DateTime());
            DropForeignKey("dbo.Vacations", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.Schedules", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.Doctors", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.Chambers", "MapId", "dbo.Maps");
            DropIndex("dbo.Vacations", new[] { "ChamberId" });
            DropIndex("dbo.Schedules", new[] { "ChamberId" });
            DropIndex("dbo.Doctors", new[] { "BloodGroupId" });
            DropIndex("dbo.Chambers", new[] { "MapId" });
            AlterColumn("dbo.Vacations", "ChamberId", c => c.Int());
            AlterColumn("dbo.Schedules", "ChamberId", c => c.Int());
            AlterColumn("dbo.Specialties", "Name", c => c.String());
            AlterColumn("dbo.Degrees", "Name", c => c.String());
            AlterColumn("dbo.Genders", "Name", c => c.String());
            AlterColumn("dbo.BloodGroups", "Name", c => c.String());
            AlterColumn("dbo.Doctors", "BloodGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "Experience", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "PermanentAddress", c => c.String());
            AlterColumn("dbo.Doctors", "PresentAddress", c => c.String());
            AlterColumn("dbo.Doctors", "MothersName", c => c.String());
            AlterColumn("dbo.Doctors", "FathersName", c => c.String());
            AlterColumn("dbo.Doctors", "Phone", c => c.String());
            AlterColumn("dbo.Maps", "Long", c => c.String());
            AlterColumn("dbo.Maps", "Lat", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
            AlterColumn("dbo.Areas", "Name", c => c.String());
            AlterColumn("dbo.Chambers", "MapId", c => c.Int(nullable: false));
            AlterColumn("dbo.Chambers", "Address", c => c.String());
            AlterColumn("dbo.Chambers", "Name", c => c.String());
            AlterColumn("dbo.Appointments", "AppointmentType", c => c.Int());
            CreateIndex("dbo.Vacations", "ChamberId");
            CreateIndex("dbo.Schedules", "ChamberId");
            CreateIndex("dbo.Doctors", "BloodGroupId");
            CreateIndex("dbo.Chambers", "MapId");
            AddForeignKey("dbo.Vacations", "ChamberId", "dbo.Chambers", "Id");
            AddForeignKey("dbo.Schedules", "ChamberId", "dbo.Chambers", "Id");
            AddForeignKey("dbo.Doctors", "BloodGroupId", "dbo.BloodGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chambers", "MapId", "dbo.Maps", "Id", cascadeDelete: true);
        }
    }
}
