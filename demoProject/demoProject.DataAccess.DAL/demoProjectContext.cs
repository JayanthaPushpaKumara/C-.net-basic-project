using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using demoProject.common.model;

namespace IJSE.Student.DataAccess.DLL
{
    public class demoProjectContext : DbContext
    {
        public demoProjectContext() : base("DemoProjectDB") { } //database name

        public DbSet<StudentModel> student { get; set; }        //this model class reference in common.model project
        public DbSet<EnrollmentModel> Enrollment { get; set; }
        public DbSet<CouresModel> Course { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}