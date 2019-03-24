namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertiesInDoctorEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "ProfessionalStatement", c => c.String());
            AddColumn("dbo.Doctors", "EducationalStatement", c => c.String());
            AddColumn("dbo.Doctors", "EducationalCurriculum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "EducationalCurriculum");
            DropColumn("dbo.Doctors", "EducationalStatement");
            DropColumn("dbo.Doctors", "ProfessionalStatement");
        }
    }
}
