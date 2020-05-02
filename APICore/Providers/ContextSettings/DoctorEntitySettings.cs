using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICore.Providers.ContextSettings
{
    public class DoctorEntitySettings : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> modelbuilder) {           
            modelbuilder.ToTable("M_DOCTOR");

            modelbuilder.HasKey(m => m.Cpf);

            modelbuilder.Property(m => m.Cpf)
                .HasColumnName("CPF")
                .ValueGeneratedNever()
                .HasMaxLength(11)
                .IsRequired();

            modelbuilder.Property(m => m.FirstName)
                 .HasColumnName("FIRST_NAME")
                 .HasMaxLength(30)
                 .IsRequired();

            modelbuilder.Property(m => m.LastName)
                 .HasColumnName("LAST_NAME")
                 .HasMaxLength(70)
                 .IsRequired();

            modelbuilder.Property(m => m.Crm)
                 .HasColumnName("CRM")
                 .HasMaxLength(6)
                 .IsRequired();

            modelbuilder.Property(m => m.Speciality)
                 .HasColumnName("SPECIALITY")
                 .HasMaxLength(39)
                 .IsRequired();

            modelbuilder.Property(m => m.Id)
                 .HasColumnName("USER_ID")
                 .IsRequired();
        }
    }
}
