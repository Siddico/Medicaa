namespace project_hospital_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicalRecordTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalRecords",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Diagnosis = c.String(nullable: false),
                        Treatment = c.String(nullable: false),
                        RecordDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.MedicalRecords", new[] { "DoctorId" });
            DropIndex("dbo.MedicalRecords", new[] { "PatientId" });
            DropTable("dbo.MedicalRecords");
        }
    }
}
