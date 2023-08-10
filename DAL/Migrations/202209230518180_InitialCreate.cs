namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Credit = c.String(),
                        Phone = c.String(),
                        Code = c.String(),
                        Picture = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Insurance = c.Int(nullable: false),
                        DeleteStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Info = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        DeleteStatus = c.Boolean(nullable: false),
                        visit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Visits", t => t.visit_Id)
                .Index(t => t.visit_Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PatientSigns = c.String(),
                        DoctorIdea = c.String(),
                        Drugs = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        DeleteStatus = c.Boolean(nullable: false),
                        patient_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.patient_id)
                .Index(t => t.patient_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "visit_Id", "dbo.Visits");
            DropForeignKey("dbo.Visits", "patient_id", "dbo.Patients");
            DropIndex("dbo.Visits", new[] { "patient_id" });
            DropIndex("dbo.Prescriptions", new[] { "visit_Id" });
            DropTable("dbo.Visits");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.Patients");
        }
    }
}
