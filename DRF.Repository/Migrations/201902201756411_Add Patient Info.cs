namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Phone", c => c.String());
            AddColumn("dbo.Patients", "Profession", c => c.String());
            AddColumn("dbo.Patients", "Note", c => c.String());
            AddColumn("dbo.Patients", "FathersName", c => c.String());
            AddColumn("dbo.Patients", "MothersName", c => c.String());
            AddColumn("dbo.Patients", "PresentAddress", c => c.String());
            AddColumn("dbo.Patients", "PermanentAddress", c => c.String());
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Patients", "ImageUrl", c => c.String());
            AddColumn("dbo.Patients", "GenderId", c => c.Int());
            AddColumn("dbo.Patients", "BloodGroupId", c => c.Int());
            CreateIndex("dbo.Patients", "GenderId");
            CreateIndex("dbo.Patients", "BloodGroupId");
            AddForeignKey("dbo.Patients", "BloodGroupId", "dbo.BloodGroups", "Id");
            AddForeignKey("dbo.Patients", "GenderId", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Patients", "BloodGroupId", "dbo.BloodGroups");
            DropIndex("dbo.Patients", new[] { "BloodGroupId" });
            DropIndex("dbo.Patients", new[] { "GenderId" });
            DropColumn("dbo.Patients", "BloodGroupId");
            DropColumn("dbo.Patients", "GenderId");
            DropColumn("dbo.Patients", "ImageUrl");
            DropColumn("dbo.Patients", "DateOfBirth");
            DropColumn("dbo.Patients", "PermanentAddress");
            DropColumn("dbo.Patients", "PresentAddress");
            DropColumn("dbo.Patients", "MothersName");
            DropColumn("dbo.Patients", "FathersName");
            DropColumn("dbo.Patients", "Note");
            DropColumn("dbo.Patients", "Profession");
            DropColumn("dbo.Patients", "Phone");
        }
    }
}
