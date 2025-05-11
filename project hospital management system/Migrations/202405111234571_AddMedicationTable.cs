namespace project_hospital_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        MedicationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Dose = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MedicationId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Medications");
        }
    }
}
