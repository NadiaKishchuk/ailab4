using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace webapi.Entity
{
    public class ClinicDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }

        public ClinicDbContext():base() { }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(u => u.Symptoms).WithMany(s => s.Users)
                .UsingEntity<UserSymptoms>(
                us => us.HasOne(u => u.Symptom).WithMany().HasForeignKey(u => u.SymptomId),
                sp => sp.HasOne(u => u.User).WithMany().HasForeignKey(x => x.UserId));

            modelBuilder.Entity<Disease>().HasMany(d => d.Symptoms).WithMany(s => s.Diseases)
              .UsingEntity<DiseaseSymptomValue>(sp => sp.HasOne(ds => ds.Symptom).WithMany().HasForeignKey(x =>x.SymptomId),
              sp => sp.HasOne(ds => ds.Disease).WithMany().HasForeignKey(x => x.DiseaseId));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=DESKTOP-I7Q35NQ\\SQLEXPRESS;Initial Catalog=lab4;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
