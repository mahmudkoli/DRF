namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDoctorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        ChamberId = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        AppointmentTime = c.DateTime(nullable: false),
                        AppointmentStatus = c.Int(nullable: false),
                        Disease = c.String(),
                        Reason = c.String(),
                        AppointmentType = c.Int(),
                        AppointmentFees = c.Double(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chambers", t => t.ChamberId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.ChamberId);
            
            CreateTable(
                "dbo.Chambers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        AreaId = c.Int(nullable: false),
                        MapId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: true)
                .Index(t => t.AreaId)
                .Index(t => t.MapId);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lat = c.String(),
                        Long = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Designation = c.String(),
                        Awards = c.String(),
                        Description = c.String(),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Experience = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        GenderId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.BloodGroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ConsultationFees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        New = c.Double(nullable: false),
                        Regular = c.Double(),
                        Checkup = c.Double(),
                        DoctorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorChamberRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        ChamberId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chambers", t => t.ChamberId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.ChamberId);
            
            CreateTable(
                "dbo.DoctorDegreeRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.DoctorSpecialtyRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Disease = c.String(),
                        Details = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        DurationTime = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        ChamberId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chambers", t => t.ChamberId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.ChamberId);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        DoctorId = c.Int(nullable: false),
                        ChamberId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chambers", t => t.ChamberId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.ChamberId);
            
            DropColumn("dbo.Users", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            DropForeignKey("dbo.Vacations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Vacations", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.Schedules", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Schedules", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.DoctorSpecialtyRelations", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.DoctorSpecialtyRelations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorDegreeRelations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorDegreeRelations", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.DoctorChamberRelations", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorChamberRelations", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.ConsultationFees", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "UserId", "dbo.Users");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Doctors", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Doctors", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.Appointments", "ChamberId", "dbo.Chambers");
            DropForeignKey("dbo.Chambers", "MapId", "dbo.Maps");
            DropForeignKey("dbo.Chambers", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Vacations", new[] { "ChamberId" });
            DropIndex("dbo.Vacations", new[] { "DoctorId" });
            DropIndex("dbo.Schedules", new[] { "ChamberId" });
            DropIndex("dbo.Schedules", new[] { "DoctorId" });
            DropIndex("dbo.DoctorSpecialtyRelations", new[] { "SpecialtyId" });
            DropIndex("dbo.DoctorSpecialtyRelations", new[] { "DoctorId" });
            DropIndex("dbo.DoctorDegreeRelations", new[] { "DegreeId" });
            DropIndex("dbo.DoctorDegreeRelations", new[] { "DoctorId" });
            DropIndex("dbo.DoctorChamberRelations", new[] { "ChamberId" });
            DropIndex("dbo.DoctorChamberRelations", new[] { "DoctorId" });
            DropIndex("dbo.ConsultationFees", new[] { "DoctorId" });
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropIndex("dbo.Doctors", new[] { "BloodGroupId" });
            DropIndex("dbo.Doctors", new[] { "GenderId" });
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropIndex("dbo.Chambers", new[] { "MapId" });
            DropIndex("dbo.Chambers", new[] { "AreaId" });
            DropIndex("dbo.Appointments", new[] { "ChamberId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Vacations");
            DropTable("dbo.Schedules");
            DropTable("dbo.Specialties");
            DropTable("dbo.DoctorSpecialtyRelations");
            DropTable("dbo.DoctorDegreeRelations");
            DropTable("dbo.DoctorChamberRelations");
            DropTable("dbo.Degrees");
            DropTable("dbo.ConsultationFees");
            DropTable("dbo.Patients");
            DropTable("dbo.Genders");
            DropTable("dbo.BloodGroups");
            DropTable("dbo.Doctors");
            DropTable("dbo.Maps");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
            DropTable("dbo.Chambers");
            DropTable("dbo.Appointments");
        }
    }
}
