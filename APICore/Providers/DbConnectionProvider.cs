using Microsoft.EntityFrameworkCore;
using APICore.Model;
using APICore.Providers.ContextSettings;

namespace APICore.Database
{
    public class DbConnectionProvider : DbContext
    {
        public DbConnectionProvider(DbContextOptions<DbConnectionProvider> options)
              : base(options)
        { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder) {
            base.OnModelCreating(modelbuilder);

            //Apply User Configuration
            modelbuilder.ApplyConfiguration(new UserEntitySettings());
            //modelbuilder.ApplyConfiguration(new DoctorEntitySettings());
            //modelbuilder.ApplyConfiguration(new PatientEntitySettings());
        }
    }
}
