namespace project_hospital_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "PatientId", "dbo.Patients");
            DropIndex("dbo.Invoices", new[] { "PatientId" });
            DropTable("dbo.Invoices");
        }
    }
}
