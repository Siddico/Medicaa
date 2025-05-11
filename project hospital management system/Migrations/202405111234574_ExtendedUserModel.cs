namespace project_hospital_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendedUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "Department", c => c.String());
            AddColumn("dbo.AspNetUsers", "DoctorId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DoctorId");
            AddForeignKey("dbo.AspNetUsers", "DoctorId", "dbo.Doctors", "DoctorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.AspNetUsers", new[] { "DoctorId" });
            DropColumn("dbo.AspNetUsers", "DoctorId");
            DropColumn("dbo.AspNetUsers", "Department");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
