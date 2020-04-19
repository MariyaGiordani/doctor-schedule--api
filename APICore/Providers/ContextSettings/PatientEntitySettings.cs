using APICore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace APICore.Providers.ContextSettings
{
    public class PatientEntitySettings : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> modelbuilder) {
            modelbuilder.ToTable("P_PATIENT");

            modelbuilder.HasKey(p => p.Cpf);

            modelbuilder.Property(p => p.Cpf)
                .HasColumnName("CPF")
                .HasColumnType("NUMERIC(11,0)")
                .ValueGeneratedNever()
                .IsRequired();

            modelbuilder.Property(p => p.FirstName)
                 .HasColumnName("FIRST_NAME")
                 .HasMaxLength(30)
                 .IsRequired();

            modelbuilder.Property(p => p.LastName)
                 .HasColumnName("LAST_NAME")
                 .HasMaxLength(70)
                 .IsRequired();

            modelbuilder.Property(p => p.Email)
                 .HasColumnName("EMAIL")
                 .HasMaxLength(70)
                 .IsRequired();

            modelbuilder.Property(p => p.Id)
                 .HasColumnName("USER_ID")
                 .IsRequired();
        }
    }
}
