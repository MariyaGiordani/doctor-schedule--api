using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICore.Providers.ContextSettings
{
    public class UserEntitySettings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelbuilder) {
            modelbuilder.ToTable("U_USER");

            modelbuilder.HasKey(u => u.Id);

            modelbuilder.Property(u => u.Id)
                .HasColumnName("USER_ID")
                .IsRequired();

            modelbuilder.Property(u => u.Password)
                 .HasColumnName("USER_PASSWORD")
                 .HasMaxLength(100)
                 .IsRequired();

            modelbuilder.Property(u => u.UserName)
                 .HasColumnName("USER_NAME")
                 .HasMaxLength(100)
                 .IsRequired();            

            modelbuilder.HasOne(m => m.Doctor).WithOne(u => u.User).HasForeignKey<Doctor>(u => u.Id).IsRequired();
            modelbuilder.HasOne(p => p.Patient).WithOne(u => u.User).HasForeignKey<Patient>(u => u.Id).IsRequired();
        }
    }
}
