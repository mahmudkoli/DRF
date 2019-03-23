namespace DRF.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredDoctorEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "FathersName", c => c.String());
            AlterColumn("dbo.Doctors", "MothersName", c => c.String());
            AlterColumn("dbo.Doctors", "PresentAddress", c => c.String());
            AlterColumn("dbo.Doctors", "PermanentAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "PermanentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "PresentAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "MothersName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "FathersName", c => c.String(nullable: false));
        }
    }
}
