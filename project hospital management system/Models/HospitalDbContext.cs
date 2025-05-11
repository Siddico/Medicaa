using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project_hospital_management_system.Models
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext() : base("DefaultConnection")
        {
            // This will create the database if it doesn't exist
            Database.SetInitializer(new CreateDatabaseIfNotExists<HospitalDbContext>());
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
